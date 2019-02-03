using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.NPCs
{
    public class VanillaNPCShop : GlobalNPC
    {
		
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
			Player player = Main.player[Main.myPlayer];
            switch (type)
            {
                case NPCID.Merchant:
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
						if (!Config.MerchantSellsSandstormInABottleWhenInDesert && !Config.UseSandstorminaBottleRecipe){
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
                    break;
                case NPCID.Steampunker:
					Main.NewText("Shopping with steampunker", 127, 127, 255);
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
						Main.NewText("World is corrupt", 127, 127, 255);
						if (Main.bloodMoon || Main.eclipse)
						{
							Main.NewText("eclipse is happening", 127, 127, 255);
							shop.item[nextSlot].SetDefaults(ItemID.RedSolution);
							nextSlot++;
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
                    break;
                case NPCID.Dryad:
					if (WorldGen.crimson)
					{
						if (Main.bloodMoon)
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
						if (Main.bloodMoon)
						{
							shop.item[nextSlot].SetDefaults(ItemID.CrimsonSeeds);
							nextSlot++;
							shop.item[nextSlot].SetDefaults(ItemID.ViciousPowder);
							nextSlot++;
						}
						if (NPC.downedBoss2) //Brain of Cthulhu or Eater of Worlds
							shop.item[nextSlot].SetDefaults(ItemID.CrimsonPlanterBox);
					}
                    break;
                case NPCID.Mechanic:
					if (Config.MechanicSellsDartTrapAfterSkeletronDefeated && NPC.downedBoss3)
					{
						shop.item[nextSlot].SetDefaults(ItemID.DartTrap);
						nextSlot++;
					}
					if (Config.MechanicSellsGeyserAfterWallofFleshDefeated && Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults(ItemID.GeyserTrap);
						nextSlot++;
					}
					if (NPC.downedGolemBoss)
					{
						if (Config.MechanicSellsLihzahrdTrapsAfterGolemDefeated)
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
						if (Config.MechanicSellsWoodenSpikesAfterGolemDefeated)
						{
							shop.item[nextSlot].SetDefaults(ItemID.WoodenSpike);
							nextSlot++;
						}
					}
                    break;
            }
        }
		
		public override void SetupTravelShop(int[] shop, ref int nextSlot)
		{
			bool addItem = false;
			if (Config.TravelingMerchantLifeformAnalyzerIncrease > 0)
			{
				addItem = true;
				for (int i = 0; i < shop.Length; i++)
				{
					if (shop[i] == ItemID.LifeformAnalyzer)
						addItem = false;
				}
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantLifeformAnalyzerIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantDPSMeterIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantStopwatchIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantMetalDetector*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantCelestialMagnetIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantAmmoBoxIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantPaintSprayerIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantBrickLayerIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantPortableCementMixerIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantExtendoGripIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantGatligatorIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantPulseBowIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantSakeIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantPhoIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantPadThaiIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantUltraBrightTorchIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantMagicHatIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantGypsyRobeIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantGiIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantPresseratorIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantYellowCounterweightIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantBlackCounterweightIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantSittingDucksFishingPoleIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantKatanaIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantCode1Increase*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantRevolverIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantCode2Increase*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantRedTeamBlockIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantRedTeamPlatformIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantYellowTeamBlockIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantYellowTeamPlatformIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantGreenTeamBlockIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantGreenTeamPlatformIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantBlueTeamBlockIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantBlueTeamPlatformIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantPinkTeamBlockIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantPinkTeamPlatformIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantWhiteTeamBlockIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantWhiteTeamPlatformIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantDiamondRingIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantAngelHaloIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantFezIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantWinterCapeIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantRedCapeIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantCrimsonCapeIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantMysteriousCapeIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantKimonoIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantWaterGunIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantCompanionCubeIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantChaliceIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantArcaneRuneWallIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantFancyDishesIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantDynastyWoodIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantRedDynastyShinglesIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantBlueDynastyShinglesIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantZebraSkinIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantLeopardSkinIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantTigerSkinIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantCastleMarsbergIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantMartiaLisaIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantTheTruthIsUpThereIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantNotAKidNorASquidIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantAcornsIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantColdSnapIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantCursedSaintIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantSnowfellasIncrease*10000 && addItem)
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
				if (Main.rand.Next(10000)+1 <= Config.TravelingMerchantTheSeasonIncrease*10000 && addItem)
				{
					shop[nextSlot] = ItemID.PaintingTheSeason;
					nextSlot++;
				}
			}
		}	
    }
}