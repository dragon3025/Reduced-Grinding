using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration.DropDownBoxes
{
    public class BattlePotion
    {
        //Luiafk and possibly other mods make use of the Vanilla Battle Buff, so it's good to have configurations for the vanilla Battle Potion.
        [Header("BattlePotions")]

        [Range(1, 750)]
        public int BattlePotionDistantEnemyDespawnTime;

        public bool PresetPerformance
        {
            get =>
                VanillaMax == 2f &&
                VanillaSpawnRate == 2f &&
                GreaterMax == 1f &&
                GreaterSpawnRate == 4f &&
                SuperMax == 1f &&
                SuperSpawnRate == 8f;
            set
            {
                if (value)
                {
                    VanillaMax = 2f;
                    VanillaSpawnRate = 2f;
                    GreaterMax = 1f;
                    GreaterSpawnRate = 4f;
                    SuperMax = 1f;
                    SuperSpawnRate = 8f;
                }
            }
        }

        public bool PresetHighMax
        {
            get =>
                VanillaMax == 2f &&
                VanillaSpawnRate == 2f &&
                GreaterMax == 3f &&
                GreaterSpawnRate == 4f &&
                SuperMax == 4f &&
                SuperSpawnRate == 8f;
            set
            {
                if (value)
                {
                    VanillaMax = 2f;
                    VanillaSpawnRate = 2f;
                    GreaterMax = 3f;
                    GreaterSpawnRate = 4f;
                    SuperMax = 4f;
                    SuperSpawnRate = 8f;
                }
            }
        }


        [Header("VanillaBattlePotion")]
        [BackgroundColor(128, 128, 128)]
        [Increment(.5f)]
        [Range(2f, 10f)]
        public float VanillaMax { get; set; }

        [BackgroundColor(128, 128, 128)]
        [Increment(.5f)]
        [Range(2f, 10f)]
        public float VanillaSpawnRate { get; set; }

        [Header("GreaterBattlePotion")]
        [Increment(.5f)]
        [Range(1f, 10f)]
        public float GreaterMax { get; set; }

        [Increment(.5f)]
        [Range(1f, 10f)]
        public float GreaterSpawnRate { get; set; }

        [Header("SuperBattlePotion")]
        [Increment(.5f)]
        [Range(1f, 10f)]
        public float SuperMax { get; set; }

        [Increment(.5f)]
        [Range(1f, 10f)]
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
