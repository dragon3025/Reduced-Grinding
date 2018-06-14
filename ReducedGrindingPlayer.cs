using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.IO;
using System;


namespace ReducedGrinding
{
	
	class ReducedGrindingPlayer : ModPlayer
    {
		
		public override void AnglerQuestReward(float quality, List<Item> rewardItems)
		{
			Player player = Main.player[Main.myPlayer];
			if (Config.QuestFishermansGuideIncrease > 0)
			{
				if (Main.rand.Next(10000)+1 <= Config.QuestFishermansGuideIncrease*10000)
				{
					Item rewardItem = new Item();
					rewardItem.SetDefaults(ItemID.FishermansGuide);
					rewardItem.stack = 1;
					rewardItems.Add(rewardItem);
				}
			}
			if (Config.QuestWeatherRadioIncrease > 0)
			{
				if (Main.rand.Next(10000)+1 <= Config.QuestWeatherRadioIncrease*10000)
				{
					Item rewardItem2 = new Item();
					rewardItem2.SetDefaults(ItemID.WeatherRadio);
					rewardItem2.stack = 1;
					rewardItems.Add(rewardItem2);
				}
			}
			if (Config.QuestSextantIncrease > 0)
			{
				if (Main.rand.Next(10000)+1 <= Config.QuestSextantIncrease*10000)
				{
					Item rewardItem3 = new Item();
					rewardItem3.SetDefaults(ItemID.Sextant);
					rewardItem3.stack = 1;
					rewardItems.Add(rewardItem3);
				}
			}
			if (Config.QuestAnglerHatIncrease > 0)
			{
				if (Main.rand.Next(10000)+1 <= Config.QuestAnglerHatIncrease*10000)
				{
					Item rewardItem4 = new Item();
					rewardItem4.SetDefaults(ItemID.AnglerHat);
					rewardItem4.stack = 1;
					rewardItems.Add(rewardItem4);
				}
			}
			if (Config.QuestAnglerVestIncrease > 0)
			{
				if (Main.rand.Next(10000)+1 <= Config.QuestAnglerVestIncrease*10000)
				{
					Item rewardItem5 = new Item();
					rewardItem5.SetDefaults(ItemID.AnglerVest);
					rewardItem5.stack = 1;
					rewardItems.Add(rewardItem5);
				}
			}
			if (Config.QuestAnglerPantsIncrease > 0)
			{
				if (Main.rand.Next(10000)+1 <= Config.QuestAnglerPantsIncrease*10000)
				{
					Item rewardItem6 = new Item();
					rewardItem6.SetDefaults(ItemID.AnglerPants);
					rewardItem6.stack = 1;
					rewardItems.Add(rewardItem6);
				}
			}
			if (Config.QuestHighTestFishingLineIncrease > 0)
			{
				if (Main.rand.Next(10000)+1 <= Config.QuestHighTestFishingLineIncrease*10000)
				{
					Item rewardItem7 = new Item();
					rewardItem7.SetDefaults(ItemID.HighTestFishingLine);
					rewardItem7.stack = 1;
					rewardItems.Add(rewardItem7);
				}
			}
			if (Config.QuestAnglerEarringIncrease > 0)
			{
				if (Main.rand.Next(10000)+1 <= Config.QuestAnglerEarringIncrease*10000)
				{
					Item rewardItem8 = new Item();
					rewardItem8.SetDefaults(ItemID.AnglerEarring);
					rewardItem8.stack = 1;
					rewardItems.Add(rewardItem8);
				}
			}
			if (Config.QuestTackleBoxIncrease > 0)
			{
				if (Main.rand.Next(10000)+1 <= Config.QuestTackleBoxIncrease*10000)
				{
					Item rewardItem9 = new Item();
					rewardItem9.SetDefaults(ItemID.TackleBox);
					rewardItem9.stack = 1;
					rewardItems.Add(rewardItem9);
				}
			}
			if (Config.QuestGoldenFishingRodIncrease > 0)
			{
				if (Main.rand.Next(10000)+1 <= Config.QuestGoldenFishingRodIncrease*10000)
				{
					Item rewardItem10 = new Item();
					rewardItem10.SetDefaults(ItemID.GoldenFishingRod);
					rewardItem10.stack = 1;
					rewardItems.Add(rewardItem10);
				}
			}
			if (Config.QuestCoralstoneBlockIncrease > 0)
			{
				if (Main.rand.Next(10000)+1 <= Config.QuestCoralstoneBlockIncrease*10000)
				{
					Item rewardItem11 = new Item();
					rewardItem11.SetDefaults(ItemID.CoralstoneBlock);
					rewardItem11.stack = Main.rand.Next(50, 150);
					rewardItems.Add(rewardItem11);
				}
			}
			if (Config.QuestGoldenBugNetIncrease > 0)
			{
				if (Main.rand.Next(10000)+1 <= Config.QuestGoldenBugNetIncrease*10000)
				{
					Item rewardItem10 = new Item();
					rewardItem10.SetDefaults(3183);
					rewardItem10.stack = 1;
					rewardItems.Add(rewardItem10);
				}
			}
			if (Config.QuestFishHookIncrease > 0)
			{
				if (Main.rand.Next(10000)+1 <= Config.QuestFishHookIncrease*10000)
				{
					Item rewardItem10 = new Item();
					rewardItem10.SetDefaults(2360);
					rewardItem10.stack = 1;
					rewardItems.Add(rewardItem10);
				}
			}
			if (Main.hardMode)
			{
				if (Config.QuestHardcoreFinWingsIncrease > 0)
				{
					if (Main.rand.Next(10000)+1 <= Config.QuestHardcoreFinWingsIncrease*10000)
					{
						Item rewardItem12 = new Item();
						rewardItem12.SetDefaults(ItemID.FinWings);
						rewardItem12.stack = 1;
						rewardItems.Add(rewardItem12);
					}
				}
				if (Config.QuestHardcoreBottomlessBucketIncrease > 0)
				{
					if (Main.rand.Next(10000)+1 <= Config.QuestHardcoreBottomlessBucketIncrease*10000)
					{
						Item rewardItem13 = new Item();
						rewardItem13.SetDefaults(ItemID.BottomlessBucket);
						rewardItem13.stack = 1;
						rewardItems.Add(rewardItem13);
					}
				}
				if (Config.QuestHardcoreSuperAbsorbantSpongeIncrease > 0)
				{
					if (Main.rand.Next(10000)+1 <= Config.QuestHardcoreSuperAbsorbantSpongeIncrease*10000)
					{
						Item rewardItem14 = new Item();
						rewardItem14.SetDefaults(ItemID.SuperAbsorbantSponge);
						rewardItem14.stack = 1;
						rewardItems.Add(rewardItem14);
					}
				}
				if (Config.QuestHardcoreHotlineFishingHookIncrease > 0)
				{
					if (Main.rand.Next(10000)+1 <= Config.QuestHardcoreHotlineFishingHookIncrease*10000)
					{
						Item rewardItem15 = new Item();
						rewardItem15.SetDefaults(ItemID.HotlineFishingHook);
						rewardItem15.stack = 1;
						rewardItems.Add(rewardItem15);
					}
				}
			}
			if (Config.QuestTrophyIncrease > 0)
			{
				if (Main.rand.Next(10000)+1 <= Config.QuestTrophyIncrease*10000)
				{
					Item rewardItem16 = new Item();
					rewardItem16.SetDefaults(2446);
					rewardItem16.stack = 1;
					rewardItems.Add(rewardItem16);
				}
				if (Main.rand.Next(10000)+1 <= Config.QuestTrophyIncrease*10000)
				{
					Item rewardItem17 = new Item();
					rewardItem17.SetDefaults(2447);
					rewardItem17.stack = 1;
					rewardItems.Add(rewardItem17);
				}
				if (Main.rand.Next(10000)+1 <= Config.QuestTrophyIncrease*10000)
				{
					Item rewardItem18 = new Item();
					rewardItem18.SetDefaults(2448);
					rewardItem18.stack = 1;
					rewardItems.Add(rewardItem18);
				}
				if (Main.rand.Next(10000)+1 <= Config.QuestTrophyIncrease*10000)
				{
					Item rewardItem19 = new Item();
					rewardItem19.SetDefaults(2449);
					rewardItem19.stack = 1;
					rewardItems.Add(rewardItem19);
				}
			}
			if (Config.QuestDecorativeFurnitureIncrease > 0)
			{
				if (Main.rand.Next(10000)+1 <= Config.QuestDecorativeFurnitureIncrease*10000)
				{
					Item rewardItem20 = new Item();
					rewardItem20.SetDefaults(2496);
					rewardItem20.stack = 1;
					rewardItems.Add(rewardItem20);
				}
				if (Main.rand.Next(10000)+1 <= Config.QuestDecorativeFurnitureIncrease*10000)
				{
					Item rewardItem21 = new Item();
					rewardItem21.SetDefaults(2497);
					rewardItem21.stack = 1;
					rewardItems.Add(rewardItem21);
				}
				if (Main.rand.Next(10000)+1 <= Config.QuestDecorativeFurnitureIncrease*10000)
				{
					Item rewardItem22 = new Item();
					rewardItem22.SetDefaults(2442);
					rewardItem22.stack = 1;
					rewardItems.Add(rewardItem22);
				}
				if (Main.rand.Next(10000)+1 <= Config.QuestDecorativeFurnitureIncrease*10000)
				{
					Item rewardItem23 = new Item();
					rewardItem23.SetDefaults(2443);
					rewardItem23.stack = 1;
					rewardItems.Add(rewardItem23);
				}
				if (Main.rand.Next(10000)+1 <= Config.QuestDecorativeFurnitureIncrease*10000)
				{
					Item rewardItem24 = new Item();
					rewardItem24.SetDefaults(2444);
					rewardItem24.stack = 1;
					rewardItems.Add(rewardItem24);
				}
				if (Main.rand.Next(10000)+1 <= Config.QuestDecorativeFurnitureIncrease*10000)
				{
					Item rewardItem25 = new Item();
					rewardItem25.SetDefaults(2445);
					rewardItem25.stack = 1;
					rewardItems.Add(rewardItem25);
				}
				if (Main.rand.Next(10000)+1 <= Config.QuestDecorativeFurnitureIncrease*10000)
				{
					Item rewardItem26 = new Item();
					rewardItem26.SetDefaults(2490);
					rewardItem26.stack = 1;
					rewardItems.Add(rewardItem26);
				}
			}
		}
		
