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

    [BackgroundColor(128, 128, 128)]
    public class StaffOfDifficultyConfig
    {
        [Header("StaffOfDifficulty")]

        [BackgroundColor(128, 128, 128)]
        public bool Normal;
        [BackgroundColor(128, 128, 128)]
        public bool Expert;
        [BackgroundColor(128, 128, 128)]
        public bool Master;

        public StaffOfDifficultyConfig() { }

        public override bool Equals(object obj)
        {
            if (obj is StaffOfDifficultyConfig other)
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

    public class BattlePotionConfig
    {
        //Luiafk and possibly other mods make use of the Vanilla Battle Buff, so it's good to have configurations for the vanilla Battle Potion.
        [Header("BattlePotions")]
        [BackgroundColor(128, 128, 128)]
        [Increment(.5f)]
        [Range(2f, 10f)]
        public float VanillaMax;

        [BackgroundColor(128, 128, 128)]
        [Increment(.5f)]
        [Range(2f, 10f)]
        public float VanillaSpawnRate;

        [Increment(.5f)]
        [Range(1f, 10f)]
        public float GreaterMax;

        [Increment(.5f)]
        [Range(1f, 10f)]
        public float GreaterSpawnRate;

        [Increment(.5f)]
        [Range(1f, 10f)]
        public float SuperMax;

        [Increment(.5f)]
        [Range(1f, 10f)]
        public float SuperSpawnRate;

        public BattlePotionConfig()
        {
            VanillaMax = 2f;
            VanillaSpawnRate = 2f;
            GreaterMax = 3f;
            GreaterSpawnRate = 4f;
            SuperMax = 4f;
            SuperSpawnRate = 8f;
        }

        public override bool Equals(object obj)
        {
            if (obj is BattlePotionConfig other)
                return VanillaMax == other.VanillaMax &&
                    VanillaSpawnRate == other.VanillaSpawnRate &&
                    GreaterMax == other.GreaterMax &&
                    GreaterSpawnRate == other.GreaterSpawnRate &&
                    SuperMax == other.SuperMax &&
                    SuperSpawnRate == other.SuperSpawnRate;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new {
                VanillaMax,
                VanillaSpawnRate,
                GreaterMax,
                GreaterSpawnRate,
                SuperMax,
                SuperSpawnRate
            }.GetHashCode();
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
        public BattlePotionConfig BattlePotionConfig;

        [BackgroundColor(128, 128, 128)]
        [Expand(false)]
        public StaffOfDifficultyConfig StaffOfDifficultyConfig;

        public HOtherModdedItemsConfig()
        {
            StaffOfDifficultyConfig = new StaffOfDifficultyConfig() { };
            BattlePotionConfig = new BattlePotionConfig() { };
        }

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    public class EnchantedSundialConfig
    {
        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int CrateEnchantedSundial;

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
            EnchantedDialMultiplier = 1f;
            EnchantedDialCooldown = 7;
        }

        public override bool Equals(object obj)
        {
            if (obj is EnchantedSundialConfig other)
                return CrateEnchantedSundial == other.CrateEnchantedSundial &&
                    EnchantedDialMultiplier == other.EnchantedDialMultiplier &&
                    EnchantedDialCooldown == other.EnchantedDialCooldown;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new
            {
                CrateEnchantedSundial,
                EnchantedDialMultiplier,
                EnchantedDialCooldown
            }.GetHashCode();
        }
    }

    public class TravelingMerchantConfig
    {
        public bool TravelingMerchantChatsItems;

        [Header("MerchantDice")]

        [BackgroundColor(128, 128, 128)]
        [Range(0, 100)]
        public int TravelingMerchantDiceUsesBeforeHardmode;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 100)]
        public int TravelingMerchantDiceUsesHardmode;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 100)]
        public int TravelingMerchantDiceUsesAfterPlantera;

        public TravelingMerchantConfig()
        {
            TravelingMerchantChatsItems = true;
            TravelingMerchantDiceUsesBeforeHardmode = 0;
            TravelingMerchantDiceUsesHardmode = 0;
            TravelingMerchantDiceUsesAfterPlantera = 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is TravelingMerchantConfig other)
                return TravelingMerchantChatsItems == other.TravelingMerchantChatsItems &&
                    TravelingMerchantDiceUsesBeforeHardmode == other.TravelingMerchantDiceUsesBeforeHardmode &&
                    TravelingMerchantDiceUsesHardmode == other.TravelingMerchantDiceUsesHardmode &&
                    TravelingMerchantDiceUsesAfterPlantera == other.TravelingMerchantDiceUsesAfterPlantera;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new
            {
                TravelingMerchantChatsItems,
                TravelingMerchantDiceUsesBeforeHardmode,
                TravelingMerchantDiceUsesHardmode,
                TravelingMerchantDiceUsesAfterPlantera
            }.GetHashCode();
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
        public EnchantedSundialConfig EnchantedSundialConfig;

        [Expand(false)]
        public TravelingMerchantConfig TravelingMerchantConfig;

        public IOtherConfig()
        {
            EnchantedSundialConfig = new EnchantedSundialConfig() { };
            TravelingMerchantConfig = new TravelingMerchantConfig() { };
        }

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
