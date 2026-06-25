using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration
{
    public enum HolidaySummonsEnums
    {
        Disabled,
        RequireSeason,
        Enabled,
    }

    public class EventAndBossConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool OldManVoodooDoll { get; set; }

        [ReloadRequired]
        [DefaultValue(true)]
        public bool WorldPeaceStandard { get; set; }

        [ReloadRequired]
        [Range(0, 24)]
        [DefaultValue(1)]
        public int WarStandardDuration { get; set; }

        [ReloadRequired]
        [DefaultValue(HolidaySummonsEnums.RequireSeason)]
        public HolidaySummonsEnums HolidaySummons { get; set; }

        [ReloadRequired]
        [DefaultValue(2)]
        [Range(0, 100)]
        public int LunarSigil { get; set; }

        [ReloadRequired]
        [DefaultValue(true)]
        public bool CelestialWard { get; set; }

        [DefaultValue(true)]
        public bool NPCArrivalMessages { get; set; }

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [DefaultValue(0)]
        public int PlanteraSapFromPlantera { get; set; }
    }
}
