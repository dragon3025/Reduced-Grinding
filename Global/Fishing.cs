﻿using ReducedGrinding.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class Fishing : ModPlayer
    {
        readonly static CFishingConfig fishingConfig = GetInstance<CFishingConfig>();

        public override void AnglerQuestReward(float rareMultiplier, List<Terraria.Item> rewardItems)
        {
            #region Fish Coin
            int fishCoinAmount = fishingConfig.FishCoinsRewardedForQuest;
            if (fishCoinAmount > 0)
            {
                Terraria.Item coin = new();
                coin.SetDefaults(ItemType<Items.FishCoin>());
                coin.stack = fishCoinAmount;
                rewardItems.Add(coin);
            }
            #endregion

            #region Extra Quest Reward Reduction
            if (Update.anglerQuests > 0)
            {
                int coinRewardAmount = 0;

                void removeReward(int itemID)
                {
                    foreach (Terraria.Item item in rewardItems.Reverse<Terraria.Item>())
                    {
                        if (item.type == itemID)
                        {
                            if (item.type == ItemID.CopperCoin)
                            {
                                coinRewardAmount += item.stack;
                            }
                            else if (item.type == ItemID.SilverCoin)
                            {
                                coinRewardAmount += item.stack * 100;
                            }
                            else if (item.type == ItemID.GoldCoin)
                            {
                                coinRewardAmount += item.stack * 10000;
                            }
                            else if (item.type == ItemID.PlatinumCoin)
                            {
                                coinRewardAmount += item.stack * 1000000;
                            }
                            rewardItems.Remove(item);
                        }
                    }
                }

                if (Main.rand.NextFloat() < fishingConfig.Angler.LowQualityRemovalChance)
                {
                    removeReward(ItemID.FishingPotion);
                    removeReward(ItemID.SonarPotion);
                    removeReward(ItemID.CratePotion);

                    removeReward(ItemID.ApprenticeBait);
                    removeReward(ItemID.JourneymanBait);
                    removeReward(ItemID.MasterBait);
                }

                removeReward(ItemID.PlatinumCoin);
                removeReward(ItemID.GoldCoin);
                removeReward(ItemID.SilverCoin);
                removeReward(ItemID.CopperCoin);

                coinRewardAmount = (int)(coinRewardAmount * fishingConfig.Angler.CoinMultiplier);

                if (coinRewardAmount > 1000000)
                {
                    Terraria.Item item = new();
                    item.SetDefaults(ItemID.PlatinumCoin);
                    item.stack = (coinRewardAmount / 1000000);
                    rewardItems.Add(item);
                    coinRewardAmount %= 1000000;
                }
                if (coinRewardAmount > 10000)
                {
                    Terraria.Item item = new();
                    item.SetDefaults(ItemID.GoldCoin);
                    item.stack = (coinRewardAmount / 10000);
                    rewardItems.Add(item);
                    coinRewardAmount %= 10000;
                }
                if (coinRewardAmount > 100)
                {
                    Terraria.Item item = new();
                    item.SetDefaults(ItemID.SilverCoin);
                    item.stack = (coinRewardAmount / 100);
                    rewardItems.Add(item);
                    coinRewardAmount %= 100;
                }
                if (coinRewardAmount > 0)
                {
                    Terraria.Item item = new();
                    item.SetDefaults(ItemID.CopperCoin);
                    item.stack = coinRewardAmount;
                    rewardItems.Add(item);
                }

                if (rewardItems.Count == 0)
                {
                    Terraria.Item item = new();
                    item.SetDefaults(ItemID.CopperCoin);
                    rewardItems.Add(item);
                }
            }
            #endregion
        }
    }
}
