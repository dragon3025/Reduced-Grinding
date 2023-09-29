using ReducedGrinding.Configuration;
using ReducedGrinding.Items;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.GlobalNPCs
{
    public class Shops : GlobalNPC
    {
        readonly static CFishingConfig fishingConfig = GetInstance<CFishingConfig>();

        public override void OnChatButtonClicked(NPC npc, bool firstButton)
        {
            if (npc.type == NPCID.Angler && firstButton)
            {
                if (Main.netMode == NetmodeID.MultiplayerClient && Global.Update.anglerQuests > 1 && !Main.LocalPlayer.HasItem(ItemType<FishingTicket>()))
                {
                    EntitySource_Gift source = new(npc);
                    Main.LocalPlayer.QuickSpawnItem(source, ItemType<FishingTicket>());
                }

                if (Main.netMode != NetmodeID.Server && fishingConfig.Angler.AnglerChatsCurrentQuest)
                {
                    Global.Update.chatQuestFish = true;

                    if (Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        ModPacket packet = Mod.GetPacket();
                        packet.Write((byte)ReducedGrinding.MessageType.chatQuestFish);
                        packet.Write(Global.Update.chatQuestFish);
                        packet.Send();
                    }
                }
            }
        }

        public override void GetChat(NPC npc, ref string chat)
        {
            if (npc.type == NPCID.Angler)
            {
                Player player = Main.LocalPlayer;
                if (fishingConfig.Angler.AnglerTellsQuestCompleted)
                {
                    chat += $"\n\nYou've given me {player.anglerQuestsFinished} fish.";
                }

                if (Global.Update.anglerQuests == -1)
                {
                    int StartingQuestPerDay = fishingConfig.Angler.StartingQuestPerDay;
                    int EndGameQuestPerDay = fishingConfig.Angler.EndGameQuestPerDay;

                    if (EndGameQuestPerDay > 1 && EndGameQuestPerDay > StartingQuestPerDay)
                    {
                        Global.Update.anglerQuests = StartingQuestPerDay;

                        float happiness = (float)(2.0 - player.currentShoppingSettings.PriceAdjustment);
                        int endGameQuestAmount = (int)(EndGameQuestPerDay * happiness - Global.Update.anglerQuests);

                        if (endGameQuestAmount > 0)
                        {
                            int questAmountConditionBonus = 0;

                            bool[] extraQuestConditions = new bool[13]
                            {
                        NPC.downedBoss1,
                        NPC.downedBoss2,
                        NPC.downedBoss3,
                        NPC.downedQueenBee,
                        NPC.downedQueenSlime,
                        NPC.downedMechBoss1,
                        NPC.downedMechBoss2,
                        NPC.downedMechBoss3,
                        NPC.downedPlantBoss,
                        NPC.downedGolemBoss,
                        NPC.downedEmpressOfLight,
                        NPC.downedAncientCultist,
                        Main.hardMode
                            };

                            for (int i = 0; i < extraQuestConditions.Length; i++)
                            {
                                if (extraQuestConditions[i] == true)
                                {
                                    questAmountConditionBonus += i < 4 ? 3 : i < 8 ? 6 : i < 12 ? 8 : 12;
                                }
                            }

                            Global.Update.anglerQuests += endGameQuestAmount * questAmountConditionBonus / 80;
                        }

                        if (Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            ModPacket packet = Mod.GetPacket();

                            packet.Write((byte)ReducedGrinding.MessageType.anglerQuests);
                            packet.Write(Global.Update.anglerQuests);

                            packet.Send();
                        }
                    }
                }
            }
        }

        public override void ModifyShop(NPCShop shop)
        {
            switch (shop.NpcType)
            {
                case NPCID.Pirate:
                    if (GetInstance<CFishingConfig>().FishCoinsRewardedForQuest > 0)
                    {
                        void addShopItem(int price, int itemID)
                        {
                            if (price > 0)
                            {

                                shop.Add(new Item(itemID)
                                {
                                    shopCustomPrice = price,
                                    shopSpecialCurrency = ReducedGrinding.FishCoin
                                });
                            }
                        }

                        #region Guaranteed Items
                        addShopItem(5, ItemID.FuzzyCarrot);
                        addShopItem(10, ItemID.AnglerHat);
                        addShopItem(10, ItemID.AnglerVest);
                        addShopItem(10, ItemID.AnglerPants);
                        addShopItem(25, ItemID.BottomlessBucket);
                        addShopItem(30, ItemID.GoldenFishingRod);
                        #endregion

                        #region Hardmode Items
                        if (Main.hardMode)
                        {
                            addShopItem(100, ItemID.HotlineFishingHook);
                            addShopItem(70, ItemID.FinWings);
                            addShopItem(70, ItemID.SuperAbsorbantSponge);
                        }
                        #endregion

                        #region Items Always Available
                        addShopItem(80, ItemID.GoldenBugNet);
                        addShopItem(60, ItemID.FishHook);
                        addShopItem(60, ItemID.FishMinecart);
                        addShopItem(80, ItemID.HighTestFishingLine);
                        addShopItem(80, ItemID.AnglerEarring);
                        addShopItem(80, ItemID.TackleBox);
                        addShopItem(60, ItemID.FishermansGuide);
                        addShopItem(60, ItemID.WeatherRadio);
                        addShopItem(60, ItemID.Sextant);
                        addShopItem(80, ItemType<MermaidCostumeBag>());
                        addShopItem(80, ItemType<FishCostumeBag>());
                        addShopItem(25, ItemID.FishingBobber);
                        #endregion
                    }
                    break;
                case NPCID.SkeletonMerchant:
                    shop.InsertBefore(ItemID.Torch, ItemID.BoneTorch);
                    if (!shop.TryGetEntry(ItemID.Torch, out _))
                    {
                        shop.InsertAfter(ItemID.BoneTorch, ItemID.Torch);
                    }

                    bool ignoreMoonPhase = GetInstance<IOtherConfig>().SkeletonMerchantIgnoresMoonphases;
                    if (ignoreMoonPhase)
                    {
                        List<int> shopItems = new() {
                            ItemID.WoodenBoomerang,
                            ItemID.Umbrella,
                            ItemID.WandofSparking,
                            ItemID.PortableStool,
                            ItemID.StrangeBrew,
                            ItemID.SpelunkerGlowstick,
                            ItemID.BlueCounterweight,
                            ItemID.RedCounterweight,
                            ItemID.PurpleCounterweight,
                            ItemID.GreenCounterweight,
                            ItemID.Bomb,
                            ItemID.Rope,
                            ItemID.MagicLantern
                        };

                        if (Main.LocalPlayer.HasItem(ItemID.FlareGun))
                        {
                            shopItems.Add(ItemID.SpelunkerFlare);
                        }

                        if (Main.hardMode)
                        {
                            shopItems.Add(ItemID.HealingPotion);
                            shopItems.Add(ItemID.Gradient);
                            shopItems.Add(ItemID.FormatC);
                            shopItems.Add(ItemID.YoYoGlove);
                            if (Main.bloodMoon)
                            {
                                shopItems.Add(ItemID.SlapHand);
                            }
                        }

                        foreach (int i in shopItems)
                        {
                            if (!shop.TryGetEntry(i, out _))
                            {
                                shop.Add(i);
                            }
                        }
                    }
                    break;
                case NPCID.BestiaryGirl:
                    if (GetInstance<IOtherConfig>().UniversalPylon.UniversalPylonBestiaryCompletionRate < 1f)
                    {
                        BestiaryUnlockProgressReport bestiaryProgressReport = Main.GetBestiaryProgressReport();

                        if (bestiaryProgressReport.CompletionPercent >= GetInstance<IOtherConfig>().UniversalPylon.UniversalPylonBestiaryCompletionRate)
                        {
                            if (!shop.TryGetEntry(ItemID.TeleportationPylonVictory, out _))
                            {
                                shop.Add(ItemID.TeleportationPylonVictory);
                            }
                        }

                        if (GetInstance<HOtherModdedItemsConfig>().BestiaryTrophy && bestiaryProgressReport.CompletionPercent >= 1f)
                        {
                            shop.Add(ItemType<Items.Placeable.BestiaryTrophy>());
                        }
                    }
                    break;
                case NPCID.WitchDoctor:
                    if (GetInstance<IOtherConfig>().WitchDoctorSellsChlorophyteOre)
                    {
                        shop.Add(ItemID.ChlorophyteOre, Condition.InJungle, Condition.DownedPlantera);
                    }
                    break;
            }
        }

        public override void SetupTravelShop(int[] shop, ref int nextSlot)
        {
            bool sellMerchantDice;
            if (Main.hardMode)
            {
                if (NPC.downedPlantBoss)
                {
                    sellMerchantDice = GetInstance<IOtherConfig>().TravelingMerchant.TravelingMerchantDiceUsesAfterPlantera > 0;
                }
                else
                {
                    sellMerchantDice = GetInstance<IOtherConfig>().TravelingMerchant.TravelingMerchantDiceUsesHardmode > 0;
                }
            }
            else
            {
                sellMerchantDice = GetInstance<IOtherConfig>().TravelingMerchant.TravelingMerchantDiceUsesBeforeHardmode > 0;
            }

            if (sellMerchantDice)
            {
                Main.travelShop[nextSlot] = ItemType<Items.MerchantDice>();
                nextSlot++;
            }

            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.TravelMerchantItems);
            }

            if (GetInstance<IOtherConfig>().TravelingMerchant.TravelingMerchantChatsItems)
            {
                Global.Update.chatMerchantItems = true;

                if (Main.netMode == NetmodeID.Server)
                {
                    ModPacket packet = Mod.GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.chatMerchantItems);
                    packet.Write(Global.Update.chatMerchantItems);
                    packet.Send();
                }
            }
        }
    }
}