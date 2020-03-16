using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.NPCs
{
	[AutoloadHead]
    public class Christmas_Elf : ModNPC
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Christmas Elf");
		}
		
        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 20; //His hitbox, the visual width/height is affected by frame count below.
            npc.height = 38;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            Main.npcFrameCount[npc.type] = 26;
            animationType = NPCID.SantaClaus;
        }
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
			if (GetInstance<IOtherCustomNPCsConfig>().ChristmasElf && NPC.downedFrost)
				return true;
			else
				return false;
        }

		public override string TownNPCName()
		{
			switch (Main.rand.Next(2)) //Names are requrest by sprite artist, Lonley Star; don't change them.
			{
				case 0:
					return "Lilly";
				default:
					return "Vanessa";
			}
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
				switch (Main.rand.Next(4))
				{
					case 0:
						return "Hmm Hmm Hmmmmmmm Hmm Hmm Hmmmmmmmmm, Jingle all the...oh hello there!";
					case 1:
						return "I'm sorry I can't give you a discount, even if you've been good for goodness sake.";
					case 2:
						return "Deck the halls with lights that you can purchase at my store.";
					default:
						return "You better watch out, those slimes are tough.";
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
			int i = 0;
			for (i = 588; i <= 590; i++)
			{
				shop.item[nextSlot].SetDefaults(i);
				nextSlot++;
			}
			for (i = 1873; i <= 1905; i++)
			{
				shop.item[nextSlot].SetDefaults(i);
				nextSlot++;
			}
		}
    }
}
