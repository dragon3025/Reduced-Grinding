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

using System.IO;
using System.Messaging;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding
{
	
	class ReducedGrinding : Mod
    {
		
		public override void Load()
		{
			ModTranslation text = CreateTranslation("Common.CavernLockboxLable");
			text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Cavern_Lock_Box>()}] Cavern Lockbox");
			AddTranslation(text);
			text = CreateTranslation("Common.DungeonBiomeLockboxLabel");
			text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Biome_Lock_Box>()}] Biome Lockbox");
			AddTranslation(text);
			text = CreateTranslation("Common.DungeonFurnitureLockboxLabel");
			text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Blue_Dungeon_Lock_Box>()}] Dungeon Furniture Lockbox");
			AddTranslation(text);
			text = CreateTranslation("Common.ShadowLockboxLable");
			text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Shadow_Lock_Box>()}] Shadow Lockbox");
			AddTranslation(text);
			text = CreateTranslation("Common.LihzahrdLockboxLable");
			text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Lihzahrd_Lock_Box>()}] Lihzahrd Lockbox");
			AddTranslation(text);
			text = CreateTranslation("Common.PyramidLockBoxLable");
			text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Pyramid_Lock_Box>()}] Pyramid Lockbox");
			AddTranslation(text);
			text = CreateTranslation("Common.SkywareLockBoxLable");
			text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Skyware_Lock_Box>()}] Skyware Lockbox");
			AddTranslation(text);
			text = CreateTranslation("Common.WebCoveredLockboxLable");
			text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Web_Covered_Lock_Box>()}] Web Covered Lockbox");
			AddTranslation(text);
			text = CreateTranslation("Common.LivingWoodLockBoxLable");
			text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Living_Wood_Lock_Box>()}] Living Wood Lockbox");
			AddTranslation(text);
			text = CreateTranslation("Common.IvyLockBoxLable");
			text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Ivy_Lock_Box>()}] Ivy Lockbox");
			AddTranslation(text);
			text = CreateTranslation("Common.IceLockBoxLable");
			text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Ice_Lock_Box>()}] Ice Lockbox");
			AddTranslation(text);
			text = CreateTranslation("Common.WaterLockBoxLable");
			text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Water_Lock_Box>()}] Water Lockbox");
			AddTranslation(text);
		}

		public ReducedGrinding()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
            };
        }

		public override void PostSetupContent()
		{
			Mod censusMod = ModLoader.GetMod("Census");
			if (censusMod != null)
			{
				censusMod.Call("TownNPCCondition", NPCType("BoneMerchant"), "Summon with a \"Skull Call\".");
				censusMod.Call("TownNPCCondition", NPCType("ChestSalesman"), "No conditions.");
				censusMod.Call("TownNPCCondition", NPCType("LootMerchant"), "No conditions.");
				censusMod.Call("TownNPCCondition", NPCType("Santa"), "Defeat the Frost Legion.");
				censusMod.Call("TownNPCCondition", NPCType("StationaryMerchant"), "No conditions.");
			}
		}

		public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
			ReducedGrindingMessageType msgType = (ReducedGrindingMessageType)reader.ReadByte();
			switch (msgType)
			{
				case ReducedGrindingMessageType.skipToNight:
					ReducedGrindingWorld.skipToNight = reader.ReadBoolean();
					break;
				case ReducedGrindingMessageType.skipToDay:
					ReducedGrindingWorld.skipToDay = reader.ReadBoolean();
					break;
				case ReducedGrindingMessageType.advanceMoonPhase:
					ReducedGrindingWorld.advanceMoonPhase = reader.ReadBoolean();
					break;
			}
		}

        public class BossBags : GlobalItem  //Rates show in comments are in addition to vanilla rates.
		{
			public override void OpenVanillaBag(string context, Player player, int arg)
			{
				
				//Boss Bags
				if (arg == ItemID.BrainOfCthulhuBossBag)
				{
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBoneRattleIncrease)
					{
						player.QuickSpawnItem(ItemID.BoneRattle, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2104, 1); //Mask
					}
				}
				else if (arg == ItemID.FishronBossBag)
				{
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootFishronWingsIncrease)
					{
						player.QuickSpawnItem(ItemID.FishronWings, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootFishronTruffleworm)
					{
						player.QuickSpawnItem(2673, 1); //Truffleworm
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2588, 1); //Mask
					}
				}
				else if (arg == ItemID.EaterOfWorldsBossBag)
				{
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootEatersBoneIncrease)
					{
						player.QuickSpawnItem(ItemID.EatersBone, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2111, 1); //Mask
					}
				}
				else if (arg == ItemID.EyeOfCthulhuBossBag)
				{
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBinocularsIncrease)
					{
						player.QuickSpawnItem(ItemID.Binoculars, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2112, 1); //Mask
					}
				}
				else if (arg == ItemID.PlanteraBossBag)
				{
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootTheAxeIncrease)
					{
						player.QuickSpawnItem(ItemID.TheAxe, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSeedlingIncrease)
					{
						player.QuickSpawnItem(ItemID.Seedling, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2109, 1); //Mask
					}
				}
				else if (arg == ItemID.QueenBeeBossBag)
				{
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootHoneyedGogglesIncrease)
					{
						player.QuickSpawnItem(ItemID.HoneyedGoggles, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootNectarIncrease)
					{
						player.QuickSpawnItem(ItemID.Nectar, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2108, 1); //Mask
					}
				}
				else if (arg == ItemID.MoonLordBossBag)
				{
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease)
					{
						player.QuickSpawnItem(ItemID.Meowmere, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease)
					{
						player.QuickSpawnItem(ItemID.Terrarian, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease)
					{
						player.QuickSpawnItem(ItemID.StarWrath, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease)
					{
						player.QuickSpawnItem(ItemID.SDMG, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease)
					{
						player.QuickSpawnItem(ItemID.FireworksLauncher, 1); //Celebration
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease)
					{
						player.QuickSpawnItem(ItemID.LastPrism, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease)
					{
						player.QuickSpawnItem(ItemID.LunarFlareBook, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease)
					{
						player.QuickSpawnItem(ItemID.RainbowCrystalStaff, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease)
					{
						player.QuickSpawnItem(ItemID.MoonlordTurretStaff, 1); //Lunar Portal Staff
					}
				}
				else if (arg == ItemID.SkeletronBossBag)
				{
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBookofSkullsIncrease)
					{
						player.QuickSpawnItem(ItemID.BookofSkulls, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSkeletronBoneKey)
					{
						player.QuickSpawnItem(ItemID.BookofSkulls, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
					{
						player.QuickSpawnItem(1281, 1); //Mask
					}
				}
				else if (arg == 3318) //King Slime
				{
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2493, 1); //Mask
					}
				}
				else if (arg == 3324) //Wall of Flesh
				{
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2105, 1); //Mask
					}
				}
				else if (arg == 3325) //The Destroyer
				{
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2113, 1); //Mask
					}
				}
				else if (arg == 3326) //The Twins
				{
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2106, 1); //Mask
					}
				}
				else if (arg == 3327) //Skeletron Prime
				{
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2107, 1); //Mask
					}
				}
				else if (arg == 3329) //Golem
				{
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2110, 1); //Mask
					}
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPicksawIncrease)
					{
						player.QuickSpawnItem(1294, 1); //Picksaw
					}
				}
				else if (arg == 3332) //Moon Lord
				{
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
					{
						player.QuickSpawnItem(3373, 1); //Mask
					}
				}
				else if (arg == 3860) //Betsy
				{
					if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
					{
						player.QuickSpawnItem(3863, 1); //Mask
					}
				}
				
				//Crates
				else if (arg == 3205) //Dungeon Crate
				{
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateDungeonBoneWelder)
					{
						player.QuickSpawnItem(ItemID.BoneWelder, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateDungeonHardmodeGoldenLockBoxIncrease && Main.hardMode)
					{
						player.QuickSpawnItem(ItemID.LockBox, 1);
					}
				}
				else if (arg == ItemID.JungleFishingCrate)
				{
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateJungleSeaweed)
					{
						player.QuickSpawnItem(ItemID.Seaweed, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateJungleFlowerBoots)
					{
						player.QuickSpawnItem(ItemID.FlowerBoots, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateJungleLivingMahoganyWand)
					{
						player.QuickSpawnItem(ItemID.LivingMahoganyWand, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateJungleRichMahoganyLeafWand)
					{
						player.QuickSpawnItem(ItemID.LivingMahoganyLeafWand, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateJungleLivingLoom)
					{
						player.QuickSpawnItem(ItemID.LivingLoom, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateJungleLeafWand)
					{
						player.QuickSpawnItem(ItemID.LeafWand, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateJungleLivingWoodWand)
					{
						player.QuickSpawnItem(ItemID.LivingWoodWand, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateJungleAnkeltOfTheWindIncrease)
					{
						player.QuickSpawnItem(212, 1); //Anklet of the Wind
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateJungleFeralClawsIncrease)
					{
						player.QuickSpawnItem(211, 1); //Feral Claws
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateJungleStaffOfRegrowth)
					{
						player.QuickSpawnItem(213, 1); //Staff Of Regrowth
					}
				}
				else if (arg == 3206) //Sky Crate
				{
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateSkySkyMill)
					{
						player.QuickSpawnItem(2197, 1); //Sky Mill
					}
				}
				else if (arg == ItemID.WoodenCrate)
				{
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateWoodenClimbingClawsIncrease)
					{
						player.QuickSpawnItem(953, 1); //Climbing Claws
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateWoodenRadarIncrease)
					{
						player.QuickSpawnItem(3084, 1); //Radar
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateWoodenAgletIncrease)
					{
						player.QuickSpawnItem(285, 1); //Aglet
					}
				}
				else if (arg == ItemID.WoodenCrate)
				{
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateWaterWalkingBootsWooden)
					{
						player.QuickSpawnItem(863, 1); //Water walking boots
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateFlippersWooden)
					{
						player.QuickSpawnItem(187, 1); //Flipper
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateEnchantedSundialWoodenIncrease)
					{
						player.QuickSpawnItem(3064, 1); //Enchanted Sundial
					}
				}
				else if (arg == ItemID.IronCrate)
				{
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateWaterWalkingBootsIron)
					{
						player.QuickSpawnItem(863, 1); //Water walking boots
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateFlippersIron)
					{
						player.QuickSpawnItem(187, 1); //Flipper
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateEnchantedSundialIronIncrease)
					{
						player.QuickSpawnItem(3064, 1); //Enchanted Sundial
					}
				}
				else if (arg == ItemID.GoldenCrate)
				{
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateWaterWalkingBootsGolden)
					{
						player.QuickSpawnItem(863, 1); //Water walking boots
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateFlippersGolden)
					{
						player.QuickSpawnItem(187, 1); //Flipper
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().CrateEnchantedSundialGoldenIncrease)
					{
						player.QuickSpawnItem(3064, 1); //Enchanted Sundial
					}
				}
				else if (context == "present")
				{
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentDogWhistle)
					{
						player.QuickSpawnItem(1927, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentToolbox)
					{
						player.QuickSpawnItem(1923, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentHandWarmer)
					{
						player.QuickSpawnItem(1921, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentCandyCanePickaxe)
					{
						player.QuickSpawnItem(1917, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentCandyCaneHook)
					{
						player.QuickSpawnItem(1915, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentFruitcakeChakram)
					{
						player.QuickSpawnItem(1918, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentRedRyderPlusMusketBall)
					{
						player.QuickSpawnItem(1870, 1);
						player.QuickSpawnItem(97, Main.rand.Next(30,60));
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentCandyCaneSword)
					{
						player.QuickSpawnItem(1909, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentMrsClausCostume)
					{
						player.QuickSpawnItem(1932, 1);
						player.QuickSpawnItem(1933, 1);
						player.QuickSpawnItem(1934, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentParkaOutfit)
					{
						player.QuickSpawnItem(1935, 1);
						player.QuickSpawnItem(1936, 1);
						player.QuickSpawnItem(1937, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentTreeCostume)
					{
						player.QuickSpawnItem(1940, 1);
						player.QuickSpawnItem(1941, 1);
						player.QuickSpawnItem(1942, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentSnowHat)
					{
						player.QuickSpawnItem(1938, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentUglySweater)
					{
						player.QuickSpawnItem(1939, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentReindeerAntlers)
					{
						player.QuickSpawnItem(1907, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentCoal)
					{
						player.QuickSpawnItem(1922, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentChristmasPudding)
					{
						player.QuickSpawnItem(1911, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentSugarCookie)
					{
						player.QuickSpawnItem(1919, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentGingerbreadCookie)
					{
						player.QuickSpawnItem(1920, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentStarAnise)
					{
						player.QuickSpawnItem(1913, Main.rand.Next(20,40));
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentEggnog)
					{
						player.QuickSpawnItem(1912, Main.rand.Next(1,3));
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentHolly)
					{
						player.QuickSpawnItem(1908, 1);
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentPineTreeBlock)
					{
						player.QuickSpawnItem(1872, Main.rand.Next(20,49));
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentCandyCaneBlock)
					{
						player.QuickSpawnItem(586, Main.rand.Next(20,49));
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentGreenCandyCaneBlock)
					{
						player.QuickSpawnItem(591, Main.rand.Next(20,49));
					}
					if (Main.rand.NextFloat() < GetInstance<BGrabBagConfig>().PresentHardmodeSnowGlobe)
					{
						player.QuickSpawnItem(602, 1);
					}
				}
            }
			
			public override void ExtractinatorUse(int extractType, ref int resultType, ref int resultStack)
			{
				
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
					if (Main.rand.NextFloat() * amberMosquitoMultiplier < GetInstance<DExtractinatorConfig>().ExtractinatorGivesAmberMosquito)
					{
						resultStack = 1;
						resultType = ItemID.AmberMosquito;
					}
					else if (Main.rand.NextFloat() * gemMultiplier < GetInstance<DExtractinatorConfig>().ExtractinatorGivesDiamond)
					{
						resultStack = 1;
						resultType = ItemID.Diamond;
					}
					else if (Main.rand.NextFloat() * gemMultiplier < GetInstance<DExtractinatorConfig>().ExtractinatorGivesRuby)
					{
						resultStack = 1;
						resultType = ItemID.Ruby;
					}
					else if (Main.rand.NextFloat() * gemMultiplier < GetInstance<DExtractinatorConfig>().ExtractinatorGivesEmerald)
					{
						resultStack = 1;
						resultType = ItemID.Emerald;
					}
					else if (Main.rand.NextFloat() * gemMultiplier < GetInstance<DExtractinatorConfig>().ExtractinatorGivesSapphire)
					{
						resultStack = 1;
						resultType = ItemID.Sapphire;
					}
					else if (Main.rand.NextFloat() * gemMultiplier < GetInstance<DExtractinatorConfig>().ExtractinatorGivesTopaz)
					{
						resultStack = 1;
						resultType = ItemID.Topaz;
					}
					else if (Main.rand.NextFloat() * gemMultiplier < GetInstance<DExtractinatorConfig>().ExtractinatorGivesAmethyst)
					{
						resultStack = 1;
						resultType = ItemID.Amethyst;
					}
					else if (Main.rand.NextFloat() * amberMultiplier < GetInstance<DExtractinatorConfig>().ExtractinatorGivesAmber)
					{
						resultStack = 1;
						resultType = ItemID.Amber;
					}
					else if (Main.rand.NextFloat() < GetInstance<DExtractinatorConfig>().ExtractinatorGivesGoldOre)
					{
						resultStack = 1;
						resultType = ItemID.GoldOre;
					}
					else if (Main.rand.NextFloat() < GetInstance<DExtractinatorConfig>().ExtractinatorGivesPlatinumOre)
					{
						resultStack = 1;
						resultType = ItemID.PlatinumOre;
					}
					else if (Main.rand.NextFloat() < GetInstance<DExtractinatorConfig>().ExtractinatorGivesFossilOre && extractType == 3347)
					{
						resultStack = 1;
						resultType = ItemID.FossilOre;
					}
					else if (Main.rand.NextFloat() < GetInstance<DExtractinatorConfig>().ExtractinatorGivesSilverOre)
					{
						resultStack = 1;
						resultType = ItemID.SilverOre;
					}
					else if (Main.rand.NextFloat() < GetInstance<DExtractinatorConfig>().ExtractinatorGivesTungstenOre)
					{
						resultStack = 1;
						resultType = ItemID.TungstenOre;
					}
					else if (Main.rand.NextFloat() < GetInstance<DExtractinatorConfig>().ExtractinatorGivesIronOre)
					{
						resultStack = 1;
						resultType = ItemID.IronOre;
					}
					else if (Main.rand.NextFloat() < GetInstance<DExtractinatorConfig>().ExtractinatorGivesLeadOre)
					{
						resultStack = 1;
						resultType = ItemID.LeadOre;
					}
					else if (Main.rand.NextFloat() < GetInstance<DExtractinatorConfig>().ExtractinatorGivesCopperOre)
					{
						resultStack = 1;
						resultType = ItemID.CopperOre;
					}
					else if (Main.rand.NextFloat() < GetInstance<DExtractinatorConfig>().ExtractinatorGivesTinOre)
					{
						resultStack = 1;
						resultType = ItemID.TinOre;
					}
					else if (Main.rand.NextFloat() < GetInstance<DExtractinatorConfig>().ExtractinatorGivesPlatinumCoin)
					{
						resultStack = 1;
						resultType = ItemID.PlatinumCoin;
					}
					else if (Main.rand.NextFloat() < GetInstance<DExtractinatorConfig>().ExtractinatorGivesGoldCoin)
					{
						resultStack = 1;
						resultType = ItemID.GoldCoin;
					}
					else if (Main.rand.NextFloat() < GetInstance<DExtractinatorConfig>().ExtractinatorGivesSilverCoin)
					{
						resultStack = 1;
						resultType = ItemID.SilverCoin;
					}
					else if (Main.rand.NextFloat() < GetInstance<DExtractinatorConfig>().ExtractinatorGivesCopperCoin)
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
				if (npc.lifeMax > 5 && npc.type != NPCID.Bee && npc.type != NPCID.BeeSmall)
				{
					Player player = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];
					float difficultyMultiplier = 1f;
					if (!Main.expertMode)
						difficultyMultiplier = GetInstance<AEnemyDropConfig>().NormalModeMultiplierForLootWithSeperateDiffRates;

					int npcTileX;
					int npcTileY;
					npcTileX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
					npcTileY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;

					//Biome Key Bonus From Mech Bosses Downed
					int mechBossesDowned = 0;
					float keyDropRateIncrease = 0;

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
						if (mechBossesDowned == 1)
						{
							keyDropRateIncrease = GetInstance<AEnemyDropConfig>().BiomeKeyIncreaseForOneMechBossDown;
						}
						else if (mechBossesDowned == 2)
						{
							keyDropRateIncrease = GetInstance<AEnemyDropConfig>().BiomeKeyIncreaseForTwoMechBossDown;
						}
						else if (mechBossesDowned == 3)
						{
							keyDropRateIncrease = GetInstance<AEnemyDropConfig>().BiomeKeyIncreaseForThreeMechBossDown;
						}
					}

					//Ankh Charm Material Bonus
					bool hasBlindfold = false;
					bool hasArmorPolish = false;
					bool hasVitamins = false;
					bool hasBezoar = false;
					bool hasAdhesiveBandage = false;
					bool hasMegaphone = false;
					bool hasNazar = false;
					bool hasFastClock = false;
					bool hasTrifoldMap = false;
					int AnkhCharmInInventory = 0;

					for (int i = 0; i < player.armor.Length; i++)
					{
						if (player.armor[i].type == ItemID.Blindfold)
							hasBlindfold = true;
						else if (player.armor[i].type == ItemID.ArmorPolish)
							hasArmorPolish = true;
						else if (player.armor[i].type == ItemID.Vitamins)
							hasVitamins = true;
						else if (player.armor[i].type == ItemID.ArmorBracing)
						{
							hasArmorPolish = true;
							hasVitamins = true;
						}
						else if (player.armor[i].type == ItemID.AdhesiveBandage)
							hasAdhesiveBandage = true;
						else if (player.armor[i].type == ItemID.Bezoar)
							hasBezoar = true;
						else if (player.armor[i].type == ItemID.MedicatedBandage)
						{
							hasAdhesiveBandage = true;
							hasBezoar = true;
						}
						else if (player.armor[i].type == ItemID.Nazar)
							hasNazar = true;
						else if (player.armor[i].type == ItemID.Megaphone)
							hasMegaphone = true;
						else if (player.armor[i].type == ItemID.CountercurseMantra)
						{
							hasNazar = true;
							hasMegaphone = true;
						}
						else if (player.armor[i].type == ItemID.TrifoldMap)
							hasTrifoldMap = true;
						else if (player.armor[i].type == ItemID.FastClock)
							hasFastClock = true;
						else if (player.armor[i].type == ItemID.ThePlan)
						{
							hasTrifoldMap = true;
							hasFastClock = true;
						}
					}

					if (player.HasItem(ItemID.Blindfold))
						hasBlindfold = true;
					if (player.HasItem(ItemID.ArmorBracing))
					{
						hasArmorPolish = true;
						hasVitamins = true;
					}
					else
					{
						if (player.HasItem(ItemID.ArmorPolish))
							hasArmorPolish = true;
						if (player.HasItem(ItemID.Vitamins))
							hasVitamins = true;
					}
					if (player.HasItem(ItemID.MedicatedBandage))
					{
						hasBezoar = true;
						hasAdhesiveBandage = true;
					}
					else
					{
						if (player.HasItem(ItemID.Bezoar))
							hasBezoar = true;
						if (player.HasItem(ItemID.AdhesiveBandage))
							hasAdhesiveBandage = true;
					}
					if (player.HasItem(ItemID.CountercurseMantra))
					{
						hasMegaphone = true;
						hasNazar = true;
					}
					else
					{
						if (player.HasItem(ItemID.Megaphone))
							hasMegaphone = true;
						if (player.HasItem(ItemID.Nazar))
							hasNazar = true;
					}
					if (player.HasItem(903)) //The Plan
					{
						hasFastClock = true;
						hasTrifoldMap = true;
					}
					else
					{
						if (player.HasItem(889)) //Fast Clock
							hasFastClock = true;
						if (player.HasItem(893)) //Trifold Map
							hasTrifoldMap = true;
					}

					if (hasBlindfold)
						AnkhCharmInInventory++;
					if (hasArmorPolish)
						AnkhCharmInInventory++;
					if (hasVitamins)
						AnkhCharmInInventory++;
					if (hasBezoar)
						AnkhCharmInInventory++;
					if (hasAdhesiveBandage)
						AnkhCharmInInventory++;
					if (hasMegaphone)
						AnkhCharmInInventory++;
					if (hasNazar)
						AnkhCharmInInventory++;
					if (hasFastClock)
						AnkhCharmInInventory++;
					if (hasTrifoldMap)
						AnkhCharmInInventory++;

					float AnkhMaterialBonus = AnkhCharmInInventory * GetInstance<AEnemyDropConfig>().LootAnkhCharmMaterialIncreasePerAnkhCharmInInventory * difficultyMultiplier;

					for (int j = 0; j < GetInstance<AEnemyDropConfig>().DropTriesForAllEnemyDroppedLoot; j++)
					{
						//Biome Keys
						if (Main.hardMode && Main.rand.NextFloat() < keyDropRateIncrease)
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

						//Boss Loot
						if (npc.type == NPCID.SkeletronHead)
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSkeletronBoneKey * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneKey, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBookofSkullsIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BookofSkulls, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1281, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1363, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == NPCID.BrainofCthulhu)
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBoneRattleIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneRattle, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2104, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1362, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == NPCID.DukeFishron)
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootFishronWingsIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FishronWings, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootFishronTruffleworm * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2673, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2588, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2589, 1, false, -1, false, false); //Trophy
						}
						if (npc.type >= 13 && npc.type <= 15 && npc.boss) //Eater of Worlds
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootEatersBoneIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EatersBone, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2111, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1361, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == NPCID.EyeofCthulhu)
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBinocularsIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Binoculars, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2112, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1360, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == NPCID.Plantera)
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootTheAxeIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TheAxe, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSeedlingIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Seedling, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2109, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1370, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == NPCID.QueenBee)
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootHoneyedGogglesIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HoneyedGoggles, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootNectarIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Nectar, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2108, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1364, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == NPCID.KingSlime)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2493, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2489, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == NPCID.WallofFlesh)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2105, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1365, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == NPCID.TheDestroyer)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2113, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1366, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism) //The Twins
						{
							if (!Main.expertMode)
							{
								int oppositeTwin = 125;
								if (npc.type == 125)
									oppositeTwin = 126;
								if (!NPC.AnyNPCs(oppositeTwin) && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2106, 1, false, -1, false, false);
							}
							if (npc.type == 125 && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease) //Retinazer
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1368, 1, false, -1, false, false); //Trophy
							if (npc.type == 126 && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease) //Spazmatism
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1369, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == NPCID.SkeletronPrime)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2113, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1367, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == NPCID.Golem)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2110, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1371, 1, false, -1, false, false); //Trophy
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPicksawIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1371, 1, false, -1, false, false); //Picksaw
						}
						if (npc.type == NPCID.DukeFishron)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2588, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2589, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == NPCID.CultistBoss)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3372, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3357, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == NPCID.MoonLordCore)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3595, 1, false, -1, false, false); //Trophy
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3373, 1, false, -1, false, false); //Mask
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease * difficultyMultiplier)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Meowmere, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease * difficultyMultiplier)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Terrarian, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease * difficultyMultiplier)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.StarWrath, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease * difficultyMultiplier)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SDMG, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease * difficultyMultiplier)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FireworksLauncher, 1, false, -1, false, false); //Celebration
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease * difficultyMultiplier)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LastPrism, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease * difficultyMultiplier)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LunarFlareBook, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease * difficultyMultiplier)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RainbowCrystalStaff, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease * difficultyMultiplier)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonlordTurretStaff, 1, false, -1, false, false); //Lunar Portal Staff
								}
							}
						}
						if (npc.type == NPCID.DD2Betsy)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3863, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3866, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == NPCID.DD2DarkMageT1)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3864, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3867, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == NPCID.DD2DarkMageT3)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease / 2)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3864, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3867, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == NPCID.DD2OgreT2)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3865, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3868, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == NPCID.DD2OgreT3)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossMaskIncrease / 2)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3865, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3868, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == NPCID.Everscream)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootFestiveWingsIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FestiveWings, 1, false, -1, false, false);
						}
						if (npc.type == NPCID.IceQueen)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBabyGrinchsMischiefWhistleIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BabyGrinchMischiefWhistle, 1, false, -1, false, false);
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootReindeerBellsIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ReindeerBells, 1, false, -1, false, false);
						}
						if (npc.type == NPCID.PirateShip)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3359, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == NPCID.MartianSaucerCore)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3358, 1, false, -1, false, false); //Trophy
							if (Main.rand.NextFloat() < GetInstance<HOtherModdedItemsConfig>().MartianSaucerMartianCallDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Martian_Call"), 1, false, -1, false, false);
						}



						//Other Loot
						int sandmin = 0;
						int sandmax = 0;
						int sandtype = ItemID.SandBlock;
						if (player.ZoneHoly)
							sandtype = ItemID.PearlsandBlock;
						else if (player.ZoneCorrupt)
							sandtype = ItemID.EbonsandBlock;
						else if (player.ZoneCrimson)
							sandtype = ItemID.CrimsandBlock;
						if (npc.type == NPCID.DuneSplicerHead)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDesertFossilFromDuneSplicer)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DesertFossil, 1, false, -1, false, false);
							}
							sandmin = GetInstance<AEnemyDropConfig>().LootMinSandFromDuneSplicer;
							sandmax = GetInstance<AEnemyDropConfig>().LootMaxSandFromDuneSplicer;
							if (sandmin > 0 && sandmax > 0 && sandmax > sandmin)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, sandtype, Main.rand.Next(sandmin, sandmax + 1), false, -1, false, false);
							}
						}
						if (npc.type == NPCID.TombCrawlerHead)
						{
							sandmin = GetInstance<AEnemyDropConfig>().LootMinSandFromTombCrawler;
							sandmax = GetInstance<AEnemyDropConfig>().LootMaxSandFromTombCrawler;
							if (sandmin > 0 && sandmax > 0 && sandmax > sandmin)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, sandtype, Main.rand.Next(sandmin, sandmax + 1), false, -1, false, false);
							}
						}
						if (npc.type == NPCID.AnglerFish || npc.type == NPCID.Piranha)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootRobotHatIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RobotHat, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.AnglerFish || (npc.type >= 269 && npc.type <= 272) || npc.type == NPCID.Werewolf) //269 to 272 is Rusty Armored Bones
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAdhesiveBandageIncrease * difficultyMultiplier + AnkhMaterialBonus)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AdhesiveBandage, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.ChaosElemental && GetInstance<AEnemyDropConfig>().LootRodofDiscordIncrease > 0)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootRodofDiscordIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RodofDiscord, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Clown || npc.type == NPCID.LightMummy || npc.type == NPCID.GiantBat)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootTrifoldMapIncrease * difficultyMultiplier + AnkhMaterialBonus)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TrifoldMap, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Clown)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBananarangIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bananarang, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.EnchantedSword || npc.type == NPCID.CrimsonAxe || npc.type == NPCID.CursedHammer || npc.type == NPCID.CursedSkull)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootNazarIncrease * difficultyMultiplier + AnkhMaterialBonus)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Nazar, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Hornet || (npc.type >= 231 && npc.type <= 235)) //Hornet
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMegaphoneBaseIncrease * difficultyMultiplier + AnkhMaterialBonus)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Megaphone, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientCobaltHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltHelmet, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientCobaltBreastplateIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltBreastplate, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientCobaltLeggingsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltLeggings, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootHiveBlockFromHornetsAndMossHornetsAfterQueenBeDowned && NPC.downedQueenBee)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Hive, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.MossHornet)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootTatteredBeeWingIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TatteredBeeWing, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootHiveBlockFromHornetsAndMossHornetsAfterQueenBeDowned && NPC.downedQueenBee)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Hive, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Corruptor || npc.type == NPCID.FloatyGross)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootVitaminsIncrease * difficultyMultiplier + AnkhMaterialBonus)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Vitamins, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Crimslime || npc.type == NPCID.BigCrimslime || npc.type == NPCID.LittleCrimslime)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBlindfoldIncrease * difficultyMultiplier + AnkhMaterialBonus)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Blindfold, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Mummy || npc.type == NPCID.Pixie || npc.type == NPCID.Wraith)
						{
							int fastClockMultiplier = 1;
							if (npc.type != NPCID.Pixie)
								fastClockMultiplier = 2;
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootFastClockBaseIncrease * difficultyMultiplier * fastClockMultiplier + AnkhMaterialBonus)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FastClock, 1, false, -1, false, false);
							}
						}
						if (Main.tile[npcTileX, npcTileY].wall == WallID.LihzahrdBrickUnsafe && NPC.downedPlantBoss)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootLizardEggIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LizardEgg, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootLihzahrdPowerCellIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LihzahrdPowerCell, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.GiantTortoise && GetInstance<AEnemyDropConfig>().LootTurtleShellIncrease > 0)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootTurtleShellIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TurtleShell, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.IceTortoise && GetInstance<AEnemyDropConfig>().LootFrozenTurtleShellIncrease > 0)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootFrozenTurtleShellIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FrozenTurtleShell, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Paladin)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPaladinsShieldIncrease * difficultyMultiplier)
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
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().PirateLootCoinGunBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CoinGun, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().PirateLootLuckyCoinBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LuckyCoin, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().PirateLootDiscountCardBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DiscountCard, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().PirateLootPirateStaffBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PirateStaff, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().PirateLootGoldRingBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldRing, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().PirateLootCutlassBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cutlass, 1, false, -1, false, false);
							}
							if (npc.type != NPCID.PirateCaptain && npc.type != NPCID.PirateShip)
							{
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSailorHatIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SailorHat, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSailorShirtIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SailorShirt, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSailorPantsIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SailorPants, 1, false, -1, false, false);
								}
							}
							if (GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease > 0 && npc.type != NPCID.PirateCaptain && npc.type != NPCID.PirateShip)
							{
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenChair, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenToilet, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenDoor, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenTable, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenBed, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenPiano, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenDresser, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenSofa, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenBathtub, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenClock, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenLamp, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenBookcase, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenChandelier, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenLantern, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenCandelabra, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenCandle, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
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
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMegaphoneBaseIncrease * difficultyMultiplier * megaphoneMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Megaphone, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.ArmoredSkeleton || (npc.type >= 273 && npc.type <= 276)) //Blue Amored Bones and Armored Skeleton
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootArmorPolishIncrease * difficultyMultiplier + AnkhMaterialBonus)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ArmorPolish, 1, false, -1, false, false);
							}
						}
						if ((npc.type == NPCID.ZombieElf || npc.type == NPCID.ZombieElfBeard || npc.type == NPCID.ZombieElfGirl))
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootElfHatIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ElfHat, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootElfShirtIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ElfShirt, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootElfPantsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ElfPants, 1, false, -1, false, false);
							}
						}
						if (npc.type >= 269 && npc.type <= 280)//All Armored Bones variants
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootWispinaBottleIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WispinaBottle, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBoneFeatherIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneFeather, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMagnetSphereIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagnetSphere, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootKeybrandIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Keybrand, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.EaterofSouls)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientShadowHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientShadowHelmet, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientShadowScalemailIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientShadowScalemail, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientShadowGreavesIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientShadowGreaves, 1, false, -1, false, false);
							}
						}
						if (npc.type == 21 || (npc.type >= 201 && npc.type <= 203) || (npc.type >= 322 && npc.type <= 323) || (npc.type >= 449 && npc.type <= 452)) //Skeleton
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSkullIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Skull, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBoneSwordIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneSword, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientGoldHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientGoldHelmet, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientIronHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientIronHelmet, 1, false, -1, false, false);
							}
						}
						if (npc.type == 31 || (npc.type >= 294 && npc.type <= 296)) //Angry Bones
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientNecroHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientNecroHelmet, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootClothierVoodooDollIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ClothierVoodooDoll, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBoneWandIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneWand, 1, false, -1, false, false);
							}
						}
						if (player.ZoneUnderworldHeight)
						{
							
							if (Main.hardMode)
							{
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootHelFireIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HelFire, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootLivingFireBlockIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LivingFireBlock, 1, false, -1, false, false);
								}
							}
							else if (NPC.downedBoss3) //Skeletron
							{
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootCascadeIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cascade, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.ManEater)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientCobaltHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltHelmet, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientCobaltBreastplateIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltBreastplate, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientCobaltLeggingsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltLeggings, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.FireImp)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPlumbersHatIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PlumbersHat, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootObsidianRoseIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ObsidianRose, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.CursedSkull || npc.type == NPCID.DarkCaster)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBoneWandIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneWand, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.CaveBat)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootChainKnifeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ChainKnife, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Reaper)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDeathSickleIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1327, 1, false, -1, false, false); //Death Sickle
							}
						}
						if (npc.type == 3 || npc.type == 132 || npc.type == 161 || (npc.type >= 186 && npc.type <= 200) || npc.type == 223 || (npc.type >= 430 && npc.type <= 436)) //Normal Zombie Variants, Raincoat Zombie, and Zombie Eskimo
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootZombieArmIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ZombieArm, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootShackleIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Shackle, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Pixie || npc.type == NPCID.Unicorn || npc.type == NPCID.RainbowSlime || npc.type == NPCID.Gastropod || npc.type == NPCID.LightMummy || npc.type == NPCID.IlluminantSlime || npc.type == NPCID.IlluminantBat || npc.type == NPCID.ChaosElemental || npc.type == NPCID.EnchantedSword || npc.type == NPCID.BigMimicHallow) //Hallow Enemies
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBlessedAppleIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlessedApple, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Mimic)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDualHookIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DualHook, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMagicDaggerIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagicDagger, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootTitanGloveIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TitanGlove, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPhilosophersStoneIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PhilosophersStone, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootCrossNecklaceIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CrossNecklace, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootStarCloakIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.StarCloak, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.BigMimicCorruption)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDartRifleIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DartRifle, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootWormHookIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WormHook, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootChainGuillotinesIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ChainGuillotines, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootClingerStaffIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ClingerStaff, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPutridScentIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PutridScent, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.BigMimicCrimson)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootLifeDrainIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulDrain, 1, false, -1, false, false);//Life Drain
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDartPistolIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DartPistol, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootFetidBaghnakhsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FetidBaghnakhs, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootFleshKnucklesIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FleshKnuckles, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootTendonHookIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TendonHook, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.BigMimicHallow)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDaedalusStormbowIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DaedalusStormbow, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootFlyingKnifeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FlyingKnife, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootCrystalVileShardIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CrystalVileShard, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootIlluminantHookIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IlluminantHook, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Harpy)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGiantHarpyFeatherIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GiantHarpyFeather, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootCloudFromHarpies)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cloud, 1, false, -1, false, false);
							}
						}
						if ((npc.type >= 26 && npc.type <= 29) || npc.type == 111) //Goblin Army (Excluding Summoner)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootHarpoonIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Harpoon, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.ArmoredViking || npc.type == NPCID.IceElemental || npc.type == NPCID.IcyMerman || npc.type == NPCID.IceTortoise)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootIceSickleIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IceSickle, 1, false, -1, false, false);
							}
						}
						if (npc.type >= 269 && npc.type <= 293)// Post-plantera dungeon enemies
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootKrakenIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Kraken, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.SkeletonArcher)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMarrowIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Marrow, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMagicQuiverIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagicQuiver, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Crimslime || npc.type == NPCID.CrimsonAxe || npc.type == NPCID.FloatyGross || npc.type == NPCID.Herpling)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMeatGrinderIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MeatGrinder, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.AngryTrapper)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootUziIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Uzi, 1, false, -1, false, false);
							}
						}
						if (NPC.downedMechBoss1 && player.ZoneJungle)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootYeletsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Yelets, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.ArmoredSkeleton)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBeamSwordIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BeamSword, 1, false, -1, false, false);
							}
						}
						if (npc.type == 2 || (npc.type >= 190 && npc.type <= 194) || npc.type == 317 || npc.type == 318) //Demon Eye and Wandering Eye
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBlackLensIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlackLens, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.ZombieEskimo || npc.type == NPCID.ArmedZombieEskimo)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootEskimoHoodIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EskimoHood, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootEskimoCoatIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EskimoCoat, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootEskimoPantsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EskimoPants, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Hellbat)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().HellBatLootMagmaStoneIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagmaStone, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Lavabat)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LavaBatLootMagmaStoneIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagmaStone, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.SnowFlinx)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSnowballLauncherIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SnowballLauncher, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.ScutlixRider)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBrainScramblerIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BrainScrambler, 1, false, -1, false, false);
							}
						}
						if (npc.type == 63 || npc.type == 64 || npc.type == 103) //Basic Jellyfish
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootJellyfishNecklaceIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.JellyfishNecklace, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DesertLamiaLight || npc.type == NPCID.DesertLamiaDark)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootLamiaClothesIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LamiaHat, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootLamiaClothesIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LamiaPants, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootLamiaClothesIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LamiaShirt, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Vampire)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonStoneIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonStone, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.RedDevil)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootFireFeatherIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FireFeather, 1, false, -1, false, false);
							}
						}
						if (GetInstance<AEnemyDropConfig>().SlimeStaffIncreaseToSurfaceSlimes && (npc.type == NPCID.GreenSlime || npc.type == NPCID.BlueSlime || npc.type == NPCID.PurpleSlime || npc.type == NPCID.IceSlime || npc.type == NPCID.SandSlime || npc.type == NPCID.JungleSlime))
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSlimeStaffIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
							}
						}
						if (GetInstance<AEnemyDropConfig>().SlimeStaffIncreaseToUndergroundSlimes && (npc.type == NPCID.RedSlime || npc.type == NPCID.YellowSlime))
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSlimeStaffIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
							}
						}
						if (GetInstance<AEnemyDropConfig>().SlimeStaffIncreaseToCavernSlimess && (npc.type == NPCID.BlackSlime || npc.type == NPCID.MotherSlime || npc.type == NPCID.BabySlime))
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSlimeStaffIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
							}
						}
						if (GetInstance<AEnemyDropConfig>().SlimeStaffIncreaseToIceSpikedSlimes && npc.type == NPCID.SpikedIceSlime)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSlimeStaffIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
							}
						}
						if (GetInstance<AEnemyDropConfig>().SlimeStaffIncreaseToSpikedJungleSlimes && npc.type == NPCID.SpikedJungleSlime)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSlimeStaffIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
							}
						}
						if (Main.hardMode && player.ZoneBeach)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPirateMapIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PirateMap, 1, false, -1, false, false);
							}
						}
						if (Main.hardMode && player.ZoneRockLayerHeight && (player.ZoneCorrupt || player.ZoneCrimson))
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSoulofNightIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofNight, 1, false, -1, false, false);
							}
						}
						if (Main.hardMode && player.ZoneRockLayerHeight && player.ZoneHoly)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSoulofLightIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofLight, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Unicorn)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootUnicornonaStickIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.UnicornonaStick, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DiggerHead || npc.type == NPCID.GiantWormHead)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootWhoopieCushionIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WhoopieCushion, 1, false, -1, false, false);
							}
						}
						if (player.ZoneSnow && Main.hardMode) //Skeletron
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAmarokIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Amarok, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.UndeadMiner)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBonePickaxeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BonePickaxe, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMiningHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MiningHelmet, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMiningShirtIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MiningShirt, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMiningPantsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MiningPants, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Psycho)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPsychoKnifeIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PsychoKnife, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.CorruptBunny)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBunnyHoodIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BunnyHood, 1, false, -1, false, false);
							}
						}
						if (npc.type >= 78 && npc.type <= 80) //Mummies
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMummyCostumeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MummyMask, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMummyCostumeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MummyShirt, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMummyCostumeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MummyPants, 1, false, -1, false, false);
							}
						}
						if (npc.type == 31 || (npc.type >= 294 && npc.type <= 296) || npc.type == NPCID.CursedSkull || npc.type == NPCID.DarkCaster) //Angry Bones, Cursed Skull, and Dark Caster
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenKeyIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenKey, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootTallyCounterIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TallyCounter, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Werewolf)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonCharmIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonCharm, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DesertBeast)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientHornIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientHorn, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Demon)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDemonScytheIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DemonScythe, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Shark)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDivingHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DivingHelmet, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Eyezor)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootEyeSpringIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EyeSpring, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.IceElemental || npc.type == NPCID.IcyMerman)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootFrostStaffIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FrostStaff, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.WalkingAntlion)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMandibleBladeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AntlionClaw, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.MeteorHead)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMeteoriteIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Meteorite, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.CorruptPenguin || npc.type == NPCID.CrimsonPenguin)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPedguinssuitIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PedguinHat, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPedguinssuitIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PedguinShirt, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPedguinssuitIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PedguinPants, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.UndeadViking)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootVikingHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.VikingHelmet, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.UmbrellaSlime)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootUmbrellaHatIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.UmbrellaHat, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Vampire || npc.type == NPCID.VampireBat)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBrokenBatWingIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BrokenBatWing, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DesertDjinn)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDesertSpiritLampIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DjinnLamp, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Piranha)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootHookIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Hook, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.LightMummy || npc.type == NPCID.DesertGhoulHallow || npc.type == NPCID.SandsharkHallow)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootLightShardIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LightShard, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DesertLamiaLight)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonMaskIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonMask, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DesertLamiaDark)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSunMaskIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SunMask, 1, false, -1, false, false);
							}
						}
						if (npc.type >= 333 && npc.type <= 336) //Present Slimes
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGiantBowIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GiantBow, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.ZombieRaincoat)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootRainArmorIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RainCoat, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootRainArmorIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RainCoat, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Mimic && player.ZoneSnow)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootToySledIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ToySled, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.SkeletonSniper)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSniperRifleIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SniperRifle, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootRifleScopeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RifleScope, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.TacticalSkeleton)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootTacticalShotgunIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TacticalShotgun, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSWATHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SWATHelmet, 1, false, -1, false, false);
							}
						}
						if (npc.type >= 524 && npc.type <= 527) //Ghouls
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientClothIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCloth, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DesertGhoulCorruption || npc.type == NPCID.DesertGhoulCrimson)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDarkShardIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DarkShard, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.AngryNimbus)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootNimbusRodIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.NimbusRod, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.BoneLee)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBlackBeltIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlackBelt, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootTabiIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Tabi, 1, false, -1, false, false);
							}
						}
						if (Main.halloween && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoodieBagIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoodieBag, 1, false, -1, false, false);
							}
						}
						if (Main.xMas && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPresentIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Present, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Drippler || npc.type == NPCID.BloodZombie)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoneyTroughIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoneyTrough, 1, false, -1, false, false);
							}
						}
						if (npc.type == 42 || npc.type == 141|| npc.type == 176 || (npc.type >= 231 && npc.type <= 235)) //Hornet, Moss Hornet, and Toxic Sludge
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBezoarIncrease * difficultyMultiplier + AnkhMaterialBonus)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bezoar, 1, false, -1, false, false);
							}
						}
						if (Main.halloween && npc.value < 500f)
						{
							if (npc.damage >= 40 && npc.defense >= 20 && GetInstance<AEnemyDropConfig>().LootBloodyMacheteAndBladedGlovesAreNotLimitedByDamageAndDefense) //Add Vanilla Drop Rate to the enemies that vanilla limits
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
							if ((npc.damage < 40 && npc.defense < 20) || (GetInstance<AEnemyDropConfig>().LootBloodyMacheteAndBladedGlovesAreNotLimitedByDamageAndDefense)) //Add this mod's increase
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
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootRallyIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Rally, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Medusa)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPocketMirrorIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PocketMirror, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Mothron)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMothronWingsIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MothronWings, 1, false, -1, false, false);
							}
						}
						if (Main.bloodMoon && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead && Main.hardMode)
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootKOCannonIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.KOCannon, 1, false, -1, false, false);
							}
						}
						if (npc.type == 16 || npc.type == 58 || npc.type == 167 || npc.type == 197 || npc.type == 185 || (npc.type >= 494 && npc.type <= 506)) //Salamanders, Giant Shellys, Crawdads, Mother Slimes, Piranhas, Snow Flinxes, Undead Vikings, and Armored Vikings.
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootCompassIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Compass, 1, false, -1, false, false);
							}
						}
						if (npc.type == 49 || npc.type == 93 || npc.type == 51 || npc.type == 150 || (npc.type >= 494 && npc.type <= 506)) //Cave Bats, Giant Bats, Jungle Bats, Ice Bats, Salamanders, Giant Shellys, and Crawdads.
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDepthMeterIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DepthMeter, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Guide) //Guide NPC
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGreenCapForNonAndrewGuide)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GreenCap, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DyeTrader) //Dye Trader NPC
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootExoticScimitarIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DyeTradersScimitar, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DD2Bartender) //Tavernkeep NPC
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAleTosserIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AleThrowingGlove, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Stylist) //Stylist NPC
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootStylishScissorsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.StylistKilLaKillScissorsIWish, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Painter) //Painter NPC
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPaintballGunIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PainterPaintballGun, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.PartyGirl) //Party Girl NPC
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootHappyGrenadeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PartyGirlGrenade, Main.rand.Next(30, 61), false, -1, false, false);
							}
						}
						if (npc.type == NPCID.TaxCollector) //Tax Collector Guide NPC
						{
							if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootClassyCane)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TaxCollectorsStickOfDoom, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.RainbowSlime && (GetInstance<AEnemyDropConfig>().LootRainbowBlockDropMinIncrease < GetInstance<AEnemyDropConfig>().LootRainbowBlockDropMaxIncrease)) //RainbowSlime
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RainbowBrick, Main.rand.Next(GetInstance<AEnemyDropConfig>().LootRainbowBlockDropMinIncrease - 30, GetInstance<AEnemyDropConfig>().LootRainbowBlockDropMaxIncrease - 60), false, -1, false, false); //Rainbow Block
						}
					
						//Chest Drop
						if (GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop > 0)
						{
							if (player.ZoneSnow && player.ZoneRockLayerHeight && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 681, 1, false, -1, false, false); //Ice Chest
							else if (player.ZoneJungle && player.ZoneRockLayerHeight && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 680, 1, false, -1, false, false); //Ivy Chest
							else if ((Main.tile[npcTileX, npcTileY].wall == WallID.LihzahrdBrickUnsafe && NPC.downedPlantBoss) && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop) //Lihzahrd Temple Enemies
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1142, 1, false, -1, false, false); //Lihzahrd Chest
							else if (player.ZoneUnderworldHeight && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 328, 1, false, -1, false, false); //Shadow Chest
							else if (player.ZoneDungeon && NPC.downedPlantBoss)
							{
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop && ReducedGrindingWorld.jungleChestMined)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1528, 1, false, -1, false, false); //Jungle Chest
								if (ReducedGrindingWorld.infectionChestMined)
								{
									if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1529, 1, false, -1, false, false); //Corruption Chest
									if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1530, 1, false, -1, false, false); //Crimson Chest
								}
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop && ReducedGrindingWorld.hallowedChestMined)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1531, 1, false, -1, false, false); //Hallowed Chest
								if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop && ReducedGrindingWorld.frozenChestMined)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1532, 1, false, -1, false, false); //Frozen Chest
							}
							else if (player.ZoneOverworldHeight && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 831, 1, false, -1, false, false); //Living Wood Chest
							else if ((player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight) && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 306, 1, false, -1, false, false); //Gold Chest
							else if (player.ZoneSkyHeight && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 838, 1, false, -1, false, false); //Skyware Chest
							if ((npc.type == 57 || npc.type == 58 || (npc.type >= 63 && npc.type <= 65) || npc.type == 67 || npc.type == 102 || npc.type == 103 || npc.type == 157 || npc.type == 220 || npc.type == 221 || npc.type == 241 || npc.type == 242 || npc.type == 256 || npc.type == 465) && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop) //Water Enemies (https://terraria.gamepedia.com/Water#Contents)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1298, 1, false, -1, false, false); //Water Chest
							if (((npc.type >= 163 && npc.type <= 165) || npc.type == 238) && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop) //Spider Nest Enemies
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 952, 1, false, -1, false, false); //Web Covered Chest
						}

						//Modded Loot
						float lockboxDropModdifier = 0.0f;
						if (Main.hardMode)
							lockboxDropModdifier = GetInstance<GLockbBoxConfig>().HardmodeModdedLockBoxDropRateModifier;
						else
							lockboxDropModdifier = GetInstance<GLockbBoxConfig>().NormalmodeModdedLockBoxDropRateModifier;
						
						if (GetInstance<GLockbBoxConfig>().LockBoxesGiveNonFurniture && (npc.type == 57 || npc.type == 58 || (npc.type >= 63 && npc.type <= 65) || npc.type == 67 || npc.type == 102 || npc.type == 103 || npc.type == 157 || npc.type == 220 || npc.type == 221 || npc.type == 241 || npc.type == 242 || npc.type == 256 || npc.type == 465)) //Water Enemies (https://terraria.gamepedia.com/Water#Contents)
						{
							if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().WaterEnemyModdedWaterLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Water_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if (npc.type == 48) //Harpy
						{
							if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().SkyModdedSkywareLockBoxLoot * lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Skyware_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if (GetInstance<GLockbBoxConfig>().LockBoxesGiveNonFurniture && ((npc.type >= 163 && npc.type <= 165) || npc.type == 238)) //Spider Nest Enemies
						{
							if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().SpiderNestWebCoveredLockBoxLoot * lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Web_Covered_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if (player.ZoneDungeon)
						{
							if (GetInstance<GLockbBoxConfig>().LockBoxesGiveFurniture)
							{
								if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().DungeonFurnitureLockBoxLoot * lockboxDropModdifier)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Blue_Dungeon_Lock_Box"), 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().DungeonFurnitureLockBoxLoot * lockboxDropModdifier)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Green_Dungeon_Lock_Box"), 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().DungeonFurnitureLockBoxLoot * lockboxDropModdifier)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Pink_Dungeon_Lock_Box"), 1, false, -1, false, false);
								}
							}
							if (GetInstance<GLockbBoxConfig>().LockBoxesGiveNonFurniture && NPC.downedPlantBoss)
							{
								if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().DungeonModdedBiomeLockBoxLoot*lockboxDropModdifier)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Biome_Lock_Box"), 1, false, -1, false, false);
								}
							}
						}
						else if (player.ZoneUnderworldHeight)
						{
							if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().HellBiomeModdedShadowLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Shadow_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if (player.ZoneSnow && player.ZoneRockLayerHeight)
						{
							if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().UndergroundSnowBiomeModdedIceLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Ice_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if (player.ZoneJungle && player.ZoneRockLayerHeight)
						{
							if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().UndergroundJungleBiomeModdedIvyLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Ivy_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if (player.ZoneSandstorm || player.ZoneUndergroundDesert)
						{
							if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().SandstormAndUndergroundDesertPyramidLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Pyramid_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if (Main.tile[npcTileX, npcTileY].wall == WallID.LihzahrdBrickUnsafe && NPC.downedPlantBoss) //Lihzahrd Temple Enemies
						{
							if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().JungleTempleLihzahrd_Lock_Box*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Lihzahrd_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if (player.ZoneOverworldHeight)
						{
							if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().SurfaceModdedLivingWoodLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Living_Wood_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if (player.ZoneDirtLayerHeight)
						{
							if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().CavernModdedCavernLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Underground_Lock_Box"), 1, false, -1, false, false);
							}
						}
						else if (player.ZoneRockLayerHeight)
						{
							if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().CavernModdedCavernLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Cavern_Lock_Box"), 1, false, -1, false, false);
							}
						}

						if (npc.type == NPCID.Drippler || npc.type == NPCID.BloodZombie)
						{
							if (Main.rand.NextFloat() < GetInstance<HOtherModdedItemsConfig>().BloodZombieAndDripplerDropsBloodMoonMedallion)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Blood_Moon_Medallion"), 1, false, -1, false, false);
							}
						}
					}

					//Restock Traveling Merchant
					bool travelingMerchantExists = false; //This is done when Luiafk is installed, because it causes restocks to happen even when the vanilla traveling merchant isn't there.
					for (int i = 0; i < Terraria.Main.npc.Length; i++)
					{
						if (Terraria.Main.npc[i].type == NPCID.TravellingMerchant)
						{
							travelingMerchantExists = true;
							break;
						}
					}
					if (travelingMerchantExists && GetInstance<ETravelingAndStationaryMerchantConfig>().ChanceThatEnemyKillWillResetTravelingMerchant > 0)
					{
						int travelingMerchantResetChanceModifier = 22; //There are 22 vanilla NPCs as of 5/26/2017
						bool tryToResetTravelingMerchant = false;
						for (int i = 0; i < Terraria.Main.npc.Length; i++) //Do once for each NPC in the world
						{
							if (Terraria.Main.npc[i].type == NPCID.TravellingMerchant)
								tryToResetTravelingMerchant = true;
							if (Terraria.Main.npc[i].townNPC == true)
							{
								if (
									Terraria.Main.npc[i].type == NPCID.Merchant ||
									Terraria.Main.npc[i].type == NPCID.Nurse ||
									Terraria.Main.npc[i].type == NPCID.Demolitionist ||
									Terraria.Main.npc[i].type == NPCID.DyeTrader ||
									Terraria.Main.npc[i].type == NPCID.Dryad ||
									Terraria.Main.npc[i].type == NPCID.DD2Bartender ||
									Terraria.Main.npc[i].type == NPCID.ArmsDealer ||
									Terraria.Main.npc[i].type == NPCID.Stylist ||
									Terraria.Main.npc[i].type == NPCID.Painter ||
									Terraria.Main.npc[i].type == NPCID.Angler ||
									Terraria.Main.npc[i].type == NPCID.GoblinTinkerer ||
									Terraria.Main.npc[i].type == NPCID.WitchDoctor ||
									Terraria.Main.npc[i].type == NPCID.Clothier ||
									Terraria.Main.npc[i].type == NPCID.Mechanic ||
									Terraria.Main.npc[i].type == NPCID.PartyGirl ||
									Terraria.Main.npc[i].type == NPCID.Wizard ||
									Terraria.Main.npc[i].type == NPCID.TaxCollector ||
									Terraria.Main.npc[i].type == NPCID.Truffle ||
									Terraria.Main.npc[i].type == NPCID.Pirate ||
									Terraria.Main.npc[i].type == NPCID.Steampunker ||
									Terraria.Main.npc[i].type == NPCID.Cyborg) //Any Permenant Town Residents other than the Guide
									travelingMerchantResetChanceModifier--;
							}
						}
						if (travelingMerchantResetChanceModifier < 1)
							travelingMerchantResetChanceModifier = 1;
						if (tryToResetTravelingMerchant)
						{
							if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().ChanceThatEnemyKillWillResetTravelingMerchant/travelingMerchantResetChanceModifier)
							{
								Chest.SetupTravelShop();
								if (Main.netMode == NetmodeID.Server)
									NetMessage.BroadcastChatMessage(NetworkText.FromKey("The Traveling Merchant restocked his items."), new Color(0, 127, 255));
								else if (Main.netMode == NetmodeID.SinglePlayer) // Single Player
									Main.NewText("The Traveling Merchant restocked his items.", 0, 127, 255);
							}
						}
					}
				}
			}
		}

		public override void AddRecipeGroups()
		{
			RecipeGroup goldAndBiomeCrates = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Golden or Biome Crate", new int[]
			{
				ItemID.JungleFishingCrate,
				ItemID.FloatingIslandFishingCrate,
				ItemID.CorruptFishingCrate,
				ItemID.CrimsonFishingCrate,
				ItemID.HallowedFishingCrate,
				ItemID.DungeonFishingCrate,
				ItemID.GoldenCrate
			});
			RecipeGroup.RegisterGroup("ReducedGrinding:goldAndBiomeCrates", goldAndBiomeCrates);
		}

		public override void AddRecipes()
		{
			//Arkhalis Crafting Tree
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

			//Easier Celestial Sigil
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.FragmentSolar);
			recipe.AddIngredient(ItemID.FragmentVortex);
			recipe.AddIngredient(ItemID.FragmentNebula);
			recipe.AddIngredient(ItemID.FragmentStardust);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.CelestialSigil);
			recipe.AddRecipe();

			//Infection Key Switching
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.CorruptionKey);
			recipe.SetResult(ItemID.CrimsonKey);
			recipe.AddRecipe();
				
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.CrimsonKey);
			recipe.SetResult(ItemID.CorruptionKey);
			recipe.AddRecipe();

			//Giant Shelly, Salamander, Crawdad Banner Switching
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.GiantShellyBanner);
			recipe.AddIngredient(ItemID.SalamanderBanner);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(ItemID.CrawdadBanner);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.CrawdadBanner);
			recipe.AddIngredient(ItemID.GiantShellyBanner);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(ItemID.SalamanderBanner);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.SalamanderBanner);
			recipe.AddIngredient(ItemID.CrawdadBanner);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(ItemID.GiantShellyBanner);
			recipe.AddRecipe();

			//Easier Hardmode Voodoo Doll
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.ClothierVoodooDoll);
			recipe.AddIngredient(ItemID.SoulofLight);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.GuideVoodooDoll);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.ClothierVoodooDoll);
			recipe.AddIngredient(ItemID.SoulofNight);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.GuideVoodooDoll);
			recipe.AddRecipe();

			//Golden Critters
			recipe = new ModRecipe(this);
			recipe.AddRecipeGroup("Birds");
			recipe.AddIngredient(this.ItemType("Gold_Reflection_Mirror"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.GoldBird);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Bunny);
			recipe.AddIngredient(this.ItemType("Gold_Reflection_Mirror"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.GoldBunny);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Frog);
			recipe.AddIngredient(this.ItemType("Gold_Reflection_Mirror"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.GoldFrog);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Grasshopper);
			recipe.AddIngredient(this.ItemType("Gold_Reflection_Mirror"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.GoldGrasshopper);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Mouse);
			recipe.AddIngredient(this.ItemType("Gold_Reflection_Mirror"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.GoldMouse);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddRecipeGroup("Squirrels");
			recipe.AddIngredient(this.ItemType("Gold_Reflection_Mirror"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.SquirrelGold);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Worm);
			recipe.AddIngredient(this.ItemType("Gold_Reflection_Mirror"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.GoldWorm);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddRecipeGroup("Butterflies");
			recipe.AddIngredient(this.ItemType("Gold_Reflection_Mirror"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.GoldButterfly);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddRecipeGroup("ReducedGrinding:goldAndBiomeCrates");
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.IronCrate);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.IronCrate);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.WoodenCrate);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.RottenChunk, 2);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(ItemID.Leather);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Vertebrae, 2);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(ItemID.Leather);
			recipe.AddRecipe();
		}
    }

    class SpawnRateMultiplierGlobalNPC : GlobalNPC
    {
		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			
			if (player.FindBuffIndex(mod.BuffType("War")) != -1)
			{
				spawnRate = (int)(spawnRate / GetInstance<HOtherModdedItemsConfig>().WarPotionSpawnrateMultiplier);
				maxSpawns = (int)(maxSpawns * GetInstance<HOtherModdedItemsConfig>().WarPotionMaxSpawnsMultiplier);
			}
			if (player.FindBuffIndex(mod.BuffType("Chaos")) != -1)
			{
				spawnRate = (int)(spawnRate / GetInstance<HOtherModdedItemsConfig>().ChaosPotionSpawnrateMultiplier);
				maxSpawns = (int)(maxSpawns * GetInstance<HOtherModdedItemsConfig>().ChaosPotionMaxSpawnsMultiplier);
			}
			if (player.FindBuffIndex(BuffID.Battle) != -1)
			{
				spawnRate = (int)(spawnRate / GetInstance<HOtherModdedItemsConfig>().BattlePotionSpawnrateMultiplier);
				maxSpawns = (int)(maxSpawns * GetInstance<HOtherModdedItemsConfig>().BattlePotionMaxSpawnsMultiplier);
			}
		}
    }

	enum ReducedGrindingMessageType : byte
	{
		SyncPlayer,
		SendClientChanges,
		skipToNight,
		skipToDay,
		advanceMoonPhase
	}

}