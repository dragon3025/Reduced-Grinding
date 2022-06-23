using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReducedGrinding
{
    [Label("Enemy Loot Vanilla")]
    public class AEnemyLootConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("These are drops that happen in vanilla. All configurations in this section will add an (1 / configuration_setting) chance to drop. Set to 0 to disable.\n\nBoss Loot")]

        [Label("[i:1299] Binoculars")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int BinocularsIncrease;

        [Label("[i:4823] Empress and [i:2609] Fishron Wings")]
        [Tooltip("This sets the same drop rate for each")]
        [Range(0, 10000)]
        [DefaultValue(7)]
        public int EmpressAndFishronWingsIncrease;

        [Label("[i:4715] Stellar Tune")]
        [Range(0, 10000)]
        [DefaultValue(4)]
        public int StellarTuneIncrease;

        [Label("[i:5075] Rainbow Cursor")]
        [Range(0, 10000)]
        [DefaultValue(4)]
        public int RainbowCursor;

        [Header("Non-Boss Loot")]

        [Label("[i:3349] Town NPC Weapons")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TownNPCWeapons;

        [Label("[i:1533] Biome Key Increase")]
        [Tooltip("This sets the same drop rate for each")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int BiomeKeyIncrease;

        [Label("[i:723] Beam Sword")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int BeamSwordIncrease;

        [Label("[i:1825] Bloody Machete and [i:1827] Bladed Glove")]
        [Tooltip("This sets the same drop rate for each")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int BloodyMacheteAndBladedGlovesIncrease;

        [Label("[i:1774] Goodie Bag")]
        [Tooltip("Only drops during Halloween")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int GoodieBagIncrease;

        [Label("[i:1314] KO Cannon")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int KOCannonIncrease;

        [Label("[i:38] Lens")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LensIncrease;

        [Label("[i:1172] Lizard Egg")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LizardEggIncrease;

        [Label("[i:682] Marrow")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int MarrowIncrease;

        [Label("[i:1513] Paladin's Hammer")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PaladinsHammerIncrease;

        [Label("[i:938] Paladin's Shield")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PaladinsShieldIncrease;

        [Label("[i:244] Plumber’s Hat")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PlumbersHatIncrease;

        [Label("[i:1869] Present")]
        [Tooltip("Only drops during Christmas")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentIncrease;

        [Label("[i:1300] Rifle Scope and [i:1254]Sniper Rifle")]
        [Tooltip("This sets the same drop rate for each")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int RifleScopeAndSniperRifleIncrease;

        [Range(0, 10000)]
        [Label("[i:759] Rocket Launcher")]
        [DefaultValue(0)]
        public int RocketLauncherIncrease;

        [Range(0, 10000)]
        [Label("[i:1326] Rod of Discord")]
        [DefaultValue(0)]
        public int RodofDiscordIncrease;

        [Range(0, 10000)]
        [Label("[i:68] Rotten Chunk and [i:1330] Vertebra")]
        [Tooltip("This sets the same drop rate for each")]
        [DefaultValue(0)]
        public int RottenChunkAndVertebra;

        [Label("[i:1309] Slime Staff (Hover for more info)")]
        [Tooltip("This is multiplied by 1 for Pinky, 80 for Sand Slime, and 100 for all other Slimes that drop it.")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int SlimeStaffIncrease;

        [Label("[i:1514] SWAT Helmet and [i:679]Tactical Shotgun")]
        [Tooltip("This sets the same drop rate for each")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int SWATHelmetAndTacticalShotgunIncrease;

        [Header("Pirate Loot (Before the additional chance from the settings below, items are set to drop twice as likely. This is done in attempt to imitate the upcoming 1.4.4 update)")]

        [Label("[i:905] Coin Gun (Hover for more info)")]
        [Tooltip("This is multiplied by 2.5 for Pirate Captain and 10 for Regular Pirates")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CoinGunBaseIncrease;

        [Label("[i:672] Cutlass (Hover for more info)")]
        [Tooltip("This is multiplied by 2.5 for Pirate Captain and 10 for Regular Pirates")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CutlassBaseIncrease;

        [Label("[i:854] Discount Card (Hover for more info)")]
        [Tooltip("This is multiplied by 2.5 for Pirate Captain and 10 for Regular Pirates")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int DiscountCardBaseIncrease;

        [Label("[i:3033] Gold Ring (Hover for more info)")]
        [Tooltip("This is multiplied by 2.5 for Pirate Captain and 10 for Regular Pirates")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int GoldRingBaseIncrease;

        [Label("[i:855] Lucky Coin (Hover for more info)")]
        [Tooltip("This is multiplied by 2.5 for Pirate Captain and 10 for Regular Pirates")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LuckyCoinBaseIncrease;

        [Label("[i:2584] Pirate Staff (Hover for more info)")]
        [Tooltip("This is multiplied by 2.5 for Pirate Captain and 10 for Regular Pirates")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PirateStaffBaseIncrease;

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

        [Header("These are drops that never happen in vanilla, for example: Marble never drops from Marble Cave enemies. All configurations in this section will add an (1 / configuration_setting) chance to drop. Set to 0 to disable.\n\nBoss Loot")]

        [Label("[i:1309] Slime Staff From Slime King")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int SlimeStaffFromSlimeKing;

        [Label("[i:2673] Truffle Worm from Duke Fishron")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TrufflewormFromDukeFishron;

        [Label("[i:4144] Terragrim from Most Hardmode Grab Bags")]
        [Tooltip("From all Boss Bags that can drop Developer Items")]
        [Range(0, 10000)]
        [DefaultValue(60)]
        public int TerragrimFromHardmodeGrabBag;

        [Header("Non-Boss Loot")]

        [Label("[i:3347] Desert Fossil from Dune Splicer (Min and Max in any order)")]
        [Range(0, 999)]
        public int[] DesertFossilFromDuneSplicer = new int[] { 0, 0 };

        [Label("[i:3347] Desert Fossil from Tomb Crawler (Min and Max in any order)")]
        [Range(0, 999)]
        public int[] DesertFossilFromTombCrawler = new int[] { 0, 0 };

        [Label("[i:3081] Marble from Marble Cave Enemies (Min and Max in any order)")]
        [Range(0, 999)]
        public int[] MarbleFromMarbleCaveEnemies = new int[] { 5, 10 };

        [Label("[i:169] Sand from Dune Splicer (Min and Max in any order)")]
        [Range(1, 999)]
        public int[] SandFromDuneSplicer = new int[] { 0, 0 };

        [Label("[i:169] Sand from Tomb Crawler (Min and Max in any order)")]
        [Range(1, 999)]
        public int[] SandFromTombCrawler = new int[] { 0, 0 };

        [Label("[i:857] Sandstorm in a Bottle from Sand Elemental")]
        [Range(0, 10000)]
        [DefaultValue(4)]
        public int SandstormInABottleFromSandElemental;

        [Label("[i:951] Snowball Launcher from Spiked Ice Slime")]
        [Range(0, 10000)]
        [DefaultValue(60)]
        public int SnowballLauncherFromSpikedIceSlime;

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

        [Label("Multi-Bobber Potion's Bobber Amount")]
        [Tooltip("Set to 1 to disable recipe")]
        [Range(1, 100)]
        [DefaultValue(10)]
        public int MultiBobberPotionBobberAmount;

        [Header("Angler Reset Chance\n\nThe configurations below will give a (1 / configuration_setting) chance at resetting the Angler Quest when finishing it. The chance to reset wont happen until the amount of players wearing any piece of Angler Armor is less than or equal to the amount of players that finished the current Quest. Set to 0 to disable.")]

        [Label("Before Hardmode")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int AnglerRecentChanceBeforeHardmode;

        [Label("Hardmode")]
        [Range(0, 10000)]
        [DefaultValue(2)]
        public int AnglerRecentChanceHardmode;

        [Label("After Plantera")]
        [Range(0, 10000)]
        [DefaultValue(2)]
        public int AnglerRecentChanceAfterPlantera;

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

        [Tooltip("Moon Ball")]
        [Label("Wizard Sells Moon Ball")]
        [DefaultValue(true)]
        public bool WizardSellsMoonBall;

        [Label("Plantera Sap Drop from Plantera")]
        [Tooltip("Summons Plantera. Chance of dropping is 1 / configuration_setting. Set to 0 to disable.")]
        [DefaultValue(0)]
        public int PlanteraSapFromPlantera;

        [Header("Spawn Increasing Potions\n\nIf you experience lag, try turning down max spawns first.\n\nGreater Battle Potion")]
        [Label("Max Spawns Multiplier")]
        [Increment(.09f)]
        [Range(1f, 10f)]
        [DefaultValue(3f)]
        public float GreaterBattlePotionMaxSpawnsMultiplier;

        [Label("Spawn Rate Multiplier")]
        [Increment(.09f)]
        [Range(1f, 10f)]
        [DefaultValue(4f)]
        public float GreaterBattlePotionSpawnrateMultiplier;

        [Header("Super Battle Potion")]
        [Label("Max Spawns Multiplier")]
        [Increment(.09f)]
        [Range(1f, 10f)]
        [DefaultValue(4f)]
        public float SuperBattlePotionMaxSpawnsMultiplier;

        [Label("Spawn Rate Multiplier")]
        [Increment(.09f)]
        [Range(1f, 10f)]
        [DefaultValue(8f)]
        public float SuperBattlePotionSpawnrateMultiplier;

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

        [Label("Add Missing Rare Chest Items During World Generation")]
        [DefaultValue(true)]
        [Tooltip("" +
            "After Vanilla World Generation, this mod will detect if certain rare chest items are\n" +
            "missing from the world and add them to the world. For example: Pyramid items that are\n" +
            "missing because the world didn't generate enough Pyramids.")]
        public bool GenerateMissingRareChestItems;

        [Label("[i:4281] Finch Staff From Tree Shaking")]
        [Tooltip("" +
            "Chance is 1 / configuration_setting. Note: Trees can only be shaken 300 times per day.")]
        [DefaultValue(300)]
        public int FinchStaffFromTreeShaking;

        [Label("[i:306] Gold Chest with [i:4144] Terragrim per World Generation")]
        [Tooltip("" +
            "After world generation, this mod will select this many Gold Chest, and insert a\n" +
            "Terragrim into it.")]
        [DefaultValue(1)]
        public int TerragrimChests;

        [Header("\nSleep boost and Sleep Potion\n\nIn vanilla, sleeping makes time travel at 5 in-game minutes per real-life second. This mod will add more time after this. The amount of time added can be reduced by different conditions listed below.")]

        [Label("Starting Boost Amount (In-Game Minutes Added)")]
        [Tooltip("Set to 0 to disable Sleep Boost completely, and disable the Sleep Potion recipe.")]
        [Range(0, 55)]
        [DefaultValue(55)]
        public int SleepBoostBase;

        [Label("Multiplier for No Player with Sleep Buff")]
        [Tooltip("" +
            "If less than 1, you'll be able to craft Sleep Potion, which gives the Sleep Buff. If\n" +
            "no player has a Sleep Buff, then the Sleep Boost is multiplied by this amount.")]
        [DefaultValue(0.5f)]
        [Increment(0.01f)]
        public float SleepBoostNoPotionBuffMultiplier;

        [Label("Sleep Potion Duration in Hours")]
        [DefaultValue(12)]
        public int SleepPotionDurationInHours;

        [Label("Multiplier for active Time Charm")]
        [Tooltip("" +
            "Time Charm is an item crafted at an Enchanted Sundial. Sleep Boost is multiplied by\n" +
            "this unless its toggled on. Set to 0 to disable.")]
        [DefaultValue(0.5f)]
        [Increment(0.01f)]
        public float SleepBoostTimeCharmMultiplier;

        [Header("\nCrates\n\nAll configurations in this section will add an (1 / configuration_setting) to drop. Set to 0 to disable. Drops from Boss Treasure Bags use the configurations for Boss Loot.\n\n[i:3205] Dungeon / Stockade Crate")]

        [Label("[i:1408] Dungeon Color Furniture Piece (Random Color)")]
        [Range(0, 10000)]
        [DefaultValue(1)]
        public int DungeonCrateDungeonFurniture;

        [Header("[i:3981] Titanium / Mythril / Pearlwood")]

        [Label("[i:3064] Enchanted Sundial")]
        [Tooltip("Denominator is multiplied by 3 for Mythril and 10 for Pearlwood")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateEnchantedSundial;

        [Header("[i:3981] Titanium / Mythril / Pearlwood and Their Pre-Hardmode Variants")]

        [Label("[i:438] King, Queen, Heart, Star, and Bomb Statue")]
        [Tooltip("" +
            "Randomly selects 1 of the 5 statues. Denominator is multiplied by 3 for Mythril and 10\n" +
            "for Pearlwood")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int CrateStatue;

        [Header("Traveling Merchant")]

        [Label("Extra Chance Rolls For Items")]
        [Tooltip("" +
            "Shop inventories are limited to 40 items, unless another mod changes this limit. This\n" +
            "will roll item chances, but if it fails every item chance possible, it will skip the\n" +
            "roll to prevent crashing from an infinite loop.")]
        [Range(0, 600)]
        [DefaultValue(0)]
        public int TravelingMerchantExtraRolls;

        [Label("[i:3059] Christmas Paintings Extra Chance")]
        [Tooltip("Chance is 1 / configuration_setting")]
        [Range(0, 600)]
        [DefaultValue(13)]
        public int TravelingMerchantChristmasChance;

        [Label("[i:2867] Martian Paintings Extra Chance")]
        [Tooltip("Chance is 1 / configuration_setting")]
        [Range(0, 600)]
        [DefaultValue(0)]
        public int TravelingMerchantMartianChance;

        [Label("[i:3596] Not a Kid, nor a Squid Extra Chance")]
        [Tooltip("Chance is 1 / configuration_setting")]
        [Range(0, 600)]
        [DefaultValue(0)]
        public int TravelingMerchantNotAKidNorASquidChance;

        [Label("[i:2223] Pulse Bow Extra Chance")]
        [Tooltip("Chance is 1 / configuration_setting")]
        [Range(0, 600)]
        [DefaultValue(100)]
        public int TravelingMerchantPulseBowChance;

        [Header("Periodic Holiday Timeline Day Length.\n\nThis mod will run a timeline for spawning Halloween and Christmas events. Where n is the configuration setting: the timeline will be n * 12 days long, Halloween will be the (9 * n + 1) day, and Christmas will be the last day. Set to 0 to disable.")]
        [Label("Periodic Holiday Timeline Day Length")]
        [Range(1, 30)]
        [DefaultValue(2)]
        public int PeriodicHolidayTimelineDayLength;

        [Header("Other")]

        [Label("Cancel Invasions When All Players Are Underground")]
        [DefaultValue(true)]
        public bool CancelInvasionsIfAllPlayersAreUnderground;

        [Label("Merchant Sells Miner's Shirt and Miner's Pants")]
        [DefaultValue(false)]
        public bool MerchantSellsMinersShirtAndPants;

        [Label("Skeleton Merchant Ignores Moonphases")]
        [DefaultValue(false)]
        public bool SkeletonMerchantIgnoresMoonphases;

        [Label("[i:67] Infection Powder per Mushroom")]
        [Tooltip("Set to 5 to disable custom recipe")]
        [Range(5, 999)]
        [DefaultValue(5)]
        public int InfectionPowderPerMushroom;

        [Label("Allow crafting [i:2889]Gold Critters")]
        [Tooltip("Recipes use 10 Gold Coins to prevent exploiting the recipe for money.")]
        [DefaultValue(false)]
        public bool CraftableGoldCritters;

        [Label("Craftable Rare Chests")]
        [DefaultValue(false)]
        public bool CraftableRareChests;

        [Label("Craftable [i:4951] Universal Pylon Difficulty")]
        [Tooltip("" +
            "0: Disabled, 1: Crafted out of all other Pylons, 2: Same as 1, + crafted at Crystal\n" +
            "Ball instead of Tinker's Workshop, 3: Same as 2 + crafted with all Souls")]
        [Range(0, 3)]
        [DefaultValue(3)]
        public int CraftableUniversalPylon;

        [Label("[i:4951] Universal Pylon, Bestiary completion % to unlock")]
        [Tooltip("" +
            "In vanilla, there are 523 entries. 51% can be achieved before Hardmode. Set to 100% to disable.")]
        [Increment(0.01f)]
        [DefaultValue(1f)]
        public float UniversalPylonBestiaryCompletionRate;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }
}
