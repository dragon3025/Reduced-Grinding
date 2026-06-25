using ReducedGrinding.Common.ModSystems;
using ReducedGrinding.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.ModPlayers
{
    public class QuestRewards : ModPlayer
    {
        private static readonly AnglerConfig anglerConfig = GetInstance<AnglerConfig>();

        public override void AnglerQuestReward(float rareMultiplier, List<Item> rewardItems)
        {
            if (UnlimitedAnglerQuests.firstQuestOfTheDay)
            {
                return;
            }

            int coinRewardAmount = 0;

            void removeReward(int itemID)
            {
                foreach (Item item in rewardItems.Reverse<Item>())
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

            if (Main.rand.NextFloat() < anglerConfig.LowQualityRemovalChance)
            {
                removeReward(ItemID.FishingPotion);
                removeReward(ItemID.SonarPotion);
                removeReward(ItemID.CratePotion);

                removeReward(ItemID.ApprenticeBait);
                removeReward(ItemID.JourneymanBait);
                removeReward(ItemID.MasterBait);
            }

            if (anglerConfig.CoinMultiplier >= 1f)
            {
                return;
            }

            removeReward(ItemID.PlatinumCoin);
            removeReward(ItemID.GoldCoin);
            removeReward(ItemID.SilverCoin);
            removeReward(ItemID.CopperCoin);

            coinRewardAmount = (int)(coinRewardAmount * anglerConfig.CoinMultiplier);

            if (coinRewardAmount > 1000000)
            {
                Item item = new();
                item.SetDefaults(ItemID.PlatinumCoin);
                item.stack = coinRewardAmount / 1000000;
                rewardItems.Add(item);
                coinRewardAmount %= 1000000;
            }
            if (coinRewardAmount > 10000)
            {
                Item item = new();
                item.SetDefaults(ItemID.GoldCoin);
                item.stack = coinRewardAmount / 10000;
                rewardItems.Add(item);
                coinRewardAmount %= 10000;
            }
            if (coinRewardAmount > 100)
            {
                Item item = new();
                item.SetDefaults(ItemID.SilverCoin);
                item.stack = coinRewardAmount / 100;
                rewardItems.Add(item);
                coinRewardAmount %= 100;
            }
            if (coinRewardAmount > 0)
            {
                Item item = new();
                item.SetDefaults(ItemID.CopperCoin);
                item.stack = coinRewardAmount;
                rewardItems.Add(item);
            }

            if (rewardItems.Count == 0)
            {
                Item item = new();
                item.SetDefaults(ItemID.CopperCoin);
                rewardItems.Add(item);
            }
        }
    }
}
