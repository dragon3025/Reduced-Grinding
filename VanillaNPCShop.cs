using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace ReducedGrinding.NPCs
{
	public class VanillaNPCShop : GlobalNPC
    {
		
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
			Player player = Main.player[Main.myPlayer];
			ReducedGrindingPlayer mPlayer = player.GetModPlayer<ReducedGrindingPlayer>(mod);
			Mod luiafk = ModLoader.GetMod("Luiafk"); //Prevent adding items that Luiafk already adds

			switch (type)
			{
				case NPCID.Merchant:
					if (mPlayer.clientConf.AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.GreenCap);
						nextSlot++;
					}
					if (mPlayer.clientConf.MerchantSellsAllMiningGear)
					{
						shop.item[nextSlot].SetDefaults(ItemID.MiningShirt);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.MiningPants);
						nextSlot++;
					}
					if (mPlayer.clientConf.MerchantSellsFishItem)
					{
						shop.item[nextSlot].SetDefaults(ItemID.Fish);
						nextSlot++;
					}
					if (mPlayer.clientConf.MerchantSellsPyramidItems && player.ZoneDesert)
					{
						shop.item[nextSlot].SetDefaults(ItemID.FlyingCarpet);
						nextSlot++;
						if (!mPlayer.clientConf.MerchantSellsSandstormInABottleWhenInDesert)
						{
							shop.item[nextSlot].SetDefaults(ItemID.SandstorminaBottle);
							nextSlot++;
						}
						shop.item[nextSlot].SetDefaults(ItemID.PharaohsMask);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.PharaohsRobe);
						nextSlot++;
					}
					if (mPlayer.clientConf.MerchantSellsCloudInABottleWhenInSky && player.ZoneSkyHeight)
					{
						shop.item[nextSlot].SetDefaults(ItemID.CloudinaBottle);
						nextSlot++;
					}
					if (mPlayer.clientConf.MerchantSellsBlizzardInABottleWhenInSnow && player.ZoneSnow)
					{
						shop.item[nextSlot].SetDefaults(ItemID.BlizzardinaBottle);
						nextSlot++;
					}
					if (mPlayer.clientConf.MerchantSellsSandstormInABottleWhenInDesert && player.ZoneDesert)
					{
						shop.item[nextSlot].SetDefaults(ItemID.SandstorminaBottle);
						nextSlot++;
					}
					if (Main.netMode == NetmodeID.SinglePlayer) //Singleplayer
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("Expert_Change_Potion"));
						nextSlot++;
					}
					break;
				case NPCID.DyeTrader:
					if (mPlayer.clientConf.AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.DyeTradersScimitar);
						nextSlot++;
					}
					break;
				case NPCID.DD2Bartender:
					if (mPlayer.clientConf.AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.AleThrowingGlove);
						nextSlot++;
					}
					break;
				case NPCID.Stylist:
					if (mPlayer.clientConf.AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.StylistKilLaKillScissorsIWish);
						nextSlot++;
					}
					break;
				case NPCID.Painter:
					if (mPlayer.clientConf.AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.PainterPaintballGun);
						nextSlot++;
					}
					break;
				case NPCID.Clothier:
					if (mPlayer.clientConf.AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.RedHat);
						nextSlot++;
					}
					break;
				case NPCID.TaxCollector:
					if (mPlayer.clientConf.AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.TaxCollectorsStickOfDoom);
						nextSlot++;
					}
					break;
				case NPCID.Steampunker:
					if (luiafk == null)
					{
						if (WorldGen.crimson)
						{
							if (Main.bloodMoon || Main.eclipse)
							{
								shop.item[nextSlot].SetDefaults(ItemID.PurpleSolution);
								nextSlot++;
							}
						}
						else
						{
							if (Main.bloodMoon || Main.eclipse)
							{
								shop.item[nextSlot].SetDefaults(ItemID.RedSolution);
								nextSlot++;
							}
							if (luiafk == null)
							{
								shop.item[nextSlot].SetDefaults(2193); //Flesh Cloning Vat
								nextSlot++;
							}
						}
					}
					break;
				case NPCID.WitchDoctor:
					if (mPlayer.clientConf.WitchDoctorSellsSeaweed)
					{
						shop.item[nextSlot].SetDefaults(ItemID.Seaweed);
						nextSlot++;
					}
					if (mPlayer.clientConf.WitchDoctorSellsFlowerBoots)
					{
						shop.item[nextSlot].SetDefaults(ItemID.FlowerBoots);
						nextSlot++;
					}
					if (mPlayer.clientConf.WitchDoctorSellsHoneyDispenser)
					{
						shop.item[nextSlot].SetDefaults(ItemID.HoneyDispenser);
						nextSlot++;
					}
					if (mPlayer.clientConf.WitchDoctorSellsStaffofRegrowth)
					{
						shop.item[nextSlot].SetDefaults(ItemID.StaffofRegrowth);
						nextSlot++;
					}
					break;
				case NPCID.Dryad:
					if (luiafk == null)
					{
						if (WorldGen.crimson)
						{
							if (Main.bloodMoon || player.ZoneCorrupt)
							{
								shop.item[nextSlot].SetDefaults(ItemID.CorruptSeeds);
								nextSlot++;
								shop.item[nextSlot].SetDefaults(ItemID.VilePowder);
								nextSlot++;
							}
							if (NPC.downedBoss2) //Brain of Cthulhu or Eater of Worlds
								shop.item[nextSlot].SetDefaults(ItemID.CorruptPlanterBox);
						}
						else
						{
							if (Main.bloodMoon || player.ZoneCrimson)
							{
								shop.item[nextSlot].SetDefaults(ItemID.CrimsonSeeds);
								nextSlot++;
								shop.item[nextSlot].SetDefaults(ItemID.ViciousPowder);
								nextSlot++;
							}
							if (NPC.downedBoss2) //Brain of Cthulhu or Eater of Worlds
								shop.item[nextSlot].SetDefaults(ItemID.CrimsonPlanterBox);
						}
					}
					break;
				case NPCID.Mechanic:
					if (mPlayer.clientConf.MechanicSellsDartTrapAfterSkeletronDefeated && NPC.downedBoss3)
					{
						shop.item[nextSlot].SetDefaults(ItemID.DartTrap);
						nextSlot++;
					}
					if (mPlayer.clientConf.MechanicSellsGeyserAfterWallofFleshDefeated && Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults(ItemID.GeyserTrap);
						nextSlot++;
					}
					if (NPC.downedGolemBoss)
					{
						if (mPlayer.clientConf.MechanicSellsLihzahrdTrapsAfterGolemDefeated)
						{
							shop.item[nextSlot].SetDefaults(ItemID.FlameTrap);
							nextSlot++;
							shop.item[nextSlot].SetDefaults(ItemID.SpearTrap);
							nextSlot++;
							shop.item[nextSlot].SetDefaults(ItemID.SpikyBallTrap);
							nextSlot++;
							shop.item[nextSlot].SetDefaults(ItemID.SuperDartTrap);
							nextSlot++;
						}
						if (mPlayer.clientConf.MechanicSellsWoodenSpikesAfterGolemDefeated)
						{
							shop.item[nextSlot].SetDefaults(ItemID.WoodenSpike);
							nextSlot++;
						}
					}
					break;
				case NPCID.Wizard:
					if (mPlayer.clientConf.WizardSellsMoonBall)
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("Moon_Ball"));
						nextSlot++;
					}
					break;
				case NPCID.Pirate:
					if (mPlayer.clientConf.PirateSellsPirateRetreatOrder)
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("Pirate_Retreat_Order"));
						nextSlot++;
					}
					break;
				case NPCID.GoblinTinkerer:
					if (mPlayer.clientConf.GoblinTinkererSellsGoblinRetreatOrder)
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("Goblin_Retreat_Order"));
						nextSlot++;
					}
					break;
				case NPCID.TravellingMerchant:
					if (mPlayer.clientConf.AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.PeddlersHat);
						nextSlot++;
					}
					break;
				case NPCID.PartyGirl:
					if (mPlayer.clientConf.AllNPCsSellTheirDeathLoot)
					{
						bool hasPartyGrenade = false;
						for (int i = 0; i < shop.item.Length; i++)
						{
							if (shop.item[i].type == ItemID.PartyGirlGrenade)
							{
								hasPartyGrenade = true;
								break;
							}
						}
						if (!hasPartyGrenade)
						{
							shop.item[nextSlot].SetDefaults(ItemID.PartyGirlGrenade);
							nextSlot++;
						}
					}
					break;
				case NPCID.SkeletonMerchant:
					if (mPlayer.clientConf.BoneMerchant && !(luiafk != null && mPlayer.clientConf.BoneMerchantDisabledWhenLuiafkIsInstalled))
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("Skull_Call"));
						nextSlot++;
					}
					break;
			}
        }
		
		public override void SetupTravelShop(int[] shop, ref int nextSlot)
		{
			bool travelingMerchantExists = false; //This is done when Luiafk is installed, because it causes restocks to happen even when the vanilla traveling merchant isn't there.
			for (int i = 0; i < Terraria.Main.npc.Length; i++)
			{
				if (Terraria.Main.npc[i].type == NPCID.TravellingMerchant)
				{
					travelingMerchantExists = true;
					break;
				}
			}
			if (travelingMerchantExists)
			{
				float StockingChance = Config.StationaryMerchantStockingChance;
				float HMCompletionBonus = Config.S_MerchantStockingChanceBonusWhichWillBeMultipliedByH_ModeCompletionRate;

				if (Main.netMode == NetmodeID.SinglePlayer) //I can't get this to run in a server, I get errors instead.
				{
					Player player = Main.player[Main.myPlayer];
					ReducedGrindingPlayer mPlayer = player.GetModPlayer<ReducedGrindingPlayer>(mod);

					StockingChance = mPlayer.clientConf.StationaryMerchantStockingChance;
					HMCompletionBonus = mPlayer.clientConf.S_MerchantStockingChanceBonusWhichWillBeMultipliedByH_ModeCompletionRate;

					bool addItem = false;
					if (mPlayer.clientConf.TravelingMerchantLifeformAnalyzerIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.LifeformAnalyzer)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantLifeformAnalyzerIncrease && addItem)
						{
							shop[nextSlot] = ItemID.LifeformAnalyzer;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantDPSMeterIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.DPSMeter)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantDPSMeterIncrease && addItem)
						{
							shop[nextSlot] = ItemID.DPSMeter;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantStopwatchIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Stopwatch)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantStopwatchIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Stopwatch;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantMetalDetector > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.MetalDetector)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantMetalDetector && addItem)
						{
							shop[nextSlot] = ItemID.MetalDetector;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantCelestialMagnetIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.CelestialMagnet)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantCelestialMagnetIncrease && addItem)
						{
							shop[nextSlot] = ItemID.CelestialMagnet;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantAmmoBoxIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.AmmoBox)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantAmmoBoxIncrease && addItem)
						{
							shop[nextSlot] = ItemID.AmmoBox;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantPaintSprayerIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintSprayer)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantPaintSprayerIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintSprayer;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantBrickLayerIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.BrickLayer)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantBrickLayerIncrease && addItem)
						{
							shop[nextSlot] = ItemID.BrickLayer;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantPortableCementMixerIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PortableCementMixer)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantPortableCementMixerIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PortableCementMixer;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantExtendoGripIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.ExtendoGrip)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantExtendoGripIncrease && addItem)
						{
							shop[nextSlot] = ItemID.ExtendoGrip;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantGatligatorIncrease > 0 && Main.hardMode)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Gatligator)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantGatligatorIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Gatligator;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantPulseBowIncrease > 0 && Main.hardMode && NPC.downedPlantBoss)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PulseBow)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantPulseBowIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PulseBow;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantSakeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Sake)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantSakeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Sake;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantPhoIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Pho)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantPhoIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Pho;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantPadThaiIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PadThai)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantPadThaiIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PadThai;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantUltraBrightTorchIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.UltrabrightTorch)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantUltraBrightTorchIncrease && addItem)
						{
							shop[nextSlot] = ItemID.UltrabrightTorch;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantMagicHatIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.MagicHat)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantMagicHatIncrease && addItem)
						{
							shop[nextSlot] = ItemID.MagicHat;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantGypsyRobeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.GypsyRobe)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantGypsyRobeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.GypsyRobe;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantGiIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Gi)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantGiIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Gi;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantPresseratorIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.ActuationAccessory)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantPresseratorIncrease && addItem)
						{
							shop[nextSlot] = ItemID.ActuationAccessory;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantYellowCounterweightIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.YellowCounterweight)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantYellowCounterweightIncrease && addItem)
						{
							shop[nextSlot] = ItemID.YellowCounterweight;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantBlackCounterweightIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.BlackCounterweight)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantBlackCounterweightIncrease && addItem)
						{
							shop[nextSlot] = ItemID.BlackCounterweight;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantSittingDucksFishingPoleIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.SittingDucksFishingRod)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantSittingDucksFishingPoleIncrease && addItem)
						{
							shop[nextSlot] = ItemID.SittingDucksFishingRod;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantKatanaIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Katana)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantKatanaIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Katana;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantCode1Increase > 0 && NPC.downedBoss1)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Code1)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantCode1Increase && addItem)
						{
							shop[nextSlot] = ItemID.Code1;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantRevolverIncrease > 0 && WorldGen.shadowOrbSmashed)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Revolver)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantRevolverIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Revolver;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantCode2Increase > 0 && NPC.downedMechBossAny)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Code2)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantCode2Increase && addItem)
						{
							shop[nextSlot] = ItemID.Code2;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantRedTeamBlockIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockRed)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantRedTeamBlockIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockRed;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantRedTeamPlatformIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockRedPlatform)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantRedTeamPlatformIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockRedPlatform;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantYellowTeamBlockIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockYellow)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantYellowTeamBlockIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockYellow;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantYellowTeamPlatformIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockYellowPlatform)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantYellowTeamPlatformIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockYellowPlatform;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantGreenTeamBlockIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockGreen)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantGreenTeamBlockIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockGreen;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantGreenTeamPlatformIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockGreenPlatform)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantGreenTeamPlatformIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockGreenPlatform;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantBlueTeamBlockIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockBlue)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantBlueTeamBlockIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockBlue;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantBlueTeamPlatformIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockBluePlatform)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantBlueTeamPlatformIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockBluePlatform;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantPinkTeamBlockIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockPink)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantPinkTeamBlockIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockPink;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantPinkTeamPlatformIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockPinkPlatform)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantPinkTeamPlatformIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockPinkPlatform;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantWhiteTeamBlockIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockWhite)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantWhiteTeamBlockIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockWhite;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantWhiteTeamPlatformIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockWhitePlatform)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantWhiteTeamPlatformIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockWhitePlatform;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantDiamondRingIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.DiamondRing)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantDiamondRingIncrease && addItem)
						{
							shop[nextSlot] = ItemID.DiamondRing;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantAngelHaloIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.AngelHalo)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantAngelHaloIncrease && addItem)
						{
							shop[nextSlot] = ItemID.AngelHalo;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantFezIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Fez)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantFezIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Fez;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantWinterCapeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.WinterCape)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantWinterCapeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.WinterCape;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantRedCapeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.RedCape)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantRedCapeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.RedCape;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantCrimsonCapeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.CrimsonCloak)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantCrimsonCapeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.CrimsonCloak;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantMysteriousCapeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.MysteriousCape)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantMysteriousCapeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.MysteriousCape;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantKimonoIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Kimono)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantKimonoIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Kimono;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantWaterGunIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.WaterGun)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantWaterGunIncrease && addItem)
						{
							shop[nextSlot] = ItemID.WaterGun;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantCompanionCubeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.CompanionCube)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantCompanionCubeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.CompanionCube;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantChaliceIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.SteampunkCup)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantChaliceIncrease && addItem)
						{
							shop[nextSlot] = ItemID.SteampunkCup;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantArcaneRuneWallIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.ArcaneRuneWall)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantArcaneRuneWallIncrease && addItem)
						{
							shop[nextSlot] = ItemID.ArcaneRuneWall;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantFancyDishesIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.FancyDishes)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantFancyDishesIncrease && addItem)
						{
							shop[nextSlot] = ItemID.FancyDishes;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantDynastyWoodIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.DynastyWood)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantDynastyWoodIncrease && addItem)
						{
							shop[nextSlot] = ItemID.DynastyWood;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantRedDynastyShinglesIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.RedDynastyShingles)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantRedDynastyShinglesIncrease && addItem)
						{
							shop[nextSlot] = ItemID.RedDynastyShingles;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantBlueDynastyShinglesIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.BlueDynastyShingles)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantBlueDynastyShinglesIncrease && addItem)
						{
							shop[nextSlot] = ItemID.BlueDynastyShingles;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantZebraSkinIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.ZebraSkin)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantZebraSkinIncrease && addItem)
						{
							shop[nextSlot] = ItemID.ZebraSkin;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantLeopardSkinIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.LeopardSkin)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantLeopardSkinIncrease && addItem)
						{
							shop[nextSlot] = ItemID.LeopardSkin;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantTigerSkinIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TigerSkin)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantTigerSkinIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TigerSkin;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantCastleMarsbergIncrease > 0 && NPC.downedMartians)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingCastleMarsberg)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantCastleMarsbergIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingCastleMarsberg;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantMartiaLisaIncrease > 0 && NPC.downedMartians)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingMartiaLisa)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantMartiaLisaIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingMartiaLisa;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantTheTruthIsUpThereIncrease > 0 && NPC.downedMartians)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingTheTruthIsUpThere)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantTheTruthIsUpThereIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingTheTruthIsUpThere;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantNotAKidNorASquidIncrease > 0 && NPC.downedMoonlord)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.MoonLordPainting)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantNotAKidNorASquidIncrease && addItem)
						{
							shop[nextSlot] = ItemID.MoonLordPainting;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantAcornsIncrease > 0 && (mPlayer.clientConf.TravelingMerchantAlwaysXMasForConfigurations || Main.xMas))
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingAcorns)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantAcornsIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingAcorns;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantColdSnapIncrease > 0 && (mPlayer.clientConf.TravelingMerchantAlwaysXMasForConfigurations || Main.xMas))
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingColdSnap)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantColdSnapIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingColdSnap;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantCursedSaintIncrease > 0 && (mPlayer.clientConf.TravelingMerchantAlwaysXMasForConfigurations || Main.xMas))
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingCursedSaint)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantCursedSaintIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingCursedSaint;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantSnowfellasIncrease > 0 && (mPlayer.clientConf.TravelingMerchantAlwaysXMasForConfigurations || Main.xMas))
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingSnowfellas)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantSnowfellasIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingSnowfellas;
							nextSlot++;
						}
					}
					if (mPlayer.clientConf.TravelingMerchantTheSeasonIncrease > 0 && (mPlayer.clientConf.TravelingMerchantAlwaysXMasForConfigurations || Main.xMas))
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingTheSeason)
								addItem = false;
						}
						if (Main.rand.NextFloat() < mPlayer.clientConf.TravelingMerchantTheSeasonIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingTheSeason;
							nextSlot++;
						}
					}
				}
				int newGoods = 0;
				int PreHardmodeCompletion = 0;
				if (Main.hardMode)
					PreHardmodeCompletion = 6;
				else
				{
					if (NPC.downedSlimeKing)
						PreHardmodeCompletion++;
					if (NPC.downedBoss1)
						PreHardmodeCompletion++;
					if (NPC.downedBoss2)
						PreHardmodeCompletion++;
					if (NPC.downedBoss3)
						PreHardmodeCompletion++;
					if (NPC.downedQueenBee)
						PreHardmodeCompletion++;
				}
				StockingChance += (HMCompletionBonus * PreHardmodeCompletion / 6);
				for (int i = 0; i < shop.Length; i++)
				{
					if (shop[i] != 0 && Main.rand.NextFloat() < StockingChance)
					{
						switch (shop[i])
						{
							//Items
							case ItemID.Sake:
								if (ReducedGrindingWorld.smItemSake == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemSake = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.Pho:
								if (ReducedGrindingWorld.smItemPho == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemPho = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.PadThai:
								if (ReducedGrindingWorld.smItemPadThai == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemPadThai = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.UltrabrightTorch:
								if (ReducedGrindingWorld.smItemUltrabrightTorch == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemUltrabrightTorch = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.AmmoBox:
								if (ReducedGrindingWorld.smItemAmmoBox == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemAmmoBox = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.MagicHat:
								if (ReducedGrindingWorld.smItemMagicHat == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemMagicHat = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.GypsyRobe:
								if (ReducedGrindingWorld.smItemGypsyRobe == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemGypsyRobe = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.Gi:
								if (ReducedGrindingWorld.smItemGi == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemGi = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.CelestialMagnet:
								if (ReducedGrindingWorld.smItemCelestialMagnet == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemCelestialMagnet = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.DPSMeter:
								if (ReducedGrindingWorld.smItemDPSMeter == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemDPSMeter = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.LifeformAnalyzer:
								if (ReducedGrindingWorld.smItemLifeformAnalyzer == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemLifeformAnalyzer = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.Stopwatch:
								if (ReducedGrindingWorld.smItemStopwatch == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemStopwatch = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.PaintSprayer:
								if (ReducedGrindingWorld.smItemPaintSprayer == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemPaintSprayer = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.BrickLayer:
								if (ReducedGrindingWorld.smItemBrickLayer == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemBrickLayer = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.PortableCementMixer:
								if (ReducedGrindingWorld.smItemPortableCementMixer == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemPortableCementMixer = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.ExtendoGrip:
								if (ReducedGrindingWorld.smItemExtendoGrip == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemExtendoGrip = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.ActuationAccessory:
								if (ReducedGrindingWorld.smItemPresserator == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemPresserator = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.BlackCounterweight:
								if (ReducedGrindingWorld.smItemBlackCounterweight == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemBlackCounterweight = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.YellowCounterweight:
								if (ReducedGrindingWorld.smItemYellowCounterweight == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemYellowCounterweight = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.SittingDucksFishingRod:
								if (ReducedGrindingWorld.smItemSittingDucksFishingPole == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemSittingDucksFishingPole = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.Katana:
								if (ReducedGrindingWorld.smItemKatana == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemKatana = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.Code1:
								if (ReducedGrindingWorld.smItemCode1 == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemCode1 = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.Revolver:
								if (ReducedGrindingWorld.smItemRevolver == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemRevolver = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.Gatligator:
								if (ReducedGrindingWorld.smItemGatligator == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemGatligator = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.Code2:
								if (ReducedGrindingWorld.smItemCode2 == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemCode2 = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.PulseBow:
								if (ReducedGrindingWorld.smItemPulseBow == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemPulseBow = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.DiamondRing:
								if (ReducedGrindingWorld.smItemDiamondRing == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemDiamondRing = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.AngelHalo:
								if (ReducedGrindingWorld.smItemAngelHalo == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemAngelHalo = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.Fez:
								if (ReducedGrindingWorld.smItemFez == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemFez = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.WinterCape:
								if (ReducedGrindingWorld.smItemWinterCape == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemWinterCape = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.RedCape:
								if (ReducedGrindingWorld.smItemRedCape == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemRedCape = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.CrimsonCloak:
								if (ReducedGrindingWorld.smItemCrimsonCloak == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemCrimsonCloak = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.MysteriousCape:
								if (ReducedGrindingWorld.smItemMysteriousCape == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemMysteriousCape = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.Kimono:
								if (ReducedGrindingWorld.smItemKimono == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemKimono = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.WaterGun:
								if (ReducedGrindingWorld.smItemWaterGun == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemWaterGun = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							case ItemID.CompanionCube:
								if (ReducedGrindingWorld.smItemCompanionCube == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemCompanionCube = true;
									ReducedGrindingWorld.smItemDecorShopNotEmpty = true;
								}
								break;
							//Decor Items
							case ItemID.TeamBlockRed:
								if (ReducedGrindingWorld.smItemRedTeamBlock == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemRedTeamBlock = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.TeamBlockYellow:
								if (ReducedGrindingWorld.smItemYellowTeamBlock == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemYellowTeamBlock = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.TeamBlockGreen:
								if (ReducedGrindingWorld.smItemGreenTeamBlock == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemGreenTeamBlock = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.TeamBlockBlue:
								if (ReducedGrindingWorld.smItemBlueTeamBlock == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemBlueTeamBlock = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.TeamBlockPink:
								if (ReducedGrindingWorld.smItemPinkTeamBlock == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemPinkTeamBlock = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.TeamBlockWhite:
								if (ReducedGrindingWorld.smItemWhiteTeamBlock == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemWhiteTeamBlock = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.SteampunkCup:
								if (ReducedGrindingWorld.smItemChalice == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemChalice = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.ArcaneRuneWall:
								if (ReducedGrindingWorld.smItemArcaneRuneWall == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemArcaneRuneWall = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.FancyDishes:
								if (ReducedGrindingWorld.smItemFancyDishes == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemFancyDishes = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.DynastyWood:
								if (ReducedGrindingWorld.smItemDynastyWood == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemDynastyWood = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.ZebraSkin:
								if (ReducedGrindingWorld.smItemZebraSkin == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemZebraSkin = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.LeopardSkin:
								if (ReducedGrindingWorld.smItemLeopardSkin == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemLeopardSkin = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.TigerSkin:
								if (ReducedGrindingWorld.smItemTigerSkin == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemTigerSkin = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.PaintingCastleMarsberg:
								if (ReducedGrindingWorld.smItemCastleMarsberg == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemCastleMarsberg = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.PaintingMartiaLisa:
								if (ReducedGrindingWorld.smItemMartiaLisa == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemMartiaLisa = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.PaintingTheTruthIsUpThere:
								if (ReducedGrindingWorld.smItemTheTruthIsUpThere == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemTheTruthIsUpThere = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.MoonLordPainting:
								if (ReducedGrindingWorld.smItemNotAKidNorASquid == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemNotAKidNorASquid = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.PaintingAcorns:
								if (ReducedGrindingWorld.smItemAcorns == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemAcorns = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.PaintingColdSnap:
								if (ReducedGrindingWorld.smItemColdSnap == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemColdSnap = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.PaintingCursedSaint:
								if (ReducedGrindingWorld.smItemCursedSaint == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemCursedSaint = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.PaintingSnowfellas:
								if (ReducedGrindingWorld.smItemSnowfellas == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemSnowfellas = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
							case ItemID.PaintingTheSeason:
								if (ReducedGrindingWorld.smItemTheSeason == false)
								{
									newGoods++;
									ReducedGrindingWorld.smItemTheSeason = true;
									ReducedGrindingWorld.smItemShopNotEmpty = true;
								}
								break;
						}
					}
				}
				if (newGoods > 0)
				{
					if (newGoods > 1)
					{
						if (Main.netMode == NetmodeID.Server)
							NetMessage.BroadcastChatMessage(NetworkText.FromKey("The stationary merchant has "+ newGoods.ToString()+" new items in his shop."), new Color(191, 255, 0));
						else if (Main.netMode == NetmodeID.SinglePlayer) // Single Player
							Main.NewText("The stationary merchant has new items in his shop.", 191, 255, 0);
					}
					else
					{
						if (Main.netMode == NetmodeID.Server)
							NetMessage.BroadcastChatMessage(NetworkText.FromKey("The stationary merchant a new item in his shop."), new Color(191, 255, 0));
						else if (Main.netMode == NetmodeID.SinglePlayer) // Single Player
							Main.NewText("The stationary merchant a new item in his shop.", 191, 255, 0);
					}
				}
				if (Main.netMode == NetmodeID.Server)
				{
					NetMessage.SendData(MessageID.WorldData);
				}
			}
		}
    }
}