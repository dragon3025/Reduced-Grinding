using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration
{
    public class LimitedItemsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("WorldGeneration")]

        [Range(0, 1000)]
        [DefaultValue(100)]
        public int TerragrimChestChance { get; set; }

        [DefaultValue(true)]
        public bool AddMissingTreeLoot { get; set; }

        [DefaultValue(true)]
        public bool AddMissingShroomLoot { get; set; }

        [DefaultValue(true)]
        public bool AddMissingPyramidLoot { get; set; }

        [DefaultValue(20)]
        public int TombstonesPerWorld { get; set; }

        [DefaultValue(true)]
        public bool OtherEvilChest { get; set; }

        [Header("Other")]

        [ReloadRequired]
        [DefaultValue(true)]
        public bool CraftableRareChests { get; set; }

        [DefaultValue(true)]
        public bool TombstonesDropFromNPCs { get; set; }

        [ReloadRequired]
        [DefaultValue(true)]
        public bool DryadSellsOppositeEvilPlanter { get; set; }

        [Range(1, 10000)]
        [DefaultValue(4)]
        public int DecorativeBannersFromCrates { get; set; }
    }
}
