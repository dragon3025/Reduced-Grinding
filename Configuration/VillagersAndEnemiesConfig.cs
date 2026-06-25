using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration
{
    public class VillagersAndEnemiesConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool NameTag { get; set; }

        [ReloadRequired]
        [DefaultValue(true)]
        public bool JackStatue { get; set; }

        [ReloadRequired]
        [DefaultValue(true)]
        public bool CultMembershipCard { get; set; }

        [BackgroundColor(128, 128, 128)]
        [ReloadRequired]
        [Increment(0.01f)]
        [DefaultValue(1f)]
        public float UniPylonBestiaryCompletionRate
        {
            get;
            set
            {
                value = (float)Math.Round(value, 2);
                field = value;
            }
        }

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool AllowSpawningRegularMimics { get; set; }

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool WitchDoctorSellsChlorophyteOre { get; set; }

        [Header("ChaosElementalSwarm")]

        [Range(0, 24)]
        [DefaultValue(6)]
        public int CESwarmDuration { get; set; }

        [Range(1, 10)]
        [DefaultValue(5)]
        public int CESwarmCElementalSpawnFailRate { get; set; }

        [Range(1, 10)]
        [DefaultValue(5)]
        public int CESwarmESwordSpawnFailRate { get; set; }

        [Range(0.6f, 1f)]
        [DefaultValue(1f)]
        public float CESKnockbackResist
        {
            get;
            set
            {
                value = (float)Math.Round(value, 2);
                field = value;
            }
        }
    }
}
