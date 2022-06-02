using System.ComponentModel;
using Terraria.ModLoader.Config;
using System;

namespace ReducedGrinding
{

    [Label("Enemy Loot")]
    public class AEnemyLootConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("All configurations in this section will add an 1/n chance for a drop, where n is the configuration setting. Set to 0 to disable.\n\nBoss Loot")]

        [Label("[i:1313] Book of Skulls")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootBookofSkullsIncrease;

        [Label("[i:1294] Picksaw")]
        [Range(0, 10000)]
        [DefaultValue(3)]
        public int LootPicksawIncrease;

        [Label("[i:1182] Seedling")]
        [Range(0, 10000)]
        [DefaultValue(7)]
        public int LootSeedlingIncrease;

        [Label("[i:1169] Bone Key")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootSkeletronBoneKey;

        [Label("[i:1299] Binoculars")]
        [Range(0, 10000)]
        [DefaultValue(3)]
        public int LootBinocularsIncrease;

        [Label("[i:3060] Bone Rattle")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int LootBoneRattleIncrease;

        [Label("[i:3373] Boss Mask")]
        [Range(0, 10000)]
        [DefaultValue(10)]
        public int LootBossMaskIncrease;

        [Label("[i:3595] Boss Trophy")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootBossTrophyIncrease;

        [Label("[i:994] Eater's Bone")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int LootEatersBoneIncrease;

        [Label("[i:2609] Fishron Wings")]
        [Range(0, 10000)]
        [DefaultValue(7)]
        public int LootFishronWingsIncrease;

        [Label("[i:2502] Honeyed Goggles")]
        [Range(0, 10000)]
        [DefaultValue(7)]
        public int LootHoneyedGogglesIncrease;

        [Label("[i:3063] Moon Lord Weapons")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int LootMoonLordEachWeaponIncrease;

        [Label("[i:1170] Nectar")]
        [Range(0, 10000)]
        [DefaultValue(7)]
        public int LootNectarIncrease;

        [Label("[i:1305] The Axe")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int LootTheAxeIncrease;

        [Header("Non-Boss Loot")]

        [Label("[i:1533] Biome Key Increase")]
        [Tooltip("This sets the same drop rate for each")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootBiomeKeyIncrease;

        [Label("[i:723] Beam Sword")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootBeamSwordIncrease;

        [Label("[i:1825] Bloody Machete and [i:1827] Bladed Glove")]
        [Tooltip("This sets the same drop rate for each")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootBloodyMacheteAndBladedGlovesIncrease;

        [Label("[i:1774] Goodie Bag")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootGoodieBagIncrease;

        [Label("[i:1314] KO Cannon")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootKOCannonIncrease;

        [Label("[i:1172] Lizard Egg")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootLizardEggIncrease;

        [Label("[i:682] Marrow")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootMarrowIncrease;

        [Label("[i:244] Plumber’s Hat")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootPlumbersHatIncrease;

        [Range(0, 10000)]
        [Label("[i:1326] Rod of Discord")]
        [DefaultValue(0)]
        public int LootRodofDiscordIncrease;

        [Tooltip("This is multiplied by 1 for Pinky, 80 for Sand Slime, and 100 for all other Slimes that drop it.")]
        [Label("[i:1309] Slime Staff (Hover for more info)")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootSlimeStaffIncrease;

        [Header("Pirate Loot")]

        [Label("[i:905] Coin Gun (Hover for more info)")]
        [Tooltip("This is multiplied by 2.5 for Pirate Captain and 10 for Regular Pirates")] //TO-DO (This might change in 1.4.4)
        [Range(0, 10000)]
        [DefaultValue(370)]
        public int PirateLootCoinGunBaseIncrease;

        [Label("[i:672] Cutlass (Hover for more info)")]
        [Tooltip("This is multiplied by 2.5 for Pirate Captain and 10 for Regular Pirates")]
        [Range(0, 10000)]
        [DefaultValue(85)]
        public int PirateLootCutlassBaseIncrease;

        [Label("[i:854] Discount Card (Hover for more info)")]
        [Tooltip("This is multiplied by 2.5 for Pirate Captain and 10 for Regular Pirates")]
        [Range(0, 10000)]
        [DefaultValue(222)]
        public int PirateLootDiscountCardBaseIncrease;

        [Label("[i:3033] Gold Ring (Hover for more info)")]
        [Tooltip("This is multiplied by 2.5 for Pirate Captain and 10 for Regular Pirates")]
        [Range(0, 10000)]
        [DefaultValue(233)]
        public int PirateLootGoldRingBaseIncrease;

        [Label("[i:855] Lucky Coin (Hover for more info)")]
        [Tooltip("This is multiplied by 2.5 for Pirate Captain and 10 for Regular Pirates")]
        [Range(0, 10000)]
        [DefaultValue(257)]
        public int PirateLootLuckyCoinBaseIncrease;

        [Label("[i:2584] Pirate Staff (Hover for more info)")]
        [Tooltip("This is multiplied by 2.5 for Pirate Captain and 10 for Regular Pirates")]
        [Range(0, 10000)]
        [DefaultValue(222)]
        public int PirateLootPirateStaffBaseIncrease;

        [Label("[i:1704] Gold Furniture")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootGoldenFurnitureIncrease;

        [Label("[i:1277] Sailor Outfit")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootSailorOutfitIncrease;

        [Header("Drops that don't happen in vanilla.")]

        [Label("[i:3347] Desert Fossil from Dune Splicer (Min and Max in any order)")]
        [Range(0, 999)]
        public int[] LootDesertFossilFromDuneSplicer = new int[] { 0, 0 };

        [Label("[i:3347] Desert Fossil from Tomb Crawler (Min and Max in any order)")]
        [Range(0, 999)]
        public int[] LootDesertFossilFromTombCrawler = new int[] { 0, 0 };

        [Label("[i:169] Sand from Dune Splicer (Min and Max in any order)")]
        [Range(1, 999)]
        public int[] LootSandFromDuneSplicer = new int[] { 0, 0 };

        [Label("[i:169] Sand from Tomb Crawler (Min and Max in any order)")]
        [Range(1, 999)]
        public int[] LootSandFromTombCrawler = new int[] { 0, 0 };

        [Label("[i:857] Sandstorm in a Bottle from Sand Elemental")]
        [Range(0, 10000)]
        [DefaultValue(4)]
        public int LootSandstormInABottleFromSandElemental;

        [Label("[i:2673] Truffle Worm from Duke Fishron")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootTrufflewormFromDukeFishron;

        [Label("[i:951] Snowball Launcher from Spiked Ice Slime")]
        [Range(0, 10000)]
        [DefaultValue(150)]
        public int LootSnowballLauncherFromSpikedIceSlime;

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

        [Label("Multi-Bobber Potion's Bobber Amount (Set to 1, to disable recipe)")]
        [Range(1, 100)]
        [DefaultValue(10)]
        public int MultiBobberPotionBobberAmount;

        [Header("The configurations below will give a chance at resetting the Angler Quest when finishing it. The chance will wait until the amount of players wearing any piece of Angler Armor is less than or equal to the amount of players that finished the current Quest before rolling. The chance is (1 / configuration setting), set to 0 to disable.")]

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

    [Label("Traveling and Stationary Merchant")]
    public class ETravelingAndStationaryMerchantConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Stationary Merchant:\n\nThis NPC sells everything the Traveling Merchant has a chance to sell, but there's a catch. By default, his prices are higher, especially when the Traveling Merchant is away. Also by default, the rarer the item, the more expensive the item is. The price for each item will get modified by the configurations below.")]
        [Label("Allow Spawning")]
        [DefaultValue(true)]
        public bool StationaryMerchant;

        [Label("Base Multiplier When Merchant Present")]
        [Increment(.09f)]
        [Range(1f, 10f)]
        [DefaultValue(4f)]
        public float S_MerchantPriceMultiplierDuringSale;

        [Label("Base Multiplier When Merchant Away")]
        [Increment(.09f)]
        [Range(1f, 10f)]
        [DefaultValue(8f)]
        public float S_MerchantPriceMultiplier;

        [Tooltip("The Traveling Merchant Shop has 6 Rarity Tiers. The price each item in the Stationary Merchant's shop will be multiplied by 1 + ((Rarity_Tier - 1) * This_Configuration)")]
        [Label("Rarity Fee Rate")]
        [Increment(.09f)]
        [Range(0f, 10f)]
        [DefaultValue(1f)]
        public float S_MerchantRarityFee;

        [Header("Traveling Merchant Shop Item Chance Increases")]
        [Label("[i:3055] Acorns")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantAcornsIncrease;

        [Label("[i:2177] Ammo Box")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantAmmoBoxIncrease;

        [Label("[i:1987] Angel Halo")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantAngelHaloIncrease;

        [Label("[i:2271] Arcane Rune Wall")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantArcaneRuneWallIncrease;

        [Label("[i:3309] Black Counter Weight")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantBlackCounterweightIncrease;

        [Label("[i:2262] Blue Dynasty Shingles")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantBlueDynastyShinglesIncrease;

        [Label("[i:3634] Blue Team Block")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantBlueTeamBlockIncrease;

        [Label("[i:3639] Blue Team Platform")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantBlueTeamPlatformIncrease;

        [Label("[i:2214] Brick Layer")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantBrickLayerIncrease;

        [Label("[i:2865] Castle Marsberg")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantCastleMarsbergIncrease;

        [Label("[i:2219] Celestial Magnet")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantCelestialMagnetIncrease;

        [Label("[i:2258] Chalice")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantChaliceIncrease;

        [Label("[i:3262] Code 1")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantCode1Increase;

        [Label("[i:3284] Code 2")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantCode2Increase;

        [Label("[i:3056] Cold Snap")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantColdSnapIncrease;

        [Label("[i:3628] Companion Cube")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantCompanionCubeIncrease;

        [Label("[i:2284] Crimson Cloak")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantCrimsonCapeIncrease;

        [Label("[i:3057] Cursed Saint")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantCursedSaintIncrease;

        [Label("[i:3119] DPS Meter")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantDPSMeterIncrease;

        [Label("[i:2276] Diamond Ring")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantDiamondRingIncrease;

        [Label("[i:2260] Dynasty Wood")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantDynastyWoodIncrease;

        [Label("[i:2215] Extendo Grip")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantExtendoGripIncrease;

        [Label("[i:2242] Fancy Dishes")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantFancyDishesIncrease;

        [Label("[i:1988] Fez")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantFezIncrease;

        [Label("[i:2270] Gatligator")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantGatligatorIncrease;

        [Label("[i:2277] Gi")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantGiIncrease;

        [Label("[i:3633] Green Team Block")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantGreenTeamBlockIncrease;

        [Label("[i:3638] Green Team Platform")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantGreenTeamPlatformIncrease;

        [Label("[i:2279] Gypsy Robe")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantGypsyRobeIncrease;

        [Label("[i:2273] Katana")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantKatanaIncrease;

        [Label("[i:2278] Kimono")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantKimonoIncrease;

        [Label("[i:2282] Leopard Skin")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantLeopardSkinIncrease;

        [Label("[i:3118] Lifeform Analyzer")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantLifeformAnalyzerIncrease;

        [Label("[i:2275] Magic Hat")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantMagicHatIncrease;

        [Label("[i:2866] Martia Lisa")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantMartiaLisaIncrease;

        [Tooltip("Normaly, not sold by the Traveling Merchant")]
        [Label("[i:3102] Metal Detector")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantMetalDetector;

        [Label("[i:2285] Mysterious Cape")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantMysteriousCapeIncrease;

        [Label("[i:3596] Not a Kid Nor a Squid")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantNotAKidNorASquidIncrease;

        [Label("[i:2267] Pad Thai")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantPadThaiIncrease;

        [Label("[i:2216] Paint Sprayer")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantPaintSprayerIncrease;

        [Label("[i:2268] Pho")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantPhoIncrease;

        [Label("[i:3636] Pink Team Block")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantPinkTeamBlockIncrease;

        [Label("[i:3641] Pink Team Platform")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantPinkTeamPlatformIncrease;

        [Label("[i:2217] Portable Cement Mixer")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantPortableCementMixerIncrease;

        [Label("[i:3624] Presserator")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantPresseratorIncrease;

        [Label("[i:2223] Pulse Bow")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantPulseBowIncrease;

        [Label("[i:2286] Red Cape")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantRedCapeIncrease;

        [Label("[i:2261] Red Dynasty Shingles")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantRedDynastyShinglesIncrease;

        [Label("[i:3621] Red Team Block")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantRedTeamBlockIncrease;

        [Label("[i:3622] Red Team Platform")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantRedTeamPlatformIncrease;

        [Label("[i:2269] Revelover")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantRevolverIncrease;

        [Label("[i:2266] Sake")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantSakeIncrease;

        [Label("[i:2296] Sitting Duck’s Fishing Pole")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantSittingDucksFishingPoleIncrease;

        [Label("[i:3058] Snowfellas")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantSnowfellasIncrease;

        [Label("[i:3099] Stopwatch")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantStopwatchIncrease;

        [Label("[i:3059] The Season")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantTheSeasonIncrease;

        [Label("[i:2867] The Truth is Up There")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantTheTruthIsUpThereIncrease;

        [Label("[i:2281] Tiger Skin")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantTigerSkinIncrease;

        [Label("[i:2274] Ultrabright Torch")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantUltraBrightTorchIncrease;

        [Label("[i:2272] Water Gun")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantWaterGunIncrease;

        [Label("[i:3637] White Team Block")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantWhiteTeamBlockIncrease;

        [Label("[i:3642] White Team Platform")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantWhiteTeamPlatformIncrease;

        [Label("[i:2287] Winter Cape")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantWinterCapeIncrease;

        [Label("[i:3314] Yellow Counterweight")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantYellowCounterweightIncrease;

        [Label("[i:3635] Yellow Team Block")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantYellowTeamBlockIncrease;

        [Label("[i:3640] Yellow Team Platform")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantYellowTeamPlatformIncrease;

        [Label("[i:2283] Zebra Skin")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TravelingMerchantZebraSkinIncrease;

        [Label("Increased Christmas Item chances requires Christmas")]
        [DefaultValue(true)]
        public bool TravelingMerchantAlwaysXMasForConfigurations;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    [Label("Vanilla NPCs")]
    public class FOtherVanillaNPCConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("All NPCs Sell Their Death Loot")]
        [DefaultValue(false)]
        public bool AllNPCsSellTheirDeathLoot;

        [Header("Mechanic Sells")]
        [Label("[i:539] Dart Trap and [i:147]Spikes After Skeleton Defeated")]
        [DefaultValue(true)]
        public bool MechanicSellsDartTrapAndSpikesAfterSkeletronDefeated;

        [Label("[i:3722] Geyzer After Wall of Flesh Defeated")]
        [DefaultValue(true)]
        public bool MechanicSellsGeyserAfterWallofFleshDefeated;

        [Header("Witch Doctor Sells")]
        [Label("[i:1146] Lihzahrd Traps After Golem Defeated")]
        [DefaultValue(true)]
        public bool WitchDoctorSellsLihzahrdTrapsAfterGolemDefeated;

        [Label("[i:1150] Wooden Spikes After Golem Defeated")]
        [DefaultValue(true)]
        public bool WitchDoctorSellsWoodenSpikesAfterGolemDefeated;

        [Label("[i:3017] Flower Boots")]
        [DefaultValue(false)]
        public bool WitchDoctorSellsFlowerBoots;

        [Label("[i:2204] Honey Dispenser")]
        [DefaultValue(false)]
        public bool WitchDoctorSellsHoneyDispenser;

        [Label("[i:2338] Seaweed")]
        [DefaultValue(false)]
        public bool WitchDoctorSellsSeaweed;

        [Label("[i:213] Staff of Regrowth")]
        [DefaultValue(false)]
        public bool WitchDoctorSellsStaffofRegrowth;

        [Header("Merchant Sells")]
        [Label("[i:410] All Mining Gear;")]
        [DefaultValue(true)]
        public bool MerchantSellsAllMiningGear;

        [Label("[i:987] Blizzard In A Bottle When In Snow")]
        [DefaultValue(false)]
        public bool MerchantSellsBlizzardInABottleWhenInSnow;

        [Label("[i:53] Cloud In A Bottle When In Sky")]
        [DefaultValue(false)]
        public bool MerchantSellsCloudInABottleWhenInSky;

        [Label("[i:669] Fish Item")]
        [DefaultValue(false)]
        public bool MerchantSellsFishItem;

        [Label("[i:934] Pyramid Items")]
        [DefaultValue(false)]
        public bool MerchantSellsPyramidItems;

        [Label("[i:857] Sandstorm In A Bottle When In Desert")]
        [DefaultValue(false)]
        public bool MerchantSellsSandstormInABottleWhenInDesert;

        [Label("[i:290] Swiftness Potion")]
        [DefaultValue(true)]
        public bool MerchantSellsSwiftnessPotion;

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

        [Tooltip("Summons Plantera")]
        [Label("$Mods.ReducedGrinding.Common.PlanteraBulbLable")]
        [DefaultValue(true)]
        public bool DryadSellsPlanteraBulbAfterPlanteraDefeated;

        [Tooltip("Ends the Goblin Invasion")]
        [Label("$Mods.ReducedGrinding.Common.GoblinRetreatOrderLable")]
        [DefaultValue(true)]
        public bool GoblinTinkererSellsGoblinRetreatOrder;

        [Tooltip("Allows crafting golden critters")]
        [Label("$Mods.ReducedGrinding.Common.GoldReflectionMirror")]
        [DefaultValue(false)]
        public bool MerchantSellsGoldReflectionMirrorForCraftingGoldCrittersItem;

        [Tooltip("Ends the Pirate Invasion")]
        [Label("$Mods.ReducedGrinding.Common.PirateRetreatOrder")]
        [DefaultValue(true)]
        public bool PirateSellsPirateRetreatOrder;

        [Tooltip("Advances the Moon Phase")]
        [Label("$Mods.ReducedGrinding.Common.MoonBall")]
        [DefaultValue(true)]
        public bool WizardSellsMoonBall;

        /* TO-DO
         * The headers for both potion was using "$Mods.ReducedGrinding.Common.WarPotion", but that's no longer working
         */

        [Header("Spawn Increasing Potions\n\nIf you experience lag, try turning down max spawns first.\n\nWarPotion")]
        [Label("Max Spawns Multiplier")]
        [Increment(.09f)]
        [Range(1f, 10f)]
        [DefaultValue(3f)]
        public float WarPotionMaxSpawnsMultiplier;

        [Label("Spawn Rate Multiplier")]
        [Increment(.09f)]
        [Range(1f, 10f)]
        [DefaultValue(3f)]
        public float WarPotionSpawnrateMultiplier;

        [Header("ChaosPotion")]
        [Label("Max Spawns Multiplier")]
        [Increment(.09f)]
        [Range(1f, 10f)]
        [DefaultValue(4f)]
        public float ChaosPotionMaxSpawnsMultiplier;

        [Label("Spawn Rate Multiplier")]
        [Increment(.09f)]
        [Range(1f, 10f)]
        [DefaultValue(4f)]
        public float ChaosPotionSpawnrateMultiplier;

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

        [Tooltip("Permanent version of the Skeleton Merchant")]
        [Label("Allow Bone Merchant Spawning")]
        [DefaultValue(false)]
        public bool BoneMerchant;

        [Label("Bone Merchant Disabled When Luiafk Is Installed")]
        [DefaultValue(false)]
        public bool BoneMerchantDisabledWhenLuiafkIsInstalled;

        [Tooltip("Permanent version of Santa Claus")]
        [Label("Allow Christmas Elf Spawning")]
        [DefaultValue(true)]
        public bool ChristmasElf;

        [Tooltip("Sells what's needed to fight the next Vanilla boss (you can still aquire these items normally)")]
        [Label("Allow Loot Merchant Spawning")]
        [DefaultValue(false)]
        public bool LootMerchant;

        [Label("Craftable Rare Chests")]
        [DefaultValue(false)]
        public bool CraftableRareChests;

        [Label("Add Missing Rare Chest Items During World Generation")]
        [DefaultValue(true)]
        [Tooltip("After Vanilla World Generation, this mod will detect if certain rare chest items are missing from the world and add them to the world. For example: Pyramid items that are missing because the world didn't generate enough Pyramids.")]
        public bool GenerateMissingRareChestItems;

        [Header("\n\nSleep boost and Sleep Potion\n\nIn vanilla, sleeping makes time travel at 5 in-game minutes per real-life second. This mod will add more time after this. The amount of time added can be reduced by different conditions listed below.")]

        [Label("Starting Boost Amount (In-Game Minutes Added)")]
        [Tooltip("Set to 0 to disable Sleep Boost completely, and disable the Sleep Potion recipe.")]
        [DefaultValue(55)]
        [Range(0, 55)]
        public int SleepBoostBase;

        [Label("Multiplier for world without an Enchanted Sundial")]
        [Tooltip("If less than 1, the Map will have an icon for the highest Enchanted Sundial.")]
        [DefaultValue(0.5f)]
        [Increment(0.01f)]
        public float SleepBoostNoSundialMultiplier;

        [Label("Multiplier for No Player with Sleep Buff")]
        [Tooltip("If less than 1, you'll be able to craft Sleep Potion, which gives Sleep Buff. If no player has a Sleep Buff, then the Sleep Boost is multiplied by this amount.")]
        [DefaultValue(0.5f)]
        [Increment(0.01f)]
        public float SleepBoostNoPotionBuffMultiplier;

        [Header("\n\nCrates\n\nAll configurations in this section will add an 1/n chance for a drop, where n is the configuration setting. Set to 0 to disable. Drops from Boss Treasure Bags use the configurations for Boss Loot\n\n[i:3205] Dungeon Crate / Stockade Crate")]

        [Label("[i:1408] Dungeon Color Furniture Piece (Random Color)")]
        [Range(0, 10000)]
        [DefaultValue(1)]
        public int DungeonCrateDungeonFurniture;

        [Header("[i:2336] Golden Crate")]

        [Label("[i:3064] Enchanted Sundial")]
        [Tooltip("Chance is divided by 3 for Mythril and divided by 10 for Pearlwood")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateEnchantedSundial;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }
}
