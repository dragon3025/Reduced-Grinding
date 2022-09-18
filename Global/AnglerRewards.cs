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

            #region Modify Requirements
            int fuzzyCarrotQuestRequirement = GetInstance<CFishingConfig>().FuzzyCarrotQuestRewarded;
            int anglerHatQuestRequirement = GetInstance<CFishingConfig>().AnglerHatQuestRewarded;
            int anglerVestQuestRequirement = GetInstance<CFishingConfig>().AnglerVestQuestRewarded;
            int anglerPantsQuestRequirement = GetInstance<CFishingConfig>().AnglerPantsQuestRewarded;
            int goldenFishingRodQuestRequirement = GetInstance<CFishingConfig>().GoldenFishingRodQuestRewarded;

            List<Terraria.Item> itemsToRemove = new();

            #region Remove rewards at old requirements
            for (int i = 0; i < rewardItems.Count; i++)
            {
                if (rewardItems[i].type == ItemID.FuzzyCarrot && fuzzyCarrotQuestRequirement != 5 && Player.anglerQuestsFinished == 5)
                    itemsToRemove.Add(rewardItems[i]);
                if (rewardItems[i].type == ItemID.AnglerHat && anglerHatQuestRequirement != 10 && Player.anglerQuestsFinished == 10)
                    itemsToRemove.Add(rewardItems[i]);
                if (rewardItems[i].type == ItemID.AnglerVest && anglerVestQuestRequirement != 15 && Player.anglerQuestsFinished == 15)
                    itemsToRemove.Add(rewardItems[i]);
                if (rewardItems[i].type == ItemID.AnglerPants && anglerPantsQuestRequirement != 20 && Player.anglerQuestsFinished == 20)
                    itemsToRemove.Add(rewardItems[i]);
                if (rewardItems[i].type == ItemID.GoldenFishingRod && goldenFishingRodQuestRequirement != 30 && Player.anglerQuestsFinished == 30)
                    itemsToRemove.Add(rewardItems[i]);
            }
            foreach (Terraria.Item item in itemsToRemove)
                rewardItems.Remove(item);
            #endregion

            #region Add rewards at new requirement
            if (fuzzyCarrotQuestRequirement != 5 && Player.anglerQuestsFinished == fuzzyCarrotQuestRequirement)
            {
                Terraria.Item fuzzyCarrot = new();
                fuzzyCarrot.SetDefaults(ItemID.FuzzyCarrot);
                rewardItems.Add(fuzzyCarrot);
            }
            if (anglerHatQuestRequirement != 10 && Player.anglerQuestsFinished == anglerHatQuestRequirement)
            {
                Terraria.Item AnglerHat = new();
                AnglerHat.SetDefaults(ItemID.AnglerHat);
                rewardItems.Add(AnglerHat);
            }
            if (anglerVestQuestRequirement != 15 && Player.anglerQuestsFinished == anglerVestQuestRequirement)
            {
                Terraria.Item AnglerVest = new();
                AnglerVest.SetDefaults(ItemID.AnglerVest);
                rewardItems.Add(AnglerVest);
            }
            if (anglerPantsQuestRequirement != 20 && Player.anglerQuestsFinished == anglerPantsQuestRequirement)
            {
                Terraria.Item anglerPants = new();
                anglerPants.SetDefaults(ItemID.AnglerPants);
                rewardItems.Add(anglerPants);
            }
            if (goldenFishingRodQuestRequirement != 30 && Player.anglerQuestsFinished == goldenFishingRodQuestRequirement)
            {
                Terraria.Item goldenFishingRod = new();
                goldenFishingRod.SetDefaults(ItemID.GoldenFishingRod);
                rewardItems.Add(goldenFishingRod);
            }
            #endregion
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

            #region Extra Furniture Drop
            //TO-DO Remove when 1.4.4 comes out.
            int questFinished = Player.anglerQuestsFinished;
            float dropRate = 1f;
            dropRate = (questFinished <= 50) ? (dropRate - questFinished * 0.01f) : ((questFinished <= 100) ? (0.5f - (questFinished - 50) * 0.005f) : ((questFinished > 150) ? 0.15f : (0.25f - (questFinished - 100) * 0.002f)));
            dropRate *= 0.9f;
            dropRate *= (float)(Player.currentShoppingSettings.PriceAdjustment + 1.0) / 2f;

            Main.NewText("Happyness: " + Player.currentShoppingSettings.PriceAdjustment.ToString()); //TO-DO Remove

            if (Main.rand.NextBool((int)(70 * dropRate)))
            {
                Terraria.Item extraFurnitureItem = new();
                switch (Main.rand.Next(11))
                {
                    case 0:
                        extraFurnitureItem.SetDefaults(2442);
                        break;
                    case 1:
                        extraFurnitureItem.SetDefaults(2443);
                        break;
                    case 2:
                        extraFurnitureItem.SetDefaults(2444);
                        break;
                    case 3:
                        extraFurnitureItem.SetDefaults(2445);
                        break;
                    case 4:
                        extraFurnitureItem.SetDefaults(2497);
                        break;
                    case 5:
                        extraFurnitureItem.SetDefaults(2495);
                        break;
                    case 6:
                        extraFurnitureItem.SetDefaults(2446);
                        break;
                    case 7:
                        extraFurnitureItem.SetDefaults(2447);
                        break;
                    case 8:
                        extraFurnitureItem.SetDefaults(2448);
                        break;
                    case 9:
                        extraFurnitureItem.SetDefaults(2449);
                        break;
                    case 10:
                        extraFurnitureItem.SetDefaults(2490);
                        break;
                    case 11:
                        extraFurnitureItem.SetDefaults(2496);
                        break;
                }
                rewardItems.Add(extraFurnitureItem);
            }
            #endregion
        }
    }
}
