using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Common.GlobalItems
{
    public class FasterInvasionSummons : GlobalItem
    {
        public static bool instantInvasion;

        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            int type = item.type;
            return type == ItemID.GoblinBattleStandard || type == ItemID.PirateMap || type == ItemID.SnowGlobe;
        }

        public override bool? UseItem(Item item, Player player)
        {
            instantInvasion = true;
            return null;
        }
    }

    public class FasterInvasionSummonsSystem : ModSystem
    {
        public override void PostUpdateInvasions()
        {
            if (FasterInvasionSummons.instantInvasion)
            {
                Main.invasionX = Main.invasionX > Main.spawnTileX ? Main.spawnTileX + 1 : Main.spawnTileX - 1;
                FasterInvasionSummons.instantInvasion = false;
            }
        }
    }
}
