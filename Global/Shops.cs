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
            Player player = Main.LocalPlayer;
            if (npc.type == NPCID.Angler)
            {
                if (GetInstance<CFishingConfig>().AnglerTellsQuestCompleted)
                {
                    Main.NewText("Quests completed: " + player.anglerQuestsFinished.ToString(), 0, 255, 255);
                }

                if (GetInstance<CFishingConfig>().FishCoinsRewardedForQuest > 0)
                {
                    int fishMerchantID = NPCType<NPCs.FishMerchant>();
                    int spawnFishMerchant = 0;
                    int anglerNPC = -1;
                    for (int i = 0; i < Main.npc.Length; i++)
                    {
                        if (spawnFishMerchant == 0 && Main.npc[i].type == fishMerchantID)
                        {
                            if (Main.npc[i].active)
                            {
                                spawnFishMerchant = -1;
                            }
                            else
                            {
                                spawnFishMerchant = 1;
                            }
                        }
                        if (anglerNPC == -1 && Main.npc[i].type == NPCID.Angler && Main.npc[i].active)
                        {
                            anglerNPC = i;
                        }
                        if (spawnFishMerchant != 0 && anglerNPC > -1)
                        {
                            break;
                        }
                    }

                    if (spawnFishMerchant == 1)
                    {
                        int newFishMerchant = NPC.NewNPC(Entity.GetSource_TownSpawn(), Main.spawnTileX * 16, Main.spawnTileY * 16, fishMerchantID, 1);
                        NPC fishMerchant = Main.npc[newFishMerchant];
                        fishMerchant.homeless = true;
                        fishMerchant.direction = Main.spawnTileX >= WorldGen.bestX ? -1 : 1;
                        fishMerchant.netUpdate = true;
                    }

                    for (int i = 0; i < Main.npc.Length; i++)
                    {
                        if (Main.npc[i].type == fishMerchantID)
                        {
                            if (Main.npc[i].Distance(Main.npc[anglerNPC].position) > 500)
                            {
                                Main.npc[i].position = Main.npc[anglerNPC].position;
                                if (Main.netMode == NetmodeID.MultiplayerClient)
                                {
                                    NetMessage.SendData(MessageID.WorldData);
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }

        public override void ModifyShop(NPCShop shop)
        {
            switch (shop.NpcType)
            {
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

                        if (Main.player[Main.myPlayer].HasItem(ItemID.FlareGun))
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
                    if (GetInstance<IOtherConfig>().UniversalPylonBestiaryCompletionRate < 1f)
                    {
                        BestiaryUnlockProgressReport bestiaryProgressReport = Main.GetBestiaryProgressReport();

                        if (bestiaryProgressReport.CompletionPercent >= GetInstance<IOtherConfig>().UniversalPylonBestiaryCompletionRate)
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
            bool sellMerchantDice = false;
            if (Main.hardMode)
            {
                if (NPC.downedPlantBoss)
                {
                    if (GetInstance<IOtherConfig>().TravelingMerchantDiceUsesAfterPlantera > 0)
                    {
                        sellMerchantDice = true;
                    }
                }
                else if (GetInstance<IOtherConfig>().TravelingMerchantDiceUsesHardmode > 0)
                {
                    sellMerchantDice = true;
                }
            }
            else if (GetInstance<IOtherConfig>().TravelingMerchantDiceUsesBeforeHardmode > 0)
            {
                sellMerchantDice = true;
            }

            if (sellMerchantDice)
            {
                Main.travelShop[nextSlot] = ItemType<Items.MerchantDice>();
                nextSlot++;
            }
        }
    }
}