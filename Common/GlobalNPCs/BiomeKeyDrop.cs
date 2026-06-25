using ReducedGrinding.Configuration;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalNPCs
{
    public class BiomeKeyDrop : GlobalNPC
    {
        private static readonly int biomeKeyGuaranteed = GetInstance<EnemyLootConfig>().GuaranteedBiomeKey;
        public static int jungleHardmodeKills;
        public static int corruptionHardmodeKills;
        public static int crimsonHardmodeKills;
        public static int hallowHardmodeKills;
        public static int snowHardmodeKills;
        public static int desertHardmodeKills;

        public override void OnKill(NPC npc)
        {
            if (npc.value <= 0 || !Main.hardMode || biomeKeyGuaranteed == 0)
            {
                return;
            }

            Player closestPlayer = Main.player[Player.FindClosest(npc.position, npc.width, npc.height)];

            CalculateBiomeKills(closestPlayer, closestPlayer.ZoneJungle, ref jungleHardmodeKills, ItemID.JungleKey, npc);
            CalculateBiomeKills(closestPlayer, closestPlayer.ZoneCorrupt, ref corruptionHardmodeKills, ItemID.CorruptionKey, npc);
            CalculateBiomeKills(closestPlayer, closestPlayer.ZoneCrimson, ref crimsonHardmodeKills, ItemID.CrimsonKey, npc);
            CalculateBiomeKills(closestPlayer, closestPlayer.ZoneHallow, ref hallowHardmodeKills, ItemID.HallowedKey, npc);
            CalculateBiomeKills(closestPlayer, closestPlayer.ZoneSnow, ref snowHardmodeKills, ItemID.FrozenKey, npc);
            CalculateBiomeKills(closestPlayer, closestPlayer.ZoneDesert, ref desertHardmodeKills, ItemID.DungeonDesertKey, npc);
        }

        public static void CalculateBiomeKills(Player player, bool inZone, ref int kills, int biomeKey, NPC npc)
        {
            if (!inZone)
            {
                return;
            }

            GuaranteedBiomeKeyBehaviorEnums guaranteedBiomeKeyBehavior = GetInstance<EnemyLootConfig>().GuaranteedBiomeKeyBehavior;
            const GuaranteedBiomeKeyBehaviorEnums giveOneTime = GuaranteedBiomeKeyBehaviorEnums.GiveOneTime;

            if (kills >= biomeKeyGuaranteed && guaranteedBiomeKeyBehavior == giveOneTime)
            {
                return;
            }

            kills++;
            if (kills >= biomeKeyGuaranteed)
            {
                Item.NewItem(npc.GetSource_Loot(), player.getRect(), biomeKey);
                if (guaranteedBiomeKeyBehavior != giveOneTime)
                {
                    kills = 0;
                }
            }
        }
    }
}
