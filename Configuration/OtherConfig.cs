using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration
{
    public class OtherConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(true)]
        public bool AdjustItemValuesForDropIncreases { get; set; }

        [ReloadRequired]
        [DefaultValue(true)]
        public bool PlaceableLog { get; set; }

        [DefaultValue(true)]
        public bool ClairvoyanceShowsLuck { get; set; }

        [DefaultValue(true)]
        public bool LocatingInfoShowsDirection { get; set; }

        [DefaultValue(true)]
        public bool ConvenientNPCRarity { get; set; }

        [Range(0, 10000)]
        [DefaultValue(1233)]
        public int AmberMosquitoChance { get; set; }

        [Range(2, 61)]
        [DefaultValue(61)]
        public int SliceOfCakeDuration { get; set; }

        [DefaultValue(true)]
        public bool EarlyUniPylonNerf { get; set; }

        [Header("FaelingHelper")]

        [DefaultValue(1)]
        public int FaelingHelperLimit { get; set; }

        [DefaultValue(0.11f)]
        [Increment(0.01f)]
        public float FaelingHelperRange
        {
            get;
            set
            {
                value = (float)Math.Round(value, 2);
                field = value;
            }
        }

        [Header("StaffOfDifficulty")]

        [ReloadRequired]
        [DefaultValue(true)]
        public bool DifficultyStavesEnabled { get; set; }

        [Increment(0.01f)]
        [Range(0f, 1f)]
        [DefaultValue(0.5f)]
        public float DifficultyStavesVotesRequired
        {
            get;
            set
            {
                value = (float)Math.Round(value, 2);
                field = value;
            }
        }

        [Range(10, 600)]
        [DefaultValue(15)]
        public int DifficultyStavesVoteTimeSeconds { get; set; }
    }
}
