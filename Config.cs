using System;
using System.ComponentModel;
using Terraria.ID;
using Terraria.ModLoader.Config;

namespace ReducedGrinding
{
    public class AEnemyLootConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Main")]

        #region Boss Loot
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int Binoculars;

        [Range(0, 10000)]
        [DefaultValue(5)]
        public int EmpressAndFishronWings;

        [Range(0, 10000)]
        [DefaultValue(5)]
        public int StellarTune;

        [Range(0, 10000)]
        [DefaultValue(3)]
        public int RainbowCursor;
        #endregion

        #region Non-Boss Loot

        #region Regular
        [Header("NonBossLoot")]

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TownNPCWeapons;

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int BiomeKey;

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int BeamSword;

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int GoodieBag;

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int KOCannon;

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int Lens;

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LizardEgg;

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int Marrow;

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PaladinsHammer;

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PaladinsShield;

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PlumbersHat;

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int Present;

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int RifleScopeAndSniperRifle;

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int RocketLauncher;

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int RodofDiscord;

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int RottenChunkAndVertebra;

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int SoulOfLightAndNight;

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int SWATHelmetAndTacticalShotgun;
        #endregion

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CoinGun;

        #region Slime Staff
        [Header("SlimeStaff")]

        [Range(0, 10000)]
        [DefaultValue(5)]
        public int SlimeStaffFromPinky;

        [Range(0, 10000)]
        [DefaultValue(75)]
        public int SlimeStaffFromSandSlime;

