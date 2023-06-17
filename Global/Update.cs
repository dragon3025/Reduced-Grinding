using Microsoft.Xna.Framework;
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
        public static int anglerQuests = NPC.downedPlantBoss ? fishingConfig.QuestCountAfterPlantera : Main.hardMode ? fishingConfig.QuestCountHardmode : NPC.downedBoss3 ? fishingConfig.QuestCountAfterSkeletron : NPC.downedBoss2 ? fishingConfig.QuestCountAfterInfectionBoss : NPC.downedBoss1 ? fishingConfig.QuestCountAfterEye : fishingConfig.QuestCountBeforeEye;
        public static bool dayTime = true;
        public static int travelingMerchantDiceRolls = NPC.downedPlantBoss ? otherConfig.TravelingMerchantDiceUsesAfterPlantera : Main.hardMode ? otherConfig.TravelingMerchantDiceUsesHardmode : otherConfig.TravelingMerchantDiceUsesBeforeHardmode;
        public static bool chatMerchantItems = false;

        //Info sent to server, but not recorded into world save
        public static bool advanceMoonPhase = false;
        public static bool instantInvasion = false;
        public static int timeHiddenFromInvasion = 0;
        public static int anglerResetTimer = 0;

        public override void ModifyTimeRate(ref double timeRate, ref double tileUpdateRate, ref double eventUpdateRate)
        {
            if (CreativePowerManager.Instance.GetPower<CreativePowers.FreezeTime>().Enabled)
            {
                return;
            }

            if (!(Main.CurrentFrameFlags.SleepingPlayersCount == Main.CurrentFrameFlags.ActivePlayersCount && Main.CurrentFrameFlags.SleepingPlayersCount > 0))
            {
                return;
            }

            int timeIncrease = NPC.downedPlantBoss ? otherConfig.SleepRateIncreasePostPlantera : Main.hardMode ? otherConfig.SleepRateIncreaseHardmode : otherConfig.SleepRateIncreasePreHardmode;

            if (timeIncrease < 1)
            {
                return;
            }

            for (int i = 0; i < 255; i++)
            {
                if (!Main.player[i].active)
                {
                    continue;
                }

                Main.player[i].taxTimer -= timeIncrease;
            }

            timeRate += timeIncrease;
            tileUpdateRate += timeIncrease;
            eventUpdateRate += timeIncrease;
        }

        public override void PostUpdateTime()
        {
            bool updatePacket = false;
            bool sendNetMessageData = false;

            int time = (int)Main.time;

            if (instantInvasion)
            {
                Main.invasionX = Main.spawnTileX;
                instantInvasion = false;
                updatePacket = true;
            }

            bool allPlayersHiddenFromInvasion = false;
            int invasionType = Main.invasionType;

            if (time % 60 == 0)
            {
                if (otherConfig.CancelInvasionsIfAllPlayersAreHidden)
                {
                    if (invasionType == InvasionID.PirateInvasion || invasionType == InvasionID.GoblinArmy || invasionType == InvasionID.MartianMadness || invasionType == InvasionID.SnowLegion)
                    {
                        allPlayersHiddenFromInvasion = true;
                    }
                }
            }

            #region For Each Player

            bool stillQuesting = Main.anglerWhoFinishedToday.Count == 0;

            for (int i = 0; i < Main.player.Length; i++)
            {
                if (!Main.player[i].active)
                {
                    continue;
                }

                if (allPlayersHiddenFromInvasion)
                {
                    if (!Main.player[i].HasBuff(BuffID.Invisibility))
                    {
                        if (Main.remixWorld)
                        {
                            allPlayersHiddenFromInvasion = false;
                        }
                        else
                        {
                            Point playerPosition = Main.player[i].Center.ToTileCoordinates();
                            if (playerPosition.Y <= Main.worldSurface + 67.5f)
                            {
                                allPlayersHiddenFromInvasion = false;
                            }
                        }
                    }
                }

                if (!stillQuesting && anglerResetTimer > 0 && !Main.anglerWhoFinishedToday.Contains(Main.player[i].name))
                {
                    stillQuesting = true;
                }
            }
            #endregion

            #region InvasionModifying
            if (time % 60 == 0)
            {
                if (allPlayersHiddenFromInvasion)
                {
                    if (timeHiddenFromInvasion == 0)
                    {
                        if (Main.netMode == NetmodeID.Server)
                        {
                            ChatHelper.BroadcastChatMessage(NetworkText.FromKey("The invasion can't find anyone, and will soon leave."), new Color(255, 255, 0));
                        }
                        else if (Main.netMode == NetmodeID.SinglePlayer)
                        {
                            Main.NewText("The invasion can't find anyone, and will soon leave.", new Color(255, 255, 0));
                        }
                    }
                    timeHiddenFromInvasion++;
                    updatePacket = true;
                }
                else if (timeHiddenFromInvasion > 0)
                {
                    timeHiddenFromInvasion--;
                    updatePacket = true;
                }

                if (timeHiddenFromInvasion >= 20 && Main.invasionX == Main.spawnTileX)
                {
                    Main.invasionType = InvasionID.None;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        ChatHelper.BroadcastChatMessage(NetworkText.FromKey("The invasion couldn't find anyone, so they left."), new Color(255, 255, 0));
                    }
                    else if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        Main.NewText("The invasion couldn't find anyone, so they left.", new Color(255, 255, 0));
                    }

                    timeHiddenFromInvasion = 0;
                    updatePacket = true;
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
                    travelingMerchantDiceRolls = NPC.downedPlantBoss ? otherConfig.TravelingMerchantDiceUsesAfterPlantera : Main.hardMode ? otherConfig.TravelingMerchantDiceUsesHardmode : otherConfig.TravelingMerchantDiceUsesBeforeHardmode;

                    anglerQuests = NPC.downedPlantBoss ? fishingConfig.QuestCountAfterPlantera : Main.hardMode ? fishingConfig.QuestCountHardmode : NPC.downedBoss3 ? fishingConfig.QuestCountAfterSkeletron : NPC.downedBoss2 ? fishingConfig.QuestCountAfterInfectionBoss : NPC.downedBoss1 ? fishingConfig.QuestCountAfterEye : fishingConfig.QuestCountBeforeEye;

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

                packet.Write((byte)ReducedGrinding.MessageType.timeHiddenFromInvasion);
                packet.Write(timeHiddenFromInvasion);

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

                if (!(Main.bloodMoon && Main.moonPhase == 3))
                {
                    Main.moonPhase++;
                    if (Main.moonPhase >= 8)
                    {
                        Main.moonPhase = 0;
                    }
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
                    NetMessage.SendData(MessageID.WorldData);
                }
            }
        }
    }
}
