using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
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

namespace ReducedGrinding.NPCs
{
	[AutoloadHead]
    public class StationaryMerchant : ModNPC
    {
		
		public static bool baseshop = false;
		public static List<int> stationaryMerchantItemsChosen;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stationary Merchant");
		}
		
        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 32;
            npc.height = 50;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            Main.npcFrameCount[npc.type] = 26;
            animationType = NPCID.Guide;
        }
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
			ReducedGrindingPlayer mPlayer = Main.LocalPlayer.GetModPlayer<ReducedGrindingPlayer>();
			if (mPlayer.clientConf.StationaryMerchant)
				return true;
			else
				return false;
        }

        public override string TownNPCName()
        {										//NPC names
            switch (Main.rand.Next(14))
            {
                case 0:
                    return "Abe";
                case 1:
                    return "Alph";
                case 2:
                    return "Elmer";
                case 3:
                    return "Lewis";
                case 4:
					return "Ralph";
                case 5:
					return "Rodney";
                case 6:
					return "Romero";
                case 7:
					return "Will";
                case 8:
					return "Dan";
                case 9:
					return "Boyd";
                case 10:
					return "Galahan";
                case 11:
					return "Mervin";
                case 12:
					return "Rico";
                default:
					return "Stephan";
            }
        }




        public override string GetChat()
        {
			if (Terraria.GameContent.Events.BirthdayParty.PartyIsUp && Main.rand.Next(3) == 0)
			{
				return "I bet travelers miss parties a lot.";
			}
			else
			{
				switch (Main.rand.Next(4))
				{
					case 0:
						return "Don't worry, I'm not going anywhere!";
					case 1:
						return "I like to stock up on goods from merchants that pass by here.";
					case 2:
						return "I could go hunting for rare items, but I'd rather buy them from those who do.";
					default:
						return "Would you like to see some goods that I've aquired from travelers?";
				}
			}

        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
            button2 = "Decor Shop";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
			{
				shop = true;
				baseshop = true;
			}
			else //Docor Shop
			{
				shop = true;
				baseshop = false;
			}
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
			if (Main.netMode == 0) // Single Player
			{
				if (baseshop)
				{
					stationaryMerchantItemsChosen = ReducedGrindingWorld.stationaryMerchantItems.ToList();
				}
				else //Docor Shop
				{
					stationaryMerchantItemsChosen = ReducedGrindingWorld.stationaryMerchantStructureItems.ToList();
				}
				int stationaryMerchantItemsCount = 0;
				foreach (int i in stationaryMerchantItemsChosen)
					stationaryMerchantItemsCount++;
				int j = 0;
				while (j < stationaryMerchantItemsCount)
				{
					shop.item[nextSlot].SetDefaults(stationaryMerchantItemsChosen[j]);
					nextSlot++;
					j++;
				}
			}
			else //I tried for days to get ReducedGrindingWorld.stationaryMerchantItems and ReducedGrindingWorld.stationaryMerchantStructureItems to sync in multiplayer but couldn't. So instead, the stationary merchant works differently in multiplayer.
			{
				if (baseshop)
				{
					if (NPC.downedSlimeKing)
					{
						for (int i = 2266; i <= 2268; i++)
						{
							shop.item[nextSlot].SetDefaults(i);
							nextSlot++;
						}
						shop.item[nextSlot].SetDefaults(3119);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(3118);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(3099);
						nextSlot++;
					}
					if (NPC.downedBoss1)
					{
						shop.item[nextSlot].SetDefaults(2274);
						nextSlot++;
						for (int i = 2214; i <= 2217; i++)
						{
							shop.item[nextSlot].SetDefaults(i);
							nextSlot++;
						}
						shop.item[nextSlot].SetDefaults(3624);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(3262);
						nextSlot++;
					}
					if (NPC.downedBoss2)
					{
						shop.item[nextSlot].SetDefaults(2273);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(2177);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(2275);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(2279);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(2277);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(1988);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(2269);
						nextSlot++;
					}
					if (NPC.downedQueenBee)
					{
						shop.item[nextSlot].SetDefaults(2219);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(3314);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(2296);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(2276);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(2284);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(2285);
						nextSlot++;
					}
					if (NPC.downedBoss3)
					{
						shop.item[nextSlot].SetDefaults(1987);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(2272);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(2278);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(2286);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(2287);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(3309);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(3628);
						nextSlot++;
					}
					if (Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults(2270);
						nextSlot++;
					}
					if (NPC.downedMechBossAny)
					{
						shop.item[nextSlot].SetDefaults(3284);
						nextSlot++;
					}
					if (NPC.downedPlantBoss)
					{
						shop.item[nextSlot].SetDefaults(2223);
						nextSlot++;
					}
				}
				else //Docor Shop
				{
					shop.item[nextSlot].SetDefaults(3621);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(3622);
					nextSlot++;
					for (int i = 3633; i <= 3642; i++)
					{
						shop.item[nextSlot].SetDefaults(i);
						nextSlot++;
					}
					if (NPC.downedSlimeKing)
					{
						shop.item[nextSlot].SetDefaults(2258);
						nextSlot++;
					}
					if (NPC.downedBoss1)
					{
						shop.item[nextSlot].SetDefaults(2242);
						nextSlot++;
					}
					if (NPC.downedBoss2)
					{
						shop.item[nextSlot].SetDefaults(2260);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(2261);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(2262);
						nextSlot++;
					}
					if (NPC.downedQueenBee)
					{
						for (int i = 2281; i <= 2283; i++)
						{
							shop.item[nextSlot].SetDefaults(i);
							nextSlot++;
						}
					}
					if (NPC.downedBoss3)
					{
						shop.item[nextSlot].SetDefaults(2271);
						nextSlot++;
					}
					if (NPC.downedFrost)
					{
						for (int i = 3055; i <= 3059; i++)
						{
							shop.item[nextSlot].SetDefaults(i);
							nextSlot++;
						}
					}
					if (NPC.downedMartians)
					{
						shop.item[nextSlot].SetDefaults(2865);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(2866);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(2867);
						nextSlot++;
					}
					if (NPC.downedMoonlord)
					{
						shop.item[nextSlot].SetDefaults(3596);
						nextSlot++;
					}
				}
			}
				
        }
    }
}