		public override void SetupStartInventory(IList<Item> items)
		{
			Item item = new Item();
			item.SetDefaults(ItemID.MiningPotion);
			item.stack = Config.NewCharacterMiningPotions;
			items.Add(item);
			
			Item item2 = new Item();
            item2.SetDefaults(ItemID.CopperBar);
			item2.stack = Config.NewCharacterCopperBars;
			items.Add(item2);
			
			Item item3 = new Item();
            item3.SetDefaults(ItemID.IronBar);
			item3.stack = Config.NewCharacterIronBars;
			items.Add(item3);
			
			Item item4 = new Item();
            item4.SetDefaults(ItemID.SilverBar);
			item4.stack = Config.NewCharacterSilverBars;
			items.Add(item4);

			Item item5 = new Item();
            item5.SetDefaults(ItemID.GoldBar);
			item5.stack = Config.NewCharacterGoldBars;
			items.Add(item5);

			Item item6 = new Item();
            item6.SetDefaults(ItemID.Barrel);
			item6.stack = Config.NewCharacterBarrels;
			items.Add(item6);

			Item item7 = new Item();
            item7.SetDefaults(ItemID.CopperCoin);
			item7.stack = Config.NewCharacterCopperCoins;
			items.Add(item7);

			Item item8 = new Item();
            item8.SetDefaults(ItemID.SilverCoin);
			item8.stack = Config.NewCharacterSilverCoins;
			items.Add(item8);

			Item item9 = new Item();
            item9.SetDefaults(ItemID.GoldCoin);
			item9.stack = Config.NewCharacterGoldCoins;
			items.Add(item9);

			Item item10 = new Item();
            item10.SetDefaults(ItemID.PlatinumCoin);
			item10.stack = Config.NewCharacterPlatinumCoins;
			items.Add(item10);

			Item item11 = new Item();
			item11.SetDefaults(mod.ItemType("War_Potion"));
			item11.stack = Config.NewCharacterWarPotions;
			items.Add(item11);
		}
		
