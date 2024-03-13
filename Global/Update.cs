using Humanizer;
using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using System;
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
        public static int anglerQuests = 0;
        public static bool dayTime = true;
        public static int travelingMerchantDiceRolls = NPC.downedPlantBoss ? otherConfig.TravelingMerchant.TravelingMerchantDiceUsesAfterPlantera : Main.hardMode ? otherConfig.TravelingMerchant.TravelingMerchantDiceUsesHardmode : otherConfig.TravelingMerchant.TravelingMerchantDiceUsesBeforeHardmode;
        public static int tryBumblebeeTunaSwap = 0;

        //Info sent to server, but not recorded into world save
        public static bool advanceMoonPhase = false;
        public static bool advanceDifficulty = false;
        public static bool instantInvasion = false;
        public static bool chatMerchantItems = false;
        public static int chatQuestFish = 0;
        public static bool chatBumblebeeTunaIncrease = false;

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

            bool sendTryBumblebeeTunaSwapPacket = false;
            void tryToSwapToBumblebeeTuna()
            {
                if (tryBumblebeeTunaSwap == 1)
                {
                    if (Main.rand.NextFloat() < fishingConfig.Angler.BumblebeeTunaSwapChance)
                    {
                        int questItem = Main.anglerQuestItemNetIDs[Main.anglerQuest];
                        if (questItem <= ItemID.ScorpioFish)
                        {
                            Main.anglerQuest = Array.IndexOf(Main.anglerQuestItemNetIDs, ItemID.BumblebeeTuna);
                            NetMessage.SendAnglerQuest(-1);
                        }
                    }
                    if (Main.anglerQuestItemNetIDs[Main.anglerQuest] == ItemID.BumblebeeTuna)
                    {
                        tryBumblebeeTunaSwap = 2;
                        sendTryBumblebeeTunaSwapPacket = true;
                    }
                }
            }

            #region Angler Reset
            bool sendAnglerQuestsPacket = false;
            if (Main.anglerWhoFinishedToday.Count > 0 && !stillQuesting && fishingConfig.Angler.UnlimitedAnglerQuest)
            {
                anglerQuests++;
                sendAnglerQuestsPacket = true;

                Main.AnglerQuestSwap();

                if (tryBumblebeeTunaSwap == 2)
                {
                    tryBumblebeeTunaSwap = 0;
                    sendTryBumblebeeTunaSwapPacket = true;

                    string textBumblebeeTunaDecrease = Language.GetTextValue("Mods.ReducedGrinding.Misc.Fishing.BumblebeeTunaDecrease").FormatWith(Main.anglerQuestItemNetIDs[Main.anglerQuest]);
                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        Main.NewText(textBumblebeeTunaDecrease, 50, 255, 130);
                    }
                    else if (Main.netMode == NetmodeID.Server)
                    {
                        ChatHelper.BroadcastChatMessage(NetworkText.FromKey(textBumblebeeTunaDecrease), new Color(50, 255, 130));
                    }
                }
                else
                {
                    tryToSwapToBumblebeeTuna();
                }

                string newQuestText = Language.GetTextValue("Mods.ReducedGrinding.Misc.Fishing.NewQuestTextWithIcon").FormatWith(Main.anglerQuestItemNetIDs[Main.anglerQuest]);
                if (!fishingConfig.Angler.AnglerChatsCurrentQuest)
                {
                    newQuestText = Language.GetTextValue("Mods.ReducedGrinding.Misc.Fishing.NewQuestText");
                }

                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText(newQuestText, 50, 255, 130);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey(newQuestText), new Color(50, 255, 130));
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

                    if (tryBumblebeeTunaSwap == 2)
                    {
                        tryBumblebeeTunaSwap = 0;
                        sendTryBumblebeeTunaSwapPacket = true;

                        string textBumblebeeTunaDecrease = Language.GetTextValue("Mods.ReducedGrinding.Misc.Fishing.BumblebeeTunaDecrease").FormatWith(Main.anglerQuestItemNetIDs[Main.anglerQuest]);
                        if (Main.netMode == NetmodeID.SinglePlayer)
                        {
                            Main.NewText(textBumblebeeTunaDecrease, 50, 255, 130);
                        }
                        else if (Main.netMode == NetmodeID.Server)
                        {
                            ChatHelper.BroadcastChatMessage(NetworkText.FromKey(textBumblebeeTunaDecrease), new Color(50, 255, 130));
                        }
                    }
                    else
                    {
                        tryToSwapToBumblebeeTuna();
                    }

                    anglerQuests = 0;
                    sendAnglerQuestsPacket = true;

                    chatQuestFish = 0;
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

                if (sendTryBumblebeeTunaSwapPacket)
                {
                    ModPacket packet = Mod.GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.tryBumblebeeTunaSwap);
                    packet.Write(tryBumblebeeTunaSwap);
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

                string moonPhaseName = Main.moonPhase switch
                {
                    0 => Language.GetTextValue("GameUI.FullMoon"),
                    1 => Language.GetTextValue("GameUI.WaningGibbous"),
                    2 => Language.GetTextValue("GameUI.ThirdQuarter"),
                    3 => Language.GetTextValue("GameUI.WaningCrescent"),
                    4 => Language.GetTextValue("GameUI.NewMoon"),
                    5 => Language.GetTextValue("GameUI.WaxingCrescent"),
                    6 => Language.GetTextValue("GameUI.FirstQuarter"),
                    _ => Language.GetTextValue("GameUI.WaxingGibbous"),
                };

                string moonPhaseText = Language.GetTextValue("Mods.ReducedGrinding.Misc.MoonWatch.MoonPhase").FormatWith(moonPhaseName);

                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText(moonPhaseText, 255, 240, 20);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey(moonPhaseText), new Color(255, 240, 20));
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
                        case GameModeID.Normal:
                            if (GetInstance<HOtherModdedItemsConfig>().StaffOfDifficulty.Normal)
                            {
                                finishedDifficultyChange = true;
                                text = Language.GetTextValue("Mods.ReducedGrinding.Misc.StaffOfDifficulty.Expert");
                                textColor = new Color(255, 179, 0);
                            }
                            break;
                        case GameModeID.Expert:
                            if (GetInstance<HOtherModdedItemsConfig>().StaffOfDifficulty.Expert)
                            {
                                finishedDifficultyChange = true;
                                text = Language.GetTextValue("Mods.ReducedGrinding.Misc.StaffOfDifficulty.Master");
                                textColor = new Color(255, 0, 0);
                            }
                            break;
                        default:
                            if (GetInstance<HOtherModdedItemsConfig>().StaffOfDifficulty.Master)
                            {
                                finishedDifficultyChange = true;
                                text = Language.GetTextValue("Mods.ReducedGrinding.Misc.StaffOfDifficulty.Normal");
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
                        Main.NewText(itemList);
                    }
                    else if (Main.netMode == NetmodeID.Server)
                    {
                        ChatHelper.BroadcastChatMessage(NetworkText.FromKey(itemList), new Color(0, 0, 0));
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

                string messageText = Language.GetTextValue("Mods.ReducedGrinding.Misc.Fishing.CurrentQuest").FormatWith(Main.anglerQuestItemNetIDs[Main.anglerQuest]);

                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText(messageText, 255, 240, 20);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey(messageText), new Color(255, 240, 20));

                    ModPacket packet = Mod.GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.chatQuestFish);
                    packet.Write(chatQuestFish);
                    packet.Send();
                }
            }

            if (chatBumblebeeTunaIncrease)
            {
                chatBumblebeeTunaIncrease = false;

                string messageText = Language.GetTextValue("Mods.ReducedGrinding.Misc.Fishing.BumblebeeTunaIncrease");

                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText(messageText, 50, 255, 130);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey(messageText), new Color(50, 255, 130));

                    ModPacket packet = Mod.GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.chatBumblebeeTunaIncrease);
                    packet.Write(chatBumblebeeTunaIncrease);
                    packet.Send();
                }
            }
        }
    }
}
