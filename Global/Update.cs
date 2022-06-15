using Microsoft.Xna.Framework;
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
        public static int seasonalDay = 0;

        public override void PostUpdateTime()
        {
            float sleepBoost = GetInstance<IOtherConfig>().SleepBoostBase;

            bool boostTime = true;
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
            if ((int)Main.time % 60 == 0 && GetInstance<IOtherConfig>().CancelInvasionsIfAllPlayersAreUnderground)
            {
                int invasionType = Main.invasionType;
                if (invasionType == InvasionID.PirateInvasion || invasionType == InvasionID.GoblinArmy || invasionType == InvasionID.MartianMadness || invasionType == InvasionID.SnowLegion)
                    cancelInvasion = true;
            }

            for (int i = 0; i < 255; i++)
            {
                if (!Main.player[i].active)
                    continue;

                activePlayers.Add(i);

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

            if (cancelInvasion && Main.invasionX == Main.spawnTileX)
            {
                Main.invasionType = InvasionID.None;
                if (Main.netMode == NetmodeID.Server)
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey("The invasion is gone."), new Color(255, 255, 0)); //TO-DO (I don't think this correct)
                else if (Main.netMode == NetmodeID.SinglePlayer) // Single Player
                    Main.NewText("The invasion is gone.", new Color(255, 255, 0));
            }

            if (boostTime)
            {

                if (!playerWithSleepBuff && GetInstance<IOtherConfig>().SleepBoostNoPotionBuffMultiplier < 1)
                    sleepBoost *= GetInstance<IOtherConfig>().SleepBoostNoPotionBuffMultiplier;

                if (!timeCharm && GetInstance<IOtherConfig>().SleepBoostTimeCharmMultiplier < 1)
                    sleepBoost *= GetInstance<IOtherConfig>().SleepBoostTimeCharmMultiplier;

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
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                        if (Main.netMode == NetmodeID.SinglePlayer)
                            Main.NewText("The Angler has another job for you!", 0, 255, 255);
                        else if (Main.netMode == NetmodeID.Server)
                            ChatHelper.BroadcastChatMessage(NetworkText.FromKey("The Angler has another job for you!"), new Color(0, 255, 255));
                    }
                    else
                        noMoreAnglerResetsToday = true;
                }
            }

            if (Main.dayTime && dayTime != Main.dayTime)
            {
                noMoreAnglerResetsToday = false;

                if (GetInstance<IOtherConfig>().PeriodicHolidayTimelineDayLength > 0)
                {
                    int dayLength = GetInstance<IOtherConfig>().PeriodicHolidayTimelineDayLength;
                    if (seasonalDay == 0)
                        seasonalDay = 1;
                    else
                    {
                        seasonalDay++;
                        if (seasonalDay == dayLength * 9 + 1)
                        {
                            Main.halloween = true;
                            if (Main.netMode == NetmodeID.Server)
                                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Misc.StartedVictoryHalloween"), new Color(255, 255, 0));
                            else
                                Main.NewText(NetworkText.FromKey("Misc.StartedVictoryHalloween"), new Color(255, 255, 0));
                        }
                        else if (seasonalDay == dayLength * 9 + 2)
                        {
                            if (Main.netMode == NetmodeID.Server)
                                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Misc.EndedVictoryHalloween"), new Color(255, 255, 0));
                            else
                                Main.NewText(NetworkText.FromKey("Misc.EndedVictoryHalloween"), new Color(255, 255, 0));
                        }
                        else if (seasonalDay == dayLength * 12)
                        {
                            Main.xMas = true;
                            if (Main.netMode == NetmodeID.Server)
                                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Misc.StartedVictoryXmas"), new Color(255, 255, 0));
                            else
                                Main.NewText(NetworkText.FromKey("Misc.StartedVictoryXmas"), new Color(255, 255, 0));
                        }
                        else if (seasonalDay > dayLength * 12)
                        {
                            seasonalDay = 1;
                            if (Main.netMode == NetmodeID.Server)
                                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Misc.EndedVictoryXmas"), new Color(255, 255, 0));
                            else
                                Main.NewText(NetworkText.FromKey("Misc.EndedVictoryXmas"), new Color(255, 255, 0));
                        }
                    }
                }
            }
            if (dayTime != Main.dayTime)
            {
                dayTime = Main.dayTime;
            }

            if (Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = Mod.GetPacket();

                packet.Write((byte)ReducedGrinding.MessageType.noMoreAnglerResetsToday);
                packet.Write(noMoreAnglerResetsToday);

                packet.Write((byte)ReducedGrinding.MessageType.dayTime);
                packet.Write(dayTime);

                packet.Write((byte)ReducedGrinding.MessageType.timeCharm);
                packet.Write(timeCharm);

                packet.Write((byte)ReducedGrinding.MessageType.seasonalDay);
                packet.Write(seasonalDay);

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
