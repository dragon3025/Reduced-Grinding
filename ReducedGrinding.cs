using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

//To debug, use:
//ErrorLogger.Log(<string>);

//To turn into a string use:
//Value.ToString()

//To show text in chat use:
//Main.NewText(string, red, green, blue);

//Chatting a value:
//Main.NewText(Value.ToString(), 255, 255, 255);

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
				if (arg == ItemID.BrainOfCthulhuBossBag && Config.BagBoneRattleIncrease > 0)
				{
					if (Main.rand.Next(10000)+1 <= Config.BagBoneRattleIncrease*10000)
					{
						player.QuickSpawnItem(ItemID.BoneRattle, 1);
					}
				}
				if (arg == ItemID.FishronBossBag && Config.BagFishronWingsIncrease > 0)
				{
					if (Main.rand.Next(10000)+1 <= Config.BagFishronWingsIncrease*10000)
					{
						player.QuickSpawnItem(ItemID.FishronWings, 1);
					}
				}
				if (arg == ItemID.EaterOfWorldsBossBag && Config.BagEatersBoneIncrease > 0)
				{
					if (Main.rand.Next(10000)+1 <= Config.BagEatersBoneIncrease*10000)
					{
						player.QuickSpawnItem(ItemID.EatersBone, 1);
					}
				}
				if (arg == ItemID.EyeOfCthulhuBossBag && Config.BagBinocularsIncrease > 0)
				{
					if (Main.rand.Next(10000)+1 <= Config.BagBinocularsIncrease*10000)
					{
						player.QuickSpawnItem(ItemID.Binoculars, 1);
					}
				}
				if (arg == ItemID.PlanteraBossBag)
				{
					if (Config.BagTheAxeIncrease > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.BagTheAxeIncrease*10000)
						{
							player.QuickSpawnItem(ItemID.TheAxe, 1);
						}

					}
					if (Config.BagSeedlingIncrease > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.BagSeedlingIncrease*10000)
						{
							player.QuickSpawnItem(ItemID.Seedling, 1);
						}

					}
				}
				if (arg == ItemID.QueenBeeBossBag)
				{
					if (Config.BagHoneyedGogglesIncrease > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.BagHoneyedGogglesIncrease*10000)
						{
							player.QuickSpawnItem(ItemID.HoneyedGoggles, 1);
						}
					}
					if (Config.BagNectarIncrease > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.BagNectarIncrease*10000)
						{
							player.QuickSpawnItem(ItemID.Nectar, 1);
						}
					}
				}
				if (arg == ItemID.SkeletronBossBag)
				{
					if (Config.BagBookofSkullsIncrease > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.BagBookofSkullsIncrease*10000)
						{
							player.QuickSpawnItem(ItemID.BookofSkulls, 1);
						}
					}
					if (Config.BagSkeletronBoneKey > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.BagSkeletronBoneKey*10000)
						{
							player.QuickSpawnItem(ItemID.BookofSkulls, 1);
						}
					}
				}
				if (arg == ItemID.JungleFishingCrate)
				{
					if (Config.JungleCrateSeaweed > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.JungleCrateSeaweed*10000)
						{
							player.QuickSpawnItem(ItemID.Seaweed, 1);
						}
					}
					if (Config.JungleCrateFlowerBoots > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.JungleCrateFlowerBoots*10000)
						{
							player.QuickSpawnItem(ItemID.FlowerBoots, 1);
						}
					}
					if (Config.JungleCrateLivingMahoganyWand > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.JungleCrateLivingMahoganyWand*10000)
						{
							player.QuickSpawnItem(ItemID.LivingMahoganyWand, 1);
						}
					}
					if (Config.JungleCrateRichMahoganyLeafWand > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.JungleCrateRichMahoganyLeafWand*10000)
						{
							player.QuickSpawnItem(ItemID.LivingMahoganyLeafWand, 1);
						}
					}
				}
				if (arg == ItemID.WoodenCrate || arg == ItemID.IronCrate || arg == ItemID.GoldenCrate)
				{
					if (Config.WoodenIronAndGoldCrateLivingLoom > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.WoodenIronAndGoldCrateLivingLoom*10000)
						{
							player.QuickSpawnItem(ItemID.LivingLoom, 1);
						}
					}
					if (Config.WoodenIronAndGoldCrateLeafWand > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.WoodenIronAndGoldCrateLeafWand*10000)
						{
							player.QuickSpawnItem(ItemID.LeafWand, 1);
						}
					}
					if (Config.WoodenIronAndGoldCrateLivingWoodWand > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.WoodenIronAndGoldCrateLivingWoodWand*10000)
						{
							player.QuickSpawnItem(ItemID.LivingWoodWand, 1);
						}
					}
				}
				if (Config.WoodenIronAndGoldCrateWaterWalkingBoots > 0)
				{
					if (arg == ItemID.WoodenCrate)
					{
						if (Main.rand.Next(10000)+1 <= Config.WoodenIronAndGoldCrateWaterWalkingBoots*10000/4)
						{
							player.QuickSpawnItem(863, 1); //Water walking boots
						}
					}
					if (arg == ItemID.IronCrate)
					{
						if (Main.rand.Next(10000)+1 <= Config.WoodenIronAndGoldCrateWaterWalkingBoots*10000/2)
						{
							player.QuickSpawnItem(863, 1); //Water walking boots
						}
					}
					if (arg == ItemID.GoldenCrate)
					{
						if (Main.rand.Next(10000)+1 <= Config.WoodenIronAndGoldCrateWaterWalkingBoots*10000)
						{
							player.QuickSpawnItem(863, 1); //Water walking boots
						}
					}
				}
				if (Config.WoodenIronAndGoldCrateWaterFlippers > 0)
				{
					if (arg == ItemID.WoodenCrate)
					{
						if (Main.rand.Next(10000)+1 <= Config.WoodenIronAndGoldCrateWaterFlippers*10000/4)
						{
							player.QuickSpawnItem(863, 1); //Water walking boots
						}
					}
					if (arg == ItemID.IronCrate)
					{
						if (Main.rand.Next(10000)+1 <= Config.WoodenIronAndGoldCrateWaterFlippers*10000/2)
						{
							player.QuickSpawnItem(863, 1); //Water walking boots
						}
					}
					if (arg == ItemID.GoldenCrate)
					{
						if (Main.rand.Next(10000)+1 <= Config.WoodenIronAndGoldCrateWaterFlippers*10000)
						{
							player.QuickSpawnItem(863, 1); //Water walking boots
						}
					}
				}
				if (context == "present")
				{
					if (Config.PresentDogWhistle > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentDogWhistle*10000)
						{
							player.QuickSpawnItem(1927, 1);
						}
					}
					if (Config.PresentToolbox > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentToolbox*10000)
						{
							player.QuickSpawnItem(1923, 1);
						}
					}
					if (Config.PresentHandWarmer > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentHandWarmer*10000)
						{
							player.QuickSpawnItem(1921, 1);
						}
					}
					if (Config.PresentCandyCanePickaxe > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentCandyCanePickaxe*10000)
						{
							player.QuickSpawnItem(1917, 1);
						}
					}
					if (Config.PresentCandyCaneHook > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentCandyCaneHook*10000)
						{
							player.QuickSpawnItem(1915, 1);
						}
					}
					if (Config.PresentFruitcakeChakram > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentFruitcakeChakram*10000)
						{
							player.QuickSpawnItem(1918, 1);
						}
					}
					if (Config.PresentRedRyderPlusMusketBall > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentRedRyderPlusMusketBall*10000)
						{
							player.QuickSpawnItem(1870, 1);
							player.QuickSpawnItem(97, Main.rand.Next(30,60));
						}
					}
					if (Config.PresentCandyCaneSword > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentCandyCaneSword*10000)
						{
							player.QuickSpawnItem(1909, 1);
						}
					}
					if (Config.PresentMrsClausCostume > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentMrsClausCostume*10000)
						{
							player.QuickSpawnItem(1932, 1);
							player.QuickSpawnItem(1933, 1);
							player.QuickSpawnItem(1934, 1);
						}
					}
					if (Config.PresentParkaOutfit > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentParkaOutfit*10000)
						{
							player.QuickSpawnItem(1935, 1);
							player.QuickSpawnItem(1936, 1);
							player.QuickSpawnItem(1937, 1);
						}
					}
					if (Config.PresentTreeCostume > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentTreeCostume*10000)
						{
							player.QuickSpawnItem(1940, 1);
							player.QuickSpawnItem(1941, 1);
							player.QuickSpawnItem(1942, 1);
						}
					}
					if (Config.PresentSnowHat > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentSnowHat*10000)
						{
							player.QuickSpawnItem(1938, 1);
						}
					}
					if (Config.PresentUglySweater > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentUglySweater*10000)
						{
							player.QuickSpawnItem(1939, 1);
						}
					}
					if (Config.PresentReindeerAntlers > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentReindeerAntlers*10000)
						{
							player.QuickSpawnItem(1907, 1);
						}
					}
					if (Config.PresentCoal > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentCoal*10000)
						{
							player.QuickSpawnItem(1922, 1);
						}
					}
					if (Config.PresentChristmasPudding > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentChristmasPudding*10000)
						{
							player.QuickSpawnItem(1911, 1);
						}
					}
					if (Config.PresentSugarCookie > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentSugarCookie*10000)
						{
							player.QuickSpawnItem(1919, 1);
						}
					}
					if (Config.PresentGingerbreadCookie > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentGingerbreadCookie*10000)
						{
							player.QuickSpawnItem(1920, 1);
						}
					}
					if (Config.PresentStarAnise > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentStarAnise*10000)
						{
							player.QuickSpawnItem(1913, Main.rand.Next(20,40));
						}
					}
					if (Config.PresentEggnog > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentEggnog*10000)
						{
							player.QuickSpawnItem(1912, Main.rand.Next(1,3));
						}
					}
					if (Config.PresentHolly > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentHolly*10000)
						{
							player.QuickSpawnItem(1908, 1);
						}
					}
					if (Config.PresentPineTreeBlock > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentPineTreeBlock*10000)
						{
							player.QuickSpawnItem(1872, Main.rand.Next(20,49));
						}
					}
					if (Config.PresentCandyCaneBlock > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentCandyCaneBlock*10000)
						{
							player.QuickSpawnItem(586, Main.rand.Next(20,49));
						}
					}
					if (Config.PresentGreenCandyCaneBlock > 0)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentGreenCandyCaneBlock*10000)
						{
							player.QuickSpawnItem(591, Main.rand.Next(20,49));
						}
					}
					if (Config.PresentHardmodeSnowGlobe > 0 && Main.hardMode)
					{
						if (Main.rand.Next(10000)+1 <= Config.PresentHardmodeSnowGlobe*10000)
						{
							player.QuickSpawnItem(602, 1);
						}
					}
				}
            }
			
			public override void ExtractinatorUse(int extractType, ref int resultType, ref int resultStack)
			{
				if(extractType == 0 || extractType == ItemID.DesertFossil)
				{
					if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesAmberMosquito*10000/3  && extractType != ItemID.DesertFossil || Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesAmberMosquito*10000 && extractType == ItemID.DesertFossil)
					{
						resultStack = 1;
						resultType = ItemID.AmberMosquito;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesDiamond*10000)
					{
						resultStack = 1;
						resultType = ItemID.Diamond;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesRuby*10000)
					{
						resultStack = 1;
						resultType = ItemID.Ruby;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesEmerald*10000)
					{
						resultStack = 1;
						resultType = ItemID.Emerald;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesSapphire*10000)
					{
						resultStack = 1;
						resultType = ItemID.Sapphire;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesTopaz*10000)
					{
						resultStack = 1;
						resultType = ItemID.Topaz;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesAmethyst*10000)
					{
						resultStack = 1;
						resultType = ItemID.Amethyst;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesAmber*10000/2  && extractType != ItemID.DesertFossil || Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesAmber*10000 && extractType == ItemID.DesertFossil)
					{
						resultStack = 1;
						resultType = ItemID.Amber;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesGoldOre*10000)
					{
						resultStack = 1;
						resultType = ItemID.GoldOre;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesPlatinumOre*10000)
					{
						resultStack = 1;
						resultType = ItemID.PlatinumOre;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesFossilOre*10000 && extractType == ItemID.DesertFossil)
					{
						resultStack = 1;
						resultType = ItemID.FossilOre;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesSilverOre*10000)
					{
						resultStack = 1;
						resultType = ItemID.SilverOre;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesTungstenOre*10000)
					{
						resultStack = 1;
						resultType = ItemID.TungstenOre;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesIronOre*10000)
					{
						resultStack = 1;
						resultType = ItemID.IronOre;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesLeadOre*10000)
					{
						resultStack = 1;
						resultType = ItemID.LeadOre;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesCopperOre*10000)
					{
						resultStack = 1;
						resultType = ItemID.CopperOre;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesTinOre*10000)
					{
						resultStack = 1;
						resultType = ItemID.TinOre;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesPlatinumCoin*10000)
					{
						resultStack = 1;
						resultType = ItemID.PlatinumCoin;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesGoldCoin*10000)
					{
						resultStack = 1;
						resultType = ItemID.GoldCoin;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesSilverCoin*10000)
					{
						resultStack = 1;
						resultType = ItemID.SilverCoin;
					} else if (Main.rand.Next(10000)+1 <= Config.ExtractinatorGivesCopperCoin*10000)
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
				Player player = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];
				if (!npc.SpawnedFromStatue)
				{
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
							// Not a critter or other npcs that give no coins or items when killed.
							if (npc.type != 46 && npc.type != 74 && npc.type != 297 && npc.type != 298 && npc.type != 299 && npc.type != 300 && npc.type != 355 && npc.type != 357 && npc.type != 358 && npc.type != 359 && npc.type != 360 && npc.type != 361 && npc.type != 366 && npc.type != 367 && npc.type != 377 && npc.type != 442 && npc.type != 443 && npc.type != 445 && npc.type != 446 && npc.type != 447 && npc.type != 448 && npc.type != 484 && npc.type != 485 && npc.type != 486 && npc.type != 487 && npc.type != 538 && npc.type != 539 && npc.type != 55 && npc.type != 230 && npc.type != 148 && npc.type != 149 && npc.type != 362 && npc.type != 363 && npc.type != 364 && npc.type != 365 && npc.type != 374 && npc.type != 375 && npc.type != 356 && npc.type != 444 && npc.type != NPCID.Bee && npc.type != NPCID.BeeSmall)
							{
								if (Main.rand.Next(10000)+1 <= keyDropRateIncrease*10000)
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
					}
					
					for (int j=0; j<Config.DropTriesForAllEnemyDroppedLoot; j++)
					{
						//Boss Loot
						if (npc.type == NPCID.SkeletronHead && !Main.expertMode) //Skeletron
						{
							if (!Main.expertMode && Config.LootSkeletronBoneKey > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootSkeletronBoneKey*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneKey, 1, false, -1, false, false);
								}
							}
							if (Config.LootBookofSkullsIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootBookofSkullsIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BookofSkulls, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == 266 && !Main.expertMode) //Brain of Cthulhu
						{
							if (Config.LootBoneRattleIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootBoneRattleIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneRattle, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == 370 && !Main.expertMode) //Duke Fishron
						{
							if (Config.LootFishronWingsIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootFishronWingsIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FishronWings, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type >= 13 && npc.type <= 15 && !Main.expertMode && npc.boss) //Eater of Worlds
						{
							if (Config.LootEatersBoneIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootEatersBoneIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EatersBone, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == 4 && !Main.expertMode) //Eye of Cthulhu
						{
							if (Config.LootBinocularsIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootBinocularsIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Binoculars, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == 262 && !Main.expertMode) //Plantera
						{
							if (Config.LootTheAxeIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootTheAxeIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TheAxe, 1, false, -1, false, false);
								}
							}
							if (Config.LootSeedlingIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootSeedlingIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Seedling, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == 222 && !Main.expertMode) //Queen Bee
						{
							if (Config.LootHoneyedGogglesIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootHoneyedGogglesIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HoneyedGoggles, 1, false, -1, false, false);
								}
							}
							if (Config.LootNectarIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootNectarIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Nectar, 1, false, -1, false, false);
								}
							}
						}
						
						//Other Loot
						if (npc.type == NPCID.AnglerFish || npc.type == NPCID.Piranha)
						{
							if (Config.LootRobotHatIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootRobotHatIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RobotHat, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.AnglerFish || (npc.type >= 269 && npc.type <= 272) || npc.type == NPCID.Werewolf) //269 to 272 is Rusty Armored Bones
						{
							if (Main.expertMode && Config.ExpertLootAdhesiveBandageIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootAdhesiveBandageIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AdhesiveBandage, 1, false, -1, false, false);
								}
							}
							else if (!Main.expertMode && Config.LootAdhesiveBandageIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootAdhesiveBandageIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AdhesiveBandage, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.ChaosElemental && Config.LootRodofDiscordIncrease > 0)
						{
							if (Main.rand.Next(10000)+1 <= Config.LootRodofDiscordIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RodofDiscord, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Clown || npc.type == NPCID.LightMummy || npc.type == NPCID.GiantBat)
						{
							if (Main.expertMode && Config.ExpertLootTrifoldMapIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootTrifoldMapIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TrifoldMap, 1, false, -1, false, false);
								}
							}
							else if (!Main.expertMode && Config.LootTrifoldMapIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootTrifoldMapIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TrifoldMap, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Clown)
						{
							if (Main.rand.Next(10000)+1 <= Config.LootBananarangIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bananarang, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.EnchantedSword || npc.type == NPCID.CrimsonAxe || npc.type == NPCID.CursedHammer || npc.type == NPCID.CursedSkull)
						{
							if (Main.expertMode && Config.ExpertLootNazarIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootNazarIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Nazar, 1, false, -1, false, false);
								}
							}
							else if(!Main.expertMode && Config.LootNazarIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootNazarIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Nazar, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == 42 || (npc.type >= 231 && npc.type <= 235)) //Hornet
						{
							if (Main.expertMode && Config.ExpertLootMegaphoneIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootMegaphoneIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Megaphone, 1, false, -1, false, false);
								}
							}
							else if(!Main.expertMode && Config.LootMegaphoneIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootMegaphoneIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Megaphone, 1, false, -1, false, false);
								}
							}
							if (Config.LootAncientCobaltHelmetIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootAncientCobaltHelmetIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltHelmet, 1, false, -1, false, false);
								}
							}
							if (Config.LootAncientCobaltBreastplateIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootAncientCobaltBreastplateIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltBreastplate, 1, false, -1, false, false);
								}
							}
							if (Config.LootAncientCobaltLeggingsIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootAncientCobaltLeggingsIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltLeggings, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Corruptor || npc.type == NPCID.FloatyGross)
						{
							if (Main.expertMode && Config.ExpertLootVitaminsIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootVitaminsIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Vitamins, 1, false, -1, false, false);
								}
							}
							else if(!Main.expertMode && Config.LootVitaminsIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootVitaminsIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Vitamins, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Crimslime || npc.type == NPCID.BigCrimslime || npc.type == NPCID.LittleCrimslime)
						{
							if (Main.expertMode && Config.ExpertLootBlindfoldIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootBlindfoldIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Blindfold, 1, false, -1, false, false);
								}
							}
							else if(!Main.expertMode && Config.LootBlindfoldIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootBlindfoldIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Blindfold, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.DesertScorpionWalk || npc.type == NPCID.DesertScorpionWall || npc.type == NPCID.Mummy || npc.type == NPCID.Pixie || npc.type == NPCID.Wraith)
						{
							if (Main.expertMode && Config.ExpertLootFastClockIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootFastClockIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FastClock, 1, false, -1, false, false);
								}
							}
							else if(!Main.expertMode && Config.LootFastClockIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootFastClockIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FastClock, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.FlyingSnake || npc.type == NPCID.Lihzahrd || npc.type == NPCID.LihzahrdCrawler)
						{
							if (Config.LootLizardEggIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootLizardEggIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LizardEgg, 1, false, -1, false, false);
								}
							}
							if (Config.LootLihzahrdPowerCellIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootLihzahrdPowerCellIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LihzahrdPowerCell, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.GiantTortoise && Config.LootTurtleShellIncrease > 0)
						{
							if (Main.rand.Next(10000)+1 <= Config.LootTurtleShellIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TurtleShell, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.IceTortoise && Config.LootFrozenTurtleShellIncrease > 0)
						{
							if (Main.rand.Next(10000)+1 <= Config.LootFrozenTurtleShellIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FrozenTurtleShell, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Paladin)
						{
							if (Main.expertMode && Config.ExpertLootPaladinsShieldIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootPaladinsShieldIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PaladinsShield, 1, false, -1, false, false);
								}
							}
							else if(!Main.expertMode && Config.LootPaladinsShieldIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootPaladinsShieldIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PaladinsShield, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type >= 212 && npc.type <= 216) //All pirates
						{
							if (Config.PirateLootCoinGunIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.PirateLootCoinGunIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CoinGun, 1, false, -1, false, false);
								}
							}
							if (Config.PirateLootLuckyCoinIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.PirateLootLuckyCoinIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LuckyCoin, 1, false, -1, false, false);
								}
							}
							if (Config.PirateLootDiscountCardIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.PirateLootDiscountCardIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DiscountCard, 1, false, -1, false, false);
								}
							}
							if (Config.PirateLootPirateStaffIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.PirateLootPirateStaffIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PirateStaff, 1, false, -1, false, false);
								}
							}
							if (Config.PirateLootGoldRingIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.PirateLootGoldRingIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldRing, 1, false, -1, false, false);
								}
							}
							if (npc.type != NPCID.PirateCaptain)
							{
								if (Config.LootSailorHatIncrease > 0)
								{
									if (Main.rand.Next(10000)+1 <= Config.LootSailorHatIncrease*10000)
									{
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SailorHat, 1, false, -1, false, false);
									}
								}
								if (Config.LootSailorShirtIncrease > 0)
								{
									if (Main.rand.Next(10000)+1 <= Config.LootSailorShirtIncrease*10000)
									{
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SailorShirt, 1, false, -1, false, false);
									}
								}
								if (Config.LootSailorPantsIncrease > 0)
								{
									if (Main.rand.Next(10000)+1 <= Config.LootSailorPantsIncrease*10000)
									{
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SailorPants, 1, false, -1, false, false);
									}
								}
							}
							if (Config.LootGoldenFurnitureIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootGoldenFurnitureIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenChair, 1, false, -1, false, false);
								}
								if (Main.rand.Next(10000)+1 <= Config.LootGoldenFurnitureIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenToilet, 1, false, -1, false, false);
								}
								if (Main.rand.Next(10000)+1 <= Config.LootGoldenFurnitureIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenDoor, 1, false, -1, false, false);
								}
								if (Main.rand.Next(10000)+1 <= Config.LootGoldenFurnitureIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenTable, 1, false, -1, false, false);
								}
								if (Main.rand.Next(10000)+1 <= Config.LootGoldenFurnitureIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenBed, 1, false, -1, false, false);
								}
								if (Main.rand.Next(10000)+1 <= Config.LootGoldenFurnitureIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenPiano, 1, false, -1, false, false);
								}
								if (Main.rand.Next(10000)+1 <= Config.LootGoldenFurnitureIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenDresser, 1, false, -1, false, false);
								}
								if (Main.rand.Next(10000)+1 <= Config.LootGoldenFurnitureIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenSofa, 1, false, -1, false, false);
								}
								if (Main.rand.Next(10000)+1 <= Config.LootGoldenFurnitureIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenBathtub, 1, false, -1, false, false);
								}
								if (Main.rand.Next(10000)+1 <= Config.LootGoldenFurnitureIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenClock, 1, false, -1, false, false);
								}
								if (Main.rand.Next(10000)+1 <= Config.LootGoldenFurnitureIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenLamp, 1, false, -1, false, false);
								}
								if (Main.rand.Next(10000)+1 <= Config.LootGoldenFurnitureIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenBookcase, 1, false, -1, false, false);
								}
								if (Main.rand.Next(10000)+1 <= Config.LootGoldenFurnitureIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenChandelier, 1, false, -1, false, false);
								}
								if (Main.rand.Next(10000)+1 <= Config.LootGoldenFurnitureIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenLantern, 1, false, -1, false, false);
								}
								if (Main.rand.Next(10000)+1 <= Config.LootGoldenFurnitureIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenCandelabra, 1, false, -1, false, false);
								}
								if (Main.rand.Next(10000)+1 <= Config.LootGoldenFurnitureIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenCandle, 1, false, -1, false, false);
								}
								if (Main.rand.Next(10000)+1 <= Config.LootGoldenFurnitureIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenSink, 1, false, -1, false, false);
								}
							}
							if (Config.LootCutlassIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootCutlassIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cutlass, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.PirateShip)
						{
							if (Config.PirateShipLootCoinGunIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.PirateShipLootCoinGunIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CoinGun, 1, false, -1, false, false);
								}
							}
							if (Config.PirateShipLootLuckyCoinIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.PirateShipLootLuckyCoinIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LuckyCoin, 1, false, -1, false, false);
								}
							}
							if (Config.PirateShipLootDiscountCardIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.PirateShipLootDiscountCardIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DiscountCard, 1, false, -1, false, false);
								}
							}
							if (Config.PirateShipLootPirateShipStaffIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.PirateShipLootPirateShipStaffIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PirateStaff, 1, false, -1, false, false);
								}
							}
							if (Config.PirateShipLootGoldRingIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.PirateShipLootGoldRingIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldRing, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Pixie || npc.type == NPCID.GreenJellyfish || npc.type == NPCID.DarkMummy)
						{
							if (Main.expertMode && Config.ExpertLootMegaphoneIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootMegaphoneIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Megaphone, 1, false, -1, false, false);
								}
							}
							else if(!Main.expertMode && Config.LootMegaphoneIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootMegaphoneIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Megaphone, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == 77 || (npc.type >= 273 && npc.type <= 276)) //Blue Amored Bones and Armored Skeleton
						{
							if (Main.expertMode && Config.ExpertLootArmorPolishIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootArmorPolishIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ArmorPolish, 1, false, -1, false, false);
								}
							}
							else if(!Main.expertMode && Config.LootArmorPolishIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootArmorPolishIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ArmorPolish, 1, false, -1, false, false);
								}
							}
						}
						if ((npc.type == NPCID.ZombieElf || npc.type == NPCID.ZombieElfBeard || npc.type == NPCID.ZombieElfGirl))
						{
							if (Config.LootElfHatIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootElfHatIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ElfHat, 1, false, -1, false, false);
								}
							}
							if (Config.LootElfShirtIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootElfShirtIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ElfShirt, 1, false, -1, false, false);
								}
							}
							if (Config.LootElfPantsIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootElfPantsIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ElfPants, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type >= 269 && npc.type <= 280)//All Armored Bones variants
						{
							if (Main.expertMode && Config.ExpertLootWispinaBottleIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootWispinaBottleIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WispinaBottle, 1, false, -1, false, false);
								}
							}
							else if(!Main.expertMode && Config.LootWispinaBottleIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootWispinaBottleIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WispinaBottle, 1, false, -1, false, false);
								}
							}
							if (Config.LootBoneFeatherIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootBoneFeatherIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneFeather, 1, false, -1, false, false);
								}
							}
							if (Main.expertMode && Config.ExpertLootMagnetSphereIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootMagnetSphereIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagnetSphere, 1, false, -1, false, false);
								}
							}
							else if (!Main.expertMode && Config.LootMagnetSphereIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootMagnetSphereIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagnetSphere, 1, false, -1, false, false);
								}
							}
							if (Main.expertMode && Config.ExpertLootKeybrandIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootKeybrandIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Keybrand, 1, false, -1, false, false);
								}
							}
							else if(!Main.expertMode && Config.LootKeybrandIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootKeybrandIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Keybrand, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.EaterofSouls)
						{
							if (Config.LootAncientShadowHelmetIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootAncientShadowHelmetIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientShadowHelmet, 1, false, -1, false, false);
								}
							}
							if (Config.LootAncientShadowScalemailIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootAncientShadowScalemailIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientShadowScalemail, 1, false, -1, false, false);
								}
							}
							if (Config.LootAncientShadowGreavesIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootAncientShadowGreavesIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientShadowGreaves, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == 21 || (npc.type >= 201 && npc.type <= 203) || (npc.type >= 322 && npc.type <= 323) || (npc.type >= 449 && npc.type <= 452)) //Skeleton
						{
							if (Config.LootSkullIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootSkullIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Skull, 1, false, -1, false, false);
								}
							}
							if (Config.LootBoneSwordIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootBoneSwordIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneSword, 1, false, -1, false, false);
								}
							}
							if (Config.LootAncientGoldHelmetIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootAncientGoldHelmetIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientGoldHelmet, 1, false, -1, false, false);
								}
							}
							if (Config.LootAncientIronHelmetIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootAncientIronHelmetIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientIronHelmet, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == 31 || (npc.type >= 294 && npc.type <= 296)) //Angry Bones
						{
							if (Config.LootAncientNecroHelmetIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootAncientNecroHelmetIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientNecroHelmet, 1, false, -1, false, false);
								}
							}
							if (Config.LootClothierVoodooDollIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootClothierVoodooDollIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ClothierVoodooDoll, 1, false, -1, false, false);
								}
							}
							if (Config.LootBoneWandIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootBoneWandIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneWand, 1, false, -1, false, false);
								}
							}
						}
						if (player.ZoneUnderworldHeight)
						{
							
							if (Main.hardMode){
								if (Config.LootHelFireIncrease > 0)
								{
									if (Main.rand.Next(10000)+1 <= Config.LootHelFireIncrease*10000)
									{
										if (npc.type != 46 && npc.type != 74 && npc.type != 297 && npc.type != 298 && npc.type != 299 && npc.type != 300 && npc.type != 355 && npc.type != 357 && npc.type != 358 && npc.type != 359 && npc.type != 360 && npc.type != 361 && npc.type != 366 && npc.type != 367 && npc.type != 377 && npc.type != 442 && npc.type != 443 && npc.type != 445 && npc.type != 446 && npc.type != 447 && npc.type != 448 && npc.type != 484 && npc.type != 485 && npc.type != 486 && npc.type != 487 && npc.type != 538 && npc.type != 539 && npc.type != 55 && npc.type != 230 && npc.type != 148 && npc.type != 149 && npc.type != 362 && npc.type != 363 && npc.type != 364 && npc.type != 365 && npc.type != 374 && npc.type != 375 && npc.type != 356 && npc.type != 444 && npc.type != NPCID.Bee && npc.type != NPCID.BeeSmall)
										{
											Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HelFire, 1, false, -1, false, false);
										}
									}
								}
								if (Config.LootLivingFireBlockIncrease > 0)
								{
									if (Main.rand.Next(10000)+1 <= Config.LootLivingFireBlockIncrease*10000)
									{
										if (npc.type != 46 && npc.type != 74 && npc.type != 297 && npc.type != 298 && npc.type != 299 && npc.type != 300 && npc.type != 355 && npc.type != 357 && npc.type != 358 && npc.type != 359 && npc.type != 360 && npc.type != 361 && npc.type != 366 && npc.type != 367 && npc.type != 377 && npc.type != 442 && npc.type != 443 && npc.type != 445 && npc.type != 446 && npc.type != 447 && npc.type != 448 && npc.type != 484 && npc.type != 485 && npc.type != 486 && npc.type != 487 && npc.type != 538 && npc.type != 539 && npc.type != 55 && npc.type != 230 && npc.type != 148 && npc.type != 149 && npc.type != 362 && npc.type != 363 && npc.type != 364 && npc.type != 365 && npc.type != 374 && npc.type != 375 && npc.type != 356 && npc.type != 444 && npc.type != NPCID.Bee && npc.type != NPCID.BeeSmall)
										{
											Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LivingFireBlock, 1, false, -1, false, false);
										}
									}
								}
							}
							else if (NPC.downedBoss3) //Skeletron
							{
								if (Config.LootCascadeIncrease > 0)
								{
									if (Main.rand.Next(10000)+1 <= Config.LootCascadeIncrease*10000)
									{
										if (npc.type != 46 && npc.type != 74 && npc.type != 297 && npc.type != 298 && npc.type != 299 && npc.type != 300 && npc.type != 355 && npc.type != 357 && npc.type != 358 && npc.type != 359 && npc.type != 360 && npc.type != 361 && npc.type != 366 && npc.type != 367 && npc.type != 377 && npc.type != 442 && npc.type != 443 && npc.type != 445 && npc.type != 446 && npc.type != 447 && npc.type != 448 && npc.type != 484 && npc.type != 485 && npc.type != 486 && npc.type != 487 && npc.type != 538 && npc.type != 539 && npc.type != 55 && npc.type != 230 && npc.type != 148 && npc.type != 149 && npc.type != 362 && npc.type != 363 && npc.type != 364 && npc.type != 365 && npc.type != 374 && npc.type != 375 && npc.type != 356 && npc.type != 444 && npc.type != NPCID.Bee && npc.type != NPCID.BeeSmall)
										{
											Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cascade, 1, false, -1, false, false);
										}
									}
								}
							}
						}
						if (npc.type == NPCID.ManEater)
						{
							if (Config.LootAncientCobaltHelmetIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootAncientCobaltHelmetIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltHelmet, 1, false, -1, false, false);
								}
							}
							if (Config.LootAncientCobaltBreastplateIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootAncientCobaltBreastplateIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltBreastplate, 1, false, -1, false, false);
								}
							}
							if (Config.LootAncientCobaltLeggingsIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootAncientCobaltLeggingsIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltLeggings, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.FireImp)
						{
							if (Config.LootPlumbersHatIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootPlumbersHatIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PlumbersHat, 1, false, -1, false, false);
								}
							}
							if (Config.LootObsidianRoseIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootObsidianRoseIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ObsidianRose, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.CursedSkull || npc.type == NPCID.DarkCaster)
						{
							if (Config.LootBoneWandIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootBoneWandIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneWand, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.CaveBat)
						{
							if (Config.LootChainKnifeIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootChainKnifeIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ChainKnife, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Reaper)
						{
							if (Main.expertMode && Config.ExpertLootDeathSickleIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootDeathSickleIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AdhesiveBandage, 1, false, -1, false, false);
								}
							}
							else if (!Main.expertMode && Config.LootDeathSickleIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootDeathSickleIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AdhesiveBandage, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == 3 || npc.type == 132 || npc.type == 161 || (npc.type >= 186 && npc.type <= 200) || npc.type == 223 || (npc.type >= 430 && npc.type <= 436)) //Normal Zombie Variants, Raincoat Zombie, and Zombie Eskimo
						{
							if (Config.LootZombieArmIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootZombieArmIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ZombieArm, 1, false, -1, false, false);
								}
							}
							if (Config.LootShackleIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootShackleIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Shackle, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Pixie || npc.type == NPCID.Unicorn || npc.type == NPCID.RainbowSlime || npc.type == NPCID.Gastropod || npc.type == NPCID.LightMummy || npc.type == NPCID.IlluminantSlime || npc.type == NPCID.IlluminantBat || npc.type == NPCID.ChaosElemental || npc.type == NPCID.EnchantedSword || npc.type == NPCID.BigMimicHallow) //Hallow Enemies
						{
							if (Main.expertMode && Config.ExpertLootBlessedAppleIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootBlessedAppleIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlessedApple, 1, false, -1, false, false);
								}
							}
							else if (!Main.expertMode && Config.LootBlessedAppleIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootBlessedAppleIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlessedApple, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Mimic)
						{
							if (Main.rand.Next(10000)+1 <= Config.LootDualHookIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DualHook, 1, false, -1, false, false);
							}
							if (Main.rand.Next(10000)+1 <= Config.LootMagicDaggerIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagicDagger, 1, false, -1, false, false);
							}
							if (Main.rand.Next(10000)+1 <= Config.LootTitanGloveIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TitanGlove, 1, false, -1, false, false);
							}
							if (Main.rand.Next(10000)+1 <= Config.LootPhilosophersStoneIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PhilosophersStone, 1, false, -1, false, false);
							}
							if (Main.rand.Next(10000)+1 <= Config.LootCrossNecklaceIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CrossNecklace, 1, false, -1, false, false);
							}
							if (Main.rand.Next(10000)+1 <= Config.LootStarCloakIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.StarCloak, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.BigMimicCorruption)
						{
							if (Main.rand.Next(10000)+1 <= Config.LootDartRifleIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DartRifle, 1, false, -1, false, false);
							}
							if (Main.rand.Next(10000)+1 <= Config.LootWormHookIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WormHook, 1, false, -1, false, false);
							}
							if (Main.rand.Next(10000)+1 <= Config.LootChainGuillotinesIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ChainGuillotines, 1, false, -1, false, false);
							}
							if (Main.rand.Next(10000)+1 <= Config.LootClingerStaffIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ClingerStaff, 1, false, -1, false, false);
							}
							if (Main.rand.Next(10000)+1 <= Config.LootPutridScentIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PutridScent, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.BigMimicCrimson)
						{
							if (Main.rand.Next(10000)+1 <= Config.LootLifeDrainIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulDrain, 1, false, -1, false, false);//Life Drain
							}
							if (Main.rand.Next(10000)+1 <= Config.LootDartPistolIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DartPistol, 1, false, -1, false, false);
							}
							if (Main.rand.Next(10000)+1 <= Config.LootFetidBaghnakhsIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FetidBaghnakhs, 1, false, -1, false, false);
							}
							if (Main.rand.Next(10000)+1 <= Config.LootFleshKnucklesIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FleshKnuckles, 1, false, -1, false, false);
							}
							if (Main.rand.Next(10000)+1 <= Config.LootTendonHookIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TendonHook, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.BigMimicHallow)
						{
							if (Main.rand.Next(10000)+1 <= Config.LootDaedalusStormbowIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DaedalusStormbow, 1, false, -1, false, false);
							}
							if (Main.rand.Next(10000)+1 <= Config.LootFlyingKnifeIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FlyingKnife, 1, false, -1, false, false);
							}
							if (Main.rand.Next(10000)+1 <= Config.LootCrystalVileShardIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CrystalVileShard, 1, false, -1, false, false);
							}
							if (Main.rand.Next(10000)+1 <= Config.LootIlluminantHookIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IlluminantHook, 1, false, -1, false, false);
							}
						}
						if (npc.type == NPCID.Harpy)
						{
							if (Config.LootGiantHarpyFeatherIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootGiantHarpyFeatherIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GiantHarpyFeather, 1, false, -1, false, false);
								}
							}
						}
						if ((npc.type >= 26 && npc.type <= 29) || npc.type == 111) //Goblin Army (Excluding Summoner)
						{
							if (Config.LootHarpoonIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootHarpoonIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Harpoon, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.ArmoredViking || npc.type == NPCID.IceElemental || npc.type == NPCID.IcyMerman || npc.type == NPCID.IceTortoise)
						{
							if (Config.LootIceSickleIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootIceSickleIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IceSickle, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type >= 269 && npc.type <= 293)// Post-plantera dungeon enemies
						{
							if (Config.LootKrakenIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootKrakenIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Kraken, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.SkeletonArcher)
						{
							if (Config.LootMarrowIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootMarrowIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Marrow, 1, false, -1, false, false);
								}
							}
							if (Config.LootMagicQuiverIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootMagicQuiverIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagicQuiver, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Crimslime || npc.type == NPCID.CrimsonAxe || npc.type == NPCID.FloatyGross || npc.type == NPCID.Herpling)
						{
							if (Config.LootMeatGrinderIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootMeatGrinderIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MeatGrinder, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.AngryTrapper)
						{
							if (Config.LootUziIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootUziIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Uzi, 1, false, -1, false, false);
								}
							}
						}
						if (NPC.downedMechBoss1 && player.ZoneJungle)
						{
							if (npc.type != 46 && npc.type != 74 && npc.type != 297 && npc.type != 298 && npc.type != 299 && npc.type != 300 && npc.type != 355 && npc.type != 357 && npc.type != 358 && npc.type != 359 && npc.type != 360 && npc.type != 361 && npc.type != 366 && npc.type != 367 && npc.type != 377 && npc.type != 442 && npc.type != 443 && npc.type != 445 && npc.type != 446 && npc.type != 447 && npc.type != 448 && npc.type != 484 && npc.type != 485 && npc.type != 486 && npc.type != 487 && npc.type != 538 && npc.type != 539 && npc.type != 55 && npc.type != 230 && npc.type != 148 && npc.type != 149 && npc.type != 362 && npc.type != 363 && npc.type != 364 && npc.type != 365 && npc.type != 374 && npc.type != 375 && npc.type != 356 && npc.type != 444 && npc.type != NPCID.Bee && npc.type != NPCID.BeeSmall)
							{
								if (Config.LootYeletsIncrease > 0)
								{
									if (Main.rand.Next(10000)+1 <= Config.LootYeletsIncrease*10000)
									{
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Yelets, 1, false, -1, false, false);
									}
								}
							}
						}
						if (npc.type == NPCID.ArmoredSkeleton)
						{
							if (Config.LootBeamSwordIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootBeamSwordIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BeamSword, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == 2 || (npc.type >= 190 && npc.type <= 194) || npc.type == 317 || npc.type == 318) //Demon Eye and Wandering Eye
						{
							if (Config.LootBlackLensIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootBlackLensIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlackLens, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.ZombieEskimo || npc.type == NPCID.ArmedZombieEskimo)
						{
							if (Config.LootEskimoHoodIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootEskimoHoodIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EskimoHood, 1, false, -1, false, false);
								}
							}
							if (Config.LootEskimoCoatIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootEskimoCoatIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EskimoCoat, 1, false, -1, false, false);
								}
							}
							if (Config.LootEskimoPantsIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootEskimoPantsIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EskimoPants, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Hellbat)
						{
							if (Config.HellBatLootMagmaStoneIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.HellBatLootMagmaStoneIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagmaStone, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Lavabat)
						{
							if (Config.LavaBatLootMagmaStoneIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LavaBatLootMagmaStoneIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagmaStone, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.SnowFlinx)
						{
							if (Config.LootSnowballLauncherIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootSnowballLauncherIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SnowballLauncher, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.MossHornet)
						{
							if (Config.LootTatteredBeeWingIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootTatteredBeeWingIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TatteredBeeWing, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.ScutlixRider)
						{
							if (Config.LootBrainScramblerIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootBrainScramblerIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BrainScrambler, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == 63 || npc.type == 64 || npc.type == 103) //Basic Jellyfish
						{
							if (Config.LootJellyfishNecklaceIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootJellyfishNecklaceIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.JellyfishNecklace, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.DesertLamiaLight || npc.type == NPCID.DesertLamiaDark)
						{
							if (Config.LootLamiaClothesIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootLamiaClothesIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LamiaHat, 1, false, -1, false, false);
								}
								if (Main.rand.Next(10000)+1 <= Config.LootLamiaClothesIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LamiaPants, 1, false, -1, false, false);
								}
								if (Main.rand.Next(10000)+1 <= Config.LootLamiaClothesIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LamiaShirt, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Vampire)
						{
							if (Main.expertMode && Config.ExpertLootMoonStoneIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootMoonStoneIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonStone, 1, false, -1, false, false);
								}
							}
							else if (!Main.expertMode && Config.LootMoonStoneIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootMoonStoneIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonStone, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.RedDevil)
						{
							if (Config.LootFireFeatherIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootFireFeatherIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FireFeather, 1, false, -1, false, false);
								}
							}
						}
						if (Config.SlimeStaffIncreaseToSurfaceSlimes && (npc.type == NPCID.GreenSlime || npc.type == NPCID.BlueSlime || npc.type == NPCID.PurpleSlime || npc.type == NPCID.IceSlime || npc.type == NPCID.SandSlime || npc.type == NPCID.JungleSlime))
						{
							if (Main.expertMode && Config.ExpertLootSlimeStaffIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootSlimeStaffIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
								}
							}
							else if(!Main.expertMode && Config.LootSlimeStaffIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootSlimeStaffIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
								}
							}
						}
						if (Config.SlimeStaffIncreaseToUndergroundSlimes && (npc.type == NPCID.RedSlime || npc.type == NPCID.YellowSlime))
						{
							if (Main.expertMode && Config.ExpertLootSlimeStaffIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootSlimeStaffIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
								}
							}
							else if(!Main.expertMode && Config.LootSlimeStaffIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootSlimeStaffIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
								}
							}
						}
						if (Config.SlimeStaffIncreaseToCavernSlimess && (npc.type == NPCID.BlackSlime || npc.type == NPCID.MotherSlime || npc.type == NPCID.BabySlime))
						{
							if (Main.expertMode && Config.ExpertLootSlimeStaffIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootSlimeStaffIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
								}
							}
							else if(!Main.expertMode && Config.LootSlimeStaffIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootSlimeStaffIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
								}
							}
						}
						if (Config.SlimeStaffIncreaseToIceSpikedSlimes && npc.type == NPCID.SpikedIceSlime)
						{
							if (Main.expertMode && Config.ExpertLootSlimeStaffIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootSlimeStaffIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
								}
							}
							else if(!Main.expertMode && Config.LootSlimeStaffIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootSlimeStaffIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
								}
							}
						}
						if (Config.SlimeStaffIncreaseToSpikedJungleSlimes && npc.type == NPCID.SpikedJungleSlime)
						{
							if (Main.expertMode && Config.ExpertLootSlimeStaffIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootSlimeStaffIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
								}
							}
							else if(!Main.expertMode && Config.LootSlimeStaffIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootSlimeStaffIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
								}
							}
						}
						if (Main.hardMode && player.ZoneBeach)
						{
							if (Config.LootPirateMapIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootPirateMapIncrease*10000)
								{
									if (npc.type != 46 && npc.type != 74 && npc.type != 297 && npc.type != 298 && npc.type != 299 && npc.type != 300 && npc.type != 355 && npc.type != 357 && npc.type != 358 && npc.type != 359 && npc.type != 360 && npc.type != 361 && npc.type != 366 && npc.type != 367 && npc.type != 377 && npc.type != 442 && npc.type != 443 && npc.type != 445 && npc.type != 446 && npc.type != 447 && npc.type != 448 && npc.type != 484 && npc.type != 485 && npc.type != 486 && npc.type != 487 && npc.type != 538 && npc.type != 539 && npc.type != 55 && npc.type != 230 && npc.type != 148 && npc.type != 149 && npc.type != 362 && npc.type != 363 && npc.type != 364 && npc.type != 365 && npc.type != 374 && npc.type != 375 && npc.type != 356 && npc.type != 444 && npc.type != NPCID.Bee && npc.type != NPCID.BeeSmall)
									{
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PirateMap, 1, false, -1, false, false);
									}
								}
							}
						}
						if (Main.hardMode && player.ZoneDirtLayerHeight && (player.ZoneCorrupt || player.ZoneCrimson))
						{
							if (npc.type != 46 && npc.type != 74 && npc.type != 297 && npc.type != 298 && npc.type != 299 && npc.type != 300 && npc.type != 355 && npc.type != 357 && npc.type != 358 && npc.type != 359 && npc.type != 360 && npc.type != 361 && npc.type != 366 && npc.type != 367 && npc.type != 377 && npc.type != 442 && npc.type != 443 && npc.type != 445 && npc.type != 446 && npc.type != 447 && npc.type != 448 && npc.type != 484 && npc.type != 485 && npc.type != 486 && npc.type != 487 && npc.type != 538 && npc.type != 539 && npc.type != 55 && npc.type != 230 && npc.type != 148 && npc.type != 149 && npc.type != 362 && npc.type != 363 && npc.type != 364 && npc.type != 365 && npc.type != 374 && npc.type != 375 && npc.type != 356 && npc.type != 444 && npc.type != NPCID.Bee && npc.type != NPCID.BeeSmall)
							{
								if (Main.expertMode && ((Main.rand.Next(10000)+1) <= Config.ExpertLootSoulofNightIncrease*10000))
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofNight, 1, false, -1, false, false);
								}
								else if (!Main.expertMode && ((Main.rand.Next(10000)+1) <= Config.LootSoulofNightIncrease*10000))
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofNight, 1, false, -1, false, false);
								}
							}
						}
						if (Main.hardMode && player.ZoneDirtLayerHeight && player.ZoneHoly)
						{
							if (npc.type != 46 && npc.type != 74 && npc.type != 297 && npc.type != 298 && npc.type != 299 && npc.type != 300 && npc.type != 355 && npc.type != 357 && npc.type != 358 && npc.type != 359 && npc.type != 360 && npc.type != 361 && npc.type != 366 && npc.type != 367 && npc.type != 377 && npc.type != 442 && npc.type != 443 && npc.type != 445 && npc.type != 446 && npc.type != 447 && npc.type != 448 && npc.type != 484 && npc.type != 485 && npc.type != 486 && npc.type != 487 && npc.type != 538 && npc.type != 539 && npc.type != 55 && npc.type != 230 && npc.type != 148 && npc.type != 149 && npc.type != 362 && npc.type != 363 && npc.type != 364 && npc.type != 365 && npc.type != 374 && npc.type != 375 && npc.type != 356 && npc.type != 444 && npc.type != NPCID.Bee && npc.type != NPCID.BeeSmall)
							{
								if (Main.expertMode && ((Main.rand.Next(10000)+1) <= Config.ExpertLootSoulofLightIncrease*10000))
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofLight, 1, false, -1, false, false);
								}
								else if (!Main.expertMode && ((Main.rand.Next(10000)+1) <= Config.LootSoulofLightIncrease*10000))
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofLight, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Unicorn)
						{
							if (Config.LootUnicornonaStickIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootUnicornonaStickIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.UnicornonaStick, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.DiggerHead || npc.type == NPCID.GiantWormHead)
						{
							if (Config.LootWhoopieCushionIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootWhoopieCushionIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WhoopieCushion, 1, false, -1, false, false);
								}
							}
						}
						if (player.ZoneSnow && Main.hardMode) //Skeletron
						{
							if (Config.LootAmarokIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootAmarokIncrease*10000)
								{
									if (npc.type != 46 && npc.type != 74 && npc.type != 297 && npc.type != 298 && npc.type != 299 && npc.type != 300 && npc.type != 355 && npc.type != 357 && npc.type != 358 && npc.type != 359 && npc.type != 360 && npc.type != 361 && npc.type != 366 && npc.type != 367 && npc.type != 377 && npc.type != 442 && npc.type != 443 && npc.type != 445 && npc.type != 446 && npc.type != 447 && npc.type != 448 && npc.type != 484 && npc.type != 485 && npc.type != 486 && npc.type != 487 && npc.type != 538 && npc.type != 539 && npc.type != 55 && npc.type != 230 && npc.type != 148 && npc.type != 149 && npc.type != 362 && npc.type != 363 && npc.type != 364 && npc.type != 365 && npc.type != 374 && npc.type != 375 && npc.type != 356 && npc.type != 444 && npc.type != NPCID.Bee && npc.type != NPCID.BeeSmall)
									{
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Amarok, 1, false, -1, false, false);
									}
								}
							}
						}
						if (npc.type == NPCID.UndeadMiner)
						{
							if (Config.LootBonePickaxeIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootBonePickaxeIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BonePickaxe, 1, false, -1, false, false);
								}
							}
							if (Config.LootMiningHelmetIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootMiningHelmetIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MiningHelmet, 1, false, -1, false, false);
								}
							}
							if (Config.LootMiningShirtIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootMiningShirtIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MiningShirt, 1, false, -1, false, false);
								}
							}
							if (Config.LootMiningPantsIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootMiningPantsIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MiningPants, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Psycho)
						{
							if (Main.expertMode && Config.LootPsychoKnifeIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootPsychoKnifeIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PsychoKnife, 1, false, -1, false, false);
								}
							}
							else if(!Main.expertMode && Config.ExpertLootPsychoKnifeIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootPsychoKnifeIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PsychoKnife, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.CorruptBunny)
						{
							if (Config.LootBunnyHoodIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootBunnyHoodIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BunnyHood, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type >= 78 && npc.type <= 80) //Mummies
						{
							if (Config.LootMummyCostumeIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootMummyCostumeIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MummyMask, 1, false, -1, false, false);
								}
							}
							if (Config.LootMummyCostumeIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootMummyCostumeIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MummyShirt, 1, false, -1, false, false);
								}
							}
							if (Config.LootMummyCostumeIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootMummyCostumeIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MummyPants, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == 31 || (npc.type >= 294 && npc.type <= 296) || npc.type == NPCID.CursedSkull || npc.type == NPCID.DarkCaster) //Angry Bones, Cursed Skull, and Dark Caster
						{
							if (Config.LootGoldenKeyIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootGoldenKeyIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenKey, 1, false, -1, false, false);
								}
							}
							if (Config.LootTallyCounterIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootTallyCounterIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TallyCounter, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Werewolf)
						{
							if (Config.LootMoonCharmIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootMoonCharmIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonCharm, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.DesertBeast)
						{
							if (Config.LootAncientHornIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootAncientHornIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientHorn, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Demon)
						{
							if (Config.LootDemonScytheIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootDemonScytheIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DemonScythe, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Shark)
						{
							if (Config.LootDivingHelmetIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootDivingHelmetIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DivingHelmet, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Eyezor)
						{
							if (Config.LootEyeSpringIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootEyeSpringIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EyeSpring, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.IceElemental || npc.type == NPCID.IcyMerman)
						{
							if (Config.LootFrostStaffIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootFrostStaffIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FrostStaff, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.WalkingAntlion)
						{
							if (Config.LootMandibleBladeIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootMandibleBladeIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AntlionClaw, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.MeteorHead)
						{
							if (Config.LootMeteoriteIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootMeteoriteIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Meteorite, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.CorruptPenguin || npc.type == NPCID.CrimsonPenguin)
						{
							if (Config.LootPedguinssuitIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootPedguinssuitIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PedguinHat, 1, false, -1, false, false);
								}
							}
							if (Config.LootPedguinssuitIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootPedguinssuitIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PedguinShirt, 1, false, -1, false, false);
								}
							}
							if (Config.LootPedguinssuitIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootPedguinssuitIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PedguinPants, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.UndeadViking)
						{
							if (Config.LootVikingHelmetIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootVikingHelmetIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.VikingHelmet, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.UmbrellaSlime)
						{
							if (Config.LootUmbrellaHatIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootUmbrellaHatIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.UmbrellaHat, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Vampire || npc.type == NPCID.VampireBat)
						{
							if (Config.LootBrokenBatWingIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootBrokenBatWingIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BrokenBatWing, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.DesertDjinn)
						{
							if (Config.LootDesertSpiritLampIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootDesertSpiritLampIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DjinnLamp, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Piranha)
						{
							if (Config.LootHookIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootHookIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Hook, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.LightMummy || npc.type == NPCID.DesertGhoulHallow || npc.type == NPCID.SandsharkHallow)
						{
							if (Config.LootLightShardIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootLightShardIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LightShard, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.DesertLamiaLight)
						{
							if (Config.LootMoonMaskIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootMoonMaskIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonMask, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.DesertLamiaDark)
						{
							if (Config.LootSunMaskIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootSunMaskIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SunMask, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type >= 333 && npc.type <= 336) //Present Slimes
						{
							if (Config.LootGiantBowIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootGiantBowIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GiantBow, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.ZombieRaincoat)
						{
							if (Config.LootRainArmorIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootRainArmorIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RainCoat, 1, false, -1, false, false);
								}
							}
							if (Config.LootRainArmorIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootRainArmorIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RainCoat, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Mimic && player.ZoneSnow)
						{
							if (Config.LootToySledIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootToySledIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ToySled, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.SkeletonSniper)
						{
							if (Config.LootSniperRifleIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootSniperRifleIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SniperRifle, 1, false, -1, false, false);
								}
							}
							if (Config.LootRifleScopeIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootRifleScopeIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RifleScope, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.TacticalSkeleton)
						{
							if (Config.LootTacticalShotgunIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootTacticalShotgunIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TacticalShotgun, 1, false, -1, false, false);
								}
							}
							if (Config.LootSWATHelmetIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootSWATHelmetIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SWATHelmet, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type >= 524 && npc.type <= 527) //Ghouls
						{
							if (Config.LootAncientClothIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootAncientClothIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCloth, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.DesertGhoulCorruption || npc.type == NPCID.DesertGhoulCrimson)
						{
							if (Config.LootDarkShardIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootDarkShardIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DarkShard, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.AngryNimbus)
						{
							if (Config.LootNimbusRodIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootNimbusRodIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.NimbusRod, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.BoneLee)
						{
							if (Config.LootBlackBeltIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootBlackBeltIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlackBelt, 1, false, -1, false, false);
								}
							}
							if (Config.LootTabiIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootTabiIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Tabi, 1, false, -1, false, false);
								}
							}
						}
						if (Main.halloween && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead)
						{
							if (npc.type != 46 && npc.type != 74 && npc.type != 297 && npc.type != 298 && npc.type != 299 && npc.type != 300 && npc.type != 355 && npc.type != 357 && npc.type != 358 && npc.type != 359 && npc.type != 360 && npc.type != 361 && npc.type != 366 && npc.type != 367 && npc.type != 377 && npc.type != 442 && npc.type != 443 && npc.type != 445 && npc.type != 446 && npc.type != 447 && npc.type != 448 && npc.type != 484 && npc.type != 485 && npc.type != 486 && npc.type != 487 && npc.type != 538 && npc.type != 539 && npc.type != 55 && npc.type != 230 && npc.type != 148 && npc.type != 149 && npc.type != 362 && npc.type != 363 && npc.type != 364 && npc.type != 365 && npc.type != 374 && npc.type != 375 && npc.type != 356 && npc.type != 444 && npc.type != NPCID.Bee && npc.type != NPCID.BeeSmall)
							{
								if (Config.LootGoodieBagIncrease > 0)
								{
									if (Main.rand.Next(10000)+1 <= Config.LootGoodieBagIncrease*10000)
									{
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoodieBag, 1, false, -1, false, false);
									}
								}
							}
						}
						if (Main.xMas && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead)
						{
							if (npc.type != 46 && npc.type != 74 && npc.type != 297 && npc.type != 298 && npc.type != 299 && npc.type != 300 && npc.type != 355 && npc.type != 357 && npc.type != 358 && npc.type != 359 && npc.type != 360 && npc.type != 361 && npc.type != 366 && npc.type != 367 && npc.type != 377 && npc.type != 442 && npc.type != 443 && npc.type != 445 && npc.type != 446 && npc.type != 447 && npc.type != 448 && npc.type != 484 && npc.type != 485 && npc.type != 486 && npc.type != 487 && npc.type != 538 && npc.type != 539 && npc.type != 55 && npc.type != 230 && npc.type != 148 && npc.type != 149 && npc.type != 362 && npc.type != 363 && npc.type != 364 && npc.type != 365 && npc.type != 374 && npc.type != 375 && npc.type != 356 && npc.type != 444 && npc.type != NPCID.Bee && npc.type != NPCID.BeeSmall)
							{
								if (Config.LootPresentIncrease > 0)
								{
									if (Main.rand.Next(10000)+1 <= Config.LootPresentIncrease*10000)
									{
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Present, 1, false, -1, false, false);
									}
								}
							}
						}
						if (npc.type == NPCID.Drippler || npc.type == NPCID.BloodZombie)
						{
							if (Main.expertMode && Config.ExpertLootMoneyTroughIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootMoneyTroughIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoneyTrough, 1, false, -1, false, false);
								}
							}
							else if (!Main.expertMode && Config.LootMoneyTroughIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootMoneyTroughIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoneyTrough, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == 42 || npc.type == 141|| npc.type == 176 || (npc.type >= 231 && npc.type <= 235)) //Hornet, Moss Hornet, and Toxic Sludge
						{
							if (Main.expertMode && Config.ExpertLootBezoarIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootBezoarIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bezoar, 1, false, -1, false, false);
								}
							}
							else if (!Main.expertMode && Config.LootBezoarIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootBezoarIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bezoar, 1, false, -1, false, false);
								}
							}
						}
						if (Main.halloween && npc.value > 0f && npc.value < 500f && npc.damage < 40 && npc.defense < 20)
						{
							if (Main.rand.Next(10000)+1 <= Config.LootBloodyMacheteIncrease*10000)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BloodyMachete, 1, false, -1, false, false);
							}
						}
						if (npc.type >= 494 && npc.type <= 506) //Giant Shellies, Crawdads, and Salamanders
						{
							if (Config.LootRallyIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootRallyIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Rally, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Everscream)
						{
							if (Config.LootFestiveWingsIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootFestiveWingsIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FestiveWings, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.IceQueen)
						{
							if (Config.LootBabyGrinchsMischiefWhistleIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootBabyGrinchsMischiefWhistleIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BabyGrinchMischiefWhistle, 1, false, -1, false, false);
								}
							}
							if (Config.LootReindeerBellsIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootReindeerBellsIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ReindeerBells, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Medusa)
						{
							if (Main.expertMode && Config.ExpertLootPocketMirrorIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootPocketMirrorIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PocketMirror, 1, false, -1, false, false);
								}
							}
							else if (Config.LootPocketMirrorIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootPocketMirrorIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PocketMirror, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == NPCID.Mothron)
						{
							if (Main.expertMode && Config.ExpertLootMothronWingsIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.ExpertLootMothronWingsIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MothronWings, 1, false, -1, false, false);
								}
							}
							else if (!Main.expertMode && Config.LootMothronWingsIncrease > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.LootMothronWingsIncrease*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MothronWings, 1, false, -1, false, false);
								}
							}
						}
						if (Main.bloodMoon && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead && Main.hardMode)
						{
							if (npc.type != 46 && npc.type != 74 && npc.type != 297 && npc.type != 298 && npc.type != 299 && npc.type != 300 && npc.type != 355 && npc.type != 357 && npc.type != 358 && npc.type != 359 && npc.type != 360 && npc.type != 361 && npc.type != 366 && npc.type != 367 && npc.type != 377 && npc.type != 442 && npc.type != 443 && npc.type != 445 && npc.type != 446 && npc.type != 447 && npc.type != 448 && npc.type != 484 && npc.type != 485 && npc.type != 486 && npc.type != 487 && npc.type != 538 && npc.type != 539 && npc.type != 55 && npc.type != 230 && npc.type != 148 && npc.type != 149 && npc.type != 362 && npc.type != 363 && npc.type != 364 && npc.type != 365 && npc.type != 374 && npc.type != 375 && npc.type != 356 && npc.type != 444 && npc.type != NPCID.Bee && npc.type != NPCID.BeeSmall)
							{
								if (Config.LootKOCannonIncrease > 0)
								{
									if (Main.rand.Next(10000)+1 <= Config.LootKOCannonIncrease*10000)
									{
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.KOCannon, 1, false, -1, false, false);
									}
								}
							}
						}
						if (npc.type == NPCID.IceSlime || npc.type == NPCID.SpikedIceSlime)
						{
							if (Config.IceSlimeAndSpikedIceSlimeLootFishItem > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.IceSlimeAndSpikedIceSlimeLootFishItem*10000)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Fish, 1, false, -1, false, false);
								}
							}
						}
						if (npc.type == 510 || npc.type == 513)
						{
							if (Config.TombCrawlerAndDuneSplicerLootPyramidChestItem > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.TombCrawlerAndDuneSplicerLootPyramidChestItem*10000)
								{
									switch (Main.rand.Next(7))
									{
										case 0:
											Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FlyingCarpet, 1, false, -1, false, false);
											break;
										case 1:
											Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SandstorminaBottle, 1, false, -1, false, false);
											break;
										case 2:
											Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PharaohsMask, 1, false, -1, false, false);
											break;
										case 3:
											Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PharaohsRobe, 1, false, -1, false, false);
											break;
										case 4:
											Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SnakeBanner, 1, false, -1, false, false);
											break;
										case 5:
											Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.OmegaBanner, 1, false, -1, false, false);
											break;
										case 6:
											Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AnkhBanner, 1, false, -1, false, false);
											break;
									}
								}
							}
						}
						if (npc.type == 510 || npc.type == 513)
						{
							if (Config.TombCrawlerAndDuneSplicerLootPyramidChestItem > 0)
							{
								if (Main.rand.Next(10000)+1 <= Config.TombCrawlerAndDuneSplicerLootPyramidChestItem*10000)
								{
									switch (Main.rand.Next(7))
									{
										case 0:
											Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FlyingCarpet, 1, false, -1, false, false);
											break;
										case 1:
											Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SandstorminaBottle, 1, false, -1, false, false);
											break;
										case 2:
											Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PharaohsMask, 1, false, -1, false, false);
											break;
										case 3:
											Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PharaohsRobe, 1, false, -1, false, false);
											break;
										case 4:
											Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SnakeBanner, 1, false, -1, false, false);
											break;
										case 5:
											Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.OmegaBanner, 1, false, -1, false, false);
											break;
										case 6:
											Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AnkhBanner, 1, false, -1, false, false);
											break;
									}
								}
							}
						}
						
						//Modded Loot
						
						if (player.ZoneUnderworldHeight)
						{
							if (npc.type != 46 && npc.type != 74 && npc.type != 297 && npc.type != 298 && npc.type != 299 && npc.type != 300 && npc.type != 355 && npc.type != 357 && npc.type != 358 && npc.type != 359 && npc.type != 360 && npc.type != 361 && npc.type != 366 && npc.type != 367 && npc.type != 377 && npc.type != 442 && npc.type != 443 && npc.type != 445 && npc.type != 446 && npc.type != 447 && npc.type != 448 && npc.type != 484 && npc.type != 485 && npc.type != 486 && npc.type != 487 && npc.type != 538 && npc.type != 539 && npc.type != 55 && npc.type != 230 && npc.type != 148 && npc.type != 149 && npc.type != 362 && npc.type != 363 && npc.type != 364 && npc.type != 365 && npc.type != 374 && npc.type != 375 && npc.type != 356 && npc.type != 444 && npc.type != NPCID.Bee && npc.type != NPCID.BeeSmall)
							{
								if (Config.HellBiomeModdedShadowBoxLoot > 0)
								{
									if (Main.rand.Next(10000)+1 <= Config.HellBiomeModdedShadowBoxLoot*10000)
									{
										Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Shadow_Lock_Box"), 1, false, -1, false, false);
									}
								}
							}
						}
					}
					
					//Restock Traveling Merchant
					
					if (npc.type != 46 && npc.type != 74 && npc.type != 297 && npc.type != 298 && npc.type != 299 && npc.type != 300 && npc.type != 355 && npc.type != 357 && npc.type != 358 && npc.type != 359 && npc.type != 360 && npc.type != 361 && npc.type != 366 && npc.type != 367 && npc.type != 377 && npc.type != 442 && npc.type != 443 && npc.type != 445 && npc.type != 446 && npc.type != 447 && npc.type != 448 && npc.type != 484 && npc.type != 485 && npc.type != 486 && npc.type != 487 && npc.type != 538 && npc.type != 539 && npc.type != 55 && npc.type != 230 && npc.type != 148 && npc.type != 149 && npc.type != 362 && npc.type != 363 && npc.type != 364 && npc.type != 365 && npc.type != 374 && npc.type != 375 && npc.type != 356 && npc.type != 444 && npc.type != NPCID.Bee && npc.type != NPCID.BeeSmall)
					{
						if (Config.ChanceThatEnemyKillWillResetTravelingMerchant > 0)
						{
							int townNPCReduction = 22;//There are 21 vanilla NPCs as of 5/26/2017
							bool resetTravelingMerchant = false;
							for (int i = 0; i < Terraria.Main.npc.Length; i++) //Do once for each NPC in the world
							{
								if (Terraria.Main.npc[i].type == NPCID.TravellingMerchant)
									resetTravelingMerchant = true;
								if (Terraria.Main.npc[i].townNPC == true)
								{
									if (Terraria.Main.npc[i].type == NPCID.Merchant || Terraria.Main.npc[i].type == NPCID.Nurse || Terraria.Main.npc[i].type == NPCID.Demolitionist || Terraria.Main.npc[i].type == NPCID.DyeTrader || Terraria.Main.npc[i].type == NPCID.Dryad || Terraria.Main.npc[i].type == NPCID.DD2Bartender || Terraria.Main.npc[i].type == NPCID.ArmsDealer || Terraria.Main.npc[i].type == NPCID.Stylist || Terraria.Main.npc[i].type == NPCID.Painter || Terraria.Main.npc[i].type == NPCID.Angler || Terraria.Main.npc[i].type == NPCID.GoblinTinkerer || Terraria.Main.npc[i].type == NPCID.WitchDoctor || Terraria.Main.npc[i].type == NPCID.Clothier || Terraria.Main.npc[i].type == NPCID.Mechanic || Terraria.Main.npc[i].type == NPCID.PartyGirl || Terraria.Main.npc[i].type == NPCID.Wizard || Terraria.Main.npc[i].type == NPCID.TaxCollector || Terraria.Main.npc[i].type == NPCID.Truffle || Terraria.Main.npc[i].type == NPCID.Pirate || Terraria.Main.npc[i].type == NPCID.Steampunker || Terraria.Main.npc[i].type == NPCID.Cyborg)
										townNPCReduction--;
								}
							}
							if (townNPCReduction < 1)
								townNPCReduction = 1;
							if (resetTravelingMerchant)
							{
								if (Main.rand.Next(10000)+1 <= Config.ChanceThatEnemyKillWillResetTravelingMerchant*10000/townNPCReduction)
								{
									Chest.SetupTravelShop();
									Main.NewText("The Traveling Merchant restocked his items.", 0, 127, 255);
								}
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
			if (Config.UseEnchangedSwordInNightsEdgeRecipe)
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
			if (Config.UseArkhalisInNightsEdgeRecipe)
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
			if (Config.UseCloudinaBottleRecipe)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(ItemID.Bottle,1);
				recipe.AddIngredient(ItemID.Cloud,64);
				recipe.AddTile(TileID.CrystalBall);
				recipe.SetResult(ItemID.CloudinaBottle);
				recipe.AddRecipe();
			}
			if (Config.UseBlizzardinaBottleRecipe)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(ItemID.CloudinaBottle,1);
				recipe.AddIngredient(ItemID.SnowBlock,64);
				recipe.AddTile(TileID.CrystalBall);
				recipe.SetResult(ItemID.BlizzardinaBottle);
				recipe.AddRecipe();
			}
			if (Config.UseSandstorminaBottleRecipe)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(ItemID.CloudinaBottle,1);
				recipe.AddIngredient(ItemID.SandBlock,64);
				recipe.AddTile(TileID.CrystalBall);
				recipe.SetResult(ItemID.SandstorminaBottle);
				recipe.AddRecipe();
			}
			if (Config.UseCustomCelestialSigilRecipe)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(ItemID.FragmentSolar, Config.CustomCelestialSigilEachLunarFragmentCost);
				recipe.AddIngredient(ItemID.FragmentVortex, Config.CustomCelestialSigilEachLunarFragmentCost);
				recipe.AddIngredient(ItemID.FragmentNebula, Config.CustomCelestialSigilEachLunarFragmentCost);
				recipe.AddIngredient(ItemID.FragmentStardust, Config.CustomCelestialSigilEachLunarFragmentCost);
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
			if (player.FindBuffIndex(BuffID.Battle) != -1)
			{
				spawnRate = (int)(spawnRate / Config.BattlePotionSpawnrateMultiplier);
				maxSpawns = (int)(maxSpawns * Config.BattlePotionMaxSpawnsMultiplier);
			}
		}
    }

}