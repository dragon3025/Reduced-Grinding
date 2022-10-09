using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class AnglerRewards : ModPlayer
    {
        public override void AnglerQuestReward(float rareMultiplier, List<Terraria.Item> rewardItems)
        {
            //TO-DO When 1.4.4 comes out, a lot of stuff may need adjusted or removed (including the Fish Merchant)
            #region Remove Furniture
            bool furnitureRemoved = false;
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
                        furnitureRemoved = true;
                        rewardItems.RemoveAt(j);
                        goto furnitureTestFinished;
                    }
                }
            }
            furnitureTestFinished: { };
            #endregion

            #region Modify Requirements
            int fuzzyCarrotQuestRequirement = GetInstance<CFishingConfig>().FuzzyCarrotQuestRewarded;
            int anglerHatQuestRequirement = GetInstance<CFishingConfig>().AnglerHatQuestRewarded;
            int anglerVestQuestRequirement = GetInstance<CFishingConfig>().AnglerVestQuestRewarded;
            int anglerPantsQuestRequirement = GetInstance<CFishingConfig>().AnglerPantsQuestRewarded;
            int goldenFishingRodQuestRequirement = GetInstance<CFishingConfig>().GoldenFishingRodQuestRewarded;

            #region Remove rewards at old requirements
            int questDone = Player.anglerQuestsFinished;

            List<Terraria.Item> itemsToRemove = new();
            for (int i = 0; i < rewardItems.Count; i++)
            {
                if (rewardItems[i].type == ItemID.FuzzyCarrot && fuzzyCarrotQuestRequirement != 5 && questDone == 5)
                    itemsToRemove.Add(rewardItems[i]);
                if (rewardItems[i].type == ItemID.AnglerHat && anglerHatQuestRequirement != 10 && questDone == 10)
                    itemsToRemove.Add(rewardItems[i]);
                if (rewardItems[i].type == ItemID.AnglerVest && anglerVestQuestRequirement != 15 && questDone == 15)
                    itemsToRemove.Add(rewardItems[i]);
                if (rewardItems[i].type == ItemID.AnglerPants && anglerPantsQuestRequirement != 20 && questDone == 20)
                    itemsToRemove.Add(rewardItems[i]);
                if (rewardItems[i].type == ItemID.GoldenFishingRod && goldenFishingRodQuestRequirement != 30 && questDone == 30)
                    itemsToRemove.Add(rewardItems[i]);
            }
            foreach (Terraria.Item item in itemsToRemove)
                rewardItems.Remove(item);
            #endregion

            #region Add rewards at new requirement
            if (fuzzyCarrotQuestRequirement != 5 && questDone == fuzzyCarrotQuestRequirement)
            {
                Terraria.Item fuzzyCarrot = new();
                fuzzyCarrot.SetDefaults(ItemID.FuzzyCarrot);
                rewardItems.Add(fuzzyCarrot);
            }
            if (anglerHatQuestRequirement != 10 && questDone == anglerHatQuestRequirement)
            {
                Terraria.Item AnglerHat = new();
                AnglerHat.SetDefaults(ItemID.AnglerHat);
                rewardItems.Add(AnglerHat);
            }
            if (anglerVestQuestRequirement != 15 && questDone == anglerVestQuestRequirement)
            {
                Terraria.Item AnglerVest = new();
                AnglerVest.SetDefaults(ItemID.AnglerVest);
                rewardItems.Add(AnglerVest);
            }
            if (anglerPantsQuestRequirement != 20 && questDone == anglerPantsQuestRequirement)
            {
                Terraria.Item anglerPants = new();
                anglerPants.SetDefaults(ItemID.AnglerPants);
                rewardItems.Add(anglerPants);
            }
            if (goldenFishingRodQuestRequirement != 30 && questDone == goldenFishingRodQuestRequirement)
            {
                Terraria.Item goldenFishingRod = new();
                goldenFishingRod.SetDefaults(ItemID.GoldenFishingRod);
                rewardItems.Add(goldenFishingRod);
            }
            #endregion
            #endregion

            if (questDone == 25)
            {
                Terraria.Item bottomlessWaterBucket = new();
                bottomlessWaterBucket.SetDefaults(ItemID.BottomlessBucket);
                rewardItems.Add(bottomlessWaterBucket);
            }

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

            #region If a Furniture Item Was Removed, Add Back a Potion Only
            if (furnitureRemoved)
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

            #region New Furniture Roll (Higher Chance and No Potion)
            Terraria.Item newFurnitureItem = new();
            switch (Main.rand.Next(19))
            {
                case 0:
                    newFurnitureItem.SetDefaults(2442);
                    break;
                case 1:
                    newFurnitureItem.SetDefaults(2443);
                    break;
                case 2:
                    newFurnitureItem.SetDefaults(2444);
                    break;
                case 3:
                    newFurnitureItem.SetDefaults(2445);
                    break;
                case 4:
                    newFurnitureItem.SetDefaults(2497);
                    break;
                case 5:
                    newFurnitureItem.SetDefaults(2495);
                    break;
                case 6:
                    newFurnitureItem.SetDefaults(2446);
                    break;
                case 7:
                    newFurnitureItem.SetDefaults(2447);
                    break;
                case 8:
                    newFurnitureItem.SetDefaults(2448);
                    break;
                case 9:
                    newFurnitureItem.SetDefaults(2449);
                    break;
                case 10:
                    newFurnitureItem.SetDefaults(2490);
                    break;
                case 12:
                    newFurnitureItem.SetDefaults(2496);
                    break;
            }
            rewardItems.Add(newFurnitureItem);
            #endregion
        }
    }
}
