using Humanizer;
using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common
{
    public class LuckInfoDisplay : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<LuckInfoDisplayPlayer>().showLuck;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            int luckDisplayed = (int)(Main.LocalPlayer.luck * 100f);

            int baseLuck = Main.LocalPlayer.usedGalaxyPearl ? 3 : 0;

            if (luckDisplayed < (0 - baseLuck))
            {
                displayColor = new(255, 25, 25, Main.mouseTextColor);
            }
            else if (luckDisplayed <= baseLuck)
            {
                displayColor = InactiveInfoTextColor;
            }

            return ReducedGrinding.GetText("Misc.LuckInfoDisplay").FormatWith(luckDisplayed);
        }
    }

    public class LuckInfoDisplayItem : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.CrystalBall;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (!GetInstance<OtherConfig>().ClairvoyanceShowsLuck)
            {
                return;
            }

            tooltips.Add(new(Mod, "GlobalCrystalBallDisplaysLuck", ReducedGrinding.GetText("Misc.ClairvoyanceLuckTooltip")));
        }
    }

    public class LuckInfoDisplayBuff : GlobalBuff
    {
        public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare)
        {
            if (!GetInstance<OtherConfig>().ClairvoyanceShowsLuck)
            {
                return;
            }

            if (type == BuffID.Clairvoyance)
            {
                tip += "\n";
                tip += ReducedGrinding.GetText("Misc.ClairvoyanceLuckTooltip");
            }
        }
    }

    public class LuckInfoDisplayPlayer : ModPlayer
    {
        public bool showLuck;

        public override void ResetInfoAccessories()
        {
            if (!GetInstance<OtherConfig>().ClairvoyanceShowsLuck)
            {
                return;
            }

            showLuck = false;

            if (Player.HasBuff(BuffID.Clairvoyance))
            {
                showLuck = true;
            }
        }

        public override void RefreshInfoAccessoriesFromTeamPlayers(Player otherPlayer)
        {
            if (otherPlayer.GetModPlayer<LuckInfoDisplayPlayer>().showLuck)
            {
                showLuck = true;
            }
        }
    }
}
