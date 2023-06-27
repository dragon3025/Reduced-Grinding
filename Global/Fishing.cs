using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class Fishing : ModPlayer
    {
        public override void AnglerQuestReward(float rareMultiplier, List<Terraria.Item> rewardItems)
        {
            #region Fish Coin
            int fishCoinAmount = GetInstance<CFishingConfig>().FishCoinsRewardedForQuest;
            if (fishCoinAmount > 0)
            {
                Terraria.Item coin = new();
                coin.SetDefaults(ItemType<Items.FishCoin>());
                coin.stack = fishCoinAmount;
                rewardItems.Add(coin);
            }
            #endregion

            if (Update.anglerQuests == 0)
            {
                return;
            }

            Global.Update.anglerResetTimer = 600;
            for (int i = 0; i < Main.player.Length; i++)
            {
                if (!Main.player[i].active)
                {
                    continue;
                }

                if (Main.anglerWhoFinishedToday.Contains(Main.player[i].name))
                {
                    continue;
                }

                for (int j = 0; j < Main.player[i].inventory.Length; j++)
                {
                    if (Main.player[i].inventory[j].type == Main.anglerQuestItemNetIDs[Main.anglerQuest])
                    {
                        Global.Update.anglerResetTimer = 3600;
                        goto finishedQuestFishCheck;
                    }
                }
            }
            finishedQuestFishCheck: { }

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                ModPacket packet = Mod.GetPacket();
                packet.Write((byte)ReducedGrinding.MessageType.anglerResetTimer);
                packet.Write(Global.Update.anglerResetTimer);
                packet.Send();
            }
        }

        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
        {
            if (Update.anglerQuests == 0 || Main.anglerWhoFinishedToday.Contains(Main.LocalPlayer.name))
            {
                return;
            }

            if (itemDrop == Main.anglerQuestItemNetIDs[Main.anglerQuest])
            {
                Global.Update.anglerResetTimer = 3600;
            }
            else
            {
                Global.Update.anglerResetTimer = Math.Min(3600, Global.Update.anglerResetTimer + 600);
            }

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                ModPacket packet = Mod.GetPacket();
                packet.Write((byte)ReducedGrinding.MessageType.anglerResetTimer);
                packet.Write(Global.Update.anglerResetTimer);
                packet.Send();
            }
        }
    }
}
