using System;
using System.ComponentModel;
using Terraria.ID;
using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration
{
    public class TimeAndWeatherConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [ReloadRequired]
        public ItemDefinition MoonWatchMaterial { get; set; }

        [ReloadRequired]
        public ItemDefinition MoonWatchAlternateMaterial { get; set; }

        [ReloadRequired]
        [Range(1, 100)]
        [DefaultValue(5)]
        public int MoonWatchMaterialAmount { get; set; }

        [ReloadRequired]
        public ItemDefinition ItemShimmeredForWind { get; set; }

        [ReloadRequired]
        public ItemDefinition ItemShimmeredForRain { get; set; }

        [BackgroundColor(128, 128, 128)]
        [Range(1f, 20f)]
        [Increment(0.5f)]
        [DefaultValue(1f)]
        public float SleepRateMultiplier { get; set; }

        [Header("EnchantedSundial")]

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [Range(1, 20)]
        [DefaultValue(20)]
        public int CrateEnchantedSundial { get; set; }

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool PreHardmodeSundials { get; set; }

        [BackgroundColor(128, 128, 128)]
        [Range(1f, 20f)]
        [Increment(0.5f)]
        [DefaultValue(1f)]
        public float EnchantedDialMultiplier
        {
            get;
            set
            {
                value = (float)Math.Round(value, 2);
                field = value;
            }
        }

        [BackgroundColor(128, 128, 128)]
        [Range(0, 7)]
        [DefaultValue(7)]
        public int EnchantedDialCooldown { get; set; }

        public TimeAndWeatherConfig()
        {
            MoonWatchMaterial = new(ItemID.SpectreBar);
            MoonWatchAlternateMaterial = new(ItemID.None);
            ItemShimmeredForWind = new(ItemID.Feather);
            ItemShimmeredForRain = new(ItemID.Cloud);
        }
    }
}
