using ReducedGrinding.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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
            int fishCoinAmount = fishingConfig.FishCoinsRewardedForQuest;
            if (fishCoinAmount > 0)
            {
                Terraria.Item coin = new();
                coin.SetDefaults(ItemType<Items.FishCoin>());
                coin.stack = fishCoinAmount;
                rewardItems.Add(coin);
            }

            float coinMultiplier = fishingConfig.Angler.ExtraQuestRewardValueMultiplier;
            if (coinMultiplier < 1f)
            {
                int coinConversion = 0;
                void convertToCoins(int itemID, int coinValue)
                {
                    foreach (Terraria.Item item in rewardItems.Reverse<Terraria.Item>())
                    {
                        if (item.type == itemID)
                        {
                            int stackSize = item.stack;
                            string name = item.Name;
                            rewardItems.Remove(item);
                            coinConversion += (int)(stackSize * coinValue * coinMultiplier);
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
                    convertToCoins(i, buyPrice(0, 0, 50));
                }

                convertToCoins(ItemID.FishingPotion, buyPrice(0, 0, 2));
                convertToCoins(ItemID.SonarPotion, buyPrice(0, 0, 2));
                convertToCoins(ItemID.CratePotion, buyPrice(0, 0, 2));

                convertToCoins(ItemID.TreasureMap, buyPrice(0, 1));
                convertToCoins(ItemID.SeaweedPlanter, buyPrice(0, 1));
                convertToCoins(ItemID.ShipInABottle, buyPrice(0, 3));

                convertToCoins(ItemID.ApprenticeBait, buyPrice(0, 0, 1));
                convertToCoins(ItemID.JourneymanBait, buyPrice(0, 0, 3));
                convertToCoins(ItemID.MasterBait, buyPrice(0, 0, 10));

                convertToCoins(ItemID.PlatinumCoin, buyPrice(1));
                convertToCoins(ItemID.GoldCoin, buyPrice(0, 1));
                convertToCoins(ItemID.SilverCoin, buyPrice(0, 0, 1));
                convertToCoins(ItemID.CopperCoin, buyPrice(0, 0, 0, 1));

                void addCoins(int coinID, int value)
                {
                    Terraria.Item coin = new();
                    coin.SetDefaults(coinID);
                    int stack = 0;
                    while (coinConversion >= value)
                    {
                        stack++;
                        coinConversion -= value;
                        if (coinConversion < value)
                        {
                            coin.stack = stack;
                            rewardItems.Add(coin);
                        }
                    }
                }

                addCoins(ItemID.PlatinumCoin, buyPrice(1));
                addCoins(ItemID.GoldCoin, buyPrice(0, 1));
                addCoins(ItemID.SilverCoin, buyPrice(0, 0, 1));
                addCoins(ItemID.CopperCoin, buyPrice(0, 0, 0, 1));
            }
        }
    }
}
