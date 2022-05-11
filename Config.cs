using System.ComponentModel;
using Terraria.ModLoader.Config;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

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

		//public int[] SomeArray = new int[] { 25, 70, 12 };

		[Header("Boss Loot (1:Normal, 2:Expert)")]

		[Label("[i:1313] Book of Skulls")]
		[Range(0, 10000)]
		public int[] LootBookofSkullsIncrease = new int[] {0, 0};

		[Label("[i:1294] Picksaw")]
		[Range(0, 10000)]
		public int[] LootPicksawIncrease = new int[] { 4, 3 };

		[Label("[i:1182] Seedling")]
		[Range(0, 10000)]
		public int[] LootSeedlingIncrease = new int[] { 8, 7 };

		[Label("[i:1169] Bone Key")]
		[Range(0, 10000)]
		public int[] LootSkeletronBoneKey = new int[] { 0, 0 };

		[Label("[i:1299] Binoculars")]
		[Range(0, 10000)]
		public int[] LootBinocularsIncrease = new int[] { 4, 3 };

		[Label("[i:3060] Bone Rattle")]
		[Range(0, 10000)]
		public int[] LootBoneRattleIncrease = new int[] { 6, 5 };

		[Label("[i:3373] Boss Mask")]
		[Range(0, 10000)] 
		public int[] LootBossMaskIncrease = new int[] { 11, 10 };

		[Label("[i:3595] Boss Trophy")]
		[Range(0, 10000)]
		public int[] LootBossTrophyIncrease = new int[] { 0, 0 };

		[Label("[i:994] Eater's Bone")]
		[Range(0, 10000)]
		public int[] LootEatersBoneIncrease = new int[] { 6, 5 };

		[Label("[i:2673] Truffle Worm")]
		[Range(0, 10000)]
		public int[] LootFishronTruffleworm = new int[] { 3, 2 };

		[Label("[i:2609] Fishron Wings")]
		[Range(0, 10000)]
		public int[] LootFishronWingsIncrease = new int[] { 8, 7 };

		[Label("[i:2502] Honeyed Goggles")]
		[Range(0, 10000)]
		public int[] LootHoneyedGogglesIncrease = new int[] { 8, 7 };

		[Label("[i:3063] Moon Lord Weapons")]
		[Range(0, 10000)]
		public int[] LootMoonLordEachWeaponIncrease = new int[] { 6, 5 };

		[Label("[i:1170] Nectar")]
		[Range(0, 10000)]
		public int[] LootNectarIncrease = new int[] { 8, 7 };

		[Label("[i:1305] The Axe")]
		[Range(0, 10000)]
		public int[] LootTheAxeIncrease = new int[] { 6, 5 };

		[Header("Non-Boss Loot")]
		[Label("[i:1533] Biome Key Increase")]
		[Range(0, 10000)] [DefaultValue(2500)] public int LootBiomeKeyIncrease;
		[Tooltip("Chance that an enemy will drop a chest that can be obtained from the biome you are currently in (water enemies will also have this chance to drop Water Chest and Spider Nest enemies will also have this chance to drop Web Covered Chest.")]
		[Label("[i:831] Chest Drop From a Matching Biome")]
		[Increment(.0001f)] [DefaultValue(0.01f)] public float AllEnemiesLootBiomeMatchingFoundOnlyChestDrop;
		[Label("[i:1322] Magma Stone From Hellbat")]
		[Increment(.0001f)] [DefaultValue(0f)] public float HellBatLootMagmaStoneIncrease;
		[Label("[i:1322] Magma Stone From Lavabat")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LavaBatLootMagmaStoneIncrease;
		[Label("[i:885] Adhesive Bandage")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootAdhesiveBandageIncrease;
		[Label("[i:3821] Ale Tosser")]
		[Increment(.0001f)] [DefaultValue(0.833f)] public float LootAleTosserIncrease;
		[Label("[i:3289] Amarok")]
		[Increment(.0001f)] [DefaultValue((1f / 100) - (1f / 300))] public float LootAmarokIncrease;
		[Label("[i:3794] Ancient Cloth")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootAncientClothIncrease;
		[Label("[i:961] Ancient Cobalt Breastplate")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootAncientCobaltBreastplateIncrease;
		[Label("[i:960] Ancient Cobalt Helmet")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootAncientCobaltHelmetIncrease;
		[Label("[i:962] Ancient Cobalt Leggings")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootAncientCobaltLeggingsIncrease;
		[Label("[i:955] Ancient Gold Helmet")]
		[Increment(.0001f)] [DefaultValue(0.015f)] public float LootAncientGoldHelmetIncrease;
		[Label("[i:3771] Ancient Horn")]
		[Increment(.0001f)] [DefaultValue(0.03f)] public float LootAncientHornIncrease;
		[Label("[i:954] Ancient Iron Helmet")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootAncientIronHelmetIncrease;
		[Label("[i:959] Ancient Necro Helmet")]
		[Increment(.0001f)] [DefaultValue(0.0028f)] public float LootAncientNecroHelmetIncrease;
		[Label("[i:958] Ancient Shadow Greeves")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootAncientShadowGreavesIncrease;
		[Label("[i:956] Ancient Shadow Helmet")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootAncientShadowHelmetIncrease;
		[Label("[i:957] Ancient Shadow Scalemail")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootAncientShadowScalemailIncrease;
		[Tooltip("Increases chance of Ankh Charm material item drops for every different\n" +
			"Ankh Charm material item in your inventory (or in equipped items). Ankh\n" +
			"Charm material crafted into a new Ankh charm material counts as 2 (for\n" +
			"example: Armor Bracing counts as having Armor Polish and Vitamins). Max\n" +
			"Ankh Charm items in inventory is 9")]
		[Label("[i:1612] Ankh Charm Material Incr. Per Material in Inven.")]
		[Increment(.0001f)] [DefaultValue(0.0025f)] public float LootAnkhCharmMaterialIncreasePerAnkhCharmInInventory;
		[Label("[i:886] Armor Polish")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootArmorPolishIncrease;
		[Label("[i:1959] Baby Grinch's Mischief Whistle")]
		[Increment(.0001f)] [DefaultValue(0.05f)] public float LootBabyGrinchsMischiefWhistleIncrease;
		[Label("[i:1324] Bananarang")]
		[Increment(.0001f)] [DefaultValue(0.3f)] public float LootBananarangIncrease;
		[Label("[i:723] Beam Sword")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootBeamSwordIncrease;
		[Label("[i:887] Bezoar")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootBezoarIncrease;
		[Label("[i:963] Black Belt")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootBlackBeltIncrease;
		[Label("[i:236] Black Lens")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootBlackLensIncrease;
		[Label("[i:3260] Blessed Apple")]
		[Increment(.0001f)] [DefaultValue(0.0066f)] public float LootBlessedAppleIncrease;
		[Label("[i:888] Blindfold")]
		[Increment(.0001f)] [DefaultValue(0f)] public float LootBlindfoldIncrease;
		[Label("[i:1825] Bloody Machete")] [Increment(.0001f)] [DefaultValue(0.0015f)] public float LootBloodyMacheteAndBladedGlovesIncrease;
		[Label("[i:1517] Bone Feather")] [Increment(.0001f)] [DefaultValue(0.0078f)] public float LootBoneFeatherIncrease;
		[Label("[i:1320] Bone Pickaxe")] [Increment(.0001f)] [DefaultValue(0.0867f)] public float LootBonePickaxeIncrease;
		[Label("[i:1166] Bone Sword")] [Increment(.0001f)] [DefaultValue(0.0051f)] public float LootBoneSwordIncrease;
		[Label("[i:932] Bone Ward")] [Increment(.0001f)] [DefaultValue(0.006f)] public float LootBoneWandIncrease;
		[Label("[i:2771] Brain Scrambler")] [Increment(.0001f)] [DefaultValue(0.01f)] public float LootBrainScramblerIncrease;
		[Label("[i:1520] Broken Bat Wing")] [Increment(.0001f)] [DefaultValue(0.075f)] public float LootBrokenBatWingIncrease;
		[Label("[i:243] Bunny Hood")] [Increment(.0001f)] [DefaultValue(0f)] public float LootBunnyHoodIncrease;
		[Label("[i:3282] Cascade")] [Increment(.0001f)] [DefaultValue(0.0025f)] public float LootCascadeIncrease;
		[Label("[i:3012] Chain Guillotines")] [Increment(.0001f)] [DefaultValue(0f)] public float LootChainGuillotinesIncrease;
		[Label("[i:1325] Chain Knife")] [Increment(.0001f)] [DefaultValue(0.0027f)] public float LootChainKnifeIncrease;
		[Label("[i:3351] Classy Cane")] [Increment(.0001f)] [DefaultValue(0.875f)] public float LootClassyCane;
		[Label("[i:3014] Clinger Staff")] [Increment(.0001f)] [DefaultValue(0f)] public float LootClingerStaffIncrease;
		[Label("[i:1307] Clothier Voodoo Doll")] [Increment(.0001f)] [DefaultValue(0.0467f)] public float LootClothierVoodooDollIncrease;
		[Label("[i:751] Cloud (From Harpies)")] [Increment(.0001f)] [DefaultValue(1f)] public float LootCloudFromHarpies;
		[Label("[i:393] Compass")] [Increment(.0001f)] [DefaultValue(0f)] public float LootCompassIncrease;
		[Label("[i:554] Cross Necklace")] [Increment(.0001f)] [DefaultValue(0f)] public float LootCrossNecklaceIncrease;
		[Label("[i:3051] Crystal Vile Shard")] [Increment(.0001f)] [DefaultValue(0f)] public float LootCrystalVileShardIncrease;
		[Label("[i:3029] Daedalus Stormbow")] [Increment(.0001f)] [DefaultValue(0f)] public float LootDaedalusStormbowIncrease;
		[Label("[i:527] Dark Shard")] [Increment(.0001f)] [DefaultValue(0f)] public float LootDarkShardIncrease;
		[Label("[i:3007] Dart Pistol")] [Increment(.0001f)] [DefaultValue(0f)] public float LootDartPistolIncrease;
		[Label("[i:3008] Dart Rifle")] [Increment(.0001f)] [DefaultValue(0f)] public float LootDartRifleIncrease;
		[Label("[i:1327] Death Sickle")] [Increment(.0001f)] [DefaultValue(0.025f)] public float LootDeathSickleIncrease;
		[Label("[i:272] Demon Sythe")] [Increment(.0001f)] [DefaultValue(0.0214f)] public float LootDemonScytheIncrease;
		[Label("[i:18] Depth Meter")] [Increment(.0001f)] [DefaultValue(0f)] public float LootDepthMeterIncrease;
		[Label("[i:3347] Desert Fossil (From Dune Splicer)")] [Increment(.0001f)] [DefaultValue(1f)] public float LootDesertFossilFromDuneSplicer;
		[Label("[i:3795] Desert Spirit Lamp")] [Increment(.0001f)] [DefaultValue(0f)] public float LootDesertSpiritLampIncrease;
		[Label("[i:268] Diving Helmet")] [Increment(.0001f)] [DefaultValue(0.03f)] public float LootDivingHelmetIncrease;
		[Label("[i:437] Dual Hook")] [Increment(.0001f)] [DefaultValue(0f)] public float LootDualHookIncrease;
		[Label("[i:1943] Elf Hat")] [Increment(.0001f)] [DefaultValue(0.00833f)] public float LootElfHatIncrease;
		[Label("[i:1945] Elf Pants")] [Increment(.0001f)] [DefaultValue(0.00833f)] public float LootElfPantsIncrease;
		[Label("[i:1944] Elf Shirt")] [Increment(.0001f)] [DefaultValue(0.00833f)] public float LootElfShirtIncrease;
		[Label("[i:804] Eskimo Coat")] [Increment(.0001f)] [DefaultValue(0f)] public float LootEskimoCoatIncrease;
		[Label("[i:803] Eskimo Hood")] [Increment(.0001f)] [DefaultValue(0f)] public float LootEskimoHoodIncrease;
		[Label("[i:805] Eskimo Pants")] [Increment(.0001f)] [DefaultValue(0f)] public float LootEskimoPantsIncrease;
		[Label("[i:3349] Exotic Scimitar")] [Increment(.0001f)] [DefaultValue(0.875f)] public float LootExoticScimitarIncrease;
		[Label("[i:1278] Eye Patch")] [Increment(.0001f)] [DefaultValue(0f)] public float LootEyePatchIncrease;
		[Label("[i:1311] Eye Spring")] [Increment(.0001f)] [DefaultValue(0f)] public float LootEyeSpringIncrease;
		[Label("[i:889] Fast Clock")] [Increment(.0001f)] [DefaultValue(0f)] public float LootFastClockBaseIncrease;
		[Label("[i:1871] Festive Wings")] [Increment(.0001f)] [DefaultValue(0.05f)] public float LootFestiveWingsIncrease;
		[Label("[i:3013] Fetid Baghnakhs")] [Increment(.0001f)] [DefaultValue(0f)] public float LootFetidBaghnakhsIncrease;
		[Label("[i:1518] Fire Feather")] [Increment(.0001f)] [DefaultValue(0.0367f)] public float LootFireFeatherIncrease;
		[Label("[i:3016] Flesh Knuckles")] [Increment(.0001f)] [DefaultValue(0f)] public float LootFleshKnucklesIncrease;
		[Label("[i:3030] Flying Knife")] [Increment(.0001f)] [DefaultValue(0f)] public float LootFlyingKnifeIncrease;
		[Label("[i:726] Frost Staff")] [Increment(.0001f)] [DefaultValue(0f)] public float LootFrostStaffIncrease;
		[Label("[i:1253] Frozen Turtle Shell")] [Increment(.0001f)] [DefaultValue(0.19f)] public float LootFrozenTurtleShellIncrease;
		[Label("[i:1906] Giant Bow")] [Increment(.0001f)] [DefaultValue(0f)] public float LootGiantBowIncrease;
		[Label("[i:1516] Giant Harpy Feather")] [Increment(.0001f)] [DefaultValue(0.005f)] public float LootGiantHarpyFeatherIncrease;
		[Label("[i:1704] Gold Furniture")] [Increment(.0001f)] [DefaultValue(0f)] public float LootGoldenFurnitureIncrease;
		[Label("[i:327] Golden Key")] [Increment(.0001f)] [DefaultValue(0f)] public float LootGoldenKeyIncrease;
		[Label("[i:1774] Goodie Bag")] [Increment(.0001f)] [DefaultValue(0f)] public float LootGoodieBagIncrease;
		[Label("[i:867] Green Cap (For non-Andrew Guide)")] [Increment(.0001f)] [DefaultValue(1f)] public float LootGreenCapForNonAndrewGuide;
		[Label("[i:3548] Happy Grenade")] [Increment(.0001f)] [DefaultValue(0.75f)] public float LootHappyGrenadeIncrease;
		[Label("[i:160] Harpoon")] [Increment(.0001f)] [DefaultValue(0.0075f)] public float LootHarpoonIncrease;
		[Label("[i:3290] Hel-Fire")] [Increment(.0001f)] [DefaultValue(0.0025f)] public float LootHelFireIncrease;
		[Label("[i:1124] Hive Block (From Hornet and Moss Hornets after Defeating Queen Bee)")] [Increment(.0001f)] [DefaultValue(1f)] public float LootHiveBlockFromHornetsAndMossHornetsAfterQueenBeDowned;
		[Label("[i:118] Hook")] [Increment(.0001f)] [DefaultValue(0f)] public float LootHookIncrease;
		[Label("[i:1306] Sickle")] [Increment(.0001f)] [DefaultValue(0.0011f)] public float LootIceSickleIncrease;
		[Label("[i:3022] Illuminant Hook")] [Increment(.0001f)] [DefaultValue(0f)] public float LootIlluminantHookIncrease;
		[Label("[i:1303] Jellyfish Necklace")] [Increment(.0001f)] [DefaultValue(0.04f)] public float LootJellyfishNecklaceIncrease;
		[Label("[i:1314] KO Cannon")] [Increment(.0001f)] [DefaultValue(0.001f)] public float LootKOCannonIncrease;
		[Label("[i:671] Keybrand")] [Increment(.0001f)] [DefaultValue(0f)] public float LootKeybrandIncrease;
		[Label("[i:3291] Kraken")] [Increment(.0001f)] [DefaultValue(0.0075f)] public float LootKrakenIncrease;
		[Label("[i:3784] Lamia Clothes")] [Increment(.0001f)] [DefaultValue(0.01f)] public float LootLamiaClothesIncrease;
		[Label("[i:3006] Life Drain")] [Increment(.0001f)] [DefaultValue(0f)] public float LootLifeDrainIncrease;
		[Label("[i:528] Light Shard")] [Increment(.0001f)] [DefaultValue(0f)] public float LootLightShardIncrease;
		[Label("[i:1293] Lihzahrd Power Cell")] [Increment(.0001f)] [DefaultValue(0f)] public float LootLihzahrdPowerCellIncrease;
		[Label("[i:2701] Living Fire Block")] [Increment(.0001f)] [DefaultValue(0f)] public float LootLivingFireBlockIncrease;
		[Label("[i:1172] Lizard Egg")] [Increment(.0001f)] [DefaultValue(0.009f)] public float LootLizardEggIncrease;
		[Label("[i:517] Magic Dagger")] [Increment(.0001f)] [DefaultValue(0f)] public float LootMagicDaggerIncrease;
		[Label("[i:1321] Magic Quiver")] [Increment(.0001f)] [DefaultValue(0.0375f)] public float LootMagicQuiverIncrease;
		[Label("[i:1266] Magnet Sphere")] [Increment(.0001f)] [DefaultValue(0.0017f)] public float LootMagnetSphereIncrease;
		[Label("[i:3772] Mandible Blade")] [Increment(.0001f)] [DefaultValue(0f)] public float LootMandibleBladeIncrease;
		[Label("[i:682] Marrow")] [Increment(.0001f)] [DefaultValue(0.045f)] public float LootMarrowIncrease;
		[Label("[i:996] Meat Grinder")] [Increment(.0001f)] [DefaultValue(0f)] public float LootMeatGrinderIncrease;
		[Label("[i:890] Megaphone")] [Increment(.0001f)] [DefaultValue(0f)] public float LootMegaphoneBaseIncrease;
		[Label("[i:116] Meteorite")] [Increment(.0001f)] [DefaultValue(0f)] public float LootMeteoriteIncrease;
		[Label("[i:88] Mining Helmet")] [Increment(.0001f)] [DefaultValue(0.2833f)] public float LootMiningHelmetIncrease;
		[Label("[i:411] Mining Pants")] [Increment(.0001f)] [DefaultValue(0.3093f)] public float LootMiningPantsIncrease;
		[Label("[i:410] Mining Shirt")] [Increment(.0001f)] [DefaultValue(0.3093f)] public float LootMiningShirtIncrease;
		[Label("[i:3213] Money Trough")] [Increment(.0001f)] [DefaultValue(0.04f)] public float LootMoneyTroughIncrease;
		[Label("[i:485] Moon Charm")] [Increment(.0001f)] [DefaultValue(0f)] public float LootMoonCharmIncrease;
		[Label("[i:2801] Moon Mask")] [Increment(.0001f)] [DefaultValue(0f)] public float LootMoonMaskIncrease;
		[Label("[i:900] Moon Stone")] [Increment(.0001f)] [DefaultValue(0f)] public float LootMoonStoneIncrease;
		[Label("[i:2770] Mothron Wings")] [Increment(.0001f)] [DefaultValue(0.1381f)] public float LootMothronWingsIncrease;
		[Label("[i:870] Mummy Costume")] [Increment(.0001f)] [DefaultValue(0f)] public float LootMummyCostumeIncrease;
		[Label("[i:891] Nazar")] [Increment(.0001f)] [DefaultValue(0f)] public float LootNazarIncrease;
		[Label("[i:1244] Nimbus Rod")] [Increment(.0001f)] [DefaultValue(0f)] public float LootNimbusRodIncrease;
		[Label("[i:1323] Obsidian Rose")] [Increment(.0001f)] [DefaultValue(0.03f)] public float LootObsidianRoseIncrease;
		[Label("[i:3350] Paintball Gun")] [Increment(.0001f)] [DefaultValue(0.9f)] public float LootPaintballGunIncrease;
		[Label("[i:938] Paladin’s Shield")] [Increment(.0001f)] [DefaultValue(0.35f)] public float LootPaladinsShieldIncrease;
		[Label("[i:3757] Pedguin’s Suit")] [Increment(.0001f)] [DefaultValue(0f)] public float LootPedguinssuitIncrease;
		[Label("[i:535] Philosopher’s Stone")] [Increment(.0001f)] [DefaultValue(0f)] public float LootPhilosophersStoneIncrease;
		[Label("[i:1315] Pirate Map")] [Increment(.0001f)] [DefaultValue(0.015f)] public float LootPirateMapIncrease;
		[Label("[i:244] Plumber’s Hat")] [Increment(.0001f)] [DefaultValue(0.048f)] public float LootPlumbersHatIncrease;
		[Label("[i:3781] Pocket Mirror")] [Increment(.0001f)] [DefaultValue(0.105f)] public float LootPocketMirrorIncrease;
		[Label("[i:1869] Present")] [Increment(.0001f)] [DefaultValue(0f)] public float LootPresentIncrease;
		[Label("[i:3106] Psycho Knife")] [Increment(.0001f)] [DefaultValue(0.1125f)] public float LootPsychoKnifeIncrease;
		[Label("[i:3015] Putrid Scent")] [Increment(.0001f)] [DefaultValue(0f)] public float LootPutridScentIncrease;
		[Label("[i:1135] Rain Armor")] [Increment(.0001f)] [DefaultValue(0f)] public float LootRainArmorIncrease;

		[Label("[i:662] Rainbow Brick Max Increase")]
		[Range(0, 1000)]
		[Slider]
		[DefaultValue(0)] public int LootRainbowBlockDropMaxIncrease;
		[Label("[i:662] Rainbow Brick Min Increase")]
		[Range(0, 1000)]
		[Slider]
		[DefaultValue(0)] public int LootRainbowBlockDropMinIncrease;
		[Label("[i:3285] Rally")] [Increment(.0001f)] [DefaultValue(0.061f)] public float LootRallyIncrease;
		[Label("[i:1914] Reindeer Bells")] [Increment(.0001f)] [DefaultValue(0.0917f)] public float LootReindeerBellsIncrease;
		[Label("[i:1300] Rifle Scope")] [Increment(.0001f)] [DefaultValue(0f)] public float LootRifleScopeIncrease;
		[Label("[i:263] Robot Hat")] [Increment(.0001f)] [DefaultValue(0f)] public float LootRobotHatIncrease;
		[Label("[i:759] Rocket Launcher")] [Increment(.0001f)] [DefaultValue(0f)] public float LootRocketLauncherIncrease;
		[Range(0, 10000)] [Label("[i:1326] Rod of Discord (1:Normal, 2:Expert)")] public int[] LootRodofDiscordIncrease = new int[] {8, 7};
		[Range(0, 10000)] [Label("[i:1514] SWAT Helmet (1:Normal, 2:Expert)")] public int[] LootSWATHelmetIncrease = new int[] {0, 0};
		[Label("[i:1277] Sailor Hat")] [Increment(.0001f)] [DefaultValue(0f)] public float LootSailorHatIncrease;
		[Label("[i:1280] Sailor Pants")] [Increment(.0001f)] [DefaultValue(0f)] public float LootSailorPantsIncrease;
		[Label("[i:1279] Sailor Shirt")] [Increment(.0001f)] [DefaultValue(0f)] public float LootSailorShirtIncrease;
		[Label("[i:216] Shackle")] [Increment(.0001f)] [DefaultValue(0f)] public float LootShackleIncrease;
		[Label("[i:169] Min Sand (From Dune Splicer)")]
		[Range(1, 1000)]
		[Slider]
		[DefaultValue(20)] public int LootMinSandFromDuneSplicer;
		[Label("[i:169] Max Sand (From Dune Splicer)")]
		[Range(1, 1000)]
		[Slider]
		[DefaultValue(50)] public int LootMaxSandFromDuneSplicer;
		[Label("[i:169] Min Sand (From Tomb Crawler)")]
		[Range(1, 1000)]
		[Slider]
		[DefaultValue(0)] public int LootMinSandFromTombCrawler;
		[Label("[i:169] Max Sand (From Tomb Crawler)")]
		[Range(1, 1000)]
		[Slider]
		[DefaultValue(0)] public int LootMaxSandFromTombCrawler;
		[Label("[i:1274] Skull")] [Increment(.0001f)] [DefaultValue(0.048f)] public float LootSkullIncrease;
		[Label("[i:1309] Slime Staff")] [Increment(.0001f)] [DefaultValue(0.075f)] public float LootSlimeStaffIncrease;
		[Label("[i:1309] Slime Staff configuration affects Surface Slimes")] [DefaultValue(false)] public bool SlimeStaffIncreaseToSurfaceSlimes;
		[Label("[i:1309] Slime Staff configuration affects Underground Slimes")] [DefaultValue(false)] public bool SlimeStaffIncreaseToUndergroundSlimes;
		[Label("[i:1309] Slime Staff configuration affects Cavern Slimes")] [DefaultValue(false)] public bool SlimeStaffIncreaseToCavernSlimess;
		[Label("[i:1309] Slime Staff configuration affects Ice Spiked Slimes")] [DefaultValue(true)] public bool SlimeStaffIncreaseToIceSpikedSlimes;
		[Label("[i:1309] Slime Staff configuration affects Spiked Jungle Slimes")] [DefaultValue(true)] public bool SlimeStaffIncreaseToSpikedJungleSlimes;
		[Label("[i:1254] Sniper Rifle")] [Increment(.0001f)] [DefaultValue(0f)] public float LootSniperRifleIncrease;
		[Label("[i:951] Snowball Launcher")] [Increment(.0001f)] [DefaultValue(0.0133f)] public float LootSnowballLauncherIncrease;
		[Label("[i:520] Soul of Light")] [Increment(.0001f)] [DefaultValue(0f)] public float LootSoulofLightIncrease;
		[Label("[i:521] Soul of Night")] [Increment(.0001f)] [DefaultValue(0f)] public float LootSoulofNightIncrease;
		[Label("[i:532] Star Cloak")] [Increment(.0001f)] [DefaultValue(0f)] public float LootStarCloakIncrease;
		[Label("[i:3352] Stylish Scissors")] [Increment(.0001f)] [DefaultValue(0.875f)] public float LootStylishScissorsIncrease;
		[Label("[i:2802] Sun Mask")] [Increment(.0001f)] [DefaultValue(0f)] public float LootSunMaskIncrease;
		[Label("[i:977] Tabi")] [Increment(.0001f)] [DefaultValue(0f)] public float LootTabiIncrease;
		[Label("[i:679] Tactical Shotgun")] [Increment(.0001f)] [DefaultValue(0f)] public float LootTacticalShotgunIncrease;
		[Label("[i:3095] Tally Counter")] [Increment(.0001f)] [DefaultValue(0f)] public float LootTallyCounterIncrease;
		[Label("[i:1521] Tattered Bee Wing")] [Increment(.0001f)] [DefaultValue(0f)] public float LootTatteredBeeWingIncrease;
		[Label("[i:3020] Tendon Hook")] [Increment(.0001f)] [DefaultValue(0f)] public float LootTendonHookIncrease;
		[Label("[i:536] Titan Glove")] [Increment(.0001f)] [DefaultValue(0f)] public float LootTitanGloveIncrease;
		[Label("[i:1312] Toy Sled")] [Increment(.0001f)] [DefaultValue(0.15f)] public float LootToySledIncrease;
		[Label("[i:893] Trifold Map")] [Increment(.0001f)] [DefaultValue(0f)] public float LootTrifoldMapIncrease;
		[Label("[i:1328] Turtle Shell")] [Increment(.0001f)] [DefaultValue(0.1412f)] public float LootTurtleShellIncrease;
		[Label("[i:1243] Umbrella Hat")] [Increment(.0001f)] [DefaultValue(0f)] public float LootUmbrellaHatIncrease;
		[Label("[i:856] Unicorn on a Stick")] [Increment(.0001f)] [DefaultValue(0.04f)] public float LootUnicornonaStickIncrease;
		[Label("[i:1265] Uzi")] [Increment(.0001f)] [DefaultValue(0f)] public float LootUziIncrease;
		[Label("[i:879] Viking Helmet")] [Increment(.0001f)] [DefaultValue(0f)] public float LootVikingHelmetIncrease;
		[Label("[i:892] Vitamins (1:Normal, 2:Expert)")] [Range(0, 10000)] public int[] LootVitaminsIncrease = new int[] { 6, 5 };
		[Label("[i:215] Whoopie Cushion")] [Increment(.0001f)] [DefaultValue(0f)] public float LootWhoopieCushionIncrease;
		[Label("[i:1183] Wisp in a Bottle")] [Increment(.0001f)] [DefaultValue(0.0063f)] public float LootWispinaBottleIncrease;
		[Label("[i:3023] Worm Hook")] [Increment(.0001f)] [DefaultValue(0f)] public float LootWormHookIncrease;
		[Label("[i:3286] Yelets")] [Increment(.0001f)] [DefaultValue(0f)] public float LootYeletsIncrease;
		[Label("[i:1304] Zombie Arm")] [Increment(.0001f)] [DefaultValue(0.016f)] public float LootZombieArmIncrease;
		[Label("[i:905] Coin Gun")] [Tooltip("This is multiplied by 4 for Pirate Captain and 16 for Pirate Ship")] [Increment(.0001f)] [DefaultValue(0.0027f)] public float PirateLootCoinGunBaseIncrease;
		[Label("[i:672] Cutlass")] [Tooltip("This is multiplied by 4 for Pirate Captain and 16 for Pirate Ship")] [Increment(.0001f)] [DefaultValue(0.0117f)] public float PirateLootCutlassBaseIncrease;
		[Label("[i:854] Discount Card")] [Tooltip("This is multiplied by 4 for Pirate Captain and 16 for Pirate Ship")] [Increment(.0001f)] [DefaultValue(0.0045f)] public float PirateLootDiscountCardBaseIncrease;
		[Label("[i:3033] Gold Ring")] [Tooltip("This is multiplied by 4 for Pirate Captain and 16 for Pirate Ship")] [Increment(.0001f)] [DefaultValue(0.0043f)] public float PirateLootGoldRingBaseIncrease;
		[Label("[i:855] Lucky Coin")] [Tooltip("This is multiplied by 4 for Pirate Captain and 16 for Pirate Ship")] [Increment(.0001f)] [DefaultValue(0.0039f)] public float PirateLootLuckyCoinBaseIncrease;
		[Label("[i:2584] Pirate Staff")] [Tooltip("This is multiplied by 4 for Pirate Captain and 16 for Pirate Ship")] [Increment(.0001f)] [DefaultValue(0.0045f)] public float PirateLootPirateStaffBaseIncrease;
		[Label("[i:1825] Bloody Machete and [i:1827] Bladed Glove drop from non-weak enemies.")] [Tooltip("Makes it so their drop chance isn't limited to enemies with low defense, damage, and coin drop.")] [DefaultValue(true)] public bool LootBloodyMacheteAndBladedGlovesAreNotLimitedByDamageAndDefense;

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
		{
			message = "Can't change settings in a server.";
			return false;
		}
	}

	[Label("Crate and Other Grab Bag Drops")]
	public class BGrabBagConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Header("[i:3205] Dungeon Crate")]
		[Label("[i:2192] Bone Welder")] [Increment(.0001f)] [DefaultValue(0.2f)] public float CrateDungeonBoneWelder;
		[Label("[i:3085] Golden Lockbox")] [Increment(.0001f)] [DefaultValue(5.0f / 6)] public float CrateDungeonHardmodeGoldenLockBoxIncrease;

		[Header("[i:2336] Golden Crate")]
		[Label("[i:3064] Enchanted Sundial")] [Increment(.0001f)] [DefaultValue((1f / 4) - (1f / 20))] public float CrateEnchantedSundialGoldenIncrease;
		[Label("[i:187] Flipper")] [Increment(.0001f)] [DefaultValue(0f)] public float CrateFlippersGolden;
		[Label("[i:863] Water Walking Boots")] [Increment(.0001f)] [DefaultValue(0f)] public float CrateWaterWalkingBootsGolden;

		[Header("[i:2335] Iron Crate")]
		[Label("[i:3064] Enchanted Sundial")] [Increment(.0001f)] [DefaultValue((1f / 16) - (1f / 60))] public float CrateEnchantedSundialIronIncrease;
		[Label("[i:187] Fipper")] [Increment(.0001f)] [DefaultValue(0f)] public float CrateFlippersIron;
		[Label("[i:863] Water Walking Boots")] [Increment(.0001f)] [DefaultValue(0f)] public float CrateWaterWalkingBootsIron;
		
		[Header("[i:2334] Wooden Crate")]
		[Label("[i:3064] Enchanted Sundial")] [Increment(.0001f)] [DefaultValue((1f / 64) - (1f / 200))] public float CrateEnchantedSundialWoodenIncrease;
		[Label("[i:187] Flipper")] [Increment(.0001f)] [DefaultValue(0f)] public float CrateFlippersWooden;
		[Label("[i:863] Water Walking Boots")] [Increment(.0001f)] [DefaultValue(0f)] public float CrateWaterWalkingBootsWooden;
		[Label("[i:285] Aglet")] [Increment(.0001f)] [DefaultValue(0f)] public float CrateWoodenAgletIncrease;
		[Label("[i:953] Climbing Claws")] [Increment(.0001f)] [DefaultValue(0f)] public float CrateWoodenClimbingClawsIncrease;
		[Label("[i:3084] Radar")] [Increment(.0001f)] [DefaultValue(0f)] public float CrateWoodenRadarIncrease;

		[Header("[i:3208] Jungle Crate")]
		[Label("[i:212] Anklet of the Wind")] [Increment(.0001f)] [DefaultValue(0f)] public float CrateJungleAnkeltOfTheWindIncrease;
		[Label("[i:211] Feral Claws")] [Increment(.0001f)] [DefaultValue(0f)] public float CrateJungleFeralClawsIncrease;
		[Label("[i:3017] Flower Boots")] [Increment(.0001f)] [DefaultValue(0.25f)] public float CrateJungleFlowerBoots;
		[Label("[i:933] Leaf Wand")] [Increment(.0001f)] [DefaultValue(0f)] public float CrateJungleLeafWand;
		[Label("[i:2196] Living Loom")] [Increment(.0001f)] [DefaultValue(0f)] public float CrateJungleLivingLoom;
		[Label("[i:3360] Mahogany Wand")] [Increment(.0001f)] [DefaultValue(0f)] public float CrateJungleLivingMahoganyWand;
		[Label("[i:832] Living Wood Wand")] [Increment(.0001f)] [DefaultValue(0f)] public float CrateJungleLivingWoodWand;
		[Label("[i:3361] Rich Mahogany Leaf Wand")] [Increment(.0001f)] [DefaultValue(0f)] public float CrateJungleRichMahoganyLeafWand;
		[Label("[i:753] Seaweed")] [Increment(.0001f)] [DefaultValue(0.25f)] public float CrateJungleSeaweed;
		[Label("[i:213] Staff of Regrowth")] [Increment(.0001f)] [DefaultValue(0f)] public float CrateJungleStaffOfRegrowth;
		
		[Header("[i:3206] Sky Crate")]
		[Label("[i:2197] Sky Mill")] [Increment(.0001f)] [DefaultValue(0.3333f)] public float CrateSkySkyMill;

		[Header("[i:1869] Present")]
		[Label("[i:586] Candy Cane Block")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentCandyCaneBlock;
		[Label("[i:1915] Candy Cane Hook")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentCandyCaneHook;
		[Label("[i:1917] Candy Cane Pickaxe")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentCandyCanePickaxe;
		[Label("[i:1909] Candy Cane Sword")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentCandyCaneSword;
		[Label("[i:1911] Christmas Pudding")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentChristmasPudding;
		[Label("[i:1922] Coal")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentCoal;
		[Label("[i:1927] Dog Whistle")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentDogWhistle;
		[Label("[i:1912] Eggnog")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentEggnog;
		[Label("[i:1918] Fruitcake Chakram")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentFruitcakeChakram;
		[Label("[i:1920] Ginderbread Cookie")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentGingerbreadCookie;
		[Label("[i:591] Green Candy Cane Block")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentGreenCandyCaneBlock;
		[Label("[i:1921] Hand Warmer")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentHandWarmer;
		[Label("[i:602] Snow Glow (Hardmode only)")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentHardmodeSnowGlobe;
		[Label("[i:1908] Holly")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentHolly;
		[Label("[i:1933] Mrs. Clause Costume")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentMrsClausCostume;
		[Label("[i:1936] Parka Outfit")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentParkaOutfit;
		[Label("[i:1872] Pine Tree Block")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentPineTreeBlock;
		[Label("[i:1870] Red Ryder (with Musket Balls)")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentRedRyderPlusMusketBall;
		[Label("[i:1907] Reindeer Antlers")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentReindeerAntlers;
		[Label("[i:1938] Snow Hat")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentSnowHat;
		[Label("[i:1913] Star Anise")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentStarAnise;
		[Label("[i:1919] Sugar Cookie")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentSugarCookie;
		[Label("[i:1923] Toolbox")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentToolbox;
		[Label("[i:1940] Tree Costume")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentTreeCostume;
		[Label("[i:1939] Ugly Sweater")] [Increment(.0001f)] [DefaultValue(0f)] public float PresentUglySweater;

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
		{
			message = "Can't change settings in a server.";
			return false;
		}
	}

	[Label("Extra Chances for Angler Quest Rewards")]
	public class CAnglerQuestRewardsConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Label("[i:2374] Earring")] [Increment(.0001f)] [DefaultValue(0.025f)] public float QuestAnglerEarringIncrease;
		[Label("[i:2367] Angler Hat")] [Increment(.0001f)] [DefaultValue(0.05f)] public float QuestAnglerHatIncrease;
		[Label("[i:2369] Angler Pants")] [Increment(.0001f)] [DefaultValue(0.05f)] public float QuestAnglerPantsIncrease;
		[Label("[i:2368] Angler Vest")] [Increment(.0001f)] [DefaultValue(0.05f)] public float QuestAnglerVestIncrease;
		[Label("[i:2435] Coralstone Block")] [Increment(.0001f)] [DefaultValue(0.04f)] public float QuestCoralstoneBlockIncrease;
		[Label("[i:2490] Furniture")] [Increment(.0001f)] [DefaultValue(0.04f)] public float QuestDecorativeFurnitureIncrease;
		[Label("[i:2498] Fish Costume")] [Increment(.0001f)] [DefaultValue(0f)] public float QuestFishCostumeIncrease;
		[Label("[i:2360] Fish Hook")] [Increment(.0001f)] [DefaultValue(0.033f)] public float QuestFishHookIncrease;
		[Label("[i:3120] Fisherman's Pocket Guide")] [Increment(.0001f)] [DefaultValue(0.025f)] public float QuestFishermansGuideIncrease;
		[Label("[i:3183] Golden Bug Net")] [Increment(.0001f)] [DefaultValue(0.012f)] public float QuestGoldenBugNetIncrease;
		[Label("[i:2294] Golden Fishing Rod")] [Increment(.0001f)] [DefaultValue(0f)] public float QuestGoldenFishingRodIncrease;
		[Label("[i:3031] Bottomless Bucket (Hardcore only)")] [Increment(.0001f)] [DefaultValue(0.04f)] public float QuestHardcoreBottomlessBucketIncrease;
		[Label("[i:2494] Fin Wings (Hardcore only)")] [Increment(.0001f)] [DefaultValue(0.04f)] public float QuestHardcoreFinWingsIncrease;
		[Label("[i:2422] Hotline Fishing Hook (Hardcore only)")] [Increment(.0001f)] [DefaultValue(0.086f)] public float QuestHardcoreHotlineFishingHookIncrease;
		[Label("[i:3032] Super Absorbant Sponge (Hardcore only)")] [Increment(.0001f)] [DefaultValue(0.086f)] public float QuestHardcoreSuperAbsorbantSpongeIncrease;
		[Label("[i:2373] High Test Fishing Line")] [Increment(.0001f)] [DefaultValue(0.025f)] public float QuestHighTestFishingLineIncrease;
		[Label("[i:2419] Mermaid Costume")] [Increment(.0001f)] [DefaultValue(0f)] public float QuestMermaidCostumeIncrease;
		[Label("[i:3096] Sextant")] [Increment(.0001f)] [DefaultValue(0.025f)] public float QuestSextantIncrease;
		[Label("[i:2375] Tackle Box")] [Increment(.0001f)] [DefaultValue(0.025f)] public float QuestTackleBoxIncrease;
		[Label("[i:2448] Trophy")] [Increment(.0001f)] [DefaultValue(0.09f)] public float QuestTrophyIncrease;
		[Label("[i:3037] Weather Radio")] [Increment(.0001f)] [DefaultValue(0.025f)] public float QuestWeatherRadioIncrease;

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
		{
			message = "Can't change settings in a server.";
			return false;
		}
	}

	[Label("Extractinator Override Chances")]
	public class DExtractinatorConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		//[Header("This mod will go through all the vanilla extractinator loot from rarest to least rarest then highest to lowest value and will roll for a chance to override the extractinator result with that item using the chances listed below. If it sucessfully overrides the drop, it will stop going through the rest of the loot and give that item.")]
		[Header("This mod will try to override the [i:997] Extractinator result with the chances below. It will go through each item below from vanilla rarest to least rarest (for ties: highest to lowest value). If it sucessfully overrides, it will stop going through the chances and give the overriding item.\n\n\nThis only drops if the block used is [i:3347]Desert Fossil.")]
		[Label("[i:3380] Sturdy Fossil")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesFossilOre;

		[Header("This chance is divided by 3 if the block used is [i:424]Silt or [i:1103]Slush.")]
		[Label("[i:1242] Amber Mosquito")] [Increment(.0001f)] [DefaultValue((1f / 100) - 0.00027f)] public float ExtractinatorGivesAmberMosquito;
		[Header("This chance is divided by 2 if the block used is [i:424]Silt or [i:1103]Slush.")]
		[Label("[i:999] Amber")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesAmber;

		[Header("These chances are divided by 2 if the block used is [i:3347]Desert Fossil.")]
		[Label("[i:181] Amethyst")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesAmethyst;
		[Label("[i:180] Topaz")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesTopaz;
		[Label("[i:177] Sapphire")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesSapphire;
		[Label("[i:179] Emerald")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesEmerald;
		[Label("[i:178] Ruby")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesRuby;
		[Label("[i:182] Diamond")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesDiamond;

		[Header("The block used doesn't affect these chances.")]
		[Label("[i:71] Copper Coin")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesCopperCoin;
		[Label("[i:72] Silver Coin")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesSilverCoin;
		[Label("[i:73] Gold Coin")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesGoldCoin;
		[Label("[i:74] Platinum Coin")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesPlatinumCoin;
		[Label("[i:12] Copper Ore")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesCopperOre;
		[Label("[i:699] Tin Ore")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesTinOre;
		[Label("[i:11] Iron Ore")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesIronOre;
		[Label("[i:700] Lead Ore")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesLeadOre;
		[Label("[i:14] Silver Ore")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesSilverOre;
		[Label("[i:701] Tungsten Ore")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesTungstenOre;
		[Label("[i:13] Gold Ore")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesGoldOre;
		[Label("[i:702] Platinum Ore")] [Increment(.0001f)] [DefaultValue(0f)] public float ExtractinatorGivesPlatinumOre;

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

		//[Tooltip("The chance of the Traveling Merchant spawning each morning is this amount when you have all permanent vanilla and Reduced Grinding NPCs.")]
		[Header("Stationary Merchant:\n\nThis NPC sells everything the Traveling Merchant has a chance to sell, but there's a catch. By default, his prices are higher, especially when the Traveling Merchant is away. Also by default, the rarer the item, the more expensive the item is. The price for each item will get modified by the configurations below.")]
		[Label("Spawns")] [DefaultValue(true)] public bool StationaryMerchant;
		[Label("Base Multiplier When Merchant Present")] [Increment(.01f)] [Range(1f, 10f)] [DefaultValue(4f)] public float S_MerchantPriceMultiplierDuringSale;
		[Label("Base Multiplier When Merchant Away")] [Increment(.01f)] [Range(1f, 10f)] [DefaultValue(8f)] public float S_MerchantPriceMultiplier;
		[Tooltip("The Traveling Merchant Shop has 6 Rarity Tiers. The price each item in the Stationary Merchant's shop will be multiplied by 1 + ((Rarity_Tier - 1) * This_Configuration)")] [Label("Rarity Fee Rate")] [Increment(.1f)] [Range(0f, 10f)] [DefaultValue(1f)] public float S_MerchantRarityFee;

		[Header("Traveling Merchant")]
		[Tooltip("This is an additional chance of the Traveling Merchant spawning each morning. This chance is" +
			"\ngreatly decreased by permanent vanilla and Reduced Grinding NPC's that you don't have.")]
		[Label("Base Extra Spawn Spawn Chance")] [Increment(.0001f)] [DefaultValue(1.0f)] public float BaseMorningTMerchantSpawnChance;

		[Header("Traveling Merchant Shop Item Chance Increases")]
		[Label("[i:3055] Acorns")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantAcornsIncrease;
		[Label("[i:2177] Ammo Box")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantAmmoBoxIncrease;
		[Label("[i:1987] Angel Halo")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantAngelHaloIncrease;
		[Label("[i:2271] Arcane Rune Wall")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantArcaneRuneWallIncrease;
		[Label("[i:3309] Black Counter Weight")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantBlackCounterweightIncrease;
		[Label("[i:2262] Blue Dynasty Shingles")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantBlueDynastyShinglesIncrease;
		[Label("[i:3634] Blue Team Block")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantBlueTeamBlockIncrease;
		[Label("[i:3639] Blue Team Platform")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantBlueTeamPlatformIncrease;
		[Label("[i:2214] Brick Layer")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantBrickLayerIncrease;
		[Label("[i:2865] Castle Marsberg")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantCastleMarsbergIncrease;
		[Label("[i:2219] Celestial Magnet")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantCelestialMagnetIncrease;
		[Label("[i:2258] Chalice")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantChaliceIncrease;
		[Label("[i:3262] Code 1")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantCode1Increase;
		[Label("[i:3284] Code 2")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantCode2Increase;
		[Label("[i:3056] Cold Snap")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantColdSnapIncrease;
		[Label("[i:3628] Companion Cube")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantCompanionCubeIncrease;
		[Label("[i:2284] Crimson Cloak")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantCrimsonCapeIncrease;
		[Label("[i:3057] Cursed Saint")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantCursedSaintIncrease;
		[Label("[i:3119] DPS Meter")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantDPSMeterIncrease;
		[Label("[i:2276] Diamond Ring")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantDiamondRingIncrease;
		[Label("[i:2260] Dynasty Wood")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantDynastyWoodIncrease;
		[Label("[i:2215] Extendo Grip")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantExtendoGripIncrease;
		[Label("[i:2242] Fancy Dishes")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantFancyDishesIncrease;
		[Label("[i:1988] Fez")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantFezIncrease;
		[Label("[i:2270] Gatligator")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantGatligatorIncrease;
		[Label("[i:2277] Gi")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantGiIncrease;
		[Label("[i:3633] Green Team Block")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantGreenTeamBlockIncrease;
		[Label("[i:3638] Green Team Platform")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantGreenTeamPlatformIncrease;
		[Label("[i:2279] Gypsy Robe")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantGypsyRobeIncrease;
		[Label("[i:2273] Katana")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantKatanaIncrease;
		[Label("[i:2278] Kimono")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantKimonoIncrease;
		[Label("[i:2282] Leopard Skin")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantLeopardSkinIncrease;
		[Label("[i:3118] Lifeform Analyzer")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantLifeformAnalyzerIncrease;
		[Label("[i:2275] Magic Hat")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantMagicHatIncrease;
		[Label("[i:2866] Martia Lisa")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantMartiaLisaIncrease;
		[Tooltip("Normaly, not sold by the Traveling Merchant")] [Label("[i:3102] Metal Detector")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantMetalDetector;
		[Label("[i:2285] Mysterious Cape")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantMysteriousCapeIncrease;
		[Label("[i:3596] Not a Kid Nor a Squid")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantNotAKidNorASquidIncrease;
		[Label("[i:2267] Pad Thai")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantPadThaiIncrease;
		[Label("[i:2216] Paint Sprayer")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantPaintSprayerIncrease;
		[Label("[i:2268] Pho")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantPhoIncrease;
		[Label("[i:3636] Pink Team Block")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantPinkTeamBlockIncrease;
		[Label("[i:3641] Pink Team Platform")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantPinkTeamPlatformIncrease;
		[Label("[i:2217] Portable Cement Mixer")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantPortableCementMixerIncrease;
		[Label("[i:3624] Presserator")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantPresseratorIncrease;
		[Label("[i:2223] Pulse Bow")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantPulseBowIncrease;
		[Label("[i:2286] Red Cape")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantRedCapeIncrease;
		[Label("[i:2261] Red Dynasty Shingles")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantRedDynastyShinglesIncrease;
		[Label("[i:3621] Red Team Block")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantRedTeamBlockIncrease;
		[Label("[i:3622] Red Team Platform")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantRedTeamPlatformIncrease;
		[Label("[i:2269] Revelover")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantRevolverIncrease;
		[Label("[i:2266] Sake")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantSakeIncrease;
		[Label("[i:2296] Sitting Duck’s Fishing Pole")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantSittingDucksFishingPoleIncrease;
		[Label("[i:3058] Snowfellas")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantSnowfellasIncrease;
		[Label("[i:3099] Stopwatch")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantStopwatchIncrease;
		[Label("[i:3059] The Season")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantTheSeasonIncrease;
		[Label("[i:2867] The Truth is Up There")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantTheTruthIsUpThereIncrease;
		[Label("[i:2281] Tiger Skin")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantTigerSkinIncrease;
		[Label("[i:2274] Ultrabright Torch")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantUltraBrightTorchIncrease;
		[Label("[i:2272] Water Gun")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantWaterGunIncrease;
		[Label("[i:3637] White Team Block")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantWhiteTeamBlockIncrease;
		[Label("[i:3642] White Team Platform")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantWhiteTeamPlatformIncrease;
		[Label("[i:2287] Winter Cape")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantWinterCapeIncrease;
		[Label("[i:3314] Yellow Counterweight")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantYellowCounterweightIncrease;
		[Label("[i:3635] Yellow Team Block")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantYellowTeamBlockIncrease;
		[Label("[i:3640] Yellow Team Platform")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantYellowTeamPlatformIncrease;
		[Label("[i:2283] Zebra Skin")] [Increment(.0001f)] [DefaultValue(0f)] public float TravelingMerchantZebraSkinIncrease;
		[Label("Increased Christmas Item chances requires Christmas")] [DefaultValue(true)] public bool TravelingMerchantAlwaysXMasForConfigurations;

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

		[Label("All NPCs Sell Their Death Loot")] [DefaultValue(false)] public bool AllNPCsSellTheirDeathLoot;
		[Header("Mechanic Sells")]
		[Label("[i:539] Dart Trap and [i:147]Spikes After Skeleton Defeated")] [DefaultValue(true)] public bool MechanicSellsDartTrapAndSpikesAfterSkeletronDefeated;
		[Label("[i:3722] Geyzer After Wall of Flesh Defeated")] [DefaultValue(true)] public bool MechanicSellsGeyserAfterWallofFleshDefeated;
		[Header("Witch Doctor Sells")]
		[Label("[i:1146] Lihzahrd Traps After Golem Defeated")] [DefaultValue(true)] public bool WitchDoctorSellsLihzahrdTrapsAfterGolemDefeated;
		[Label("[i:1150] Wooden Spikes After Golem Defeated")] [DefaultValue(true)] public bool WitchDoctorSellsWoodenSpikesAfterGolemDefeated;
		[Label("[i:3017] Flower Boots")] [DefaultValue(false)] public bool WitchDoctorSellsFlowerBoots;
		[Label("[i:2204] Honey Dispenser")] [DefaultValue(false)] public bool WitchDoctorSellsHoneyDispenser;
		[Label("[i:2338] Seaweed")] [DefaultValue(false)] public bool WitchDoctorSellsSeaweed;
		[Label("[i:213] Staff of Regrowth")] [DefaultValue(false)] public bool WitchDoctorSellsStaffofRegrowth;
		[Header("Merchant Sells")]
		[Label("[i:410] All Mining Gear;")] [DefaultValue(true)] public bool MerchantSellsAllMiningGear;
		[Label("[i:987] Blizzard In A Bottle When In Snow")] [DefaultValue(false)] public bool MerchantSellsBlizzardInABottleWhenInSnow;
		[Label("[i:53] Cloud In A Bottle When In Sky")] [DefaultValue(false)] public bool MerchantSellsCloudInABottleWhenInSky;
		[Label("[i:669] Fish Item")] [DefaultValue(false)] public bool MerchantSellsFishItem;
		[Label("[i:934] Pyramid Items")] [DefaultValue(false)] public bool MerchantSellsPyramidItems;
		[Label("[i:857] Sandstorm In A Bottle When In Desert")] [DefaultValue(false)] public bool MerchantSellsSandstormInABottleWhenInDesert;
		[Label("[i:290] Swiftness Potion")] [DefaultValue(true)] public bool MerchantSellsSwiftnessPotion;
		[Header("Tax Collector")]
		[Label("[i:73] Tax Requirement for Tax Alert")]
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
		[Label("Lockboxes Give Furniture")] [DefaultValue(true)] public bool LockBoxesGiveFurniture;
		[Label("Lock Boxes Give Non-Furniture")] [DefaultValue(true)] public bool LockBoxesGiveNonFurniture;
		[Label("Hardmode Modded Lock Box Drop Rate Modifier")] [Increment(.0001f)] [DefaultValue(1f)] public float HardmodeModdedLockBoxDropRateModifier;
		[Label("Normalmode Modded Lock Box Drop Rate Modifier")] [Increment(.0001f)] [DefaultValue(1f)] public float NormalmodeModdedLockBoxDropRateModifier;
		[Label("$Mods.ReducedGrinding.Common.CavernLockboxLable")]
		[Increment(.0001f)] [DefaultValue(0.0025f)] public float CavernModdedCavernLockBoxLoot;
		[Label("$Mods.ReducedGrinding.Common.DungeonBiomeLockboxLabel")]
		[Increment(.0001f)] [DefaultValue(0.0025f)] public float DungeonModdedBiomeLockBoxLoot;


		[Tooltip("Required stack size of a single biome key type needed to open Biome Lockboxes. The type is randomly choosen from\n" +
			"available keys in inventory that meet this required size. The rare item obtained will match the key used to open it.")]
		[Label("Required [i:1533]Biome Key stack size to open Biome Lockboxes")]
		[Range(1, 99)] [DefaultValue(3)] public int BiomeLockboxKeysRequired;


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

		[Tooltip("Summons Plantera")] [Label("$Mods.ReducedGrinding.Common.PlanteraBulbLable")] [DefaultValue(true)] public bool DryadSellsPlanteraBulbAfterPlanteraDefeated;
		[Tooltip("Ends the Goblin Invasion")] [Label("$Mods.ReducedGrinding.Common.GoblinRetreatOrderLable")] [DefaultValue(true)] public bool GoblinTinkererSellsGoblinRetreatOrder;
		[Tooltip("Allows crafting golden critters")] [Label("$Mods.ReducedGrinding.Common.GoldReflectionMirror")] [DefaultValue(false)] public bool MerchantSellsGoldReflectionMirrorForCraftingGoldCrittersItem;
		[Tooltip("Ends the Pirate Invasion")] [Label("$Mods.ReducedGrinding.Common.PirateRetreatOrder")] [DefaultValue(true)] public bool PirateSellsPirateRetreatOrder;
		[Tooltip("Advances the Moon Phase")] [Label("$Mods.ReducedGrinding.Common.MoonBall")] [DefaultValue(true)] public bool WizardSellsMoonBall;
		[Tooltip("Starts a Martian Invasion")] [Label("$Mods.ReducedGrinding.Common.MartianCall")] [Increment(.0001f)] [DefaultValue(1f)] public float MartianSaucerMartianCallDrop;
		[Header("[i:300] Battle Potion")]
		[Tooltip("The vanilla multiplier will be multiplied further by this amount")] [Label("Max Spawns Extra Multiplier")] [Increment(.0001f)] [Range(1f, 100f)] [DefaultValue(1f)] public float BattlePotionMaxSpawnsMultiplier;
		[Tooltip("The vanilla multiplier will be multiplied further by this amount")] [Label("Spawn Rate Extra Multiplier")] [Increment(.0001f)] [Range(1f, 100f)] [DefaultValue(1f)] public float BattlePotionSpawnrateMultiplier;
		[Header("$Mods.ReducedGrinding.Common.WarPotion")]
		[Label("Max Spawns Multiplier")] [Increment(.0001f)] [Range(1f, 100f)] [DefaultValue(10f)] public float WarPotionMaxSpawnsMultiplier;
		[Label("Spawn Rate Multiplier")] [Increment(.0001f)] [Range(1f, 100f)] [DefaultValue(10f)] public float WarPotionSpawnrateMultiplier;
		[Header("$Mods.ReducedGrinding.Common.ChaosPotion")]
		[Label("Max Spawns Multiplier")] [Increment(.0001f)] [Range(1f, 100f)] [DefaultValue(20f)] public float ChaosPotionMaxSpawnsMultiplier;
		[Label("Spawn Rate Multiplier")] [Increment(.0001f)] [Range(1f, 100f)] [DefaultValue(20f)] public float ChaosPotionSpawnrateMultiplier;

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

		[Tooltip("Permanent version of the Skeleton Merchant")] [Label("Bone Merchant")] [DefaultValue(false)] public bool BoneMerchant;
		[Label("Bone Merchant Disabled When Luiafk Is Installed")] [DefaultValue(false)] public bool BoneMerchantDisabledWhenLuiafkIsInstalled;
		[Tooltip("Permanent version of Santa Claus")] [Label("Christmas Elf")] [DefaultValue(true)] public bool ChristmasElf;
		[Tooltip("Sells what's needed to fight the next Vanilla boss (you can still aquire these items normally)")] [Label("Loot Merchant")] [DefaultValue(false)] public bool LootMerchant;
		[Tooltip("Sells vanilla chests that are normally limited. Note: This mod allows you to aquire these chests through monster drops.")] [Label("Chest Salesman")] [DefaultValue(false)] public bool ChestSalesman;
		[Label("Chest Salesman Pre-Hardmode Chests Require Hardmode Activated")] [DefaultValue(false)] public bool ChestSalesmanPreHardmodeChestsRequireHardmodeActivated;
		[Header("Chest Salesman Sells")]
		[Label("[i:1529] Biome Chests")] [DefaultValue(true)] public bool ChestSalesmanSellsBiomeChests;
		[Label("[i:306] Gold Chest")] [DefaultValue(true)] public bool ChestSalesmanSellsGoldChest;
		[Label("[i:681] Ice Chest")] [DefaultValue(true)] public bool ChestSalesmanSellsIceChest;
		[Label("[i:680] Ivy Chest")] [DefaultValue(true)] public bool ChestSalesmanSellsIvyChest;
		[Label("[i:680] Lihzahrd Chest")] [DefaultValue(true)] public bool ChestSalesmanSellsLihzahrdChest;
		[Label("[i:831] Living Wood Chest")] [DefaultValue(false)] public bool ChestSalesmanSellsLivingWoodChest;
		[Label("[i:1298] Water Chest")] [DefaultValue(true)] public bool ChestSalesmanSellsOceanChest;
		[Label("[i:328] Shadow Chest")] [DefaultValue(true)] public bool ChestSalesmanSellsShadowChest;
		[Label("[i:838] SkywareChest")] [DefaultValue(true)] public bool ChestSalesmanSellsSkywareChest;
		[Label("[i:952] Web Covered Chest")] [DefaultValue(true)] public bool ChestSalesmanSellsWebCoveredChest;

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
		{
			message = "Can't change settings in a server.";
			return false;
		}
    }
}
