using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;

namespace ReducedGrinding.NPCs
{
	public class VanillaNPCShop : GlobalNPC
    {

		public override void GetChat(NPC npc, ref string chat)
		{
			Player player = Main.player[Main.myPlayer];
			if (npc.type == NPCID.Angler)
				Main.NewText("Quest Completed: " + player.anglerQuestsFinished, 0, 255, 255);
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
			Player player = Main.player[Main.myPlayer];
			Mod luiafk = ModLoader.GetMod("Luiafk");
			Mod thorium = ModLoader.GetMod("ThoriumMod");

			switch (type)
			{
				case NPCID.Merchant:
					if (Config.MerchantSellsSwiftnessPotion)
					{
						shop.item[nextSlot].SetDefaults(ItemID.SwiftnessPotion);
						nextSlot++;
					}
					if (Config.MerchantSellsGoldReflectionMirrorForCraftingGoldCrittersItem)
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("Gold_Reflection_Mirror"));
						nextSlot++;
					}
					if (Config.AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.GreenCap);
						nextSlot++;
					}
					if (Config.MerchantSellsAllMiningGear)
					{
						shop.item[nextSlot].SetDefaults(ItemID.MiningShirt);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.MiningPants);
						nextSlot++;
					}
					if (Config.MerchantSellsFishItem)
					{
						shop.item[nextSlot].SetDefaults(ItemID.Fish);
						nextSlot++;
					}
					if (Config.MerchantSellsPyramidItems && player.ZoneDesert)
					{
						shop.item[nextSlot].SetDefaults(ItemID.FlyingCarpet);
						nextSlot++;
						if (!Config.MerchantSellsSandstormInABottleWhenInDesert)
						{
							shop.item[nextSlot].SetDefaults(ItemID.SandstorminaBottle);
							nextSlot++;
						}
						shop.item[nextSlot].SetDefaults(ItemID.PharaohsMask);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.PharaohsRobe);
						nextSlot++;
					}
					if (Config.MerchantSellsCloudInABottleWhenInSky && player.ZoneSkyHeight)
					{
						shop.item[nextSlot].SetDefaults(ItemID.CloudinaBottle);
						nextSlot++;
					}
					if (Config.MerchantSellsBlizzardInABottleWhenInSnow && player.ZoneSnow)
					{
						shop.item[nextSlot].SetDefaults(ItemID.BlizzardinaBottle);
						nextSlot++;
					}
					if (Config.MerchantSellsSandstormInABottleWhenInDesert && player.ZoneDesert)
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
					if (Config.AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.DyeTradersScimitar);
						nextSlot++;
					}
					break;
				case NPCID.DD2Bartender:
					if (Config.AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.AleThrowingGlove);
						nextSlot++;
					}
					break;
				case NPCID.Stylist:
					if (Config.AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.StylistKilLaKillScissorsIWish);
						nextSlot++;
					}
					break;
				case NPCID.Painter:
					if (Config.AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.PainterPaintballGun);
						nextSlot++;
					}
					break;
				case NPCID.Clothier:
					if (Config.AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.RedHat);
						nextSlot++;
					}
					break;
				case NPCID.TaxCollector:
					if (Config.AllNPCsSellTheirDeathLoot)
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
					if (Config.WitchDoctorSellsSeaweed)
					{
						shop.item[nextSlot].SetDefaults(ItemID.Seaweed);
						nextSlot++;
					}
					if (Config.WitchDoctorSellsFlowerBoots)
					{
						shop.item[nextSlot].SetDefaults(ItemID.FlowerBoots);
						nextSlot++;
					}
					if (Config.WitchDoctorSellsHoneyDispenser)
					{
						shop.item[nextSlot].SetDefaults(ItemID.HoneyDispenser);
						nextSlot++;
					}
					if (Config.WitchDoctorSellsStaffofRegrowth)
					{
						shop.item[nextSlot].SetDefaults(ItemID.StaffofRegrowth);
						nextSlot++;
					}
					if (NPC.downedGolemBoss)
					{
						if (Config.WitchDoctorSellsLihzahrdTrapsAfterGolemDefeated)
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
						if (Config.WitchDoctorSellsWoodenSpikesAfterGolemDefeated)
						{
							shop.item[nextSlot].SetDefaults(ItemID.WoodenSpike);
							nextSlot++;
						}
					}
					if (Config.WitchDoctorSellsThoriumButterfliesWhenThoriumInstalled && (thorium != null))
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("SwallowtailButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults(mod.ItemType("BloodiedButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults(mod.ItemType("FuschiaButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults(mod.ItemType("TempleButterfly"));
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
					if (Config.DryadSellsPlanteraBulbAfterPlanteraDefeated && NPC.downedPlantBoss)
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("Plantera_Bulb"));
						nextSlot++;
					}
					break;
				case NPCID.Mechanic:
					if (Config.MechanicSellsDartTrapAndSpikesAfterSkeletronDefeated && NPC.downedBoss3)
					{
						shop.item[nextSlot].SetDefaults(ItemID.DartTrap);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.Spike);
						nextSlot++;
					}
					if (Config.MechanicSellsGeyserAfterWallofFleshDefeated && Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults(ItemID.GeyserTrap);
						nextSlot++;
					}
					break;
				case NPCID.Wizard:
					if (Config.WizardSellsMoonBall)
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("Moon_Ball"));
						nextSlot++;
					}
					break;
				case NPCID.Pirate:
					if (Config.PirateSellsPirateRetreatOrder)
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("Pirate_Retreat_Order"));
						nextSlot++;
					}
					break;
				case NPCID.GoblinTinkerer:
					if (Config.GoblinTinkererSellsGoblinRetreatOrder)
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("Goblin_Retreat_Order"));
						nextSlot++;
					}
					break;
				case NPCID.TravellingMerchant:
					if (Config.AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.PeddlersHat);
						nextSlot++;
					}
					break;
				case NPCID.PartyGirl:
					if (Config.AllNPCsSellTheirDeathLoot)
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
					if (Config.BoneMerchant && !(luiafk != null && Config.BoneMerchantDisabledWhenLuiafkIsInstalled))
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

					StockingChance = Config.StationaryMerchantStockingChance;
					HMCompletionBonus = Config.S_MerchantStockingChanceBonusWhichWillBeMultipliedByH_ModeCompletionRate;

					bool addItem = false;
					if (Config.TravelingMerchantLifeformAnalyzerIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.LifeformAnalyzer)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantLifeformAnalyzerIncrease && addItem)
						{
							shop[nextSlot] = ItemID.LifeformAnalyzer;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantDPSMeterIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.DPSMeter)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantDPSMeterIncrease && addItem)
						{
							shop[nextSlot] = ItemID.DPSMeter;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantStopwatchIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Stopwatch)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantStopwatchIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Stopwatch;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantMetalDetector > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.MetalDetector)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantMetalDetector && addItem)
						{
							shop[nextSlot] = ItemID.MetalDetector;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantCelestialMagnetIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.CelestialMagnet)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantCelestialMagnetIncrease && addItem)
						{
							shop[nextSlot] = ItemID.CelestialMagnet;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantAmmoBoxIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.AmmoBox)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantAmmoBoxIncrease && addItem)
						{
							shop[nextSlot] = ItemID.AmmoBox;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantPaintSprayerIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintSprayer)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantPaintSprayerIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintSprayer;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantBrickLayerIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.BrickLayer)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantBrickLayerIncrease && addItem)
						{
							shop[nextSlot] = ItemID.BrickLayer;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantPortableCementMixerIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PortableCementMixer)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantPortableCementMixerIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PortableCementMixer;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantExtendoGripIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.ExtendoGrip)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantExtendoGripIncrease && addItem)
						{
							shop[nextSlot] = ItemID.ExtendoGrip;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantGatligatorIncrease > 0 && Main.hardMode)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Gatligator)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantGatligatorIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Gatligator;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantPulseBowIncrease > 0 && Main.hardMode && NPC.downedPlantBoss)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PulseBow)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantPulseBowIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PulseBow;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantSakeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Sake)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantSakeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Sake;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantPhoIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Pho)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantPhoIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Pho;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantPadThaiIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PadThai)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantPadThaiIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PadThai;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantUltraBrightTorchIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.UltrabrightTorch)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantUltraBrightTorchIncrease && addItem)
						{
							shop[nextSlot] = ItemID.UltrabrightTorch;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantMagicHatIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.MagicHat)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantMagicHatIncrease && addItem)
						{
							shop[nextSlot] = ItemID.MagicHat;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantGypsyRobeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.GypsyRobe)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantGypsyRobeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.GypsyRobe;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantGiIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Gi)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantGiIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Gi;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantPresseratorIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.ActuationAccessory)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantPresseratorIncrease && addItem)
						{
							shop[nextSlot] = ItemID.ActuationAccessory;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantYellowCounterweightIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.YellowCounterweight)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantYellowCounterweightIncrease && addItem)
						{
							shop[nextSlot] = ItemID.YellowCounterweight;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantBlackCounterweightIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.BlackCounterweight)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantBlackCounterweightIncrease && addItem)
						{
							shop[nextSlot] = ItemID.BlackCounterweight;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantSittingDucksFishingPoleIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.SittingDucksFishingRod)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantSittingDucksFishingPoleIncrease && addItem)
						{
							shop[nextSlot] = ItemID.SittingDucksFishingRod;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantKatanaIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Katana)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantKatanaIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Katana;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantCode1Increase > 0 && NPC.downedBoss1)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Code1)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantCode1Increase && addItem)
						{
							shop[nextSlot] = ItemID.Code1;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantRevolverIncrease > 0 && WorldGen.shadowOrbSmashed)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Revolver)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantRevolverIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Revolver;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantCode2Increase > 0 && NPC.downedMechBossAny)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Code2)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantCode2Increase && addItem)
						{
							shop[nextSlot] = ItemID.Code2;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantRedTeamBlockIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockRed)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantRedTeamBlockIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockRed;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantRedTeamPlatformIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockRedPlatform)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantRedTeamPlatformIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockRedPlatform;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantYellowTeamBlockIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockYellow)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantYellowTeamBlockIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockYellow;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantYellowTeamPlatformIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockYellowPlatform)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantYellowTeamPlatformIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockYellowPlatform;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantGreenTeamBlockIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockGreen)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantGreenTeamBlockIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockGreen;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantGreenTeamPlatformIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockGreenPlatform)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantGreenTeamPlatformIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockGreenPlatform;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantBlueTeamBlockIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockBlue)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantBlueTeamBlockIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockBlue;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantBlueTeamPlatformIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockBluePlatform)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantBlueTeamPlatformIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockBluePlatform;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantPinkTeamBlockIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockPink)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantPinkTeamBlockIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockPink;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantPinkTeamPlatformIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockPinkPlatform)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantPinkTeamPlatformIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockPinkPlatform;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantWhiteTeamBlockIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockWhite)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantWhiteTeamBlockIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockWhite;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantWhiteTeamPlatformIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockWhitePlatform)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantWhiteTeamPlatformIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockWhitePlatform;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantDiamondRingIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.DiamondRing)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantDiamondRingIncrease && addItem)
						{
							shop[nextSlot] = ItemID.DiamondRing;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantAngelHaloIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.AngelHalo)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantAngelHaloIncrease && addItem)
						{
							shop[nextSlot] = ItemID.AngelHalo;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantFezIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Fez)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantFezIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Fez;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantWinterCapeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.WinterCape)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantWinterCapeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.WinterCape;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantRedCapeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.RedCape)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantRedCapeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.RedCape;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantCrimsonCapeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.CrimsonCloak)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantCrimsonCapeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.CrimsonCloak;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantMysteriousCapeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.MysteriousCape)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantMysteriousCapeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.MysteriousCape;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantKimonoIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Kimono)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantKimonoIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Kimono;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantWaterGunIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.WaterGun)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantWaterGunIncrease && addItem)
						{
							shop[nextSlot] = ItemID.WaterGun;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantCompanionCubeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.CompanionCube)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantCompanionCubeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.CompanionCube;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantChaliceIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.SteampunkCup)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantChaliceIncrease && addItem)
						{
							shop[nextSlot] = ItemID.SteampunkCup;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantArcaneRuneWallIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.ArcaneRuneWall)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantArcaneRuneWallIncrease && addItem)
						{
							shop[nextSlot] = ItemID.ArcaneRuneWall;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantFancyDishesIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.FancyDishes)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantFancyDishesIncrease && addItem)
						{
							shop[nextSlot] = ItemID.FancyDishes;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantDynastyWoodIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.DynastyWood)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantDynastyWoodIncrease && addItem)
						{
							shop[nextSlot] = ItemID.DynastyWood;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantRedDynastyShinglesIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.RedDynastyShingles)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantRedDynastyShinglesIncrease && addItem)
						{
							shop[nextSlot] = ItemID.RedDynastyShingles;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantBlueDynastyShinglesIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.BlueDynastyShingles)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantBlueDynastyShinglesIncrease && addItem)
						{
							shop[nextSlot] = ItemID.BlueDynastyShingles;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantZebraSkinIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.ZebraSkin)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantZebraSkinIncrease && addItem)
						{
							shop[nextSlot] = ItemID.ZebraSkin;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantLeopardSkinIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.LeopardSkin)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantLeopardSkinIncrease && addItem)
						{
							shop[nextSlot] = ItemID.LeopardSkin;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantTigerSkinIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TigerSkin)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantTigerSkinIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TigerSkin;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantCastleMarsbergIncrease > 0 && NPC.downedMartians)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingCastleMarsberg)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantCastleMarsbergIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingCastleMarsberg;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantMartiaLisaIncrease > 0 && NPC.downedMartians)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingMartiaLisa)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantMartiaLisaIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingMartiaLisa;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantTheTruthIsUpThereIncrease > 0 && NPC.downedMartians)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingTheTruthIsUpThere)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantTheTruthIsUpThereIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingTheTruthIsUpThere;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantNotAKidNorASquidIncrease > 0 && NPC.downedMoonlord)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.MoonLordPainting)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantNotAKidNorASquidIncrease && addItem)
						{
							shop[nextSlot] = ItemID.MoonLordPainting;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantAcornsIncrease > 0 && (Config.TravelingMerchantAlwaysXMasForConfigurations || Main.xMas))
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingAcorns)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantAcornsIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingAcorns;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantColdSnapIncrease > 0 && (Config.TravelingMerchantAlwaysXMasForConfigurations || Main.xMas))
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingColdSnap)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantColdSnapIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingColdSnap;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantCursedSaintIncrease > 0 && (Config.TravelingMerchantAlwaysXMasForConfigurations || Main.xMas))
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingCursedSaint)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantCursedSaintIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingCursedSaint;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantSnowfellasIncrease > 0 && (Config.TravelingMerchantAlwaysXMasForConfigurations || Main.xMas))
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingSnowfellas)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantSnowfellasIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingSnowfellas;
							nextSlot++;
						}
					}
					if (Config.TravelingMerchantTheSeasonIncrease > 0 && (Config.TravelingMerchantAlwaysXMasForConfigurations || Main.xMas))
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingTheSeason)
								addItem = false;
						}
						if (Main.rand.NextFloat() < Config.TravelingMerchantTheSeasonIncrease && addItem)
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