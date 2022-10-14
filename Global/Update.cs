using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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
        //Gets recorded into world save
        public static bool noMoreAnglerResetsToday = false;
        public static bool dayTime = true;
        public static int seasonalDay = 1;
        public static bool invasionWithGreaterBattleBuff = false;
        public static bool invasionWithSuperBattleBuff = false;
        public static int travelingMerchantDiceRolls = NPC.downedPlantBoss ? GetInstance<IOtherConfig>().TravelingMerchantDiceUsesAfterPlantera : Main.hardMode ? GetInstance<IOtherConfig>().TravelingMerchantDiceUsesHardmode : GetInstance<IOtherConfig>().TravelingMerchantDiceUsesBeforeHardmode;

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
                return;
            if (!(Main.CurrentFrameFlags.SleepingPlayersCount == Main.CurrentFrameFlags.ActivePlayersCount && Main.CurrentFrameFlags.SleepingPlayersCount > 0))
                return;

            int increase;

            if (NPC.downedPlantBoss)
                increase = GetInstance<IOtherConfig>().SleepRateIncreasePostPlantera;
            else if (Main.hardMode)
                increase = GetInstance<IOtherConfig>().SleepRateIncreaseHardmode;
            else
                increase = GetInstance<IOtherConfig>().SleepRateIncreasePreHardmode;

            if (increase > 0)
            {
                for (int i = 0; i < 255; i++)
                {
                    if (!Main.player[i].active)
                        continue;

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

            int anglerResetChance;
            if (NPC.downedPlantBoss)
                anglerResetChance = GetInstance<CFishingConfig>().AnglerRecentChanceAfterPlantera;
            else if (Main.hardMode)
                anglerResetChance = GetInstance<CFishingConfig>().AnglerRecentChanceHardmode;
            else
                anglerResetChance = GetInstance<CFishingConfig>().AnglerRecentChanceBeforeHardmode;

            int fishermenCount = 0;
            List<int> activePlayers = new() { };

            bool allPlayersHiddenFromInvasion = false;
            int invasionType = Main.invasionType;
            bool playerWithGreaterBattleBuff = false;
            bool playerWithSuperBattleBuff = false;

            int BattlePotionsAffectInvasions = GetInstance<HOtherModdedItemsConfig>().BattlePotionsAffectInvasions;
            bool useInvasionBuffing = false;
            if (BattlePotionsAffectInvasions > 1 && Main.invasionType != InvasionID.None)
            {
                if (BattlePotionsAffectInvasions == 2)
                    useInvasionBuffing = true;
                else if (invasionType == InvasionID.PirateInvasion || invasionType == InvasionID.GoblinArmy || invasionType == InvasionID.MartianMadness || invasionType == InvasionID.SnowLegion)
                    useInvasionBuffing = true;
            }

            if (invasionType == InvasionID.None)
            {
                invasionWithGreaterBattleBuff = false;
                invasionWithSuperBattleBuff = false;
            }
            else if (instantInvasion)
            {
                Main.invasionX = Main.spawnTileX;
                instantInvasion = false;
                updatePacket = true;
            }

            if (time % 60 == 0 && GetInstance<IOtherConfig>().CancelInvasionsIfAllPlayersAreUnderground)
            {
                if (invasionType == InvasionID.PirateInvasion || invasionType == InvasionID.GoblinArmy || invasionType == InvasionID.MartianMadness || invasionType == InvasionID.SnowLegion)
                    allPlayersHiddenFromInvasion = true;
            }

            #region For Each Player

            for (int i = 0; i < 255; i++)
            {
                if (!Main.player[i].active)
                    continue;

                activePlayers.Add(i);

                if (useInvasionBuffing)
                {
                    if (!playerWithGreaterBattleBuff && Main.player[i].FindBuffIndex(BuffType<Buffs.SuperBattle>()) != -1)
                        playerWithGreaterBattleBuff = true;
                    if (!playerWithSuperBattleBuff && Main.player[i].FindBuffIndex(BuffType<Buffs.GreaterBattle>()) != -1)
                        playerWithSuperBattleBuff = true;
                }

                Point playerPosition = Main.player[i].Center.ToTileCoordinates();

                if (allPlayersHiddenFromInvasion && playerPosition.Y <= Main.worldSurface + 67.5f)
                    allPlayersHiddenFromInvasion = false;

                if (anglerResetChance > 0 && !noMoreAnglerResetsToday && Main.anglerWhoFinishedToday.Count > 0)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        int armorType = Main.player[i].armor[j].type;
                        if (armorType == ItemID.AnglerHat || armorType == ItemID.AnglerVest || armorType == ItemID.AnglerPants)
                        {
                            fishermenCount++;
                            break;
                        }
                    }
                }

                if (GetInstance<IOtherConfig>().AnkhMaterialUseFromInventory)
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
                                Main.player[i].ClearBuff(BuffID.Weak);

                            if (itemType == ItemID.ArmorBracing || itemType == ItemID.ArmorPolish)
                                Main.player[i].ClearBuff(BuffID.BrokenArmor);

                            if (itemType == ItemID.MedicatedBandage || itemType == ItemID.AdhesiveBandage)
                                Main.player[i].ClearBuff(BuffID.Bleeding);
                            if (itemType == ItemID.MedicatedBandage || itemType == ItemID.Bezoar)
                                Main.player[i].ClearBuff(BuffID.Poisoned);

                            if (itemType == ItemID.CountercurseMantra || itemType == ItemID.Nazar)
                                Main.player[i].ClearBuff(BuffID.Cursed);
                            if (itemType == ItemID.CountercurseMantra || itemType == ItemID.Megaphone)
                                Main.player[i].ClearBuff(BuffID.Silenced);

                            if (itemType == ItemID.ThePlan || itemType == ItemID.FastClock)
                                Main.player[i].ClearBuff(BuffID.Slow);
                            if (itemType == ItemID.ThePlan || itemType == ItemID.TrifoldMap)
                                Main.player[i].ClearBuff(BuffID.Confused);

                            if (itemType == ItemID.Blindfold)
                                Main.player[i].ClearBuff(BuffID.Darkness);
                        }
                    }
                }

                //TO-DO 1.4.4+ will add this (I don't know about SugarRush though)
                if (Main.player[i].FindBuffIndex(BuffID.Sharpened) != -1)
                    Main.player[i].buffTime[Main.player[i].FindBuffIndex(BuffID.Sharpened)] = 600;

                if (Main.player[i].FindBuffIndex(BuffID.Clairvoyance) != -1)
                    Main.player[i].buffTime[Main.player[i].FindBuffIndex(BuffID.Clairvoyance)] = 600;

                if (Main.player[i].FindBuffIndex(BuffID.AmmoBox) != -1)
                    Main.player[i].buffTime[Main.player[i].FindBuffIndex(BuffID.AmmoBox)] = 600;

                if (Main.player[i].FindBuffIndex(BuffID.Bewitched) != -1)
                    Main.player[i].buffTime[Main.player[i].FindBuffIndex(BuffID.Bewitched)] = 600;

                if (Main.player[i].FindBuffIndex(BuffID.SugarRush) != -1)
                    Main.player[i].buffTime[Main.player[i].FindBuffIndex(BuffID.SugarRush)] = 600;
            }
            #endregion

            #region InvasionModifing
            if (time % 60 == 0)
            {
                if (allPlayersHiddenFromInvasion)
                {
                    if (timeHiddenFromInvasion == 0)
                    {
                        if (Main.netMode == NetmodeID.Server)
                            ChatHelper.BroadcastChatMessage(NetworkText.FromKey("The invasion can't find anyone on the surface, and will soon leave."), new Color(255, 255, 0));
                        else if (Main.netMode == NetmodeID.SinglePlayer) // Single Player
                            Main.NewText("The invasion can't find anyone on the surface, and will soon leave.", new Color(255, 255, 0));
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
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey("The invasion couldn't find anyone, so they left."), new Color(255, 255, 0));
                else if (Main.netMode == NetmodeID.SinglePlayer) // Single Player
                    Main.NewText("The invasion couldn't find anyone, so they left.", new Color(255, 255, 0));
                timeHiddenFromInvasion = 0;
                updatePacket = true;
            }
            else if (invasionType > 0)
            {
                float invasionBoost = 1f;
                if (invasionWithGreaterBattleBuff != playerWithGreaterBattleBuff)
                {
                    updatePacket = true;
                    if (!invasionWithGreaterBattleBuff)
                        invasionBoost *= 2;
                    else
                        invasionBoost /= 2;
                    invasionWithGreaterBattleBuff = !invasionWithGreaterBattleBuff;
                }
                if (invasionWithSuperBattleBuff != playerWithSuperBattleBuff)
                {
                    updatePacket = true;
                    if (!invasionWithSuperBattleBuff)
                        invasionBoost *= 2;
                    else
                        invasionBoost /= 2;
                    invasionWithSuperBattleBuff = !invasionWithSuperBattleBuff;
                }

                float invasionBoostEffect = GetInstance<HOtherModdedItemsConfig>().ModBattlePotionMaxSpawnEffectOnInvasion;
                invasionBoost = (1 * (1 - invasionBoostEffect)) + (invasionBoost * invasionBoostEffect);

                Main.invasionSize = (int)(Main.invasionSize * invasionBoost);
                Main.invasionSizeStart = (int)(Main.invasionSizeStart * invasionBoost);
                Main.invasionProgress = (int)(Main.invasionProgress * invasionBoost);
                Main.invasionProgressMax = (int)(Main.invasionProgressMax * invasionBoost);
            }
            #endregion

            #region Angler
            if (anglerResetChance > 0 && !noMoreAnglerResetsToday && Main.anglerWhoFinishedToday.Count > 0)
            {
                if (fishermenCount <= Main.anglerWhoFinishedToday.Count)
                {
                    if (Main.rand.NextBool(anglerResetChance))
                    {
                        Main.AnglerQuestSwap();
                        if (Main.netMode == NetmodeID.SinglePlayer)
                            Main.NewText("The Angler decided to give you another job.", 0, 255, 255);
                        else if (Main.netMode == NetmodeID.Server)
                        {
                            ChatHelper.BroadcastChatMessage(NetworkText.FromKey("The Angler decided to give you another job."), new Color(0, 255, 255));
                        }
                    }
                    else
                    {
                        noMoreAnglerResetsToday = true;
                        updatePacket = true;
                    }
                }
            }
            #endregion


            if (dayTime != Main.dayTime)
            {
                dayTime = Main.dayTime;
                updatePacket = true;

                #region NewDay
                if (Main.dayTime)
                {
                    travelingMerchantDiceRolls = NPC.downedPlantBoss ? GetInstance<IOtherConfig>().TravelingMerchantDiceUsesAfterPlantera : Main.hardMode ? GetInstance<IOtherConfig>().TravelingMerchantDiceUsesHardmode : GetInstance<IOtherConfig>().TravelingMerchantDiceUsesBeforeHardmode;
                    noMoreAnglerResetsToday = false;

                    if (GetInstance<IOtherConfig>().HolidayTimelineDaysPerMonth > 0)
                    {
                        int yearLength = GetInstance<IOtherConfig>().HolidayTimelineDaysPerMonth * 12;
                        float halloweenDay = 304f / 365f;
                        float xMasDay = 359f / 365f;

                        halloween = xMas = false;

                        seasonalDay++;
                        if (seasonalDay == (int)Math.Round(yearLength * halloweenDay))
                        {
                            Main.halloween = halloween = true;
                            if (Main.netMode == NetmodeID.Server)
                                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Misc.StartedVictoryHalloween"), new Color(255, 255, 0));
                            else
                                Main.NewText(NetworkText.FromKey("Misc.StartedVictoryHalloween"), new Color(255, 255, 0));
                        }
                        else if (seasonalDay == (int)Math.Round(yearLength * halloweenDay) + 1)
                        {
                            if (Main.netMode == NetmodeID.Server)
                                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Misc.EndedVictoryHalloween"), new Color(255, 255, 0));
                            else
                                Main.NewText(NetworkText.FromKey("Misc.EndedVictoryHalloween"), new Color(255, 255, 0));
                        }
                        else if (seasonalDay == (int)Math.Round(yearLength * xMasDay))
                        {
                            Main.xMas = xMas = true;
                            if (Main.netMode == NetmodeID.Server)
                                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Misc.StartedVictoryXmas"), new Color(255, 255, 0));
                            else
                                Main.NewText(NetworkText.FromKey("Misc.StartedVictoryXmas"), new Color(255, 255, 0));
                        }
                        else if (seasonalDay == (int)Math.Round(yearLength * xMasDay) + 1)
                        {
                            if (Main.netMode == NetmodeID.Server)
                                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Misc.EndedVictoryXmas"), new Color(255, 255, 0));
                            else
                                Main.NewText(NetworkText.FromKey("Misc.EndedVictoryXmas"), new Color(255, 255, 0));
                        }
                        if (seasonalDay >= yearLength + 1)
                            seasonalDay = 1;
                    }
                }
                #endregion
            }

            if (celestialSigil) //TO-DO Remove once 1.4.4+ comes out
            {
                if (NPC.MoonLordCountdown > 720)
                    NPC.MoonLordCountdown = 720;
                celestialSigil = false;
                updatePacket = true;
            }

            #region ClientToServerData
            if (updatePacket && Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = Mod.GetPacket();

                packet.Write((byte)ReducedGrinding.MessageType.noMoreAnglerResetsToday);
                packet.Write(noMoreAnglerResetsToday);

                packet.Write((byte)ReducedGrinding.MessageType.dayTime);
                packet.Write(dayTime);

                packet.Write((byte)ReducedGrinding.MessageType.seasonalDay);
                packet.Write(seasonalDay);

                packet.Write((byte)ReducedGrinding.MessageType.invasionWithGreaterBattleBuff);
                packet.Write(invasionWithGreaterBattleBuff);

                packet.Write((byte)ReducedGrinding.MessageType.invasionWithSuperBattleBuff);
                packet.Write(invasionWithSuperBattleBuff);

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

            if (sendNetMessageData)
                NetMessage.SendData(MessageID.WorldData);
            #endregion
        }

        public override void PostUpdateWorld()
        {
            if (ReducedGrindingSave.usingFargowiltas)
            {
                //This mod will undo the period timeline feature, so this is here to undo the undo.
                if (!Main.xMas && xMas)
                    Main.xMas = xMas;
                if (!Main.halloween && halloween)
                    Main.halloween = halloween;
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
                    Main.bloodMoon = false;

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
