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
            int questsDone = Player.anglerQuestsFinished;

            #region Modify Requirements
            Terraria.Item rewardItem = new();
            List<Terraria.Item> itemsToRemove = new();

            void removeReward(int requirement, int vanillaRequirement, int index, int item)
            {
                if (requirement != vanillaRequirement && questsDone == vanillaRequirement && rewardItems[index].type == item)
                {
                    itemsToRemove.Add(rewardItems[index]);
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
