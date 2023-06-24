using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class Shops : GlobalNPC
    {
        public override void GetChat(NPC npc, ref string chat)
        {
            GetInstance<ReducedGrinding>().Logger.Debug("Main.myPlayer: " + Main.myPlayer.ToString() + " Main.netMode: " + Main.netMode.ToString());
            Main.NewText("(NewText) Main.myPlayer: " + Main.myPlayer.ToString() + " Main.netMode: " + Main.netMode.ToString());
            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("(Broadcast) Main.myPlayer: " + Main.myPlayer.ToString() + " Main.netMode: " + Main.netMode.ToString()), new Color());

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
                    bool? fishMerchantExist = null;
                    int anglerNPC = -1;
                    for (int i = 0; i < Main.npc.Length; i++)
                    {
                        if (fishMerchantExist == null && Main.npc[i].type == fishMerchantID)
                        {
                            if (Main.npc[i].active)
                            {
                                fishMerchantExist = true;
                            }
                            else
                            {
                                fishMerchantExist = false;
                            }
                        }
                        if (anglerNPC == -1 && Main.npc[i].type == NPCID.Angler && Main.npc[i].active)
                        {
                            anglerNPC = i;
                        }
                        if (fishMerchantExist != null && anglerNPC > -1)
                        {
                            break;
                        }
                    }

                    if (fishMerchantExist != true)
                    {
                        int newFishMerchant = NPC.NewNPC(Entity.GetSource_TownSpawn(), Main.spawnTileX * 16, Main.spawnTileY * 16, fishMerchantID, 1);
                        Main.npc[newFishMerchant].whoAmI = newFishMerchant;
                        Main.npc[newFishMerchant].homeless = true;
                        Main.npc[newFishMerchant].direction = Main.spawnTileX >= WorldGen.bestX ? -1 : 1;
                        Main.npc[newFishMerchant].netUpdate = true;
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, newFishMerchant);
                        }
                    }

                    for (int i = 0; i < Main.npc.Length; i++)
                    {
                        if (Main.npc[i].type == fishMerchantID)
                        {
                            if (Main.npc[i].Distance(Main.npc[anglerNPC].position) > 0) //500) TO-DO TEMPORARY
                            {
                                Main.npc[i].position = Main.npc[anglerNPC].position;
                                if (Main.netMode == NetmodeID.MultiplayerClient)
                                {
                                    NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, i);
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
            bool sellMerchantDice;
            if (Main.hardMode)
            {
                if (NPC.downedPlantBoss)
                {
                    sellMerchantDice = GetInstance<IOtherConfig>().TravelingMerchantDiceUsesAfterPlantera > 0;
                }
                else
                {
                    sellMerchantDice = GetInstance<IOtherConfig>().TravelingMerchantDiceUsesHardmode > 0;
                }
            }
            else
            {
                sellMerchantDice = GetInstance<IOtherConfig>().TravelingMerchantDiceUsesBeforeHardmode > 0;
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

            if (GetInstance<IOtherConfig>().TravelingMerchantChatsItems)
            {
                Update.chatMerchantItems = true;

                if (Main.netMode == NetmodeID.Server)
                {
                    ModPacket packet = Mod.GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.chatMerchantItems);
                    packet.Write(Update.chatMerchantItems);
                    packet.Send();
                }
            }
        }
    }
}