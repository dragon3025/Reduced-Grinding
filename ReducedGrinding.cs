using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System;
using Terraria.DataStructures;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria;

/*To debug, use:
ErrorLogger.Log(<string>);

To turn into a string use:
Value.ToString()

To show text in chat use:
Main.NewText(string);
or
Main.NewText(string, red, green, blue);

Chatting a value:
Main.NewText(Value.ToString(), 255, 255, 255);
*/

namespace ReducedGrinding
{
	
	class ReducedGrinding : Mod
    {
		
		public override void Load()
		{
		   Config.Load();
		}
		
        public ReducedGrinding()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
            };
        }
		
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            ReducedGrindingMessageType msgType = (ReducedGrindingMessageType)reader.ReadByte();
            byte playernumber;
			
            int DropTriesForAllEnemyDroppedLoot;
			float NormalModeLootMultiplierForLootWithSeperateDifficultyRates;
			
			float CrateDungeonBoneWelder;
			float CrateEnchantedSundialGoldenIncrease;
			float CrateEnchantedSundialIronIncrease;
			float CrateEnchantedSundialWoodenIncrease;
			float CrateJungleAnkeltOfTheWindIncrease;
			float CrateJungleFeralClawsIncrease;
			float CrateJungleFlowerBoots;
			float CrateJungleLeafWand;
			float CrateJungleLivingLoom;
			float CrateJungleLivingMahoganyWand;
			float CrateJungleLivingWoodWand;
			float CrateJungleRichMahoganyLeafWand;
			float CrateJungleSeaweed;
			float CrateJungleStaffOfRegrowth;
			float CrateSkySkyMill;
			float CrateFlippersGolden;
			float CrateFlippersIron;
			float CrateFlippersWooden;
			float CrateWaterWalkingBootsGolden;
			float CrateWaterWalkingBootsIron;
			float CrateWaterWalkingBootsWooden;
			float CrateWoodenAgletIncrease;
			float CrateWoodenClimbingClawsIncrease;
			float CrateWoodenRadarIncrease;
			float PresentCandyCaneBlock;
			float PresentCandyCaneHook;
			float PresentCandyCanePickaxe;
			float PresentCandyCaneSword;
			float PresentChristmasPudding;
			float PresentCoal;
			float PresentDogWhistle;
			float PresentEggnog;
			float PresentFruitcakeChakram;
			float PresentGingerbreadCookie;
			float PresentGreenCandyCaneBlock;
			float PresentHandWarmer;
			float PresentHardmodeSnowGlobe;
			float PresentHolly;
			float PresentMrsClausCostume;
			float PresentParkaOutfit;
			float PresentPineTreeBlock;
			float PresentRedRyderPlusMusketBall;
			float PresentReindeerAntlers;
			float PresentSnowHat;
			float PresentStarAnise;
			float PresentSugarCookie;
			float PresentToolbox ;
			float PresentTreeCostume;
			float PresentUglySweater;
			
			float LootBookofSkullsIncrease;
			float LootPicksawIncrease;
			float LootSeedlingIncrease;
			float LootSkeletronBoneKey;
			float LootBinocularsIncrease;
			float LootBoneRattleIncrease;
			float LootBossMaskIncrease;
			float LootBossTrophyIncrease;
			float LootEatersBoneIncrease;
			float LootFishronTruffleworm;
			float LootFishronWingsIncrease;
			float LootHoneyedGogglesIncrease;
			float LootNectarIncrease;
			float LootTheAxeIncrease;
			
			float BiomeKeyIncreaseForOneMechBossDown;
			float BiomeKeyIncreaseForTwoMechBossDown;
			float BiomeKeyIncreaseForThreeMechBossDown;
			
			float AllEnemiesLootBiomeMatchingFoundOnlyChestDrop;
			float HellBatLootMagmaStoneIncrease;
			float LavaBatLootMagmaStoneIncrease;
			float LootAdhesiveBandageIncrease;
			float LootAleTosser;
			float LootAmarokIncrease;
			float LootAncientClothIncrease;
			float LootAncientCobaltBreastplateIncrease;
			float LootAncientCobaltHelmetIncrease;
			float LootAncientCobaltLeggingsIncrease;
			float LootAncientGoldHelmetIncrease;
			float LootAncientHornIncrease;
			float LootAncientIronHelmetIncrease;
			float LootAncientNecroHelmetIncrease;
			float LootAncientShadowGreavesIncrease;
			float LootAncientShadowHelmetIncrease;
			float LootAncientShadowScalemailIncrease;
			float LootAnkhCharmMaterialIncreasePerAnkhCharmInInventory;
			float LootArmorPolishIncrease;
			float LootBabyGrinchsMischiefWhistleIncrease;
			float LootBananarangIncrease;
			float LootBeamSwordIncrease;
			float LootBezoarIncrease;
			float LootBlackBeltIncrease;
			float LootBlackLensIncrease;
			float LootBlessedAppleIncrease;
			float LootBlindfoldIncrease;
			float LootBloodyMacheteAndBladedGlovesIncrease;
			float LootBoneFeatherIncrease;
			float LootBonePickaxeIncrease;
			float LootBoneSwordIncrease;
			float LootBoneWandIncrease;
			float LootBrainScramblerIncrease;
			float LootBrokenBatWingIncrease;
			float LootBunnyHoodIncrease;
			float LootCascadeIncrease;
			float LootChainGuillotinesIncrease;
			float LootChainKnifeIncrease;
			float LootClassyCane;
			float LootClingerStaffIncrease;
			float LootClothierVoodooDollIncrease;
			float LootCompassIncrease;
			float LootCrossNecklaceIncrease;
			float LootCrystalVileShardIncrease;
			float LootDaedalusStormbowIncrease;
			float LootDarkShardIncrease;
			float LootDartPistolIncrease;
			float LootDartRifleIncrease;
			float LootDeathSickleIncrease;
			float LootDemonScytheIncrease;
			float LootDepthMeterIncrease;
			float LootDesertSpiritLampIncrease;
			float LootDivingHelmetIncrease;
			float LootDualHookIncrease;
			float LootElfHatIncrease;
			float LootElfPantsIncrease;
			float LootElfShirtIncrease;
			float LootEskimoCoatIncrease;
			float LootEskimoHoodIncrease;
			float LootEskimoPantsIncrease;
			float LootExoticScimitar;
			float LootEyePatchIncrease;
			float LootEyeSpringIncrease;
			float LootFastClockBaseIncrease;
			float LootFestiveWingsIncrease;
			float LootFetidBaghnakhsIncrease;
			float LootFireFeatherIncrease;
			float LootFleshKnucklesIncrease;
			float LootFlyingKnifeIncrease;
			float LootFrostStaffIncrease;
			float LootFrozenTurtleShellIncrease;
			float LootGiantBowIncrease;
			float LootGiantHarpyFeatherIncrease;
			float LootGoldenFurnitureIncrease;
			float LootGoldenKeyIncrease;
			float LootGoodieBagIncrease;
			float LootGreenCap;
			float LootHappyGrenade;
			float LootHarpoonIncrease;
			float LootHelFireIncrease;
			float LootHookIncrease;
			float LootIceSickleIncrease;
			float LootIlluminantHookIncrease;
			float LootJellyfishNecklaceIncrease;
			float LootKOCannonIncrease;
			float LootKeybrandIncrease;
			float LootKrakenIncrease;
			float LootLamiaClothesIncrease;
			float LootLifeDrainIncrease;
			float LootLightShardIncrease;
			float LootLihzahrdPowerCellIncrease;
			float LootLivingFireBlockIncrease;
			float LootLizardEggIncrease;
			float LootMagicDaggerIncrease;
			float LootMagicQuiverIncrease;
			float LootMagnetSphereIncrease;
			float LootMandibleBladeIncrease;
			float LootMarrowIncrease;
			float LootMeatGrinderIncrease;
			float LootMegaphoneBaseIncrease;
			float LootMeteoriteIncrease;
			float LootMiningHelmetIncrease;
			float LootMiningPantsIncrease;
			float LootMiningShirtIncrease;
			float LootMoneyTroughIncrease;
			float LootMoonCharmIncrease;
			float LootMoonMaskIncrease;
			float LootMoonStoneIncrease;
			float LootMothronWingsIncrease;
			float LootMummyCostumeIncrease;
			float LootNazarIncrease;
			float LootNimbusRodIncrease;
			float LootObsidianRoseIncrease;
			float LootPaintballGun;
			float LootPaladinsShieldIncrease;
			float LootPedguinssuitIncrease;
			float LootPhilosophersStoneIncrease;
			float LootPirateMapIncrease;
			float LootPlumbersHatIncrease;
			float LootPocketMirrorIncrease;
			float LootPresentIncrease;
			float LootPsychoKnifeIncrease;
			float LootPutridScentIncrease;
			float LootRainArmorIncrease;
			int LootRainbowBlockDropMaxIncrease;
			int LootRainbowBlockDropMinIncrease;
			float LootRallyIncrease;
			float LootReindeerBellsIncrease;
			float LootRifleScopeIncrease;
			float LootRobotHatIncrease;
			float LootRocketLauncherIncrease;
			float LootRodofDiscordIncrease;
			float LootSWATHelmetIncrease;
			float LootSailorHatIncrease;
			float LootSailorPantsIncrease;
			float LootSailorShirtIncrease;
			float LootShackleIncrease;
			float LootSkullIncrease;
			float LootSlimeStaffIncrease;
			float LootSniperRifleIncrease;
			float LootSnowballLauncherIncrease;
			float LootSoulofLightIncrease;
			float LootSoulofNightIncrease;
			float LootStarCloakIncrease;
			float LootStylishScissors;
			float LootSunMaskIncrease;
			float LootTabiIncrease;
			float LootTacticalShotgunIncrease;
			float LootTallyCounterIncrease;
			float LootTatteredBeeWingIncrease;
			float LootTendonHookIncrease;
			float LootTitanGloveIncrease;
			float LootToySledIncrease;
			float LootTrifoldMapIncrease;
			float LootTurtleShellIncrease;
			float LootUmbrellaHatIncrease;
			float LootUnicornonaStickIncrease;
			float LootUziIncrease;
			float LootVikingHelmetIncrease;
			float LootVitaminsIncrease;
			float LootWhoopieCushionIncrease;
			float LootWispinaBottleIncrease;
			float LootWormHookIncrease;
			float LootYeletsIncrease;
			float LootZombieArmIncrease;
			float PirateLootCoinGunBaseIncrease;
			float PirateLootCutlassBaseIncrease;
			float PirateLootDiscountCardBaseIncrease;
			float PirateLootGoldRingBaseIncrease;
			float PirateLootLuckyCoinBaseIncrease;
			float PirateLootPirateStaffBaseIncrease;
			bool LootBloodyMacheteAndBladedGlovesAreNotLimitedByDamageAndDefense;
			bool SlimeStaffIncreaseToSurfaceSlimes;
			bool SlimeStaffIncreaseToUndergroundSlimes;
			bool SlimeStaffIncreaseToCavernSlimess;
			bool SlimeStaffIncreaseToIceSpikedSlimes;
			bool SlimeStaffIncreaseToSpikedJungleSlimes;

			float CavernModdedCavernLockBoxLoot;
			float DungeonModdedBiomeLockBoxLoot;
			float DungeonFurnitureLockBoxLoot;
			float HardmodeModdedLockBoxDropRateModifier;
			float HellBiomeModdedShadowLockBoxLoot;
			float JungleTempleLihzahrd_Lock_Box;
			float NormalmodeModdedLockBoxDropRateModifier;
			float SandstormAndUndergroundDesertPyramidLockBoxLoot;
			float SkyModdedSkywareLockBoxLoot;
			float SpiderNestWebCoveredLockBoxLoot;
			float SurfaceModdedLivingWoodLockBoxLoot;
			float UndergroundJungleBiomeModdedIvyLockBoxLoot;
			float UndergroundSnowBiomeModdedIceLockBoxLoot;
			float WaterEnemyModdedWaterLockBoxLoot;
			
			float TravelingMerchantAcornsIncrease;
			float TravelingMerchantAmmoBoxIncrease;
			float TravelingMerchantAngelHaloIncrease;
			float TravelingMerchantArcaneRuneWallIncrease;
			float TravelingMerchantBlackCounterweightIncrease;
			float TravelingMerchantBlueDynastyShinglesIncrease;
			float TravelingMerchantBlueTeamBlockIncrease;
			float TravelingMerchantBlueTeamPlatformIncrease;
			float TravelingMerchantBrickLayerIncrease;
			float TravelingMerchantCastleMarsbergIncrease;
			float TravelingMerchantCelestialMagnetIncrease;
			float TravelingMerchantChaliceIncrease;
			float TravelingMerchantCode1Increase;
			float TravelingMerchantCode2Increase;
			float TravelingMerchantColdSnapIncrease;
			float TravelingMerchantCompanionCubeIncrease;
			float TravelingMerchantCrimsonCapeIncrease;
			float TravelingMerchantCursedSaintIncrease;
			float TravelingMerchantDPSMeterIncrease;
			float TravelingMerchantDiamondRingIncrease;
			float TravelingMerchantDynastyWoodIncrease;
			float TravelingMerchantExtendoGripIncrease;
			float TravelingMerchantFancyDishesIncrease;
			float TravelingMerchantFezIncrease;
			float TravelingMerchantGatligatorIncrease;
			float TravelingMerchantGiIncrease;
			float TravelingMerchantGreenTeamBlockIncrease;
			float TravelingMerchantGreenTeamPlatformIncrease;
			float TravelingMerchantGypsyRobeIncrease;
			float TravelingMerchantKatanaIncrease;
			float TravelingMerchantKimonoIncrease;
			float TravelingMerchantLeopardSkinIncrease;
			float TravelingMerchantLifeformAnalyzerIncrease;
			float TravelingMerchantMagicHatIncrease;
			float TravelingMerchantMartiaLisaIncrease;
			float TravelingMerchantMetalDetector;
			float TravelingMerchantMysteriousCapeIncrease;
			float TravelingMerchantNotAKidNorASquidIncrease;
			float TravelingMerchantPadThaiIncrease;
			float TravelingMerchantPaintSprayerIncrease;
			float TravelingMerchantPhoIncrease;
			float TravelingMerchantPinkTeamBlockIncrease;
			float TravelingMerchantPinkTeamPlatformIncrease;
			float TravelingMerchantPortableCementMixerIncrease;
			float TravelingMerchantPresseratorIncrease;
			float TravelingMerchantPulseBowIncrease;
			float TravelingMerchantRedCapeIncrease;
			float TravelingMerchantRedDynastyShinglesIncrease;
			float TravelingMerchantRedTeamBlockIncrease;
			float TravelingMerchantRedTeamPlatformIncrease;
			float TravelingMerchantRevolverIncrease;
			float TravelingMerchantSakeIncrease;
			float TravelingMerchantSittingDucksFishingPoleIncrease;
			float TravelingMerchantSnowfellasIncrease;
			float TravelingMerchantStopwatchIncrease;
			float TravelingMerchantTheSeasonIncrease;
			float TravelingMerchantTheTruthIsUpThereIncrease;
			float TravelingMerchantTigerSkinIncrease;
			float TravelingMerchantUltraBrightTorchIncrease;
			float TravelingMerchantWaterGunIncrease;
			float TravelingMerchantWhiteTeamBlockIncrease;
			float TravelingMerchantWhiteTeamPlatformIncrease;
			float TravelingMerchantWinterCapeIncrease;
			float TravelingMerchantYellowCounterweightIncrease;
			float TravelingMerchantYellowTeamBlockIncrease;
			float TravelingMerchantYellowTeamPlatformIncrease;
			float TravelingMerchantZebraSkinIncrease;
			bool TravelingMerchantAlwaysXMasForConfigurations;
			float ChanceThatEnemyKillWillResetTravelingMerchant;
			bool StationaryMerchant;
			float StationaryMerchantStockingChance;
			float S_MerchantStockingChanceBonusWhichWillBeMultipliedByH_ModeCompletionRate;
			
			float QuestAnglerEarringIncrease;
			float QuestAnglerHatIncrease;
			float QuestAnglerPantsIncrease;
			float QuestAnglerVestIncrease;
			float QuestCoralstoneBlockIncrease;
			float QuestDecorativeFurnitureIncrease;
			float QuestFishCostumeIncrease;
			float QuestFishHookIncrease;
			float QuestFishermansGuideIncrease;
			float QuestGoldenBugNetIncrease;
			float QuestGoldenFishingRodIncrease;
			float QuestHardcoreBottomlessBucketIncrease;
			float QuestHardcoreFinWingsIncrease;
			float QuestHardcoreHotlineFishingHookIncrease;
			float QuestHardcoreSuperAbsorbantSpongeIncrease;
			float QuestHighTestFishingLineIncrease;
			float QuestMermaidCostumeIncrease;
			float QuestSextantIncrease;
			float QuestTackleBoxIncrease;
			float QuestTrophyIncrease;
			float QuestWeatherRadioIncrease;
			
			bool ChestSalesmanPreHardmodeChestsRequireHardmodeActivated;
			bool ChestSalesmanSellsBiomeChests;
			bool ChestSalesmanSellsGoldChest;
			bool ChestSalesmanSellsIceChest;
			bool ChestSalesmanSellsIvyChest;
			bool ChestSalesmanSellsLihzahrdChest;
			bool ChestSalesmanSellsLivingWoodChest;
			bool ChestSalesmanSellsOceanChest;
			bool ChestSalesmanSellsShadowChest;
			bool ChestSalesmanSellsSkywareChest;
			bool ChestSalesmanSellsWebCoveredChest;
			bool ChestSalesmanSpawnable;
			
			bool MechanicSellsDartTrapAfterSkeletronDefeated;
			bool MechanicSellsGeyserAfterWallofFleshDefeated;
			bool MechanicSellsLihzahrdTrapsAfterGolemDefeated;
			bool MechanicSellsWoodenSpikesAfterGolemDefeated;
			bool MerchantSellsAllMiningGear;
			bool MerchantSellsBlizzardInABottleWhenInSnow;
			bool MerchantSellsCloudInABottleWhenInSky;
			bool MerchantSellsFishItem;
			bool MerchantSellsPyramidItems;
			bool MerchantSellsSandstormInABottleWhenInDesert;
			bool WitchDoctorSellsFlowerBoots;
			bool WitchDoctorSellsHoneyDispenser;
			bool WitchDoctorSellsSeaweed;
			bool WitchDoctorSellsStaffofRegrowth;
			int TaxCollectorMinTaxRequiredToChatTaxEachMorningAndNight;
			
			bool GoblinTinkererSellsGoblinRetreatOrder;
			bool MerchantSellsExpertChangePotion;
			bool PirateSellsPirateRetreatOrder;
			bool WizardSellsMoonBall;
			float BattlePotionMaxSpawnsMultiplier;
			float BattlePotionSpawnrateMultiplier;
			float BloodZombieAndDripplerDropsBloodMoonMedallion;
			float ChaosPotionMaxSpawnsMultiplier;
			float ChaosPotionSpawnrateMultiplier;
			float WarPotionMaxSpawnsMultiplier;
			float WarPotionSpawnrateMultiplier;
			
			int NewCharacterBarrels;
			int NewCharacterCopperBars;
			int NewCharacterCopperCoins;
			int NewCharacterGoldBars;
			int NewCharacterGoldCoins;
			int NewCharacterIronBars;
			int NewCharacterMiningPotions;
			int NewCharacterPlatinumCoins;
			int NewCharacterSilverBars;
			int NewCharacterSilverCoins;
			int NewCharacterWarPotions;

			float ExtractinatorGivesAmber;
			float ExtractinatorGivesAmberMosquito;
			float ExtractinatorGivesAmethyst;
			float ExtractinatorGivesCopperCoin;
			float ExtractinatorGivesCopperOre;
			float ExtractinatorGivesDiamond;
			float ExtractinatorGivesEmerald;
			float ExtractinatorGivesFossilOre;
			float ExtractinatorGivesGoldCoin;
			float ExtractinatorGivesGoldOre;
			float ExtractinatorGivesIronOre;
			float ExtractinatorGivesLeadOre;
			float ExtractinatorGivesPlatinumCoin;
			float ExtractinatorGivesPlatinumOre;
			float ExtractinatorGivesRuby;
			float ExtractinatorGivesSapphire;
			float ExtractinatorGivesSilverCoin;
			float ExtractinatorGivesSilverOre;
			float ExtractinatorGivesTinOre;
			float ExtractinatorGivesTopaz;
			float ExtractinatorGivesTungstenOre;
			
			bool CrateUpgradesDependingOnFishingPower;
			float FishCatchBecomesBalloonPufferfish;
			float FishCatchBecomesBladetongue;
			float FishCatchBecomesBlueJellyfish;
			float FishCatchBecomesChaosFish;
			float FishCatchBecomesCorruptCrate;
			float FishCatchBecomesCrimsonCrate;
			float FishCatchBecomesCrystalSerpent;
			float FishCatchBecomesDungeonCrate;
			float FishCatchBecomesFrogLeg;
			float FishCatchBecomesFrostDaggerfish;
			float FishCatchBecomesGoldenCarp;
			float FishCatchBecomesGoldenCrate;
			float FishCatchBecomesGreenJellyfish;
			float FishCatchBecomesHallowedCrate;
			float FishCatchBecomesIronCrate;
			float FishCatchBecomesJungleCrate;
			float FishCatchBecomesPinkJellyfish;
			float FishCatchBecomesPurpleClubberfish;
			float FishCatchBecomesReaverSharkAfterAllMechBossesDowned;
			float FishCatchBecomesReaverSharkAfterEyeOfCthulhuEaterOfWorldsAndSkeletronDowned;
			float FishCatchBecomesReaverSharkBeforeEyeOfCthulhuEaterOfWorldsAndSkeletronDowned;
			float FishCatchBecomesRockfish;
			float FishCatchBecomesSawtoothSharkAfterAllMechBossesDowned;
			float FishCatchBecomesSawtoothSharkAfterEyeOfCthulhuEaterOfWorldsAndSkeletronDowned;
			float FishCatchBecomesSawtoothSharkBeforeEyeOfCthulhuEaterOfWorldsAndSkeletronDowned;
			float FishCatchBecomesScalyTruffle;
			float FishCatchBecomesSkyCrate;
			float FishCatchBecomesSwordfish;
			float FishCatchBecomesToxikarp;
			float FishCatchBecomesWoodenCrate;
			float FishCatchBecomesZephyrFish;
			
			
			
            byte arrayLength;

            BitsByte flags1;
            ReducedGrindingPlayer mPlayer;
			ReducedGrindingWorld world = GetModWorld<ReducedGrindingWorld>();
			
            switch (msgType)
            {
				case ReducedGrindingMessageType.skipToDay:
					bool skipToDay = reader.ReadBoolean();
					ReducedGrindingWorld.skipToDay = skipToDay;
					break;
				// This message sent by the server to initialize the Volcano Rubble.
				case ReducedGrindingMessageType.skipToNight:
					bool skipToNight = reader.ReadBoolean();
					ReducedGrindingWorld.skipToNight = skipToNight;
					break;
                case ReducedGrindingMessageType.SyncPlayer:
                    if(Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        playernumber = reader.ReadByte();  //byte
						
						
						
                        DropTriesForAllEnemyDroppedLoot = reader.ReadInt32();
						NormalModeLootMultiplierForLootWithSeperateDifficultyRates = reader.ReadSingle();
						
						CrateDungeonBoneWelder = reader.ReadSingle();
						CrateEnchantedSundialGoldenIncrease = reader.ReadSingle();
						CrateEnchantedSundialIronIncrease = reader.ReadSingle();
						CrateEnchantedSundialWoodenIncrease = reader.ReadSingle();
						CrateJungleAnkeltOfTheWindIncrease = reader.ReadSingle();
						CrateJungleFeralClawsIncrease = reader.ReadSingle();
						CrateJungleFlowerBoots = reader.ReadSingle();
						CrateJungleLeafWand = reader.ReadSingle();
						CrateJungleLivingLoom = reader.ReadSingle();
						CrateJungleLivingMahoganyWand = reader.ReadSingle();
						CrateJungleLivingWoodWand = reader.ReadSingle();
						CrateJungleRichMahoganyLeafWand = reader.ReadSingle();
						CrateJungleSeaweed = reader.ReadSingle();
						CrateJungleStaffOfRegrowth = reader.ReadSingle();
						CrateSkySkyMill = reader.ReadSingle();
						CrateFlippersGolden = reader.ReadSingle();
						CrateFlippersIron = reader.ReadSingle();
						CrateFlippersWooden = reader.ReadSingle();
						CrateWaterWalkingBootsGolden = reader.ReadSingle();
						CrateWaterWalkingBootsIron = reader.ReadSingle();
						CrateWaterWalkingBootsWooden = reader.ReadSingle();
						CrateWoodenAgletIncrease = reader.ReadSingle();
						CrateWoodenClimbingClawsIncrease = reader.ReadSingle();
						CrateWoodenRadarIncrease = reader.ReadSingle();
						PresentCandyCaneBlock = reader.ReadSingle();
						PresentCandyCaneHook = reader.ReadSingle();
						PresentCandyCanePickaxe = reader.ReadSingle();
						PresentCandyCaneSword = reader.ReadSingle();
						PresentChristmasPudding = reader.ReadSingle();
						PresentCoal = reader.ReadSingle();
						PresentDogWhistle = reader.ReadSingle();
						PresentEggnog = reader.ReadSingle();
						PresentFruitcakeChakram = reader.ReadSingle();
						PresentGingerbreadCookie = reader.ReadSingle();
						PresentGreenCandyCaneBlock = reader.ReadSingle();
						PresentHandWarmer = reader.ReadSingle();
						PresentHardmodeSnowGlobe = reader.ReadSingle();
						PresentHolly = reader.ReadSingle();
						PresentMrsClausCostume = reader.ReadSingle();
						PresentParkaOutfit = reader.ReadSingle();
						PresentPineTreeBlock = reader.ReadSingle();
						PresentRedRyderPlusMusketBall = reader.ReadSingle();
						PresentReindeerAntlers = reader.ReadSingle();
						PresentSnowHat = reader.ReadSingle();
						PresentStarAnise = reader.ReadSingle();
						PresentSugarCookie = reader.ReadSingle();
						PresentToolbox = reader.ReadSingle();
						PresentTreeCostume = reader.ReadSingle();
						PresentUglySweater = reader.ReadSingle();
						
						LootBookofSkullsIncrease = reader.ReadSingle();
						LootPicksawIncrease = reader.ReadSingle();
						LootSeedlingIncrease = reader.ReadSingle();
						LootSkeletronBoneKey = reader.ReadSingle();
						LootBinocularsIncrease = reader.ReadSingle();
						LootBoneRattleIncrease = reader.ReadSingle();
						LootBossMaskIncrease = reader.ReadSingle();
						LootBossTrophyIncrease = reader.ReadSingle();
						LootEatersBoneIncrease = reader.ReadSingle();
						LootFishronTruffleworm = reader.ReadSingle();
						LootFishronWingsIncrease = reader.ReadSingle();
						LootHoneyedGogglesIncrease = reader.ReadSingle();
						LootNectarIncrease = reader.ReadSingle();
						LootTheAxeIncrease = reader.ReadSingle();
						
						BiomeKeyIncreaseForOneMechBossDown = reader.ReadSingle();
						BiomeKeyIncreaseForTwoMechBossDown = reader.ReadSingle();
						BiomeKeyIncreaseForThreeMechBossDown = reader.ReadSingle();
						
						AllEnemiesLootBiomeMatchingFoundOnlyChestDrop = reader.ReadSingle();
						HellBatLootMagmaStoneIncrease = reader.ReadSingle();
						LavaBatLootMagmaStoneIncrease = reader.ReadSingle();
						LootAdhesiveBandageIncrease = reader.ReadSingle();
						LootAleTosser = reader.ReadSingle();
						LootAmarokIncrease = reader.ReadSingle();
						LootAncientClothIncrease = reader.ReadSingle();
						LootAncientCobaltBreastplateIncrease = reader.ReadSingle();
						LootAncientCobaltHelmetIncrease = reader.ReadSingle();
						LootAncientCobaltLeggingsIncrease = reader.ReadSingle();
						LootAncientGoldHelmetIncrease = reader.ReadSingle();
						LootAncientHornIncrease = reader.ReadSingle();
						LootAncientIronHelmetIncrease = reader.ReadSingle();
						LootAncientNecroHelmetIncrease = reader.ReadSingle();
						LootAncientShadowGreavesIncrease = reader.ReadSingle();
						LootAncientShadowHelmetIncrease = reader.ReadSingle();
						LootAncientShadowScalemailIncrease = reader.ReadSingle();
						LootAnkhCharmMaterialIncreasePerAnkhCharmInInventory = reader.ReadSingle();
						LootArmorPolishIncrease = reader.ReadSingle();
						LootBabyGrinchsMischiefWhistleIncrease = reader.ReadSingle();
						LootBananarangIncrease = reader.ReadSingle();
						LootBeamSwordIncrease = reader.ReadSingle();
						LootBezoarIncrease = reader.ReadSingle();
						LootBlackBeltIncrease = reader.ReadSingle();
						LootBlackLensIncrease = reader.ReadSingle();
						LootBlessedAppleIncrease = reader.ReadSingle();
						LootBlindfoldIncrease = reader.ReadSingle();
						LootBloodyMacheteAndBladedGlovesIncrease = reader.ReadSingle();
						LootBoneFeatherIncrease = reader.ReadSingle();
						LootBonePickaxeIncrease = reader.ReadSingle();
						LootBoneSwordIncrease = reader.ReadSingle();
						LootBoneWandIncrease = reader.ReadSingle();
						LootBrainScramblerIncrease = reader.ReadSingle();
						LootBrokenBatWingIncrease = reader.ReadSingle();
						LootBunnyHoodIncrease = reader.ReadSingle();
						LootCascadeIncrease = reader.ReadSingle();
						LootChainGuillotinesIncrease = reader.ReadSingle();
						LootChainKnifeIncrease = reader.ReadSingle();
						LootClassyCane = reader.ReadSingle();
						LootClingerStaffIncrease = reader.ReadSingle();
						LootClothierVoodooDollIncrease = reader.ReadSingle();
						LootCompassIncrease = reader.ReadSingle();
						LootCrossNecklaceIncrease = reader.ReadSingle();
						LootCrystalVileShardIncrease = reader.ReadSingle();
						LootDaedalusStormbowIncrease = reader.ReadSingle();
						LootDarkShardIncrease = reader.ReadSingle();
						LootDartPistolIncrease = reader.ReadSingle();
						LootDartRifleIncrease = reader.ReadSingle();
						LootDeathSickleIncrease = reader.ReadSingle();
						LootDemonScytheIncrease = reader.ReadSingle();
						LootDepthMeterIncrease = reader.ReadSingle();
						LootDesertSpiritLampIncrease = reader.ReadSingle();
						LootDivingHelmetIncrease = reader.ReadSingle();
						LootDualHookIncrease = reader.ReadSingle();
						LootElfHatIncrease = reader.ReadSingle();
						LootElfPantsIncrease = reader.ReadSingle();
						LootElfShirtIncrease = reader.ReadSingle();
						LootEskimoCoatIncrease = reader.ReadSingle();
						LootEskimoHoodIncrease = reader.ReadSingle();
						LootEskimoPantsIncrease = reader.ReadSingle();
						LootExoticScimitar = reader.ReadSingle();
						LootEyePatchIncrease = reader.ReadSingle();
						LootEyeSpringIncrease = reader.ReadSingle();
						LootFastClockBaseIncrease = reader.ReadSingle();
						LootFestiveWingsIncrease = reader.ReadSingle();
						LootFetidBaghnakhsIncrease = reader.ReadSingle();
						LootFireFeatherIncrease = reader.ReadSingle();
						LootFleshKnucklesIncrease = reader.ReadSingle();
						LootFlyingKnifeIncrease = reader.ReadSingle();
						LootFrostStaffIncrease = reader.ReadSingle();
						LootFrozenTurtleShellIncrease = reader.ReadSingle();
						LootGiantBowIncrease = reader.ReadSingle();
						LootGiantHarpyFeatherIncrease = reader.ReadSingle();
						LootGoldenFurnitureIncrease = reader.ReadSingle();
						LootGoldenKeyIncrease = reader.ReadSingle();
						LootGoodieBagIncrease = reader.ReadSingle();
						LootGreenCap = reader.ReadSingle();
						LootHappyGrenade = reader.ReadSingle();
						LootHarpoonIncrease = reader.ReadSingle();
						LootHelFireIncrease = reader.ReadSingle();
						LootHookIncrease = reader.ReadSingle();
						LootIceSickleIncrease = reader.ReadSingle();
						LootIlluminantHookIncrease = reader.ReadSingle();
						LootJellyfishNecklaceIncrease = reader.ReadSingle();
						LootKOCannonIncrease = reader.ReadSingle();
						LootKeybrandIncrease = reader.ReadSingle();
						LootKrakenIncrease = reader.ReadSingle();
						LootLamiaClothesIncrease = reader.ReadSingle();
						LootLifeDrainIncrease = reader.ReadSingle();
						LootLightShardIncrease = reader.ReadSingle();
						LootLihzahrdPowerCellIncrease = reader.ReadSingle();
						LootLivingFireBlockIncrease = reader.ReadSingle();
						LootLizardEggIncrease = reader.ReadSingle();
						LootMagicDaggerIncrease = reader.ReadSingle();
						LootMagicQuiverIncrease = reader.ReadSingle();
						LootMagnetSphereIncrease = reader.ReadSingle();
						LootMandibleBladeIncrease = reader.ReadSingle();
						LootMarrowIncrease = reader.ReadSingle();
						LootMeatGrinderIncrease = reader.ReadSingle();
						LootMegaphoneBaseIncrease = reader.ReadSingle();
						LootMeteoriteIncrease = reader.ReadSingle();
						LootMiningHelmetIncrease = reader.ReadSingle();
						LootMiningPantsIncrease = reader.ReadSingle();
						LootMiningShirtIncrease = reader.ReadSingle();
						LootMoneyTroughIncrease = reader.ReadSingle();
						LootMoonCharmIncrease = reader.ReadSingle();
						LootMoonMaskIncrease = reader.ReadSingle();
						LootMoonStoneIncrease = reader.ReadSingle();
						LootMothronWingsIncrease = reader.ReadSingle();
						LootMummyCostumeIncrease = reader.ReadSingle();
						LootNazarIncrease = reader.ReadSingle();
						LootNimbusRodIncrease = reader.ReadSingle();
						LootObsidianRoseIncrease = reader.ReadSingle();
						LootPaintballGun = reader.ReadSingle();
						LootPaladinsShieldIncrease = reader.ReadSingle();
						LootPedguinssuitIncrease = reader.ReadSingle();
						LootPhilosophersStoneIncrease = reader.ReadSingle();
						LootPirateMapIncrease = reader.ReadSingle();
						LootPlumbersHatIncrease = reader.ReadSingle();
						LootPocketMirrorIncrease = reader.ReadSingle();
						LootPresentIncrease = reader.ReadSingle();
						LootPsychoKnifeIncrease = reader.ReadSingle();
						LootPutridScentIncrease = reader.ReadSingle();
						LootRainArmorIncrease = reader.ReadSingle();
						LootRainbowBlockDropMaxIncrease = reader.ReadInt32();
						LootRainbowBlockDropMinIncrease = reader.ReadInt32();
						LootRallyIncrease = reader.ReadSingle();
						LootReindeerBellsIncrease = reader.ReadSingle();
						LootRifleScopeIncrease = reader.ReadSingle();
						LootRobotHatIncrease = reader.ReadSingle();
						LootRocketLauncherIncrease = reader.ReadSingle();
						LootRodofDiscordIncrease = reader.ReadSingle();
						LootSWATHelmetIncrease = reader.ReadSingle();
						LootSailorHatIncrease = reader.ReadSingle();
						LootSailorPantsIncrease = reader.ReadSingle();
						LootSailorShirtIncrease = reader.ReadSingle();
						LootShackleIncrease = reader.ReadSingle();
						LootSkullIncrease = reader.ReadSingle();
						LootSlimeStaffIncrease = reader.ReadSingle();
						LootSniperRifleIncrease = reader.ReadSingle();
						LootSnowballLauncherIncrease = reader.ReadSingle();
						LootSoulofLightIncrease = reader.ReadSingle();
						LootSoulofNightIncrease = reader.ReadSingle();
						LootStarCloakIncrease = reader.ReadSingle();
						LootStylishScissors = reader.ReadSingle();
						LootSunMaskIncrease = reader.ReadSingle();
						LootTabiIncrease = reader.ReadSingle();
						LootTacticalShotgunIncrease = reader.ReadSingle();
						LootTallyCounterIncrease = reader.ReadSingle();
						LootTatteredBeeWingIncrease = reader.ReadSingle();
						LootTendonHookIncrease = reader.ReadSingle();
						LootTitanGloveIncrease = reader.ReadSingle();
						LootToySledIncrease = reader.ReadSingle();
						LootTrifoldMapIncrease = reader.ReadSingle();
						LootTurtleShellIncrease = reader.ReadSingle();
						LootUmbrellaHatIncrease = reader.ReadSingle();
						LootUnicornonaStickIncrease = reader.ReadSingle();
						LootUziIncrease = reader.ReadSingle();
						LootVikingHelmetIncrease = reader.ReadSingle();
						LootVitaminsIncrease = reader.ReadSingle();
						LootWhoopieCushionIncrease = reader.ReadSingle();
						LootWispinaBottleIncrease = reader.ReadSingle();
						LootWormHookIncrease = reader.ReadSingle();
						LootYeletsIncrease = reader.ReadSingle();
						LootZombieArmIncrease = reader.ReadSingle();
						PirateLootCoinGunBaseIncrease = reader.ReadSingle();
						PirateLootCutlassBaseIncrease = reader.ReadSingle();
						PirateLootDiscountCardBaseIncrease = reader.ReadSingle();
						PirateLootGoldRingBaseIncrease = reader.ReadSingle();
						PirateLootLuckyCoinBaseIncrease = reader.ReadSingle();
						PirateLootPirateStaffBaseIncrease = reader.ReadSingle();
						LootBloodyMacheteAndBladedGlovesAreNotLimitedByDamageAndDefense = reader.ReadBoolean();
						SlimeStaffIncreaseToSurfaceSlimes = reader.ReadBoolean();
						SlimeStaffIncreaseToUndergroundSlimes = reader.ReadBoolean();
						SlimeStaffIncreaseToCavernSlimess = reader.ReadBoolean();
						SlimeStaffIncreaseToIceSpikedSlimes = reader.ReadBoolean();
						SlimeStaffIncreaseToSpikedJungleSlimes = reader.ReadBoolean();

						CavernModdedCavernLockBoxLoot = reader.ReadSingle();
						DungeonModdedBiomeLockBoxLoot = reader.ReadSingle();
						DungeonFurnitureLockBoxLoot = reader.ReadSingle();
						HardmodeModdedLockBoxDropRateModifier = reader.ReadSingle();
						HellBiomeModdedShadowLockBoxLoot = reader.ReadSingle();
						JungleTempleLihzahrd_Lock_Box = reader.ReadSingle();
						NormalmodeModdedLockBoxDropRateModifier = reader.ReadSingle();
						SandstormAndUndergroundDesertPyramidLockBoxLoot = reader.ReadSingle();
						SkyModdedSkywareLockBoxLoot = reader.ReadSingle();
						SpiderNestWebCoveredLockBoxLoot = reader.ReadSingle();
						SurfaceModdedLivingWoodLockBoxLoot = reader.ReadSingle();
						UndergroundJungleBiomeModdedIvyLockBoxLoot = reader.ReadSingle();
						UndergroundSnowBiomeModdedIceLockBoxLoot = reader.ReadSingle();
						WaterEnemyModdedWaterLockBoxLoot = reader.ReadSingle();
						
						TravelingMerchantAcornsIncrease = reader.ReadSingle();
						TravelingMerchantAmmoBoxIncrease = reader.ReadSingle();
						TravelingMerchantAngelHaloIncrease = reader.ReadSingle();
						TravelingMerchantArcaneRuneWallIncrease = reader.ReadSingle();
						TravelingMerchantBlackCounterweightIncrease = reader.ReadSingle();
						TravelingMerchantBlueDynastyShinglesIncrease = reader.ReadSingle();
						TravelingMerchantBlueTeamBlockIncrease = reader.ReadSingle();
						TravelingMerchantBlueTeamPlatformIncrease = reader.ReadSingle();
						TravelingMerchantBrickLayerIncrease = reader.ReadSingle();
						TravelingMerchantCastleMarsbergIncrease = reader.ReadSingle();
						TravelingMerchantCelestialMagnetIncrease = reader.ReadSingle();
						TravelingMerchantChaliceIncrease = reader.ReadSingle();
						TravelingMerchantCode1Increase = reader.ReadSingle();
						TravelingMerchantCode2Increase = reader.ReadSingle();
						TravelingMerchantColdSnapIncrease = reader.ReadSingle();
						TravelingMerchantCompanionCubeIncrease = reader.ReadSingle();
						TravelingMerchantCrimsonCapeIncrease = reader.ReadSingle();
						TravelingMerchantCursedSaintIncrease = reader.ReadSingle();
						TravelingMerchantDPSMeterIncrease = reader.ReadSingle();
						TravelingMerchantDiamondRingIncrease = reader.ReadSingle();
						TravelingMerchantDynastyWoodIncrease = reader.ReadSingle();
						TravelingMerchantExtendoGripIncrease = reader.ReadSingle();
						TravelingMerchantFancyDishesIncrease = reader.ReadSingle();
						TravelingMerchantFezIncrease = reader.ReadSingle();
						TravelingMerchantGatligatorIncrease = reader.ReadSingle();
						TravelingMerchantGiIncrease = reader.ReadSingle();
						TravelingMerchantGreenTeamBlockIncrease = reader.ReadSingle();
						TravelingMerchantGreenTeamPlatformIncrease = reader.ReadSingle();
						TravelingMerchantGypsyRobeIncrease = reader.ReadSingle();
						TravelingMerchantKatanaIncrease = reader.ReadSingle();
						TravelingMerchantKimonoIncrease = reader.ReadSingle();
						TravelingMerchantLeopardSkinIncrease = reader.ReadSingle();
						TravelingMerchantLifeformAnalyzerIncrease = reader.ReadSingle();
						TravelingMerchantMagicHatIncrease = reader.ReadSingle();
						TravelingMerchantMartiaLisaIncrease = reader.ReadSingle();
						TravelingMerchantMetalDetector = reader.ReadSingle();
						TravelingMerchantMysteriousCapeIncrease = reader.ReadSingle();
						TravelingMerchantNotAKidNorASquidIncrease = reader.ReadSingle();
						TravelingMerchantPadThaiIncrease = reader.ReadSingle();
						TravelingMerchantPaintSprayerIncrease = reader.ReadSingle();
						TravelingMerchantPhoIncrease = reader.ReadSingle();
						TravelingMerchantPinkTeamBlockIncrease = reader.ReadSingle();
						TravelingMerchantPinkTeamPlatformIncrease = reader.ReadSingle();
						TravelingMerchantPortableCementMixerIncrease = reader.ReadSingle();
						TravelingMerchantPresseratorIncrease = reader.ReadSingle();
						TravelingMerchantPulseBowIncrease = reader.ReadSingle();
						TravelingMerchantRedCapeIncrease = reader.ReadSingle();
						TravelingMerchantRedDynastyShinglesIncrease = reader.ReadSingle();
						TravelingMerchantRedTeamBlockIncrease = reader.ReadSingle();
						TravelingMerchantRedTeamPlatformIncrease = reader.ReadSingle();
						TravelingMerchantRevolverIncrease = reader.ReadSingle();
						TravelingMerchantSakeIncrease = reader.ReadSingle();
						TravelingMerchantSittingDucksFishingPoleIncrease = reader.ReadSingle();
						TravelingMerchantSnowfellasIncrease = reader.ReadSingle();
						TravelingMerchantStopwatchIncrease = reader.ReadSingle();
						TravelingMerchantTheSeasonIncrease = reader.ReadSingle();
						TravelingMerchantTheTruthIsUpThereIncrease = reader.ReadSingle();
						TravelingMerchantTigerSkinIncrease = reader.ReadSingle();
						TravelingMerchantUltraBrightTorchIncrease = reader.ReadSingle();
						TravelingMerchantWaterGunIncrease = reader.ReadSingle();
						TravelingMerchantWhiteTeamBlockIncrease = reader.ReadSingle();
						TravelingMerchantWhiteTeamPlatformIncrease = reader.ReadSingle();
						TravelingMerchantWinterCapeIncrease = reader.ReadSingle();
						TravelingMerchantYellowCounterweightIncrease = reader.ReadSingle();
						TravelingMerchantYellowTeamBlockIncrease = reader.ReadSingle();
						TravelingMerchantYellowTeamPlatformIncrease = reader.ReadSingle();
						TravelingMerchantZebraSkinIncrease = reader.ReadSingle();
						TravelingMerchantAlwaysXMasForConfigurations = reader.ReadBoolean();
						ChanceThatEnemyKillWillResetTravelingMerchant = reader.ReadSingle();
						StationaryMerchant = reader.ReadBoolean();
						StationaryMerchantStockingChance = reader.ReadSingle();
						S_MerchantStockingChanceBonusWhichWillBeMultipliedByH_ModeCompletionRate = reader.ReadSingle();
						
						QuestAnglerEarringIncrease = reader.ReadSingle();
						QuestAnglerHatIncrease = reader.ReadSingle();
						QuestAnglerPantsIncrease = reader.ReadSingle();
						QuestAnglerVestIncrease = reader.ReadSingle();
						QuestCoralstoneBlockIncrease = reader.ReadSingle();
						QuestDecorativeFurnitureIncrease = reader.ReadSingle();
						QuestFishCostumeIncrease = reader.ReadSingle();
						QuestFishHookIncrease = reader.ReadSingle();
						QuestFishermansGuideIncrease = reader.ReadSingle();
						QuestGoldenBugNetIncrease = reader.ReadSingle();
						QuestGoldenFishingRodIncrease = reader.ReadSingle();
						QuestHardcoreBottomlessBucketIncrease = reader.ReadSingle();
						QuestHardcoreFinWingsIncrease = reader.ReadSingle();
						QuestHardcoreHotlineFishingHookIncrease = reader.ReadSingle();
						QuestHardcoreSuperAbsorbantSpongeIncrease = reader.ReadSingle();
						QuestHighTestFishingLineIncrease = reader.ReadSingle();
						QuestMermaidCostumeIncrease = reader.ReadSingle();
						QuestSextantIncrease = reader.ReadSingle();
						QuestTackleBoxIncrease = reader.ReadSingle();
						QuestTrophyIncrease = reader.ReadSingle();
						QuestWeatherRadioIncrease = reader.ReadSingle();
						
						ChestSalesmanPreHardmodeChestsRequireHardmodeActivated = reader.ReadBoolean();
						ChestSalesmanSellsBiomeChests = reader.ReadBoolean();
						ChestSalesmanSellsGoldChest = reader.ReadBoolean();
						ChestSalesmanSellsIceChest = reader.ReadBoolean();
						ChestSalesmanSellsIvyChest = reader.ReadBoolean();
						ChestSalesmanSellsLihzahrdChest = reader.ReadBoolean();
						ChestSalesmanSellsLivingWoodChest = reader.ReadBoolean();
						ChestSalesmanSellsOceanChest = reader.ReadBoolean();
						ChestSalesmanSellsShadowChest = reader.ReadBoolean();
						ChestSalesmanSellsSkywareChest = reader.ReadBoolean();
						ChestSalesmanSellsWebCoveredChest = reader.ReadBoolean();
						ChestSalesmanSpawnable = reader.ReadBoolean();
						
						MechanicSellsDartTrapAfterSkeletronDefeated = reader.ReadBoolean();
						MechanicSellsGeyserAfterWallofFleshDefeated = reader.ReadBoolean();
						MechanicSellsLihzahrdTrapsAfterGolemDefeated = reader.ReadBoolean();
						MechanicSellsWoodenSpikesAfterGolemDefeated = reader.ReadBoolean();
						MerchantSellsAllMiningGear = reader.ReadBoolean();
						MerchantSellsBlizzardInABottleWhenInSnow = reader.ReadBoolean();
						MerchantSellsCloudInABottleWhenInSky = reader.ReadBoolean();
						MerchantSellsFishItem = reader.ReadBoolean();
						MerchantSellsPyramidItems = reader.ReadBoolean();
						MerchantSellsSandstormInABottleWhenInDesert = reader.ReadBoolean();
						WitchDoctorSellsFlowerBoots = reader.ReadBoolean();
						WitchDoctorSellsHoneyDispenser = reader.ReadBoolean();
						WitchDoctorSellsSeaweed = reader.ReadBoolean();
						WitchDoctorSellsStaffofRegrowth = reader.ReadBoolean();
						TaxCollectorMinTaxRequiredToChatTaxEachMorningAndNight = reader.ReadInt32();
						
						GoblinTinkererSellsGoblinRetreatOrder = reader.ReadBoolean();
						MerchantSellsExpertChangePotion = reader.ReadBoolean();
						PirateSellsPirateRetreatOrder = reader.ReadBoolean();
						WizardSellsMoonBall = reader.ReadBoolean();
						BattlePotionMaxSpawnsMultiplier = reader.ReadSingle();
						BattlePotionSpawnrateMultiplier = reader.ReadSingle();
						BloodZombieAndDripplerDropsBloodMoonMedallion = reader.ReadSingle();
						ChaosPotionMaxSpawnsMultiplier = reader.ReadSingle();
						ChaosPotionSpawnrateMultiplier = reader.ReadSingle();
						WarPotionMaxSpawnsMultiplier = reader.ReadSingle();
						WarPotionSpawnrateMultiplier = reader.ReadSingle();
						
						NewCharacterBarrels = reader.ReadInt32();
						NewCharacterCopperBars = reader.ReadInt32();
						NewCharacterCopperCoins = reader.ReadInt32();
						NewCharacterGoldBars = reader.ReadInt32();
						NewCharacterGoldCoins = reader.ReadInt32();
						NewCharacterIronBars = reader.ReadInt32();
						NewCharacterMiningPotions = reader.ReadInt32();
						NewCharacterPlatinumCoins = reader.ReadInt32();
						NewCharacterSilverBars = reader.ReadInt32();
						NewCharacterSilverCoins = reader.ReadInt32();
						NewCharacterWarPotions = reader.ReadInt32();

						ExtractinatorGivesAmber = reader.ReadSingle();
						ExtractinatorGivesAmberMosquito = reader.ReadSingle();
						ExtractinatorGivesAmethyst = reader.ReadSingle();
						ExtractinatorGivesCopperCoin = reader.ReadSingle();
						ExtractinatorGivesCopperOre = reader.ReadSingle();
						ExtractinatorGivesDiamond = reader.ReadSingle();
						ExtractinatorGivesEmerald = reader.ReadSingle();
						ExtractinatorGivesFossilOre = reader.ReadSingle();
						ExtractinatorGivesGoldCoin = reader.ReadSingle();
						ExtractinatorGivesGoldOre = reader.ReadSingle();
						ExtractinatorGivesIronOre = reader.ReadSingle();
						ExtractinatorGivesLeadOre = reader.ReadSingle();
						ExtractinatorGivesPlatinumCoin = reader.ReadSingle();
						ExtractinatorGivesPlatinumOre = reader.ReadSingle();
						ExtractinatorGivesRuby = reader.ReadSingle();
						ExtractinatorGivesSapphire = reader.ReadSingle();
						ExtractinatorGivesSilverCoin = reader.ReadSingle();
						ExtractinatorGivesSilverOre = reader.ReadSingle();
						ExtractinatorGivesTinOre = reader.ReadSingle();
						ExtractinatorGivesTopaz = reader.ReadSingle();
						ExtractinatorGivesTungstenOre = reader.ReadSingle();
						
						CrateUpgradesDependingOnFishingPower = reader.ReadBoolean();
						FishCatchBecomesBalloonPufferfish = reader.ReadSingle();
						FishCatchBecomesBladetongue = reader.ReadSingle();
						FishCatchBecomesBlueJellyfish = reader.ReadSingle();
						FishCatchBecomesChaosFish = reader.ReadSingle();
						FishCatchBecomesCorruptCrate = reader.ReadSingle();
						FishCatchBecomesCrimsonCrate = reader.ReadSingle();
						FishCatchBecomesCrystalSerpent = reader.ReadSingle();
						FishCatchBecomesDungeonCrate = reader.ReadSingle();
						FishCatchBecomesFrogLeg = reader.ReadSingle();
						FishCatchBecomesFrostDaggerfish = reader.ReadSingle();
						FishCatchBecomesGoldenCarp = reader.ReadSingle();
						FishCatchBecomesGoldenCrate = reader.ReadSingle();
						FishCatchBecomesGreenJellyfish = reader.ReadSingle();
						FishCatchBecomesHallowedCrate = reader.ReadSingle();
						FishCatchBecomesIronCrate = reader.ReadSingle();
						FishCatchBecomesJungleCrate = reader.ReadSingle();
						FishCatchBecomesPinkJellyfish = reader.ReadSingle();
						FishCatchBecomesPurpleClubberfish = reader.ReadSingle();
						FishCatchBecomesReaverSharkAfterAllMechBossesDowned = reader.ReadSingle();
						FishCatchBecomesReaverSharkAfterEyeOfCthulhuEaterOfWorldsAndSkeletronDowned = reader.ReadSingle();
						FishCatchBecomesReaverSharkBeforeEyeOfCthulhuEaterOfWorldsAndSkeletronDowned = reader.ReadSingle();
						FishCatchBecomesRockfish = reader.ReadSingle();
						FishCatchBecomesSawtoothSharkAfterAllMechBossesDowned = reader.ReadSingle();
						FishCatchBecomesSawtoothSharkAfterEyeOfCthulhuEaterOfWorldsAndSkeletronDowned = reader.ReadSingle();
						FishCatchBecomesSawtoothSharkBeforeEyeOfCthulhuEaterOfWorldsAndSkeletronDowned = reader.ReadSingle();
						FishCatchBecomesScalyTruffle = reader.ReadSingle();
						FishCatchBecomesSkyCrate = reader.ReadSingle();
						FishCatchBecomesSwordfish = reader.ReadSingle();
						FishCatchBecomesToxikarp = reader.ReadSingle();
						FishCatchBecomesWoodenCrate = reader.ReadSingle();
						FishCatchBecomesZephyrFish = reader.ReadSingle();
									
						
						
                        mPlayer = Main.player[playernumber].GetModPlayer<ReducedGrindingPlayer>();
                        mPlayer.clientConf = new ReducedGrindingPlayer.ClientConf(
							DropTriesForAllEnemyDroppedLoot,
							NormalModeLootMultiplierForLootWithSeperateDifficultyRates,
							
							CrateDungeonBoneWelder,
							CrateEnchantedSundialGoldenIncrease,
							CrateEnchantedSundialIronIncrease,
							CrateEnchantedSundialWoodenIncrease,
							CrateJungleAnkeltOfTheWindIncrease,
							CrateJungleFeralClawsIncrease,
							CrateJungleFlowerBoots,
							CrateJungleLeafWand,
							CrateJungleLivingLoom,
							CrateJungleLivingMahoganyWand,
							CrateJungleLivingWoodWand,
							CrateJungleRichMahoganyLeafWand,
							CrateJungleSeaweed,
							CrateJungleStaffOfRegrowth,
							CrateSkySkyMill,
							CrateFlippersGolden,
							CrateFlippersIron,
							CrateFlippersWooden,
							CrateWaterWalkingBootsGolden,
							CrateWaterWalkingBootsIron,
							CrateWaterWalkingBootsWooden,
							CrateWoodenAgletIncrease,
							CrateWoodenClimbingClawsIncrease,
							CrateWoodenRadarIncrease,
							PresentCandyCaneBlock,
							PresentCandyCaneHook,
							PresentCandyCanePickaxe,
							PresentCandyCaneSword,
							PresentChristmasPudding,
							PresentCoal,
							PresentDogWhistle,
							PresentEggnog,
							PresentFruitcakeChakram,
							PresentGingerbreadCookie,
							PresentGreenCandyCaneBlock,
							PresentHandWarmer,
							PresentHardmodeSnowGlobe,
							PresentHolly,
							PresentMrsClausCostume,
							PresentParkaOutfit,
							PresentPineTreeBlock,
							PresentRedRyderPlusMusketBall,
							PresentReindeerAntlers,
							PresentSnowHat,
							PresentStarAnise,
							PresentSugarCookie,
							PresentToolbox ,
							PresentTreeCostume,
							PresentUglySweater,
							
							LootBookofSkullsIncrease,
							LootPicksawIncrease,
							LootSeedlingIncrease,
							LootSkeletronBoneKey,
							LootBinocularsIncrease,
							LootBoneRattleIncrease,
							LootBossMaskIncrease,
							LootBossTrophyIncrease,
							LootEatersBoneIncrease,
							LootFishronTruffleworm,
							LootFishronWingsIncrease,
							LootHoneyedGogglesIncrease,
							LootNectarIncrease,
							LootTheAxeIncrease,
							
							BiomeKeyIncreaseForOneMechBossDown,
							BiomeKeyIncreaseForTwoMechBossDown,
							BiomeKeyIncreaseForThreeMechBossDown,
							
							AllEnemiesLootBiomeMatchingFoundOnlyChestDrop,
							HellBatLootMagmaStoneIncrease,
							LavaBatLootMagmaStoneIncrease,
							LootAdhesiveBandageIncrease,
							LootAleTosser,
							LootAmarokIncrease,
							LootAncientClothIncrease,
							LootAncientCobaltBreastplateIncrease,
							LootAncientCobaltHelmetIncrease,
							LootAncientCobaltLeggingsIncrease,
							LootAncientGoldHelmetIncrease,
							LootAncientHornIncrease,
							LootAncientIronHelmetIncrease,
							LootAncientNecroHelmetIncrease,
							LootAncientShadowGreavesIncrease,
							LootAncientShadowHelmetIncrease,
							LootAncientShadowScalemailIncrease,
							LootAnkhCharmMaterialIncreasePerAnkhCharmInInventory,
							LootArmorPolishIncrease,
							LootBabyGrinchsMischiefWhistleIncrease,
							LootBananarangIncrease,
							LootBeamSwordIncrease,
							LootBezoarIncrease,
							LootBlackBeltIncrease,
							LootBlackLensIncrease,
							LootBlessedAppleIncrease,
							LootBlindfoldIncrease,
							LootBloodyMacheteAndBladedGlovesIncrease,
							LootBoneFeatherIncrease,
							LootBonePickaxeIncrease,
							LootBoneSwordIncrease,
							LootBoneWandIncrease,
							LootBrainScramblerIncrease,
							LootBrokenBatWingIncrease,
							LootBunnyHoodIncrease,
							LootCascadeIncrease,
							LootChainGuillotinesIncrease,
							LootChainKnifeIncrease,
							LootClassyCane,
							LootClingerStaffIncrease,
							LootClothierVoodooDollIncrease,
							LootCompassIncrease,
							LootCrossNecklaceIncrease,
							LootCrystalVileShardIncrease,
							LootDaedalusStormbowIncrease,
							LootDarkShardIncrease,
							LootDartPistolIncrease,
							LootDartRifleIncrease,
							LootDeathSickleIncrease,
							LootDemonScytheIncrease,
							LootDepthMeterIncrease,
							LootDesertSpiritLampIncrease,
							LootDivingHelmetIncrease,
							LootDualHookIncrease,
							LootElfHatIncrease,
							LootElfPantsIncrease,
							LootElfShirtIncrease,
							LootEskimoCoatIncrease,
							LootEskimoHoodIncrease,
							LootEskimoPantsIncrease,
							LootExoticScimitar,
							LootEyePatchIncrease,
							LootEyeSpringIncrease,
							LootFastClockBaseIncrease,
							LootFestiveWingsIncrease,
							LootFetidBaghnakhsIncrease,
							LootFireFeatherIncrease,
							LootFleshKnucklesIncrease,
							LootFlyingKnifeIncrease,
							LootFrostStaffIncrease,
							LootFrozenTurtleShellIncrease,
							LootGiantBowIncrease,
							LootGiantHarpyFeatherIncrease,
							LootGoldenFurnitureIncrease,
							LootGoldenKeyIncrease,
							LootGoodieBagIncrease,
							LootGreenCap,
							LootHappyGrenade,
							LootHarpoonIncrease,
							LootHelFireIncrease,
							LootHookIncrease,
							LootIceSickleIncrease,
							LootIlluminantHookIncrease,
							LootJellyfishNecklaceIncrease,
							LootKOCannonIncrease,
							LootKeybrandIncrease,
							LootKrakenIncrease,
							LootLamiaClothesIncrease,
							LootLifeDrainIncrease,
							LootLightShardIncrease,
							LootLihzahrdPowerCellIncrease,
							LootLivingFireBlockIncrease,
							LootLizardEggIncrease,
							LootMagicDaggerIncrease,
							LootMagicQuiverIncrease,
							LootMagnetSphereIncrease,
							LootMandibleBladeIncrease,
							LootMarrowIncrease,
							LootMeatGrinderIncrease,
							LootMegaphoneBaseIncrease,
							LootMeteoriteIncrease,
							LootMiningHelmetIncrease,
							LootMiningPantsIncrease,
							LootMiningShirtIncrease,
							LootMoneyTroughIncrease,
							LootMoonCharmIncrease,
							LootMoonMaskIncrease,
							LootMoonStoneIncrease,
							LootMothronWingsIncrease,
							LootMummyCostumeIncrease,
							LootNazarIncrease,
							LootNimbusRodIncrease,
							LootObsidianRoseIncrease,
							LootPaintballGun,
							LootPaladinsShieldIncrease,
							LootPedguinssuitIncrease,
							LootPhilosophersStoneIncrease,
							LootPirateMapIncrease,
							LootPlumbersHatIncrease,
							LootPocketMirrorIncrease,
							LootPresentIncrease,
							LootPsychoKnifeIncrease,
							LootPutridScentIncrease,
							LootRainArmorIncrease,
							LootRainbowBlockDropMaxIncrease,
							LootRainbowBlockDropMinIncrease,
							LootRallyIncrease,
							LootReindeerBellsIncrease,
							LootRifleScopeIncrease,
							LootRobotHatIncrease,
							LootRocketLauncherIncrease,
							LootRodofDiscordIncrease,
							LootSWATHelmetIncrease,
							LootSailorHatIncrease,
							LootSailorPantsIncrease,
							LootSailorShirtIncrease,
							LootShackleIncrease,
							LootSkullIncrease,
							LootSlimeStaffIncrease,
							LootSniperRifleIncrease,
							LootSnowballLauncherIncrease,
							LootSoulofLightIncrease,
							LootSoulofNightIncrease,
							LootStarCloakIncrease,
							LootStylishScissors,
							LootSunMaskIncrease,
							LootTabiIncrease,
							LootTacticalShotgunIncrease,
							LootTallyCounterIncrease,
							LootTatteredBeeWingIncrease,
							LootTendonHookIncrease,
							LootTitanGloveIncrease,
							LootToySledIncrease,
							LootTrifoldMapIncrease,
							LootTurtleShellIncrease,
							LootUmbrellaHatIncrease,
							LootUnicornonaStickIncrease,
							LootUziIncrease,
							LootVikingHelmetIncrease,
							LootVitaminsIncrease,
							LootWhoopieCushionIncrease,
							LootWispinaBottleIncrease,
							LootWormHookIncrease,
							LootYeletsIncrease,
							LootZombieArmIncrease,
							PirateLootCoinGunBaseIncrease,
							PirateLootCutlassBaseIncrease,
							PirateLootDiscountCardBaseIncrease,
							PirateLootGoldRingBaseIncrease,
							PirateLootLuckyCoinBaseIncrease,
							PirateLootPirateStaffBaseIncrease,
							LootBloodyMacheteAndBladedGlovesAreNotLimitedByDamageAndDefense,
							SlimeStaffIncreaseToSurfaceSlimes,
							SlimeStaffIncreaseToUndergroundSlimes,
							SlimeStaffIncreaseToCavernSlimess,
							SlimeStaffIncreaseToIceSpikedSlimes,
							SlimeStaffIncreaseToSpikedJungleSlimes,

							CavernModdedCavernLockBoxLoot,
							DungeonModdedBiomeLockBoxLoot,
							DungeonFurnitureLockBoxLoot,
							HardmodeModdedLockBoxDropRateModifier,
							HellBiomeModdedShadowLockBoxLoot,
							JungleTempleLihzahrd_Lock_Box,
							NormalmodeModdedLockBoxDropRateModifier,
							SandstormAndUndergroundDesertPyramidLockBoxLoot,
							SkyModdedSkywareLockBoxLoot,
							SpiderNestWebCoveredLockBoxLoot,
							SurfaceModdedLivingWoodLockBoxLoot,
							UndergroundJungleBiomeModdedIvyLockBoxLoot,
							UndergroundSnowBiomeModdedIceLockBoxLoot,
							WaterEnemyModdedWaterLockBoxLoot,
							
							TravelingMerchantAcornsIncrease,
							TravelingMerchantAmmoBoxIncrease,
							TravelingMerchantAngelHaloIncrease,
							TravelingMerchantArcaneRuneWallIncrease,
							TravelingMerchantBlackCounterweightIncrease,
							TravelingMerchantBlueDynastyShinglesIncrease,
							TravelingMerchantBlueTeamBlockIncrease,
							TravelingMerchantBlueTeamPlatformIncrease,
							TravelingMerchantBrickLayerIncrease,
							TravelingMerchantCastleMarsbergIncrease,
							TravelingMerchantCelestialMagnetIncrease,
							TravelingMerchantChaliceIncrease,
							TravelingMerchantCode1Increase,
							TravelingMerchantCode2Increase,
							TravelingMerchantColdSnapIncrease,
							TravelingMerchantCompanionCubeIncrease,
							TravelingMerchantCrimsonCapeIncrease,
							TravelingMerchantCursedSaintIncrease,
							TravelingMerchantDPSMeterIncrease,
							TravelingMerchantDiamondRingIncrease,
							TravelingMerchantDynastyWoodIncrease,
							TravelingMerchantExtendoGripIncrease,
							TravelingMerchantFancyDishesIncrease,
							TravelingMerchantFezIncrease,
							TravelingMerchantGatligatorIncrease,
							TravelingMerchantGiIncrease,
							TravelingMerchantGreenTeamBlockIncrease,
							TravelingMerchantGreenTeamPlatformIncrease,
							TravelingMerchantGypsyRobeIncrease,
							TravelingMerchantKatanaIncrease,
							TravelingMerchantKimonoIncrease,
							TravelingMerchantLeopardSkinIncrease,
							TravelingMerchantLifeformAnalyzerIncrease,
							TravelingMerchantMagicHatIncrease,
							TravelingMerchantMartiaLisaIncrease,
							TravelingMerchantMetalDetector,
							TravelingMerchantMysteriousCapeIncrease,
							TravelingMerchantNotAKidNorASquidIncrease,
							TravelingMerchantPadThaiIncrease,
							TravelingMerchantPaintSprayerIncrease,
							TravelingMerchantPhoIncrease,
							TravelingMerchantPinkTeamBlockIncrease,
							TravelingMerchantPinkTeamPlatformIncrease,
							TravelingMerchantPortableCementMixerIncrease,
							TravelingMerchantPresseratorIncrease,
							TravelingMerchantPulseBowIncrease,
							TravelingMerchantRedCapeIncrease,
							TravelingMerchantRedDynastyShinglesIncrease,
							TravelingMerchantRedTeamBlockIncrease,
							TravelingMerchantRedTeamPlatformIncrease,
							TravelingMerchantRevolverIncrease,
							TravelingMerchantSakeIncrease,
							TravelingMerchantSittingDucksFishingPoleIncrease,
							TravelingMerchantSnowfellasIncrease,
							TravelingMerchantStopwatchIncrease,
							TravelingMerchantTheSeasonIncrease,
							TravelingMerchantTheTruthIsUpThereIncrease,
							TravelingMerchantTigerSkinIncrease,
							TravelingMerchantUltraBrightTorchIncrease,
							TravelingMerchantWaterGunIncrease,
							TravelingMerchantWhiteTeamBlockIncrease,
							TravelingMerchantWhiteTeamPlatformIncrease,
							TravelingMerchantWinterCapeIncrease,
							TravelingMerchantYellowCounterweightIncrease,
							TravelingMerchantYellowTeamBlockIncrease,
							TravelingMerchantYellowTeamPlatformIncrease,
							TravelingMerchantZebraSkinIncrease,
							TravelingMerchantAlwaysXMasForConfigurations,
							ChanceThatEnemyKillWillResetTravelingMerchant,
							StationaryMerchant,
							StationaryMerchantStockingChance,
							S_MerchantStockingChanceBonusWhichWillBeMultipliedByH_ModeCompletionRate,
							
							QuestAnglerEarringIncrease,
							QuestAnglerHatIncrease,
							QuestAnglerPantsIncrease,
							QuestAnglerVestIncrease,
							QuestCoralstoneBlockIncrease,
							QuestDecorativeFurnitureIncrease,
							QuestFishCostumeIncrease,
							QuestFishHookIncrease,
							QuestFishermansGuideIncrease,
							QuestGoldenBugNetIncrease,
							QuestGoldenFishingRodIncrease,
							QuestHardcoreBottomlessBucketIncrease,
							QuestHardcoreFinWingsIncrease,
							QuestHardcoreHotlineFishingHookIncrease,
							QuestHardcoreSuperAbsorbantSpongeIncrease,
							QuestHighTestFishingLineIncrease,
							QuestMermaidCostumeIncrease,
							QuestSextantIncrease,
							QuestTackleBoxIncrease,
							QuestTrophyIncrease,
							QuestWeatherRadioIncrease,
							
							ChestSalesmanPreHardmodeChestsRequireHardmodeActivated,
							ChestSalesmanSellsBiomeChests,
							ChestSalesmanSellsGoldChest,
							ChestSalesmanSellsIceChest,
							ChestSalesmanSellsIvyChest,
							ChestSalesmanSellsLihzahrdChest,
							ChestSalesmanSellsLivingWoodChest,
							ChestSalesmanSellsOceanChest,
							ChestSalesmanSellsShadowChest,
							ChestSalesmanSellsSkywareChest,
							ChestSalesmanSellsWebCoveredChest,
							ChestSalesmanSpawnable,
							
							MechanicSellsDartTrapAfterSkeletronDefeated,
							MechanicSellsGeyserAfterWallofFleshDefeated,
							MechanicSellsLihzahrdTrapsAfterGolemDefeated,
							MechanicSellsWoodenSpikesAfterGolemDefeated,
							MerchantSellsAllMiningGear,
							MerchantSellsBlizzardInABottleWhenInSnow,
							MerchantSellsCloudInABottleWhenInSky,
							MerchantSellsFishItem,
							MerchantSellsPyramidItems,
							MerchantSellsSandstormInABottleWhenInDesert,
							WitchDoctorSellsFlowerBoots,
							WitchDoctorSellsHoneyDispenser,
							WitchDoctorSellsSeaweed,
							WitchDoctorSellsStaffofRegrowth,
							TaxCollectorMinTaxRequiredToChatTaxEachMorningAndNight,
							
							GoblinTinkererSellsGoblinRetreatOrder,
							MerchantSellsExpertChangePotion,
							PirateSellsPirateRetreatOrder,
							WizardSellsMoonBall,
							BattlePotionMaxSpawnsMultiplier,
							BattlePotionSpawnrateMultiplier,
							BloodZombieAndDripplerDropsBloodMoonMedallion,
							ChaosPotionMaxSpawnsMultiplier,
							ChaosPotionSpawnrateMultiplier,
							WarPotionMaxSpawnsMultiplier,
							WarPotionSpawnrateMultiplier,
							
							NewCharacterBarrels,
							NewCharacterCopperBars,
							NewCharacterCopperCoins,
							NewCharacterGoldBars,
							NewCharacterGoldCoins,
							NewCharacterIronBars,
							NewCharacterMiningPotions,
							NewCharacterPlatinumCoins,
							NewCharacterSilverBars,
							NewCharacterSilverCoins,
							NewCharacterWarPotions,

							ExtractinatorGivesAmber,
							ExtractinatorGivesAmberMosquito,
							ExtractinatorGivesAmethyst,
							ExtractinatorGivesCopperCoin,
							ExtractinatorGivesCopperOre,
							ExtractinatorGivesDiamond,
							ExtractinatorGivesEmerald,
							ExtractinatorGivesFossilOre,
							ExtractinatorGivesGoldCoin,
							ExtractinatorGivesGoldOre,
							ExtractinatorGivesIronOre,
							ExtractinatorGivesLeadOre,
							ExtractinatorGivesPlatinumCoin,
							ExtractinatorGivesPlatinumOre,
							ExtractinatorGivesRuby,
							ExtractinatorGivesSapphire,
							ExtractinatorGivesSilverCoin,
							ExtractinatorGivesSilverOre,
							ExtractinatorGivesTinOre,
							ExtractinatorGivesTopaz,
							ExtractinatorGivesTungstenOre,
							
							CrateUpgradesDependingOnFishingPower,
							FishCatchBecomesBalloonPufferfish,
							FishCatchBecomesBladetongue,
							FishCatchBecomesBlueJellyfish,
							FishCatchBecomesChaosFish,
							FishCatchBecomesCorruptCrate,
							FishCatchBecomesCrimsonCrate,
							FishCatchBecomesCrystalSerpent,
							FishCatchBecomesDungeonCrate,
							FishCatchBecomesFrogLeg,
							FishCatchBecomesFrostDaggerfish,
							FishCatchBecomesGoldenCarp,
							FishCatchBecomesGoldenCrate,
							FishCatchBecomesGreenJellyfish,
							FishCatchBecomesHallowedCrate,
							FishCatchBecomesIronCrate,
							FishCatchBecomesJungleCrate,
							FishCatchBecomesPinkJellyfish,
							FishCatchBecomesPurpleClubberfish,
							FishCatchBecomesReaverSharkAfterAllMechBossesDowned,
							FishCatchBecomesReaverSharkAfterEyeOfCthulhuEaterOfWorldsAndSkeletronDowned,
							FishCatchBecomesReaverSharkBeforeEyeOfCthulhuEaterOfWorldsAndSkeletronDowned,
							FishCatchBecomesRockfish,
							FishCatchBecomesSawtoothSharkAfterAllMechBossesDowned,
							FishCatchBecomesSawtoothSharkAfterEyeOfCthulhuEaterOfWorldsAndSkeletronDowned,
							FishCatchBecomesSawtoothSharkBeforeEyeOfCthulhuEaterOfWorldsAndSkeletronDowned,
							FishCatchBecomesScalyTruffle,
							FishCatchBecomesSkyCrate,
							FishCatchBecomesSwordfish,
							FishCatchBecomesToxikarp,
							FishCatchBecomesWoodenCrate,
							FishCatchBecomesZephyrFish
						);

                        arrayLength = reader.ReadByte();
                    }
                    break;
                case ReducedGrindingMessageType.SendClientChanges:
                    playernumber = reader.ReadByte();

                    flags1 = reader.ReadByte();        //byte

                    mPlayer = Main.player[playernumber].GetModPlayer<ReducedGrindingPlayer>();
                    if (Main.netMode == NetmodeID.Server)
                    {
                        ModPacket packet = GetPacket();
                        packet.Write((byte)ReducedGrindingMessageType.SendClientChanges);
                        packet.Write(playernumber);
                        packet.Write((byte)flags1);
                        packet.Send(-1, playernumber);
                    }
                    break;
                default:
                    ErrorLogger.Log("ReducedGrinding: Unknown Message type: " + msgType);
                    break;
            }
        }
		
		public class BossBags : GlobalItem  //Rates show in comments are in addition to vanilla rates.
		{
			public override void OpenVanillaBag(string context, Player player, int arg)
			{
				ReducedGrindingPlayer mPlayer = Main.LocalPlayer.GetModPlayer<ReducedGrindingPlayer>(mod);
				
				//Boss Bags
				if (arg == ItemID.BrainOfCthulhuBossBag)
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootBoneRattleIncrease)
					{
						player.QuickSpawnItem(ItemID.BoneRattle, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2104, 1); //Mask
					}
				}
				else if (arg == ItemID.FishronBossBag)
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootFishronWingsIncrease)
					{
						player.QuickSpawnItem(ItemID.FishronWings, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootFishronTruffleworm)
					{
						player.QuickSpawnItem(2673, 1); //Truffleworm
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2588, 1); //Mask
					}
				}
				else if (arg == ItemID.EaterOfWorldsBossBag)
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootEatersBoneIncrease)
					{
						player.QuickSpawnItem(ItemID.EatersBone, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2111, 1); //Mask
					}
				}
				else if (arg == ItemID.EyeOfCthulhuBossBag)
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootBinocularsIncrease)
					{
						player.QuickSpawnItem(ItemID.Binoculars, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2112, 1); //Mask
					}
				}
				else if (arg == ItemID.PlanteraBossBag)
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootTheAxeIncrease)
					{
						player.QuickSpawnItem(ItemID.TheAxe, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootSeedlingIncrease)
					{
						player.QuickSpawnItem(ItemID.Seedling, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2109, 1); //Mask
					}
				}
				else if (arg == ItemID.QueenBeeBossBag)
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootHoneyedGogglesIncrease)
					{
						player.QuickSpawnItem(ItemID.HoneyedGoggles, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootNectarIncrease)
					{
						player.QuickSpawnItem(ItemID.Nectar, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2108, 1); //Mask
					}
				}
				else if (arg == ItemID.SkeletronBossBag)
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootBookofSkullsIncrease)
					{
						player.QuickSpawnItem(ItemID.BookofSkulls, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootSkeletronBoneKey)
					{
						player.QuickSpawnItem(ItemID.BookofSkulls, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(1281, 1); //Mask
					}
				}
				else if (arg == 3318) //King Slime
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2493, 1); //Mask
					}
				}
				else if (arg == 3324) //Wall of Flesh
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2105, 1); //Mask
					}
				}
				else if (arg == 3325) //The Destroyer
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2113, 1); //Mask
					}
				}
				else if (arg == 3326) //The Twins
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2106, 1); //Mask
					}
				}
				else if (arg == 3327) //Skeletron Prime
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2107, 1); //Mask
					}
				}
				else if (arg == 3329) //Golem
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2110, 1); //Mask
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootPicksawIncrease)
					{
						player.QuickSpawnItem(1294, 1); //Picksaw
					}
				}
				else if (arg == 3332) //Moon Lord
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(3373, 1); //Mask
					}
				}
				else if (arg == 3860) //Betsy
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(3863, 1); //Mask
					}
				}
				
				//Crates
				else if (arg == 3205) //Dungeon Crate
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateDungeonBoneWelder)
					{
						player.QuickSpawnItem(2192, 1); //Bone Welder
					}
				}
				else if (arg == ItemID.JungleFishingCrate)
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateJungleSeaweed)
					{
						player.QuickSpawnItem(ItemID.Seaweed, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateJungleFlowerBoots)
					{
						player.QuickSpawnItem(ItemID.FlowerBoots, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateJungleLivingMahoganyWand)
					{
						player.QuickSpawnItem(ItemID.LivingMahoganyWand, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateJungleRichMahoganyLeafWand)
					{
						player.QuickSpawnItem(ItemID.LivingMahoganyLeafWand, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateJungleLivingLoom)
					{
						player.QuickSpawnItem(ItemID.LivingLoom, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateJungleLeafWand)
					{
						player.QuickSpawnItem(ItemID.LeafWand, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateJungleLivingWoodWand)
					{
						player.QuickSpawnItem(ItemID.LivingWoodWand, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateJungleAnkeltOfTheWindIncrease)
					{
						player.QuickSpawnItem(212, 1); //Anklet of the Wind
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateJungleFeralClawsIncrease)
					{
						player.QuickSpawnItem(211, 1); //Feral Claws
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateJungleStaffOfRegrowth)
					{
						player.QuickSpawnItem(213, 1); //Staff Of Regrowth
					}
				}
				else if (arg == 3206) //Sky Crate
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateSkySkyMill)
					{
						player.QuickSpawnItem(2197, 1); //Sky Mill
					}
				}
				else if (arg == ItemID.WoodenCrate)
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateWoodenClimbingClawsIncrease)
					{
						player.QuickSpawnItem(953, 1); //Climbing Claws
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateWoodenRadarIncrease)
					{
						player.QuickSpawnItem(3084, 1); //Radar
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateWoodenAgletIncrease)
					{
						player.QuickSpawnItem(285, 1); //Aglet
					}
				}
				else if (arg == ItemID.WoodenCrate)
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateWaterWalkingBootsWooden)
					{
						player.QuickSpawnItem(863, 1); //Water walking boots
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateFlippersWooden)
					{
						player.QuickSpawnItem(187, 1); //Flipper
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateEnchantedSundialWoodenIncrease)
					{
						player.QuickSpawnItem(3064, 1); //Enchanted Sundial
					}
				}
				else if (arg == ItemID.IronCrate)
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateWaterWalkingBootsIron)
					{
						player.QuickSpawnItem(863, 1); //Water walking boots
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateFlippersIron)
					{
						player.QuickSpawnItem(187, 1); //Flipper
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateEnchantedSundialIronIncrease)
					{
						player.QuickSpawnItem(3064, 1); //Enchanted Sundial
					}
				}
				else if (arg == ItemID.GoldenCrate)
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateWaterWalkingBootsGolden)
					{
						player.QuickSpawnItem(863, 1); //Water walking boots
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateFlippersGolden)
					{
						player.QuickSpawnItem(187, 1); //Flipper
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.CrateEnchantedSundialGoldenIncrease)
					{
						player.QuickSpawnItem(3064, 1); //Enchanted Sundial
					}
				}
				else if (context == "present")
				{
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentDogWhistle)
					{
						player.QuickSpawnItem(1927, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentToolbox)
					{
						player.QuickSpawnItem(1923, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentHandWarmer)
					{
						player.QuickSpawnItem(1921, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentCandyCanePickaxe)
					{
						player.QuickSpawnItem(1917, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentCandyCaneHook)
					{
						player.QuickSpawnItem(1915, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentFruitcakeChakram)
					{
						player.QuickSpawnItem(1918, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentRedRyderPlusMusketBall)
					{
						player.QuickSpawnItem(1870, 1);
						player.QuickSpawnItem(97, Main.rand.Next(30,60));
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentCandyCaneSword)
					{
						player.QuickSpawnItem(1909, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentMrsClausCostume)
					{
						player.QuickSpawnItem(1932, 1);
						player.QuickSpawnItem(1933, 1);
						player.QuickSpawnItem(1934, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentParkaOutfit)
					{
						player.QuickSpawnItem(1935, 1);
						player.QuickSpawnItem(1936, 1);
						player.QuickSpawnItem(1937, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentTreeCostume)
					{
						player.QuickSpawnItem(1940, 1);
						player.QuickSpawnItem(1941, 1);
						player.QuickSpawnItem(1942, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentSnowHat)
					{
						player.QuickSpawnItem(1938, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentUglySweater)
					{
						player.QuickSpawnItem(1939, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentReindeerAntlers)
					{
						player.QuickSpawnItem(1907, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentCoal)
					{
						player.QuickSpawnItem(1922, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentChristmasPudding)
					{
						player.QuickSpawnItem(1911, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentSugarCookie)
					{
						player.QuickSpawnItem(1919, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentGingerbreadCookie)
					{
						player.QuickSpawnItem(1920, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentStarAnise)
					{
						player.QuickSpawnItem(1913, Main.rand.Next(20,40));
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentEggnog)
					{
						player.QuickSpawnItem(1912, Main.rand.Next(1,3));
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentHolly)
					{
						player.QuickSpawnItem(1908, 1);
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentPineTreeBlock)
					{
						player.QuickSpawnItem(1872, Main.rand.Next(20,49));
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentCandyCaneBlock)
					{
						player.QuickSpawnItem(586, Main.rand.Next(20,49));
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentGreenCandyCaneBlock)
					{
						player.QuickSpawnItem(591, Main.rand.Next(20,49));
					}
					if (Main.rand.NextFloat() < mPlayer.clientConf.PresentHardmodeSnowGlobe)
					{
						player.QuickSpawnItem(602, 1);
					}
				}
            }
			
			public override void ExtractinatorUse(int extractType, ref int resultType, ref int resultStack)
			{
				
				ReducedGrindingPlayer mPlayer = Main.LocalPlayer.GetModPlayer<ReducedGrindingPlayer>(mod);
				
				if(extractType == 3347 || extractType == 424 || extractType == 1103)
				{
					float amberMosquitoMultiplier = 3f;
					float gemMultiplier = 1f;
					float amberMultiplier = 2f;
					if (extractType == 3347)
					{
						amberMosquitoMultiplier /= 3;
						gemMultiplier *= 2;
						amberMultiplier /= 2;
					}
					if (Main.rand.NextFloat() * amberMosquitoMultiplier < mPlayer.clientConf.ExtractinatorGivesAmberMosquito)
					{
						resultStack = 1;
						resultType = ItemID.AmberMosquito;
					}
					else if (Main.rand.NextFloat() * gemMultiplier < mPlayer.clientConf.ExtractinatorGivesDiamond)
					{
						resultStack = 1;
						resultType = ItemID.Diamond;
					}
					else if (Main.rand.NextFloat() * gemMultiplier < mPlayer.clientConf.ExtractinatorGivesRuby)
					{
						resultStack = 1;
						resultType = ItemID.Ruby;
					}
					else if (Main.rand.NextFloat() * gemMultiplier < mPlayer.clientConf.ExtractinatorGivesEmerald)
					{
						resultStack = 1;
						resultType = ItemID.Emerald;
					}
					else if (Main.rand.NextFloat() * gemMultiplier < mPlayer.clientConf.ExtractinatorGivesSapphire)
					{
						resultStack = 1;
						resultType = ItemID.Sapphire;
					}
					else if (Main.rand.NextFloat() * gemMultiplier < mPlayer.clientConf.ExtractinatorGivesTopaz)
					{
						resultStack = 1;
						resultType = ItemID.Topaz;
					}
					else if (Main.rand.NextFloat() * gemMultiplier < mPlayer.clientConf.ExtractinatorGivesAmethyst)
					{
						resultStack = 1;
						resultType = ItemID.Amethyst;
					}
					else if (Main.rand.NextFloat() * amberMultiplier < mPlayer.clientConf.ExtractinatorGivesAmber)
					{
						resultStack = 1;
						resultType = ItemID.Amber;
					}
					else if (Main.rand.NextFloat() < mPlayer.clientConf.ExtractinatorGivesGoldOre)
					{
						resultStack = 1;
						resultType = ItemID.GoldOre;
					}
					else if (Main.rand.NextFloat() < mPlayer.clientConf.ExtractinatorGivesPlatinumOre)
					{
						resultStack = 1;
						resultType = ItemID.PlatinumOre;
					}
					else if (Main.rand.NextFloat() < mPlayer.clientConf.ExtractinatorGivesFossilOre && extractType == 3347)
					{
						resultStack = 1;
						resultType = ItemID.FossilOre;
					}
					else if (Main.rand.NextFloat() < mPlayer.clientConf.ExtractinatorGivesSilverOre)
					{
						resultStack = 1;
						resultType = ItemID.SilverOre;
					}
					else if (Main.rand.NextFloat() < mPlayer.clientConf.ExtractinatorGivesTungstenOre)
					{
						resultStack = 1;
						resultType = ItemID.TungstenOre;
					}
					else if (Main.rand.NextFloat() < mPlayer.clientConf.ExtractinatorGivesIronOre)
					{
						resultStack = 1;
						resultType = ItemID.IronOre;
					}
					else if (Main.rand.NextFloat() < mPlayer.clientConf.ExtractinatorGivesLeadOre)
					{
						resultStack = 1;
						resultType = ItemID.LeadOre;
					}
					else if (Main.rand.NextFloat() < mPlayer.clientConf.ExtractinatorGivesCopperOre)
					{
						resultStack = 1;
						resultType = ItemID.CopperOre;
					}
					else if (Main.rand.NextFloat() < mPlayer.clientConf.ExtractinatorGivesTinOre)
					{
						resultStack = 1;
						resultType = ItemID.TinOre;
					}
					else if (Main.rand.NextFloat() < mPlayer.clientConf.ExtractinatorGivesPlatinumCoin)
					{
						resultStack = 1;
						resultType = ItemID.PlatinumCoin;
					}
					else if (Main.rand.NextFloat() < mPlayer.clientConf.ExtractinatorGivesGoldCoin)
					{
						resultStack = 1;
						resultType = ItemID.GoldCoin;
					}
					else if (Main.rand.NextFloat() < mPlayer.clientConf.ExtractinatorGivesSilverCoin)
					{
						resultStack = 1;
						resultType = ItemID.SilverCoin;
					}
					else if (Main.rand.NextFloat() < mPlayer.clientConf.ExtractinatorGivesCopperCoin)
					{
						resultStack = 1;
						resultType = ItemID.CopperCoin;
					}
				}
			}
        }
		
		public class ModGlobalNPC : GlobalNPC
		{
				public override void NPCLoot(NPC npc)
				{
				
				if (npc.type != 46 && npc.type != 74 && npc.type != 297 && npc.type != 298 && npc.type != 299 && npc.type != 300 && npc.type != 355 && npc.type != 357 && npc.type != 358 && npc.type != 359 && npc.type != 360 && npc.type != 361 && npc.type != 366 && npc.type != 367 && npc.type != 377 && npc.type != 442 && npc.type != 443 && npc.type != 445 && npc.type != 446 && npc.type != 447 && npc.type != 448 && npc.type != 484 && npc.type != 485 && npc.type != 486 && npc.type != 487 && npc.type != 538 && npc.type != 539 && npc.type != 55 && npc.type != 230 && npc.type != 148 && npc.type != 149 && npc.type != 362 && npc.type != 363 && npc.type != 364 && npc.type != 365 && npc.type != 374 && npc.type != 375 && npc.type != 356 && npc.type != 444 && npc.type != NPCID.Bee && npc.type != NPCID.BeeSmall && (npc.townNPC == false) && !npc.SpawnedFromStatue)
				{
					ReducedGrindingPlayer mPlayer = Main.LocalPlayer.GetModPlayer<ReducedGrindingPlayer>(mod);
					Player player = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];
					float difficultyMultiplier = 1f;
					if (!Main.expertMode)
						difficultyMultiplier = mPlayer.clientConf.NormalModeLootMultiplierForLootWithSeperateDifficultyRates;
					
					//Biome Keys
					int mechBossesDowned = 0;
					if (Main.hardMode)
					{
						if (NPC.downedMechBoss1)//The Destroyer
						{
							mechBossesDowned += 1;
						}
						if (NPC.downedMechBoss2)//The Twins
						{
							mechBossesDowned += 1;
						}
						if (NPC.downedMechBoss3)//	Skeletron Prime
						{
							mechBossesDowned += 1;
						}
						if (mechBossesDowned > 0)
						{
							float keyDropRateIncrease = 0;
							if (mechBossesDowned == 1)
							{
								keyDropRateIncrease = mPlayer.clientConf.BiomeKeyIncreaseForOneMechBossDown;
							}
							else if (mechBossesDowned == 2)
							{
								keyDropRateIncrease = mPlayer.clientConf.BiomeKeyIncreaseForTwoMechBossDown;
							}
							else if (mechBossesDowned == 3)
							{
								keyDropRateIncrease = mPlayer.clientConf.BiomeKeyIncreaseForThreeMechBossDown;
							}
							if (Main.rand.NextFloat() < keyDropRateIncrease)
							{
								if (player.ZoneJungle)
								{
									{
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.JungleKey, 1, false, -1, false, false);
									}
								}
								else if (player.ZoneCorrupt)
								{
									{
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CorruptionKey, 1, false, -1, false, false);
									}
								}
								else if (player.ZoneCrimson)
								{
									{
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CrimsonKey, 1, false, -1, false, false);
									}
								}
								else if (player.ZoneHoly)
								{
									{
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HallowedKey, 1, false, -1, false, false);
									}
								}
								else if (player.ZoneSnow)
								{
									{
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FrozenKey, 1, false, -1, false, false);
									}
								}
							}
						}
					}
					
					for (int j=0; j<player.GetModPlayer<ReducedGrindingPlayer>().clientConf.DropTriesForAllEnemyDroppedLoot; j++)
					{
						int AnkhCharmInInventory = 0;
						if (player.HasItem(888)) //Blindfold
							AnkhCharmInInventory++;
						if (player.HasItem(901)) //Armor Bracing
							AnkhCharmInInventory += 2;
						else
						{
							if (player.HasItem(886)) //Armor Polish
								AnkhCharmInInventory++;
							if (player.HasItem(892)) //Vitamins
								AnkhCharmInInventory++;
						}
						if (player.HasItem(902)) //Medicated Bandage
							AnkhCharmInInventory += 2;
						else
						{
							if (player.HasItem(887)) //Bezoar
								AnkhCharmInInventory++;
							if (player.HasItem(885)) //Adhesive Bandage
								AnkhCharmInInventory++;
						}
						if (player.HasItem(904)) //Countercurse Mantra
							AnkhCharmInInventory += 2;
						else
						{
							if (player.HasItem(890)) //Megaphone
								AnkhCharmInInventory++;
							if (player.HasItem(891)) //Nazar
								AnkhCharmInInventory++;
						}
						if (player.HasItem(903)) //The Plan
							AnkhCharmInInventory += 2;
						else
						{
							if (player.HasItem(889)) //Fast Clock
								AnkhCharmInInventory++;
							if (player.HasItem(893)) //Trifold Map
								AnkhCharmInInventory++;
						}
						float AnkhMaterialBonus = AnkhCharmInInventory * mPlayer.clientConf.LootAnkhCharmMaterialIncreasePerAnkhCharmInInventory * difficultyMultiplier;
						
						//Boss Loot
						if (npc.type == NPCID.SkeletronHead) //Skeletron
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootSkeletronBoneKey * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneKey, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootBookofSkullsIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BookofSkulls, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1281, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1363, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 266) //Brain of Cthulhu
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootBoneRattleIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneRattle, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2104, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1362, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 370) //Duke Fishron
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootFishronWingsIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FishronWings, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootFishronTruffleworm * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2673, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2588, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2589, 1, false, -1, false, false); //Trophy
						}
						if (npc.type >= 13 && npc.type <= 15 && npc.boss) //Eater of Worlds
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootEatersBoneIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EatersBone, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2111, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1361, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 4) //Eye of Cthulhu
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootBinocularsIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Binoculars, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2112, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1360, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 262) //Plantera
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootTheAxeIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TheAxe, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootSeedlingIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Seedling, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2109, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1370, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 222) //Queen Bee
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootHoneyedGogglesIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HoneyedGoggles, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootNectarIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Nectar, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2108, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1364, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 50) //Slime King
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2493, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2489, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 113) //Wall of Flesh
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2105, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1365, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 134) //The Destroyer
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2113, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1366, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 125 || npc.type == 126) //The Twins
						{
							if (!Main.expertMode)
							{
								int oppositeTwin = 125;
								if (npc.type == 125)
									oppositeTwin = 126;
								if (!NPC.AnyNPCs(oppositeTwin) && Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2106, 1, false, -1, false, false);
							}
							if (npc.type == 125 && Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease) //Retinazer
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1368, 1, false, -1, false, false); //Trophy
							if (npc.type == 126 && Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease) //Spazmatism
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1369, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 127) //Skeletron Prime
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2113, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1367, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 245) //Golem
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2110, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1371, 1, false, -1, false, false); //Trophy
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootPicksawIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1371, 1, false, -1, false, false); //Picksaw
						}
						if (npc.type == 370) //Duke Fishron
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2588, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2589, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 439) //Lunatic Cultist
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3372, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3357, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 398) //Moon Lord
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3373, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3595, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 551) //Betsy
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3863, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3866, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 564) //Dark Mage T1
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3864, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3867, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 565) //Dark Mage T3
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease / 2)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3864, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3867, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 576) //Ogre T2
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3865, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3868, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 577) //Ogre T3
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossMaskIncrease / 2)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3865, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3868, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 344) //Everscream
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootFestiveWingsIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FestiveWings, 1, false, -1, false, false);
						}
						if (npc.type == 345) //Ice Queen
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBabyGrinchsMischiefWhistleIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BabyGrinchMischiefWhistle, 1, false, -1, false, false);
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootReindeerBellsIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ReindeerBells, 1, false, -1, false, false);
						}
						if (npc.type == 491) //Flying Dutchman
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3359, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 395) //Martian Saucer
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3358, 1, false, -1, false, false); //Trophy
						}
						
						
						
						//Other Loot
						if (npc.type == NPCID.AnglerFish || npc.type == NPCID.Piranha)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootRobotHatIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RobotHat, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.AnglerFish || (npc.type >= 269 && npc.type <= 272) || npc.type == NPCID.Werewolf) //269 to 272 is Rusty Armored Bones
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootAdhesiveBandageIncrease * difficultyMultiplier + AnkhMaterialBonus)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AdhesiveBandage, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.ChaosElemental && mPlayer.clientConf.LootRodofDiscordIncrease > 0)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootRodofDiscordIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RodofDiscord, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Clown || npc.type == NPCID.LightMummy || npc.type == NPCID.GiantBat)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootTrifoldMapIncrease * difficultyMultiplier + AnkhMaterialBonus)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TrifoldMap, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Clown)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBananarangIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bananarang, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.EnchantedSword || npc.type == NPCID.CrimsonAxe || npc.type == NPCID.CursedHammer || npc.type == NPCID.CursedSkull)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootNazarIncrease * difficultyMultiplier + AnkhMaterialBonus)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Nazar, 1, false, -1, false, false);
							}
						}
						if (npc.type == 42 || (npc.type >= 231 && npc.type <= 235)) //Hornet
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMegaphoneBaseIncrease * difficultyMultiplier + AnkhMaterialBonus)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Megaphone, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootAncientCobaltHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltHelmet, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootAncientCobaltBreastplateIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltBreastplate, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootAncientCobaltLeggingsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltLeggings, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Corruptor || npc.type == NPCID.FloatyGross)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootVitaminsIncrease * difficultyMultiplier + AnkhMaterialBonus)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Vitamins, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Crimslime || npc.type == NPCID.BigCrimslime || npc.type == NPCID.LittleCrimslime)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBlindfoldIncrease * difficultyMultiplier + AnkhMaterialBonus)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Blindfold, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Mummy || npc.type == NPCID.Pixie || npc.type == NPCID.Wraith)
						{
							int fastClockMultiplier = 1;
							if (npc.type != NPCID.Pixie)
								fastClockMultiplier = 2;
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootFastClockBaseIncrease * difficultyMultiplier * fastClockMultiplier + AnkhMaterialBonus)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FastClock, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.FlyingSnake || npc.type == NPCID.Lihzahrd || npc.type == NPCID.LihzahrdCrawler)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootLizardEggIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LizardEgg, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootLihzahrdPowerCellIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LihzahrdPowerCell, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.GiantTortoise && mPlayer.clientConf.LootTurtleShellIncrease > 0)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootTurtleShellIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TurtleShell, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.IceTortoise && mPlayer.clientConf.LootFrozenTurtleShellIncrease > 0)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootFrozenTurtleShellIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FrozenTurtleShell, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Paladin)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootPaladinsShieldIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PaladinsShield, 1, false, -1, false, false);
							}
						}
						if ((npc.type >= 212 && npc.type <= 216) || npc.type == NPCID.PirateShip) //All Human Pirates and Flying Dutchman
						{
							int pirateLootMultiplier = 1;
							int pirateLootMultiplier2 = 1;
							if (npc.type == NPCID.PirateCaptain || npc.type == NPCID.PirateShip)
								pirateLootMultiplier = 4;
							if (npc.type == NPCID.PirateShip)
								pirateLootMultiplier2 = 4;
							if (Main.rand.NextFloat() < mPlayer.clientConf.PirateLootCoinGunBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CoinGun, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.PirateLootLuckyCoinBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LuckyCoin, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.PirateLootDiscountCardBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DiscountCard, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.PirateLootPirateStaffBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PirateStaff, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.PirateLootGoldRingBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldRing, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.PirateLootCutlassBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cutlass, 1, false, -1, false, false);
							}
							if (npc.type != NPCID.PirateCaptain && npc.type != NPCID.PirateShip)
							{
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootSailorHatIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SailorHat, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootSailorShirtIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SailorShirt, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootSailorPantsIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SailorPants, 1, false, -1, false, false);
								}
							}
							if (mPlayer.clientConf.LootGoldenFurnitureIncrease > 0 && npc.type != NPCID.PirateCaptain && npc.type != NPCID.PirateShip)
							{
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenChair, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenToilet, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenDoor, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenTable, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenBed, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenPiano, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenDresser, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenSofa, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenBathtub, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenClock, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenLamp, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenBookcase, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenChandelier, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenLantern, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenCandelabra, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenCandle, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenSink, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Pixie || npc.type == NPCID.GreenJellyfish || npc.type == NPCID.DarkMummy)
						{
							int megaphoneMultiplier = 1;
							if (npc.type == NPCID.GreenJellyfish)
								megaphoneMultiplier = 2;
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMegaphoneBaseIncrease * difficultyMultiplier * megaphoneMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Megaphone, 1, false, -1, false, false);
							}
						}
						if (npc.type == 77 || (npc.type >= 273 && npc.type <= 276)) //Blue Amored Bones and Armored Skeleton
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootArmorPolishIncrease * difficultyMultiplier + AnkhMaterialBonus)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ArmorPolish, 1, false, -1, false, false);
							}
						}
						if ((npc.type == NPCID.ZombieElf || npc.type == NPCID.ZombieElfBeard || npc.type == NPCID.ZombieElfGirl))
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootElfHatIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ElfHat, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootElfShirtIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ElfShirt, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootElfPantsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ElfPants, 1, false, -1, false, false);
							}
						}
						if (npc.type >= 269 && npc.type <= 280)//All Armored Bones variants
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootWispinaBottleIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WispinaBottle, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBoneFeatherIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneFeather, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMagnetSphereIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagnetSphere, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootKeybrandIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Keybrand, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.EaterofSouls)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootAncientShadowHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientShadowHelmet, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootAncientShadowScalemailIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientShadowScalemail, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootAncientShadowGreavesIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientShadowGreaves, 1, false, -1, false, false);
							}
						}
						if (npc.type == 21 || (npc.type >= 201 && npc.type <= 203) || (npc.type >= 322 && npc.type <= 323) || (npc.type >= 449 && npc.type <= 452)) //Skeleton
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootSkullIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Skull, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBoneSwordIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneSword, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootAncientGoldHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientGoldHelmet, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootAncientIronHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientIronHelmet, 1, false, -1, false, false);
							}
						}
						if (npc.type == 31 || (npc.type >= 294 && npc.type <= 296)) //Angry Bones
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootAncientNecroHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientNecroHelmet, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootClothierVoodooDollIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ClothierVoodooDoll, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBoneWandIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneWand, 1, false, -1, false, false);
							}
						}
						if (player.ZoneUnderworldHeight)
						{
							
							if (Main.hardMode)
							{
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootHelFireIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HelFire, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootLivingFireBlockIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LivingFireBlock, 1, false, -1, false, false);
								}
							}
							else if (NPC.downedBoss3) //Skeletron
							{
								if (Main.rand.NextFloat() < mPlayer.clientConf.LootCascadeIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cascade, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.ManEater)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootAncientCobaltHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltHelmet, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootAncientCobaltBreastplateIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltBreastplate, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootAncientCobaltLeggingsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltLeggings, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.FireImp)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootPlumbersHatIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PlumbersHat, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootObsidianRoseIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ObsidianRose, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.CursedSkull || npc.type == NPCID.DarkCaster)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBoneWandIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneWand, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.CaveBat)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootChainKnifeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ChainKnife, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Reaper)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootDeathSickleIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1327, 1, false, -1, false, false); //Death Sickle
							}
						}
						if (npc.type == 3 || npc.type == 132 || npc.type == 161 || (npc.type >= 186 && npc.type <= 200) || npc.type == 223 || (npc.type >= 430 && npc.type <= 436)) //Normal Zombie Variants, Raincoat Zombie, and Zombie Eskimo
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootZombieArmIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ZombieArm, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootShackleIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Shackle, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Pixie || npc.type == NPCID.Unicorn || npc.type == NPCID.RainbowSlime || npc.type == NPCID.Gastropod || npc.type == NPCID.LightMummy || npc.type == NPCID.IlluminantSlime || npc.type == NPCID.IlluminantBat || npc.type == NPCID.ChaosElemental || npc.type == NPCID.EnchantedSword || npc.type == NPCID.BigMimicHallow) //Hallow Enemies
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBlessedAppleIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlessedApple, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Mimic)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootDualHookIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DualHook, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMagicDaggerIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagicDagger, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootTitanGloveIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TitanGlove, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootPhilosophersStoneIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PhilosophersStone, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootCrossNecklaceIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CrossNecklace, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootStarCloakIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.StarCloak, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.BigMimicCorruption)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootDartRifleIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DartRifle, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootWormHookIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WormHook, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootChainGuillotinesIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ChainGuillotines, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootClingerStaffIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ClingerStaff, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootPutridScentIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PutridScent, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.BigMimicCrimson)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootLifeDrainIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulDrain, 1, false, -1, false, false);//Life Drain
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootDartPistolIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DartPistol, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootFetidBaghnakhsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FetidBaghnakhs, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootFleshKnucklesIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FleshKnuckles, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootTendonHookIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TendonHook, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.BigMimicHallow)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootDaedalusStormbowIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DaedalusStormbow, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootFlyingKnifeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FlyingKnife, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootCrystalVileShardIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CrystalVileShard, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootIlluminantHookIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IlluminantHook, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Harpy)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootGiantHarpyFeatherIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GiantHarpyFeather, 1, false, -1, false, false);
							}
						}
						if ((npc.type >= 26 && npc.type <= 29) || npc.type == 111) //Goblin Army (Excluding Summoner)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootHarpoonIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Harpoon, 1, false, -1, false, false);
							}
					}
						if (npc.type == NPCID.ArmoredViking || npc.type == NPCID.IceElemental || npc.type == NPCID.IcyMerman || npc.type == NPCID.IceTortoise)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootIceSickleIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IceSickle, 1, false, -1, false, false);
							}
						}
						if (npc.type >= 269 && npc.type <= 293)// Post-plantera dungeon enemies
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootKrakenIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Kraken, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.SkeletonArcher)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMarrowIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Marrow, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMagicQuiverIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagicQuiver, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Crimslime || npc.type == NPCID.CrimsonAxe || npc.type == NPCID.FloatyGross || npc.type == NPCID.Herpling)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMeatGrinderIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MeatGrinder, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.AngryTrapper)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootUziIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Uzi, 1, false, -1, false, false);
							}
						}
						if (NPC.downedMechBoss1 && player.ZoneJungle)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootYeletsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Yelets, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.ArmoredSkeleton)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBeamSwordIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BeamSword, 1, false, -1, false, false);
							}
						}
						if (npc.type == 2 || (npc.type >= 190 && npc.type <= 194) || npc.type == 317 || npc.type == 318) //Demon Eye and Wandering Eye
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBlackLensIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlackLens, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.ZombieEskimo || npc.type == NPCID.ArmedZombieEskimo)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootEskimoHoodIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EskimoHood, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootEskimoCoatIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EskimoCoat, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootEskimoPantsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EskimoPants, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Hellbat)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.HellBatLootMagmaStoneIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagmaStone, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Lavabat)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LavaBatLootMagmaStoneIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagmaStone, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.SnowFlinx)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootSnowballLauncherIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SnowballLauncher, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.MossHornet)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootTatteredBeeWingIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TatteredBeeWing, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.ScutlixRider)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBrainScramblerIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BrainScrambler, 1, false, -1, false, false);
							}
						}
						if (npc.type == 63 || npc.type == 64 || npc.type == 103) //Basic Jellyfish
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootJellyfishNecklaceIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.JellyfishNecklace, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DesertLamiaLight || npc.type == NPCID.DesertLamiaDark)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootLamiaClothesIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LamiaHat, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootLamiaClothesIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LamiaPants, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootLamiaClothesIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LamiaShirt, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Vampire)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMoonStoneIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonStone, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.RedDevil)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootFireFeatherIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FireFeather, 1, false, -1, false, false);
							}
						}
						if (mPlayer.clientConf.SlimeStaffIncreaseToSurfaceSlimes && (npc.type == NPCID.GreenSlime || npc.type == NPCID.BlueSlime || npc.type == NPCID.PurpleSlime || npc.type == NPCID.IceSlime || npc.type == NPCID.SandSlime || npc.type == NPCID.JungleSlime))
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootSlimeStaffIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
							}
						}
						if (mPlayer.clientConf.SlimeStaffIncreaseToUndergroundSlimes && (npc.type == NPCID.RedSlime || npc.type == NPCID.YellowSlime))
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootSlimeStaffIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
							}
						}
						if (mPlayer.clientConf.SlimeStaffIncreaseToCavernSlimess && (npc.type == NPCID.BlackSlime || npc.type == NPCID.MotherSlime || npc.type == NPCID.BabySlime))
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootSlimeStaffIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
							}
						}
						if (mPlayer.clientConf.SlimeStaffIncreaseToIceSpikedSlimes && npc.type == NPCID.SpikedIceSlime)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootSlimeStaffIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
							}
						}
						if (mPlayer.clientConf.SlimeStaffIncreaseToSpikedJungleSlimes && npc.type == NPCID.SpikedJungleSlime)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootSlimeStaffIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
							}
						}
						if (Main.hardMode && player.ZoneBeach)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootPirateMapIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PirateMap, 1, false, -1, false, false);
							}
						}
						if (Main.hardMode && player.ZoneRockLayerHeight && (player.ZoneCorrupt || player.ZoneCrimson))
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootSoulofNightIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofNight, 1, false, -1, false, false);
							}
						}
						if (Main.hardMode && player.ZoneRockLayerHeight && player.ZoneHoly)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootSoulofLightIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofLight, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Unicorn)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootUnicornonaStickIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.UnicornonaStick, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DiggerHead || npc.type == NPCID.GiantWormHead)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootWhoopieCushionIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WhoopieCushion, 1, false, -1, false, false);
							}
						}
						if (player.ZoneSnow && Main.hardMode) //Skeletron
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootAmarokIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Amarok, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.UndeadMiner)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBonePickaxeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BonePickaxe, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMiningHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MiningHelmet, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMiningShirtIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MiningShirt, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMiningPantsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MiningPants, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Psycho)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootPsychoKnifeIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PsychoKnife, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.CorruptBunny)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBunnyHoodIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BunnyHood, 1, false, -1, false, false);
							}
						}
						if (npc.type >= 78 && npc.type <= 80) //Mummies
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMummyCostumeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MummyMask, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMummyCostumeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MummyShirt, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMummyCostumeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MummyPants, 1, false, -1, false, false);
							}
						}
						if (npc.type == 31 || (npc.type >= 294 && npc.type <= 296) || npc.type == NPCID.CursedSkull || npc.type == NPCID.DarkCaster) //Angry Bones, Cursed Skull, and Dark Caster
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootGoldenKeyIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenKey, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootTallyCounterIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TallyCounter, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Werewolf)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMoonCharmIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonCharm, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DesertBeast)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootAncientHornIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientHorn, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Demon)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootDemonScytheIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DemonScythe, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Shark)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootDivingHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DivingHelmet, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Eyezor)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootEyeSpringIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EyeSpring, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.IceElemental || npc.type == NPCID.IcyMerman)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootFrostStaffIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FrostStaff, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.WalkingAntlion)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMandibleBladeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AntlionClaw, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.MeteorHead)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMeteoriteIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Meteorite, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.CorruptPenguin || npc.type == NPCID.CrimsonPenguin)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootPedguinssuitIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PedguinHat, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootPedguinssuitIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PedguinShirt, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootPedguinssuitIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PedguinPants, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.UndeadViking)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootVikingHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.VikingHelmet, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.UmbrellaSlime)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootUmbrellaHatIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.UmbrellaHat, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Vampire || npc.type == NPCID.VampireBat)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBrokenBatWingIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BrokenBatWing, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DesertDjinn)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootDesertSpiritLampIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DjinnLamp, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Piranha)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootHookIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Hook, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.LightMummy || npc.type == NPCID.DesertGhoulHallow || npc.type == NPCID.SandsharkHallow)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootLightShardIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LightShard, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DesertLamiaLight)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMoonMaskIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonMask, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DesertLamiaDark)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootSunMaskIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SunMask, 1, false, -1, false, false);
							}
						}
						if (npc.type >= 333 && npc.type <= 336) //Present Slimes
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootGiantBowIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GiantBow, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.ZombieRaincoat)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootRainArmorIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RainCoat, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootRainArmorIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RainCoat, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Mimic && player.ZoneSnow)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootToySledIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ToySled, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.SkeletonSniper)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootSniperRifleIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SniperRifle, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootRifleScopeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RifleScope, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.TacticalSkeleton)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootTacticalShotgunIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TacticalShotgun, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootSWATHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SWATHelmet, 1, false, -1, false, false);
							}
						}
						if (npc.type >= 524 && npc.type <= 527) //Ghouls
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootAncientClothIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCloth, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DesertGhoulCorruption || npc.type == NPCID.DesertGhoulCrimson)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootDarkShardIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DarkShard, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.AngryNimbus)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootNimbusRodIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.NimbusRod, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.BoneLee)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBlackBeltIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlackBelt, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootTabiIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Tabi, 1, false, -1, false, false);
							}
						}
						if (Main.halloween && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootGoodieBagIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoodieBag, 1, false, -1, false, false);
							}
						}
						if (Main.xMas && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootPresentIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Present, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Drippler || npc.type == NPCID.BloodZombie)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMoneyTroughIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoneyTrough, 1, false, -1, false, false);
							}
						}
						if (npc.type == 42 || npc.type == 141|| npc.type == 176 || (npc.type >= 231 && npc.type <= 235)) //Hornet, Moss Hornet, and Toxic Sludge
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootBezoarIncrease * difficultyMultiplier + AnkhMaterialBonus)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bezoar, 1, false, -1, false, false);
							}
						}
						if (Main.halloween && npc.value < 500f)
						{
							if (npc.damage >= 40 && npc.defense >= 20 && mPlayer.clientConf.LootBloodyMacheteAndBladedGlovesAreNotLimitedByDamageAndDefense) //Add Vanilla Drop Rate to the enemies that vanilla limits
							{
								if (Main.rand.Next(2000) == 0)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1825, 1, false, -1, false, false); //Bloody Machete
								}
								if (Main.rand.Next(2000) == 0)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1827, 1, false, -1, false, false); //Bladed Gloves
								}
							}
							if ((npc.damage < 40 && npc.defense < 20) || (mPlayer.clientConf.LootBloodyMacheteAndBladedGlovesAreNotLimitedByDamageAndDefense)) //Add this mod's increase
							{
								if (Main.rand.Next(2000) == 0)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1825, 1, false, -1, false, false); //Bloody Machete
								}
								if (Main.rand.Next(2000) == 0)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1827, 1, false, -1, false, false); //Bladed Gloves
								}
							}
						}
						if (npc.type >= 494 && npc.type <= 506) //Giant Shellies, Crawdads, and Salamanders
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootRallyIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Rally, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Medusa)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootPocketMirrorIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PocketMirror, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Mothron)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootMothronWingsIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MothronWings, 1, false, -1, false, false);
							}
						}
						if (Main.bloodMoon && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead && Main.hardMode)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootKOCannonIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.KOCannon, 1, false, -1, false, false);
							}
						}
						if (npc.type == 16 || npc.type == 58 || npc.type == 167 || npc.type == 197 || npc.type == 185 || (npc.type >= 494 && npc.type <= 506)) //Salamanders, Giant Shellys, Crawdads, Mother Slimes, Piranhas, Snow Flinxes, Undead Vikings, and Armored Vikings.
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootCompassIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Compass, 1, false, -1, false, false);
							}
						}
						if (npc.type == 49 || npc.type == 93 || npc.type == 51 || npc.type == 150 || (npc.type >= 494 && npc.type <= 506)) //Cave Bats, Giant Bats, Jungle Bats, Ice Bats, Salamanders, Giant Shellys, and Crawdads.
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootDepthMeterIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DepthMeter, 1, false, -1, false, false);
							}
						}
						if (npc.type == 22) //Guide NPC
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootGreenCap)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 867, 1, false, -1, false, false);
							}
						}
						if (npc.type == 207) //Dye Trader NPC
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootExoticScimitar)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3349, 1, false, -1, false, false);
							}
						}
						if (npc.type == 550) //Tavernkeep NPC
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootAleTosser)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3821, 1, false, -1, false, false);
							}
						}
						if (npc.type == 353) //Stylist NPC
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootStylishScissors)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3352, 1, false, -1, false, false);
							}
						}
						if (npc.type == 227) //Painter NPC
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootStylishScissors)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3352, 1, false, -1, false, false);
							}
						}
						if (npc.type == 208) //Party Girl NPC
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootPaintballGun)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3350, Main.rand.Next(30, 61), false, -1, false, false);
							}
						}
						if (npc.type == 441) //Tax Collector Guide NPC
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.LootClassyCane)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3351, 1, false, -1, false, false);
							}
						}
						if (npc.type == 244 && (mPlayer.clientConf.LootRainbowBlockDropMinIncrease < mPlayer.clientConf.LootRainbowBlockDropMaxIncrease)) //RainbowSlime
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 662, Main.rand.Next(mPlayer.clientConf.LootRainbowBlockDropMinIncrease - 30, mPlayer.clientConf.LootRainbowBlockDropMaxIncrease - 60), false, -1, false, false); //Rainbow Block
						}
					
						//Chest Drop
						if (mPlayer.clientConf.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop > 0)
						{
							if ((npc.type == 57 || npc.type == 58 || (npc.type >= 63 && npc.type <= 65) || npc.type == 67 || npc.type == 102 || npc.type == 103 || npc.type == 157 || npc.type == 220 || npc.type == 221 || npc.type == 241 || npc.type == 242 || npc.type == 256 || npc.type == 465) && Main.rand.NextFloat() < mPlayer.clientConf.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop) //Water Enemies (https://terraria.gamepedia.com/Water#Contents)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1298, 1, false, -1, false, false); //Water Chest
							else if (player.ZoneSnow && player.ZoneRockLayerHeight && Main.rand.NextFloat() < mPlayer.clientConf.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 681, 1, false, -1, false, false); //Ice Chest
							else if (player.ZoneJungle && player.ZoneRockLayerHeight && Main.rand.NextFloat() < mPlayer.clientConf.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 680, 1, false, -1, false, false); //Ivy Chest
							else if ((npc.type == 198 || npc.type == 199 || npc.type == 226) && Main.rand.NextFloat() < mPlayer.clientConf.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1142, 1, false, -1, false, false); //Lihzahrd Chest
							else if (((npc.type >= 163 && npc.type <= 165) || npc.type == 238) && Main.rand.NextFloat() < mPlayer.clientConf.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop) //Spider Nest Enemies
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 952, 1, false, -1, false, false); //Web Covered Chest
							else if (player.ZoneUnderworldHeight && Main.rand.NextFloat() < mPlayer.clientConf.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 328, 1, false, -1, false, false); //Shadow Chest
							else if (player.ZoneDungeon && NPC.downedPlantBoss)
							{
								if (Main.rand.NextFloat() < mPlayer.clientConf.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop && ReducedGrindingWorld.jungleChestMined)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1528, 1, false, -1, false, false); //Jungle Chest
								if (ReducedGrindingWorld.infectionChestMined)
								{
									if (Main.rand.NextFloat() < mPlayer.clientConf.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1529, 1, false, -1, false, false); //Corruption Chest
									if (Main.rand.NextFloat() < mPlayer.clientConf.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1530, 1, false, -1, false, false); //Crimson Chest
								}
								if (Main.rand.NextFloat() < mPlayer.clientConf.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop && ReducedGrindingWorld.hallowedChestMined)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1531, 1, false, -1, false, false); //Hallowed Chest
								if (Main.rand.NextFloat() < mPlayer.clientConf.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop && ReducedGrindingWorld.frozenChestMined)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1532, 1, false, -1, false, false); //Frozen Chest
							}
							else if (player.ZoneOverworldHeight && Main.rand.NextFloat() < mPlayer.clientConf.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 831, 1, false, -1, false, false); //Living Wood Chest
							else if ((player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight) && Main.rand.NextFloat() < mPlayer.clientConf.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 306, 1, false, -1, false, false); //Gold Chest
							else if (player.ZoneSkyHeight && Main.rand.NextFloat() < mPlayer.clientConf.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 838, 1, false, -1, false, false); //Skyware Chest
						}

						//Modded Loot
						float lockboxDropModdifier = 0.0f;
						if (Main.hardMode)
							lockboxDropModdifier = mPlayer.clientConf.HardmodeModdedLockBoxDropRateModifier;
						else
							lockboxDropModdifier = mPlayer.clientConf.NormalmodeModdedLockBoxDropRateModifier;
						
						if (npc.type == 57 || npc.type == 58 || (npc.type >= 63 && npc.type <= 65) || npc.type == 67 || npc.type == 102 || npc.type == 103 || npc.type == 157 || npc.type == 220 || npc.type == 221 || npc.type == 241 || npc.type == 242 || npc.type == 256 || npc.type == 465) //Water Enemies (https://terraria.gamepedia.com/Water#Contents)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.WaterEnemyModdedWaterLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Water_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if (player.ZoneDungeon)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.DungeonFurnitureLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Blue_Dungeon_Lock_Box"), 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.DungeonFurnitureLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Green_Dungeon_Lock_Box"), 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < mPlayer.clientConf.DungeonFurnitureLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Pink_Dungeon_Lock_Box"), 1, false, -1, false, false);
							}
							if (NPC.downedPlantBoss)
							{
								if (Main.rand.NextFloat() < mPlayer.clientConf.DungeonModdedBiomeLockBoxLoot*lockboxDropModdifier)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Biome_Lock_Box"), 1, false, -1, false, false);
								}
							}
						}
						else if (player.ZoneUnderworldHeight)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.HellBiomeModdedShadowLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Shadow_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if (player.ZoneSnow && player.ZoneRockLayerHeight)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.UndergroundSnowBiomeModdedIceLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Ice_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if (player.ZoneJungle && player.ZoneRockLayerHeight)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.UndergroundJungleBiomeModdedIvyLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Ivy_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if (npc.type == 48) //Harpy
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.SkyModdedSkywareLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Skyware_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if (player.ZoneSandstorm || player.ZoneUndergroundDesert)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.SandstormAndUndergroundDesertPyramidLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Pyramid_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if (npc.type == 198 || npc.type == 199 || npc.type == 226) //Lihzard Temple Enemies
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.JungleTempleLihzahrd_Lock_Box*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Lihzahrd_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if ((npc.type >= 163 && npc.type <= 165) || npc.type == 238) //Spider Nest Enemies
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.SpiderNestWebCoveredLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Web_Covered_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if (player.ZoneOverworldHeight)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.SurfaceModdedLivingWoodLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Living_Wood_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if (player.ZoneDirtLayerHeight)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.CavernModdedCavernLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Underground_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if (player.ZoneRockLayerHeight)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.CavernModdedCavernLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Cavern_Lock_Box"), 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Drippler || npc.type == NPCID.BloodZombie)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.BloodZombieAndDripplerDropsBloodMoonMedallion)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Blood_Moon_Medallion"), 1, false, -1, false, false);
							}
						}
					}
					
					//Restock Traveling Merchant
					if (mPlayer.clientConf.ChanceThatEnemyKillWillResetTravelingMerchant > 0)
					{
						int travelingMerchantResetChanceModifier = 22; //There are 22 vanilla NPCs as of 5/26/2017
						bool tryToResetTravelingMerchant = false;
						for (int i = 0; i < Terraria.Main.npc.Length; i++) //Do once for each NPC in the world
						{
							if (Terraria.Main.npc[i].type == NPCID.TravellingMerchant)
								tryToResetTravelingMerchant = true;
							if (Terraria.Main.npc[i].townNPC == true)
							{
								if (Terraria.Main.npc[i].type == NPCID.Merchant || Terraria.Main.npc[i].type == NPCID.Nurse || Terraria.Main.npc[i].type == NPCID.Demolitionist || Terraria.Main.npc[i].type == NPCID.DyeTrader || Terraria.Main.npc[i].type == NPCID.Dryad || Terraria.Main.npc[i].type == NPCID.DD2Bartender || Terraria.Main.npc[i].type == NPCID.ArmsDealer || Terraria.Main.npc[i].type == NPCID.Stylist || Terraria.Main.npc[i].type == NPCID.Painter || Terraria.Main.npc[i].type == NPCID.Angler || Terraria.Main.npc[i].type == NPCID.GoblinTinkerer || Terraria.Main.npc[i].type == NPCID.WitchDoctor || Terraria.Main.npc[i].type == NPCID.Clothier || Terraria.Main.npc[i].type == NPCID.Mechanic || Terraria.Main.npc[i].type == NPCID.PartyGirl || Terraria.Main.npc[i].type == NPCID.Wizard || Terraria.Main.npc[i].type == NPCID.TaxCollector || Terraria.Main.npc[i].type == NPCID.Truffle || Terraria.Main.npc[i].type == NPCID.Pirate || Terraria.Main.npc[i].type == NPCID.Steampunker || Terraria.Main.npc[i].type == NPCID.Cyborg) //Any Permenant Town Residents other than the Guide
									travelingMerchantResetChanceModifier--;
							}
						}
						if (travelingMerchantResetChanceModifier < 1)
							travelingMerchantResetChanceModifier = 1;
						if (tryToResetTravelingMerchant)
						{
							if (Main.rand.NextFloat() < mPlayer.clientConf.ChanceThatEnemyKillWillResetTravelingMerchant/travelingMerchantResetChanceModifier)
							{
								Chest.SetupTravelShop();
								if (Main.netMode == 2) // Server
									NetMessage.BroadcastChatMessage(NetworkText.FromKey("The Traveling Merchant restocked his items."), new Color(0, 127, 255));
								else if (Main.netMode == 0) // Single Player
									Main.NewText("The Traveling Merchant restocked his items.", 0, 127, 255);
							}
						}
					}
				}
			}
		}
	
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(this);
			
			recipe.AddIngredient(ItemID.EnchantedBoomerang,1);
			recipe.AddIngredient(ItemID.Katana,1);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.EnchantedSword);
			recipe.AddRecipe();
				
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.EnchantedSword,1);
			recipe.AddIngredient(ItemID.ShadowKey,1);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.Arkhalis);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.FragmentSolar, 1);
			recipe.AddIngredient(ItemID.FragmentVortex, 1);
			recipe.AddIngredient(ItemID.FragmentNebula, 1);
			recipe.AddIngredient(ItemID.FragmentStardust, 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.CelestialSigil);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.GoldenCrate, 1);
			recipe.AddIngredient(ItemID.DoubleCod, 1);
			recipe.AddIngredient(ItemID.VariegatedLardfish, 1);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.JungleFishingCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.GoldenCrate, 1);
			recipe.AddIngredient(ItemID.Ebonkoi, 1);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.CorruptFishingCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.GoldenCrate, 1);
			recipe.AddIngredient(ItemID.CrimsonTigerfish, 1);
			recipe.AddIngredient(ItemID.Hemopiranha, 1);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.CrimsonFishingCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.GoldenCrate, 1);
			recipe.AddIngredient(ItemID.Prismite, 1);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.HallowedFishingCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.GoldenCrate, 1);
			recipe.AddIngredient(ItemID.GoldenKey, 1);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.DungeonFishingCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.GoldenCrate, 1);
			recipe.AddIngredient(ItemID.Damselfish, 1);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.FloatingIslandFishingCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.GoldenCrate, 1);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.IronCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.IronCrate, 1);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.WoodenCrate);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.IronCrate, 4);
			recipe.AddIngredient(ItemID.DoubleCod, 1);
			recipe.AddIngredient(ItemID.VariegatedLardfish, 1);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.JungleFishingCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.IronCrate, 4);
			recipe.AddIngredient(ItemID.Ebonkoi, 1);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.CorruptFishingCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.IronCrate, 4);
			recipe.AddIngredient(ItemID.CrimsonTigerfish, 1);
			recipe.AddIngredient(ItemID.Hemopiranha, 1);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.CrimsonFishingCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.IronCrate, 4);
			recipe.AddIngredient(ItemID.Prismite, 1);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.HallowedFishingCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.IronCrate, 4);
			recipe.AddIngredient(ItemID.GoldenKey, 1);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.DungeonFishingCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.IronCrate, 4);
			recipe.AddIngredient(ItemID.Damselfish, 1);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.FloatingIslandFishingCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.WoodenCrate, 5);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.IronCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.IronCrate, 4);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.GoldenCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.JungleFishingCrate, 2);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.GoldenCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.FloatingIslandFishingCrate, 2);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.GoldenCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.CorruptFishingCrate, 2);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.GoldenCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.CrimsonFishingCrate, 2);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.GoldenCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.HallowedFishingCrate, 2);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.GoldenCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.DungeonFishingCrate, 2);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.GoldenCrate);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(1534, 1); //Corruption Key
			recipe.SetResult(1535); //Crimson Key
			recipe.AddRecipe();
				
			recipe = new ModRecipe(this);
			recipe.AddIngredient(1535, 1); //Crimson Key
			recipe.SetResult(1534); //Corruption Key
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(3392, 1); //Giant Shelly Banner
			recipe.AddIngredient(3391, 1); //Salamander Banner
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(3393); //Crawdad Banner
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(3393, 1); //Crawdad Banner
			recipe.AddIngredient(3392, 1); //Giant Shelly Banner
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(3391); //Salamander Banner
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(3391, 1); //Salamander Banner
			recipe.AddIngredient(3393, 1); //Crawdad Banner
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(3392); //Giant Shelly Banner
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(1307, 1); //ClothierVoodooDoll
			recipe.AddIngredient(520, 1); //Soul of Light
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(267); //Guide Voodoo Doll
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(1307, 1); //ClothierVoodooDoll
			recipe.AddIngredient(521, 1); //Soul of Night
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(267); //Guide Voodoo Doll
			recipe.AddRecipe();
		
		}
		
    }

    class SpawnRateMultiplierGlobalNPC : GlobalNPC
    {
		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			ReducedGrindingPlayer mPlayer = player.GetModPlayer<ReducedGrindingPlayer>(mod);
			
			if (player.FindBuffIndex(mod.BuffType("War")) != -1)
			{
				spawnRate = (int)(spawnRate / mPlayer.clientConf.WarPotionSpawnrateMultiplier);
				maxSpawns = (int)(maxSpawns * mPlayer.clientConf.WarPotionMaxSpawnsMultiplier);
			}
			if (player.FindBuffIndex(mod.BuffType("Chaos")) != -1)
			{
				spawnRate = (int)(spawnRate / mPlayer.clientConf.ChaosPotionSpawnrateMultiplier);
				maxSpawns = (int)(maxSpawns * mPlayer.clientConf.ChaosPotionMaxSpawnsMultiplier);
			}
			if (player.FindBuffIndex(BuffID.Battle) != -1)
			{
				spawnRate = (int)(spawnRate / mPlayer.clientConf.BattlePotionSpawnrateMultiplier);
				maxSpawns = (int)(maxSpawns * mPlayer.clientConf.BattlePotionMaxSpawnsMultiplier);
			}
		}
    }

	enum ReducedGrindingMessageType : byte
	{
		SyncPlayer,
		SendClientChanges,
		skipToNight,
		skipToDay
	}

}