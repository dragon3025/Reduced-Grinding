using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration.DropDownBoxes
{
    public class EnchantedSundialConfig
    {
        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int CrateEnchantedSundial;

        [BackgroundColor(128, 128, 128)]
        public bool PreHardmodeSundials;

        [BackgroundColor(128, 128, 128)]
        [Range(1f, 20f)]
        [Increment(0.5f)]
        public float EnchantedDialMultiplier;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 7)]
        public int EnchantedDialCooldown;

        public EnchantedSundialConfig()
        {
            CrateEnchantedSundial = 0;
            PreHardmodeSundials = false;
            EnchantedDialMultiplier = 1f;
            EnchantedDialCooldown = 7;
        }

        public override bool Equals(object obj)
        {
            if (obj is EnchantedSundialConfig other)
                return CrateEnchantedSundial == other.CrateEnchantedSundial &&
                    PreHardmodeSundials == other.PreHardmodeSundials &&
                    EnchantedDialMultiplier == other.EnchantedDialMultiplier &&
                    EnchantedDialCooldown == other.EnchantedDialCooldown;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new
            {
                CrateEnchantedSundial,
                PreHardmodeSundials,
                EnchantedDialMultiplier,
                EnchantedDialCooldown
            }.GetHashCode();
        }
    }
}
