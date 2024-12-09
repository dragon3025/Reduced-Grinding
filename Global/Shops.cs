using Humanizer;
using ReducedGrinding.Configuration;
using ReducedGrinding.Items;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.GlobalNPCs
{
    public class Shops : GlobalNPC
    {
        readonly static CFishingConfig fishingConfig = GetInstance<CFishingConfig>();

        public static LocalizedText QuestFinishedText { get; private set; }


        public override void OnChatButtonClicked(NPC npc, bool firstButton)
        {
            if (npc.type == NPCID.Angler && firstButton)
            {
                if (Global.Update.chatQuestFish == 0 && Main.netMode != NetmodeID.Server && fishingConfig.Angler.AnglerChatsCurrentQuest)
                {
                    Global.Update.chatQuestFish = 1;

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
                    chat += $"\n\n" + Language.GetTextValue("Mods.ReducedGrinding.Misc.Fishing.QuestFinishedText").FormatWith(player.anglerQuestsFinished);
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

                        addShopItem(5, ItemID.FuzzyCarrot);
                        addShopItem(10, ItemID.AnglerHat);
                        addShopItem(10, ItemID.AnglerVest);
                        addShopItem(10, ItemID.AnglerPants);

                        if (NPC.downedQueenBee)
                        {
                            addShopItem(70, ItemID.HoneyAbsorbantSponge);
                            addShopItem(70, ItemID.BottomlessHoneyBucket);
                        }

                        addShopItem(30, ItemID.GoldenFishingRod);

                        if (Main.hardMode)
                        {
                            addShopItem(100, ItemID.HotlineFishingHook);
                            addShopItem(70, ItemID.FinWings);
                        }

                        addShopItem(25, ItemID.BottomlessBucket);
                        addShopItem(70, ItemID.SuperAbsorbantSponge);
                        addShopItem(80, ItemID.GoldenBugNet);
                        addShopItem(60, ItemID.FishHook);
                        addShopItem(60, ItemID.FishMinecart);
                        addShopItem(80, ItemType<MermaidCostumeBag>());
                        addShopItem(80, ItemType<FishCostumeBag>());
                        addShopItem(80, ItemID.HighTestFishingLine);
                        addShopItem(80, ItemID.AnglerEarring);
                        addShopItem(80, ItemID.TackleBox);
                        addShopItem(60, ItemID.FishermansGuide);
                        addShopItem(60, ItemID.WeatherRadio);
                        addShopItem(60, ItemID.Sextant);
                        addShopItem(25, ItemID.FishingBobber);
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

        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            if (npc.type == NPCID.SkeletonMerchant)
            {

                List<int> itemsToAdd = new()
                {
                    ItemID.Torch,
                    ItemID.BoneTorch
                };

                int ignoreMoonPhase = GetInstance<IOtherConfig>().SkeletonMerchantIgnoresMoonphases;
                if (ignoreMoonPhase > 0)
                {
                    itemsToAdd.Add(ItemID.StrangeBrew);
                    itemsToAdd.Add(ItemID.SpelunkerGlowstick);
                    itemsToAdd.Add(ItemID.BoneArrow);
                    itemsToAdd.Add(ItemID.BlueCounterweight);
                    itemsToAdd.Add(ItemID.RedCounterweight);
                    itemsToAdd.Add(ItemID.PurpleCounterweight);
                    itemsToAdd.Add(ItemID.GreenCounterweight);
                    itemsToAdd.Add(ItemID.MagicLantern);

                    if (Main.LocalPlayer.HasItem(ItemID.FlareGun))
                    {
                        itemsToAdd.Add(ItemID.SpelunkerFlare);
                    }

                    if (Main.hardMode)
                    {
                        itemsToAdd.Add(ItemID.Gradient);
                        itemsToAdd.Add(ItemID.FormatC);
                    }

                    if (!Main.LocalPlayer.ateArtisanBread)
                    {
                        itemsToAdd.Add(ItemID.ArtisanLoaf);
                    }
                }

                if (ignoreMoonPhase == 2)
                {
                    itemsToAdd.Add(ItemID.WoodenBoomerang);
                    itemsToAdd.Add(ItemID.Umbrella);
                    if (Main.remixWorld)
                    {
                        itemsToAdd.Add(ItemID.MagicDagger);
                    }
                    else
                    {
                        itemsToAdd.Add(ItemID.WandofSparking);
                    }
                    itemsToAdd.Add(ItemID.PortableStool);
                    itemsToAdd.Add(ItemID.Aglet);
                    itemsToAdd.Add(ItemID.ClimbingClaws);
                    itemsToAdd.Add(ItemID.CordageGuide);
                    itemsToAdd.Add(ItemID.Radar);
                    itemsToAdd.Add(ItemID.LesserHealingPotion);
                    if (Main.hardMode)
                    {
                        itemsToAdd.Add(ItemID.HealingPotion);
                    }
                    itemsToAdd.Add(ItemID.Glowstick);
                    itemsToAdd.Add(ItemID.WoodenArrow);
                }

                foreach (Item item in items)
                {
                    if (item == null || item.type == ItemID.None)
                    {
                        continue;
                    }

                    itemsToAdd.Remove(item.type);
                }

                foreach (int itemToAdd in itemsToAdd)
                {

                    for (int i = 0; i < items.Length; i++)
                    {
                        if (items[i] == null)
                        {
                            items[i] = new Item();
                        }

                        if (items[i].type == ItemID.None)
                        {
                            items[i].SetDefaults(itemToAdd);
                            break;
                        }
                    }
                }
            }
        }
    }
}