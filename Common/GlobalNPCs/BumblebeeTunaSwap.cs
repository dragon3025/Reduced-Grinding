using Microsoft.Xna.Framework;
using ReducedGrinding.Common.ModPlayers;
using ReducedGrinding.Configuration;
using System;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalNPCs
{
    public class BumblebeeTunaSwap : GlobalNPC
    {
        private static readonly AnglerConfig anglerConfig = GetInstance<AnglerConfig>();

        public override void OnKill(NPC npc)
        {
            if (npc.type != NPCID.QueenBee || NPC.FindFirstNPC(NPCID.Angler) == -1)
            {
                return;
            }

            if (Main.rand.NextFloat() < anglerConfig.BumblebeeTunaSwapChance)
            {
                bool anyPlayerHasQuestFish = false;
                bool allPlayersFinishedQuest = true;
                foreach (Player player in Main.ActivePlayers)
                {
                    if (Main.anglerWhoFinishedToday.Contains(player.name))
                    {
                        continue;
                    }

                    //At least one player will set this to false if unlimited quest fish is enabled.
                    allPlayersFinishedQuest = false;

                    /* Since we're running this code on the frame that Queen Bee is killed,
                     * we can't count players that recently dropped the Quest Fish. */
                    if (player.GetModPlayer<QuestFishTimer>().inventoryQuestFishTimer == QuestFishTimer.maxInventoryQuestFishTimer)
                    {
                        anyPlayerHasQuestFish = true;
                        break;
                    }
                }

                if (anyPlayerHasQuestFish || allPlayersFinishedQuest)
                {
                    return;
                }

                int questItem = Main.anglerQuestItemNetIDs[Main.anglerQuest];
                if (questItem <= ItemID.ScorpioFish)
                {
                    Main.anglerQuest = Array.IndexOf(Main.anglerQuestItemNetIDs, ItemID.BumblebeeTuna);
                    NetMessage.SendAnglerQuest(-1);
                }

                AnglerSystem.chatQuestFish = true;

                string message = ReducedGrinding.GetText("Misc.Fishing.BumblebeeTunaIncrease");
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText(message, 50, 255, 130);
                    return;
                }
                ChatHelper.BroadcastChatMessage(NetworkText.FromKey(message), new Color(50, 255, 130));
            }
        }
    }
}
