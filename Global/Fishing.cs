using ReducedGrinding.Configuration;
using System.Collections.Generic;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class Fishing : ModPlayer
    {
        public override void AnglerQuestReward(float rareMultiplier, List<Terraria.Item> rewardItems)
        {
            int fishCoinAmount = GetInstance<CFishingConfig>().FishCoinsRewardedForQuest;
            if (fishCoinAmount > 0)
            {
                Terraria.Item coin = new();
                coin.SetDefaults(ItemType<Items.FishCoin>());
                coin.stack = fishCoinAmount;
                rewardItems.Add(coin);
            }
        }
    }
}
