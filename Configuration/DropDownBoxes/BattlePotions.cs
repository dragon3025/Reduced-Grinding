using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration.DropDownBoxes
{
    public class BattlePotion
    {
        [Header("BattlePotions")]

        [Range(1, 750)]
        public int BattlePotionDistantEnemyDespawnTime;

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
            BattlePotionDistantEnemyDespawnTime = 180;
        }

        public override bool Equals(object obj)
        {
            if (obj is BattlePotion other)
                return BattlePotionDistantEnemyDespawnTime == other.BattlePotionDistantEnemyDespawnTime &&
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
