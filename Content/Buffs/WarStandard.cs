using ReducedGrinding.Configuration;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Buffs
{
    public class WarStandard : ModBuff
    {
        public override LocalizedText Description
        {
            get
            {
                if (!GetInstance<BattlePotionConfig>().GreaterBattlePotion)
                {
                    return base.Description;
                }

                return Language.GetOrRegister("Mods.ReducedGrinding.Misc.WarStandardBattleBuffTooltip");
            }
        }
    }
}