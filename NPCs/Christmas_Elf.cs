using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
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
            if (GetInstance<IOtherCustomNPCsConfig>().ChristmasElf && NPC.downedFrost)
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
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return "What a beautiful night, the stars are bright and shinning!";
                    default:
                        return "What brings you here on this silent night?";
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
