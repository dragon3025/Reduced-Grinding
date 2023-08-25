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
        public static bool chatMerchantItems = false;


        //Info sent to server, but not recorded into world save
        public static bool advanceMoonPhase = false;
        public static bool advanceDifficulty = false;
        public static bool instantInvasion = false;
        public static int anglerResetTimer = 0;

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
            bool updatePacket = false;
            bool sendNetMessageData = false;

            int cooldownMax = otherConfig.EnchantedSundial.EnchantedDialCooldown;
            if (Main.IsFastForwardingTime())
            {
                cooldownMax++;
            }
            if (Main.sundialCooldown > cooldownMax)
            {
                Main.sundialCooldown = cooldownMax;
                sendNetMessageData = true;
            }
            if (Main.moondialCooldown > cooldownMax)
            {
                Main.moondialCooldown = cooldownMax;
                sendNetMessageData = true;
            }

            if (instantInvasion)
            {
                Main.invasionX = Main.spawnTileX;
                instantInvasion = false;
                updatePacket = true;
            }

            #region For Each Player, Test if Still Questing

            bool stillQuesting = Main.anglerWhoFinishedToday.Count == 0;

            for (int i = 0; i < Main.player.Length; i++)
            {
                if (stillQuesting)
                {
                    break;
                }

                if (!Main.player[i].active)
                {
                    continue;
                }

                if (!stillQuesting && anglerResetTimer > 0 && !Main.anglerWhoFinishedToday.Contains(Main.player[i].name))
                {
                    stillQuesting = true;
                }
            }
            #endregion

            #region Angler
            if (anglerQuests > 0 && Main.anglerWhoFinishedToday.Count > 0 && !stillQuesting)
            {
                anglerQuests--;

                if (anglerQuests > 0)
                {
                    Main.AnglerQuestSwap();
                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        Main.NewText("The Angler decided to give you another job.", 0, 255, 255);
                    }
                    else if (Main.netMode == NetmodeID.Server)
                    {
                        ChatHelper.BroadcastChatMessage(NetworkText.FromKey("The Angler decided to give you another job."), new Color(0, 255, 255));
                    }
                }
                anglerResetTimer = 0;
                updatePacket = true;
            }

            if (anglerResetTimer > 0)
            {
                anglerResetTimer--;
                updatePacket = true;
            }
            #endregion

            if (dayTime != Main.dayTime)
            {
                dayTime = Main.dayTime;
                updatePacket = true;

                #region New Morning
                if (Main.dayTime)
                {
                    travelingMerchantDiceRolls = NPC.downedPlantBoss ? otherConfig.TravelingMerchant.TravelingMerchantDiceUsesAfterPlantera : Main.hardMode ? otherConfig.TravelingMerchant.TravelingMerchantDiceUsesHardmode : otherConfig.TravelingMerchant.TravelingMerchantDiceUsesBeforeHardmode;

                    anglerQuests = -1;

                    anglerResetTimer = 0;
                }
                #endregion
            }

            #region ClientToServerData
            if (updatePacket && Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = Mod.GetPacket();

                packet.Write((byte)ReducedGrinding.MessageType.anglerQuests);
                packet.Write(anglerQuests);

                packet.Write((byte)ReducedGrinding.MessageType.dayTime);
                packet.Write(dayTime);

                packet.Write((byte)ReducedGrinding.MessageType.instantInvasion);
                packet.Write(instantInvasion);

                packet.Write((byte)ReducedGrinding.MessageType.travelingMerchantDiceRolls);
                packet.Write(travelingMerchantDiceRolls);

                packet.Write((byte)ReducedGrinding.MessageType.anglerResetTimer);
                packet.Write(anglerResetTimer);

                sendNetMessageData = true;

                packet.Send();
            }

            if (sendNetMessageData && Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData);
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
                string itemList = "";

                for (int i = 0; i < Main.travelShop.Length; i++)
                {
                    if (Main.travelShop[i] != ItemID.None)
                    {
                        itemList += "[i:" + Main.travelShop[i].ToString() + "]";
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

                chatMerchantItems = false;

                if (Main.netMode == NetmodeID.Server)
                {
                    ModPacket packet = Mod.GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.chatMerchantItems);
                    packet.Write(chatMerchantItems);
                    packet.Send();
                }
            }
        }
    }
}
