using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.DataStructures;
using System.Collections.Generic;
using ReLogic.Content;

namespace ReducedGrinding.NPCs
{
	[AutoloadHead]
    public class ChestSalesman : ModNPC
    {
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chest Salesman");
		}
		
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18; //His hitbox, the visual width/height is affected by frame count below.
			NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            Main.npcFrameCount[Type] = 25;
			AnimationType = NPCID.Guide;
        }
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
			if (GetInstance< IOtherCustomNPCsConfig>().ChestSalesman)
				return true;
			else
				return false;
        }

		public override List<string> SetNPCNameList()
		{
			return new List<string>() {
				"Chester",
				"Chad",
				"Charlie",
				"Chace",
				"Benedict",
				"Ranulph",
				"Mike",
				"Locke",
				"John",
				"Ferdinand",
				"Lewis",
				"Nicholas",
				"Aron",
				"Robert",
				"Thor",
				"Jones",
				"Rolf",
				"Tobin",
				"Alexander",
				"George",
				"Francis",
				"Montgomery",
				"Mark",
				"Ross",
				"Adrian",
				"Samuel",
				"Randy"
			};
		}

        public override string GetChat()
        {
			if (Terraria.GameContent.Events.BirthdayParty.PartyIsUp && Main.rand.Next(3) == 0)
			{
				return "Just between you and me, these chests here are perfect for hiding some of that delicious cake!";
			}
			else
			{
				switch (Main.rand.Next(5))
				{
					case 0:
						return "You got the looks of an adventurer! Mounds of treasure... discovering them is one thing, but where do you keep them?! That's where my chests come in!";
					case 1:
						return "Aye, I like you. You remind me of good old me, roaming the lands in search of riches! But there's one thing I like more than that... and that's a neat storage system!";
					case 2:
						return "Don't have the aptitude for the crafting of those beautiful, mysterious chests all over the globe? I collect them for a hobby, and I am here to sell them!";
					case 3:
						return "Having trouble throwing stuff away? Why not buy a chest and call it a day? Your hoarding habit is our little secret!";
					default:
						return "One can pray for the growth of countless tentacles for juggling items around... or one can simply use chests!";
				}
			}

        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
			ReducedGrindingPlayer mPlayer = Main.LocalPlayer.GetModPlayer<ReducedGrindingPlayer>();
            shop.item[nextSlot].SetDefaults(48); //Default Chest
			nextSlot++;
			if (Main.hardMode || !GetInstance< IOtherCustomNPCsConfig>().ChestSalesmanPreHardmodeChestsRequireHardmodeActivated)
			{
				if (GetInstance< IOtherCustomNPCsConfig>().ChestSalesmanSellsGoldChest)
				{
					shop.item[nextSlot].SetDefaults(306);
					nextSlot++;
				}
				if (GetInstance< IOtherCustomNPCsConfig>().ChestSalesmanSellsIceChest && (NPC.downedBoss1 || Main.hardMode)) //Eye of Cthulhu
				{
					shop.item[nextSlot].SetDefaults(681);
					nextSlot++;
				}
				if (GetInstance< IOtherCustomNPCsConfig>().ChestSalesmanSellsIvyChest && (NPC.downedBoss2 || Main.hardMode)) //Eater of Worlds or Brain of Cthulhu
				{
					shop.item[nextSlot].SetDefaults(680);
					nextSlot++;
				}
				if (GetInstance< IOtherCustomNPCsConfig>().ChestSalesmanSellsLivingWoodChest)
				{
					shop.item[nextSlot].SetDefaults(831);
					nextSlot++;
				}
				if (GetInstance< IOtherCustomNPCsConfig>().ChestSalesmanSellsSkywareChest && (NPC.downedBoss2 || Main.hardMode))
				{
					shop.item[nextSlot].SetDefaults(838);
					nextSlot++;
				}
				if (GetInstance< IOtherCustomNPCsConfig>().ChestSalesmanSellsOceanChest)
				{
					shop.item[nextSlot].SetDefaults(1298);
					nextSlot++;
				}
				if (GetInstance< IOtherCustomNPCsConfig>().ChestSalesmanSellsWebCoveredChest && (NPC.downedBoss1 || Main.hardMode))
				{
					shop.item[nextSlot].SetDefaults(952);
					nextSlot++;
				}
				if (GetInstance< IOtherCustomNPCsConfig>().ChestSalesmanSellsShadowChest && (NPC.downedBoss3 || Main.hardMode)) //Skeletron
				{
					shop.item[nextSlot].SetDefaults(328); //Shadow Chest
					nextSlot++;
				}
			}
			if (NPC.downedGolemBoss && GetInstance< IOtherCustomNPCsConfig>().ChestSalesmanSellsLihzahrdChest){
				shop.item[nextSlot].SetDefaults(1142); //Lihzahrd Chest
				nextSlot++;
			}
			if (NPC.downedPlantBoss && GetInstance< IOtherCustomNPCsConfig>().ChestSalesmanSellsBiomeChests)
			{//Dungeon Chest
				shop.item[nextSlot].SetDefaults(1529);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(1530);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(1531);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(1532);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(1528);
				nextSlot++;
			}
        }

    }
}