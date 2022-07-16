using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
    public class PlanteraSap : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plantera Sap");
            Tooltip.SetDefault("Use in the Jungle to summon Plantera");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;

            NPCID.Sets.MPAllowedEnemies[NPCID.Plantera] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.value = 0;
            Item.rare = ItemRarityID.Lime;
            Item.useAnimation = 20;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.ForceRoar;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ZoneJungle && Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && !NPC.AnyNPCs(NPCID.Plantera);
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                SoundEngine.PlaySound(SoundID.Roar, player.position);

                int type = NPCID.Plantera;

                if (Main.netMode != NetmodeID.MultiplayerClient)
                    NPC.SpawnOnPlayer(player.whoAmI, type);
                else
                    NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
            }

            return true;
        }
    }
}