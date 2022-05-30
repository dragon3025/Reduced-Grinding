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
        /*public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
        {
            if (itemDrop == ItemID.ZephyrFish)
                return;
            itemDrop = ItemID.StoneBlock;
        }*/

        public override void AnglerQuestReward(float rareMultiplier, List<Terraria.Item> rewardItems)
        {
            Player player = Main.player[Main.myPlayer];
            Main.NewText("Quest Completed: " + player.anglerQuestsFinished, 0, 255, 255);
        }
    }
}
