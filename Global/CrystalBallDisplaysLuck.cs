using ReducedGrinding.Configuration;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace ReducedGrinding.GlobalCrystalBallDisplaysLuck
{
    public class CrystalBallDisplaysLuck : GlobalItem
    {
        readonly static IOtherConfig otherConfig = GetInstance<IOtherConfig>();

        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.CrystalBall;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (!otherConfig.ClairvoyanceShowsLuck)
            {
                return;
            }

            tooltips.Add(new(Mod, "GlobalCrystalBallDisplaysLuck", Language.GetTextValue("Mods.ReducedGrinding.Misc.ClairvoyanceLuckTooltip")));
        }
    }
}
