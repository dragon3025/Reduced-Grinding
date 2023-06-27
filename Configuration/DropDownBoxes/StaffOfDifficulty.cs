using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration.DropDownBoxes
{
    public class StaffOfDifficulty
    {
        [Header("StaffOfDifficulty")]

        [BackgroundColor(128, 128, 128)]
        public bool Normal;
        [BackgroundColor(128, 128, 128)]
        public bool Expert;
        [BackgroundColor(128, 128, 128)]
        public bool Master;

        public StaffOfDifficulty() { }

        public override bool Equals(object obj)
        {
            if (obj is StaffOfDifficulty other)
                return Normal == other.Normal &&
                    Expert == other.Expert &&
                    Master == other.Master;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new { Normal, Expert, Master }.GetHashCode();
        }
    }
}
