using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReducedGrinding
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

        #region Multi-Bobber Potions
        [Header("MultiBobberPotions")]

        [BackgroundColor(128, 128, 128)]
        [Range(0, 100)]
        [DefaultValue(0)]
        public int MultiBobberPotionBonus;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 100)]
        [DefaultValue(0)]
        public int GreaterMultiBobberPotionBonus;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 100)]
        [DefaultValue(0)]
        public int SuperMultiBobberPotionBonus;
        #endregion

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

        #region Battle Potions
        [Header("SpawnIncreasingPotions")]

        //Luiafk and possibly other mods make use of the Vanilla Battle Buff, so it's good to have configurations for the vanilla Battle Potion.
        [BackgroundColor(128, 128, 128)]
        [Increment(.5f)]
        [Range(2f, 10f)]
        [DefaultValue(2f)]
        public float BattlePotionMaxSpawnsMultiplier;

        [BackgroundColor(128, 128, 128)]
        [Increment(.5f)]
        [Range(2f, 10f)]
        [DefaultValue(2f)]
        public float BattlePotionSpawnrateMultiplier;
        [Header("GreaterBattlePotion")]

        [Increment(.5f)]
        [Range(1f, 10f)]
        [DefaultValue(3f)]
        public float GreaterBattlePotionMaxSpawnsMultiplier;

        [Increment(.5f)]
        [Range(1f, 10f)]
        [DefaultValue(4f)]
        public float GreaterBattlePotionSpawnrateMultiplier;

        [Header("SuperBattlePotion")]

        [Increment(.5f)]
        [Range(1f, 10f)]
        [DefaultValue(4f)]
        public float SuperBattlePotionMaxSpawnsMultiplier;

        [Increment(.5f)]
        [Range(1f, 10f)]
        [DefaultValue(8f)]
        public float SuperBattlePotionSpawnrateMultiplier;
        #endregion

        #region Staff of Difficulty
        [Header("StaffOfDifficulty")]

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool StaffOfDifficultyJourney;

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool StaffOfDifficultyNormal;

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool StaffOfDifficultyExpert;

        [BackgroundColor(128, 128, 128)]
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

        [Header("EnchantedDialsAndSleep")]

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateEnchantedSundial;

        [BackgroundColor(128, 128, 128)]
        [Range(1f, 20f)]
        [Increment(0.5f)]
        [DefaultValue(1f)]
        public float EnchantedDialMultiplier;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 7)]
        [DefaultValue(7)]
        public int EnchantedDialCooldown;

        [BackgroundColor(128, 128, 128)]
        [Range(1f, 20f)]
        [Increment(0.5f)]
        [DefaultValue(1f)]
        public float SleepRateMultiplier;

        #region Traveling Merchant
        [Header("TravelingMerchant")]

        [DefaultValue(true)]
        public bool TravelingMerchantChatsItems;

        [Header("MerchantDice")]

        [BackgroundColor(128, 128, 128)]
        [Range(0, 100)]
        [DefaultValue(0)]
        public int TravelingMerchantDiceUsesBeforeHardmode;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 100)]
        [DefaultValue(0)]
        public int TravelingMerchantDiceUsesHardmode;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 100)]
        [DefaultValue(0)]
        public int TravelingMerchantDiceUsesAfterPlantera;
        #endregion

        #region Crafting
        [Header("Crafting")]

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool CraftableGoldCritters;

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool CraftableRareChests;

        [Range(0, 3)]
        [DefaultValue(1)]
        public int CraftableUniversalPylon;
        #endregion

        #region Other
        [Header("Other")]

        [DefaultValue(true)]
        public bool AdjustItemValuesForDropIncreases;

        [DefaultValue(true)]
        public bool CancelInvasionsIfAllPlayersAreHidden;

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool SkeletonMerchantIgnoresMoonphases;

        [BackgroundColor(128, 128, 128)]
        [Increment(0.01f)]
        [DefaultValue(1f)]
        public float UniversalPylonBestiaryCompletionRate;

        [BackgroundColor(128, 128, 128)]
        [DefaultValue(false)]
        public bool AllSpawningRegularMimics;

        [BackgroundColor(128, 128, 128)]
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
