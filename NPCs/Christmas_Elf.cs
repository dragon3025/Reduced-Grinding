using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;

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
            AnimationType = NPCID.SantaClaus;
        }
        public override bool CanTownNPCSpawn(int nextSlotTownNPCs, int money)
        {
            if (GetInstance<IOtherConfig>().ChristmasElf && NPC.downedFrost)
                return true;
            else
                return false;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>() {
                "Lilly",
                "Vanessa"
            };
        }

        public override string GetChat()
        {
            if (!Main.dayTime)
            {
                return Main.rand.Next(2) switch
                {
                    0 => "What a beautiful night, the stars are bright and shinning!",
                    _ => "What brings you here on this silent night?",
                };
            }
            else
            {
                return Main.rand.Next(4) switch
                {
                    0 => "Hmm Hmm Hmmmmmmm Hmm Hmm Hmmmmmmmmm, Jingle all the...oh hello there!",
                    1 => "I'm sorry I can't give you a discount, even if you've been good for goodness sake.",
                    2 => "Deck the halls with lights that you can purchase at my store.",
                    _ => "You better watch out, those slimes are tough.",
                };
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
            shop.item[nextSlot].SetDefaults(588);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(589);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(590);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(597);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(598);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(596);
            nextSlot++;
            for (int nextSlot22 = 1873; nextSlot22 < 1906; nextSlot22++)
            {
                shop.item[nextSlot].SetDefaults(nextSlot22);
                nextSlot++;
            }
        }
    }
}
