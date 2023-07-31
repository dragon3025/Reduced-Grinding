using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration.DropDownBoxes
{
    public class WorldGeneration
    {
        [Range(0, 1000)]
        public int TerragrimChestChance;

        public bool AddMissingTreeLoot;

        public bool AddMissingShroomLoot;

        public bool AddMissingPyramidLoot;

        public WorldGeneration()
        {
            TerragrimChestChance = 100;
            AddMissingTreeLoot = true;
            AddMissingShroomLoot = true;
            AddMissingPyramidLoot = true;
        }

        public override bool Equals(object obj)
        {
            if (obj is WorldGeneration other)
                return TerragrimChestChance == other.TerragrimChestChance &&
                    AddMissingTreeLoot == other.AddMissingTreeLoot &&
                    AddMissingShroomLoot == other.AddMissingShroomLoot &&
                    AddMissingPyramidLoot == other.AddMissingPyramidLoot;

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new
            {
                TerragrimChestChance,
                AddMissingTreeLoot,
                AddMissingShroomLoot,
                AddMissingPyramidLoot
            }.GetHashCode();
        }
    }
}
