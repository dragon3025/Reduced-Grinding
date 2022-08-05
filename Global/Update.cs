using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class Update : ModSystem
    {
        //Gets recording into world save
        public static bool advanceMoonPhase = false;
        public static bool noMoreAnglerResetsToday = false;
        public static bool dayTime = true;
        public static bool timeCharm = false;
        public static int seasonalDay = 1;
        public static bool invasionWithGreaterBattleBuff = false;
        public static bool invasionWithSuperBattleBuff = false;
        public static bool instantInvasion = false;
        public static bool celestialSigil = false;

        public override void PostUpdateTime()
        {
            bool updatePacket = false;
            
            int time = (int)Main.time;

            float sleepBoost = GetInstance<IOtherConfig>().SleepBoostBase;

            bool boostTime = true;
            if (sleepBoost == 0)
                boostTime = false;
            if (Main.fastForwardTime)
                boostTime = false;
            if (Main.CurrentFrameFlags.SleepingPlayersCount != Main.CurrentFrameFlags.ActivePlayersCount)
                boostTime = false;
            if (Main.CurrentFrameFlags.SleepingPlayersCount < 1)
                boostTime = false;

            bool playerWithSleepBuff = false;

            int anglerResetChance;
            if (NPC.downedPlantBoss)
                anglerResetChance = GetInstance<CFishingConfig>().AnglerRecentChanceAfterPlantera;
            else if (Main.hardMode)
                anglerResetChance = GetInstance<CFishingConfig>().AnglerRecentChanceHardmode;
            else
                anglerResetChance = GetInstance<CFishingConfig>().AnglerRecentChanceBeforeHardmode;

            int fishermenCount = 0;
            List<int> activePlayers = new() { };

            bool cancelInvasion = false;
            int invasionType = Main.invasionType;
            bool playerWithGreaterBattleBuff = false;
            bool playerWithSuperBattleBuff = false;

            if (invasionType == 0)
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
                    cancelInvasion = true;
            }

            for (int i = 0; i < 255; i++)
            {
                if (!Main.player[i].active)
                    continue;

                activePlayers.Add(i);

                if (!playerWithGreaterBattleBuff && Main.player[i].FindBuffIndex(BuffType<Buffs.SuperBattle>()) != -1)
                    playerWithGreaterBattleBuff = true;

                if (!playerWithSuperBattleBuff && Main.player[i].FindBuffIndex(BuffType<Buffs.GreaterBattle>()) != -1)
                    playerWithSuperBattleBuff = true;

                Point playerPosition = Main.player[i].Center.ToTileCoordinates();

                if (playerPosition.Y <= Main.worldSurface + 67.5f)
                    cancelInvasion = false;

                if (boostTime && !playerWithSleepBuff && GetInstance<IOtherConfig>().SleepBoostNoPotionBuffMultiplier < 1 && Main.player[i].FindBuffIndex(BuffType<Buffs.Sleep>()) != -1)
                    playerWithSleepBuff = true;

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

                //TO-DO 1.4.4 will add this (I don't know about SugarRush though)
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

            if (cancelInvasion && Main.invasionX == Main.spawnTileX)
            {
                Main.invasionType = InvasionID.None;
                string InvasionLeftMessage = $"{Language.GetTextValue($"Mods.ReducedGrinding.Other.InvasionLeft")}";
                if (Main.netMode == NetmodeID.Server)
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(InvasionLeftMessage), new Color(255, 255, 0)); //TO-DO (I don't think this correct)
                else if (Main.netMode == NetmodeID.SinglePlayer) // Single Player
                    Main.NewText(InvasionLeftMessage, new Color(255, 255, 0));
            }
            else if (invasionType > 0)
            {
                float invasionBoost = 1f;
                if (invasionWithGreaterBattleBuff != playerWithGreaterBattleBuff)
                {
                    updatePacket = true;
                    if (!invasionWithGreaterBattleBuff)
                    {
                        invasionWithGreaterBattleBuff = true;
                        invasionBoost *= GetInstance<HOtherModdedItemsConfig>().GreaterBattlePotionMaxSpawnsMultiplier;
                    }
                    else
                    {
                        invasionWithGreaterBattleBuff = false;
                        invasionBoost /= GetInstance<HOtherModdedItemsConfig>().GreaterBattlePotionMaxSpawnsMultiplier;
                    }
                }
                if (invasionWithSuperBattleBuff != playerWithSuperBattleBuff)
                {
                    updatePacket = true;
                    if (!invasionWithSuperBattleBuff)
                    {
                        invasionWithSuperBattleBuff = true;
                        invasionBoost *= GetInstance<HOtherModdedItemsConfig>().SuperBattlePotionMaxSpawnsMultiplier;
                    }
                    else
                    {
                        invasionWithSuperBattleBuff = false;
                        invasionBoost /= GetInstance<HOtherModdedItemsConfig>().SuperBattlePotionMaxSpawnsMultiplier;
                    }
                }

                float invasionBoostEffect = GetInstance<HOtherModdedItemsConfig>().ModBattlePotionMaxSpawnEffectOnInvasion;
                invasionBoost = (1 * (1 - invasionBoostEffect)) + (invasionBoost * invasionBoostEffect);

                Main.invasionSize = (int)(Main.invasionSize * invasionBoost);
                Main.invasionSizeStart = (int)(Main.invasionSizeStart * invasionBoost);
                Main.invasionProgress = (int)(Main.invasionProgress * invasionBoost);
                Main.invasionProgressMax = (int)(Main.invasionProgressMax * invasionBoost);
            }

            if (boostTime)
            {

                if (!playerWithSleepBuff && GetInstance<IOtherConfig>().SleepBoostNoPotionBuffMultiplier < 1)
                    sleepBoost *= GetInstance<IOtherConfig>().SleepBoostNoPotionBuffMultiplier;

                if (!timeCharm && GetInstance<IOtherConfig>().SleepBoostInactiveTimeCharmMultiplier < 1)
                    sleepBoost *= GetInstance<IOtherConfig>().SleepBoostInactiveTimeCharmMultiplier;

                Main.time += (int)sleepBoost;

                foreach (int i in activePlayers)
                {
                    if (Main.player[i].FindBuffIndex(BuffType<Buffs.Sleep>()) != -1)
                        Main.player[i].buffTime[Main.player[i].FindBuffIndex(BuffType<Buffs.Sleep>())] -= (int)sleepBoost;
                }
            }

            if (anglerResetChance > 0 && !noMoreAnglerResetsToday && Main.anglerWhoFinishedToday.Count > 0)
            {
                if (fishermenCount <= Main.anglerWhoFinishedToday.Count)
                {
                    if (Main.rand.NextBool(anglerResetChance))
                    {
                        Main.AnglerQuestSwap();
                        string newAnglerJobMessage = $"{Language.GetTextValue($"Mods.ReducedGrinding.Other.NewAnglerJob")}";
                        if (Main.netMode == NetmodeID.SinglePlayer)
                            Main.NewText(newAnglerJobMessage, 0, 255, 255);
                        else if (Main.netMode == NetmodeID.Server)
                        {
                            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(newAnglerJobMessage), new Color(0, 255, 255));
                        }
                    }
                    else
                    {
                        noMoreAnglerResetsToday = true;
                        updatePacket = true;
                    }
                }
            }

            if (dayTime != Main.dayTime)
            {
                dayTime = Main.dayTime;
                updatePacket = true;

                if (Main.dayTime)
                {
                    noMoreAnglerResetsToday = false;
                    updatePacket = true;

                    if (GetInstance<IOtherConfig>().HolidayTimelineDaysPerMonth > 0)
                    {
                        int yearLength = GetInstance<IOtherConfig>().HolidayTimelineDaysPerMonth * 12;
                        float halloweenDay = 304f / 365f;
                        float xMasDay = 359f / 365f;

                        seasonalDay++;
                        if (seasonalDay == (int)Math.Round(yearLength * halloweenDay))
                        {
                            Main.halloween = true;
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
                            Main.xMas = true;
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
                        if (seasonalDay == yearLength + 1)
                            seasonalDay = 1;
                    }
                }

            }

            if (celestialSigil) //TO-DO Remove once 1.4.4 comes out
            {
                if (NPC.MoonLordCountdown > 720)
                    NPC.MoonLordCountdown = 720;
                celestialSigil = false;
                updatePacket = true;
            }

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

                packet.Send();
                NetMessage.SendData(MessageID.WorldData);
            }
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
