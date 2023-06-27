using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration
{
    public class AEnemyLootConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Main")]

        #region Boss Loot
        [BackgroundColor(128, 128, 128)]
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

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TownNPCWeapons;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int BiomeKey;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int BeamSword;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int GoodieBag;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int KOCannon;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int Lens;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LizardEgg;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int Marrow;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PaladinsHammer;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PaladinsShield;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PlumbersHat;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int Present;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int RifleScopeAndSniperRifle;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int RocketLauncher;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int RodofDiscord;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int RottenChunkAndVertebra;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int SoulOfLightAndNight;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int SWATHelmetAndTacticalShotgun;
        #endregion

        [BackgroundColor(128, 128, 128)]
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

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int SlimeStaffFromSlimeKing;

        [BackgroundColor(128, 128, 128)]
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

        [Expand(false)]
        [BackgroundColor(128, 128, 128)]
        public DropDownBoxes.BobberPotions BobberPotions;

        #region Angler Quest Amount Each Day
        [Header("AnglerQuestAmountEachDay")]

        [BackgroundColor(128, 128, 128)]
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

        [Header("FishCoin")]

        [BackgroundColor(128, 128, 128)]
        [Range(0, 999)]
        [DefaultValue(0)]
        public int FishCoinsRewardedForQuest;

        public CFishingConfig()
        {
            BobberPotions = new DropDownBoxes.BobberPotions() { };
        }

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
        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool MoonWatch;

        [DefaultValue(true)]
        public bool SlimeTrophy;

        [DefaultValue(true)]
        public bool BestiaryTrophy;

        [DefaultValue(true)]
        public bool WorldPeaceStandard;

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(0)]
        public int PlanteraSapFromPlantera;

        [DefaultValue(true)]
        public bool HolidaySummons;
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

        [Header("Crafting")]

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool CraftableGoldCritters;

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool CraftableRareChests;

        #region Other
        [Header("Other")]

        [DefaultValue(true)]
        public bool AdjustItemValuesForDropIncreases;

        [DefaultValue(true)]
        public bool CancelInvasionsIfAllPlayersAreHidden;

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool SkeletonMerchantIgnoresMoonphases;

        [Expand(false)]
        public DropDownBoxes.UniversalPylon UniversalPylon;

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool AllSpawningRegularMimics;

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool WitchDoctorSellsChlorophyteOre;
        #endregion

        public IOtherConfig()
        {
            EnchantedSundial = new DropDownBoxes.EnchantedSundialConfig() { };
            TravelingMerchant = new DropDownBoxes.TravelingMerchant() { };
            UniversalPylon = new DropDownBoxes.UniversalPylon() { };
        }

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }
}
