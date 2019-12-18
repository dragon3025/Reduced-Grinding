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

using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding
{
	
	class ReducedGrindingPlayer : ModPlayer
    {

        private void SendClientChangesPacket()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                ModPacket packet = mod.GetPacket();
                packet.Write((byte)ReducedGrindingMessageType.SendClientChanges);
                packet.Write((byte)player.whoAmI);
                //BitsByte flags = new BitsByte();
                //flags[0] = currentlyActive;
                //packet.Write((byte)flags);
                packet.Send();
            }
        }
		
		public override void AnglerQuestReward(float quality, List<Item> rewardItems)
		{
			Player player = Main.player[Main.myPlayer];

			Main.NewText("Quest Completed: " + player.anglerQuestsFinished, 0, 255, 255);

			if (GetInstance<CAnglerQuestRewardsConfig>().QuestFishermansGuideIncrease > 0)
			{
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestFishermansGuideIncrease)
				{
					Item rewardItem = new Item();
					rewardItem.SetDefaults(ItemID.FishermansGuide);
					rewardItem.stack = 1;
					rewardItems.Add(rewardItem);
				}
			}
			if (GetInstance<CAnglerQuestRewardsConfig>().QuestWeatherRadioIncrease > 0)
			{
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestWeatherRadioIncrease)
				{
					Item rewardItem2 = new Item();
					rewardItem2.SetDefaults(ItemID.WeatherRadio);
					rewardItem2.stack = 1;
					rewardItems.Add(rewardItem2);
				}
			}
			if (GetInstance<CAnglerQuestRewardsConfig>().QuestSextantIncrease > 0)
			{
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestSextantIncrease)
				{
					Item rewardItem3 = new Item();
					rewardItem3.SetDefaults(ItemID.Sextant);
					rewardItem3.stack = 1;
					rewardItems.Add(rewardItem3);
				}
			}
			if (GetInstance<CAnglerQuestRewardsConfig>().QuestAnglerHatIncrease > 0)
			{
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestAnglerHatIncrease)
				{
					Item rewardItem4 = new Item();
					rewardItem4.SetDefaults(ItemID.AnglerHat);
					rewardItem4.stack = 1;
					rewardItems.Add(rewardItem4);
				}
			}
			if (GetInstance<CAnglerQuestRewardsConfig>().QuestAnglerVestIncrease > 0)
			{
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestAnglerVestIncrease)
				{
					Item rewardItem5 = new Item();
					rewardItem5.SetDefaults(ItemID.AnglerVest);
					rewardItem5.stack = 1;
					rewardItems.Add(rewardItem5);
				}
			}
			if (GetInstance<CAnglerQuestRewardsConfig>().QuestAnglerPantsIncrease > 0)
			{
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestAnglerPantsIncrease)
				{
					Item rewardItem6 = new Item();
					rewardItem6.SetDefaults(ItemID.AnglerPants);
					rewardItem6.stack = 1;
					rewardItems.Add(rewardItem6);
				}
			}
			if (GetInstance<CAnglerQuestRewardsConfig>().QuestHighTestFishingLineIncrease > 0)
			{
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestHighTestFishingLineIncrease)
				{
					Item rewardItem7 = new Item();
					rewardItem7.SetDefaults(ItemID.HighTestFishingLine);
					rewardItem7.stack = 1;
					rewardItems.Add(rewardItem7);
				}
			}
			if (GetInstance<CAnglerQuestRewardsConfig>().QuestAnglerEarringIncrease > 0)
			{
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestAnglerEarringIncrease)
				{
					Item rewardItem8 = new Item();
					rewardItem8.SetDefaults(ItemID.AnglerEarring);
					rewardItem8.stack = 1;
					rewardItems.Add(rewardItem8);
				}
			}
			if (GetInstance<CAnglerQuestRewardsConfig>().QuestTackleBoxIncrease > 0)
			{
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestTackleBoxIncrease)
				{
					Item rewardItem9 = new Item();
					rewardItem9.SetDefaults(ItemID.TackleBox);
					rewardItem9.stack = 1;
					rewardItems.Add(rewardItem9);
				}
			}
			if (GetInstance<CAnglerQuestRewardsConfig>().QuestGoldenFishingRodIncrease > 0)
			{
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestGoldenFishingRodIncrease)
				{
					Item rewardItem10 = new Item();
					rewardItem10.SetDefaults(ItemID.GoldenFishingRod);
					rewardItem10.stack = 1;
					rewardItems.Add(rewardItem10);
				}
			}
			if (GetInstance<CAnglerQuestRewardsConfig>().QuestCoralstoneBlockIncrease > 0)
			{
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestCoralstoneBlockIncrease)
				{
					Item rewardItem11 = new Item();
					rewardItem11.SetDefaults(ItemID.CoralstoneBlock);
					rewardItem11.stack = Main.rand.Next(50, 150);
					rewardItems.Add(rewardItem11);
				}
			}
			if (GetInstance<CAnglerQuestRewardsConfig>().QuestGoldenBugNetIncrease > 0)
			{
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestGoldenBugNetIncrease)
				{
					Item rewardItem10 = new Item();
					rewardItem10.SetDefaults(3183);
					rewardItem10.stack = 1;
					rewardItems.Add(rewardItem10);
				}
			}
			if (GetInstance<CAnglerQuestRewardsConfig>().QuestFishHookIncrease > 0)
			{
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestFishHookIncrease)
				{
					Item rewardItem10 = new Item();
					rewardItem10.SetDefaults(2360);
					rewardItem10.stack = 1;
					rewardItems.Add(rewardItem10);
				}
			}
			if (Main.hardMode)
			{
				if (GetInstance<CAnglerQuestRewardsConfig>().QuestHardcoreFinWingsIncrease > 0)
				{
					if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestHardcoreFinWingsIncrease)
					{
						Item rewardItem12 = new Item();
						rewardItem12.SetDefaults(ItemID.FinWings);
						rewardItem12.stack = 1;
						rewardItems.Add(rewardItem12);
					}
				}
				if (GetInstance<CAnglerQuestRewardsConfig>().QuestHardcoreBottomlessBucketIncrease > 0)
				{
					if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestHardcoreBottomlessBucketIncrease)
					{
						Item rewardItem13 = new Item();
						rewardItem13.SetDefaults(ItemID.BottomlessBucket);
						rewardItem13.stack = 1;
						rewardItems.Add(rewardItem13);
					}
				}
				if (GetInstance<CAnglerQuestRewardsConfig>().QuestHardcoreSuperAbsorbantSpongeIncrease > 0)
				{
					if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestHardcoreSuperAbsorbantSpongeIncrease)
					{
						Item rewardItem14 = new Item();
						rewardItem14.SetDefaults(ItemID.SuperAbsorbantSponge);
						rewardItem14.stack = 1;
						rewardItems.Add(rewardItem14);
					}
				}
				if (GetInstance<CAnglerQuestRewardsConfig>().QuestHardcoreHotlineFishingHookIncrease > 0)
				{
					if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestHardcoreHotlineFishingHookIncrease)
					{
						Item rewardItem15 = new Item();
						rewardItem15.SetDefaults(ItemID.HotlineFishingHook);
						rewardItem15.stack = 1;
						rewardItems.Add(rewardItem15);
					}
				}
			}
			if (GetInstance<CAnglerQuestRewardsConfig>().QuestTrophyIncrease > 0)
			{
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestTrophyIncrease)
				{
					Item rewardItem16 = new Item();
					rewardItem16.SetDefaults(2446);
					rewardItem16.stack = 1;
					rewardItems.Add(rewardItem16);
				}
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestTrophyIncrease)
				{
					Item rewardItem17 = new Item();
					rewardItem17.SetDefaults(2447);
					rewardItem17.stack = 1;
					rewardItems.Add(rewardItem17);
				}
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestTrophyIncrease)
				{
					Item rewardItem18 = new Item();
					rewardItem18.SetDefaults(2448);
					rewardItem18.stack = 1;
					rewardItems.Add(rewardItem18);
				}
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestTrophyIncrease)
				{
					Item rewardItem19 = new Item();
					rewardItem19.SetDefaults(2449);
					rewardItem19.stack = 1;
					rewardItems.Add(rewardItem19);
				}
			}
			if (GetInstance<CAnglerQuestRewardsConfig>().QuestDecorativeFurnitureIncrease > 0)
			{
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestDecorativeFurnitureIncrease)
				{
					Item rewardItem20 = new Item();
					rewardItem20.SetDefaults(2496);
					rewardItem20.stack = 1;
					rewardItems.Add(rewardItem20);
				}
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestDecorativeFurnitureIncrease)
				{
					Item rewardItem21 = new Item();
					rewardItem21.SetDefaults(2497);
					rewardItem21.stack = 1;
					rewardItems.Add(rewardItem21);
				}
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestDecorativeFurnitureIncrease)
				{
					Item rewardItem22 = new Item();
					rewardItem22.SetDefaults(2442);
					rewardItem22.stack = 1;
					rewardItems.Add(rewardItem22);
				}
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestDecorativeFurnitureIncrease)
				{
					Item rewardItem23 = new Item();
					rewardItem23.SetDefaults(2443);
					rewardItem23.stack = 1;
					rewardItems.Add(rewardItem23);
				}
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestDecorativeFurnitureIncrease)
				{
					Item rewardItem24 = new Item();
					rewardItem24.SetDefaults(2444);
					rewardItem24.stack = 1;
					rewardItems.Add(rewardItem24);
				}
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestDecorativeFurnitureIncrease)
				{
					Item rewardItem25 = new Item();
					rewardItem25.SetDefaults(2445);
					rewardItem25.stack = 1;
					rewardItems.Add(rewardItem25);
				}
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestDecorativeFurnitureIncrease)
				{
					Item rewardItem26 = new Item();
					rewardItem26.SetDefaults(2490);
					rewardItem26.stack = 1;
					rewardItems.Add(rewardItem26);
				}
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestFishCostumeIncrease)
				{
					Item rewardItem26 = new Item();
					rewardItem26.SetDefaults(2498); //Mask
					rewardItem26.stack = 1;
					rewardItems.Add(rewardItem26);
					
					Item rewardItem27 = new Item();
					rewardItem27.SetDefaults(2499); //Shirt
					rewardItem27.stack = 1;
					rewardItems.Add(rewardItem27);
					
					Item rewardItem28 = new Item();
					rewardItem28.SetDefaults(2500); //Finskirt
					rewardItem28.stack = 1;
					rewardItems.Add(rewardItem28);
				}
				if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestMermaidCostumeIncrease)
				{
					Item rewardItem26 = new Item();
					rewardItem26.SetDefaults(2417); //Hairpin
					rewardItem26.stack = 1;
					rewardItems.Add(rewardItem26);
					
					Item rewardItem27 = new Item();
					rewardItem27.SetDefaults(2418); //Adornment
					rewardItem27.stack = 1;
					rewardItems.Add(rewardItem27);
					
					Item rewardItem28 = new Item();
					rewardItem28.SetDefaults(2419); //Tail
					rewardItem28.stack = 1;
					rewardItems.Add(rewardItem28);
				}
			}
		}
		
		public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
		{
			//The maximum amount of fishing power is 282: https://terraria.gamepedia.com/Fishing#Notes

			if (junk)
				return;
			bool enableFishUpgrade = (player.FindBuffIndex(mod.BuffType("Fish_Upgrade")) != -1);

			if (!(fishingRod.type == 2289 || (fishingRod.type >= 2291 && fishingRod.type <= 2296) || fishingRod.type == 2421 || fishingRod.type == 2422))
				enableFishUpgrade = false; //Vanilla Rods Only

			float upgradeRate = (power - 141) / 141;

			if (Main.rand.NextFloat() < upgradeRate && enableFishUpgrade)
			{
				bool common, uncommon, rare, veryRare, superRare, isCrate;
				for (int i = 0; i < Math.Min(1000, (player.anglerQuestsFinished / 5)); i++)
				{
					if ((caughtType >= 2297 && caughtType <= 2302) || caughtType == 2290 || caughtType == 2316) //Non-Rare Fish
					{
						caughtType = 0;
						calculateCatchRates(power, out common, out uncommon, out rare, out veryRare, out superRare, out isCrate);

						if (isCrate) return;

						if (liquidType == 1) //Lava
						{
							if (superRare)
							{
								caughtType = 2331;
							}
							else if (veryRare)
							{
								caughtType = 2331;
							}
							else if (rare)
							{
								caughtType = 2315;
							}
						}
						else if (liquidType == 2) //Honey
						{
							if (rare || (uncommon && Main.rand.Next(2) == 0))
							{
								caughtType = 2314;
							}
							else if (uncommon && questFish == 2451)
							{
								caughtType = 2451;
							}
						}
						else if (isCrate)
						{
							caughtType = ((veryRare | superRare) ? 2336 : ((rare && player.ZoneCorrupt) ? 3203 : ((rare && player.ZoneCrimson) ? 3204 : ((rare && player.ZoneHoly) ? 3207 : ((rare && player.ZoneDungeon) ? 3205 : ((rare && player.ZoneJungle) ? 3208 : ((rare && worldLayer == 0) ? 3206 : ((!uncommon) ? 2334 : 2335))))))));
						}
						else if (superRare && Main.rand.Next(5) == 0)
						{
							caughtType = 2423;
						}
						else if (superRare && Main.rand.Next(5) == 0)
						{
							caughtType = 3225;
						}
						else if (superRare && Main.rand.Next(10) == 0)
						{
							caughtType = 2420;
						}
						else if (((!superRare && !veryRare) & uncommon) && Main.rand.Next(5) == 0)
						{
							caughtType = 3196;
						}
						else
						{
							bool flag8 = player.ZoneCorrupt;
							bool flag9 = player.ZoneCrimson;
							if (flag8 && flag9)
							{
								if (Main.rand.Next(2) == 0)
								{
									flag9 = false;
								}
								else
								{
									flag8 = false;
								}
							}
							if (flag8)
							{
								if (superRare && Main.hardMode && player.ZoneSnow && worldLayer == 3 && Main.rand.Next(3) != 0)
								{
									caughtType = 2429;
								}
								else if (superRare && Main.hardMode && Main.rand.Next(2) == 0)
								{
									caughtType = 3210;
								}
								else if (rare)
								{
									caughtType = 2330;
								}
								else if (uncommon && questFish == 2454)
								{
									caughtType = 2454;
								}
								else if (uncommon && questFish == 2485)
								{
									caughtType = 2485;
								}
								else if (uncommon && questFish == 2457)
								{
									caughtType = 2457;
								}
								else if (uncommon)
								{
									caughtType = 2318;
								}
							}
							else if (flag9)
							{
								if (superRare && Main.hardMode && player.ZoneSnow && worldLayer == 3 && Main.rand.Next(3) != 0)
								{
									caughtType = 2429;
								}
								else if (superRare && Main.hardMode && Main.rand.Next(2) == 0)
								{
									caughtType = 3211;
								}
								else if (uncommon && questFish == 2477)
								{
									caughtType = 2477;
								}
								else if (uncommon && questFish == 2463)
								{
									caughtType = 2463;
								}
								else if (uncommon)
								{
									caughtType = 2319;
								}
								else if (common)
								{
									caughtType = 2305;
								}
							}
							else if (player.ZoneHoly)
							{
								if (superRare && Main.hardMode && player.ZoneSnow && worldLayer == 3 && Main.rand.Next(3) != 0)
								{
									caughtType = 2429;
								}
								else if (superRare && Main.hardMode && Main.rand.Next(2) == 0)
								{
									caughtType = 3209;
								}
								else if (worldLayer > 1 && veryRare)
								{
									caughtType = 2317;
								}
								else if (worldLayer > 1 && rare && questFish == 2465)
								{
									caughtType = 2465;
								}
								else if (worldLayer < 2 && rare && questFish == 2468)
								{
									caughtType = 2468;
								}
								else if (rare)
								{
									caughtType = 2310;
								}
								else if (uncommon && questFish == 2471)
								{
									caughtType = 2471;
								}
								else if (uncommon)
								{
									caughtType = 2307;
								}
							}
							if (caughtType == 0 && player.ZoneSnow)
							{
								if (worldLayer < 2 && uncommon && questFish == 2467)
								{
									caughtType = 2467;
								}
								else if (worldLayer == 1 && uncommon && questFish == 2470)
								{
									caughtType = 2470;
								}
								else if (worldLayer >= 2 && uncommon && questFish == 2484)
								{
									caughtType = 2484;
								}
								else if (worldLayer > 1 && uncommon && questFish == 2466)
								{
									caughtType = 2466;
								}
								else if ((common && Main.rand.Next(12) == 0) || (uncommon && Main.rand.Next(6) == 0))
								{
									caughtType = 3197;
								}
								else if (uncommon)
								{
									caughtType = 2306;
								}
								else if (common)
								{
									caughtType = 2299;
								}
								else if (worldLayer > 1 && Main.rand.Next(3) == 0)
								{
									caughtType = 2309;
								}
							}
							if (caughtType == 0 && player.ZoneJungle)
							{
								if (worldLayer == 1 && uncommon && questFish == 2452)
								{
									caughtType = 2452;
								}
								else if (worldLayer == 1 && uncommon && questFish == 2483)
								{
									caughtType = 2483;
								}
								else if (worldLayer == 1 && uncommon && questFish == 2488)
								{
									caughtType = 2488;
								}
								else if (worldLayer >= 1 && uncommon && questFish == 2486)
								{
									caughtType = 2486;
								}
								else if (worldLayer > 1 && uncommon)
								{
									caughtType = 2311;
								}
								else if (uncommon)
								{
									caughtType = 2313;
								}
								else if (common)
								{
									caughtType = 2302;
								}
							}
							if (((caughtType == 0 && Main.shroomTiles > 200) & uncommon) && questFish == 2475)
							{
								caughtType = 2475;
							}
							if (caughtType == 0)
							{
								if (worldLayer <= 1 && player.ZoneBeach && poolSize > 1000)
								{
									caughtType = ((veryRare && Main.rand.Next(2) == 0) ? 2341 : (veryRare ? 2342 : ((rare && Main.rand.Next(5) == 0) ? 2438 : ((rare && Main.rand.Next(2) == 0) ? 2332 : ((uncommon && questFish == 2480) ? 2480 : ((uncommon && questFish == 2481) ? 2481 : (uncommon ? 2316 : ((common && Main.rand.Next(2) == 0) ? 2301 : ((!common) ? 2297 : 2300)))))))));
								}
								else
								{
									int sandTiles = Main.sandTiles;
								}
							}
							if (caughtType == 0)
							{
								caughtType = ((worldLayer < 2 && uncommon && questFish == 2461) ? 2461 : ((worldLayer == 0 && uncommon && questFish == 2453) ? 2453 : ((worldLayer == 0 && uncommon && questFish == 2473) ? 2473 : ((worldLayer == 0 && uncommon && questFish == 2476) ? 2476 : ((worldLayer < 2 && uncommon && questFish == 2458) ? 2458 : ((worldLayer < 2 && uncommon && questFish == 2459) ? 2459 : ((worldLayer == 0 && uncommon) ? 2304 : ((((worldLayer > 0 && worldLayer < 3) & uncommon) && questFish == 2455) ? 2455 : ((worldLayer == 1 && uncommon && questFish == 2479) ? 2479 : ((worldLayer == 1 && uncommon && questFish == 2456) ? 2456 : ((worldLayer == 1 && uncommon && questFish == 2474) ? 2474 : ((worldLayer > 1 && rare && Main.rand.Next(5) == 0) ? ((!Main.hardMode || Main.rand.Next(2) != 0) ? 2436 : 2437) : ((worldLayer > 1 && superRare) ? 2308 : ((worldLayer > 1 && veryRare && Main.rand.Next(2) == 0) ? 2320 : ((worldLayer > 1 && rare) ? 2321 : ((worldLayer > 1 && uncommon && questFish == 2478) ? 2478 : ((worldLayer > 1 && uncommon && questFish == 2450) ? 2450 : ((worldLayer > 1 && uncommon && questFish == 2464) ? 2464 : ((worldLayer > 1 && uncommon && questFish == 2469) ? 2469 : ((worldLayer > 2 && uncommon && questFish == 2462) ? 2462 : ((worldLayer > 2 && uncommon && questFish == 2482) ? 2482 : ((worldLayer > 2 && uncommon && questFish == 2472) ? 2472 : ((worldLayer > 2 && uncommon && questFish == 2460) ? 2460 : ((worldLayer > 1 && uncommon && Main.rand.Next(4) != 0) ? 2303 : ((worldLayer > 1 && ((uncommon | common) || Main.rand.Next(4) == 0)) ? ((Main.rand.Next(4) != 0) ? 2309 : 2303) : ((uncommon && questFish == 2487) ? 2487 : ((poolSize <= 1000 || !common) ? 2290 : 2298)))))))))))))))))))))))))));
							}
						}
					}
					else
						break;
				}
			}
			if ((caughtType >= 2334 && caughtType <= 2336) || (caughtType >= 3203 && caughtType <= 3208)) //Caught a crate
			{
				if (power > 70.5f && caughtType == ItemID.WoodenCrate)
				{
					upgradeRate = (power - 70.5f) / 70.5f;
					if (Main.rand.NextFloat() < upgradeRate)
					{
						caughtType = ItemID.IronCrate;
					}
				}
				if (power > 141 && caughtType == ItemID.IronCrate)
				{
					upgradeRate = (power - 141) / 70.5f;
					if (Main.rand.NextFloat() < upgradeRate)
					{
						if (player.ZoneJungle)
							caughtType = ItemID.JungleFishingCrate;
						else if (worldLayer == 0)
							caughtType = ItemID.FloatingIslandFishingCrate;
						else if (player.ZoneCorrupt)
							caughtType = ItemID.CorruptFishingCrate;
						else if (player.ZoneCrimson)
							caughtType = ItemID.CrimsonFishingCrate;
						else if (player.ZoneHoly)
							caughtType = ItemID.HallowedFishingCrate;
						else if (player.ZoneDungeon)
							caughtType = ItemID.DungeonFishingCrate;
					}
				}
				if (power > 211.5f && (caughtType == ItemID.IronCrate))
				{
					upgradeRate = (power - 211.5f) / 70.5f;
					if (Main.rand.NextFloat() < upgradeRate)
					{
						caughtType = ItemID.GoldenCrate;
					}
				}
			}
		}

		public void calculateCatchRates(int power, out bool common, out bool uncommon, out bool rare, out bool veryrare, out bool superrare, out bool isCrate)
		{
			common = false;
			uncommon = false;
			rare = false;
			veryrare = false;
			superrare = false;
			isCrate = false;

			if (power <= 0) return;

			if (Main.rand.Next(Math.Max(2, 150 * 1 / power)) == 0)
				common = true;
			if (Main.rand.Next(Math.Max(3, 150 * 2 / power)) == 0)
				uncommon = true;
			if (Main.rand.Next(Math.Max(4, 150 * 7 / power)) == 0)
				rare = true;
			if (Main.rand.Next(Math.Max(5, 150 * 15 / power)) == 0)
				veryrare = true;
			if (Main.rand.Next(Math.Max(6, 150 * 30 / power)) == 0)
				superrare = true;
			if (Main.rand.Next(100) < (10 + (player.cratePotion ? 10 : 0)))
				isCrate = true;
		}

		public override void PostUpdate()
		{
			Player player = Main.LocalPlayer;
			
			if (NPC.taxCollector && Main.time == 1.0)
			{

				if (player.taxMoney >= GetInstance<FOtherVanillaNPCConfig>().TaxCollectorTaxRequiredToChatTaxatMorningAndNight)
				{
					int taxGold = player.taxMoney;
					int taxSilver = 0;
					int taxCopper = 0;
					taxCopper = taxGold % 100;
					taxGold = (taxGold - taxCopper) / 100;
					taxSilver = taxGold % 100;
					taxGold = (taxGold - taxSilver) / 100;
					Main.NewText("Tax Money:");
					if (taxGold > 0)
						Main.NewText(taxGold.ToString() + " Gold", 255, 255, 0);
					if (taxSilver > 0)
					Main.NewText(taxSilver.ToString() + " Silver", 191, 191, 191);
					if (taxCopper > 0)
					Main.NewText(taxCopper.ToString() + " Copper", 255, 127, 0);
				}
			}
		}
    }
}
 