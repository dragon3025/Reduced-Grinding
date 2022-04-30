using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System.Collections.Generic;

namespace ReducedGrinding.NPCs
{
	[AutoloadHead]
    public class BoneMerchant : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bone Merchant");
		}

		public override void SetDefaults()
		{
			NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 20; //His hitbox, the visual width/height is affected by frame count below.
            NPC.height = 38;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            Main.npcFrameCount[Type] = 26;
			AnimationType = NPCID.SkeletonMerchant;
        }
        public override bool CanTownNPCSpawn(int nextSlotTownNPCs, int money)
        {
			return false; //He's summoned with a Skull Call.
        }

		public override List<string> SetNPCNameList()
		{
			return new List<string> {
				"Billy Marrows",
				"Gloomy Mays",
				"No-Eyed Wiley",
				"Skellington",
				"Bones McGee",
				"Jack Sellington",
				"Mika",
				"Rattles Magoo",
				"Tom"
			};
		}

		public override string GetChat()
		{
			if (!Main.dayTime)
			{
				switch (Main.rand.Next(2))
				{
					case 0:
						return "What a beautiful night, the stars are bright and shinning!";
					default:
						return "What brings you here, on this calm, silent night?";
				}
			}
			else
			{
				switch (Main.rand.Next(7))
				{
					case 0:
						return "You would not believe some of the things people throw at me... Wanna buy some of it?";
					case 1:
						return "I'd lend you a hand, but last time I did that, I didn't get it back for a month.";
					case 2:
						return "Stay away from the spiders. They'll suck out your insides and leave you a hollow shell of a man. Trust me on this one.";
					case 3:
						return "Excellent! Someone's finally come by to take some of these maggots off my hands.";
					case 4:
						return "There's no illness or condition that can't be cured by some of my Slime Oil! Trust me, it works, just look at my lively figure!";
					case 5:
						return "The only things constant in this world are death and taxes, I've got both!";
					default:
						return "Got any spare bones for sale? I'm looking to replace my broken hip... again.";
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
			Player player = Main.player[Main.myPlayer];
			if (player.HasItem(ModContent.ItemType<Items.Moon_Ball>()))
			{
				shop.item[nextSlot].SetDefaults(3001);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(28);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(3002);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(282);
				nextSlot++;
				if (Main.time % 60.0 * 60.0 * 6.0 <= 10800.0)
				{
					shop.item[nextSlot].SetDefaults(3004);
				}
				else
				{
					shop.item[nextSlot].SetDefaults(8);
				}
				nextSlot++;
				shop.item[nextSlot].SetDefaults(3003);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(40);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(3310);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(3313);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(3312);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(3311);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(166);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(965);
				nextSlot++;
				if (Main.hardMode)
				{
					shop.item[nextSlot].SetDefaults(3316);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(3315);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(3334);
					nextSlot++;
					if (Main.bloodMoon)
					{
						shop.item[nextSlot].SetDefaults(3258);
						nextSlot++;
					}
				}
				shop.item[nextSlot].SetDefaults(3043);
				nextSlot++;
			}
			else
			{
				if (Main.moonPhase % 2 == 0)
				{
					shop.item[nextSlot].SetDefaults(3001);
				}
				else
				{
					shop.item[nextSlot].SetDefaults(28);
				}
				nextSlot++;
				if (!Main.dayTime || Main.moonPhase == 0)
				{
					shop.item[nextSlot].SetDefaults(3002);
				}
				else
				{
					shop.item[nextSlot].SetDefaults(282);
				}
				nextSlot++;
				if (Main.time % 60.0 * 60.0 * 6.0 <= 10800.0)
				{
					shop.item[nextSlot].SetDefaults(3004);
				}
				else
				{
					shop.item[nextSlot].SetDefaults(8);
				}
				nextSlot++;
				if (Main.moonPhase == 0 || Main.moonPhase == 1 || Main.moonPhase == 4 || Main.moonPhase == 5)
				{
					shop.item[nextSlot].SetDefaults(3003);
				}
				else
				{
					shop.item[nextSlot].SetDefaults(40);
				}
				nextSlot++;
				if (Main.moonPhase % 4 == 0)
				{
					shop.item[nextSlot].SetDefaults(3310);
				}
				else if (Main.moonPhase % 4 == 1)
				{
					shop.item[nextSlot].SetDefaults(3313);
				}
				else if (Main.moonPhase % 4 == 2)
				{
					shop.item[nextSlot].SetDefaults(3312);
				}
				else
				{
					shop.item[nextSlot].SetDefaults(3311);
				}
				nextSlot++;
				shop.item[nextSlot].SetDefaults(166);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(965);
				nextSlot++;
				if (Main.hardMode)
				{
					if (Main.moonPhase < 4)
					{
						shop.item[nextSlot].SetDefaults(3316);
					}
					else
					{
						shop.item[nextSlot].SetDefaults(3315);
					}
					nextSlot++;
					shop.item[nextSlot].SetDefaults(3334);
					nextSlot++;
					if (Main.bloodMoon)
					{
						shop.item[nextSlot].SetDefaults(3258);
						nextSlot++;
					}
				}
				if (Main.moonPhase == 0 && !Main.dayTime)
				{
					shop.item[nextSlot].SetDefaults(3043);
					nextSlot++;
				}
			}
		}
    }
}
