using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration.DropDownBoxes
{
    public class UniversalPylon
    {
        [BackgroundColor(128, 128, 128)]
        [Increment(0.01f)]
        public float UniversalPylonBestiaryCompletionRate;

        [Header("CraftableUniversalPylon")]

        public bool CraftWithPylons;

        [BackgroundColor(128, 128, 128)]
        public bool CraftWithPreMechSouls;

        [BackgroundColor(128, 128, 128)]
        public bool CraftWithMechSouls;

        [BackgroundColor(128, 128, 128)]
        public bool CraftWithFragments;

        public bool CraftAtCrystalBall;

        public UniversalPylon()
        {
            UniversalPylonBestiaryCompletionRate = 1f;
            CraftWithPylons = true;
            CraftWithPreMechSouls = false;
            CraftWithMechSouls = false;
            CraftWithFragments = false;
            CraftAtCrystalBall = true;
        }

        public override bool Equals(object obj)
        {
            if (obj is UniversalPylon other)
                return UniversalPylonBestiaryCompletionRate == other.UniversalPylonBestiaryCompletionRate &&
                    CraftWithPylons == other.CraftWithPylons &&
                    CraftWithPreMechSouls == other.CraftWithPreMechSouls &&
                    CraftWithMechSouls == other.CraftWithMechSouls &&
                    CraftWithFragments == other.CraftWithFragments &&
                    CraftAtCrystalBall == other.CraftAtCrystalBall;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new
            {
                UniversalPylonBestiaryCompletionRate,
                CraftWithPylons,
                CraftWithPreMechSouls,
                CraftWithMechSouls,
                CraftWithFragments,
                CraftAtCrystalBall
            }.GetHashCode();
        }
    }
}
