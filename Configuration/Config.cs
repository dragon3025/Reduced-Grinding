using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration
{
    public class AEnemyLootConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Main")]

        [Expand(false)]
        public DropDownBoxes.BossLoot BossLoot;

        [Expand(false)]
        public DropDownBoxes.NonBossLoot NonBossLoot;

        [Header("NonVanilla")]

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int SlimeStaffFromSlimeKing;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TrufflewormFromDukeFishron;

        public AEnemyLootConfig()
        {
            NonBossLoot = new DropDownBoxes.NonBossLoot() { };
            BossLoot = new DropDownBoxes.BossLoot() { };
        }
    }

    public class CFishingConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Expand(false)]
        public DropDownBoxes.Angler Angler;

        [Expand(false)]
        [BackgroundColor(128, 128, 128)]
        public DropDownBoxes.BobberPotions BobberPotions;

        [Header("FishCoin")]

        [BackgroundColor(128, 128, 128)]
        [Range(0, 999)]
        [DefaultValue(0)]
        public int FishCoinsRewardedForQuest;

        public CFishingConfig()
        {
            Angler = new DropDownBoxes.Angler() { };
            BobberPotions = new DropDownBoxes.BobberPotions() { };
        }
    }

    public class HOtherModdedItemsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        #region Regular
        [BackgroundColor(128, 128, 128)]
        [DefaultValue(0)]
        [Range(0, 3)]
        public int MoonWatch;

        [DefaultValue(true)]
        public bool SlimeTrophy;

        [DefaultValue(true)]
        public bool BestiaryTrophy;

        [DefaultValue(true)]
        public bool WorldPeaceStandard;

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(0)]
        public int PlanteraSapFromPlantera;

        [DefaultValue(2)]
        [Range(0, 2)]
        public int HolidaySummons;
        #endregion

        [Expand(false)]
        public DropDownBoxes.BattlePotion BattlePotion;

        [BackgroundColor(128, 128, 128)]
        [Expand(false)]
        public DropDownBoxes.StaffOfDifficulty StaffOfDifficulty;

        public HOtherModdedItemsConfig()
        {
            StaffOfDifficulty = new DropDownBoxes.StaffOfDifficulty() { };
            BattlePotion = new DropDownBoxes.BattlePotion() { };
        }
    }

    public class IOtherConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Expand(false)]
        public DropDownBoxes.WorldGeneration WorldGeneration;

        [BackgroundColor(128, 128, 128)]
        [Range(1f, 20f)]
        [Increment(0.5f)]
        [DefaultValue(1f)]
        public float SleepRateMultiplier;

        [BackgroundColor(128, 128, 128)]
        [Expand(false)]
        public DropDownBoxes.EnchantedSundialConfig EnchantedSundial;

        [Expand(false)]
        public DropDownBoxes.TravelingMerchant TravelingMerchant;

        [Expand(false)]
        public DropDownBoxes.UniversalPylon UniversalPylon;

        [Header("Crafting")]

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool CraftableGoldCritters;

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool CraftableRareChests;

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool ShimmerRoyalStatues;

        #region Other
        [Header("Other")]

        [DefaultValue(true)]
        public bool AdjustItemValuesForDropIncreases;

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(0)]
        [Range(0, 2)]
        public int SkeletonMerchantIgnoresMoonphases;

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool AllSpawningRegularMimics;

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool WitchDoctorSellsChlorophyteOre;
        #endregion

        public IOtherConfig()
        {
            WorldGeneration = new DropDownBoxes.WorldGeneration() { };
            EnchantedSundial = new DropDownBoxes.EnchantedSundialConfig() { };
            TravelingMerchant = new DropDownBoxes.TravelingMerchant() { };
            UniversalPylon = new DropDownBoxes.UniversalPylon() { };
        }
    }
}
