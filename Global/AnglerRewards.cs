using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class AnglerRewards : ModPlayer
    {
        readonly static CFishingConfig fishingConfig = GetInstance<CFishingConfig>();

        public override void AnglerQuestReward(float rareMultiplier, List<Terraria.Item> rewardItems)
        {
            //TO-DO When 1.4.4+ comes out, a lot of stuff may need adjusted or removed (including the Fish Merchant)
            int questsDone = Player.anglerQuestsFinished;

            #region Remove Furniture
            bool addPotion = false;
            int[] furniturePool = new int[]
            {
                2442, //Furniture
                2443,
                2444,
                2445,
                2497,
                2495,
                2446,
                2447,
                2448,
                2449,
                2490,
                2496
            };
            foreach (int i in furniturePool)
            {
                for (int j = 0; j < rewardItems.Count; j++)
                {
                    if (rewardItems[j].type == i)
                    {
                        addPotion = true;
                        rewardItems.RemoveAt(j);
                        goto furnitureTestFinished;
                    }
                }
            }
            furnitureTestFinished: { };
            #endregion

            #region Modify Requirements
            Terraria.Item rewardItem = new();
            List<Terraria.Item> itemsToRemove = new();

            void removeReward(int requirement, int vanillaRequirement, int index, int item)
            {
                if (requirement != vanillaRequirement && questsDone == vanillaRequirement && rewardItems[index].type == item)
                {
                    itemsToRemove.Add(rewardItems[index]);
                    addPotion = true;
                }
            }

            void addReward(int requirement, int vanillaRequirement, int item)
            {
                if (requirement != vanillaRequirement && questsDone == requirement)
                {
                    rewardItem.SetDefaults(item);
                    rewardItems.Add(rewardItem);
                }
            }

            for (int i = 0; i < rewardItems.Count; i++)
            {
                //Don't remove items here, or it will mess with Count. Wait until after this for loop.
                removeReward(fishingConfig.FuzzyCarrotQuestRewarded, 5, i, ItemID.FuzzyCarrot);
                removeReward(fishingConfig.AnglerHatQuestRewarded, 10, i, ItemID.AnglerHat);
                removeReward(fishingConfig.AnglerVestQuestRewarded, 15, i, ItemID.AnglerVest);
                removeReward(fishingConfig.AnglerPantsQuestRewarded, 20, i, ItemID.AnglerPants);
                removeReward(fishingConfig.BottomlessWaterBucketQuestRewarded, 0, i, ItemID.BottomlessBucket);
                removeReward(fishingConfig.GoldenFishingRodQuestRewarded, 30, i, ItemID.GoldenFishingRod);
            }

            foreach (Terraria.Item item in itemsToRemove)
            {
                rewardItems.Remove(item);
            }

            addReward(fishingConfig.FuzzyCarrotQuestRewarded, 5, ItemID.FuzzyCarrot);
            addReward(fishingConfig.AnglerHatQuestRewarded, 10, ItemID.AnglerHat);
            addReward(fishingConfig.AnglerVestQuestRewarded, 15, ItemID.AnglerVest);
            addReward(fishingConfig.AnglerPantsQuestRewarded, 20, ItemID.AnglerPants);
            addReward(fishingConfig.BottomlessWaterBucketQuestRewarded, 0, ItemID.BottomlessBucket);
            addReward(fishingConfig.GoldenFishingRodQuestRewarded, 30, ItemID.GoldenFishingRod);
            #endregion

            #region If a Furniture or Reward Item Was Removed, Add a Potion
            if (addPotion)
            {
                Terraria.Item newPotionItem = new();
                switch (Main.rand.Next(3))
                {
                    case 0:
                        newPotionItem.SetDefaults(2354);
                        newPotionItem.stack = Main.rand.Next(2, 6);
                        break;
                    case 1:
                        newPotionItem.SetDefaults(2355);
                        newPotionItem.stack = Main.rand.Next(2, 6);
                        break;
                    default:
                        newPotionItem.SetDefaults(2356);
                        newPotionItem.stack = Main.rand.Next(2, 6);
                        break;
                }
                rewardItems.Add(newPotionItem);
            }
            #endregion

            #region New Furniture Roll (Uses 1.4.4+ calculation, except furniture that only appear in 1.4.4+ return as nothing)
            float chanceCalculation = MathHelper.Lerp((1f - rareMultiplier), 1f, Math.Min(1f, (float)questsDone / (float)100));
            if (!(chanceCalculation >= 1f) && !(Main.rand.NextFloat() <= chanceCalculation))
            { }
            else
            {
                Terraria.Item furnitureItem = new();
                furnitureItem.type = ItemID.None;
                switch (Main.rand.Next(19))
                {
                    case 0:
                        furnitureItem.SetDefaults(2442);
                        break;
                    case 1:
                        furnitureItem.SetDefaults(2443);
                        break;
                    case 2:
                        furnitureItem.SetDefaults(2444);
                        break;
                    case 3:
                        furnitureItem.SetDefaults(2445);
                        break;
                    case 4:
                        furnitureItem.SetDefaults(2497);
                        break;
                    case 5:
                        furnitureItem.SetDefaults(2495);
                        break;
                    case 6:
                        furnitureItem.SetDefaults(2446);
                        break;
                    case 7:
                        furnitureItem.SetDefaults(2447);
                        break;
                    case 8:
                        furnitureItem.SetDefaults(2448);
                        break;
                    case 9:
                        furnitureItem.SetDefaults(2449);
                        break;
                    case 10:
                        furnitureItem.SetDefaults(2490);
                        break;
                    case 12:
                        furnitureItem.SetDefaults(2496);
                        break;
                }
                if (furnitureItem.type != ItemID.None)
                {
                    rewardItems.Add(rewardItem);
                }
            }
            #endregion

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
        }
    }
}
