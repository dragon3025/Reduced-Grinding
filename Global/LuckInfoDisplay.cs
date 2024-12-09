using Humanizer;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ReducedGrinding.Global
{
    public class LuckInfoDisplay : InfoDisplay
    {
        public static Color RedInfoTextColor => new(255, 128, 128, Main.mouseTextColor);

        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<GlobalPlayer>().showLuck;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            int luckDisplayed = (int)(Main.LocalPlayer.luck * 100f);

            if (luckDisplayed == 0)
            {
                displayColor = InactiveInfoTextColor;
            }
            else if (luckDisplayed < 0)
            {
                displayColor = RedInfoTextColor;
            }

            return Language.GetTextValue("Mods.ReducedGrinding.Misc.LuckInfoDisplay").FormatWith(luckDisplayed);
        }
    }
}
