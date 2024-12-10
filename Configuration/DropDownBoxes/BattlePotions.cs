using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration.DropDownBoxes
{
    public class BattlePotion
    {
        //Luiafk and possibly other mods make use of the Vanilla Battle Buff, so it's good to have configurations for the vanilla Battle Potion.
        [Header("BattlePotions")]

        [Range(1, 750)]
        public int BattlePotionDistantEnemyDespawnTime;

        [BackgroundColor(128, 128, 128)]
        [Increment(.5f)]
        [Range(2f, 10f)]
        public float VanillaMax;

        [BackgroundColor(128, 128, 128)]
        [Increment(.5f)]
        [Range(2f, 10f)]
        public float VanillaSpawnRate;

        [Increment(.5f)]
        [Range(1f, 10f)]
        public float GreaterMax;

        [Increment(.5f)]
        [Range(1f, 10f)]
        public float GreaterSpawnRate;

        [Increment(.5f)]
        [Range(1f, 10f)]
        public float SuperMax;

        [Increment(.5f)]
        [Range(1f, 10f)]
        public float SuperSpawnRate;

        public BattlePotion()
        {
            BattlePotionDistantEnemyDespawnTime = 180;
            VanillaMax = 2f;
            VanillaSpawnRate = 2f;
            GreaterMax = 3f;
            GreaterSpawnRate = 4f;
            SuperMax = 4f;
            SuperSpawnRate = 8f;
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
