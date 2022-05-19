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
			int SandstormInABottleCount = 0;
			int FlyingCarpetCount = 0;
			int PharaohOutfitCount = 0;
			int foundItem = 0;
			List<int> desertChests = new List<int>();

			for (int chestIndex = 0; chestIndex < 8000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				int TileSubID = 1; //Gold Chest
				if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == TileSubID * 36)
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == ItemID.PharaohsMask) foundItem = ItemID.PharaohsMask;
						if (chest.item[inventoryIndex].type == ItemID.PharaohsRobe) foundItem = ItemID.PharaohsMask;
						if (chest.item[inventoryIndex].type == ItemID.FlyingCarpet) foundItem = ItemID.FlyingCarpet;
						if (chest.item[inventoryIndex].type == ItemID.SandstorminaBottle) foundItem = ItemID.SandstorminaBottle;
					}
					if (foundItem > 0)
					{
						if (foundItem == ItemID.PharaohsMask) PharaohOutfitCount += 1;
						if (foundItem == ItemID.FlyingCarpet) FlyingCarpetCount += 1;
						if (foundItem == ItemID.SandstorminaBottle) SandstormInABottleCount += 1;
						foundItem = 0;
					}
				}

				TileSubID = 10; //Sandstone Chest
				if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers2 && Main.tile[chest.x, chest.y].TileFrameX == TileSubID * 36)
					desertChests.Add(chestIndex);
			}

			if (desertChests.Count > 0)
            {
				while (PharaohOutfitCount == 0 || FlyingCarpetCount == 0 || SandstormInABottleCount == 0)
				{
					int chestIndex = desertChests[Main.rand.Next(desertChests.Count)];
					Chest chest = Main.chest[chestIndex];
					if (PharaohOutfitCount == 0)
					{
						int PharaohOutfitPieces = 0;
						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == ItemID.None)
							{
								if (PharaohOutfitPieces == 0)
								{
									chest.item[inventoryIndex].SetDefaults(ItemID.PharaohsMask);
									PharaohOutfitPieces += 1;
								}
								else
								{
									chest.item[inventoryIndex].SetDefaults(ItemID.PharaohsRobe);
									PharaohOutfitCount += 1;
									break;
								}
							}
						}
					}
					else if (FlyingCarpetCount == 0)
					{
						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == ItemID.None)
							{
								chest.item[inventoryIndex].SetDefaults(ItemID.FlyingCarpet);
								FlyingCarpetCount += 1;
								break;
							}
						}
					}
					else if (SandstormInABottleCount == 0)
					{
						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == ItemID.None)
							{
								chest.item[inventoryIndex].SetDefaults(ItemID.SandstorminaBottle);
								SandstormInABottleCount += 1;
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
			foreach (Item i in player.inventory)
			{
				switch (i.type)
				{
					case ItemID.CopperCoin:
						playerCoinAmount += 1 * i.stack;
						break;
					case ItemID.SilverCoin:
						playerCoinAmount += 100 * i.stack;
						break;
					case ItemID.GoldCoin:
						playerCoinAmount += 10000 * i.stack;
						break;
					case ItemID.PlatinumCoin:
						playerCoinAmount += 1000000 * i.stack;
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
