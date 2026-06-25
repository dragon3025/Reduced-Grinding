using ReducedGrinding.Configuration;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common
{
    internal class UniversalPylon : GlobalPylon
    {
        public override bool? ValidTeleportCheck_PreNPCCount(TeleportPylonInfo pylonInfo, ref int defaultNecessaryNPCCount)
        {
            if (pylonInfo.TypeOfPylon != TeleportPylonType.Victory || !GetInstance<OtherConfig>().EarlyUniPylonNerf)
            {
                return base.ValidTeleportCheck_PreNPCCount(pylonInfo, ref defaultNecessaryNPCCount);
            }

            if (Main.GetBestiaryProgressReport().CompletionPercent < 1f)
            {
                defaultNecessaryNPCCount = 2;
            }

            return base.ValidTeleportCheck_PreNPCCount(pylonInfo, ref defaultNecessaryNPCCount);
        }

        public override void PostValidTeleportCheck(TeleportPylonInfo destinationPylonInfo, TeleportPylonInfo nearbyPylonInfo, ref bool destinationPylonValid, ref bool validNearbyPylonFound, ref string errorKey)
        {
            if (!GetInstance<OtherConfig>().EarlyUniPylonNerf || Main.GetBestiaryProgressReport().CompletionPercent >= 1f)
            {
                return;
            }

            if (destinationPylonInfo.TypeOfPylon == TeleportPylonType.Victory)
            {
                errorKey = ReducedGrinding.GetText("Misc.UniversalPylonBestiaryFail.Destination");
            }
            else if (nearbyPylonInfo.TypeOfPylon == TeleportPylonType.Victory)
            {
                errorKey = ReducedGrinding.GetText("Misc.UniversalPylonBestiaryFail.Nearby");
            }
        }
    }

    internal class UniversalPylonItem : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == ItemID.TeleportationPylonVictory;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (!GetInstance<OtherConfig>().EarlyUniPylonNerf || Main.GetBestiaryProgressReport().CompletionPercent >= 1f)
            {
                return;
            }

            string tooltip = ReducedGrinding.GetText("Misc.UniversalPylonBestiaryFail.Tooltip");
            tooltips.Add(new TooltipLine(Mod, "UniversalPylonNerfTooltip", tooltip));
        }
    }
}
