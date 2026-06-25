using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration
{
    public enum UniPylonCraftWithPylonsEnums
    {
        Disabled,
        PreHardmode,
        All,
    }

    public class CraftingConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [ReloadRequired]
        [Range(1, 15)]
        [DefaultValue(3)]
        public int LeatherPerArchaeologistsPiece { get; set; }

        [ReloadRequired]
        [Range(1, 100)]
        [DefaultValue(25)]
        public int SturdyFossilsToDesertFossils { get; set; }

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool CraftableGoldCritters { get; set; }

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool ShimmerRoyalStatues { get; set; }

        [Header("CraftableUniversalPylon")]

        [ReloadRequired]
        [DefaultValue(UniPylonCraftWithPylonsEnums.All)]
        public UniPylonCraftWithPylonsEnums UniPylonCraftWithPylons { get; set; }

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool UniPylonCraftWithMechSouls { get; set; }

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool UniPylonCraftWithFragments { get; set; }
    }
}
