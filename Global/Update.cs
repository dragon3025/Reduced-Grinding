using log4net;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ReLogic.Content.Sources;
using ReLogic.Content;
using ReLogic.Utilities;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader.Assets;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Core;
using Terraria.ModLoader.UI;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria;

namespace ReducedGrinding.Global
{
    public class Update : ModSystem
	{
		//Gets recording into world save
		public static bool advanceMoonPhase = false;
		public static bool sleepBoost = false;
		public static int sleepBoostCheck = 60;
		public static int sundialSearchCount = 0;
		public static int sundialX = -1;
		public static int sundialY = -1;

		public override void PostUpdateTime()
		{
			float timeBoost = GetInstance<IOtherConfig>().SleepBoostBase;

			if (GetInstance<IOtherConfig>().SleepBoostSundialMultiplier < 1)
			{
				sundialSearchCount++;
				if (sundialSearchCount == 60)
				{
					sundialSearchCount = 0;
					sundialX = sundialY = -1;
					for (int i = 0; i < Main.maxTilesY; i++)
					{
						for (int j = 0; j < Main.maxTilesX; j++)
						{
							if (Main.tile[j, i].TileType == TileID.Sundial)
							{
								sundialX = j + 1;
								sundialY = i + 1;
								break;
							}
						}
						if (sundialX > -1)
							break;
					}
				}

				if (sundialX == -1)
					timeBoost *= GetInstance<IOtherConfig>().SleepBoostSundialMultiplier;
			}
			else
				sundialX = sundialY = -1;

			if (Main.fastForwardTime)
				return;

			if (Main.CurrentFrameFlags.SleepingPlayersCount != Main.CurrentFrameFlags.ActivePlayersCount)
				return;

			if (Main.CurrentFrameFlags.SleepingPlayersCount < 1)
				return;

			if (GetInstance<IOtherConfig>().SleepBoostTownMultiplier < 1)
			{
				for (int i = 0; i < 255; i++)
				{
					if (!Main.player[i].active)
						continue;
					if (Main.player[i].townNPCs < 3)
					{
						timeBoost *= GetInstance<IOtherConfig>().SleepBoostTownMultiplier;
						break;
					}
				}
			}

			if (GetInstance<IOtherConfig>().SleepBoostDivideByNearbyEnemies)
			{
				int nearbyEnemies = 0;
				int enemyRange = 2000;
				for (int i = 0; i < 255; i++)
				{
					if (!Main.player[i].active)
						continue;
					int enemyCount = 0;
					for (int l = 0; l < 200; l++)
					{
						if (Main.npc[l].active && !Main.npc[l].friendly && Main.npc[l].damage > 0 && Main.npc[l].lifeMax > 5 && !Main.npc[l].dontCountMe && (Main.npc[l].Center - Main.player[i].Center).Length() < enemyRange)
							enemyCount++;
					}
					nearbyEnemies = Math.Max(nearbyEnemies, enemyCount);
				}
				timeBoost /= nearbyEnemies + 1;
			}

			if (GetInstance<IOtherConfig>().SleepBoostNoPotionBuffMultiplier < 1)
			{
				for (int i = 0; i < 255; i++)
				{
					if (!Main.player[i].active)
						continue;
					if (Main.player[i].FindBuffIndex(ModContent.BuffType<Buffs.Sleep>()) == -1)
					{
						timeBoost *= GetInstance<IOtherConfig>().SleepBoostNoPotionBuffMultiplier;
						break;
					}
				}
			}

			Main.time += (int)timeBoost;

			for (int i = 0; i < 255; i++)
			{
				if (!Main.player[i].active)
					continue;
				if (Main.player[i].FindBuffIndex(ModContent.BuffType<Buffs.Sleep>()) != -1)
					Main.player[i].buffTime[Main.player[i].FindBuffIndex(ModContent.BuffType<Buffs.Sleep>())] -= (int)timeBoost;
			}
		}

		public override void PostUpdateWorld()
		{

			Terraria.Player player = Main.player[Main.myPlayer];

			int playerCoinAmount = 0;
			foreach (Terraria.Item inventoryIndex in player.inventory)
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
				if (!Main.player[i].active)
					continue;
				if (Main.player[i].HasItem(ModContent.ItemType<Items.BossAndEventControl.Celestial_Beacon>()))
					anyPlayerHasCelestialBeacon = true;
			}

			if (NPC.MoonLordCountdown > 1 && anyPlayerHasCelestialBeacon)
				NPC.MoonLordCountdown = 1;



			if (Main.time % 600 == 0 && !NPC.downedMoonlord)
			{
				for (int i = 0; i < Main.npc.Length; i++)
				{
					if (Main.npc[i].type == NPCID.MoonLordCore && !anyPlayerHasCelestialBeacon)
					{
						var source = new EntitySource_Gift(Main.player[(int)Terraria.Player.FindClosest(Main.npc[i].position, Main.npc[i].width, Main.npc[i].height)]);
						player.QuickSpawnItem(source, ModContent.ItemType<Items.BossAndEventControl.Celestial_Beacon>());
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
				if (Main.bloodMoon && Main.moonPhase == 4)
					Main.bloodMoon = false;
				if (Main.netMode == NetmodeID.Server)
				{
					var netMessage = Mod.GetPacket();
					netMessage.Write((byte)ReducedGrindingMessageType.advanceMoonPhase);
					netMessage.Write(Global.Update.advanceMoonPhase);
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
                        Terraria.WorldGen.SpawnTravelNPC();
				}
			}
		}
	}
}
