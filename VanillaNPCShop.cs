using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

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

			switch (type)
			{
				case NPCID.Merchant:
					if (GetInstance<FOtherVanillaNPCConfig>().MerchantSellsSwiftnessPotion)
					{
						shop.item[nextSlot].SetDefaults(ItemID.SwiftnessPotion);
						nextSlot++;
					}
					if (GetInstance<HOtherModdedItemsConfig>().MerchantSellsGoldReflectionMirrorForCraftingGoldCrittersItem)
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("Gold_Reflection_Mirror"));
						nextSlot++;
					}
					if (GetInstance<FOtherVanillaNPCConfig>().AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.GreenCap);
						nextSlot++;
					}
					if (GetInstance<FOtherVanillaNPCConfig>().MerchantSellsAllMiningGear)
					{
						shop.item[nextSlot].SetDefaults(ItemID.MiningShirt);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.MiningPants);
						nextSlot++;
					}
					if (GetInstance<FOtherVanillaNPCConfig>().MerchantSellsFishItem)
					{
						shop.item[nextSlot].SetDefaults(ItemID.Fish);
						nextSlot++;
					}
					if (GetInstance<FOtherVanillaNPCConfig>().MerchantSellsPyramidItems && player.ZoneDesert)
					{
						shop.item[nextSlot].SetDefaults(ItemID.FlyingCarpet);
						nextSlot++;
						if (!GetInstance<FOtherVanillaNPCConfig>().MerchantSellsSandstormInABottleWhenInDesert)
						{
							shop.item[nextSlot].SetDefaults(ItemID.SandstorminaBottle);
							nextSlot++;
						}
						shop.item[nextSlot].SetDefaults(ItemID.PharaohsMask);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.PharaohsRobe);
						nextSlot++;
					}
					if (GetInstance<FOtherVanillaNPCConfig>().MerchantSellsCloudInABottleWhenInSky && player.ZoneSkyHeight)
					{
						shop.item[nextSlot].SetDefaults(ItemID.CloudinaBottle);
						nextSlot++;
					}
					if (GetInstance<FOtherVanillaNPCConfig>().MerchantSellsBlizzardInABottleWhenInSnow && player.ZoneSnow)
					{
						shop.item[nextSlot].SetDefaults(ItemID.BlizzardinaBottle);
						nextSlot++;
					}
					if (GetInstance<FOtherVanillaNPCConfig>().MerchantSellsSandstormInABottleWhenInDesert && player.ZoneDesert)
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
					if (GetInstance<FOtherVanillaNPCConfig>().AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.DyeTradersScimitar);
						nextSlot++;
					}
					break;
				case NPCID.DD2Bartender:
					if (GetInstance<FOtherVanillaNPCConfig>().AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.AleThrowingGlove);
						nextSlot++;
					}
					break;
				case NPCID.Stylist:
					if (GetInstance<FOtherVanillaNPCConfig>().AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.StylistKilLaKillScissorsIWish);
						nextSlot++;
					}
					break;
				case NPCID.Painter:
					if (GetInstance<FOtherVanillaNPCConfig>().AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.PainterPaintballGun);
						nextSlot++;
					}
					break;
				case NPCID.Clothier:
					if (GetInstance<FOtherVanillaNPCConfig>().AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.RedHat);
						nextSlot++;
					}
					break;
				case NPCID.TaxCollector:
					if (GetInstance<FOtherVanillaNPCConfig>().AllNPCsSellTheirDeathLoot)
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
					if (GetInstance<FOtherVanillaNPCConfig>().WitchDoctorSellsSeaweed)
					{
						shop.item[nextSlot].SetDefaults(ItemID.Seaweed);
						nextSlot++;
					}
					if (GetInstance<FOtherVanillaNPCConfig>().WitchDoctorSellsFlowerBoots)
					{
						shop.item[nextSlot].SetDefaults(ItemID.FlowerBoots);
						nextSlot++;
					}
					if (GetInstance<FOtherVanillaNPCConfig>().WitchDoctorSellsHoneyDispenser)
					{
						shop.item[nextSlot].SetDefaults(ItemID.HoneyDispenser);
						nextSlot++;
					}
					if (GetInstance<FOtherVanillaNPCConfig>().WitchDoctorSellsStaffofRegrowth)
					{
						shop.item[nextSlot].SetDefaults(ItemID.StaffofRegrowth);
						nextSlot++;
					}
					if (NPC.downedGolemBoss)
					{
						if (GetInstance<FOtherVanillaNPCConfig>().WitchDoctorSellsLihzahrdTrapsAfterGolemDefeated)
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
						if (GetInstance<FOtherVanillaNPCConfig>().WitchDoctorSellsWoodenSpikesAfterGolemDefeated)
						{
							shop.item[nextSlot].SetDefaults(ItemID.WoodenSpike);
							nextSlot++;
						}
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
					if (GetInstance<HOtherModdedItemsConfig>().DryadSellsPlanteraBulbAfterPlanteraDefeated && NPC.downedPlantBoss)
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("Plantera_Bulb"));
						nextSlot++;
					}
					break;
				case NPCID.Mechanic:
					if (GetInstance<FOtherVanillaNPCConfig>().MechanicSellsDartTrapAndSpikesAfterSkeletronDefeated && NPC.downedBoss3)
					{
						shop.item[nextSlot].SetDefaults(ItemID.DartTrap);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.Spike);
						nextSlot++;
					}
					if (GetInstance<FOtherVanillaNPCConfig>().MechanicSellsGeyserAfterWallofFleshDefeated && Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults(ItemID.GeyserTrap);
						nextSlot++;
					}
					break;
				case NPCID.Wizard:
					if (GetInstance<HOtherModdedItemsConfig>().WizardSellsMoonBall)
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("Moon_Ball"));
						nextSlot++;
					}
					break;
				case NPCID.Pirate:
					if (GetInstance<HOtherModdedItemsConfig>().PirateSellsPirateRetreatOrder)
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("Pirate_Retreat_Order"));
						nextSlot++;
					}
					break;
				case NPCID.GoblinTinkerer:
					if (GetInstance<HOtherModdedItemsConfig>().GoblinTinkererSellsGoblinRetreatOrder)
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("Goblin_Retreat_Order"));
						nextSlot++;
					}
					break;
				case NPCID.TravellingMerchant:
					if (GetInstance<FOtherVanillaNPCConfig>().AllNPCsSellTheirDeathLoot)
					{
						shop.item[nextSlot].SetDefaults(ItemID.PeddlersHat);
						nextSlot++;
					}
					break;
				case NPCID.PartyGirl:
					if (GetInstance<FOtherVanillaNPCConfig>().AllNPCsSellTheirDeathLoot)
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
					if (GetInstance<IOtherCustomNPCsConfig>().BoneMerchant && !(luiafk != null && GetInstance<IOtherCustomNPCsConfig>().BoneMerchantDisabledWhenLuiafkIsInstalled))
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
				float StockingChance = GetInstance<ETravelingAndStationaryMerchantConfig>().StationaryMerchantStockingChance;
				float PreHardModeCompletionBonus = GetInstance<ETravelingAndStationaryMerchantConfig>().S_MerchantStockingBonusForPreH_ModeCompletionRate;

				if (Main.netMode == NetmodeID.SinglePlayer) //I can't get this to run in a server, I get errors instead.
				{
					Player player = Main.player[Main.myPlayer];

					StockingChance = GetInstance<ETravelingAndStationaryMerchantConfig>().StationaryMerchantStockingChance;
					PreHardModeCompletionBonus = GetInstance<ETravelingAndStationaryMerchantConfig>().S_MerchantStockingBonusForPreH_ModeCompletionRate;

					bool addItem = false;
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantLifeformAnalyzerIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.LifeformAnalyzer)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantLifeformAnalyzerIncrease && addItem)
						{
							shop[nextSlot] = ItemID.LifeformAnalyzer;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantDPSMeterIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.DPSMeter)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantDPSMeterIncrease && addItem)
						{
							shop[nextSlot] = ItemID.DPSMeter;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantStopwatchIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Stopwatch)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantStopwatchIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Stopwatch;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantMetalDetector > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.MetalDetector)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantMetalDetector && addItem)
						{
							shop[nextSlot] = ItemID.MetalDetector;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantCelestialMagnetIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.CelestialMagnet)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantCelestialMagnetIncrease && addItem)
						{
							shop[nextSlot] = ItemID.CelestialMagnet;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantAmmoBoxIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.AmmoBox)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantAmmoBoxIncrease && addItem)
						{
							shop[nextSlot] = ItemID.AmmoBox;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantPaintSprayerIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintSprayer)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantPaintSprayerIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintSprayer;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantBrickLayerIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.BrickLayer)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantBrickLayerIncrease && addItem)
						{
							shop[nextSlot] = ItemID.BrickLayer;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantPortableCementMixerIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PortableCementMixer)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantPortableCementMixerIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PortableCementMixer;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantExtendoGripIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.ExtendoGrip)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantExtendoGripIncrease && addItem)
						{
							shop[nextSlot] = ItemID.ExtendoGrip;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantGatligatorIncrease > 0 && Main.hardMode)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Gatligator)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantGatligatorIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Gatligator;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantPulseBowIncrease > 0 && Main.hardMode && NPC.downedPlantBoss)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PulseBow)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantPulseBowIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PulseBow;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantSakeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Sake)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantSakeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Sake;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantPhoIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Pho)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantPhoIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Pho;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantPadThaiIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PadThai)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantPadThaiIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PadThai;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantUltraBrightTorchIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.UltrabrightTorch)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantUltraBrightTorchIncrease && addItem)
						{
							shop[nextSlot] = ItemID.UltrabrightTorch;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantMagicHatIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.MagicHat)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantMagicHatIncrease && addItem)
						{
							shop[nextSlot] = ItemID.MagicHat;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantGypsyRobeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.GypsyRobe)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantGypsyRobeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.GypsyRobe;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantGiIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Gi)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantGiIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Gi;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantPresseratorIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.ActuationAccessory)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantPresseratorIncrease && addItem)
						{
							shop[nextSlot] = ItemID.ActuationAccessory;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantYellowCounterweightIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.YellowCounterweight)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantYellowCounterweightIncrease && addItem)
						{
							shop[nextSlot] = ItemID.YellowCounterweight;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantBlackCounterweightIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.BlackCounterweight)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantBlackCounterweightIncrease && addItem)
						{
							shop[nextSlot] = ItemID.BlackCounterweight;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantSittingDucksFishingPoleIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.SittingDucksFishingRod)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantSittingDucksFishingPoleIncrease && addItem)
						{
							shop[nextSlot] = ItemID.SittingDucksFishingRod;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantKatanaIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Katana)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantKatanaIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Katana;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantCode1Increase > 0 && NPC.downedBoss1)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Code1)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantCode1Increase && addItem)
						{
							shop[nextSlot] = ItemID.Code1;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantRevolverIncrease > 0 && WorldGen.shadowOrbSmashed)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Revolver)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantRevolverIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Revolver;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantCode2Increase > 0 && NPC.downedMechBossAny)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Code2)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantCode2Increase && addItem)
						{
							shop[nextSlot] = ItemID.Code2;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantRedTeamBlockIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockRed)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantRedTeamBlockIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockRed;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantRedTeamPlatformIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockRedPlatform)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantRedTeamPlatformIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockRedPlatform;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantYellowTeamBlockIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockYellow)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantYellowTeamBlockIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockYellow;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantYellowTeamPlatformIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockYellowPlatform)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantYellowTeamPlatformIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockYellowPlatform;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantGreenTeamBlockIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockGreen)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantGreenTeamBlockIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockGreen;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantGreenTeamPlatformIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockGreenPlatform)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantGreenTeamPlatformIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockGreenPlatform;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantBlueTeamBlockIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockBlue)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantBlueTeamBlockIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockBlue;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantBlueTeamPlatformIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockBluePlatform)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantBlueTeamPlatformIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockBluePlatform;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantPinkTeamBlockIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockPink)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantPinkTeamBlockIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockPink;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantPinkTeamPlatformIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockPinkPlatform)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantPinkTeamPlatformIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockPinkPlatform;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantWhiteTeamBlockIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockWhite)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantWhiteTeamBlockIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockWhite;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantWhiteTeamPlatformIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TeamBlockWhitePlatform)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantWhiteTeamPlatformIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TeamBlockWhitePlatform;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantDiamondRingIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.DiamondRing)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantDiamondRingIncrease && addItem)
						{
							shop[nextSlot] = ItemID.DiamondRing;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantAngelHaloIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.AngelHalo)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantAngelHaloIncrease && addItem)
						{
							shop[nextSlot] = ItemID.AngelHalo;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantFezIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Fez)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantFezIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Fez;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantWinterCapeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.WinterCape)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantWinterCapeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.WinterCape;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantRedCapeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.RedCape)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantRedCapeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.RedCape;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantCrimsonCapeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.CrimsonCloak)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantCrimsonCapeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.CrimsonCloak;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantMysteriousCapeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.MysteriousCape)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantMysteriousCapeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.MysteriousCape;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantKimonoIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.Kimono)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantKimonoIncrease && addItem)
						{
							shop[nextSlot] = ItemID.Kimono;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantWaterGunIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.WaterGun)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantWaterGunIncrease && addItem)
						{
							shop[nextSlot] = ItemID.WaterGun;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantCompanionCubeIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.CompanionCube)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantCompanionCubeIncrease && addItem)
						{
							shop[nextSlot] = ItemID.CompanionCube;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantChaliceIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.SteampunkCup)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantChaliceIncrease && addItem)
						{
							shop[nextSlot] = ItemID.SteampunkCup;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantArcaneRuneWallIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.ArcaneRuneWall)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantArcaneRuneWallIncrease && addItem)
						{
							shop[nextSlot] = ItemID.ArcaneRuneWall;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantFancyDishesIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.FancyDishes)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantFancyDishesIncrease && addItem)
						{
							shop[nextSlot] = ItemID.FancyDishes;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantDynastyWoodIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.DynastyWood)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantDynastyWoodIncrease && addItem)
						{
							shop[nextSlot] = ItemID.DynastyWood;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantRedDynastyShinglesIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.RedDynastyShingles)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantRedDynastyShinglesIncrease && addItem)
						{
							shop[nextSlot] = ItemID.RedDynastyShingles;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantBlueDynastyShinglesIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.BlueDynastyShingles)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantBlueDynastyShinglesIncrease && addItem)
						{
							shop[nextSlot] = ItemID.BlueDynastyShingles;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantZebraSkinIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.ZebraSkin)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantZebraSkinIncrease && addItem)
						{
							shop[nextSlot] = ItemID.ZebraSkin;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantLeopardSkinIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.LeopardSkin)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantLeopardSkinIncrease && addItem)
						{
							shop[nextSlot] = ItemID.LeopardSkin;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantTigerSkinIncrease > 0)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.TigerSkin)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantTigerSkinIncrease && addItem)
						{
							shop[nextSlot] = ItemID.TigerSkin;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantCastleMarsbergIncrease > 0 && NPC.downedMartians)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingCastleMarsberg)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantCastleMarsbergIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingCastleMarsberg;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantMartiaLisaIncrease > 0 && NPC.downedMartians)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingMartiaLisa)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantMartiaLisaIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingMartiaLisa;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantTheTruthIsUpThereIncrease > 0 && NPC.downedMartians)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingTheTruthIsUpThere)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantTheTruthIsUpThereIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingTheTruthIsUpThere;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantNotAKidNorASquidIncrease > 0 && NPC.downedMoonlord)
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.MoonLordPainting)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantNotAKidNorASquidIncrease && addItem)
						{
							shop[nextSlot] = ItemID.MoonLordPainting;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantAcornsIncrease > 0 && (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantAlwaysXMasForConfigurations || Main.xMas))
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingAcorns)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantAcornsIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingAcorns;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantColdSnapIncrease > 0 && (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantAlwaysXMasForConfigurations || Main.xMas))
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingColdSnap)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantColdSnapIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingColdSnap;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantCursedSaintIncrease > 0 && (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantAlwaysXMasForConfigurations || Main.xMas))
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingCursedSaint)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantCursedSaintIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingCursedSaint;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantSnowfellasIncrease > 0 && (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantAlwaysXMasForConfigurations || Main.xMas))
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingSnowfellas)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantSnowfellasIncrease && addItem)
						{
							shop[nextSlot] = ItemID.PaintingSnowfellas;
							nextSlot++;
						}
					}
					if (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantTheSeasonIncrease > 0 && (GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantAlwaysXMasForConfigurations || Main.xMas))
					{
						addItem = true;
						for (int i = 0; i < shop.Length; i++)
						{
							if (shop[i] == ItemID.PaintingTheSeason)
								addItem = false;
						}
						if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().TravelingMerchantTheSeasonIncrease && addItem)
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
				StockingChance += (PreHardModeCompletionBonus * PreHardmodeCompletion / 6);
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