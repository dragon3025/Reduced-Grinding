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

            bool resetWait = false;
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
                        resetWait = true;
                        break;
                    }
                }

                if (resetWait)
                {
                    break;
                }
            }

            if (resetWait)
            {
                Global.Update.anglerResetTimer = 600;
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
}
