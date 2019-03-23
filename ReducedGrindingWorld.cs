using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using Terraria.DataStructures;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria;

namespace ReducedGrinding
{
    public class ReducedGrindingWorld : ModWorld
    {
		public static bool skipToDay = false;
		public static bool skipToNight = false;
		
		//Gets recording into world save
        public static bool infectionChestMined = false;
        public static bool hallowedChestMined = false;
        public static bool frozenChestMined = false;
        public static bool jungleChestMined = false;
		public static List<int> stationaryMerchantItems;
		public static List<int> stationaryMerchantStructureItems;
        public static bool skippedToDayOrNight = false;

        public override void Initialize()
        {
			infectionChestMined = false;
			hallowedChestMined = false;
			frozenChestMined = false;
			jungleChestMined = false;
			stationaryMerchantItems = new List<int>();
			stationaryMerchantStructureItems = new List<int>();
			skippedToDayOrNight = false;
		}
		
        public override TagCompound Save()
        {
            var biomeChestMined = new List<string>();
            if (infectionChestMined) biomeChestMined.Add("infectionChestMined");
			if (hallowedChestMined) biomeChestMined.Add("hallowedChestMined");
			if (frozenChestMined) biomeChestMined.Add("frozenChestMined");
			if (jungleChestMined) biomeChestMined.Add("jungleChestMined");

            return new TagCompound
			{
                {"biomeChestMined", biomeChestMined},
				{"stationaryMerchantItems", stationaryMerchantItems},
				{"stationaryMerchantStructureItems", stationaryMerchantStructureItems},
				{"skippedToDayOrNight", skippedToDayOrNight}
            };
        }

        public override void Load(TagCompound tag)
        {
            var biomeChestMined = tag.GetList<string>("biomeChestMined");
            infectionChestMined = biomeChestMined.Contains("infectionChestMined");
			hallowedChestMined = biomeChestMined.Contains("hallowedChestMined");
			frozenChestMined = biomeChestMined.Contains("frozenChestMined");
			jungleChestMined = biomeChestMined.Contains("jungleChestMined");
			
			stationaryMerchantItems = tag.Get<List<int>>("stationaryMerchantItems");
			stationaryMerchantStructureItems = tag.Get<List<int>>("stationaryMerchantStructureItems");
			
			skippedToDayOrNight = tag.GetBool("skippedToDayOrNight");
        }
		
		/*public override void LoadLegacy(BinaryReader reader) {
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0) {
				BitsByte flags = reader.ReadByte();
				infectionChestMined = flags[0];
				hallowedChestMined = flags[1];
				frozenChestMined = flags[2];
				jungleChestMined = flags[3];
			}
		}
		
		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = infectionChestMined;
			flags[1] = hallowedChestMined;
			flags[2] = frozenChestMined;
			flags[3] = jungleChestMined;
			writer.Write(flags);
		}
		
		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			infectionChestMined = flags[0];
			hallowedChestMined = flags[1];
			frozenChestMined = flags[2];
			jungleChestMined = flags[3];
		}*/
		
		public override void PostUpdate()
		{
			Player player = Main.player[Main.myPlayer];
			if (player.HasItem(1528)) //Jungle Chest
				jungleChestMined = true;
			if (player.HasItem(1529)) //Corruption Chest
				infectionChestMined = true;
			if (player.HasItem(1530)) //Crimson Chest
				infectionChestMined = true;
			if (player.HasItem(1531)) //Hallowed Chest
				hallowedChestMined = true;
			if (player.HasItem(1532)) //Frozen Chest
				frozenChestMined = true;
				
            int playerCoinAmount = 0;
			int townNPCCount = 0;	
			for (int i = 0; i < Terraria.Main.npc.Length; i++) //Do once for each NPC in the world
			{
				if (Terraria.Main.npc[i].townNPC == true)
				{
					if (Terraria.Main.npc[i].type == NPCID.Guide || Terraria.Main.npc[i].type == NPCID.Merchant || Terraria.Main.npc[i].type == NPCID.Nurse || Terraria.Main.npc[i].type == NPCID.Demolitionist || Terraria.Main.npc[i].type == NPCID.DyeTrader || Terraria.Main.npc[i].type == NPCID.Dryad || Terraria.Main.npc[i].type == NPCID.DD2Bartender || Terraria.Main.npc[i].type == NPCID.ArmsDealer || Terraria.Main.npc[i].type == NPCID.Stylist || Terraria.Main.npc[i].type == NPCID.Painter || Terraria.Main.npc[i].type == NPCID.Angler || Terraria.Main.npc[i].type == NPCID.GoblinTinkerer || Terraria.Main.npc[i].type == NPCID.WitchDoctor || Terraria.Main.npc[i].type == NPCID.Clothier || Terraria.Main.npc[i].type == NPCID.Mechanic || Terraria.Main.npc[i].type == NPCID.PartyGirl || Terraria.Main.npc[i].type == NPCID.Wizard || Terraria.Main.npc[i].type == NPCID.TaxCollector || Terraria.Main.npc[i].type == NPCID.Truffle || Terraria.Main.npc[i].type == NPCID.Pirate || Terraria.Main.npc[i].type == NPCID.Steampunker || Terraria.Main.npc[i].type == NPCID.Cyborg) //Any Permenant Town Residents
						townNPCCount++;
				}
			}
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
			stationaryMerchantItems.Sort();
			stationaryMerchantStructureItems.Sort();
			
			bool anyPlayerHasItem = false;
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active && Main.player[i].HasItem(mod.ItemType("Celestial_Beacon")))
				{ 
					anyPlayerHasItem = true;
					break; 
				}
			}
			if (NPC.MoonLordCountdown > 1 && anyPlayerHasItem)
				NPC.MoonLordCountdown = 1;
			//if (NPC.MoonLordCountdown > 1 && Main.player.Any(x => x.HasItem(mod.ItemType("Celestial_Beacon"))))
				//NPC.MoonLordCountdown = 1;

			if (skipToNight)
			{
				if (Main.sundialCooldown > 0)
					ReducedGrindingWorld.skippedToDayOrNight = true;
				Main.time = 54000;
				skipToDay = false;
				skipToNight = false;
				
				if (Main.netMode == 2) //Server
				{
					var netMessage = mod.GetPacket();
					netMessage.Write((byte)ReducedGrindingMessageType.skipToNight);
					netMessage.Write(ReducedGrindingWorld.skipToNight);
					netMessage.Send();
					NetMessage.SendData(7);
					
					netMessage.Write((byte)ReducedGrindingMessageType.skipToDay);
					netMessage.Write(ReducedGrindingWorld.skipToDay);
					netMessage.Send();
					NetMessage.SendData(7);
				}
			}

			if (skipToDay)
			{
				if (Main.sundialCooldown > 0)
					ReducedGrindingWorld.skippedToDayOrNight = true;
				Main.time = 32400;
				skipToDay = false;
				skipToNight = false;
				
				if (Main.netMode == 2) //Server
				{
					var netMessage = mod.GetPacket();
					netMessage.Write((byte)ReducedGrindingMessageType.skipToNight);
					netMessage.Write(ReducedGrindingWorld.skipToNight);
					netMessage.Send();
					NetMessage.SendData(7);
					
					netMessage.Write((byte)ReducedGrindingMessageType.skipToDay);
					netMessage.Write(ReducedGrindingWorld.skipToDay);
					netMessage.Send();
					NetMessage.SendData(7);
				}
			}
			
			if (Main.dayTime && skippedToDayOrNight)
			{
				Main.sundialCooldown++;
				skippedToDayOrNight = false;
			}
		}
    }
}
