using ReducedGrinding.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.Item;
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
                    void rollForRemoval(int itemID)
                    {
                        foreach (Terraria.Item item in rewardItems.Reverse<Terraria.Item>())
                        {
                            if (item.type == itemID)
                            {
                                if (Main.rand.NextFloat() > rewardChance)
                                {
                                    rewardItems.Remove(item);
                                }
                            }
                        }
                    }

                    int[] fiftySilverItems = new int[]
                    {
                    ItemID.LifePreserver,
                    ItemID.CompassRose,
                    ItemID.WallAnchor,
                    ItemID.PillaginMePixels,
                    ItemID.GoldfishTrophy,
                    ItemID.BunnyfishTrophy,
                    ItemID.SwordfishTrophy,
                    ItemID.SharkteethTrophy,
                    ItemID.NotSoLostInParadise,
                    ItemID.Crustography,
                    ItemID.WhatLurksBelow,
                    ItemID.Fangs,
                    ItemID.CouchGag,
                    ItemID.SilentFish,
                    ItemID.TheDuke
                    };

                    foreach (int i in fiftySilverItems)
                    {
                        rollForRemoval(i);
                    }

                    rollForRemoval(ItemID.FishingPotion);
                    rollForRemoval(ItemID.SonarPotion);
                    rollForRemoval(ItemID.CratePotion);
                    rollForRemoval(ItemID.TreasureMap);
                    rollForRemoval(ItemID.SeaweedPlanter);
                    rollForRemoval(ItemID.ShipInABottle);
                    rollForRemoval(ItemID.ApprenticeBait);
                    rollForRemoval(ItemID.JourneymanBait);
                    rollForRemoval(ItemID.MasterBait);
                    rollForRemoval(ItemID.PlatinumCoin);
                    rollForRemoval(ItemID.GoldCoin);
                    rollForRemoval(ItemID.SilverCoin);
                    rollForRemoval(ItemID.CopperCoin);
                }
            }
            #endregion
        }
    }
}
