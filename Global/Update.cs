using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class Update : ModSystem
    {
        readonly static IOtherConfig otherConfig = GetInstance<IOtherConfig>();
        readonly static CFishingConfig fishingConfig = GetInstance<CFishingConfig>();

        //Gets recorded into world save
        public static int anglerQuests = 1;
        public static bool dayTime = true;
        public static int travelingMerchantDiceRolls = NPC.downedPlantBoss ? otherConfig.TravelingMerchant.TravelingMerchantDiceUsesAfterPlantera : Main.hardMode ? otherConfig.TravelingMerchant.TravelingMerchantDiceUsesHardmode : otherConfig.TravelingMerchant.TravelingMerchantDiceUsesBeforeHardmode;


        //Info sent to server, but not recorded into world save
        public static bool advanceMoonPhase = false;
        public static bool advanceDifficulty = false;
        public static bool instantInvasion = false;
        public static bool chatMerchantItems = false;
        public static int chatQuestFish = 0;

        public override void ModifyTimeRate(ref double timeRate, ref double tileUpdateRate, ref double eventUpdateRate)
        {
            float rateMultiplier = 1f;
            if (otherConfig.EnchantedSundial.EnchantedDialMultiplier > 1f && Main.IsFastForwardingTime())
            {
                rateMultiplier *= otherConfig.EnchantedSundial.EnchantedDialMultiplier;
            }

            if (!CreativePowerManager.Instance.GetPower<CreativePowers.FreezeTime>().Enabled &&
                Main.CurrentFrameFlags.SleepingPlayersCount == Main.CurrentFrameFlags.ActivePlayersCount &&
                Main.CurrentFrameFlags.SleepingPlayersCount > 0)
            {
                if (otherConfig.SleepRateMultiplier >= 1f)
                {
                    rateMultiplier *= otherConfig.SleepRateMultiplier;
                }
            }

            if (rateMultiplier > 1f)
            {
                timeRate *= rateMultiplier;
                tileUpdateRate *= rateMultiplier;
                eventUpdateRate *= rateMultiplier;
            }
        }

        public override void PostUpdateTime()
        {
            bool sendNetMessageWorldData = false;

            int cooldownMax = otherConfig.EnchantedSundial.EnchantedDialCooldown;
            if (Main.IsFastForwardingTime())
            {
                cooldownMax++;
            }
            if (Main.sundialCooldown > cooldownMax)
            {
                Main.sundialCooldown = cooldownMax;
                sendNetMessageWorldData = true;
            }
            if (Main.moondialCooldown > cooldownMax)
            {
                Main.moondialCooldown = cooldownMax;
                sendNetMessageWorldData = true;
            }

            bool sendInstantInvasionPacket = false;
            if (instantInvasion)
            {
                Main.invasionX = Main.spawnTileX;
                instantInvasion = false;
                sendInstantInvasionPacket = true;
                sendNetMessageWorldData = true;
            }

            #region For Each Player, Test if Still Questing

            bool stillQuesting = Main.anglerWhoFinishedToday.Count == 0;

            for (int i = 0; i < Main.maxPlayers; i++)
            {
                if (stillQuesting)
                {
                    break;
                }

                if (!Main.player[i].active)
                {
                    continue;
                }

                if (!stillQuesting && Main.player[i].HasItem(ItemType<Items.FishingTicket>()) && !Main.anglerWhoFinishedToday.Contains(Main.player[i].name))
                {
                    stillQuesting = true;
                }
            }
            #endregion

            #region Angler
            bool sendAnglerQuestsPacket = false;
            if (anglerQuests > 0 && Main.anglerWhoFinishedToday.Count > 0 && !stillQuesting)
            {
                anglerQuests--;
                sendAnglerQuestsPacket = true;

                if (anglerQuests > 0)
                {
                    Main.AnglerQuestSwap();
                    string newQuestText = "The Angler decided to give you another quest";
                    if (fishingConfig.Angler.AnglerChatsCurrentQuest)
                    {
                        newQuestText += fishingConfig.Angler.AnglerChatsCurrentQuest ? $": [i:{Main.anglerQuestItemNetIDs[Main.anglerQuest]}]." : ".";
                    }
                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        Main.NewText(newQuestText, 128, 255, 255);
                    }
                    else if (Main.netMode == NetmodeID.Server)
                    {
                        ChatHelper.BroadcastChatMessage(NetworkText.FromKey(newQuestText), new Color(128, 255, 255));
                    }
                }
            }
            #endregion

            #region Day / Night Changed
            bool sendDayTimePacket = false;
            bool sendTravelingMerchantDiceRollsPacket = false;
            bool sendChatQuestFishPacket = false;

            if (dayTime != Main.dayTime)
            {
                dayTime = Main.dayTime;
                sendDayTimePacket = true;

                #region New Morning
                if (Main.dayTime)
                {
                    travelingMerchantDiceRolls = NPC.downedPlantBoss ? otherConfig.TravelingMerchant.TravelingMerchantDiceUsesAfterPlantera : Main.hardMode ? otherConfig.TravelingMerchant.TravelingMerchantDiceUsesHardmode : otherConfig.TravelingMerchant.TravelingMerchantDiceUsesBeforeHardmode;
                    sendTravelingMerchantDiceRollsPacket = true;

                    anglerQuests = -1;
                    chatQuestFish = 0;
                    sendAnglerQuestsPacket = true;
                    sendChatQuestFishPacket = true;
                }
                #endregion
            }
            #endregion

            #region ClientToServerData
            if (Main.netMode == NetmodeID.Server)
            {
                if (sendAnglerQuestsPacket)
                {
                    ModPacket packetAnglerQuest = Mod.GetPacket();
                    packetAnglerQuest.Write((byte)ReducedGrinding.MessageType.anglerQuests);
                    packetAnglerQuest.Write(anglerQuests);
                    packetAnglerQuest.Send();
                }

                if (sendDayTimePacket)
                {
                    ModPacket dayTimePacket = Mod.GetPacket();
                    dayTimePacket.Write((byte)ReducedGrinding.MessageType.dayTime);
                    dayTimePacket.Write(dayTime);
                    dayTimePacket.Send();
                }

                if (sendInstantInvasionPacket)
                {
                    ModPacket instantInvasionPacket = Mod.GetPacket();
                    instantInvasionPacket.Write((byte)ReducedGrinding.MessageType.instantInvasion);
                    instantInvasionPacket.Write(instantInvasion);
                    instantInvasionPacket.Send();
                }

                if (sendTravelingMerchantDiceRollsPacket)
                {
                    ModPacket travelingMerchantDiceRollsPacket = Mod.GetPacket();
                    travelingMerchantDiceRollsPacket.Write((byte)ReducedGrinding.MessageType.travelingMerchantDiceRolls);
                    travelingMerchantDiceRollsPacket.Write(travelingMerchantDiceRolls);
                    travelingMerchantDiceRollsPacket.Send();
                }

                if (sendChatQuestFishPacket)
                {
                    ModPacket packet = Mod.GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.chatQuestFish);
                    packet.Write(chatQuestFish);
                    packet.Send();
                }

                if (sendNetMessageWorldData)
                {
                    NetMessage.SendData(MessageID.WorldData);
                }
            }
            #endregion
        }

        public override void PostUpdateWorld()
        {
            if (advanceMoonPhase)
            {
                advanceMoonPhase = false;

                Main.moonPhase++;
                if (Main.moonPhase >= 8)
                {
                    Main.moonPhase = 0;
                }

                if (Main.netMode == NetmodeID.Server)
                {
                    ModPacket packet = Mod.GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.advanceMoonPhase);
                    packet.Write(advanceMoonPhase);
                    packet.Send();
                    NetMessage.SendData(MessageID.WorldData);
                }
            }

            if (advanceDifficulty)
            {
                advanceDifficulty = false;

                int difficultyOld = Main.GameMode;
                int difficultyNew = difficultyOld;

                string text = "";
                Color textColor = new();
                bool finishedDifficultyChange = false;

                while (!finishedDifficultyChange)
                {
                    switch (Main.GameMode)
                    {
                        case 0:
                            if (GetInstance<HOtherModdedItemsConfig>().StaffOfDifficulty.Expert)
                            {
                                finishedDifficultyChange = true;
                                text = "World difficulty mode is now Expert!";
                                textColor = new Color(255, 179, 0);
                            }
                            break;
                        case 1:
                            if (GetInstance<HOtherModdedItemsConfig>().StaffOfDifficulty.Master)
                            {
                                finishedDifficultyChange = true;
                                text = "World difficulty mode is now Master!";
                                textColor = new Color(255, 0, 0);
                            }
                            break;
                        default:
                            if (GetInstance<HOtherModdedItemsConfig>().StaffOfDifficulty.Expert)
                            {
                                finishedDifficultyChange = true;
                                text = "World difficulty mode is now Normal!";
                                textColor = new Color(255, 255, 255);
                            }
                            break;
                    }
                    difficultyNew++;
                    if (difficultyNew > 2)
                    {
                        difficultyNew = 0;
                    }
                    if (difficultyNew == difficultyOld)
                    {
                        finishedDifficultyChange = true;
                    }
                }

                if (difficultyNew != difficultyOld)
                {
                    Main.GameMode = difficultyNew;
                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        Main.NewText(text, textColor);
                    }
                    else if (Main.netMode == NetmodeID.Server)
                    {
                        ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), textColor);
                        NetMessage.SendData(MessageID.WorldData);
                    }
                }

                if (Main.netMode == NetmodeID.Server)
                {
                    ModPacket packet = Mod.GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.advanceDifficulty);
                    packet.Write(advanceDifficulty);
                    packet.Send();
                    NetMessage.SendData(MessageID.WorldData);
                }
            }

            if (chatMerchantItems)
            {
                chatMerchantItems = false;

                string itemList = "";

                for (int i = 0; i < Main.travelShop.Length; i++)
                {
                    if (Main.travelShop[i] != ItemID.None)
                    {
                        itemList += $"[i:{Main.travelShop[i]}]";
                    }
                }

                if (itemList != "")
                {
                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        Main.NewText(itemList, 50, 125);
                    }
                    else if (Main.netMode == NetmodeID.Server)
                    {
                        ChatHelper.BroadcastChatMessage(NetworkText.FromKey(itemList), new Color(50, 125, 255));
                    }
                }

                if (Main.netMode == NetmodeID.Server)
                {
                    ModPacket packet = Mod.GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.chatMerchantItems);
                    packet.Write(chatMerchantItems);
                    packet.Send();
                }
            }

            if (chatQuestFish == 1)
            {
                chatQuestFish = 2;

                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText($"Current Quest: [i:{Main.anglerQuestItemNetIDs[Main.anglerQuest]}]");
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey($"Current Quest: [i:{Main.anglerQuestItemNetIDs[Main.anglerQuest]}]"), new Color(255, 255, 255));

                    ModPacket packet = Mod.GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.chatQuestFish);
                    packet.Write(chatQuestFish);
                    packet.Send();
                }
            }
        }
    }
}
