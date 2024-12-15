using Humanizer;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ReducedGrinding.Global
{
    public class LuckInfoDisplay : InfoDisplay
    {
        public static Color RedInfoTextColor => new(255, 25, 25, Main.mouseTextColor);

        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<GlobalPlayer>().showLuck;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            int luckDisplayed = (int)(Main.LocalPlayer.luck * 100f);

            int baseLuck = Main.LocalPlayer.usedGalaxyPearl ? 3 : 0;

            if (luckDisplayed < (0 - baseLuck))
            {
                displayColor = RedInfoTextColor;
            }
            else if (luckDisplayed <= baseLuck)
            {
                displayColor = InactiveInfoTextColor;
            }

            return Language.GetTextValue("Mods.ReducedGrinding.Misc.LuckInfoDisplay").FormatWith(luckDisplayed);
        }
    }
}
