using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Events;
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
        public static int seasonalDay = 1;
        public static int travelingMerchantDiceRolls = NPC.downedPlantBoss ? otherConfig.TravelingMerchantDiceUsesAfterPlantera : Main.hardMode ? otherConfig.TravelingMerchantDiceUsesHardmode : otherConfig.TravelingMerchantDiceUsesBeforeHardmode;

        //Info sent to server, but not recorded into world save
        public static bool advanceMoonPhase = false;
        public static bool instantInvasion = false;
        public static bool celestialSigil = false;
        public static bool xMas = false;
        public static bool halloween = false;
        public static int timeHiddenFromInvasion = 0;

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

            int increase;

            if (NPC.downedPlantBoss)
            {
                increase = otherConfig.SleepRateIncreasePostPlantera;
            }
            else if (Main.hardMode)
            {
                increase = otherConfig.SleepRateIncreaseHardmode;
            }
            else
            {
                increase = otherConfig.SleepRateIncreasePreHardmode;
            }

            if (increase > 0)
            {
                for (int i = 0; i < 255; i++)
                {
                    if (!Main.player[i].active)
                    {
                        continue;
                    }

                    Main.player[i].taxTimer -= increase;
                }

                timeRate += increase;
                tileUpdateRate += increase;
                eventUpdateRate += increase;
            }
        }

        public override void PostUpdateTime()
        {
            bool updatePacket = false;
            bool sendNetMessageData = false;

            int time = (int)Main.time;

            bool stillQuesting = false;

            bool allPlayersHiddenFromInvasion = false;
            int invasionType = Main.invasionType;

            if (instantInvasion)
            {
                Main.invasionX = Main.spawnTileX;
                instantInvasion = false;
                updatePacket = true;
            }

            if (time % 60 == 0)
            {
                if (NPC.downedMoonlord)
                {
                    NPC.LunarShieldPowerExpert = NPC.LunarShieldPowerNormal = 50; //Remove when 1.4.4+ comes out
                }

                if (otherConfig.CancelInvasionsIfAllPlayersAreUnderground)
                {
                    if (invasionType == InvasionID.PirateInvasion || invasionType == InvasionID.GoblinArmy || invasionType == InvasionID.MartianMadness || invasionType == InvasionID.SnowLegion)
                    {
                        allPlayersHiddenFromInvasion = true;
                    }
                }
            }

            #region For Each Player

            bool skipDD2Wave = false;

            for (int i = 0; i < Main.player.Length; i++)
            {
                if (!Main.player[i].active)
                {
                    continue;
                }

                if (!skipDD2Wave && Main.player[i].HeldItem.type == ItemID.DD2ElderCrystal)
                {
                    skipDD2Wave = true;
                }

                Point playerPosition = Main.player[i].Center.ToTileCoordinates();

                if (allPlayersHiddenFromInvasion && playerPosition.Y <= Main.worldSurface + 67.5f)
                {
                    allPlayersHiddenFromInvasion = false;
                }

                if (!Main.anglerWhoFinishedToday.Contains(Main.player[i].name))
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        int armorType = Main.player[i].armor[j].type;
                        if (armorType == ItemID.AnglerHat || armorType == ItemID.AnglerVest || armorType == ItemID.AnglerPants)
                        {
                            stillQuesting = true;
                            break;
                        }
                    }
                }

                //TO-DO When 1.4.4 comes out, the Pocket Mirror will become an Ankh Material. (With the Shimmer, will this feature even be necessary?).
                if (otherConfig.AnkhMaterialUseFromInventory)
                {
                    bool equipped_to_ankh_material = false;
                    for (int j = 3; j <= 9; j++)
                    {
                        int accessoryType = Main.player[i].armor[j].type;

                        if (accessoryType == ItemID.Vitamins || accessoryType == ItemID.ArmorPolish || accessoryType == ItemID.AdhesiveBandage || accessoryType == ItemID.Bezoar || accessoryType == ItemID.Nazar || accessoryType == ItemID.Megaphone || accessoryType == ItemID.TrifoldMap || accessoryType == ItemID.FastClock || accessoryType == ItemID.Blindfold || accessoryType == ItemID.ArmorBracing || accessoryType == ItemID.MedicatedBandage || accessoryType == ItemID.CountercurseMantra || accessoryType == ItemID.ThePlan)
                        {
                            equipped_to_ankh_material = true;
                            break;
                        }
                    }

                    if (equipped_to_ankh_material)
                    {
                        for (int j = 0; j < Main.player[i].inventory.Length; j++)
                        {
                            int itemType = Main.player[i].inventory[j].type;

                            if (itemType == ItemID.ArmorBracing || itemType == ItemID.Vitamins)
                            {
                                Main.player[i].ClearBuff(BuffID.Weak);
                            }

                            if (itemType == ItemID.ArmorBracing || itemType == ItemID.ArmorPolish)
                            {
                                Main.player[i].ClearBuff(BuffID.BrokenArmor);
                            }

                            if (itemType == ItemID.MedicatedBandage || itemType == ItemID.AdhesiveBandage)
                            {
                                Main.player[i].ClearBuff(BuffID.Bleeding);
                            }

                            if (itemType == ItemID.MedicatedBandage || itemType == ItemID.Bezoar)
                            {
                                Main.player[i].ClearBuff(BuffID.Poisoned);
                            }

                            if (itemType == ItemID.CountercurseMantra || itemType == ItemID.Nazar)
                            {
                                Main.player[i].ClearBuff(BuffID.Cursed);
                            }

                            if (itemType == ItemID.CountercurseMantra || itemType == ItemID.Megaphone)
                            {
                                Main.player[i].ClearBuff(BuffID.Silenced);
                            }

                            if (itemType == ItemID.ThePlan || itemType == ItemID.FastClock)
                            {
                                Main.player[i].ClearBuff(BuffID.Slow);
                            }

                            if (itemType == ItemID.ThePlan || itemType == ItemID.TrifoldMap)
                            {
                                Main.player[i].ClearBuff(BuffID.Confused);
                            }

                            if (itemType == ItemID.Blindfold)
                            {
                                Main.player[i].ClearBuff(BuffID.Darkness);
                            }
                        }
                    }
                }
            }
            #endregion

            if (DD2Event.Ongoing)
            {
                if (skipDD2Wave && DD2Event.TimeLeftBetweenWaves > 60)
                {
                    DD2Event.TimeLeftBetweenWaves = 60;
                }
            }

            #region InvasionModifing
            if (time % 60 == 0)
            {
                if (allPlayersHiddenFromInvasion)
                {
                    if (timeHiddenFromInvasion == 0)
                    {
                        if (Main.netMode == NetmodeID.Server)
                        {
                            ChatHelper.BroadcastChatMessage(NetworkText.FromKey("The invasion can't find anyone on the surface, and will soon leave."), new Color(255, 255, 0));
                        }
                        else if (Main.netMode == NetmodeID.SinglePlayer)
                        {
                            Main.NewText("The invasion can't find anyone on the surface, and will soon leave.", new Color(255, 255, 0));
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
                    updatePacket = true;
                }
            }
            #endregion

            if (dayTime != Main.dayTime)
            {
                dayTime = Main.dayTime;
                updatePacket = true;

                if ((Main.bloodMoon || Main.eclipse) && Main.sundialCooldown > 0)
                {
                    Main.sundialCooldown = 0;
                    sendNetMessageData = true;
                }

                #region New Morning
                if (Main.dayTime)
                {
                    travelingMerchantDiceRolls = NPC.downedPlantBoss ? otherConfig.TravelingMerchantDiceUsesAfterPlantera : Main.hardMode ? otherConfig.TravelingMerchantDiceUsesHardmode : otherConfig.TravelingMerchantDiceUsesBeforeHardmode;

                    anglerQuests = NPC.downedPlantBoss ? fishingConfig.QuestCountAfterPlantera : Main.hardMode ? fishingConfig.QuestCountHardmode : NPC.downedBoss3 ? fishingConfig.QuestCountAfterSkeletron : NPC.downedBoss2 ? fishingConfig.QuestCountAfterInfectionBoss : NPC.downedBoss1 ? fishingConfig.QuestCountAfterEye : fishingConfig.QuestCountBeforeEye;

                    if (otherConfig.HolidayTimelineDaysPerMonth > 0)
                    {
                        int yearLength = otherConfig.HolidayTimelineDaysPerMonth * 12;
                        float halloweenDay = 304f / 365f;
                        float xMasDay = 359f / 365f;

                        halloween = xMas = false;

                        seasonalDay++;
                        if (seasonalDay == (int)Math.Round(yearLength * halloweenDay))
                        {
                            Main.halloween = halloween = true;
                            if (Main.netMode == NetmodeID.Server)
                            {
                                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Misc.StartedVictoryHalloween"), new Color(255, 255, 0));
                            }
                            else
                            {
                                Main.NewText(NetworkText.FromKey("Misc.StartedVictoryHalloween"), new Color(255, 255, 0));
                            }
                        }
                        else if (seasonalDay == (int)Math.Round(yearLength * halloweenDay) + 1)
                        {
                            if (Main.netMode == NetmodeID.Server)
                            {
                                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Misc.EndedVictoryHalloween"), new Color(255, 255, 0));
                            }
                            else
                            {
                                Main.NewText(NetworkText.FromKey("Misc.EndedVictoryHalloween"), new Color(255, 255, 0));
                            }
                        }
                        else if (seasonalDay == (int)Math.Round(yearLength * xMasDay))
                        {
                            Main.xMas = xMas = true;
                            if (Main.netMode == NetmodeID.Server)
                            {
                                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Misc.StartedVictoryXmas"), new Color(255, 255, 0));
                            }
                            else
                            {
                                Main.NewText(NetworkText.FromKey("Misc.StartedVictoryXmas"), new Color(255, 255, 0));
                            }
                        }
                        else if (seasonalDay == (int)Math.Round(yearLength * xMasDay) + 1)
                        {
                            if (Main.netMode == NetmodeID.Server)
                            {
                                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Misc.EndedVictoryXmas"), new Color(255, 255, 0));
                            }
                            else
                            {
                                Main.NewText(NetworkText.FromKey("Misc.EndedVictoryXmas"), new Color(255, 255, 0));
                            }
                        }
                        if (seasonalDay >= yearLength + 1)
                        {
                            seasonalDay = 1;
                        }
                    }
                }
                #endregion
            }

            if (celestialSigil) //TO-DO Remove once 1.4.4+ comes out
            {
                if (NPC.MoonLordCountdown > 720)
                {
                    NPC.MoonLordCountdown = 720;
                }

                celestialSigil = false;
                updatePacket = true;
            }

            #region ClientToServerData
            if (updatePacket && Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = Mod.GetPacket();

                packet.Write((byte)ReducedGrinding.MessageType.anglerQuests);
                packet.Write(anglerQuests);

                packet.Write((byte)ReducedGrinding.MessageType.dayTime);
                packet.Write(dayTime);

                packet.Write((byte)ReducedGrinding.MessageType.seasonalDay);
                packet.Write(seasonalDay);

                packet.Write((byte)ReducedGrinding.MessageType.instantInvasion);
                packet.Write(instantInvasion);

                packet.Write((byte)ReducedGrinding.MessageType.celestialSigil);
                packet.Write(celestialSigil);

                packet.Write((byte)ReducedGrinding.MessageType.travelingMerchantDiceRolls);
                packet.Write(travelingMerchantDiceRolls);

                packet.Write((byte)ReducedGrinding.MessageType.timeHiddenFromInvasion);
                packet.Write(timeHiddenFromInvasion);

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
            if (ReducedGrindingSave.usingFargowiltas)
            {
                //This mod will undo the period timeline feature, so this is here to undo the undo.
                if (!Main.xMas && xMas)
                {
                    Main.xMas = xMas;
                }

                if (!Main.halloween && halloween)
                {
                    Main.halloween = halloween;
                }
            }

            if (advanceMoonPhase)
            {
                advanceMoonPhase = false;
                Main.moonPhase++;
                if (Main.moonPhase >= 8)
                {
                    Main.moonPhase = 0;
                }

                if (Main.bloodMoon && Main.moonPhase == 4)
                {
                    Main.bloodMoon = false;
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
        }
    }
}
