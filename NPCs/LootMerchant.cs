using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;

namespace ReducedGrinding.NPCs
{
    [AutoloadHead]
    public class LootMerchant : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Loot Merchant");
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 22; //His hitbox, the visual width/height is affected by frame count below.
            NPC.height = 42;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            Main.npcFrameCount[Type] = 26;
            AnimationType = NPCID.Merchant;
        }
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (GetInstance<IOtherConfig>().LootMerchant)
                return true;
            else
                return false;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>() {
                "Dalton",
                "Hall",
                "Zack",
                "Lewin",
                "Kenton",
                "James",
                "Kameron",
                "Reggie",
                "Murphy",
                "Harlan",
                "Manny",
                "Raine",
                "Buddy",
                "Carleton",
                "Gale",
                "Wilson",
                "Darien",
                "Cedric",
                "Walt",
                "Jensen",
                "Thorley",
                "Desmond",
                "Rylan",
                "Doug",
                "Ralf",
                "Oakley",
                "Dudley"
            };
        }

        public override string GetChat()
        {
            switch (Main.rand.Next(4))
            {
                case 0:
                    return "I like to collect loot from monsters and a little mining, want to buy any?";
                case 1:
                    return "If you're looking for loot, you've come to the right place.";
                case 2:
                    return "Looking for loot?";
                default:
                    return "You could kill some mobs for their loot, or you could buy them from me.";
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
            int gameProgress = 0;
            if (NPC.downedSlimeKing)
                gameProgress = 1;
            if (NPC.downedBoss1)
                gameProgress = 2;
            if (NPC.downedBoss2)
                gameProgress = 3;
            if (NPC.downedBoss3)
                gameProgress = 4;
            if (Main.hardMode)
                gameProgress = 5;
            if (NPC.downedPlantBoss)
                gameProgress = 6;
            if (NPC.downedGolemBoss)
                gameProgress = 7;

            shop.item[nextSlot].SetDefaults(ItemID.Gel);
            nextSlot++;
            if (WorldGen.goldBar == ItemID.GoldBar)
                shop.item[nextSlot].SetDefaults(ItemID.GoldOre);
            else
                shop.item[nextSlot].SetDefaults(ItemID.PlatinumOre);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Ruby);
            nextSlot++;
            if (gameProgress > 0)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Lens);
                nextSlot++;
            }
            if (gameProgress > 1)
            {
                if (WorldGen.crimson)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.ViciousPowder);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.Vertebrae);
                    nextSlot++;
                }
                else
                {
                    shop.item[nextSlot].SetDefaults(ItemID.VilePowder);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.RottenChunk);
                    nextSlot++;
                }
            }
            if (gameProgress > 2)
            {
                {
                    shop.item[nextSlot].SetDefaults(ItemID.BottledHoney);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.Stinger);
                    nextSlot++;
                }
            }
            if (gameProgress > 3)
            {
                {
                    //While all other summon material is sold right before the next boss, this is sold after Skeletron, because it has no use until then.
                    shop.item[nextSlot].SetDefaults(ItemID.ClothierVoodooDoll);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.GuideVoodooDoll);
                    nextSlot++;
                }
            }
            if (gameProgress > 4)
            {
                {
                    shop.item[nextSlot].SetDefaults(WorldGen.ironBar);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.SoulofLight);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.SoulofNight);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.Bone);
                    nextSlot++;
                }
            }
            if (gameProgress > 5)
            {
                {
                    shop.item[nextSlot].SetDefaults(ItemID.LihzahrdPowerCell);
                    nextSlot++;
                }
            }
            if (gameProgress > 6)
            {
                {
                    shop.item[nextSlot].SetDefaults(ItemID.TruffleWorm);
                    nextSlot++;
                }
            }
        }
    }
}