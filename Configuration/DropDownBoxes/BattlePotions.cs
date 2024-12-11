using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration.DropDownBoxes
{
    public class BattlePotion
    {
        [Header("BattlePotions")]

        [Range(1, 750)]
        public int BattlePotionDistantEnemyDespawnTime;

        public bool GreaterBattlePotion
        {
            get =>
                (
                    GreaterMax > 2f ||
                    GreaterSpawnRate > 2f
                );
            set
            {
                if (value)
                {
                    GreaterSpawnRate = float.Max(2.5f, GreaterSpawnRate);
                }
                else
                {
                    GreaterMax = GreaterSpawnRate = 2f;
                    SuperMax = SuperSpawnRate = 2f;
                }
            }
        }

        public bool SuperBattlePotion
        {
            get =>
                GreaterBattlePotion &&
                (
                    SuperMax > 2f ||
                    SuperSpawnRate > 2f
                );
            set
            {
                if (value)
                {
                    GreaterSpawnRate = float.Max(2.5f, GreaterSpawnRate);
                    SuperSpawnRate = float.Max(3f, float.Max(3f, SuperSpawnRate));
                }
                else
                {
                    SuperMax = SuperSpawnRate = 2f;
                }
            }
        }

        public bool PresetPerformance
        {
            get =>
                VanillaMax == 2f &&
                VanillaSpawnRate == 2f &&
                GreaterMax == 2f &&
                GreaterSpawnRate == 8f &&
                SuperMax == 2f &&
                SuperSpawnRate == 16f;
            set
            {
                if (value)
                {
                    VanillaMax = 2f;
                    VanillaSpawnRate = 2f;
                    GreaterMax = 2f;
                    GreaterSpawnRate = 8f;
                    SuperMax = 2f;
                    SuperSpawnRate = 16f;
                }
            }
        }

        public bool PresetHighMax
        {
            get =>
                VanillaMax == 2f &&
                VanillaSpawnRate == 2f &&
                GreaterMax == 13f &&
                GreaterSpawnRate == 50f &&
                SuperMax == 24f &&
                SuperSpawnRate == 100f;
            set
            {
                if (value)
                {
                    VanillaMax = 2f;
                    VanillaSpawnRate = 2f;
                    GreaterMax = 13f;
                    GreaterSpawnRate = 50f;
                    SuperMax = 24f;
                    SuperSpawnRate = 100f;
                }
            }
        }


        [Header("VanillaBattlePotion")]
        [BackgroundColor(128, 128, 128)]
        [Increment(.5f)]
        [Range(2f, 100f)]
        public float VanillaMax { get; set; }

        [BackgroundColor(128, 128, 128)]
        [Increment(.5f)]
        [Range(2f, 100f)]
        public float VanillaSpawnRate { get; set; }

        [Header("GreaterBattlePotion")]
        [Increment(.5f)]
        [Range(2f, 100f)]
        public float GreaterMax { get; set; }

        [Increment(.5f)]
        [Range(2f, 100f)]
        public float GreaterSpawnRate { get; set; }

        [Header("SuperBattlePotion")]
        [Increment(.5f)]
        [Range(2f, 100f)]
        public float SuperMax { get; set; }

        [Increment(.5f)]
        [Range(2f, 100f)]
        public float SuperSpawnRate { get; set; }

        public BattlePotion()
        {
            PresetPerformance = true;
            PresetHighMax = false;
            GreaterBattlePotion = true;
            SuperBattlePotion = true;
            BattlePotionDistantEnemyDespawnTime = 180;
        }

        public override bool Equals(object obj)
        {
            if (obj is BattlePotion other)
                return BattlePotionDistantEnemyDespawnTime == other.BattlePotionDistantEnemyDespawnTime &&
                    GreaterBattlePotion == other.GreaterBattlePotion &&
                    SuperBattlePotion == other.SuperBattlePotion &&
                    PresetPerformance == other.PresetPerformance &&
                    PresetHighMax == other.PresetHighMax &&
                    VanillaMax == other.VanillaMax &&
                    VanillaSpawnRate == other.VanillaSpawnRate &&
                    GreaterMax == other.GreaterMax &&
                    GreaterSpawnRate == other.GreaterSpawnRate &&
                    SuperMax == other.SuperMax &&
                    SuperSpawnRate == other.SuperSpawnRate;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new
            {
                BattlePotionDistantEnemyDespawnTime,
                GreaterBattlePotion,
                SuperBattlePotion,
                PresetPerformance,
                PresetHighMax,
                VanillaMax,
                VanillaSpawnRate,
                GreaterMax,
                GreaterSpawnRate,
                SuperMax,
                SuperSpawnRate
            }.GetHashCode();
        }
    }
}
