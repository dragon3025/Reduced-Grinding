using ReducedGrinding.Configuration;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalItems
{

    public class BattlePotionChanges : GlobalItem
    {
        private static readonly BattlePotionConfig battlePotion = GetInstance<BattlePotionConfig>();

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return battlePotion.VanillaDuration != 7 && item.type == ItemID.BattlePotion;
        }

        public override void SetDefaults(Item item)
        {
            item.buffTime = battlePotion.VanillaDuration * 60 * 60;
        }
    }
}