        [Range(0, 10000)]
        [DefaultValue(100)]
        public int SlimeStaffFromOtherSlimes;
        #endregion
        #endregion

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    public class BEnemyLootNonVanillaConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Main")]

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int SlimeStaffFromSlimeKing;

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TrufflewormFromDukeFishron;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    public class CFishingConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(true)]
        public bool AnglerTellsQuestCompleted;

        #region Multi-Bobber Potions
        [Header("MultiBobberPotions")]

        [Range(0, 100)]
        [DefaultValue(0)]
        public int MultiBobberPotionBonus;

        [Range(0, 100)]
        [DefaultValue(0)]
        public int GreaterMultiBobberPotionBonus;

        [Range(0, 100)]
        [DefaultValue(0)]
        public int SuperMultiBobberPotionBonus;
        #endregion

        #region Reward Modifying
        [Header("RewardModifying")]

        [Range(1, 150)]
        [DefaultValue(5)]
        public int FuzzyCarrotQuestRewarded;

        [Range(1, 150)]
        [DefaultValue(10)]
        public int AnglerHatQuestRewarded;

        [Range(1, 150)]
        [DefaultValue(15)]
        public int AnglerVestQuestRewarded;

        [Range(1, 150)]
        [DefaultValue(20)]
        public int AnglerPantsQuestRewarded;

        [Range(0, 150)]
        [DefaultValue(25)]
        public int BottomlessWaterBucketQuestRewarded;

        [Range(1, 150)]
        [DefaultValue(30)]
        public int GoldenFishingRodQuestRewarded;

        #endregion

        #region Angler Quest Amount Each Day
        [Header("AnglerQuestAmountEachDay")]

        [Range(1, 10000)]
        [DefaultValue(1)]
        public int QuestCountBeforeEye;

        [Range(1, 10000)]
        [DefaultValue(2)]
        public int QuestCountAfterEye;

        [Range(1, 10000)]
        [DefaultValue(3)]
        public int QuestCountAfterInfectionBoss;

        [Range(1, 10000)]
        [DefaultValue(6)]
        public int QuestCountAfterSkeletron;

        [Range(1, 10000)]
        [DefaultValue(10)]
        public int QuestCountHardmode;

        [Range(1, 10000)]
        [DefaultValue(10)]
        public int QuestCountAfterPlantera;
        #endregion

        #region Fish Merchant
        [Header("FishCoin")]

        [Range(0, 999)]
        [DefaultValue(0)]
        public int FishCoinsRewardedForQuest;

        [Header("FishMerchantShopPrices")]
        [Range(1, 9999)]
        [DefaultValue(5)]
        public int FuzzyCarrotPrice;

        [Range(1, 9999)]
        [DefaultValue(10)]
        public int AnglerHatPrice;

        [Range(1, 9999)]
        [DefaultValue(10)]
        public int AnglerVestPrice;

        [Range(1, 9999)]
        [DefaultValue(10)]
        public int AnglerPantsPrice;

        [Range(1, 9999)]
        [DefaultValue(25)]
        public int GoldenFishingRod;

        [Range(1, 9999)]
        [DefaultValue(10)]
        public int HotlineFishingHook;

        [Range(1, 9999)]
        [DefaultValue(7)]
        public int FinWings;

        [Range(1, 9999)]
        [DefaultValue(7)]
        public int BottomlessWaterBucket;

        [Range(1, 9999)]
        [DefaultValue(7)]
        public int SuperAbsorbantSponge;

        [Range(1, 9999)]
        [DefaultValue(8)]
        public int GoldenBugNet;

        [Range(1, 9999)]
        [DefaultValue(6)]
        public int FishHook;

        [Range(1, 9999)]
        [DefaultValue(6)]
        public int Minecarp;

        [Range(1, 9999)]
        [DefaultValue(8)]
        public int AnglerTackleBagIngredients;

        [Range(1, 9999)]
        [DefaultValue(6)]
        public int FishFinderIngredients;

        [Range(1, 9999)]
        [DefaultValue(8)]
        public int VanitySets;
        #endregion

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    public class HOtherModdedItemsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        #region Regular
        [DefaultValue(true)]
        public bool MoonBall;

        [DefaultValue(true)]
        public bool SlimeTrophy;

        [DefaultValue(true)]
        public bool BestiaryTrophy;

        [DefaultValue(0)]
        public int PlanteraSapFromPlantera;

        [DefaultValue(true)]
        public bool HolidaySummons;
        #endregion

        #region Battle Potions
        [Header("SpawnIncreasingPotions")]

        [Increment(.1f)]
        [Range(2f, 10f)]
        [DefaultValue(2f)]
        public float BattlePotionMaxSpawnsMultiplier;

        [Increment(.1f)]
        [Range(2f, 10f)]
        [DefaultValue(2f)]
        public float BattlePotionSpawnrateMultiplier;
        [Header("GreaterBattlePotion")]

        [Increment(.1f)]
        [Range(1f, 10f)]
        [DefaultValue(3f)]
        public float GreaterBattlePotionMaxSpawnsMultiplier;

        [Increment(.1f)]
        [Range(1f, 10f)]
        [DefaultValue(4f)]
        public float GreaterBattlePotionSpawnrateMultiplier;

        [Header("SuperBattlePotion")]

        [Increment(.1f)]
        [Range(1f, 10f)]
        [DefaultValue(4f)]
        public float SuperBattlePotionMaxSpawnsMultiplier;

        [Increment(.1f)]
        [Range(1f, 10f)]
        [DefaultValue(8f)]
        public float SuperBattlePotionSpawnrateMultiplier;
        #endregion

        #region Staff of Difficulty
        [Header("StaffOfDifficulty")]

        [DefaultValue(false)]
        public bool StaffOfDifficultyJourney;

        [DefaultValue(false)]
        public bool StaffOfDifficultyNormal;

        [DefaultValue(false)]
        public bool StaffOfDifficultyExpert;

        [DefaultValue(false)]
        public bool StaffOfDifficultyMaster;
        #endregion

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    public class IOtherConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(75)]
        public int TerragrimChestChance;

        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateEnchantedSundial;

        #region Traveling Merchant
        [Header("TravelingMerchant")]

        [Range(0, 100)]
        [DefaultValue(0)]
        public int TravelingMerchantDiceUsesBeforeHardmode;

        [Range(0, 100)]
        [DefaultValue(0)]
        public int TravelingMerchantDiceUsesHardmode;

        [Range(0, 100)]
        [DefaultValue(0)]
        public int TravelingMerchantDiceUsesAfterPlantera;
        #endregion

        #region Crafting
        [Header("Crafting")]

        [DefaultValue(false)]
        public bool CraftableGoldCritters;

        [DefaultValue(false)]
        public bool CraftableRareChests;

        [Range(0, 3)]
        [DefaultValue(1)]
        public int CraftableUniversalPylon;
        #endregion

        #region Sleep Time Rate
        [Header("SleepTimeRate")]

        [DefaultValue(0)]
        public int SleepRateIncreasePreHardmode;

        [DefaultValue(0)]
        public int SleepRateIncreaseHardmode;

        [DefaultValue(0)]
        public int SleepRateIncreasePostPlantera;
        #endregion

        #region Other
        [Header("Other")]

        [DefaultValue(true)]
        public bool AdjustItemValuesForDropIncreases;

        [DefaultValue(true)]
        public bool CancelInvasionsIfAllPlayersAreHidden;

        [DefaultValue(false)]
        public bool SkeletonMerchantIgnoresMoonphases;

        [Increment(0.01f)]
        [DefaultValue(1f)]
        public float UniversalPylonBestiaryCompletionRate;

        [DefaultValue(false)]
        public bool AllSpawningRegularMimics;

        [DefaultValue(false)]
        public bool WitchDoctorSellsChlorophyteOre;
        #endregion

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }
}
