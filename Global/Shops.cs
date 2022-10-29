using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class Shops : GlobalNPC
    {
        public override void GetChat(NPC npc, ref string chat)
        {
            Player player = Main.player[Main.myPlayer];
            if (npc.type == NPCID.Angler)
            {
                Main.NewText("Quests completed: " + player.anglerQuestsFinished.ToString(), 0, 255, 255);
                if (GetInstance<CFishingConfig>().FishCoinsRewardedForQuest > 0)
                {
                    bool spawnFishMerchant = true;
                    int fishMerchantID = NPCType<NPCs.FishMerchant>();
                    int anglerNPC = -1;
                    for (int i = 0; i < Main.npc.Length; i++)
                    {
                        if (spawnFishMerchant && Main.npc[i].type == fishMerchantID)
                        {
                            spawnFishMerchant = false;
                            break;
                        }
                        if (anglerNPC == -1 && Main.npc[i].type == NPCID.Angler)
                            anglerNPC = i;
                    }
                    if (spawnFishMerchant)
                    {
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                            NPC.SpawnOnPlayer(player.whoAmI, fishMerchantID);
                        else
                            NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: fishMerchantID);
                        for (int i = 0; i < Main.npc.Length; i++)
                        {
                            if (Main.npc[i].type == fishMerchantID)
                            {
                                Main.npc[i].position = Main.npc[anglerNPC].position;
                                if (Main.netMode == NetmodeID.MultiplayerClient)
                                    NetMessage.SendData(MessageID.WorldData);
                                break;
                            }
                        }
                    }
                }
            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            switch (type)
            {
                case NPCID.Mechanic:
                    shop.item[nextSlot].SetDefaults(ItemID.Teleporter); //Remove when 1.4.4+ Comes out
                    nextSlot++;
                    break;
                case NPCID.Merchant:
                    if (GetInstance<IOtherConfig>().MerchantSellsMinersShirtAndPants)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.MiningShirt);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.MiningPants);
                        nextSlot++;
                    }
                    if (GetInstance<IOtherConfig>().HolidayTimelineDaysPerMonth > 0)
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<Items.Placeable.Calendar>());
                        nextSlot++;
                    }
                    break;
                case NPCID.SkeletonMerchant:
                    if (GetInstance<IOtherConfig>().SkeletonMerchantIgnoresMoonphases)
                    {
                        List<int> shopItems = new() {
                            ItemID.StrangeBrew,
                            ItemID.LesserHealingPotion,
                            ItemID.SpelunkerGlowstick,
                            ItemID.Glowstick,
                            ItemID.BoneTorch,
                            ItemID.WoodenArrow,
                            ItemID.BlueCounterweight,
                            ItemID.RedCounterweight,
                            ItemID.PurpleCounterweight,
                            ItemID.GreenCounterweight,
                            ItemID.Bomb,
                            ItemID.Rope,
                            ItemID.MagicLantern
                        };

                        if (Main.hardMode)
                        {
                            shopItems.Add(ItemID.Gradient);
                            shopItems.Add(ItemID.FormatC);
                            shopItems.Add(ItemID.YoYoGlove);
                            if (Main.bloodMoon)
                                shopItems.Add(ItemID.SlapHand);
                        }

                        foreach (int i in shopItems)
                        {
                            bool addItem = true;
                            for (int j = 0; j < 40; j++)
                            {
                                if (shop.item[j].type == i)
                                {
                                    addItem = false;
                                    break;
                                }
                            }
                            if (addItem)
                            {
                                shop.item[nextSlot].SetDefaults(i);
                                nextSlot++;
                            }
                        }
                    }
                    break;
                case NPCID.BestiaryGirl:
                    if (GetInstance<IOtherConfig>().UniversalPylonBestiaryCompletionRate < 1f)
                    {
                        BestiaryUnlockProgressReport bestiaryProgressReport = Main.GetBestiaryProgressReport();
                        bool sellingUniversalPylon = false;
                        bool sellingDiggingMoleMinecart = false; //TO-DO Remove when 1.4.4+ comes out
                        for (int i = 0; i <= 40; i++)
                        {
                            if (shop.item[i].type == ItemID.TeleportationPylonVictory)
                                sellingUniversalPylon = true;
                            if (shop.item[i].type == ItemID.DiggingMoleMinecart)
                                sellingDiggingMoleMinecart = true;
                            if (sellingUniversalPylon && sellingDiggingMoleMinecart)
                                break;
                        }
                        if (!sellingUniversalPylon && bestiaryProgressReport.CompletionPercent >= GetInstance<IOtherConfig>().UniversalPylonBestiaryCompletionRate)
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.TeleportationPylonVictory);
                            nextSlot++;
                        }
                        if (!sellingDiggingMoleMinecart && bestiaryProgressReport.CompletionPercent >= 0.35f)
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.DiggingMoleMinecart);
                            nextSlot++;
                        }
                        if (GetInstance<HOtherModdedItemsConfig>().BestiaryTrophy && bestiaryProgressReport.CompletionPercent >= 1f)
                        {
                            shop.item[nextSlot].SetDefaults(ItemType<Items.Placeable.BestiaryTrophy>());
                            nextSlot++;
                        }
                    }
                    break;
                case NPCID.WitchDoctor:
                    if (GetInstance<IOtherConfig>().WitchDoctorSellsChlorophyteOreAfterPlantera && NPC.downedPlantBoss)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.ChlorophyteOre);
                        nextSlot++;
                    }
                    break;
            }
        }

        public override void SetupTravelShop(int[] shop, ref int nextSlot)
        {
            bool sellMerchantDice = false;
            if (Main.hardMode)
            {
                if (NPC.downedPlantBoss)
                {
                    if (GetInstance<IOtherConfig>().TravelingMerchantDiceUsesAfterPlantera > 0)
                        sellMerchantDice = true;
                }
                else if (GetInstance<IOtherConfig>().TravelingMerchantDiceUsesHardmode > 0)
                    sellMerchantDice = true;
            }
            else if (GetInstance<IOtherConfig>().TravelingMerchantDiceUsesBeforeHardmode > 0)
                sellMerchantDice = true;

            if (sellMerchantDice)
            {
                Main.travelShop[nextSlot] = ItemType<Items.MerchantDice>();
                nextSlot++;
            }

            Player player = null;
            for (int j = 0; j < 255; j++)
            {
                Player player2 = Main.player[j];
                if (player2.active && (player == null || player.luck < player2.luck))
                {
                    player = player2;
                }
            }
            if (player == null)
            {
                player = new Player();
            }

            #region Extra Item Rolls
            if (NPC.downedMartians && GetInstance<IOtherConfig>().TravelingMerchantMartianChance > 0)
            {
                int[] items = new int[] {
                        2865,
                        2866,
                        2867
                    };
                foreach (int i in items)
                {
                    bool addItem = true;
                    for (int k = 0; k < 40; k++)
                    {
                        if (Main.travelShop[k] == i)
                        {
                            addItem = false;
                            break;
                        }
                    }
                    if (addItem && player.RollLuck(GetInstance<IOtherConfig>().TravelingMerchantMartianChance) == 0)
                    {
                        Main.travelShop[nextSlot] = i;
                        nextSlot++;
                    }
                }
            }

            if (Main.xMas && GetInstance<IOtherConfig>().TravelingMerchantChristmasChance > 0)
            {
                int[] items = new int[] {
                        3055,
                        3056,
                        3057,
                        3058
                    };
                foreach (int i in items)
                {
                    bool addItem = true;
                    for (int k = 0; k < 40; k++)
                    {
                        if (Main.travelShop[k] == i)
                        {
                            addItem = false;
                            break;
                        }
                    }
                    if (addItem && player.RollLuck(GetInstance<IOtherConfig>().TravelingMerchantChristmasChance) == 0)
                    {
                        Main.travelShop[nextSlot] = i;
                        nextSlot++;
                    }
                }
            }

            if (NPC.downedMoonlord && GetInstance<IOtherConfig>().TravelingMerchantNotAKidNorASquidChance > 0)
            {
                if (player.RollLuck(GetInstance<IOtherConfig>().TravelingMerchantNotAKidNorASquidChance) == 0)
                {
                    bool addItem = true;
                    for (int k = 0; k < 40; k++)
                    {
                        if (Main.travelShop[k] == 3596)
                        {
                            addItem = false;
                            break;
                        }
                    }
                    if (addItem)
                    {
                        Main.travelShop[nextSlot] = 3596;
                        nextSlot++;
                    }
                }
            }

            if (NPC.downedPlantBoss && GetInstance<IOtherConfig>().TravelingMerchantPulseBowChance > 0)
            {
                if (player.RollLuck(GetInstance<IOtherConfig>().TravelingMerchantPulseBowChance) == 0)
                {
                    bool addItem = true;
                    for (int k = 0; k < 40; k++)
                    {
                        if (Main.travelShop[k] == ItemID.PulseBow)
                        {
                            addItem = false;
                            break;
                        }
                    }
                    if (addItem)
                    {
                        Main.travelShop[nextSlot] = ItemID.PulseBow;
                        nextSlot++;
                    }
                }
            }
            #endregion
        }
    }
}