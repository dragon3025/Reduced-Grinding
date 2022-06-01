using System.ComponentModel;
using Terraria.ModLoader.Config;
using System;

namespace ReducedGrinding
{

    [Label("Enemy Loot")]
    public class AEnemyLootConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("All configurations in this section will add an n/1 chance for a drop, where n is the configuration setting. Set to 0 to disable.\n\nBoss Loot")]

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
        [Range(0, 10000)]
        [DefaultValue(2500)]
        public int LootBiomeKeyIncrease;

        [Label("[i:1322] Magma Stone From Hellbat")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int HellBatLootMagmaStoneIncrease;

        [Label("[i:1322] Magma Stone From Lavabat")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LavaBatLootMagmaStoneIncrease;

        [Label("[i:885] Adhesive Bandage")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootAdhesiveBandageIncrease;

        [Label("[i:3821] Ale Tosser")]
        [Range(0, 10000)]
        [DefaultValue(2)]
        public int LootAleTosserIncrease;

        [Label("[i:3289] Amarok")]
        [Range(0, 10000)]
        [DefaultValue(150)]
        public int LootAmarokIncrease;

        [Label("[i:3794] Ancient Cloth")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootAncientClothIncrease;

        [Label("[i:961] Ancient Cobalt Breastplate")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootAncientCobaltBreastplateIncrease;

        [Label("[i:960] Ancient Cobalt Helmet")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootAncientCobaltHelmetIncrease;

        [Label("[i:962] Ancient Cobalt Leggings")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootAncientCobaltLeggingsIncrease;

        [Label("[i:955] Ancient Gold Helmet")]
        [Range(0, 10000)]
        [DefaultValue(66)]
        public int LootAncientGoldHelmetIncrease;

        [Label("[i:3771] Ancient Horn")]
        [Range(0, 10000)]
        [DefaultValue(33)]
        public int LootAncientHornIncrease;

        [Label("[i:954] Ancient Iron Helmet")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootAncientIronHelmetIncrease;

        [Label("[i:959] Ancient Necro Helmet")]
        [Range(0, 10000)]
        [DefaultValue(357)]
        public int LootAncientNecroHelmetIncrease;

        [Label("[i:958] Ancient Shadow Greeves")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootAncientShadowGreavesIncrease;

        [Label("[i:956] Ancient Shadow Helmet")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootAncientShadowHelmetIncrease;

        [Label("[i:957] Ancient Shadow Scalemail")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootAncientShadowScalemailIncrease;

        [Label("[i:886] Armor Polish")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootArmorPolishIncrease;

        [Label("[i:1959] Baby Grinch's Mischief Whistle")]
        [Range(0, 10000)]
        [DefaultValue(0.20)]
        public int LootBabyGrinchsMischiefWhistleIncrease;

        [Label("[i:1324] Bananarang")]
        [Range(0, 10000)]
        [DefaultValue(3)]
        public int LootBananarangIncrease;

        [Label("[i:723] Beam Sword")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootBeamSwordIncrease;

        [Label("[i:887] Bezoar")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootBezoarIncrease;

        [Label("[i:963] Black Belt")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootBlackBeltIncrease;

        [Label("[i:236] Black Lens")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootBlackLensIncrease;

        [Label("[i:3260] Blessed Apple")]
        [Range(0, 10000)]
        [DefaultValue(151)]
        public int LootBlessedAppleIncrease;

        [Label("[i:888] Blindfold")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootBlindfoldIncrease;

        [Label("[i:1825] Bloody Machete and [i:1827] Bladed Glove")]
        [Range(0, 10000)]
        [DefaultValue(666)]
        public int LootBloodyMacheteAndBladedGlovesIncrease;

        [Label("[i:1517] Bone Feather")]
        [Range(0, 10000)]
        [DefaultValue(128)]
        public int LootBoneFeatherIncrease;

        [Label("[i:1320] Bone Pickaxe")]
        [Range(0, 10000)]
        [DefaultValue(12)]
        public int LootBonePickaxeIncrease;

        [Label("[i:1166] Bone Sword")]
        [Range(0, 10000)]
        [DefaultValue(196)]
        public int LootBoneSwordIncrease;

        [Label("[i:932] Bone Ward")]
        [Range(0, 10000)]
        [DefaultValue(167)]
        public int LootBoneWandIncrease;

        [Label("[i:2771] Brain Scrambler")]
        [Range(0, 10000)]
        [DefaultValue(100)]
        public int LootBrainScramblerIncrease;

        [Label("[i:1520] Broken Bat Wing")]
        [Range(0, 10000)]
        [DefaultValue(14)]
        public int LootBrokenBatWingIncrease;

        [Label("[i:243] Bunny Hood")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootBunnyHoodIncrease;

        [Label("[i:3282] Cascade")]
        [Range(0, 10000)]
        [DefaultValue(400)]
        public int LootCascadeIncrease;

        [Label("[i:3012] Chain Guillotines")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootChainGuillotinesIncrease;

        [Label("[i:1325] Chain Knife")]
        [Range(0, 10000)]
        [DefaultValue(370)]
        public int LootChainKnifeIncrease;

        [Label("[i:3351] Classy Cane")]
        [Range(0, 10000)]
        [DefaultValue(2)]
        public int LootClassyCane;

        [Label("[i:3014] Clinger Staff")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootClingerStaffIncrease;

        [Label("[i:1307] Clothier Voodoo Doll")]
        [Range(0, 10000)]
        [DefaultValue(21)]
        public int LootClothierVoodooDollIncrease;

        [Label("[i:751] Cloud (From Harpies)")]
        [Range(0, 10000)]
        [DefaultValue(1)]
        public int LootCloudFromHarpies;

        [Label("[i:393] Compass")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootCompassIncrease;

        [Label("[i:554] Cross Necklace")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootCrossNecklaceIncrease;

        [Label("[i:3051] Crystal Vile Shard")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootCrystalVileShardIncrease;

        [Label("[i:3029] Daedalus Stormbow")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootDaedalusStormbowIncrease;

        [Label("[i:527] Dark Shard")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootDarkShardIncrease;

        [Label("[i:3007] Dart Pistol")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootDartPistolIncrease;

        [Label("[i:3008] Dart Rifle")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootDartRifleIncrease;

        [Label("[i:1327] Death Sickle")]
        [Range(0, 10000)]
        [DefaultValue(40)]
        public int LootDeathSickleIncrease;

        [Label("[i:272] Demon Sythe")]
        [Range(0, 10000)]
        [DefaultValue(47)]
        public int LootDemonScytheIncrease;

        [Label("[i:18] Depth Meter")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootDepthMeterIncrease;

        [Label("[i:3795] Desert Spirit Lamp")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootDesertSpiritLampIncrease;

        [Label("[i:268] Diving Helmet")]
        [Range(0, 10000)]
        [DefaultValue(33)]
        public int LootDivingHelmetIncrease;

        [Label("[i:437] Dual Hook")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootDualHookIncrease;

        [Label("[i:1943] Elf Hat")]
        [Range(0, 10000)]
        [DefaultValue(120)]
        public int LootElfHatIncrease;

        [Label("[i:1945] Elf Pants")]
        [Range(0, 10000)]
        [DefaultValue(120)]
        public int LootElfPantsIncrease;

        [Label("[i:1944] Elf Shirt")]
        [Range(0, 10000)]
        [DefaultValue(120)]
        public int LootElfShirtIncrease;

        [Label("[i:804] Eskimo Coat")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootEskimoCoatIncrease;

        [Label("[i:803] Eskimo Hood")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootEskimoHoodIncrease;

        [Label("[i:805] Eskimo Pants")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootEskimoPantsIncrease;

        [Label("[i:3349] Exotic Scimitar")]
        [Range(0, 10000)]
        [DefaultValue(2)]
        public int LootExoticScimitarIncrease;

        [Label("[i:1278] Eye Patch")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootEyePatchIncrease;

        [Label("[i:1311] Eye Spring")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootEyeSpringIncrease;

        [Label("[i:889] Fast Clock")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootFastClockBaseIncrease;

        [Label("[i:1871] Festive Wings")]
        [Range(0, 10000)]
        [DefaultValue(20)]
        public int LootFestiveWingsIncrease;

        [Label("[i:3013] Fetid Baghnakhs")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootFetidBaghnakhsIncrease;

        [Label("[i:1518] Fire Feather")]
        [Range(0, 10000)]
        [DefaultValue(27)]
        public int LootFireFeatherIncrease;

        [Label("[i:3016] Flesh Knuckles")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootFleshKnucklesIncrease;

        [Label("[i:3030] Flying Knife")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootFlyingKnifeIncrease;

        [Label("[i:726] Frost Staff")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootFrostStaffIncrease;

        [Label("[i:1253] Frozen Turtle Shell")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int LootFrozenTurtleShellIncrease;

        [Label("[i:1906] Giant Bow")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootGiantBowIncrease;

        [Label("[i:1516] Giant Harpy Feather")]
        [Range(0, 10000)]
        [DefaultValue(200)]
        public int LootGiantHarpyFeatherIncrease;

        [Label("[i:1704] Gold Furniture")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootGoldenFurnitureIncrease;

        [Label("[i:327] Golden Key")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootGoldenKeyIncrease;

        [Label("[i:1774] Goodie Bag")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootGoodieBagIncrease;

        [Label("[i:867] Green Cap (For non-Andrew Guide)")]
        [Range(0, 10000)]
        [DefaultValue(1)]
        public int LootGreenCapForNonAndrewGuide;

        [Label("[i:3548] Happy Grenade")]
        [Range(0, 10000)]
        [DefaultValue(2)]
        public int LootHappyGrenadeIncrease;

        [Label("[i:160] Harpoon")]
        [Range(0, 10000)]
        [DefaultValue(133)]
        public int LootHarpoonIncrease;

        [Label("[i:3290] Hel-Fire")]
        [Range(0, 10000)]
        [DefaultValue(400)]
        public int LootHelFireIncrease;

        [Label("[i:118] Hook")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootHookIncrease;

        [Label("[i:1306] Sickle")]
        [Range(0, 10000)]
        [DefaultValue(909)]
        public int LootIceSickleIncrease;

        [Label("[i:3022] Illuminant Hook")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootIlluminantHookIncrease;

        [Label("[i:1303] Jellyfish Necklace")]
        [Range(0, 10000)]
        [DefaultValue(25)]
        public int LootJellyfishNecklaceIncrease;

        [Label("[i:1314] KO Cannon")]
        [Range(0, 10000)]
        [DefaultValue(1000)]
        public int LootKOCannonIncrease;

        [Label("[i:671] Keybrand")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootKeybrandIncrease;

        [Label("[i:3291] Kraken")]
        [Range(0, 10000)]
        [DefaultValue(133)]
        public int LootKrakenIncrease;

        [Label("[i:3784] Lamia Clothes")]
        [Range(0, 10000)]
        [DefaultValue(100)]
        public int LootLamiaClothesIncrease;

        [Label("[i:3006] Life Drain")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootLifeDrainIncrease;

        [Label("[i:528] Light Shard")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootLightShardIncrease;

        [Label("[i:1293] Lihzahrd Power Cell")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootLihzahrdPowerCellIncrease;

        [Label("[i:2701] Living Fire Block")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootLivingFireBlockIncrease;

        [Label("[i:1172] Lizard Egg")]
        [Range(0, 10000)]
        [DefaultValue(111)]
        public int LootLizardEggIncrease;

        [Label("[i:517] Magic Dagger")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootMagicDaggerIncrease;

        [Label("[i:1321] Magic Quiver")]
        [Range(0, 10000)]
        [DefaultValue(27)]
        public int LootMagicQuiverIncrease;

        [Label("[i:1266] Magnet Sphere")]
        [Range(0, 10000)]
        [DefaultValue(588)]
        public int LootMagnetSphereIncrease;

        [Label("[i:3772] Mandible Blade")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootMandibleBladeIncrease;

        [Label("[i:682] Marrow")]
        [Range(0, 10000)]
        [DefaultValue(22)]
        public int LootMarrowIncrease;

        [Label("[i:996] Meat Grinder")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootMeatGrinderIncrease;

        [Label("[i:890] Megaphone")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootMegaphoneBaseIncrease;

        [Label("[i:116] Meteorite")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootMeteoriteIncrease;

        [Label("[i:88] Mining Helmet")]
        [Range(0, 10000)]
        [DefaultValue(4)]
        public int LootMiningHelmetIncrease;

        [Label("[i:411] Mining Pants")]
        [Range(0, 10000)]
        [DefaultValue(3)]
        public int LootMiningPantsIncrease;

        [Label("[i:410] Mining Shirt")]
        [Range(0, 10000)]
        [DefaultValue(3)]
        public int LootMiningShirtIncrease;

        [Label("[i:3213] Money Trough")]
        [Range(0, 10000)]
        [DefaultValue(25)]
        public int LootMoneyTroughIncrease;

        [Label("[i:485] Moon Charm")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootMoonCharmIncrease;

        [Label("[i:2801] Moon Mask")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootMoonMaskIncrease;

        [Label("[i:900] Moon Stone")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootMoonStoneIncrease;

        [Label("[i:2770] Mothron Wings")]
        [Range(0, 10000)]
        [DefaultValue(7)]
        public int LootMothronWingsIncrease;

        [Label("[i:870] Mummy Costume")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootMummyCostumeIncrease;

        [Label("[i:891] Nazar")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootNazarIncrease;

        [Label("[i:1244] Nimbus Rod")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootNimbusRodIncrease;

        [Label("[i:1323] Obsidian Rose")]
        [Range(0, 10000)]
        [DefaultValue(33)]
        public int LootObsidianRoseIncrease;

        [Label("[i:3350] Paintball Gun")]
        [Range(0, 10000)]
        [DefaultValue(2)]
        public int LootPaintballGunIncrease;

        [Label("[i:938] Paladin’s Shield")]
        [Range(0, 10000)]
        [DefaultValue(3)]
        public int LootPaladinsShieldIncrease;

        [Label("[i:3757] Pedguin’s Suit")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootPedguinssuitIncrease;


        [Label("[i:535] Philosopher’s Stone")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootPhilosophersStoneIncrease;

        [Label("[i:1315] Pirate Map")]
        [Range(0, 10000)]
        [DefaultValue(67)]
        public int LootPirateMapIncrease;

        [Label("[i:244] Plumber’s Hat")]
        [Range(0, 10000)]
        [DefaultValue(21)]
        public int LootPlumbersHatIncrease;

        [Label("[i:3781] Pocket Mirror")]
        [Range(0, 10000)]
        [DefaultValue(10)]
        public int LootPocketMirrorIncrease;

        [Label("[i:1869] Present")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootPresentIncrease;

        [Label("[i:3106] Psycho Knife")]
        [Range(0, 10000)]
        [DefaultValue(9)]
        public int LootPsychoKnifeIncrease;

        [Label("[i:3015] Putrid Scent")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootPutridScentIncrease;

        [Label("[i:1135] Rain Armor")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootRainArmorIncrease;

        [Label("[i:662] Rainbow Brick Max Increase (Min and Max in any order)")]
        [Range(0, 999)]
        public int[] LootRainbowBrickDrop = new int[] {0, 0};

        [Label("[i:3285] Rally")]
        [Range(0, 10000)]
        [DefaultValue(16)]
        public int LootRallyIncrease;

        [Label("[i:1914] Reindeer Bells")]
        [Range(0, 10000)]
        [DefaultValue(11)]
        public int LootReindeerBellsIncrease;

        [Label("[i:1300] Rifle Scope")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootRifleScopeIncrease;

        [Label("[i:263] Robot Hat")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootRobotHatIncrease;

        [Label("[i:759] Rocket Launcher")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootRocketLauncherIncrease;

        [Range(0, 10000)]
        [Label("[i:1326] Rod of Discord")]
        [DefaultValue(7)]
        public int LootRodofDiscordIncrease;

        [Range(0, 10000)]
        [Label("[i:1514] SWAT Helmet")]
        [DefaultValue(0)]
        public int LootSWATHelmetIncrease;

        [Label("[i:1277] Sailor Outfit")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootSailorOutfitIncrease;

        [Label("[i:216] Shackle")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootShackleIncrease;

        [Label("[i:1274] Skull")]
        [Range(0, 10000)]
        [DefaultValue(21)]
        public int LootSkullIncrease;

        [Tooltip("This is multiplied by 1 for Pinky, 80 for Sand Slime, and 100 for all other Slimes that drop it.")]
        [Label("[i:1309] Slime Staff (Hover for more info)")]
        [Range(0, 10000)]
        [DefaultValue(13)]
        public int LootSlimeStaffIncrease;

        [Label("[i:1254] Sniper Rifle")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootSniperRifleIncrease;

        [Label("[i:951] Snowball Launcher")]
        [Range(0, 10000)]
        [DefaultValue(75)]
        public int LootSnowballLauncherIncrease;

        [Label("[i:520] Soul of Light")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootSoulofLightIncrease;

        [Label("[i:521] Soul of Night")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootSoulofNightIncrease;

        [Label("[i:532] Star Cloak")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootStarCloakIncrease;

        [Label("[i:3352] Stylish Scissors")]
        [Range(0, 10000)]
        [DefaultValue(2)]
        public int LootStylishScissorsIncrease;

        [Label("[i:2802] Sun Mask")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootSunMaskIncrease;

        [Label("[i:977] Tabi")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootTabiIncrease;

        [Label("[i:679] Tactical Shotgun")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootTacticalShotgunIncrease;

        [Label("[i:3095] Tally Counter")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootTallyCounterIncrease;

        [Label("[i:1521] Tattered Bee Wing")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootTatteredBeeWingIncrease;

        [Label("[i:3020] Tendon Hook")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootTendonHookIncrease;

        [Label("[i:536] Titan Glove")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootTitanGloveIncrease;

        [Label("[i:1312] Toy Sled")]
        [Range(0, 10000)]
        [DefaultValue(7)]
        public int LootToySledIncrease;

        [Label("[i:893] Trifold Map")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootTrifoldMapIncrease;

        [Label("[i:1328] Turtle Shell")]
        [Range(0, 10000)]
        [DefaultValue(7)]
        public int LootTurtleShellIncrease;

        [Label("[i:1243] Umbrella Hat")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootUmbrellaHatIncrease;

        [Label("[i:856] Unicorn on a Stick")]
        [Range(0, 10000)]
        [DefaultValue(25)]
        public int LootUnicornonaStickIncrease;

        [Label("[i:1265] Uzi")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootUziIncrease;

        [Label("[i:879] Viking Helmet")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootVikingHelmetIncrease;

        [Label("[i:892] Vitamins")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int LootVitaminsIncrease;

        [Label("[i:215] Whoopie Cushion")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootWhoopieCushionIncrease;

        [Label("[i:1183] Wisp in a Bottle")]
        [Range(0, 10000)]
        [DefaultValue(159)]
        public int LootWispinaBottleIncrease;

        [Label("[i:3023] Worm Hook")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootWormHookIncrease;

        [Label("[i:3286] Yelets")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootYeletsIncrease;

        [Label("[i:1304] Zombie Arm")]
        [Range(0, 10000)]
        [DefaultValue(63)]
        public int LootZombieArmIncrease;

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

        [Header("Drops that don't happen in vanilla.")]

        [Label("[i:2673] Truffle Worm from Duke Fishron")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LootFishronTruffleworm;

        [Label("[i:3347] Desert Fossil from Dune Splicer (Min and Max in any order)")]
        [Range(0, 999)]
        public int[] LootDesertFossilFromDuneSplicer = new int[] { 0 , 0 };

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

        [Header("$Mods.ReducedGrinding.Common.WarPotion")]
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

        [Header("$Mods.ReducedGrinding.Common.ChaosPotion")]
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
