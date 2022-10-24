using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReducedGrinding
{
    [Label("Enemy Loot Vanilla")]
    public class AEnemyLootConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        #region Boss Loot
        [Header("You can change item drop rates using the following configurations. Chance = 1 / configuration_setting. Set to 0 to use the vanilla drop rate.\n\n" +
            "Boss Loot")]

        [Label("[i: 1299] Binoculars")]
        [Tooltip("If world difficulty is normal, this is multiplied by (4/3)")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int Binoculars;

        [Label("[i:4823] Empress and [i:2609] Fishron Wings")]
        [Tooltip("" +
            "This sets the same drop rate for each. If the world difficulty is normal, this\n" +
            "is multiplied by (3 / 2)")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int EmpressAndFishronWings;

        [Label("[i:4715] Stellar Tune")]
        [Tooltip("If world difficulty is normal, this is multiplied by (5/2)")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int StellarTune;

        [Label("[i:5075] Rainbow Cursor")]
        [Range(0, 10000)]
        [DefaultValue(3)]
        public int RainbowCursor;
        #endregion

        #region Non-Boss Loot

        #region Regular
        [Header("Non-Boss Loot")]

        [Label("[i:3349] Town NPC Weapons")]
        [Tooltip("" +
            "This mod will remove the name requirement for the Guide and\n" +
            "Steampunker. This setting doesn't affect the Party Girl.")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TownNPCWeapons;

        [Label("[i:1533] Biome Key Increase")]
        [Tooltip("This sets the same drop rate for each")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int BiomeKey;

        [Label("[i:723] Beam Sword")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int BeamSword;

        [Label("[i:1774] Goodie Bag")]
        [Tooltip("Only drops during Halloween")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int GoodieBag;

        [Label("[i:1314] KO Cannon")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int KOCannon;

        [Label("[i:38] Lens")]
        [Tooltip("" +
            "Lens wont drop if Black Lens drops, so\n" +
            "chance = (99 / 100) * (1 / configuration_setting)")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int Lens;

        [Label("[i:1172] Lizard Egg")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LizardEgg;

        [Label("[i:682] Marrow")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int Marrow;

        [Label("[i:1513] Paladin's Hammer")]
        [Tooltip("If world difficulty is normal, this is multiplied by 146.67%")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PaladinsHammer;

        [Label("[i:938] Paladin's Shield")]
        [Tooltip("If world difficulty is normal, this is multiplied by 145.33%")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PaladinsShield;

        [Label("[i:244] Plumberís Hat")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PlumbersHat;

        [Label("[i:1869] Present")]
        [Tooltip("Only drops during Christmas")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int Present;

        [Label("[i:1300] Rifle Scope and [i:1254]Sniper Rifle")]
        [Tooltip("" +
            "This sets the same drop rate for each. If world difficulty is normal, this is\n" +
            "multiplied by 183.33 % ")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int RifleScopeAndSniperRifle;

        [Range(0, 10000)]
        [Label("[i:759] Rocket Launcher")]
        [Tooltip("If world difficulty is normal, this is multiplied by 194.44%")]
        [DefaultValue(0)]
        public int RocketLauncher;

        [Range(0, 10000)]
        [Label("[i:1326] Rod of Discord")]
        [Tooltip("" +
            "If world difficulty is normal, this is multiplied by (5/4). In a Celebrationmk10\n" +
            "world, it's divided by 4 (it round upwards if below 1)")]
        [DefaultValue(0)]
        public int RodofDiscord;

        [Range(0, 10000)]
        [Label("[i:68] Rotten Chunk and [i:1330] Vertebra")]
        [Tooltip("This sets the same drop rate for each")]
        [DefaultValue(0)]
        public int RottenChunkAndVertebra;

        [Label("[i:520] Soul of Light and [i:521] Soul of Night")]
        [Tooltip("This sets the same drop rate for each")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int SoulOfLightAndNight;

        [Label("[i:1514] SWAT Helmet and [i:679]Tactical Shotgun")]
        [Tooltip("" +
            "This sets the same drop rate for each. If world difficulty is normal, this is\n" +
            "multiplied by 191.66 % ")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int SWATHelmetAndTacticalShotgun;
        #endregion

        [Label("[i:905] Coin Gun From Flying Dutchman")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CoinGun;

        #region Slime Staff
        [Header("[i:1309] Slime Staff")]

        [Label("From Pinky")]
        [Tooltip("If world difficulty is normal, this multiplied by (10/7)")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int SlimeStaffFromPinky;

        [Label("From Sand Slime")]
        [Tooltip("If world difficulty is normal, this multiplied by (10/7)")]
        [Range(0, 10000)]
        [DefaultValue(75)]
        public int SlimeStaffFromSandSlime;

        [Label("From Others")]
        [Tooltip("If world difficulty is normal, this multiplied by (10/7)")]
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

    [Label("Enemy Loot Non-Vanilla")]
    public class BEnemyLootNonVanillaConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        #region Boss Loot
        [Header("These drop chances don't exist in vanilla. Chance = 1 / configuration_setting. Set to 0 to disable.\n\n" +
            "Boss Loot")]

        [Label("[i:1309] Slime Staff From Slime King")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int SlimeStaffFromSlimeKing;

        [Label("[i:2673] Truffle Worm from Duke Fishron")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TrufflewormFromDukeFishron;
        #endregion

        #region Non-Boss Loot
        [Header("Non-Boss Loot")]

        [Label("[i:3081] Marble from Marble Cave Enemies (Min and Max in any order)")]
        [Range(0, 999)]
        public int[] MarbleFromMarbleCaveEnemies = new int[] { 5, 10 };

        [Label("[i:951] Snowball Launcher from Spiked Ice Slime")]
        [Range(0, 10000)]
        [DefaultValue(60)]
        public int SnowballLauncherFromSpikedIceSlime; //TO-DO This might not be needed it 1.4.4+
        #endregion

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    [Label("Fishing")]
    public class CFishingConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        #region Multi-Bobber Potions
        [Header("Set the amount of extra bobbers each potion gives. Set to 0 to disable recipe.")]

        [Label("[i:ReducedGrinding/MultiBobberPotion]Multi-Bobber Potion")]
        [Range(0, 100)]
        [DefaultValue(1)]
        public int MultiBobberPotionBonus;

        [Label("[i:ReducedGrinding/GreaterMultiBobberPotion] Greater Multi-Bobber Potion")]
        [Range(0, 100)]
        [DefaultValue(2)]
        public int GreaterMultiBobberPotionBonus;

        [Label("[i:ReducedGrinding/SuperMultiBobberPotion] Super Multi-Bobber Potion")]
        [Range(0, 100)]
        [DefaultValue(3)]
        public int SuperMultiBobberPotionBonus;
        #endregion

        #region Reward Modifying

        [Header("Quest Completion Requirements For Guaranteed Rewards")]

        [Label("Fuzzy Carrot")]
        [Tooltip("Vanilla default: 5")]
        [Range(1, 150)]
        [DefaultValue(3)]
        public int FuzzyCarrotQuestRewarded;

        [Label("Angler Hat")]
        [Tooltip("Vanilla default: 10")]
        [Range(1, 150)]
        [DefaultValue(5)]
        public int AnglerHatQuestRewarded;

        [Label("Angler Vest")]
        [Tooltip("Vanilla default: 15")]
        [Range(1, 150)]
        [DefaultValue(10)]
        public int AnglerVestQuestRewarded;

        [Label("Angler Pants")]
        [Tooltip("Vanilla default: 20")]
        [Range(1, 150)]
        [DefaultValue(20)]
        public int AnglerPantsQuestRewarded;

        [Label("Golden Fishing Rod")]
        [Tooltip("Vanilla default: 30")]
        [Range(1, 150)]
        [DefaultValue(30)]
        public int GoldenFishingRodQuestRewarded;

        #endregion

        #region Angler Reset Chance
        [Header("Angler Reset Chance\n\n" +
            "The configurations below will give a (1 / configuration_setting) chance at resetting the Angler Quest when finishing it. The chance to reset wont happen if a player wearing any piece of Angler Armor hasn't finished their Quest. Set to 0 to disable.")]

        [Label("Before Hardmode")]
        [Range(0, 10000)]
        [DefaultValue(1)]
        public int AnglerRecentChanceBeforeHardmode;

        [Label("Hardmode")]
        [Range(0, 10000)]
        [DefaultValue(1)]
        public int AnglerRecentChanceHardmode;

        [Label("After Plantera")]
        [Range(0, 10000)]
        [DefaultValue(1)]
        public int AnglerRecentChanceAfterPlantera;
        #endregion

        #region Fish Merchant
        [Header("Fish Merchant\n\n" +
            "You can set it so the Angler rewards the player with an amount of Fish Coins when completing a quest. These are used to buy Angler Quest rewards from a new Fish Merchant, who appears when talking to the Angler.")]

        [Label("[i:ReducedGrinding/FishCoin] Fish Coins Rewarded")]
        [Tooltip("Set both to 0, to disable the Fish Merchant from spawning")]
        [Range(1, 999)]
        [DefaultValue(1)]
        public int FishCoinsRewardedForQuest;

        [Header("Fish Merchant Shop Prices\n\n" +
            "Set the Fish Coin prices here for the Fish Merchant. Setting to 0 will disable the item from appearing in the shop. Some items wont appear in the shop until their vanilla requirement is met (for example: Hardmode items).")]

        [Label("[i:2428] Fuzzy Carrot")]
        [Range(1, 9999)]
        [DefaultValue(3)]
        public int FuzzyCarrotPrice;

        [Label("[i:2367] Angler Hat")]
        [Range(1, 9999)]
        [DefaultValue(5)]
        public int AnglerHatPrice;

        [Label("[i:2368] Angler Vest")]
        [Range(1, 9999)]
        [DefaultValue(5)]
        public int AnglerVestPrice;

        [Label("[i:2369] Angler Pants")]
        [Range(1, 9999)]
        [DefaultValue(5)]
        public int AnglerPantsPrice;

        [Label("[i:2294] Golden Fishing Rod")]
        [Range(1, 9999)]
        [DefaultValue(25)]
        public int GoldenFishingRod;

        [Label("[i:2422] Hotline Fishing Rod")]
        [Range(1, 9999)]
        [DefaultValue(10)]
        public int HotlineFishingHook;

        [Label("[i:2494] Fin Wings")]
        [Range(1, 9999)]
        [DefaultValue(7)]
        public int FinWings;

        [Label("[i:3021] Bottomless Water Bucket")]
        [Range(1, 9999)]
        [DefaultValue(7)]
        public int BottomlessWaterBucket;

        [Label("[i:3032] Super Absorbent Sponge")]
        [Range(1, 9999)]
        [DefaultValue(7)]
        public int SuperAbsorbantSponge;

        [Label("[i:3183] Golden Bug Net")]
        [Range(1, 9999)]
        [DefaultValue(8)]
        public int GoldenBugNet;

        [Label("[i:2360] Fish Hook")]
        [Range(1, 9999)]
        [DefaultValue(6)]
        public int FishHook;

        [Label("[i:4067] Minecarp")]
        [Range(1, 9999)]
        [DefaultValue(6)]
        public int Minecarp;

        [Label("[i:2373] Angler Tackle Bag Ingredients")]
        [Range(1, 9999)]
        [DefaultValue(8)]
        public int AnglerTackleBagIngredients;

        [Label("[i:3120] Fish Finder Ingredients")]
        [Range(1, 9999)]
        [DefaultValue(6)]
        public int FishFinderIngredients;

        [Label("[i:2498] Vanity Sets")]
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

    [Label("Other Modded Items")]
    public class HOtherModdedItemsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        #region Regular
        [Label("[i:ReducedGrinding/MoonBall] Moon Ball")]
        [Tooltip("" +
            "Advances the moon phase and will stop the Blood Moon when\n" +
            "advancing to a new moon.Set to false to disable the recipe.\n" +
            "Crafted out of Meteorite, Glass, and Fallen Star.")]
        [DefaultValue(true)]
        public bool MoonBall;

        [Label("[i:ReducedGrinding/SlimeTrophy] Slime Trophy")]
        [Tooltip("\n" +
            "This trophy's drop chances are the same as Slime Staff in vanilla. Slime Staff\n" +
            "is sometimes seen as a trophy item, so this is an alternative trophy item in\n" +
            "case you set lower drop rates for Slime Staff.")]
        [DefaultValue(true)]
        public bool SlimeTrophy;

        [Label("[i:ReducedGrinding/BestiaryTrophy] Bestiary Trophy")]
        [Tooltip("" +
            "If the Bestiary is 100% complete, the Zoologoist will sell this Trophy. This\n" +
            "acts as a replacement reward if the Universal Pylon is set to be craftable.")]
        [DefaultValue(true)]
        public bool BestiaryTrophy;

        [Label("[i:ReducedGrinding/PlanteraSap] Plantera Drop from Plantera")]
        [Tooltip("Summons Plantera. Chance = 1 / configuration_setting. Set to 0 to disable.")]
        [DefaultValue(0)]
        public int PlanteraSapFromPlantera;
        #endregion

        #region Battle Potions
        [Header("Spawn Increasing Potions\n" +
            "If you experience lag, try turning down max spawns first. For each Potion, setting both max spawns and spawn rate will disable their recipe.\n\n" +
            "[i:ReducedGrinding/GreaterBattlePotion] Greater Battle Potion")]

        [Label("Max Spawns Multiplier")]
        [Increment(.1f)]
        [Range(1f, 10f)]
        [DefaultValue(3f)]
        public float GreaterBattlePotionMaxSpawnsMultiplier;

        [Label("Spawn Rate Multiplier")]
        [Increment(.1f)]
        [Range(1f, 10f)]
        [DefaultValue(4f)]
        public float GreaterBattlePotionSpawnrateMultiplier;

        [Header("[i:ReducedGrinding/SuperBattlePotion] Super Battle Potion")]

        [Label("Max Spawns Multiplier")]
        [Increment(.1f)]
        [Range(1f, 10f)]
        [DefaultValue(4f)]
        public float SuperBattlePotionMaxSpawnsMultiplier;

        [Label("Spawn Rate Multiplier")]
        [Increment(.1f)]
        [Range(1f, 10f)]
        [DefaultValue(8f)]
        public float SuperBattlePotionSpawnrateMultiplier;
        #endregion

        #region Staff of Difficulty
        [Header("[i:ReducedGrinding/StaffOfDifficulty] Staff of Difficulty. Because it's a creative item, it is simply crafted with 1 dirt block for early and instant use. Disable all to disable the recipe.")]

        [Label("Enable Switching to Journey")]
        [DefaultValue(false)]
        public bool StaffOfDifficultyJourney;

        [Label("Enable Switching to Normal")]
        [DefaultValue(false)]
        public bool StaffOfDifficultyNormal;

        [Label("Enable Switching to Expert")]
        [DefaultValue(false)]
        public bool StaffOfDifficultyExpert;

        [Label("Enable Switching to Master")]
        [DefaultValue(false)]
        public bool StaffOfDifficultyMaster;
        #endregion

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    [Label("Other")]
    public class IOtherConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("[i:4144] Chest Terragrim Chance")]
        [Tooltip("" +
            "Chance for vanilla chests to generate with Terragrim inside. This excludes\n" +
            "Regular Wooden Chests. Chance = 1 / configuration_setting. Set to 0 to disable.")]
        [DefaultValue(75)]
        public int TerragrimChestChance;

        #region Crates
        [Header("" +
            "Crates\n\n" +
            "All configurations in this section will add a (1 / configuration_setting) to drop. Set to 0 to disable.\n\n" +
            "[i: 3205] Dungeon / Stockade Crate")]

        [Label("[i:1408] Dungeon Color Furniture Piece (Random Color)")]
        [Range(0, 10000)]
        [DefaultValue(1)]
        public int DungeonCrateDungeonFurniture;

        [Header("[i:3981] Titanium / Mythril / Pearlwood")]

        [Label("[i:3064] Enchanted Sundial")]
        [Tooltip("" +
            "Changes the chance of Enchanted Sundial drop unless it's set to 0. Denominator\n" +
            "is multiplied by 3 for Mythril and 10 for Pearlwood")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateEnchantedSundial;

        [Header("[i:3981] Titanium / Mythril / Pearlwood and Their Pre-Hardmode Variants")]

        [Label("[i:438] King, Queen, Heart, Star, and Bomb Statue")]
        [Tooltip("" +
            "Randomly selects 1 of the 5 statues. Denominator is multiplied by 3 for Mythril\n" +
            "and 10 for Pearlwood")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int CrateStatue;
        #endregion

        #region Traveling Merchant
        [Header("Traveling Merchant\n\n" +
            "[i:ReducedGrinding/MerchantDice] Merchant Dice. For a limited amount of times per day, you can use this to re-roll the Traveling Merchant shop. The Traveling Merchant will only sell it if it's set higher than 0.")]

        [Label("Before Hardmode")]
        [Range(0, 100)]
        [DefaultValue(0)]
        public int TravelingMerchantDiceUsesBeforeHardmode;

        [Label("Hardmode")]
        [Range(0, 100)]
        [DefaultValue(0)]
        public int TravelingMerchantDiceUsesHardmode;

        [Label("After Plantera")]
        [Range(0, 100)]
        [DefaultValue(0)]
        public int TravelingMerchantDiceUsesAfterPlantera;

        [Header("Extra item rolls (chance = 1 / configuration setting)")]

        [Label("[i:3059] Christmas Paintings Extra Chance (for each)")]
        [Tooltip("Chance = 1 / configuration_setting")]
        [Range(0, 600)]
        [DefaultValue(5)]
        public int TravelingMerchantChristmasChance;

        [Label("[i:2867] Martian Paintings Extra Chance (for each)")]
        [Tooltip("$Mods.ReducedGrinding.Config.IOtherConfig.Tooltip.TravelingMerchantItemExtraChance")]
        [Range(0, 600)]
        [DefaultValue(0)]
        public int TravelingMerchantMartianChance;

        [Label("[i:3596] Not a Kid, nor a Squid Extra Chance")]
        [Tooltip("$Mods.ReducedGrinding.Config.IOtherConfig.Tooltip.TravelingMerchantItemExtraChance")]
        [Range(0, 600)]
        [DefaultValue(0)]
        public int TravelingMerchantNotAKidNorASquidChance;

        [Label("[i:2223] Pulse Bow Extra Chance")]
        [Tooltip("$Mods.ReducedGrinding.Config.IOtherConfig.Tooltip.TravelingMerchantItemExtraChance")]
        [Range(0, 600)]
        [DefaultValue(10)]
        public int TravelingMerchantPulseBowChance;
        #endregion

        #region Holiday Timeline
        [Header("" +
            "Periodic Holiday Timeline.\n\n" +
            "This mod will run a looping timeline for periodically triggering Halloween and Christmas events.A[i: ReducedGrinding / Calendar] Calendar item can also be purchased from the Merchant to see the current date.Halloween will happen on the last day of October and Christmas will happen around the end of December. Set to 0 to disable.")]

        [Label("Days Per Month (12 Months per year)")]
        [Range(0, 30)]
        [DefaultValue(2)]
        public int HolidayTimelineDaysPerMonth;
        #endregion

        #region Crafting
        [Header("Crafting")]

        [Label("[i:67] Infection Powder per Mushroom")]
        [Tooltip("Set to 5 to disable custom recipe")]
        [Range(5, 999)]
        [DefaultValue(5)]
        public int InfectionPowderPerMushroom;

        [Label("Allow crafting [i:2889] Gold Critters")]
        [Tooltip("Recipes use 10 Gold Coins to prevent exploiting the recipe for money")]
        [DefaultValue(false)]
        public bool CraftableGoldCritters;

        [Label("Craftable Rare Chests")]
        [DefaultValue(false)]
        public bool CraftableRareChests;

        [Label("Craftable [i:4951] Universal Pylon Difficulty")]
        [Tooltip("" +
            "0: Disabled 1: Crafted out of all other Pylons 2: Same as 1, + crafted at\n" +
            "Crystal Ball instead of Tinker's Workshop 3: Same as 2 + crafted with all Souls")]
        [Range(0, 3)]
        [DefaultValue(1)]
        public int CraftableUniversalPylon;
        #endregion

        #region Sleep Time Rate
        [Header("" +
            "Sleeping Time Rate Increase\n" +
            "In vanilla, sleeping multiplies the time rate by 5; afterward, an amount will get added to the time rate using the conditions below.")]

        [Label("Pre-Hardmode")]
        [DefaultValue(0)]
        public int SleepRateIncreasePreHardmode;

        [Label("Hardmode")]
        [DefaultValue(0)]
        public int SleepRateIncreaseHardmode;

        [Label("Post-Plantera")]
        [DefaultValue(0)]
        public int SleepRateIncreasePostPlantera;
        #endregion

        #region Other
        [Header("Other")]

        [Label("Adjust Values For Drop Increases")]
        [Tooltip("" +
            "If enabled, items with extra drop rates will have their values\n" +
            "reduced depending on how much their drop rate is increased.\n" +
            "New value is multiplied by (chance / total_new_chance).")]
        [DefaultValue(true)]
        public bool AdjustItemValuesForDropIncreases;

        [Label("Equipping [i:1612] Ankh Charm Material Allows Use From Inventory")]
        [Tooltip("" +
            "If enabled, equipping any accessory in the Ankh Charm crafting\n" +
            "tree will allow all other accessories in the Ankh Charm\n" +
            "crafting tree to work from your inventory.")]
        [DefaultValue(true)]
        public bool AnkhMaterialUseFromInventory;

        [Label("Cancel Invasions When All Players Are Underground")]
        [DefaultValue(true)]
        public bool CancelInvasionsIfAllPlayersAreUnderground;

        [Label("Merchant Sells [i:410] Miner's Shirt and [i:411] Miner's Pants")]
        [DefaultValue(false)]
        public bool MerchantSellsMinersShirtAndPants;

        [Label("Skeleton Merchant Ignores Moonphases")]
        [DefaultValue(false)]
        public bool SkeletonMerchantIgnoresMoonphases;

        [Label("[i:4951] Universal Pylon, Bestiary completion % to unlock")]
        [Tooltip("" +
            "In vanilla, there are 523 entries. 51% can be achieved before\n" +
            "Hardmode.Set to 100 % to disable")]
        [Increment(0.01f)]
        [DefaultValue(1f)]
        public float UniversalPylonBestiaryCompletionRate;

        [Label("Allow spawning Regular and Ice Mimics")]
        [Tooltip("" +
            "If enable, placing nothing but 1 Key of Light and 1 Key of Night in a chest will\n" +
            "spawn a regular Mimic.Doing this in a Snow Biome will spawn an Ice Mimic.")]
        [DefaultValue(false)]
        public bool AllSpawningRegularMimics;
        #endregion

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }
}