		public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
		{
			if (junk)
			{
				return;
			}
			
			int EyeEaterSkeletronDowned = 0;
			if (NPC.downedBoss1)
				EyeEaterSkeletronDowned++;
			if (NPC.downedBoss2)
				EyeEaterSkeletronDowned++;
			if (NPC.downedBoss3)
				EyeEaterSkeletronDowned++;
			int MechBossesDowned = 0;
			if (NPC.downedMechBoss1)
				MechBossesDowned++;
			if (NPC.downedMechBoss2)
				MechBossesDowned++;
			if (NPC.downedMechBoss3)
				MechBossesDowned++;
			
			float reaverSharkRate = 0;
			if (NPC.downedMechBossAny)
				reaverSharkRate = Config.FishCatchBecomesReaverSharkAfterEyeOfCthulhuEaterOfWorldsAndSkeletronDowned + (Config.FishCatchBecomesReaverSharkAfterAllMechBossesDowned - Config.FishCatchBecomesReaverSharkAfterEyeOfCthulhuEaterOfWorldsAndSkeletronDowned) * MechBossesDowned / 3;
			else{
				reaverSharkRate = Config.FishCatchBecomesReaverSharkBeforeEyeOfCthulhuEaterOfWorldsAndSkeletronDowned + (Config.FishCatchBecomesReaverSharkAfterEyeOfCthulhuEaterOfWorldsAndSkeletronDowned - Config.FishCatchBecomesReaverSharkBeforeEyeOfCthulhuEaterOfWorldsAndSkeletronDowned) * EyeEaterSkeletronDowned / 3;
			}
			float sawtoothSharkRate = 0;
			if (NPC.downedMechBossAny)
				reaverSharkRate = Config.FishCatchBecomesSawtoothSharkAfterEyeOfCthulhuEaterOfWorldsAndSkeletronDowned + (Config.FishCatchBecomesSawtoothSharkAfterAllMechBossesDowned - Config.FishCatchBecomesSawtoothSharkAfterEyeOfCthulhuEaterOfWorldsAndSkeletronDowned) * MechBossesDowned / 3;
			else{
				sawtoothSharkRate = Config.FishCatchBecomesSawtoothSharkBeforeEyeOfCthulhuEaterOfWorldsAndSkeletronDowned + (Config.FishCatchBecomesSawtoothSharkAfterEyeOfCthulhuEaterOfWorldsAndSkeletronDowned - Config.FishCatchBecomesSawtoothSharkBeforeEyeOfCthulhuEaterOfWorldsAndSkeletronDowned) * EyeEaterSkeletronDowned / 3;
			}
			
			float powerFloat = power;
			float crateUpgradeRate = 0;
			
			if ((caughtType >= 2334 && caughtType <= 2336) || (caughtType >= 3203 && caughtType <= 3208)) //Caught a crate
			{
				if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesGoldenCrate*10000*Math.Min(1, powerFloat/257))
					caughtType = ItemID.GoldenCrate;
				else if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesJungleCrate*10000*Math.Min(1, powerFloat/257) && player.ZoneJungle)
					caughtType = ItemID.JungleFishingCrate;
				else if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesCorruptCrate*10000*Math.Min(1, powerFloat/257) && player.ZoneCorrupt)
					caughtType = ItemID.CorruptFishingCrate;
				else if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesCrimsonCrate*10000*Math.Min(1, powerFloat/257) && player.ZoneCrimson)
					caughtType = ItemID.CrimsonFishingCrate;
				else if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesHallowedCrate*10000*Math.Min(1, powerFloat/257) && player.ZoneHoly)
					caughtType = ItemID.HallowedFishingCrate;
				else if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesDungeonCrate*10000*Math.Min(1, powerFloat/257) && player.ZoneDungeon)
					caughtType = ItemID.DungeonFishingCrate;
				else if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesSkyCrate*10000*Math.Min(1, powerFloat/257) && worldLayer == 0)
					caughtType = ItemID.FloatingIslandFishingCrate;
				else if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesIronCrate*10000*Math.Min(1, powerFloat/257))
					caughtType = ItemID.IronCrate;
				else if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesWoodenCrate*10000*Math.Min(1, powerFloat/257))
					caughtType = ItemID.WoodenCrate;
				
				if (Config.CrateUpgradesDependingOnFishingPower)
				{
					if (power > 50 && caughtType == ItemID.WoodenCrate)
					{
						crateUpgradeRate = (power - 50) / 77;
						if (Main.rand.Next(10000)+1 <= 10000*crateUpgradeRate){
							caughtType = ItemID.IronCrate;
						}
					}
					if (power > 50 && caughtType == ItemID.IronCrate && player.ZoneDungeon)
					{
						crateUpgradeRate = (power - 127) / 78;
						if (Main.rand.Next(10000)+1 <= 10000*crateUpgradeRate)
							caughtType = ItemID.DungeonFishingCrate;
					}
					if (power > 127 && caughtType == ItemID.IronCrate)
					{
						crateUpgradeRate = (power - 127) / 78;
						if (Main.rand.Next(10000)+1 <= 10000*crateUpgradeRate){
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
					if (power > 205 && (caughtType == ItemID.IronCrate || (caughtType >= 3203 && caughtType <= 3208)))
					{
						crateUpgradeRate = (power - 205) / 77;
						if (Main.rand.Next(10000)+1 <= 10000*crateUpgradeRate){
							caughtType = ItemID.GoldenCrate;
						}
					}
				}
			}
			else
			{
				for (int i = 1; i <= 18; i++)//Do 18 times
				{
					switch (Main.rand.Next(18+1))
					{
						//Worldlayers: 0, sky; 1, surface; 2, underground; 3, caverns; and 4, underworld.
						//Power affects config rate. It's mulitplied by power/257 , but capped at 1.
						case 1:
							if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesGoldenCarp*10000*Math.Min(1, powerFloat/257) && worldLayer >= 2)
							{
								caughtType = ItemID.GoldenCarp;
								i = 19;
							}
							break;
						case 2:
							if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesBlueJellyfish*10000*Math.Min(1, powerFloat/257) && worldLayer >= 3 && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly)
							{
								caughtType = ItemID.BlueJellyfish;
								i = 19;
							}
							break;
						case 3:
							if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesPinkJellyfish*10000*Math.Min(1, powerFloat/257) && worldLayer <= 1 && player.ZoneBeach)
							{
								caughtType = ItemID.PinkJellyfish;
								i = 19;
							}
							break;
						case 4:
							if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesGreenJellyfish*10000*Math.Min(1, powerFloat/257) && worldLayer >= 3 && Main.hardMode && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly)
							{
								caughtType = ItemID.GreenJellyfish;
								i = 19;
							}
							break;
						case 5:
							if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesChaosFish*10000*Math.Min(1, powerFloat/257) && worldLayer >= 2 && player.ZoneHoly)
							{
								caughtType = ItemID.ChaosFish;
								i = 19;
							}
							break;
						case 6:
							if (Main.rand.Next(10000)+1 <= reaverSharkRate*10000*Math.Min(1, powerFloat/257) && worldLayer <= 1 && player.ZoneBeach)
							{
								caughtType = ItemID.ReaverShark;
								i = 19;
							}
							break;
						case 7:
							if (Main.rand.Next(10000)+1 <= sawtoothSharkRate*10000*Math.Min(1, powerFloat/257) && worldLayer <= 1 && player.ZoneBeach)
							{
								caughtType = ItemID.SawtoothShark;
								i = 19;
							}
							break;
						case 8:
							if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesScalyTruffle*10000*Math.Min(1, powerFloat/257) && worldLayer == 3 && Main.hardMode && (player.ZoneSnow && (player.ZoneHoly || player.ZoneCorrupt || player.ZoneCrimson)))
							{
								caughtType = ItemID.ScalyTruffle;
								i = 19;
							}
							break;
						case 9:
							if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesZephyrFish*10000*Math.Min(1, powerFloat/257))
							{
								caughtType = ItemID.ZephyrFish;
								i = 19;
							}
							break;
						case 10:
							if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesToxikarp*10000*Math.Min(1, powerFloat/257) && Main.hardMode && player.ZoneCorrupt)
							{
								caughtType = ItemID.Toxikarp;
								i = 19;
							}
							break;
						case 11:
							if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesBladetongue*10000*Math.Min(1, powerFloat/257) && Main.hardMode && player.ZoneCrimson)
							{
								caughtType = ItemID.Bladetongue;
								i = 19;
							}
							break;
						case 12:
							if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesCrystalSerpent*10000*Math.Min(1, powerFloat/257) && Main.hardMode && player.ZoneHoly)
							{
								caughtType = ItemID.CrystalSerpent;
								i = 19;
							}
							break;
						case 13:
							if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesPurpleClubberfish*10000*Math.Min(1, powerFloat/257) && player.ZoneCorrupt)
							{
								caughtType = ItemID.PurpleClubberfish;
								i = 19;
							}
							break;
						case 14:
							if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesRockfish*10000*Math.Min(1, powerFloat/257) && worldLayer >= 2)
							{
								caughtType = ItemID.Rockfish;
								i = 19;
							}
							break;
						case 15:
							if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesFrogLeg*10000*Math.Min(1, powerFloat/257))
							{
								caughtType = ItemID.FrogLeg;
								i = 19;
							}
							break;
						case 16:
							if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesSwordfish*10000*Math.Min(1, powerFloat/257) && worldLayer <= 1 && player.ZoneBeach)
							{
								caughtType = ItemID.Swordfish;
								i = 19;
							}
							break;
						case 17:
							if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesBalloonPufferfish*10000*Math.Min(1, powerFloat/257))
							{
								caughtType = ItemID.BalloonPufferfish;
								i = 19;
							}
							break;
						case 18:
							if (Main.rand.Next(10000)+1 <= Config.FishCatchBecomesFrostDaggerfish*10000*Math.Min(1, powerFloat/257) && player.ZoneSnow)
							{
								caughtType = ItemID.FrostDaggerfish;
								i = 19;
							}
							break;
					}
				}
			}
		}
    }
}