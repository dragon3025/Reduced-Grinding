using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18; //His hitbox, the visual width/height is affected by frame count below.
			npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            Main.npcFrameCount[npc.type] = 25;            
            animationType = NPCID.Guide;
        }
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
			ReducedGrindingPlayer mPlayer = Main.LocalPlayer.GetModPlayer<ReducedGrindingPlayer>();
			if (mPlayer.clientConf.ChestSalesman)
				return true;
			else
				return false;
        }

        public override string TownNPCName()
        {										//NPC names
            switch (Main.rand.Next(27))
            {
                case 0:
                    return "Chester";
                case 1:
                    return "Chad";
                case 2:
                    return "Charlie";
                case 3:
                    return "Chace";
                case 4:
					return "Benedict";
                case 5:
					return "Ranulph";
                case 6:
					return "Mike";
                case 7:
					return "Locke";
                case 8:
					return "John";
                case 9:
					return "Ferdinand";
                case 10:
					return "Lewis";
                case 11:
					return "Nicholas";
                case 12:
					return "Aron";
                case 13:
					return "Robert";
                case 14:
					return "Thor";
                case 15:
					return "Jones";
                case 16:
					return "Rolf";
                case 17:
					return "Tobin";
                case 18:
					return "Alexander";
                case 19:
					return "George";
                case 20:
					return "Francis";
                case 21:
					return "Montgomery";
                case 22:
					return "Mark";
                case 23:
					return "Ross";
                case 24:
					return "Adrian";
                case 25:
					return "Samuel";
                default:
					return "Randy";
            }
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
			if (Main.hardMode || !mPlayer.clientConf.ChestSalesmanPreHardmodeChestsRequireHardmodeActivated)
			{
				if (mPlayer.clientConf.ChestSalesmanSellsGoldChest)
				{
					shop.item[nextSlot].SetDefaults(306);
					nextSlot++;
				}
				if (mPlayer.clientConf.ChestSalesmanSellsIceChest && (NPC.downedBoss1 || Main.hardMode)) //Eye of Cthulhu
				{
					shop.item[nextSlot].SetDefaults(681);
					nextSlot++;
				}
				if (mPlayer.clientConf.ChestSalesmanSellsIvyChest && (NPC.downedBoss2 || Main.hardMode)) //Eater of Worlds or Brain of Cthulhu
				{
					shop.item[nextSlot].SetDefaults(680);
					nextSlot++;
				}
				if (mPlayer.clientConf.ChestSalesmanSellsLivingWoodChest)
				{
					shop.item[nextSlot].SetDefaults(831);
					nextSlot++;
				}
				if (mPlayer.clientConf.ChestSalesmanSellsSkywareChest && (NPC.downedBoss2 || Main.hardMode))
				{
					shop.item[nextSlot].SetDefaults(838);
					nextSlot++;
				}
				if (mPlayer.clientConf.ChestSalesmanSellsOceanChest)
				{
					shop.item[nextSlot].SetDefaults(1298);
					nextSlot++;
				}
				if (mPlayer.clientConf.ChestSalesmanSellsWebCoveredChest && (NPC.downedBoss1 || Main.hardMode))
				{
					shop.item[nextSlot].SetDefaults(952);
					nextSlot++;
				}
				if (mPlayer.clientConf.ChestSalesmanSellsShadowChest && (NPC.downedBoss3 || Main.hardMode)) //Skeletron
				{
					shop.item[nextSlot].SetDefaults(328); //Shadow Chest
					nextSlot++;
				}
			}
			if (NPC.downedGolemBoss && mPlayer.clientConf.ChestSalesmanSellsLihzahrdChest){
				shop.item[nextSlot].SetDefaults(1142); //Lihzahrd Chest
				nextSlot++;
			}
			if (NPC.downedPlantBoss && mPlayer.clientConf.ChestSalesmanSellsBiomeChests)
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