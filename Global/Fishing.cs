using ReducedGrinding.Configuration;
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

            #region Extra Quest Reward Chance
            if (!Update.firstQuest)
            {
                float rewardChance = fishingConfig.Angler.ExtraQuestRewardChance;
                if (Main.rand.Next() > rewardChance)
                {
                    void removeReward(int itemID)
                    {
                        foreach (Terraria.Item item in rewardItems.Reverse<Terraria.Item>())
                        {
                            if (item.type == itemID)
                            {
                                rewardItems.Remove(item);
                            }
                        }
                    }

                    removeReward(ItemID.FishingPotion);
                    removeReward(ItemID.SonarPotion);
                    removeReward(ItemID.CratePotion);

                    removeReward(ItemID.ApprenticeBait);
                    removeReward(ItemID.JourneymanBait);
                    removeReward(ItemID.MasterBait);

                    removeReward(ItemID.PlatinumCoin);
                    removeReward(ItemID.GoldCoin);
                    removeReward(ItemID.SilverCoin);
                    removeReward(ItemID.CopperCoin);

                    removeReward(ItemID.BunnyfishTrophy);
                    removeReward(ItemID.CompassRose);
                    removeReward(ItemID.CouchGag);
                    removeReward(ItemID.Crustography);
                    removeReward(ItemID.Fangs);
                    removeReward(ItemID.GoldfishTrophy);
                    removeReward(ItemID.LifePreserver);
                    removeReward(ItemID.NotSoLostInParadise);
                    removeReward(ItemID.PillaginMePixels);
                    removeReward(ItemID.SeaweedPlanter);
                    removeReward(ItemID.SharkteethTrophy);
                    removeReward(ItemID.ShipInABottle);
                    removeReward(ItemID.SilentFish);
                    removeReward(ItemID.SwordfishTrophy);
                    removeReward(ItemID.TheDuke);
                    removeReward(ItemID.TreasureMap);
                    removeReward(ItemID.WallAnchor);
                    removeReward(ItemID.WhatLurksBelow);

                    if (rewardItems.Count == 0)
                    {
                        Terraria.Item item = new();
                        item.SetDefaults(ItemID.CopperCoin);
                        rewardItems.Add(item);
                    }
                }
            }
            #endregion
        }
    }
}
