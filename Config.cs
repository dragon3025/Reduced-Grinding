using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace ReducedGrinding
{

	[Label("Enemy Drop")]
	public class AEnemyDropConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Header("Universal Extra Drop Settings")]
		[Label("Drop Tries For All Enemy Loot")]
		[Tooltip("When an enemy drops loot from vanilla functions, this mod will roll a certain number of\n" +
			"extra chances to drop the loot. How many times should this mod roll an extra chance?")]
		[DefaultValue(1)] public int DropTriesForAllEnemyDroppedLoot;
		[Label("Nrml Mode Mult. For Enemy Loot Wth Sep. Diff. Rates")]
		[Tooltip("It's a vanilla mechanic that some enemy loot have higher drops in Expert Mode than Normal\n" +
			"Mode. When playing on Normal Mode and this mod rolls an extra chance to drop those types of\n" +
			"items, the rate of that extra chance will multiplied by this amount.")]
		[Increment(.0001f)] [DefaultValue(0.5f)] public float NormalModeMultiplierForLootWithSeperateDiffRates;

		[Header("Boss Loot")]
		[Label("[i:1313] Book of Skulls Increase")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootBookofSkullsIncrease;
		[Label("[i:1294] Picksaw Increase")]
		[Increment(.0001f)] [DefaultValue(0.375f)] public float LootPicksawIncrease;
		[Label("[i:1182] Seedling Increase")]
		[Increment(.0001f)] [DefaultValue(0.15f)] public float LootSeedlingIncrease;
		[Label("[i:1169] Bone Key Increase")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootSkeletronBoneKey;
		[Label("[i:1299] Binoculars Increase")]
		[Increment(.0001f)] [DefaultValue(0.467f)] public float LootBinocularsIncrease;
		[Label("[i:3060] Bone Rattle Increase")]
		[Increment(.0001f)] [DefaultValue(0.2f)] public float LootBoneRattleIncrease;
		[Label("[i:3373] Boss Mask Increase")]
		[Increment(.0001f)] [DefaultValue(0.1071f)] public float LootBossMaskIncrease;
		[Label("[i:3595] Boss Trophy Increase")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootBossTrophyIncrease;
		[Label("[i:994] Eater's Bone Increase")]
		[Increment(.0001f)] [DefaultValue(0.2f)] public float LootEatersBoneIncrease;
		[Label("[i:2673] Truffle Worm Increase")]
		[Increment(.0001f)] [DefaultValue(0.5f)] public float LootFishronTruffleworm;
		[Label("[i:2609] Fishron Wings Increase")]
		[Increment(.0001f)] [DefaultValue(0.15f)] public float LootFishronWingsIncrease;
		[Label("[i:2502] Honeyed Goggles Increase")]
		[Increment(.0001f)] [DefaultValue(0.14f)] public float LootHoneyedGogglesIncrease;
		[Label("[i:3063] Moon Lord Weapons Increase")]
		[Increment(.0001f)] [DefaultValue((1f / 3) - (1f / 9))] public float LootMoonLordEachWeaponIncrease;
		[Label("[i:1170] Nectar Increase")]
		[Increment(.0001f)] [DefaultValue(0.14f)] public float LootNectarIncrease;
		[Label("[i:1305] The Axe Increase")]
		[Increment(.0001f)] [DefaultValue(0.20f)] public float LootTheAxeIncrease;

		[Header("Non-Boss Loot")]
		[Label("Biome Key Increase For 1 Mech Boss Down")]
		[Increment(.0001f)] [DefaultValue(0.0004f)] public float BiomeKeyIncreaseForOneMechBossDown;
		[Label("Biome Key Increase For 2 Mech Bosses Down")]
		[Increment(.0001f)] [DefaultValue(0.0012f)] public float BiomeKeyIncreaseForTwoMechBossDown;
		[Label("Biome Key Increase For 3 Mech Bosses Down")]
		[Increment(.0001f)] [DefaultValue(0.0028f)] public float BiomeKeyIncreaseForThreeMechBossDown;
		[Tooltip("Chance that an enemy will drop a chest that can be obtained from the biome you are currently in (water enemies will also have this chance to drop Water Chest and Spider Nest enemies will also have this chance to drop Web Covered Chest.")]
		[Label("Chest Drop From a Matching Biome")]
		[Increment(.0001f)] [DefaultValue(0.01f)] public float AllEnemiesLootBiomeMatchingFoundOnlyChestDrop;
		[Label("Magma Stone Increase From Hellbat")]
		[Increment(.0001f)] [DefaultValue(0f)] public float HellBatLootMagmaStoneIncrease;
		[Label("Magma Stone Increase From Lavabat")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LavaBatLootMagmaStoneIncrease;
		[Label("Adhesive Bandage Increase")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootAdhesiveBandageIncrease;
		[Label("Ale Tosser Increase")]
		[Increment(.0001f)] [DefaultValue(0.833f)] public float LootAleTosserIncrease;
		[Label("Amarok Increase")]
		[Increment(.0001f)] [DefaultValue((1f / 100) - (1f / 300))] public float LootAmarokIncrease;
		[Label("Ancient Cloth Increase")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootAncientClothIncrease;
		[Label("Ancient Cobalt Breastplate Increase")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootAncientCobaltBreastplateIncrease;
		[Label("Ancient Cobalt Helmet Increase")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootAncientCobaltHelmetIncrease;
		[Label("Ancient Cobalt Leggings Increase")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootAncientCobaltLeggingsIncrease;
		[Increment(.0001f)] [DefaultValue(0.015f)] public float LootAncientGoldHelmetIncrease;
		[Increment(.0001f)] [DefaultValue(0.03f)] public float LootAncientHornIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootAncientIronHelmetIncrease;
		[Increment(.0001f)] [DefaultValue(0.0028f)] public float LootAncientNecroHelmetIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootAncientShadowGreavesIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootAncientShadowHelmetIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootAncientShadowScalemailIncrease;
		[Increment(.0001f)] [DefaultValue(0.0025f)] public float LootAnkhCharmMaterialIncreasePerAnkhCharmInInventory;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootArmorPolishIncrease;
		[Increment(.0001f)] [DefaultValue(0.05f)] public float LootBabyGrinchsMischiefWhistleIncrease;
		[Increment(.0001f)] [DefaultValue(0.3f)] public float LootBananarangIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootBeamSwordIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootBezoarIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootBlackBeltIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootBlackLensIncrease;
		[Increment(.0001f)] [DefaultValue(0.0066f)] public float LootBlessedAppleIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootBlindfoldIncrease;
		[Increment(.0001f)] [DefaultValue(0.0015f)] public float LootBloodyMacheteAndBladedGlovesIncrease;
		[Increment(.0001f)] [DefaultValue(0.0078f)] public float LootBoneFeatherIncrease;
		[Increment(.0001f)] [DefaultValue(0.0867f)] public float LootBonePickaxeIncrease;
		[Increment(.0001f)] [DefaultValue(0.0051f)] public float LootBoneSwordIncrease;
		[Increment(.0001f)] [DefaultValue(0.006f)] public float LootBoneWandIncrease;
		[Increment(.0001f)] [DefaultValue(0.01f)] public float LootBrainScramblerIncrease;
		[Increment(.0001f)] [DefaultValue(0.075f)] public float LootBrokenBatWingIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootBunnyHoodIncrease;
		[Increment(.0001f)] [DefaultValue(0.0025f)] public float LootCascadeIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootChainGuillotinesIncrease;
		[Increment(.0001f)] [DefaultValue(0.0027f)] public float LootChainKnifeIncrease;
		[Increment(.0001f)] [DefaultValue(0.875f)] public float LootClassyCane;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootClingerStaffIncrease;
		[Increment(.0001f)] [DefaultValue(0.0467f)] public float LootClothierVoodooDollIncrease;
		[Increment(.0001f)] [DefaultValue(1f)] public float LootCloudFromHarpies;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootCompassIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootCrossNecklaceIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootCrystalVileShardIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootDaedalusStormbowIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootDarkShardIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootDartPistolIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootDartRifleIncrease;
		[Increment(.0001f)] [DefaultValue(0.025f)] public float LootDeathSickleIncrease;
		[Increment(.0001f)] [DefaultValue(0.0214f)] public float LootDemonScytheIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootDepthMeterIncrease;
		[Increment(.0001f)] [DefaultValue(1f)] public float LootDesertFossilFromDuneSplicer;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootDesertSpiritLampIncrease;
		[Increment(.0001f)] [DefaultValue(0.03f)] public float LootDivingHelmetIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootDualHookIncrease;
		[Increment(.0001f)] [DefaultValue(0.00833f)] public float LootElfHatIncrease;
		[Increment(.0001f)] [DefaultValue(0.00833f)] public float LootElfPantsIncrease;
		[Increment(.0001f)] [DefaultValue(0.00833f)] public float LootElfShirtIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootEskimoCoatIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootEskimoHoodIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootEskimoPantsIncrease;
		[Increment(.0001f)] [DefaultValue(0.875f)] public float LootExoticScimitarIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootEyePatchIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootEyeSpringIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootFastClockBaseIncrease;
		[Increment(.0001f)] [DefaultValue(0.05f)] public float LootFestiveWingsIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootFetidBaghnakhsIncrease;
		[Increment(.0001f)] [DefaultValue(0.0367f)] public float LootFireFeatherIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootFleshKnucklesIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootFlyingKnifeIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootFrostStaffIncrease;
		[Increment(.0001f)] [DefaultValue(0.19f)] public float LootFrozenTurtleShellIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootGiantBowIncrease;
		[Increment(.0001f)] [DefaultValue(0.005f)] public float LootGiantHarpyFeatherIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootGoldenFurnitureIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootGoldenKeyIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootGoodieBagIncrease;
		[Increment(.0001f)] [DefaultValue(1f)] public float LootGreenCapForNonAndrewGuide;
		[Increment(.0001f)] [DefaultValue(0.75f)] public float LootHappyGrenadeIncrease;
		[Increment(.0001f)] [DefaultValue(0.0075f)] public float LootHarpoonIncrease;
		[Increment(.0001f)] [DefaultValue(0.0025f)] public float LootHelFireIncrease;
		[Increment(.0001f)] [DefaultValue(1f)] public float LootHiveBlockFromHornetsAndMossHornetsAfterQueenBeDowned;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootHookIncrease;
		[Increment(.0001f)] [DefaultValue(0.0011f)] public float LootIceSickleIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootIlluminantHookIncrease;
		[Increment(.0001f)] [DefaultValue(0.04f)] public float LootJellyfishNecklaceIncrease;
		[Increment(.0001f)] [DefaultValue(0.001f)] public float LootKOCannonIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootKeybrandIncrease;
		[Increment(.0001f)] [DefaultValue(0.0075f)] public float LootKrakenIncrease;
		[Increment(.0001f)] [DefaultValue(0.01f)] public float LootLamiaClothesIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootLifeDrainIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootLightShardIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootLihzahrdPowerCellIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootLivingFireBlockIncrease;
		[Increment(.0001f)] [DefaultValue(0.009f)] public float LootLizardEggIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootMagicDaggerIncrease;
		[Increment(.0001f)] [DefaultValue(0.0375f)] public float LootMagicQuiverIncrease;
		[Increment(.0001f)] [DefaultValue(0.0017f)] public float LootMagnetSphereIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootMandibleBladeIncrease;
		[Increment(.0001f)] [DefaultValue(0.045f)] public float LootMarrowIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootMeatGrinderIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootMegaphoneBaseIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootMeteoriteIncrease;
		[Increment(.0001f)] [DefaultValue(0.2833f)] public float LootMiningHelmetIncrease;
		[Increment(.0001f)] [DefaultValue(0.3093f)] public float LootMiningPantsIncrease;
		[Increment(.0001f)] [DefaultValue(0.3093f)] public float LootMiningShirtIncrease;
		[Increment(.0001f)] [DefaultValue(0.04f)] public float LootMoneyTroughIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootMoonCharmIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootMoonMaskIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootMoonStoneIncrease;
		[Increment(.0001f)] [DefaultValue(0.1381f)] public float LootMothronWingsIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootMummyCostumeIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootNazarIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootNimbusRodIncrease;
		[Increment(.0001f)] [DefaultValue(0.03f)] public float LootObsidianRoseIncrease;
		[Increment(.0001f)] [DefaultValue(0.9f)] public float LootPaintballGunIncrease;
		[Increment(.0001f)] [DefaultValue(0.35f)] public float LootPaladinsShieldIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootPedguinssuitIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootPhilosophersStoneIncrease;
		[Increment(.0001f)] [DefaultValue(0.015f)] public float LootPirateMapIncrease;
		[Increment(.0001f)] [DefaultValue(0.048f)] public float LootPlumbersHatIncrease;
		[Increment(.0001f)] [DefaultValue(0.105f)] public float LootPocketMirrorIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootPresentIncrease;
		[Increment(.0001f)] [DefaultValue(0.1125f)] public float LootPsychoKnifeIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootPutridScentIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootRainArmorIncrease;
		[Range(1, 1000)]
		[Slider]
		[DefaultValue(0)] public int LootRainbowBlockDropMaxIncrease;
		[Range(1, 1000)]
		[Slider]
		[DefaultValue(0)] public int LootRainbowBlockDropMinIncrease;
		[Increment(.0001f)] [DefaultValue(0.061f)] public float LootRallyIncrease;
		[Increment(.0001f)] [DefaultValue(0.0917f)] public float LootReindeerBellsIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootRifleScopeIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootRobotHatIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootRocketLauncherIncrease;
		[Increment(.0001f)] [DefaultValue(0.1291f)] public float LootRodofDiscordIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootSWATHelmetIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootSailorHatIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootSailorPantsIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootSailorShirtIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootShackleIncrease;
		[Range(1, 1000)]
		[Slider]
		[DefaultValue(50)] public int LootMaxSandFromDuneSplicer;
		[Range(1, 1000)]
		[Slider]
		[DefaultValue(0)] public int LootMaxSandFromTombCrawler;
		[Range(1, 1000)]
		[Slider]
		[DefaultValue(20)] public int LootMinSandFromDuneSplicer;
		[Range(1, 1000)]
		[Slider]
		[DefaultValue(0)] public int LootMinSandFromTombCrawler;
		[Increment(.0001f)] [DefaultValue(0.048f)] public float LootSkullIncrease;
		[Increment(.0001f)] [DefaultValue(0.075f)] public float LootSlimeStaffIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootSniperRifleIncrease;
		[Increment(.0001f)] [DefaultValue(0.0133f)] public float LootSnowballLauncherIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootSoulofLightIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootSoulofNightIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootStarCloakIncrease;
		[Increment(.0001f)] [DefaultValue(0.875f)] public float LootStylishScissorsIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootSunMaskIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootTabiIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootTacticalShotgunIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootTallyCounterIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootTatteredBeeWingIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootTendonHookIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootTitanGloveIncrease;
		[Increment(.0001f)] [DefaultValue(0.15f)] public float LootToySledIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootTrifoldMapIncrease;
		[Increment(.0001f)] [DefaultValue(0.1412f)] public float LootTurtleShellIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootUmbrellaHatIncrease;
		[Increment(.0001f)] [DefaultValue(0.04f)] public float LootUnicornonaStickIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootUziIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootVikingHelmetIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootVitaminsIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootWhoopieCushionIncrease;
		[Increment(.0001f)] [DefaultValue(0.0063f)] public float LootWispinaBottleIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootWormHookIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float LootYeletsIncrease;
		[Increment(.0001f)] [DefaultValue(0.016f)] public float LootZombieArmIncrease;
		[Increment(.0001f)] [DefaultValue(0.0027f)] public float PirateLootCoinGunBaseIncrease;
		[Increment(.0001f)] [DefaultValue(0.0117f)] public float PirateLootCutlassBaseIncrease;
		[Increment(.0001f)] [DefaultValue(0.0045f)] public float PirateLootDiscountCardBaseIncrease;
		[Increment(.0001f)] [DefaultValue(0.0043f)] public float PirateLootGoldRingBaseIncrease;
		[Increment(.0001f)] [DefaultValue(0.0039f)] public float PirateLootLuckyCoinBaseIncrease;
		[Increment(.0001f)] [DefaultValue(0.0045f)] public float PirateLootPirateStaffBaseIncrease;
		[DefaultValue(true)] public bool LootBloodyMacheteAndBladedGlovesAreNotLimitedByDamageAndDefense;
		[DefaultValue(false)] public bool SlimeStaffIncreaseToSurfaceSlimes;
		[DefaultValue(false)] public bool SlimeStaffIncreaseToUndergroundSlimes;
		[DefaultValue(false)] public bool SlimeStaffIncreaseToCavernSlimess;
		[DefaultValue(true)] public bool SlimeStaffIncreaseToIceSpikedSlimes;
		[DefaultValue(true)] public bool SlimeStaffIncreaseToSpikedJungleSlimes;

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
		{
			message = "Can't change settings in a server.";
			return false;
		}
	}

	[Label("Grab Bags")]
	public class BGrabBagConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Increment(.0001f)] [DefaultValue(0.2f)] public float CrateDungeonBoneWelder;
		[Increment(.0001f)] [DefaultValue(5.0f / 6)] public float CrateDungeonHardmodeGoldenLockBoxIncrease;
		[Increment(.0001f)] [DefaultValue((1f / 4) - (1f / 20))] public float CrateEnchantedSundialGoldenIncrease;
		[Increment(.0001f)] [DefaultValue((1f / 16) - (1f / 60))] public float CrateEnchantedSundialIronIncrease;
		[Increment(.0001f)] [DefaultValue((1f / 64) - (1f / 200))] public float CrateEnchantedSundialWoodenIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float CrateJungleAnkeltOfTheWindIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float CrateJungleFeralClawsIncrease;
		[Increment(.0001f)] [DefaultValue(0.25f)] public float CrateJungleFlowerBoots;
		[Increment(.0001f)] [DefaultValue(0f)] public float CrateJungleLeafWand;
		[Increment(.0001f)] [DefaultValue(0f)] public float CrateJungleLivingLoom;
		[Increment(.0001f)] [DefaultValue(0f)] public float CrateJungleLivingMahoganyWand;
		[Increment(.0001f)] [DefaultValue(0f)] public float CrateJungleLivingWoodWand;
		[Increment(.0001f)] [DefaultValue(0f)] public float CrateJungleRichMahoganyLeafWand;
		[Increment(.0001f)] [DefaultValue(0.25f)] public float CrateJungleSeaweed;
		[Increment(.0001f)] [DefaultValue(0f)] public float CrateJungleStaffOfRegrowth;
		[Increment(.0001f)] [DefaultValue(0.3333f)] public float CrateSkySkyMill;
		[Increment(.0001f)] [DefaultValue(0f)] public float CrateFlippersGolden;
		[Increment(.0001f)] [DefaultValue(0f)] public float CrateFlippersIron;
		[Increment(.0001f)] [DefaultValue(0f)] public float CrateFlippersWooden;
		[Increment(.0001f)] [DefaultValue(0f)] public float CrateWaterWalkingBootsGolden;
		[Increment(.0001f)] [DefaultValue(0f)] public float CrateWaterWalkingBootsIron;
		[Increment(.0001f)] [DefaultValue(0f)] public float CrateWaterWalkingBootsWooden;
		[Increment(.0001f)] [DefaultValue(0f)] public float CrateWoodenAgletIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float CrateWoodenClimbingClawsIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float CrateWoodenRadarIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentCandyCaneBlock;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentCandyCaneHook;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentCandyCanePickaxe;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentCandyCaneSword;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentChristmasPudding;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentCoal;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentDogWhistle;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentEggnog;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentFruitcakeChakram;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentGingerbreadCookie;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentGreenCandyCaneBlock;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentHandWarmer;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentHardmodeSnowGlobe;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentHolly;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentMrsClausCostume;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentParkaOutfit;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentPineTreeBlock;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentRedRyderPlusMusketBall;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentReindeerAntlers;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentSnowHat;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentStarAnise;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentSugarCookie;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentToolbox;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentTreeCostume;
		[Increment(.0001f)] [DefaultValue(0f)] public float PresentUglySweater;

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
		{
			message = "Can't change settings in a server.";
			return false;
		}
	}

	[Label("Angler, Extra Chances for Quest Rewards")]
	public class CAnglerQuestRewardsConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Increment(.0001f)] [DefaultValue(0.025f)] public float QuestAnglerEarringIncrease;
		[Increment(.0001f)] [DefaultValue(0.05f)] public float QuestAnglerHatIncrease;
		[Increment(.0001f)] [DefaultValue(0.05f)] public float QuestAnglerPantsIncrease;
		[Increment(.0001f)] [DefaultValue(0.05f)] public float QuestAnglerVestIncrease;
		[Increment(.0001f)] [DefaultValue(0.04f)] public float QuestCoralstoneBlockIncrease;
		[Increment(.0001f)] [DefaultValue(0.04f)] public float QuestDecorativeFurnitureIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float QuestFishCostumeIncrease;
		[Increment(.0001f)] [DefaultValue(0.033f)] public float QuestFishHookIncrease;
		[Increment(.0001f)] [DefaultValue(0.025f)] public float QuestFishermansGuideIncrease;
		[Increment(.0001f)] [DefaultValue(0.012f)] public float QuestGoldenBugNetIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float QuestGoldenFishingRodIncrease;
		[Increment(.0001f)] [DefaultValue(0.04f)] public float QuestHardcoreBottomlessBucketIncrease;
		[Increment(.0001f)] [DefaultValue(0.04f)] public float QuestHardcoreFinWingsIncrease;
		[Increment(.0001f)] [DefaultValue(0.086f)] public float QuestHardcoreHotlineFishingHookIncrease;
		[Increment(.0001f)] [DefaultValue(0.086f)] public float QuestHardcoreSuperAbsorbantSpongeIncrease;
		[Increment(.0001f)] [DefaultValue(0.025f)] public float QuestHighTestFishingLineIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float QuestMermaidCostumeIncrease;
		[Increment(.0001f)] [DefaultValue(0.025f)] public float QuestSextantIncrease;
		[Increment(.0001f)] [DefaultValue(0.025f)] public float QuestTackleBoxIncrease;
		[Increment(.0001f)] [DefaultValue(0.09f)] public float QuestTrophyIncrease;
		[Increment(.0001f)] [DefaultValue(0.025f)] public float QuestWeatherRadioIncrease;

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
		{
			message = "Can't change settings in a server.";
			return false;
		}
	}

	[Label("Extractinator")]
	public class DExtractinatorConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesAmber;
		[Increment(.0001f)] [DefaultValue(0.0014f)] public float ExtractinatorGivesAmberMosquito;
		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesAmethyst;
		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesCopperCoin;
		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesCopperOre;
		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesDiamond;
		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesEmerald;
		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesFossilOre;
		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesGoldCoin;
		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesGoldOre;
		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesIronOre;
		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesLeadOre;
		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesPlatinumCoin;
		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesPlatinumOre;
		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesRuby;
		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesSapphire;
		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesSilverCoin;
		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesSilverOre;
		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesTinOre;
		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesTopaz;
		[Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesTungstenOre;

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

		[Tooltip("The chance of the Traveling Merchant spawning each morning is this amount when you have all permanent vanilla and Reduced Grinding NPCs.")]
		[Increment(.0001f)] [DefaultValue(1.0f)] public float BaseMorningTMerchantSpawnChance;
		[Increment(.0001f)] [DefaultValue(0.0432f)] public float ChanceEachInGameMinuteWillResetTravelingMerchant;
		[Tooltip("This NPC's shop starts with nothing and each time the Traveling Merchant shop is reset from either vanilla or Reduced Grinding mechanics, the Stationary Merchant will have a chance to gain some of the Stationary Merchant's items.")]
		[DefaultValue(true)] public bool StationaryMerchant;
		[Increment(.0001f)] [DefaultValue(0.143f)] public float StationaryMerchantStockingChance;
		[Increment(.0001f)] [DefaultValue(0.857f)] public float S_MerchantStockingChanceBonusWhichWillBeMultipliedByH_ModeCompletionRate;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantAcornsIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantAmmoBoxIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantAngelHaloIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantArcaneRuneWallIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantBlackCounterweightIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantBlueDynastyShinglesIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantBlueTeamBlockIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantBlueTeamPlatformIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantBrickLayerIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantCastleMarsbergIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantCelestialMagnetIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantChaliceIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantCode1Increase;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantCode2Increase;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantColdSnapIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantCompanionCubeIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantCrimsonCapeIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantCursedSaintIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantDPSMeterIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantDiamondRingIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantDynastyWoodIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantExtendoGripIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantFancyDishesIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantFezIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantGatligatorIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantGiIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantGreenTeamBlockIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantGreenTeamPlatformIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantGypsyRobeIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantKatanaIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantKimonoIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantLeopardSkinIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantLifeformAnalyzerIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantMagicHatIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantMartiaLisaIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantMetalDetector;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantMysteriousCapeIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantNotAKidNorASquidIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantPadThaiIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantPaintSprayerIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantPhoIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantPinkTeamBlockIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantPinkTeamPlatformIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantPortableCementMixerIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantPresseratorIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantPulseBowIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantRedCapeIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantRedDynastyShinglesIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantRedTeamBlockIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantRedTeamPlatformIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantRevolverIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantSakeIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantSittingDucksFishingPoleIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantSnowfellasIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantStopwatchIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantTheSeasonIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantTheTruthIsUpThereIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantTigerSkinIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantUltraBrightTorchIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantWaterGunIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantWhiteTeamBlockIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantWhiteTeamPlatformIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantWinterCapeIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantYellowCounterweightIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantYellowTeamBlockIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantYellowTeamPlatformIncrease;
		[Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantZebraSkinIncrease;
		[DefaultValue(false)] public bool TravelingMerchantAlwaysXMasForConfigurations;
		[Increment(.0001f)] [DefaultValue(0f)] public float ChanceThatEnemyKillWillResetTravelingMerchant;

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
		{
			message = "Can't change settings in a server.";
			return false;
		}
	}

	[Label("Other Vanilla NPCs")]
	public class FOtherVanillaNPCConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[DefaultValue(false)] public bool AllNPCsSellTheirDeathLoot;
		[DefaultValue(true)] public bool DryadSellsPlanteraBulbAfterPlanteraDefeated;
		[DefaultValue(true)] public bool MechanicSellsDartTrapAndSpikesAfterSkeletronDefeated;
		[DefaultValue(true)] public bool MechanicSellsGeyserAfterWallofFleshDefeated;
		[DefaultValue(true)] public bool WitchDoctorSellsLihzahrdTrapsAfterGolemDefeated;
		[DefaultValue(true)] public bool WitchDoctorSellsWoodenSpikesAfterGolemDefeated;
		[DefaultValue(true)] public bool MerchantSellsAllMiningGear;
		[DefaultValue(false)] public bool MerchantSellsBlizzardInABottleWhenInSnow;
		[DefaultValue(false)] public bool MerchantSellsCloudInABottleWhenInSky;
		[DefaultValue(false)] public bool MerchantSellsFishItem;
		[DefaultValue(false)] public bool MerchantSellsPyramidItems;
		[DefaultValue(false)] public bool MerchantSellsSandstormInABottleWhenInDesert;
		[DefaultValue(true)] public bool MerchantSellsSwiftnessPotion;
		[DefaultValue(false)] public bool WitchDoctorSellsFlowerBoots;
		[DefaultValue(false)] public bool WitchDoctorSellsHoneyDispenser;
		[DefaultValue(false)] public bool WitchDoctorSellsSeaweed;
		[DefaultValue(false)] public bool WitchDoctorSellsStaffofRegrowth;
		[Label("Tax Collector Alert Requirement")]
		[Tooltip("Once the Tax Collector has this much money collected, he will let the player know each morning. Set to 0 to disable.")]
		[Range(0, 100000)]
		[Slider]
		[DefaultValue(50000)] public int TaxCollectorTaxRequiredToChatTaxatMorningAndNight;

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
		{
			message = "Can't change settings in a server.";
			return false;
		}
	}

	[Label("Lock Boxes")]
	public class GLockbBoxConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;
		[Header("These are custom lockboxes that have a chance to drop from all enemies. The type of lockbox depends on either the enemy killed or the biome you're in. The lockbox gives loot that you would normally get from a chest of the matching biome and possibly furniture from the structures that the chest would be found in.")]
		[Tooltip("Set to false to prevent getting funiture items from lockboxes")]
		[DefaultValue(true)] public bool LockBoxesGiveFurniture;
		[Tooltip("Set to false to preent getting non-funiture items from lockboxes")]
		[DefaultValue(true)] public bool LockBoxesGiveNonFurniture;
		[Increment(.0001f)] [DefaultValue(1f)] public float HardmodeModdedLockBoxDropRateModifier;
		[Increment(.0001f)] [DefaultValue(1f)] public float NormalmodeModdedLockBoxDropRateModifier;
		[Label("$Mods.ReducedGrinding.Common.CavernLockboxLable")]
		[Increment(.0001f)] [DefaultValue(0.0025f)] public float CavernModdedCavernLockBoxLoot;
		[Tooltip("Biome Lockboxes will only give loot from Dungeon Biome Chest that any player has obtained in the current world and requires a Biome Key to open.")]
		[Label("$Mods.ReducedGrinding.Common.DungeonBiomeLockboxLabel")]
		[Increment(.0001f)] [DefaultValue(0.0025f)] public float DungeonModdedBiomeLockBoxLoot;
		[Tooltip("Comes in 3 forms (no matter what dungeon your world has): Blue Dungeon, Green Dungeon, and Pink Dungeon.")]
		[Label("$Mods.ReducedGrinding.Common.DungeonFurnitureLockboxLabel")]
		[Increment(.0001f)] [DefaultValue(0.0025f)] public float DungeonFurnitureLockBoxLoot;
		[Label("$Mods.ReducedGrinding.Common.ShadowLockboxLable")]
		[Increment(.0001f)] [DefaultValue(0.0025f)] public float HellBiomeModdedShadowLockBoxLoot;
		[Label("$Mods.ReducedGrinding.Common.LihzahrdLockboxLable")]
		[Increment(.0001f)] [DefaultValue(0.0025f)] public float JungleTempleLihzahrd_Lock_Box;
		[Tooltip("Drops in Underground Desert and Sandstorms")]
		[Label("$Mods.ReducedGrinding.Common.PyramidLockBoxLable")]
		[Increment(.0001f)] [DefaultValue(0.0025f)] public float SandstormAndUndergroundDesertPyramidLockBoxLoot;
		[Label("$Mods.ReducedGrinding.Common.SkywareLockBoxLable")]
		[Increment(.0001f)] [DefaultValue(0.0025f)] public float SkyModdedSkywareLockBoxLoot;
		[Label("$Mods.ReducedGrinding.Common.WebCoveredLockboxLable")]
		[Increment(.0001f)] [DefaultValue(0.0025f)] public float SpiderNestWebCoveredLockBoxLoot;
		[Label("$Mods.ReducedGrinding.Common.LivingWoodLockBoxLable")]
		[Increment(.0001f)] [DefaultValue(0.0025f)] public float SurfaceModdedLivingWoodLockBoxLoot;
		[Label("$Mods.ReducedGrinding.Common.IvyLockBoxLable")]
		[Increment(.0001f)] [DefaultValue(0.0025f)] public float UndergroundJungleBiomeModdedIvyLockBoxLoot;
		[Label("$Mods.ReducedGrinding.Common.IceLockBoxLable")]
		[Increment(.0001f)] [DefaultValue(0.0025f)] public float UndergroundSnowBiomeModdedIceLockBoxLoot;
		[Tooltip("Drops from water enemies.")]
		[Label("$Mods.ReducedGrinding.Common.WaterLockBoxLable")]
		[Increment(.0001f)] [DefaultValue(0.0025f)] public float WaterEnemyModdedWaterLockBoxLoot;

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

		[DefaultValue(true)] public bool GoblinTinkererSellsGoblinRetreatOrder;
		[DefaultValue(false)] public bool MerchantSellsGoldReflectionMirrorForCraftingGoldCrittersItem;
		[DefaultValue(true)] public bool PirateSellsPirateRetreatOrder;
		[DefaultValue(true)] public bool WizardSellsMoonBall;
		[Increment(.0001f)] [Range(1f, 100f)] [DefaultValue(1f)] public float BattlePotionMaxSpawnsMultiplier;
		[Increment(.0001f)] [Range(1f, 100f)] [DefaultValue(1f)] public float BattlePotionSpawnrateMultiplier;
		[Increment(.0001f)] [DefaultValue(0.1f)] public float BloodZombieAndDripplerDropsBloodMoonMedallion;
		[Increment(.0001f)] [Range(1f, 100f)] [DefaultValue(20f)] public float ChaosPotionMaxSpawnsMultiplier;
		[Increment(.0001f)] [Range(1f, 100f)] [DefaultValue(20f)] public float ChaosPotionSpawnrateMultiplier;
		[DefaultValue(true)] public bool LunarCall;
		[Increment(.0001f)] [DefaultValue(1f)] public float MartianSaucerMartianCallDrop;
		[Increment(.0001f)] [Range(1f, 100f)] [DefaultValue(10f)] public float WarPotionMaxSpawnsMultiplier;
		[Increment(.0001f)] [Range(1f, 100f)] [DefaultValue(10f)] public float WarPotionSpawnrateMultiplier;

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
		{
			message = "Can't change settings in a server.";
			return false;
		}
	}

	[Label("Other Custom NPCs")]
	public class IOtherCustomNPCsConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[DefaultValue(true)] public bool BoneMerchant;
		[DefaultValue(true)] public bool Santa;
		[DefaultValue(false)] public bool BoneMerchantDisabledWhenLuiafkIsInstalled;
		[DefaultValue(false)] public bool LootMerchant;
		[DefaultValue(false)] public bool ChestSalesman;
		[DefaultValue(false)] public bool ChestSalesmanPreHardmodeChestsRequireHardmodeActivated;
		[DefaultValue(true)] public bool ChestSalesmanSellsBiomeChests;
		[DefaultValue(true)] public bool ChestSalesmanSellsGoldChest;
		[DefaultValue(true)] public bool ChestSalesmanSellsIceChest;
		[DefaultValue(true)] public bool ChestSalesmanSellsIvyChest;
		[DefaultValue(true)] public bool ChestSalesmanSellsLihzahrdChest;
		[DefaultValue(false)] public bool ChestSalesmanSellsLivingWoodChest;
		[DefaultValue(true)] public bool ChestSalesmanSellsOceanChest;
		[DefaultValue(true)] public bool ChestSalesmanSellsShadowChest;
		[DefaultValue(true)] public bool ChestSalesmanSellsSkywareChest;
		[DefaultValue(true)] public bool ChestSalesmanSellsWebCoveredChest;

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
		{
			message = "Can't change settings in a server.";
			return false;
		}
	}
}
