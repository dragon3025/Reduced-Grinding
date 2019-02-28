using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

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
			return true;
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
			else
			{
				shop = true;
				baseshop = false;
			}
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
			if (baseshop)
			{
				stationaryMerchantItemsChosen = ReducedGrindingWorld.stationaryMerchantItems.ToList();
			}
			else
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
    }
}