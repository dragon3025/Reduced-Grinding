using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration
{
    public class BattlePotionConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool GreaterBattlePotion
        {
            get
            {
                field = SuperBattlePotion || field;
                return field;
            }
            set
            {
                if (!value)
                {
                    SuperBattlePotion = false;
                }
                field = value;
            }
        }

        [ReloadRequired]
        [DefaultValue(true)]
        public bool SuperBattlePotion { get; set; }

        [DefaultValue(true)]
        public bool BuffIconTiers { get; set; }

        [DefaultValue(true)]
        public bool TownsRequireAllVillagersUnlocked { get; set; }

        [Header("BatttleBuffDuration")]
        [BackgroundColor(128, 128, 128)]
        [Slider]
        [Range(1, 60)]
        [DefaultValue(7)]
        public int VanillaDuration
        {
            get
            {
                field = Math.Min(field, Math.Min(GreaterDuration, SuperDuration));
                return field;
            }
            set
            {
                GreaterDuration = Math.Max(value, GreaterDuration);
                SuperDuration = Math.Max(GreaterDuration, SuperDuration);
                field = value;
            }
        }

        [Slider]
        [Range(1, 60)]
        [DefaultValue(11)]
        public int GreaterDuration
        {
            get
            {
                field = Math.Min(field, SuperDuration);
                return field;
            }
            set
            {
                SuperDuration = Math.Max(value, SuperDuration);
                field = value;
            }
        }

        [Slider]
        [Range(1, 60)]
        [DefaultValue(15)]
        public int SuperDuration { get; set; }

        [Header("BattlePotions")]

        [DefaultValue(true)]
        public bool SpawnRatePresetDefault
        {
            get =>
                VanillaSpawnRate == 2f &&
                GreaterSpawnRate == 26f &&
                SuperSpawnRate == 50f;
            set
            {
                if (value)
                {
                    VanillaSpawnRate = 2f;
                    GreaterSpawnRate = 26f;
                    SuperSpawnRate = 50f;
                }
            }
        }

        [DefaultValue(false)]
        public bool SpawnRatePresetLowPerformance
        {
            get =>
                //10 is the max multiplier for the Journey Mode slider.
                VanillaSpawnRate == 2f &&
                GreaterSpawnRate == 6f &&
                SuperSpawnRate == 10f;
            set
            {
                if (value)
                {
                    VanillaSpawnRate = 2f;
                    GreaterSpawnRate = 6f;
                    SuperSpawnRate = 10f;
                }
            }
        }

        [Header("BattleBuffSpawnRates")]
        [BackgroundColor(128, 128, 128)]
        [Increment(1f)]
        [Range(2f, 100f)]
        [DefaultValue(2)]
        public float VanillaSpawnRate
        {
            get
            {
                field = Math.Min(field, Math.Min(GreaterSpawnRate, SuperSpawnRate));
                return field;
            }
            set
            {
                GreaterSpawnRate = Math.Max(value, GreaterSpawnRate);
                SuperSpawnRate = Math.Max(GreaterSpawnRate, SuperSpawnRate);
                field = value;
            }
        }

        [Increment(1f)]
        [Range(2f, 100f)]
        [DefaultValue(26f)]
        public float GreaterSpawnRate
        {
            get
            {
                field = Math.Min(field, SuperSpawnRate);
                return field;
            }
            set
            {
                SuperSpawnRate = Math.Max(value, SuperSpawnRate);
                field = value;
            }
        }

        [Increment(1f)]
        [Range(2f, 100f)]
        [DefaultValue(50f)]
        public float SuperSpawnRate { get; set; }
    }
}
