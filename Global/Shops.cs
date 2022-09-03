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
                Main.NewText("Quests completed: " + player.anglerQuestsFinished.ToString(), 0, 255, 255); //Localize
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            switch (type)
            {
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
                        for (int i = 0; i <= 40; i++)
                        {
                            if (shop.item[i].type == ItemID.TeleportationPylonVictory)
                            {
                                sellingUniversalPylon = true;
                                break;
                            }
                        }
                        if (!sellingUniversalPylon && bestiaryProgressReport.CompletionPercent >= GetInstance<IOtherConfig>().UniversalPylonBestiaryCompletionRate)
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.TeleportationPylonVictory);
                            nextSlot++;
                        }
                        if (GetInstance<HOtherModdedItemsConfig>().BestiaryTrophy && bestiaryProgressReport.CompletionPercent >= 1f)
                        {
                            shop.item[nextSlot].SetDefaults(ItemType<Items.Placeable.BestiaryTrophy>());
                            nextSlot++;
                        }
                    }
                    break;
            }
        }

        public override void SetupTravelShop(int[] shop, ref int nextSlot)
        {
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
            int amountToAdd = GetInstance<IOtherConfig>().TravelingMerchantExtraRolls;
            int itemsAdded = 0;
            int[] itemChance = new int[6]
            {
                    100,
                    200,
                    300,
                    400,
                    500,
                    600
            };
            while (itemsAdded < amountToAdd)
            {
                int shopItem = 0;
                if (player.RollLuck(itemChance[4]) == 0)
                {
                    shopItem = 3309;
                }
                if (player.RollLuck(itemChance[3]) == 0)
                {
                    shopItem = 3314;
                }
                if (player.RollLuck(itemChance[5]) == 0)
                {
                    shopItem = 1987;
                }
                if (player.RollLuck(itemChance[4]) == 0 && Main.hardMode)
                {
                    shopItem = 2270;
                }
                if (player.RollLuck(itemChance[4]) == 0 && Main.hardMode)
                {
                    shopItem = 4760;
                }
                if (player.RollLuck(itemChance[4]) == 0)
                {
                    shopItem = 2278;
                }
                if (player.RollLuck(itemChance[4]) == 0)
                {
                    shopItem = 2271;
                }
                if (player.RollLuck(itemChance[4]) == 0 && (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3 || NPC.downedQueenBee || Main.hardMode))
                {
                    shopItem = 4347;
                    if (Main.hardMode)
                    {
                        shopItem = 4348;
                    }
                }
                if (player.RollLuck(itemChance[3]) == 0 && Main.hardMode && NPC.downedPlantBoss)
                {
                    shopItem = 2223;
                }
                if (player.RollLuck(itemChance[3]) == 0)
                {
                    shopItem = 2272;
                }
                if (player.RollLuck(itemChance[3]) == 0)
                {
                    shopItem = 2219;
                }
                if (player.RollLuck(itemChance[3]) == 0)
                {
                    shopItem = 2276;
                }
                if (player.RollLuck(itemChance[3]) == 0)
                {
                    shopItem = 2284;
                }
                if (player.RollLuck(itemChance[3]) == 0)
                {
                    shopItem = 2285;
                }
                if (player.RollLuck(itemChance[3]) == 0)
                {
                    shopItem = 2286;
                }
                if (player.RollLuck(itemChance[3]) == 0)
                {
                    shopItem = 2287;
                }
                if (player.RollLuck(itemChance[3]) == 0)
                {
                    shopItem = 4744;
                }
                if (player.RollLuck(itemChance[3]) == 0 && NPC.downedBoss3)
                {
                    shopItem = 2296;
                }
                if (player.RollLuck(itemChance[3]) == 0)
                {
                    shopItem = 3628;
                }
                if (player.RollLuck(itemChance[3]) == 0 && Main.hardMode)
                {
                    shopItem = 4091;
                }
                if (player.RollLuck(itemChance[3]) == 0)
                {
                    shopItem = 4603;
                }
                if (player.RollLuck(itemChance[3]) == 0)
                {
                    shopItem = 4604;
                }
                if (player.RollLuck(itemChance[3]) == 0)
                {
                    shopItem = 4605;
                }
                if (player.RollLuck(itemChance[3]) == 0)
                {
                    shopItem = 4550;
                }
                if (player.RollLuck(itemChance[2]) == 0 && NPC.downedBoss2) //TO-DO Switch this to testing for bullet or rifle.
                {
                    shopItem = 2269;
                }
                if (player.RollLuck(itemChance[2]) == 0)
                {
                    shopItem = 2177;
                }
                if (player.RollLuck(itemChance[2]) == 0)
                {
                    shopItem = 1988;
                }
                if (player.RollLuck(itemChance[2]) == 0)
                {
                    shopItem = 2275;
                }
                if (player.RollLuck(itemChance[2]) == 0)
                {
                    shopItem = 2279;
                }
                if (player.RollLuck(itemChance[2]) == 0)
                {
                    shopItem = 2277;
                }
                if (player.RollLuck(itemChance[2]) == 0)
                {
                    shopItem = 4555;
                }
                if (player.RollLuck(itemChance[2]) == 0)
                {
                    shopItem = 4321;
                }
                if (player.RollLuck(itemChance[2]) == 0)
                {
                    shopItem = 4323;
                }
                if (player.RollLuck(itemChance[2]) == 0)
                {
                    shopItem = 4549;
                }
                if (player.RollLuck(itemChance[2]) == 0)
                {
                    shopItem = 4561;
                }
                if (player.RollLuck(itemChance[2]) == 0)
                {
                    shopItem = 4774;
                }
                if (player.RollLuck(itemChance[2]) == 0)
                {
                    shopItem = 4562;
                }
                if (player.RollLuck(itemChance[2]) == 0)
                {
                    shopItem = 4558;
                }
                if (player.RollLuck(itemChance[2]) == 0)
                {
                    shopItem = 4559;
                }
                if (player.RollLuck(itemChance[2]) == 0)
                {
                    shopItem = 4563;
                }
                if (player.RollLuck(itemChance[2]) == 0)
                {
                    shopItem = 4666;
                }
                if (player.RollLuck(itemChance[2]) == 0 && NPC.downedBoss1)
                {
                    shopItem = 3262;
                }
                if (player.RollLuck(itemChance[2]) == 0 && NPC.downedMechBossAny)
                {
                    shopItem = 3284;
                }
                if (player.RollLuck(itemChance[2]) == 0 && Main.hardMode && NPC.downedMoonlord)
                {
                    shopItem = 3596;
                }
                if (player.RollLuck(itemChance[2]) == 0 && Main.hardMode && NPC.downedMartians)
                {
                    shopItem = 2865;
                }
                if (player.RollLuck(itemChance[2]) == 0 && Main.hardMode && NPC.downedMartians)
                {
                    shopItem = 2866;
                }
                if (player.RollLuck(itemChance[2]) == 0 && Main.hardMode && NPC.downedMartians)
                {
                    shopItem = 2867;
                }
                if (player.RollLuck(itemChance[2]) == 0 && Main.xMas)
                {
                    shopItem = 3055;
                }
                if (player.RollLuck(itemChance[2]) == 0 && Main.xMas)
                {
                    shopItem = 3056;
                }
                if (player.RollLuck(itemChance[2]) == 0 && Main.xMas)
                {
                    shopItem = 3057;
                }
                if (player.RollLuck(itemChance[2]) == 0 && Main.xMas)
                {
                    shopItem = 3058;
                }
                if (player.RollLuck(itemChance[2]) == 0 && Main.xMas)
                {
                    shopItem = 3059;
                }
                if (player.RollLuck(itemChance[1]) == 0)
                {
                    shopItem = 2214;
                }
                if (player.RollLuck(itemChance[1]) == 0)
                {
                    shopItem = 2215;
                }
                if (player.RollLuck(itemChance[1]) == 0)
                {
                    shopItem = 2216;
                }
                if (player.RollLuck(itemChance[1]) == 0)
                {
                    shopItem = 2217;
                }
                if (player.RollLuck(itemChance[1]) == 0)
                {
                    shopItem = 3624;
                }
                if (player.RollLuck(itemChance[1]) == 0)
                {
                    shopItem = 2273;
                }
                if (player.RollLuck(itemChance[1]) == 0)
                {
                    shopItem = 2274;
                }
                if (player.RollLuck(itemChance[0]) == 0)
                {
                    shopItem = 2266;
                }
                if (player.RollLuck(itemChance[0]) == 0)
                {
                    shopItem = 2267;
                }
                if (player.RollLuck(itemChance[0]) == 0)
                {
                    shopItem = 2268;
                }
                if (player.RollLuck(itemChance[0]) == 0)
                {
                    shopItem = 2281 + Main.rand.Next(3);
                }
                if (player.RollLuck(itemChance[0]) == 0)
                {
                    shopItem = 2258;
                }
                if (player.RollLuck(itemChance[0]) == 0)
                {
                    shopItem = 2242;
                }
                if (player.RollLuck(itemChance[0]) == 0)
                {
                    shopItem = 2260;
                }
                if (player.RollLuck(itemChance[0]) == 0)
                {
                    shopItem = 3637;
                }
                if (player.RollLuck(itemChance[0]) == 0)
                {
                    shopItem = 4420;
                }
                if (player.RollLuck(itemChance[0]) == 0)
                {
                    shopItem = 3119;
                }
                if (player.RollLuck(itemChance[0]) == 0)
                {
                    shopItem = 3118;
                }
                if (player.RollLuck(itemChance[0]) == 0)
                {
                    shopItem = 3099;
                }
                if (shopItem != 0)
                {
                    for (int k = 0; k < 40; k++)
                    {
                        if (Main.travelShop[k] == shopItem)
                        {
                            shopItem = 0;
                            break;
                        }
                        if (shopItem == 3637)
                        {
                            int num5 = Main.travelShop[k];
                            if ((uint)(num5 - 3621) <= 1u || (uint)(num5 - 3633) <= 9u)
                            {
                                shopItem = 0;
                            }
                            if (shopItem == 0)
                            {
                                break;
                            }
                        }
                    }
                }
                itemsAdded++;
                if (shopItem == 0)
                {
                    continue;
                }
                Main.travelShop[nextSlot] = shopItem;
                nextSlot++;
                if (shopItem == 2260)
                {
                    Main.travelShop[nextSlot] = 2261;
                    nextSlot++;
                    Main.travelShop[nextSlot] = 2262;
                    nextSlot++;
                }
                if (shopItem == 4555)
                {
                    Main.travelShop[nextSlot] = 4556;
                    nextSlot++;
                    Main.travelShop[nextSlot] = 4557;
                    nextSlot++;
                }
                if (shopItem == 4321)
                {
                    Main.travelShop[nextSlot] = 4322;
                    nextSlot++;
                }
                if (shopItem == 4323)
                {
                    Main.travelShop[nextSlot] = 4324;
                    nextSlot++;
                    Main.travelShop[nextSlot] = 4365;
                    nextSlot++;
                }
                if (shopItem == 4666)
                {
                    Main.travelShop[nextSlot] = 4664;
                    nextSlot++;
                    Main.travelShop[nextSlot] = 4665;
                    nextSlot++;
                }
                if (shopItem == 3637)
                {
                    nextSlot--;
                    switch (Main.rand.Next(6))
                    {
                        case 0:
                            Main.travelShop[nextSlot++] = 3637;
                            Main.travelShop[nextSlot++] = 3642;
                            break;
                        case 1:
                            Main.travelShop[nextSlot++] = 3621;
                            Main.travelShop[nextSlot++] = 3622;
                            break;
                        case 2:
                            Main.travelShop[nextSlot++] = 3634;
                            Main.travelShop[nextSlot++] = 3639;
                            break;
                        case 3:
                            Main.travelShop[nextSlot++] = 3633;
                            Main.travelShop[nextSlot++] = 3638;
                            break;
                        case 4:
                            Main.travelShop[nextSlot++] = 3635;
                            Main.travelShop[nextSlot++] = 3640;
                            break;
                        case 5:
                            Main.travelShop[nextSlot++] = 3636;
                            Main.travelShop[nextSlot++] = 3641;
                            break;
                    }
                }
            }
            #endregion

            #region Individual Item Rolls
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