using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.WorldBuilding;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Chat;

namespace ReducedGrinding
{
	public class ReducedGrindingWorld : ModSystem
    {
		//Gets recording into world save
		public static bool advanceMoonPhase = false;

		public override void PostWorldGen()
		{
			//int worldSize = Main.maxTilesX / 4200 == 1 ? 1 : Main.maxTilesX / 4200 == 1.5 ? 2 : 3; in case I need it.

			List<int> missingPyramidItems = new List<int> { ItemID.PharaohsMask, ItemID.PharaohsRobe, ItemID.FlyingCarpet , ItemID.SandstorminaBottle };
			List<int> missingLivingWoodItems = new List<int> { ItemID.BabyBirdStaff, ItemID.SunflowerMinecart, ItemID.LadybugMinecart};
			bool beeMinecartMissing = true;

			List<int> desertChests = new List<int>();
			List<int> ivyChests = new List<int>();
			List<int> livingWoodChests = new List<int>();
			List<int> surfaceChests = new List<int>();

			for (int chestIndex = 0; chestIndex < 8000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];

				if (chest == null)
					continue;

				int TileSubID = 1; //Gold Chest
				if (Main.tile[chest.x, chest.y].TileType == TileID.Containers)
				{
					if (Main.tile[chest.x, chest.y].TileFrameX == TileSubID * 36)
					{
						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							List<int> missingPyramidItemsOld = new List<int>();
							missingPyramidItemsOld.AddRange(missingPyramidItems);

							foreach (int itemType in missingPyramidItemsOld)
								if (chest.item[inventoryIndex].type == itemType) missingPyramidItems.Remove(itemType);
						}
					}

					TileSubID = 10; //Ivy Chest
					if (Main.tile[chest.x, chest.y].TileFrameX == TileSubID * 36)
					{
						ivyChests.Add(chestIndex);
						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == ItemID.BeeMinecart) beeMinecartMissing = false;
						}
					}

					TileSubID = 0; //Surface Chest
					if (Main.tile[chest.x, chest.y].TileFrameX == TileSubID * 36)
						surfaceChests.Add(chestIndex);

