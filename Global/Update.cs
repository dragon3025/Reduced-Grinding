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
		public static int sundialSearchTimer = 0;
		public static int sundialX = -1;
		public static int sundialY = -1;
		public static bool nearPylon = false;

		public override void PostUpdateTime()
		{
			float timeBoost = GetInstance<IOtherConfig>().SleepBoostBase;

			if (GetInstance<IOtherConfig>().SleepBoostNoSundialMultiplier < 1)
			{
				sundialSearchTimer++;
				if (sundialSearchTimer == 60)
				{
					sundialSearchTimer = 0;
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
					timeBoost *= GetInstance<IOtherConfig>().SleepBoostNoSundialMultiplier;
			}
			else
				sundialX = sundialY = -1;

			if (sundialX > -1)
            {
				nearPylon = false;
				for (int i = 0; i < 255; i++)
				{
					if (!Main.player[i].active)
						continue;
					for (int x = -20; x <= 20; x++)
                    {
						for (int y = -20; y <= 20; y++)
                        {
							Point tileLocation = Main.player[i].Center.ToTileCoordinates();
							int tilex = tileLocation.X + x;
							int tiley = tileLocation.Y + y;
							if (Main.tile[tilex, tiley].TileType == TileID.TeleportationPylon)
                            {
								nearPylon = true;
								break;
							}
						}
						if (nearPylon)
							break;
					}
					if (nearPylon)
						break;
				}
			}

			if (Main.fastForwardTime)
				return;

			if (Main.CurrentFrameFlags.SleepingPlayersCount != Main.CurrentFrameFlags.ActivePlayersCount)
				return;

			if (Main.CurrentFrameFlags.SleepingPlayersCount < 1)
				return;

			if (GetInstance<IOtherConfig>().SleepBoostNoTownMultiplier < 1)
			{
				for (int i = 0; i < 255; i++)
				{
					if (!Main.player[i].active)
						continue;
					if (Main.player[i].townNPCs < 3)
					{
						timeBoost *= GetInstance<IOtherConfig>().SleepBoostNoTownMultiplier;
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

			if (Main.netMode == NetmodeID.Server)
			{
				var netMessage = Mod.GetPacket();

				netMessage.Write((byte)ReducedGrindingMessageType.sundialSearchTimer);
				netMessage.Write(sundialSearchTimer);
				netMessage.Send();
				NetMessage.SendData(MessageID.WorldData);

				netMessage.Write((byte)ReducedGrindingMessageType.sundialX);
				netMessage.Write(sundialX);
				netMessage.Send();
				NetMessage.SendData(MessageID.WorldData);

				netMessage.Write((byte)ReducedGrindingMessageType.sundialY);
				netMessage.Write(sundialY);
				netMessage.Send();
				NetMessage.SendData(MessageID.WorldData);

				netMessage.Write((byte)ReducedGrindingMessageType.nearPylon);
				netMessage.Write(nearPylon);
				netMessage.Send();
				NetMessage.SendData(MessageID.WorldData);
			}
		}

		public override void PostUpdateWorld()
		{

			Player player = Main.player[Main.myPlayer];

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

			//Mod luiafk = ModLoader.GetMod("Luiafk"); TODO
			//if (GetInstance<IOtherCustomNPCsConfig>().BoneMerchant && !(luiafk != null && GetInstance<IOtherCustomNPCsConfig>().BoneMerchantDisabledWhenLuiafkIsInstalled))
		}
	}
}
