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
		
		public class BossBags : GlobalItem  //Rates show in comments are in addition to vanilla rates.
		{
			public override void OpenVanillaBag(string context, Player player, int arg)
			{
				//Boss Bags
				if (arg == ItemID.BrainOfCthulhuBossBag)
				{
					if (Main.rand.NextFloat() < Config.LootBoneRattleIncrease)
					{
						player.QuickSpawnItem(ItemID.BoneRattle, 1);
					}
					if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2104, 1); //Mask
					}
				}
				else if (arg == ItemID.FishronBossBag)
				{
					if (Main.rand.NextFloat() < Config.LootFishronWingsIncrease)
					{
						player.QuickSpawnItem(ItemID.FishronWings, 1);
					}
					if (Main.rand.NextFloat() < Config.LootFishronTruffleworm)
					{
						player.QuickSpawnItem(2673, 1); //Truffleworm
					}
					if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2588, 1); //Mask
					}
				}
				else if (arg == ItemID.EaterOfWorldsBossBag)
				{
					if (Main.rand.NextFloat() < Config.LootEatersBoneIncrease)
					{
						player.QuickSpawnItem(ItemID.EatersBone, 1);
					}
					if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2111, 1); //Mask
					}
				}
				else if (arg == ItemID.EyeOfCthulhuBossBag)
				{
					if (Main.rand.NextFloat() < Config.LootBinocularsIncrease)
					{
						player.QuickSpawnItem(ItemID.Binoculars, 1);
					}
					if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2112, 1); //Mask
					}
				}
				else if (arg == ItemID.PlanteraBossBag)
				{
					if (Main.rand.NextFloat() < Config.LootTheAxeIncrease)
					{
						player.QuickSpawnItem(ItemID.TheAxe, 1);
					}
					if (Main.rand.NextFloat() < Config.LootSeedlingIncrease)
					{
						player.QuickSpawnItem(ItemID.Seedling, 1);
					}
					if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2109, 1); //Mask
					}
				}
				else if (arg == ItemID.QueenBeeBossBag)
				{
					if (Main.rand.NextFloat() < Config.LootHoneyedGogglesIncrease)
					{
						player.QuickSpawnItem(ItemID.HoneyedGoggles, 1);
					}
					if (Main.rand.NextFloat() < Config.LootNectarIncrease)
					{
						player.QuickSpawnItem(ItemID.Nectar, 1);
					}
					if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2108, 1); //Mask
					}
				}
				else if (arg == ItemID.SkeletronBossBag)
				{
					if (Main.rand.NextFloat() < Config.LootBookofSkullsIncrease)
					{
						player.QuickSpawnItem(ItemID.BookofSkulls, 1);
					}
					if (Main.rand.NextFloat() < Config.LootSkeletronBoneKey)
					{
						player.QuickSpawnItem(ItemID.BookofSkulls, 1);
					}
					if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(1281, 1); //Mask
					}
				}
				else if (arg == 3318) //King Slime
				{
					if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2493, 1); //Mask
					}
				}
				else if (arg == 3324) //Wall of Flesh
				{
					if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2105, 1); //Mask
					}
				}
				else if (arg == 3325) //The Destroyer
				{
					if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2113, 1); //Mask
					}
				}
				else if (arg == 3326) //The Twins
				{
					if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2106, 1); //Mask
					}
				}
				else if (arg == 3327) //Skeletron Prime
				{
					if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2107, 1); //Mask
					}
				}
				else if (arg == 3329) //Golem
				{
					if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(2110, 1); //Mask
					}
					if (Main.rand.NextFloat() < Config.LootPicksawIncrease)
					{
						player.QuickSpawnItem(1294, 1); //Picksaw
					}
				}
				else if (arg == 3332) //Moon Lord
				{
					if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(3373, 1); //Mask
					}
				}
				else if (arg == 3860) //Betsy
				{
					if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
					{
						player.QuickSpawnItem(3863, 1); //Mask
					}
				}
				
				//Crates
				else if (arg == 3205) //Dungeon Crate
				{
					if (Main.rand.NextFloat() < Config.CrateDungeonBoneWelder)
					{
						player.QuickSpawnItem(2192, 1); //Bone Welder
					}
				}
				else if (arg == ItemID.JungleFishingCrate)
				{
					if (Main.rand.NextFloat() < Config.CrateJungleSeaweed)
					{
						player.QuickSpawnItem(ItemID.Seaweed, 1);
					}
					if (Main.rand.NextFloat() < Config.CrateJungleFlowerBoots)
					{
						player.QuickSpawnItem(ItemID.FlowerBoots, 1);
					}
					if (Main.rand.NextFloat() < Config.CrateJungleLivingMahoganyWand)
					{
						player.QuickSpawnItem(ItemID.LivingMahoganyWand, 1);
					}
					if (Main.rand.NextFloat() < Config.CrateJungleRichMahoganyLeafWand)
					{
						player.QuickSpawnItem(ItemID.LivingMahoganyLeafWand, 1);
					}
					if (Main.rand.NextFloat() < Config.CrateJungleLivingLoom)
					{
						player.QuickSpawnItem(ItemID.LivingLoom, 1);
					}
					if (Main.rand.NextFloat() < Config.CrateJungleLeafWand)
					{
						player.QuickSpawnItem(ItemID.LeafWand, 1);
					}
					if (Main.rand.NextFloat() < Config.CrateJungleLivingWoodWand)
					{
						player.QuickSpawnItem(ItemID.LivingWoodWand, 1);
					}
					if (Main.rand.NextFloat() < Config.CrateJungleAnkeltOfTheWindIncrease)
					{
						player.QuickSpawnItem(212, 1); //Anklet of the Wind
					}
					if (Main.rand.NextFloat() < Config.CrateJungleFeralClawsIncrease)
					{
						player.QuickSpawnItem(211, 1); //Feral Claws
					}
					if (Main.rand.NextFloat() < Config.CrateJungleStaffOfRegrowth)
					{
						player.QuickSpawnItem(213, 1); //Staff Of Regrowth
					}
				}
				else if (arg == 3206) //Sky Crate
				{
					if (Main.rand.NextFloat() < Config.CrateSkySkyMill)
					{
						player.QuickSpawnItem(2197, 1); //Sky Mill
					}
				}
				else if (arg == ItemID.WoodenCrate)
				{
					if (Main.rand.NextFloat() < Config.CrateWoodenClimbingClawsIncrease)
					{
						player.QuickSpawnItem(953, 1); //Climbing Claws
					}
					if (Main.rand.NextFloat() < Config.CrateWoodenRadarIncrease)
					{
						player.QuickSpawnItem(3084, 1); //Radar
					}
					if (Main.rand.NextFloat() < Config.CrateWoodenAgletIncrease)
					{
						player.QuickSpawnItem(285, 1); //Aglet
					}
				}
				else if (arg == ItemID.WoodenCrate)
				{
					if (Main.rand.NextFloat() < Config.CrateWaterWalkingBootsWooden)
					{
						player.QuickSpawnItem(863, 1); //Water walking boots
					}
					if (Main.rand.NextFloat() < Config.CrateFlippersWooden)
					{
						player.QuickSpawnItem(187, 1); //Flipper
					}
					if (Main.rand.NextFloat() < Config.CrateEnchantedSundialWoodenIncrease)
					{
						player.QuickSpawnItem(3064, 1); //Enchanted Sundial
					}
				}
				else if (arg == ItemID.IronCrate)
				{
					if (Main.rand.NextFloat() < Config.CrateWaterWalkingBootsIron)
					{
						player.QuickSpawnItem(863, 1); //Water walking boots
					}
					if (Main.rand.NextFloat() < Config.CrateFlippersIron)
					{
						player.QuickSpawnItem(187, 1); //Flipper
					}
					if (Main.rand.NextFloat() < Config.CrateEnchantedSundialIronIncrease)
					{
						player.QuickSpawnItem(3064, 1); //Enchanted Sundial
					}
				}
				else if (arg == ItemID.GoldenCrate)
				{
					if (Main.rand.NextFloat() < Config.CrateWaterWalkingBootsGolden)
					{
						player.QuickSpawnItem(863, 1); //Water walking boots
					}
					if (Main.rand.NextFloat() < Config.CrateFlippersGolden)
					{
						player.QuickSpawnItem(187, 1); //Flipper
					}
					if (Main.rand.NextFloat() < Config.CrateEnchantedSundialGoldenIncrease)
					{
						player.QuickSpawnItem(3064, 1); //Enchanted Sundial
					}
				}
				else if (context == "present")
				{
					if (Main.rand.NextFloat() < Config.PresentDogWhistle)
					{
						player.QuickSpawnItem(1927, 1);
					}
					if (Main.rand.NextFloat() < Config.PresentToolbox)
					{
						player.QuickSpawnItem(1923, 1);
					}
					if (Main.rand.NextFloat() < Config.PresentHandWarmer)
					{
						player.QuickSpawnItem(1921, 1);
					}
					if (Main.rand.NextFloat() < Config.PresentCandyCanePickaxe)
					{
						player.QuickSpawnItem(1917, 1);
					}
					if (Main.rand.NextFloat() < Config.PresentCandyCaneHook)
					{
						player.QuickSpawnItem(1915, 1);
					}
					if (Main.rand.NextFloat() < Config.PresentFruitcakeChakram)
					{
						player.QuickSpawnItem(1918, 1);
					}
					if (Main.rand.NextFloat() < Config.PresentRedRyderPlusMusketBall)
					{
						player.QuickSpawnItem(1870, 1);
						player.QuickSpawnItem(97, Main.rand.Next(30,60));
					}
					if (Main.rand.NextFloat() < Config.PresentCandyCaneSword)
					{
						player.QuickSpawnItem(1909, 1);
					}
					if (Main.rand.NextFloat() < Config.PresentMrsClausCostume)
					{
						player.QuickSpawnItem(1932, 1);
						player.QuickSpawnItem(1933, 1);
						player.QuickSpawnItem(1934, 1);
					}
					if (Main.rand.NextFloat() < Config.PresentParkaOutfit)
					{
						player.QuickSpawnItem(1935, 1);
						player.QuickSpawnItem(1936, 1);
						player.QuickSpawnItem(1937, 1);
					}
					if (Main.rand.NextFloat() < Config.PresentTreeCostume)
					{
						player.QuickSpawnItem(1940, 1);
						player.QuickSpawnItem(1941, 1);
						player.QuickSpawnItem(1942, 1);
					}
					if (Main.rand.NextFloat() < Config.PresentSnowHat)
					{
						player.QuickSpawnItem(1938, 1);
					}
					if (Main.rand.NextFloat() < Config.PresentUglySweater)
					{
						player.QuickSpawnItem(1939, 1);
					}
					if (Main.rand.NextFloat() < Config.PresentReindeerAntlers)
					{
						player.QuickSpawnItem(1907, 1);
					}
					if (Main.rand.NextFloat() < Config.PresentCoal)
					{
						player.QuickSpawnItem(1922, 1);
					}
					if (Main.rand.NextFloat() < Config.PresentChristmasPudding)
					{
						player.QuickSpawnItem(1911, 1);
					}
					if (Main.rand.NextFloat() < Config.PresentSugarCookie)
					{
						player.QuickSpawnItem(1919, 1);
					}
					if (Main.rand.NextFloat() < Config.PresentGingerbreadCookie)
					{
						player.QuickSpawnItem(1920, 1);
					}
					if (Main.rand.NextFloat() < Config.PresentStarAnise)
					{
						player.QuickSpawnItem(1913, Main.rand.Next(20,40));
					}
					if (Main.rand.NextFloat() < Config.PresentEggnog)
					{
						player.QuickSpawnItem(1912, Main.rand.Next(1,3));
					}
					if (Main.rand.NextFloat() < Config.PresentHolly)
					{
						player.QuickSpawnItem(1908, 1);
					}
					if (Main.rand.NextFloat() < Config.PresentPineTreeBlock)
					{
						player.QuickSpawnItem(1872, Main.rand.Next(20,49));
					}
					if (Main.rand.NextFloat() < Config.PresentCandyCaneBlock)
					{
						player.QuickSpawnItem(586, Main.rand.Next(20,49));
					}
					if (Main.rand.NextFloat() < Config.PresentGreenCandyCaneBlock)
					{
						player.QuickSpawnItem(591, Main.rand.Next(20,49));
					}
					if (Main.rand.NextFloat() < Config.PresentHardmodeSnowGlobe)
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
					if (Main.rand.NextFloat() * amberMosquitoMultiplier < Config.ExtractinatorGivesAmberMosquito)
					{
						resultStack = 1;
						resultType = ItemID.AmberMosquito;
					}
					else if (Main.rand.NextFloat() * gemMultiplier < Config.ExtractinatorGivesDiamond)
					{
						resultStack = 1;
						resultType = ItemID.Diamond;
					}
					else if (Main.rand.NextFloat() * gemMultiplier < Config.ExtractinatorGivesRuby)
					{
						resultStack = 1;
						resultType = ItemID.Ruby;
					}
					else if (Main.rand.NextFloat() * gemMultiplier < Config.ExtractinatorGivesEmerald)
					{
						resultStack = 1;
						resultType = ItemID.Emerald;
					}
					else if (Main.rand.NextFloat() * gemMultiplier < Config.ExtractinatorGivesSapphire)
					{
						resultStack = 1;
						resultType = ItemID.Sapphire;
					}
					else if (Main.rand.NextFloat() * gemMultiplier < Config.ExtractinatorGivesTopaz)
					{
						resultStack = 1;
						resultType = ItemID.Topaz;
					}
					else if (Main.rand.NextFloat() * gemMultiplier < Config.ExtractinatorGivesAmethyst)
					{
						resultStack = 1;
						resultType = ItemID.Amethyst;
					}
					else if (Main.rand.NextFloat() * amberMultiplier < Config.ExtractinatorGivesAmber)
					{
						resultStack = 1;
						resultType = ItemID.Amber;
					}
					else if (Main.rand.NextFloat() < Config.ExtractinatorGivesGoldOre)
					{
						resultStack = 1;
						resultType = ItemID.GoldOre;
					}
					else if (Main.rand.NextFloat() < Config.ExtractinatorGivesPlatinumOre)
					{
						resultStack = 1;
						resultType = ItemID.PlatinumOre;
					}
					else if (Main.rand.NextFloat() < Config.ExtractinatorGivesFossilOre && extractType == 3347)
					{
						resultStack = 1;
						resultType = ItemID.FossilOre;
					}
					else if (Main.rand.NextFloat() < Config.ExtractinatorGivesSilverOre)
					{
						resultStack = 1;
						resultType = ItemID.SilverOre;
					}
					else if (Main.rand.NextFloat() < Config.ExtractinatorGivesTungstenOre)
					{
						resultStack = 1;
						resultType = ItemID.TungstenOre;
					}
					else if (Main.rand.NextFloat() < Config.ExtractinatorGivesIronOre)
					{
						resultStack = 1;
						resultType = ItemID.IronOre;
					}
					else if (Main.rand.NextFloat() < Config.ExtractinatorGivesLeadOre)
					{
						resultStack = 1;
						resultType = ItemID.LeadOre;
					}
					else if (Main.rand.NextFloat() < Config.ExtractinatorGivesCopperOre)
					{
						resultStack = 1;
						resultType = ItemID.CopperOre;
					}
					else if (Main.rand.NextFloat() < Config.ExtractinatorGivesTinOre)
					{
						resultStack = 1;
						resultType = ItemID.TinOre;
					}
					else if (Main.rand.NextFloat() < Config.ExtractinatorGivesPlatinumCoin)
					{
						resultStack = 1;
						resultType = ItemID.PlatinumCoin;
					}
					else if (Main.rand.NextFloat() < Config.ExtractinatorGivesGoldCoin)
					{
						resultStack = 1;
						resultType = ItemID.GoldCoin;
					}
					else if (Main.rand.NextFloat() < Config.ExtractinatorGivesSilverCoin)
					{
						resultStack = 1;
						resultType = ItemID.SilverCoin;
					}
					else if (Main.rand.NextFloat() < Config.ExtractinatorGivesCopperCoin)
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
					Player player = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];
					float difficultyMultiplier = 1f;
					if (!Main.expertMode)
						difficultyMultiplier = Config.NormalModeLootMultiplierForLootWithSeperateDifficultyRates;
					
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
								keyDropRateIncrease = Config.BiomeKeyIncreaseForOneMechBossDown;
							}
							else if (mechBossesDowned == 2)
							{
								keyDropRateIncrease = Config.BiomeKeyIncreaseForTwoMechBossDown;
							}
							else if (mechBossesDowned == 3)
							{
								keyDropRateIncrease = Config.BiomeKeyIncreaseForThreeMechBossDown;
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
					
					for (int j=0; j<Config.DropTriesForAllEnemyDroppedLoot; j++)
					{
						//Boss Loot
						if (npc.type == NPCID.SkeletronHead) //Skeletron
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < Config.LootSkeletronBoneKey * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneKey, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < Config.LootBookofSkullsIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BookofSkulls, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1281, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1363, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 266) //Brain of Cthulhu
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < Config.LootBoneRattleIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneRattle, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2104, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1362, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 370) //Duke Fishron
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < Config.LootFishronWingsIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FishronWings, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < Config.LootFishronTruffleworm * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2673, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2588, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2589, 1, false, -1, false, false); //Trophy
						}
						if (npc.type >= 13 && npc.type <= 15 && npc.boss) //Eater of Worlds
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < Config.LootEatersBoneIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EatersBone, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2111, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1361, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 4) //Eye of Cthulhu
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < Config.LootBinocularsIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Binoculars, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2112, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1360, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 262) //Plantera
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < Config.LootTheAxeIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TheAxe, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < Config.LootSeedlingIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Seedling, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2109, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1370, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 222) //Queen Bee
						{
							if (!Main.expertMode)
							{
								if (Main.rand.NextFloat() < Config.LootHoneyedGogglesIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HoneyedGoggles, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < Config.LootNectarIncrease * difficultyMultiplier)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Nectar, 1, false, -1, false, false);
								if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2108, 1, false, -1, false, false); //Mask
							}
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1364, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 50) //Slime King
						{
							if (Main.rand.NextFloat() < Config.LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2493, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2489, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 113) //Wall of Flesh
						{
							if (Main.rand.NextFloat() < Config.LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2105, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1365, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 134) //The Destroyer
						{
							if (Main.rand.NextFloat() < Config.LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2113, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1366, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 125 || npc.type == 126) //The Twins
						{
							if (!Main.expertMode)
							{
								int oppositeTwin = 125;
								if (npc.type == 125)
									oppositeTwin = 126;
								if (!NPC.AnyNPCs(oppositeTwin) && Main.rand.NextFloat() < Config.LootBossMaskIncrease)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2106, 1, false, -1, false, false);
							}
							if (npc.type == 125 && Main.rand.NextFloat() < Config.LootBossTrophyIncrease) //Retinazer
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1368, 1, false, -1, false, false); //Trophy
							if (npc.type == 126 && Main.rand.NextFloat() < Config.LootBossTrophyIncrease) //Spazmatism
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1369, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 127) //Skeletron Prime
						{
							if (Main.rand.NextFloat() < Config.LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2113, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1367, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 245) //Golem
						{
							if (Main.rand.NextFloat() < Config.LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2110, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1371, 1, false, -1, false, false); //Trophy
							if (Main.rand.NextFloat() < Config.LootPicksawIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1371, 1, false, -1, false, false); //Picksaw
						}
						if (npc.type == 370) //Duke Fishron
						{
							if (Main.rand.NextFloat() < Config.LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2588, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2589, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 439) //Lunatic Cultist
						{
							if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3372, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3357, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 398) //Moon Lord
						{
							if (Main.rand.NextFloat() < Config.LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3373, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3595, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 551) //Betsy
						{
							if (Main.rand.NextFloat() < Config.LootBossMaskIncrease && !Main.expertMode)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3863, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3866, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 564) //Dark Mage T1
						{
							if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3864, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3867, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 565) //Dark Mage T3
						{
							if (Main.rand.NextFloat() < Config.LootBossMaskIncrease / 2)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3864, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3867, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 576) //Ogre T2
						{
							if (Main.rand.NextFloat() < Config.LootBossMaskIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3865, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3868, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 577) //Ogre T3
						{
							if (Main.rand.NextFloat() < Config.LootBossMaskIncrease / 2)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3865, 1, false, -1, false, false); //Mask
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3868, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 344) //Everscream
						{
							if (Main.rand.NextFloat() < Config.LootFestiveWingsIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FestiveWings, 1, false, -1, false, false);
						}
						if (npc.type == 345) //Ice Queen
						{
							if (Main.rand.NextFloat() < Config.LootBabyGrinchsMischiefWhistleIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BabyGrinchMischiefWhistle, 1, false, -1, false, false);
							if (Main.rand.NextFloat() < Config.LootReindeerBellsIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ReindeerBells, 1, false, -1, false, false);
						}
						if (npc.type == 491) //Flying Dutchman
						{
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3359, 1, false, -1, false, false); //Trophy
						}
						if (npc.type == 395) //Martian Saucer
						{
							if (Main.rand.NextFloat() < Config.LootBossTrophyIncrease)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3358, 1, false, -1, false, false); //Trophy
						}
						
						
						
						//Other Loot
						if (npc.type == NPCID.AnglerFish || npc.type == NPCID.Piranha)
						{
							if (Main.rand.NextFloat() < Config.LootRobotHatIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RobotHat, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.AnglerFish || (npc.type >= 269 && npc.type <= 272) || npc.type == NPCID.Werewolf) //269 to 272 is Rusty Armored Bones
						{
							if (Main.rand.NextFloat() < Config.LootAdhesiveBandageIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AdhesiveBandage, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.ChaosElemental && Config.LootRodofDiscordIncrease > 0)
						{
							if (Main.rand.NextFloat() < Config.LootRodofDiscordIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RodofDiscord, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Clown || npc.type == NPCID.LightMummy || npc.type == NPCID.GiantBat)
						{
							if (Main.rand.NextFloat() < Config.LootTrifoldMapIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TrifoldMap, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Clown)
						{
							if (Main.rand.NextFloat() < Config.LootBananarangIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bananarang, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.EnchantedSword || npc.type == NPCID.CrimsonAxe || npc.type == NPCID.CursedHammer || npc.type == NPCID.CursedSkull)
						{
							if (Main.rand.NextFloat() < Config.LootNazarIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Nazar, 1, false, -1, false, false);
							}
						}
						if (npc.type == 42 || (npc.type >= 231 && npc.type <= 235)) //Hornet
						{
							if (Main.rand.NextFloat() < Config.LootMegaphoneBaseIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Megaphone, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootAncientCobaltHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltHelmet, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootAncientCobaltBreastplateIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltBreastplate, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootAncientCobaltLeggingsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltLeggings, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Corruptor || npc.type == NPCID.FloatyGross)
						{
							if (Main.rand.NextFloat() < Config.LootVitaminsIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Vitamins, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Crimslime || npc.type == NPCID.BigCrimslime || npc.type == NPCID.LittleCrimslime)
						{
							if (Main.rand.NextFloat() < Config.LootBlindfoldIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Blindfold, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Mummy || npc.type == NPCID.Pixie || npc.type == NPCID.Wraith)
						{
							int fastClockMultiplier = 1;
							if (npc.type != NPCID.Pixie)
								fastClockMultiplier = 2;
							if (Main.rand.NextFloat() < Config.LootFastClockBaseIncrease * difficultyMultiplier* fastClockMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FastClock, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.FlyingSnake || npc.type == NPCID.Lihzahrd || npc.type == NPCID.LihzahrdCrawler)
						{
							if (Main.rand.NextFloat() < Config.LootLizardEggIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LizardEgg, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootLihzahrdPowerCellIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LihzahrdPowerCell, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.GiantTortoise && Config.LootTurtleShellIncrease > 0)
						{
							if (Main.rand.NextFloat() < Config.LootTurtleShellIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TurtleShell, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.IceTortoise && Config.LootFrozenTurtleShellIncrease > 0)
						{
							if (Main.rand.NextFloat() < Config.LootFrozenTurtleShellIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FrozenTurtleShell, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Paladin)
						{
							if (Main.rand.NextFloat() < Config.LootPaladinsShieldIncrease * difficultyMultiplier)
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
							if (Main.rand.NextFloat() < Config.PirateLootCoinGunBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CoinGun, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.PirateLootLuckyCoinBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LuckyCoin, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.PirateLootDiscountCardBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DiscountCard, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.PirateLootPirateStaffBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PirateStaff, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.PirateLootGoldRingBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldRing, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.PirateLootCutlassBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cutlass, 1, false, -1, false, false);
							}
							if (npc.type != NPCID.PirateCaptain && npc.type != NPCID.PirateShip)
							{
								if (Main.rand.NextFloat() < Config.LootSailorHatIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SailorHat, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < Config.LootSailorShirtIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SailorShirt, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < Config.LootSailorPantsIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SailorPants, 1, false, -1, false, false);
								}
							}
							if (Config.LootGoldenFurnitureIncrease > 0 && npc.type != NPCID.PirateCaptain && npc.type != NPCID.PirateShip)
							{
								if (Main.rand.NextFloat() < Config.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenChair, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < Config.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenToilet, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < Config.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenDoor, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < Config.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenTable, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < Config.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenBed, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < Config.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenPiano, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < Config.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenDresser, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < Config.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenSofa, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < Config.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenBathtub, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < Config.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenClock, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < Config.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenLamp, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < Config.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenBookcase, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < Config.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenChandelier, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < Config.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenLantern, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < Config.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenCandelabra, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < Config.LootGoldenFurnitureIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenCandle, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < Config.LootGoldenFurnitureIncrease)
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
							if (Main.rand.NextFloat() < Config.LootMegaphoneBaseIncrease * difficultyMultiplier * megaphoneMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Megaphone, 1, false, -1, false, false);
							}
						}
						if (npc.type == 77 || (npc.type >= 273 && npc.type <= 276)) //Blue Amored Bones and Armored Skeleton
						{
							if (Main.rand.NextFloat() < Config.LootArmorPolishIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ArmorPolish, 1, false, -1, false, false);
							}
						}
						if ((npc.type == NPCID.ZombieElf || npc.type == NPCID.ZombieElfBeard || npc.type == NPCID.ZombieElfGirl))
						{
							if (Main.rand.NextFloat() < Config.LootElfHatIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ElfHat, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootElfShirtIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ElfShirt, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootElfPantsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ElfPants, 1, false, -1, false, false);
							}
						}
						if (npc.type >= 269 && npc.type <= 280)//All Armored Bones variants
						{
							if (Main.rand.NextFloat() < Config.LootWispinaBottleIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WispinaBottle, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootBoneFeatherIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneFeather, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootMagnetSphereIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagnetSphere, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootKeybrandIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Keybrand, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.EaterofSouls)
						{
							if (Main.rand.NextFloat() < Config.LootAncientShadowHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientShadowHelmet, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootAncientShadowScalemailIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientShadowScalemail, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootAncientShadowGreavesIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientShadowGreaves, 1, false, -1, false, false);
							}
						}
						if (npc.type == 21 || (npc.type >= 201 && npc.type <= 203) || (npc.type >= 322 && npc.type <= 323) || (npc.type >= 449 && npc.type <= 452)) //Skeleton
						{
							if (Main.rand.NextFloat() < Config.LootSkullIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Skull, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootBoneSwordIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneSword, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootAncientGoldHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientGoldHelmet, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootAncientIronHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientIronHelmet, 1, false, -1, false, false);
							}
						}
						if (npc.type == 31 || (npc.type >= 294 && npc.type <= 296)) //Angry Bones
						{
							if (Main.rand.NextFloat() < Config.LootAncientNecroHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientNecroHelmet, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootClothierVoodooDollIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ClothierVoodooDoll, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootBoneWandIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneWand, 1, false, -1, false, false);
							}
						}
						if (player.ZoneUnderworldHeight)
						{
							
							if (Main.hardMode)
							{
								if (Main.rand.NextFloat() < Config.LootHelFireIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HelFire, 1, false, -1, false, false);
								}
								if (Main.rand.NextFloat() < Config.LootLivingFireBlockIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LivingFireBlock, 1, false, -1, false, false);
								}
							}
							else if (NPC.downedBoss3) //Skeletron
							{
								if (Main.rand.NextFloat() < Config.LootCascadeIncrease)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cascade, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.ManEater)
						{
							if (Main.rand.NextFloat() < Config.LootAncientCobaltHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltHelmet, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootAncientCobaltBreastplateIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltBreastplate, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootAncientCobaltLeggingsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltLeggings, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.FireImp)
						{
							if (Main.rand.NextFloat() < Config.LootPlumbersHatIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PlumbersHat, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootObsidianRoseIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ObsidianRose, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.CursedSkull || npc.type == NPCID.DarkCaster)
						{
							if (Main.rand.NextFloat() < Config.LootBoneWandIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneWand, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.CaveBat)
						{
							if (Main.rand.NextFloat() < Config.LootChainKnifeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ChainKnife, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Reaper)
						{
							if (Main.rand.NextFloat() < Config.LootDeathSickleIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AdhesiveBandage, 1, false, -1, false, false);
							}
						}
						if (npc.type == 3 || npc.type == 132 || npc.type == 161 || (npc.type >= 186 && npc.type <= 200) || npc.type == 223 || (npc.type >= 430 && npc.type <= 436)) //Normal Zombie Variants, Raincoat Zombie, and Zombie Eskimo
						{
							if (Main.rand.NextFloat() < Config.LootZombieArmIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ZombieArm, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootShackleIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Shackle, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Pixie || npc.type == NPCID.Unicorn || npc.type == NPCID.RainbowSlime || npc.type == NPCID.Gastropod || npc.type == NPCID.LightMummy || npc.type == NPCID.IlluminantSlime || npc.type == NPCID.IlluminantBat || npc.type == NPCID.ChaosElemental || npc.type == NPCID.EnchantedSword || npc.type == NPCID.BigMimicHallow) //Hallow Enemies
						{
							if (Main.rand.NextFloat() < Config.LootBlessedAppleIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlessedApple, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Mimic)
						{
							if (Main.rand.NextFloat() < Config.LootDualHookIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DualHook, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootMagicDaggerIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagicDagger, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootTitanGloveIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TitanGlove, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootPhilosophersStoneIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PhilosophersStone, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootCrossNecklaceIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CrossNecklace, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootStarCloakIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.StarCloak, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.BigMimicCorruption)
						{
							if (Main.rand.NextFloat() < Config.LootDartRifleIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DartRifle, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootWormHookIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WormHook, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootChainGuillotinesIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ChainGuillotines, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootClingerStaffIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ClingerStaff, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootPutridScentIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PutridScent, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.BigMimicCrimson)
						{
							if (Main.rand.NextFloat() < Config.LootLifeDrainIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulDrain, 1, false, -1, false, false);//Life Drain
							}
							if (Main.rand.NextFloat() < Config.LootDartPistolIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DartPistol, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootFetidBaghnakhsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FetidBaghnakhs, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootFleshKnucklesIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FleshKnuckles, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootTendonHookIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TendonHook, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.BigMimicHallow)
						{
							if (Main.rand.NextFloat() < Config.LootDaedalusStormbowIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DaedalusStormbow, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootFlyingKnifeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FlyingKnife, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootCrystalVileShardIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CrystalVileShard, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootIlluminantHookIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IlluminantHook, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Harpy)
						{
							if (Main.rand.NextFloat() < Config.LootGiantHarpyFeatherIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GiantHarpyFeather, 1, false, -1, false, false);
							}
						}
						if ((npc.type >= 26 && npc.type <= 29) || npc.type == 111) //Goblin Army (Excluding Summoner)
						{
							if (Main.rand.NextFloat() < Config.LootHarpoonIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Harpoon, 1, false, -1, false, false);
							}
					}
						if (npc.type == NPCID.ArmoredViking || npc.type == NPCID.IceElemental || npc.type == NPCID.IcyMerman || npc.type == NPCID.IceTortoise)
						{
							if (Main.rand.NextFloat() < Config.LootIceSickleIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IceSickle, 1, false, -1, false, false);
							}
						}
						if (npc.type >= 269 && npc.type <= 293)// Post-plantera dungeon enemies
						{
							if (Main.rand.NextFloat() < Config.LootKrakenIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Kraken, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.SkeletonArcher)
						{
							if (Main.rand.NextFloat() < Config.LootMarrowIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Marrow, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootMagicQuiverIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagicQuiver, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Crimslime || npc.type == NPCID.CrimsonAxe || npc.type == NPCID.FloatyGross || npc.type == NPCID.Herpling)
						{
							if (Main.rand.NextFloat() < Config.LootMeatGrinderIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MeatGrinder, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.AngryTrapper)
						{
							if (Main.rand.NextFloat() < Config.LootUziIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Uzi, 1, false, -1, false, false);
							}
						}
						if (NPC.downedMechBoss1 && player.ZoneJungle)
						{
							if (Main.rand.NextFloat() < Config.LootYeletsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Yelets, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.ArmoredSkeleton)
						{
							if (Main.rand.NextFloat() < Config.LootBeamSwordIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BeamSword, 1, false, -1, false, false);
							}
						}
						if (npc.type == 2 || (npc.type >= 190 && npc.type <= 194) || npc.type == 317 || npc.type == 318) //Demon Eye and Wandering Eye
						{
							if (Main.rand.NextFloat() < Config.LootBlackLensIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlackLens, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.ZombieEskimo || npc.type == NPCID.ArmedZombieEskimo)
						{
							if (Main.rand.NextFloat() < Config.LootEskimoHoodIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EskimoHood, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootEskimoCoatIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EskimoCoat, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootEskimoPantsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EskimoPants, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Hellbat)
						{
							if (Main.rand.NextFloat() < Config.HellBatLootMagmaStoneIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagmaStone, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Lavabat)
						{
							if (Main.rand.NextFloat() < Config.LavaBatLootMagmaStoneIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagmaStone, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.SnowFlinx)
						{
							if (Main.rand.NextFloat() < Config.LootSnowballLauncherIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SnowballLauncher, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.MossHornet)
						{
							if (Main.rand.NextFloat() < Config.LootTatteredBeeWingIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TatteredBeeWing, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.ScutlixRider)
						{
							if (Main.rand.NextFloat() < Config.LootBrainScramblerIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BrainScrambler, 1, false, -1, false, false);
							}
						}
						if (npc.type == 63 || npc.type == 64 || npc.type == 103) //Basic Jellyfish
						{
							if (Main.rand.NextFloat() < Config.LootJellyfishNecklaceIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.JellyfishNecklace, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DesertLamiaLight || npc.type == NPCID.DesertLamiaDark)
						{
							if (Main.rand.NextFloat() < Config.LootLamiaClothesIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LamiaHat, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootLamiaClothesIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LamiaPants, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootLamiaClothesIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LamiaShirt, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Vampire)
						{
							if (Main.rand.NextFloat() < Config.LootMoonStoneIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonStone, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.RedDevil)
						{
							if (Main.rand.NextFloat() < Config.LootFireFeatherIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FireFeather, 1, false, -1, false, false);
							}
						}
						if (Config.SlimeStaffIncreaseToSurfaceSlimes && (npc.type == NPCID.GreenSlime || npc.type == NPCID.BlueSlime || npc.type == NPCID.PurpleSlime || npc.type == NPCID.IceSlime || npc.type == NPCID.SandSlime || npc.type == NPCID.JungleSlime))
						{
							if (Main.rand.NextFloat() < Config.LootSlimeStaffIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
							}
						}
						if (Config.SlimeStaffIncreaseToUndergroundSlimes && (npc.type == NPCID.RedSlime || npc.type == NPCID.YellowSlime))
						{
							if (Main.rand.NextFloat() < Config.LootSlimeStaffIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
							}
						}
						if (Config.SlimeStaffIncreaseToCavernSlimess && (npc.type == NPCID.BlackSlime || npc.type == NPCID.MotherSlime || npc.type == NPCID.BabySlime))
						{
							if (Main.rand.NextFloat() < Config.LootSlimeStaffIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
							}
						}
						if (Config.SlimeStaffIncreaseToIceSpikedSlimes && npc.type == NPCID.SpikedIceSlime)
						{
							if (Main.rand.NextFloat() < Config.LootSlimeStaffIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
							}
						}
						if (Config.SlimeStaffIncreaseToSpikedJungleSlimes && npc.type == NPCID.SpikedJungleSlime)
						{
							if (Main.rand.NextFloat() < Config.LootSlimeStaffIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
							}
						}
						if (Main.hardMode && player.ZoneBeach)
						{
							if (Main.rand.NextFloat() < Config.LootPirateMapIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PirateMap, 1, false, -1, false, false);
							}
						}
						if (Main.hardMode && player.ZoneRockLayerHeight && (player.ZoneCorrupt || player.ZoneCrimson))
						{
							if (Main.rand.NextFloat() < Config.LootSoulofNightIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofNight, 1, false, -1, false, false);
							}
						}
						if (Main.hardMode && player.ZoneRockLayerHeight && player.ZoneHoly)
						{
							if (Main.rand.NextFloat() < Config.LootSoulofLightIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofLight, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Unicorn)
						{
							if (Main.rand.NextFloat() < Config.LootUnicornonaStickIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.UnicornonaStick, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DiggerHead || npc.type == NPCID.GiantWormHead)
						{
							if (Main.rand.NextFloat() < Config.LootWhoopieCushionIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WhoopieCushion, 1, false, -1, false, false);
							}
						}
						if (player.ZoneSnow && Main.hardMode) //Skeletron
						{
							if (Main.rand.NextFloat() < Config.LootAmarokIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Amarok, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.UndeadMiner)
						{
							if (Main.rand.NextFloat() < Config.LootBonePickaxeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BonePickaxe, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootMiningHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MiningHelmet, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootMiningShirtIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MiningShirt, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootMiningPantsIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MiningPants, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Psycho)
						{
							if (Main.rand.NextFloat() < Config.LootPsychoKnifeIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PsychoKnife, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.CorruptBunny)
						{
							if (Main.rand.NextFloat() < Config.LootBunnyHoodIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BunnyHood, 1, false, -1, false, false);
							}
						}
						if (npc.type >= 78 && npc.type <= 80) //Mummies
						{
							if (Main.rand.NextFloat() < Config.LootMummyCostumeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MummyMask, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootMummyCostumeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MummyShirt, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootMummyCostumeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MummyPants, 1, false, -1, false, false);
							}
						}
						if (npc.type == 31 || (npc.type >= 294 && npc.type <= 296) || npc.type == NPCID.CursedSkull || npc.type == NPCID.DarkCaster) //Angry Bones, Cursed Skull, and Dark Caster
						{
							if (Main.rand.NextFloat() < Config.LootGoldenKeyIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenKey, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootTallyCounterIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TallyCounter, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Werewolf)
						{
							if (Main.rand.NextFloat() < Config.LootMoonCharmIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonCharm, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DesertBeast)
						{
							if (Main.rand.NextFloat() < Config.LootAncientHornIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientHorn, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Demon)
						{
							if (Main.rand.NextFloat() < Config.LootDemonScytheIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DemonScythe, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Shark)
						{
							if (Main.rand.NextFloat() < Config.LootDivingHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DivingHelmet, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Eyezor)
						{
							if (Main.rand.NextFloat() < Config.LootEyeSpringIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EyeSpring, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.IceElemental || npc.type == NPCID.IcyMerman)
						{
							if (Main.rand.NextFloat() < Config.LootFrostStaffIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FrostStaff, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.WalkingAntlion)
						{
							if (Main.rand.NextFloat() < Config.LootMandibleBladeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AntlionClaw, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.MeteorHead)
						{
							if (Main.rand.NextFloat() < Config.LootMeteoriteIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Meteorite, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.CorruptPenguin || npc.type == NPCID.CrimsonPenguin)
						{
							if (Main.rand.NextFloat() < Config.LootPedguinssuitIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PedguinHat, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootPedguinssuitIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PedguinShirt, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootPedguinssuitIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PedguinPants, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.UndeadViking)
						{
							if (Main.rand.NextFloat() < Config.LootVikingHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.VikingHelmet, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.UmbrellaSlime)
						{
							if (Main.rand.NextFloat() < Config.LootUmbrellaHatIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.UmbrellaHat, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Vampire || npc.type == NPCID.VampireBat)
						{
							if (Main.rand.NextFloat() < Config.LootBrokenBatWingIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BrokenBatWing, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DesertDjinn)
						{
							if (Main.rand.NextFloat() < Config.LootDesertSpiritLampIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DjinnLamp, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Piranha)
						{
							if (Main.rand.NextFloat() < Config.LootHookIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Hook, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.LightMummy || npc.type == NPCID.DesertGhoulHallow || npc.type == NPCID.SandsharkHallow)
						{
							if (Main.rand.NextFloat() < Config.LootLightShardIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LightShard, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DesertLamiaLight)
						{
							if (Main.rand.NextFloat() < Config.LootMoonMaskIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonMask, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DesertLamiaDark)
						{
							if (Main.rand.NextFloat() < Config.LootSunMaskIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SunMask, 1, false, -1, false, false);
							}
						}
						if (npc.type >= 333 && npc.type <= 336) //Present Slimes
						{
							if (Main.rand.NextFloat() < Config.LootGiantBowIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GiantBow, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.ZombieRaincoat)
						{
							if (Main.rand.NextFloat() < Config.LootRainArmorIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RainCoat, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootRainArmorIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RainCoat, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Mimic && player.ZoneSnow)
						{
							if (Main.rand.NextFloat() < Config.LootToySledIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ToySled, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.SkeletonSniper)
						{
							if (Main.rand.NextFloat() < Config.LootSniperRifleIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SniperRifle, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootRifleScopeIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RifleScope, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.TacticalSkeleton)
						{
							if (Main.rand.NextFloat() < Config.LootTacticalShotgunIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TacticalShotgun, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootSWATHelmetIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SWATHelmet, 1, false, -1, false, false);
							}
						}
						if (npc.type >= 524 && npc.type <= 527) //Ghouls
						{
							if (Main.rand.NextFloat() < Config.LootAncientClothIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCloth, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.DesertGhoulCorruption || npc.type == NPCID.DesertGhoulCrimson)
						{
							if (Main.rand.NextFloat() < Config.LootDarkShardIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DarkShard, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.AngryNimbus)
						{
							if (Main.rand.NextFloat() < Config.LootNimbusRodIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.NimbusRod, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.BoneLee)
						{
							if (Main.rand.NextFloat() < Config.LootBlackBeltIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlackBelt, 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.LootTabiIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Tabi, 1, false, -1, false, false);
							}
						}
						if (Main.halloween && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead)
						{
							if (Main.rand.NextFloat() < Config.LootGoodieBagIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoodieBag, 1, false, -1, false, false);
							}
						}
						if (Main.xMas && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead)
						{
							if (Main.rand.NextFloat() < Config.LootPresentIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Present, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Drippler || npc.type == NPCID.BloodZombie)
						{
							if (Main.rand.NextFloat() < Config.LootMoneyTroughIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoneyTrough, 1, false, -1, false, false);
							}
						}
						if (npc.type == 42 || npc.type == 141|| npc.type == 176 || (npc.type >= 231 && npc.type <= 235)) //Hornet, Moss Hornet, and Toxic Sludge
						{
							if (Main.rand.NextFloat() < Config.LootBezoarIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bezoar, 1, false, -1, false, false);
							}
						}
						if (Main.halloween && npc.value > 0f && npc.value < 500f && npc.damage < 40 && npc.defense < 20)
						{
							if (Main.rand.NextFloat() < Config.LootBloodyMacheteIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BloodyMachete, 1, false, -1, false, false);
							}
						}
						if (npc.type >= 494 && npc.type <= 506) //Giant Shellies, Crawdads, and Salamanders
						{
							if (Main.rand.NextFloat() < Config.LootRallyIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Rally, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Medusa)
						{
							if (Main.rand.NextFloat() < Config.LootPocketMirrorIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PocketMirror, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Mothron)
						{
							if (Main.rand.NextFloat() < Config.LootMothronWingsIncrease * difficultyMultiplier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MothronWings, 1, false, -1, false, false);
							}
						}
						if (Main.bloodMoon && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead && Main.hardMode)
						{
							if (Main.rand.NextFloat() < Config.LootKOCannonIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.KOCannon, 1, false, -1, false, false);
							}
						}
						if (npc.type == 16 || npc.type == 58 || npc.type == 167 || npc.type == 197 || npc.type == 185 || (npc.type >= 494 && npc.type <= 506)) //Salamanders, Giant Shellys, Crawdads, Mother Slimes, Piranhas, Snow Flinxes, Undead Vikings, and Armored Vikings.
						{
							if (Main.rand.NextFloat() < Config.LootCompassIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Compass, 1, false, -1, false, false);
							}
						}
						if (npc.type == 49 || npc.type == 93 || npc.type == 51 || npc.type == 150 || (npc.type >= 494 && npc.type <= 506)) //Cave Bats, Giant Bats, Jungle Bats, Ice Bats, Salamanders, Giant Shellys, and Crawdads.
						{
							if (Main.rand.NextFloat() < Config.LootDepthMeterIncrease)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DepthMeter, 1, false, -1, false, false);
							}
						}
						if (npc.type == 22) //Guide NPC
						{
							if (Main.rand.NextFloat() < Config.LootGreenCap)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 867, 1, false, -1, false, false);
							}
						}
						if (npc.type == 207) //Dye Trader NPC
						{
							if (Main.rand.NextFloat() < Config.LootExoticScimitar)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3349, 1, false, -1, false, false);
							}
						}
						if (npc.type == 550) //Tavernkeep NPC
						{
							if (Main.rand.NextFloat() < Config.LootAleTosser)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3821, 1, false, -1, false, false);
							}
						}
						if (npc.type == 353) //Stylist NPC
						{
							if (Main.rand.NextFloat() < Config.LootStylishScissors)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3352, 1, false, -1, false, false);
							}
						}
						if (npc.type == 227) //Painter NPC
						{
							if (Main.rand.NextFloat() < Config.LootStylishScissors)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3352, 1, false, -1, false, false);
							}
						}
						if (npc.type == 208) //Party Girl NPC
						{
							if (Main.rand.NextFloat() < Config.LootPaintballGun)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3350, Main.rand.Next(30, 61), false, -1, false, false);
							}
						}
						if (npc.type == 441) //Tax Collector Guide NPC
						{
							if (Main.rand.NextFloat() < Config.LootClassyCane)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3351, 1, false, -1, false, false);
							}
						}
						if (npc.type == 244 && (Config.LootRainbowBlockDropMinIncrease < Config.LootRainbowBlockDropMaxIncrease)) //RainbowSlime
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 662, Main.rand.Next(Config.LootRainbowBlockDropMinIncrease - 30, Config.LootRainbowBlockDropMaxIncrease - 60), false, -1, false, false); //Rainbow Block
						}
					
						//Chest Drop
						if (Config.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop > 0)
						{
							if (Config.LivingWoodChestRecipe == false && player.ZoneOverworldHeight && Main.rand.NextFloat() < Config.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 831, 1, false, -1, false, false); //Living Wood Chest
							if ((player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight) && Main.rand.NextFloat() < Config.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 306, 1, false, -1, false, false); //Gold Chest
							if (player.ZoneSnow && player.ZoneRockLayerHeight && Main.rand.NextFloat() < Config.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 681, 1, false, -1, false, false); //Ice Chest
							if (player.ZoneJungle && player.ZoneRockLayerHeight && Main.rand.NextFloat() < Config.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 680, 1, false, -1, false, false); //Ivy Chest
							if ((npc.type == 198 || npc.type == 199 || npc.type == 226) && Main.rand.NextFloat() < Config.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1142, 1, false, -1, false, false); //Lihzahrd Chest
							if (player.ZoneSkyHeight && Main.rand.NextFloat() < Config.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 838, 1, false, -1, false, false); //Skyware Chest
							if ((npc.type == 57 || npc.type == 58 || (npc.type >= 63 && npc.type <= 65) || npc.type == 67 || npc.type == 102 || npc.type == 103 || npc.type == 157 || npc.type == 220 || npc.type == 221 || npc.type == 241 || npc.type == 242 || npc.type == 256 || npc.type == 465) && Main.rand.NextFloat() < Config.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop) //Water Enemies (https://terraria.gamepedia.com/Water#Contents)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1298, 1, false, -1, false, false); //Water Chest
							if (((npc.type >= 163 && npc.type <= 165) || npc.type == 238) && Main.rand.NextFloat() < Config.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop) //Spider Nest Enemies
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 952, 1, false, -1, false, false); //Web Covered Chest
							if (player.ZoneUnderworldHeight && Main.rand.NextFloat() < Config.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 328, 1, false, -1, false, false); //Shadow Chest
							if (player.ZoneDungeon && NPC.downedPlantBoss)
							{
								if (Main.rand.NextFloat() < Config.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop && ReducedGrindingWorld.jungleChestMined)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1528, 1, false, -1, false, false); //Jungle Chest
								if (ReducedGrindingWorld.infectionChestMined)
								{
									if (Main.rand.NextFloat() < Config.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1529, 1, false, -1, false, false); //Corruption Chest
									if (Main.rand.NextFloat() < Config.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1530, 1, false, -1, false, false); //Crimson Chest
								}
								if (Main.rand.NextFloat() < Config.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop && ReducedGrindingWorld.hallowedChestMined)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1531, 1, false, -1, false, false); //Hallowed Chest
								if (Main.rand.NextFloat() < Config.AllEnemiesLootBiomeMatchingFoundOnlyChestDrop && ReducedGrindingWorld.frozenChestMined)
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1532, 1, false, -1, false, false); //Frozen Chest
							}
						}

						//Modded Loot
						float lockboxDropModdifier = 0.0f;
						if (Main.hardMode)
							lockboxDropModdifier = Config.HardmodeModdedLockBoxDropRateModifier;
						else
							lockboxDropModdifier = Config.NormalmodeModdedLockBoxDropRateModifier;
						
						if (player.ZoneDungeon)
						{
							if (Main.rand.NextFloat() < Config.DungeonFurnitureLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Blue_Dungeon_Lock_Box"), 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.DungeonFurnitureLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Green_Dungeon_Lock_Box"), 1, false, -1, false, false);
							}
							if (Main.rand.NextFloat() < Config.DungeonFurnitureLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Pink_Dungeon_Lock_Box"), 1, false, -1, false, false);
							}
							if (NPC.downedPlantBoss)
							{
								if (Main.rand.NextFloat() < Config.DungeonModdedBiomeLockBoxLoot*lockboxDropModdifier)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Biome_Lock_Box"), 1, false, -1, false, false);
								}
							}
						}
						if (player.ZoneUnderworldHeight)
						{
							if (Main.rand.NextFloat() < Config.HellBiomeModdedShadowLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Shadow_Lock_Box"), 1, false, -1, false, false);
							}
						}
						if (player.ZoneSnow && player.ZoneRockLayerHeight)
						{
							if (Main.rand.NextFloat() < Config.UndergroundSnowBiomeModdedIceLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Ice_Lock_Box"), 1, false, -1, false, false);
							}
						}
						if (player.ZoneJungle && player.ZoneRockLayerHeight)
						{
							if (Main.rand.NextFloat() < Config.UndergroundJungleBiomeModdedIvyLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Ivy_Lock_Box"), 1, false, -1, false, false);
							}
						}
						if (player.ZoneOverworldHeight)
						{
							if (Main.rand.NextFloat() < Config.SurfaceModdedLivingWoodLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Living_Wood_Lock_Box"), 1, false, -1, false, false);
							}
						}
						if (npc.type == 57 || npc.type == 58 || (npc.type >= 63 && npc.type <= 65) || npc.type == 67 || npc.type == 102 || npc.type == 103 || npc.type == 157 || npc.type == 220 || npc.type == 221 || npc.type == 241 || npc.type == 242 || npc.type == 256 || npc.type == 465) //Water Enemies (https://terraria.gamepedia.com/Water#Contents)
						{
							if (Main.rand.NextFloat() < Config.WaterEnemyModdedWaterLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Water_Lock_Box"), 1, false, -1, false, false);
							}
						}
						if (npc.type == 48) //Harpy
						{
							if (Main.rand.NextFloat() < Config.SkyModdedSkywareLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Skyware_Lock_Box"), 1, false, -1, false, false);
							}
						}
						if (player.ZoneSandstorm || player.ZoneUndergroundDesert)
						{
							if (Main.rand.NextFloat() < Config.SandstormAndUndergroundDesertPyramidLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Pyramid_Lock_Box"), 1, false, -1, false, false);
							}
						}
						if (player.ZoneRockLayerHeight)
						{
							if (Main.rand.NextFloat() < Config.CavernModdedCavernLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Cavern_Lock_Box"), 1, false, -1, false, false);
							}
						}
						if (npc.type == 198 || npc.type == 199 || npc.type == 226) //Lihzard Temple Enemies
						{
							if (Main.rand.NextFloat() < Config.JungleTempleLihzahrd_Lock_Box*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Lihzahrd_Lock_Box"), 1, false, -1, false, false);
							}
						}
						if ((npc.type >= 163 && npc.type <= 165) || npc.type == 238) //Spider Nest Enemies
						{
							if (Main.rand.NextFloat() < Config.SpiderNestWebCoveredLockBoxLoot*lockboxDropModdifier)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Web_Covered_Lock_Box"), 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Drippler || npc.type == NPCID.BloodZombie)
						{
							if (Main.rand.NextFloat() < Config.BloodZombieAndDripplerDropsBloodMoonMedallion)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Blood_Moon_Medallion"), 1, false, -1, false, false);
							}
						}
					}
					
					//Restock Traveling Merchant
					if (Config.ChanceThatEnemyKillWillResetTravelingMerchant > 0)
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
							if (Main.rand.NextFloat() < Config.ChanceThatEnemyKillWillResetTravelingMerchant/travelingMerchantResetChanceModifier)
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
			if (Config.EnchantedSwordRecipe)
			{
				recipe.AddIngredient(ItemID.EnchantedBoomerang,1);
				recipe.AddIngredient(ItemID.Muramasa,1);
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(ItemID.EnchantedSword);
				recipe.AddRecipe();
				
				recipe = new ModRecipe(this);
			}
			if (Config.ArkhalisRecipe)
			{
				recipe.AddIngredient(ItemID.EnchantedSword,1);
				recipe.AddIngredient(ItemID.DarkLance,1);
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(ItemID.Arkhalis);
				recipe.AddRecipe();
				
				recipe = new ModRecipe(this);
			}
			if (Config.EnchangedSwordInNightsEdgeRecipe)
			{
				recipe.AddIngredient(ItemID.LightsBane,1);
				recipe.AddIngredient(ItemID.EnchantedSword,1);
				recipe.AddIngredient(ItemID.BladeofGrass,1);
				recipe.AddIngredient(ItemID.FieryGreatsword,1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(ItemID.NightsEdge);
				recipe.AddRecipe();
				
				recipe = new ModRecipe(this);
				recipe.AddIngredient(ItemID.BloodButcherer,1);
				recipe.AddIngredient(ItemID.EnchantedSword,1);
				recipe.AddIngredient(ItemID.BladeofGrass,1);
				recipe.AddIngredient(ItemID.FieryGreatsword,1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(ItemID.NightsEdge);
				recipe.AddRecipe();
				
				recipe = new ModRecipe(this);
			}
			if (Config.ArkhalisInNightsEdgeRecipe)
			{
				recipe.AddIngredient(ItemID.LightsBane,1);
				recipe.AddIngredient(ItemID.Arkhalis,1);
				recipe.AddIngredient(ItemID.BladeofGrass,1);
				recipe.AddIngredient(ItemID.FieryGreatsword,1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(ItemID.NightsEdge);
				recipe.AddRecipe();
				
				recipe = new ModRecipe(this);
				recipe.AddIngredient(ItemID.BloodButcherer,1);
				recipe.AddIngredient(ItemID.Arkhalis,1);
				recipe.AddIngredient(ItemID.BladeofGrass,1);
				recipe.AddIngredient(ItemID.FieryGreatsword,1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(ItemID.NightsEdge);
				recipe.AddRecipe();
			}
			if (Config.CloudinaBottleRecipe)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(ItemID.Bottle,1);
				recipe.AddIngredient(ItemID.Cloud,64);
				recipe.AddTile(TileID.CrystalBall);
				recipe.SetResult(ItemID.CloudinaBottle);
				recipe.AddRecipe();
			}
			if (Config.BlizzardinaBottleRecipe)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(ItemID.CloudinaBottle,1);
				recipe.AddIngredient(ItemID.SnowBlock,64);
				recipe.AddTile(TileID.CrystalBall);
				recipe.SetResult(ItemID.BlizzardinaBottle);
				recipe.AddRecipe();
			}
			if (Config.SandstorminaBottleRecipe)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(ItemID.CloudinaBottle,1);
				recipe.AddIngredient(ItemID.SandBlock,64);
				recipe.AddTile(TileID.CrystalBall);
				recipe.SetResult(ItemID.SandstorminaBottle);
				recipe.AddRecipe();
			}
			if (Config.CelestialSigilRecipe)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(ItemID.FragmentSolar, Config.CelestialSigilEachLunarFragmentCost);
				recipe.AddIngredient(ItemID.FragmentVortex, Config.CelestialSigilEachLunarFragmentCost);
				recipe.AddIngredient(ItemID.FragmentNebula, Config.CelestialSigilEachLunarFragmentCost);
				recipe.AddIngredient(ItemID.FragmentStardust, Config.CelestialSigilEachLunarFragmentCost);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.SetResult(ItemID.CelestialSigil);
				recipe.AddRecipe();
			}
			if (Config.LivingWoodChestRecipe)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(ItemID.Wood, 8);
				recipe.AddIngredient(ItemID.IronBar, 2);
				recipe.AddTile(TileID.LivingLoom);
				recipe.SetResult(ItemID.LivingWoodChest);
				recipe.AddRecipe();
				
				recipe = new ModRecipe(this);
				recipe.AddIngredient(ItemID.Wood, 8);
				recipe.AddIngredient(ItemID.LeadBar, 2);
				recipe.AddTile(TileID.LivingLoom);
				recipe.SetResult(ItemID.LivingWoodChest);
				recipe.AddRecipe();
			}
			if (Config.HermesBootsRecipe)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(225, Config.HermesBootsSilkCost);
				recipe.AddIngredient(290, Config.HermesBootsSwiftnessPotionCost);
				recipe.AddTile(TileID.Loom);
				recipe.SetResult(54);
				recipe.AddRecipe();
			}
			if (Config.LavaCharmRecipe)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(318, Config.LavaCharmFireblossomCost);
				recipe.AddIngredient(317, Config.LavaCharmWaterleafCost);
				recipe.AddIngredient(175, Config.LavaCharmHellstoneBarCost);
				recipe.AddTile(TileID.Loom);
				recipe.SetResult(906);
				recipe.AddRecipe();
			}
			if (Config.CrateDowngradeRecipes)
			{
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
			}
			if (Config.CrateUpgradeRecipes)
			{
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
			}
				
			recipe = new ModRecipe(this);
			recipe.AddIngredient(1534, 1); //Corruption Key
			recipe.SetResult(1535); //Crimson Key
			recipe.AddRecipe();
				
			recipe = new ModRecipe(this);
			recipe.AddIngredient(1535, 1); //Crimson Key
			recipe.SetResult(1534); //Corruption Key
			recipe.AddRecipe();
			
			if (Config.CrawdadGiantShellySalamanderBannerRecipe)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(3392, 1); //Giant Shelly Banner
				if (Config.CrawdadGiantShellySalamanderBannerCostOneOfEach)
					recipe.AddIngredient(3391, 1); //Salamander Banner
				recipe.AddTile(TileID.Loom);
				recipe.SetResult(3393); //Crawdad Banner
				recipe.AddRecipe();
				
				recipe = new ModRecipe(this);
				recipe.AddIngredient(3393, 1); //Crawdad Banner
				if (Config.CrawdadGiantShellySalamanderBannerCostOneOfEach)
					recipe.AddIngredient(3392, 1); //Giant Shelly Banner
				recipe.AddTile(TileID.Loom);
				recipe.SetResult(3391); //Salamander Banner
				recipe.AddRecipe();
				
				recipe = new ModRecipe(this);
				recipe.AddIngredient(3391, 1); //Salamander Banner
				if (Config.CrawdadGiantShellySalamanderBannerCostOneOfEach)
					recipe.AddIngredient(3393, 1); //Crawdad Banner
				recipe.AddTile(TileID.Loom);
				recipe.SetResult(3392); //Giant Shelly Banner
				recipe.AddRecipe();
			}
			
			if (Config.GuideVoodooDollRecipe)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(1307, Config.GuideVoodooDollClothierVoodooDollCost); //ClothierVoodooDoll
				recipe.AddIngredient(521, Config.GuideVoodooDollSoulOfNightCost); //Soul of Night
				recipe.AddTile(TileID.CrystalBall);
				recipe.SetResult(267); //Guide Voodoo Doll
				recipe.AddRecipe();
			}
		
		}
		
    }

    class SpawnRateMultiplierGlobalNPC : GlobalNPC
    {
		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			if (player.FindBuffIndex(mod.BuffType("War")) != -1)
			{
				spawnRate = (int)(spawnRate / Config.WarPotionSpawnrateMultiplier);
				maxSpawns = (int)(maxSpawns * Config.WarPotionMaxSpawnsMultiplier);
			}
			if (player.FindBuffIndex(mod.BuffType("Chaos")) != -1)
			{
				spawnRate = (int)(spawnRate / Config.ChaosPotionSpawnrateMultiplier);
				maxSpawns = (int)(maxSpawns * Config.ChaosPotionMaxSpawnsMultiplier);
			}
			if (player.FindBuffIndex(BuffID.Battle) != -1)
			{
				spawnRate = (int)(spawnRate / Config.BattlePotionSpawnrateMultiplier);
				maxSpawns = (int)(maxSpawns * Config.BattlePotionMaxSpawnsMultiplier);
			}
		}
    }

}