					TileSubID = 12; //Living Wood Chest
					if (Main.tile[chest.x, chest.y].TileFrameX == TileSubID * 36)
					{
						livingWoodChests.Add(chestIndex);
						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							List<int> missingLivingWoodItemsOld = new List<int>();
							missingLivingWoodItemsOld.AddRange(missingLivingWoodItems);

							foreach (int itemType in missingLivingWoodItemsOld)
								if (chest.item[inventoryIndex].type == itemType) missingLivingWoodItems.Remove(itemType);
						}
					}
				}

				TileSubID = 10; //Sandstone Chest
				if (Main.tile[chest.x, chest.y].TileType == TileID.Containers2 && Main.tile[chest.x, chest.y].TileFrameX == TileSubID * 36)
					desertChests.Add(chestIndex);
			}

			if (desertChests.Count > 0)
            {
				while (missingPyramidItems.Count > 0)
				{
					int desertChestsIndex = Main.rand.Next(desertChests.Count);
					int chestIndex = desertChests[desertChestsIndex];

					Chest chest = Main.chest[chestIndex];
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == ItemID.None)
						{
							chest.item[inventoryIndex].SetDefaults(missingPyramidItems[0]);
							missingPyramidItems.RemoveAt(0);
							if (desertChests.Count > 1)
								desertChests.RemoveAt(desertChestsIndex);
							break;
						}
					}
				}
            }

			if (beeMinecartMissing && ivyChests.Count > 0)
			{
				int chestIndex = ivyChests[Main.rand.Next(ivyChests.Count)];

				Chest chest = Main.chest[chestIndex];
				for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
				{
					if (chest.item[inventoryIndex].type == ItemID.None)
					{
						chest.item[inventoryIndex].SetDefaults(ItemID.BeeMinecart);
						break;
					}
				}
			}

			if ((surfaceChests.Count + livingWoodChests.Count) > 0)
			{
				while (missingLivingWoodItems.Count > 0)
				{
					if (livingWoodChests.Count > 0)
					{
						int livingWoodChestsIndex = Main.rand.Next(livingWoodChests.Count);
						int chestIndex = livingWoodChests[livingWoodChestsIndex];

						Chest chest = Main.chest[chestIndex];
						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == ItemID.None)
							{
								chest.item[inventoryIndex].SetDefaults(missingLivingWoodItems[0]);
								missingLivingWoodItems.RemoveAt(0);
								livingWoodChests.RemoveAt(livingWoodChestsIndex);
								break;
							}
						}
					}
					else
					{
						int surfaceChestIndex = Main.rand.Next(surfaceChests.Count);
						int chestIndex = surfaceChests[surfaceChestIndex];

						Chest chest = Main.chest[chestIndex];
						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == ItemID.None)
							{
								chest.item[inventoryIndex].SetDefaults(missingLivingWoodItems[0]);
								missingLivingWoodItems.RemoveAt(0);
								if (surfaceChests.Count > 1)
									surfaceChests.RemoveAt(surfaceChestIndex);
								break;
							}
						}
					}
				}
			}
		}

		public override void PostUpdateWorld()
        {
			Player player = Main.player[Main.myPlayer];

			int playerCoinAmount = 0;
			foreach (Item inventoryIndex in player.inventory)
			{
				switch (inventoryIndex.type)
				{
					case ItemID.CopperCoin:
						playerCoinAmount += 1 * inventoryIndex.stack;
						break;
					case ItemID.SilverCoin:
						playerCoinAmount += 100 * inventoryIndex.stack;
						break;
					case ItemID.GoldCoin:
						playerCoinAmount += 10000 * inventoryIndex.stack;
						break;
					case ItemID.PlatinumCoin:
						playerCoinAmount += 1000000 * inventoryIndex.stack;
						break;
				}
			}

			bool anyPlayerHasCelestialBeacon = false;
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active)
				{
					if (Main.player[i].HasItem(ModContent.ItemType<Items.Celestial_Beacon>()))
						anyPlayerHasCelestialBeacon = true;
				}
			}

			if (NPC.MoonLordCountdown > 1 && anyPlayerHasCelestialBeacon)
				NPC.MoonLordCountdown = 1;

			if (Main.time % 600 == 0 && !NPC.downedMoonlord)
			{
				for (int i = 0; i < Main.npc.Length; i++)
				{
					if (Main.npc[i].type == NPCID.MoonLordCore && !anyPlayerHasCelestialBeacon)
					{
						var source = new EntitySource_Gift(Main.player[(int)Player.FindClosest(Main.npc[i].position, Main.npc[i].width, Main.npc[i].height)]);
						player.QuickSpawnItem(source, ModContent.ItemType<Items.Celestial_Beacon>());
						break;
					}
				}
			}

			//I plan on having the dials enhance the speed of sleeping instead.
			if (advanceMoonPhase)
			{
				advanceMoonPhase = false;
				Main.moonPhase++;
				if (Main.moonPhase >= 8)
				{
					Main.moonPhase = 0;
				}
				if (Main.netMode == NetmodeID.Server)
				{
					var netMessage = Mod.GetPacket();
					netMessage.Write((byte)ReducedGrindingMessageType.advanceMoonPhase);
					netMessage.Write(ReducedGrindingWorld.advanceMoonPhase);
					netMessage.Send();
					NetMessage.SendData(MessageID.WorldData);
				}
			}

			//There are 21 stationary vanilla NPCs (excluding Guide and Santa) as of 5/26/2017; 15 Pre-Hardmode and 6 Hardmode.
			float TownNPCs = 0f;
			float TownNPCsMax = 15f;
			float TownHardmodeNPCs = 0f;
			float TownHardmodeNPCsMax = 6f;
			bool tryToSpawnTravelingMerchant = true;

			//Mod luiafk = ModLoader.GetMod("Luiafk"); TODO
			//if (GetInstance<IOtherCustomNPCsConfig>().BoneMerchant && !(luiafk != null && GetInstance<IOtherCustomNPCsConfig>().BoneMerchantDisabledWhenLuiafkIsInstalled))
			if (GetInstance<IOtherConfig>().BoneMerchant)
				TownNPCsMax++;
			if (GetInstance<ETravelingAndStationaryMerchantConfig>().StationaryMerchant)
				TownNPCsMax++;
			if (GetInstance<IOtherConfig>().LootMerchant)
				TownNPCsMax++;
			if (GetInstance<IOtherConfig>().ChristmasElf)
				TownHardmodeNPCsMax++;

			for (int i = 0; i < Terraria.Main.npc.Length; i++) //Do once for each NPC in the world
			{
				if (Terraria.Main.npc[i].townNPC == true)
				{
					if (Terraria.Main.npc[i].type == NPCID.TravellingMerchant)
					{
						tryToSpawnTravelingMerchant = false;
					}
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
						(Terraria.Main.npc[i].type == NPCType<NPCs.BoneMerchant>() && GetInstance<IOtherConfig>().BoneMerchant) ||
						(Terraria.Main.npc[i].type == NPCType<NPCs.StationaryMerchant>() && GetInstance<ETravelingAndStationaryMerchantConfig>().StationaryMerchant) ||
						(Terraria.Main.npc[i].type == NPCType<NPCs.LootMerchant>() && GetInstance<IOtherConfig>().LootMerchant)
					)
						TownNPCs++;
					else if (
						Terraria.Main.npc[i].type == NPCID.Wizard ||
						Terraria.Main.npc[i].type == NPCID.TaxCollector ||
						Terraria.Main.npc[i].type == NPCID.Truffle ||
						Terraria.Main.npc[i].type == NPCID.Pirate ||
						Terraria.Main.npc[i].type == NPCID.Steampunker ||
						Terraria.Main.npc[i].type == NPCID.Cyborg ||
						(Terraria.Main.npc[i].type == NPCType<NPCs.Christmas_Elf>() && GetInstance<IOtherConfig>().ChristmasElf)
					)
					{
						TownHardmodeNPCs++;
					}
				}
			}

			float TownNPCPercent = (TownNPCs / TownNPCsMax + TownHardmodeNPCs / TownHardmodeNPCsMax) / 2;

			if (!Main.fastForwardTime && Main.dayTime && Main.time < 27000.0)
			{
				int alltownNPCs = 0;
				for (int j = 0; j < 200; j++)
				{
					if (Main.npc[j].active && Main.npc[j].townNPC && Main.npc[j].type != NPCID.OldMan && Main.npc[j].type != NPCID.SkeletonMerchant)
					{
						alltownNPCs++;
					}
				}
				if (alltownNPCs >= 2)
				{
					if (tryToSpawnTravelingMerchant)
					{
						tryToSpawnTravelingMerchant = false;
						if (!Main.fastForwardTime && Main.dayTime && Main.time < 27000.0)
						{
							int chanceRoll = (int)(27000.0 / (double)Main.dayRate);
							chanceRoll *= 4;
							for (int i = 0; i < 3; i++)
							{
								if (Main.rand.Next(chanceRoll) == 0)
								{
									tryToSpawnTravelingMerchant = true;
									break;
								}
							}
						}
					}
					if (tryToSpawnTravelingMerchant && Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().BaseMorningTMerchantSpawnChance * Math.Pow(TownNPCPercent, 2))
						WorldGen.SpawnTravelNPC();
				}
			}
		}
	}
}
