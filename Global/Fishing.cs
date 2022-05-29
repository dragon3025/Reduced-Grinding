using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace ReducedGrinding.Global
{

    class Fishing : ModPlayer
    {
        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
        {
            if (itemDrop == ItemID.ZephyrFish)
                return;
            itemDrop = ItemID.StoneBlock;
        }

        //public override void AnglerQuestReward(float quality, List<Item> rewardItems)
        //{
        //    Player player = Main.player[Main.myPlayer];
        //
        //    Main.NewText("Quest Completed: " + player.anglerQuestsFinished, 0, 255, 255);
        //
        //    if (GetInstance<CAnglerQuestRewardsConfig>().QuestFishermansGuideIncrease > 0)
        //    {
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestFishermansGuideIncrease)
        //        {
        //            Item rewardItem = new Item();
        //            rewardItem.SetDefaults(ItemID.FishermansGuide);
        //            rewardItem.stack = 1;
        //            rewardItems.Add(rewardItem);
        //        }
        //    }
        //    if (GetInstance<CAnglerQuestRewardsConfig>().QuestWeatherRadioIncrease > 0)
        //    {
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestWeatherRadioIncrease)
        //        {
        //            Item rewardItem2 = new Item();
        //            rewardItem2.SetDefaults(ItemID.WeatherRadio);
        //            rewardItem2.stack = 1;
        //            rewardItems.Add(rewardItem2);
        //        }
        //    }
        //    if (GetInstance<CAnglerQuestRewardsConfig>().QuestSextantIncrease > 0)
        //    {
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestSextantIncrease)
        //        {
        //            Item rewardItem3 = new Item();
        //            rewardItem3.SetDefaults(ItemID.Sextant);
        //            rewardItem3.stack = 1;
        //            rewardItems.Add(rewardItem3);
        //        }
        //    }
        //    if (GetInstance<CAnglerQuestRewardsConfig>().QuestAnglerHatIncrease > 0)
        //    {
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestAnglerHatIncrease)
        //        {
        //            Item rewardItem4 = new Item();
        //            rewardItem4.SetDefaults(ItemID.AnglerHat);
        //            rewardItem4.stack = 1;
        //            rewardItems.Add(rewardItem4);
        //        }
        //    }
        //    if (GetInstance<CAnglerQuestRewardsConfig>().QuestAnglerVestIncrease > 0)
        //    {
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestAnglerVestIncrease)
        //        {
        //            Item rewardItem5 = new Item();
        //            rewardItem5.SetDefaults(ItemID.AnglerVest);
        //            rewardItem5.stack = 1;
        //            rewardItems.Add(rewardItem5);
        //        }
        //    }
        //    if (GetInstance<CAnglerQuestRewardsConfig>().QuestAnglerPantsIncrease > 0)
        //    {
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestAnglerPantsIncrease)
        //        {
        //            Item rewardItem6 = new Item();
        //            rewardItem6.SetDefaults(ItemID.AnglerPants);
        //            rewardItem6.stack = 1;
        //            rewardItems.Add(rewardItem6);
        //        }
        //    }
        //    if (GetInstance<CAnglerQuestRewardsConfig>().QuestHighTestFishingLineIncrease > 0)
        //    {
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestHighTestFishingLineIncrease)
        //        {
        //            Item rewardItem7 = new Item();
        //            rewardItem7.SetDefaults(ItemID.HighTestFishingLine);
        //            rewardItem7.stack = 1;
        //            rewardItems.Add(rewardItem7);
        //        }
        //    }
        //    if (GetInstance<CAnglerQuestRewardsConfig>().QuestAnglerEarringIncrease > 0)
        //    {
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestAnglerEarringIncrease)
        //        {
        //            Item rewardItem8 = new Item();
        //            rewardItem8.SetDefaults(ItemID.AnglerEarring);
        //            rewardItem8.stack = 1;
        //            rewardItems.Add(rewardItem8);
        //        }
        //    }
        //    if (GetInstance<CAnglerQuestRewardsConfig>().QuestTackleBoxIncrease > 0)
        //    {
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestTackleBoxIncrease)
        //        {
        //            Item rewardItem9 = new Item();
        //            rewardItem9.SetDefaults(ItemID.TackleBox);
        //            rewardItem9.stack = 1;
        //            rewardItems.Add(rewardItem9);
        //        }
        //    }
        //    if (GetInstance<CAnglerQuestRewardsConfig>().QuestGoldenFishingRodIncrease > 0)
        //    {
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestGoldenFishingRodIncrease)
        //        {
        //            Item rewardItem10 = new Item();
        //            rewardItem10.SetDefaults(ItemID.GoldenFishingRod);
        //            rewardItem10.stack = 1;
        //            rewardItems.Add(rewardItem10);
        //        }
        //    }
        //    if (GetInstance<CAnglerQuestRewardsConfig>().QuestCoralstoneBlockIncrease > 0)
        //    {
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestCoralstoneBlockIncrease)
        //        {
        //            Item rewardItem11 = new Item();
        //            rewardItem11.SetDefaults(ItemID.CoralstoneBlock);
        //            rewardItem11.stack = Main.rand.Next(50, 150);
        //            rewardItems.Add(rewardItem11);
        //        }
        //    }
        //    if (GetInstance<CAnglerQuestRewardsConfig>().QuestGoldenBugNetIncrease > 0)
        //    {
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestGoldenBugNetIncrease)
        //        {
        //            Item rewardItem10 = new Item();
        //            rewardItem10.SetDefaults(3183);
        //            rewardItem10.stack = 1;
        //            rewardItems.Add(rewardItem10);
        //        }
        //    }
        //    if (GetInstance<CAnglerQuestRewardsConfig>().QuestFishHookIncrease > 0)
        //    {
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestFishHookIncrease)
        //        {
        //            Item rewardItem10 = new Item();
        //            rewardItem10.SetDefaults(2360);
        //            rewardItem10.stack = 1;
        //            rewardItems.Add(rewardItem10);
        //        }
        //    }
        //    if (Main.hardMode)
        //    {
        //        if (GetInstance<CAnglerQuestRewardsConfig>().QuestHardcoreFinWingsIncrease > 0)
        //        {
        //            if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestHardcoreFinWingsIncrease)
        //            {
        //                Item rewardItem12 = new Item();
        //                rewardItem12.SetDefaults(ItemID.FinWings);
        //                rewardItem12.stack = 1;
        //                rewardItems.Add(rewardItem12);
        //            }
        //        }
        //        if (GetInstance<CAnglerQuestRewardsConfig>().QuestHardcoreBottomlessBucketIncrease > 0)
        //        {
        //            if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestHardcoreBottomlessBucketIncrease)
        //            {
        //                Item rewardItem13 = new Item();
        //                rewardItem13.SetDefaults(ItemID.BottomlessBucket);
        //                rewardItem13.stack = 1;
        //                rewardItems.Add(rewardItem13);
        //            }
        //        }
        //        if (GetInstance<CAnglerQuestRewardsConfig>().QuestHardcoreSuperAbsorbantSpongeIncrease > 0)
        //        {
        //            if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestHardcoreSuperAbsorbantSpongeIncrease)
        //            {
        //                Item rewardItem14 = new Item();
        //                rewardItem14.SetDefaults(ItemID.SuperAbsorbantSponge);
        //                rewardItem14.stack = 1;
        //                rewardItems.Add(rewardItem14);
        //            }
        //        }
        //        if (GetInstance<CAnglerQuestRewardsConfig>().QuestHardcoreHotlineFishingHookIncrease > 0)
        //        {
        //            if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestHardcoreHotlineFishingHookIncrease)
        //            {
        //                Item rewardItem15 = new Item();
        //                rewardItem15.SetDefaults(ItemID.HotlineFishingHook);
        //                rewardItem15.stack = 1;
        //                rewardItems.Add(rewardItem15);
        //            }
        //        }
        //    }
        //    if (GetInstance<CAnglerQuestRewardsConfig>().QuestTrophyIncrease > 0)
        //    {
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestTrophyIncrease)
        //        {
        //            Item rewardItem16 = new Item();
        //            rewardItem16.SetDefaults(2446);
        //            rewardItem16.stack = 1;
        //            rewardItems.Add(rewardItem16);
        //        }
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestTrophyIncrease)
        //        {
        //            Item rewardItem17 = new Item();
        //            rewardItem17.SetDefaults(2447);
        //            rewardItem17.stack = 1;
        //            rewardItems.Add(rewardItem17);
        //        }
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestTrophyIncrease)
        //        {
        //            Item rewardItem18 = new Item();
        //            rewardItem18.SetDefaults(2448);
        //            rewardItem18.stack = 1;
        //            rewardItems.Add(rewardItem18);
        //        }
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestTrophyIncrease)
        //        {
        //            Item rewardItem19 = new Item();
        //            rewardItem19.SetDefaults(2449);
        //            rewardItem19.stack = 1;
        //            rewardItems.Add(rewardItem19);
        //        }
        //    }
        //    if (GetInstance<CAnglerQuestRewardsConfig>().QuestDecorativeFurnitureIncrease > 0)
        //    {
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestDecorativeFurnitureIncrease)
        //        {
        //            Item rewardItem20 = new Item();
        //            rewardItem20.SetDefaults(2496);
        //            rewardItem20.stack = 1;
        //            rewardItems.Add(rewardItem20);
        //        }
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestDecorativeFurnitureIncrease)
        //        {
        //            Item rewardItem21 = new Item();
        //            rewardItem21.SetDefaults(2497);
        //            rewardItem21.stack = 1;
        //            rewardItems.Add(rewardItem21);
        //        }
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestDecorativeFurnitureIncrease)
        //        {
        //            Item rewardItem22 = new Item();
        //            rewardItem22.SetDefaults(2442);
        //            rewardItem22.stack = 1;
        //            rewardItems.Add(rewardItem22);
        //        }
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestDecorativeFurnitureIncrease)
        //        {
        //            Item rewardItem23 = new Item();
        //            rewardItem23.SetDefaults(2443);
        //            rewardItem23.stack = 1;
        //            rewardItems.Add(rewardItem23);
        //        }
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestDecorativeFurnitureIncrease)
        //        {
        //            Item rewardItem24 = new Item();
        //            rewardItem24.SetDefaults(2444);
        //            rewardItem24.stack = 1;
        //            rewardItems.Add(rewardItem24);
        //        }
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestDecorativeFurnitureIncrease)
        //        {
        //            Item rewardItem25 = new Item();
        //            rewardItem25.SetDefaults(2445);
        //            rewardItem25.stack = 1;
        //            rewardItems.Add(rewardItem25);
        //        }
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestDecorativeFurnitureIncrease)
        //        {
        //            Item rewardItem26 = new Item();
        //            rewardItem26.SetDefaults(2490);
        //            rewardItem26.stack = 1;
        //            rewardItems.Add(rewardItem26);
        //        }
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestFishCostumeIncrease)
        //        {
        //            Item rewardItem26 = new Item();
        //            rewardItem26.SetDefaults(2498); //Mask
        //            rewardItem26.stack = 1;
        //            rewardItems.Add(rewardItem26);
        //
        //            Item rewardItem27 = new Item();
        //            rewardItem27.SetDefaults(2499); //Shirt
        //            rewardItem27.stack = 1;
        //            rewardItems.Add(rewardItem27);
        //
        //            Item rewardItem28 = new Item();
        //            rewardItem28.SetDefaults(2500); //Finskirt
        //            rewardItem28.stack = 1;
        //            rewardItems.Add(rewardItem28);
        //        }
        //        if (Main.rand.NextFloat() < GetInstance<CAnglerQuestRewardsConfig>().QuestMermaidCostumeIncrease)
        //        {
        //            Item rewardItem26 = new Item();
        //            rewardItem26.SetDefaults(2417); //Hairpin
        //            rewardItem26.stack = 1;
        //            rewardItems.Add(rewardItem26);
        //
        //            Item rewardItem27 = new Item();
        //            rewardItem27.SetDefaults(2418); //Adornment
        //            rewardItem27.stack = 1;
        //            rewardItems.Add(rewardItem27);
        //
        //            Item rewardItem28 = new Item();
        //            rewardItem28.SetDefaults(2419); //Tail
        //            rewardItem28.stack = 1;
        //            rewardItems.Add(rewardItem28);
        //        }
        //    }
        //}

    }
}
