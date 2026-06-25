using ReducedGrinding.Configuration;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalNPCs
{
    public class SpawnSmallMimic
    {
        public static bool SmallMimicSummonCheck(On_NPC.orig_BigMimicSummonCheck orig, int x, int y, Player player)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient || !Main.hardMode || !GetInstance<VillagersAndEnemiesConfig>().AllowSpawningRegularMimics)
            {
                return orig(x, y, player);
            }

            int chestIndex = Chest.FindChest(x, y);
            if (chestIndex < 0)
            {
                return orig(x, y, player);
            }
            int keyOfLightCount = 0;
            int keyOfNightCount = 0;
            ushort selectedChest = Main.tile[Main.chest[chestIndex].x, Main.chest[chestIndex].y].TileType;
            int frame = Main.tile[Main.chest[chestIndex].x, Main.chest[chestIndex].y].TileFrameX / 36;
            if (selectedChest == 21 && frame > 4 && frame < 7)
            {
                return orig(x, y, player);
            }

            for (int slot = 0; slot < 40; slot++)
            {
                Item item = Main.chest[chestIndex].item[slot];
                if (item == null || item.type <= ItemID.None)
                {
                    continue;
                }
                if (item.type == ItemID.LightKey)
                {
                    keyOfLightCount += item.stack;
                }
                else if (item.type == ItemID.NightKey)
                {
                    keyOfNightCount += item.stack;
                }
                else
                {
                    keyOfLightCount = keyOfNightCount = 0;
                    break;
                }
                if (keyOfLightCount > 1 || keyOfNightCount > 1)
                {
                    break;
                }
            }
            if (keyOfLightCount != 1 || keyOfNightCount != 1)
            {
                return orig(x, y, player);
            }

            if (Main.tile[x, y].TileFrameX % 36 != 0)
            {
                x--;
            }
            if (Main.tile[x, y].TileFrameY % 36 != 0)
            {
                y--;
            }
            int chest = Chest.FindChest(x, y);
            for (int j = 0; j < 40; j++)
            {
                Main.chest[chestIndex].item[j].SetDefaults(ItemID.None);
            }
            Chest.DestroyChest(x, y);
            for (int k = x; k <= x + 1; k++)
            {
                for (int l = y; l <= y + 1; l++)
                {
                    Main.tile[k, l].ClearTile();
                }
            }
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.ChestUpdates, -1, -1, null, 1, x, y, 0f, chest);
                NetMessage.SendTileSquare(-1, x, y, 3);
            }
            //Note Small Non-Ice Mimics all have the same Id, the type used depends on the height spawned.
            int mimicType = player.ZoneSnow ? NPCID.IceMimic : NPCID.Mimic;
            int newMimic = NPC.NewNPC(player.GetSource_FromThis(), x * 16 + 16, y * 16 + 32, mimicType);
            NPC npc = Main.npc[newMimic];
            npc.whoAmI = newMimic;
            Item.NewItem(npc.GetSource_DropAsItem(), npc.getRect(), ItemID.SoulofLight, Main.rand.Next(7, 9));
            Item.NewItem(npc.GetSource_DropAsItem(), npc.getRect(), ItemID.SoulofNight, Main.rand.Next(7, 9));
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.SyncNPC, number: newMimic);
            }
            npc.BigMimicSpawnSmoke();
            return false;
        }
    }

    public class SpawnSmallMimicSystem : ModSystem
    {
        public override void Load()
        {
            On_NPC.BigMimicSummonCheck += SpawnSmallMimic.SmallMimicSummonCheck;
        }
    }
}
