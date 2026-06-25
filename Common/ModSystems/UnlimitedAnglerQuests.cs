using Humanizer;
using Microsoft.Xna.Framework;
using ReducedGrinding.Common.GlobalNPCs;
using ReducedGrinding.Common.ModPlayers;
using ReducedGrinding.Configuration;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.ModSystems
{
    public class UnlimitedAnglerQuests : ModSystem
    {
        private static readonly AnglerConfig anglerConfig = GetInstance<AnglerConfig>();
        public static bool firstQuestOfTheDay = true;

        public override void PreUpdateTime()
        {
            if (Main.dayTime && Main.time == 0)
            {
                firstQuestOfTheDay = true;

                if (Main.netMode != NetmodeID.MultiplayerClient
                    && anglerConfig.AnglerChatsBumbleBeeTuna
                    && Main.anglerQuestItemNetIDs[Main.anglerQuest] == ItemID.BumblebeeTuna)
                {
                    AnglerSystem.chatQuestFish = true;
                }
            }

            if (Main.netMode == NetmodeID.MultiplayerClient || !anglerConfig.UnlimitedAnglerQuest)
            {
                return;
            }

            bool stillQuesting = Main.anglerWhoFinishedToday.Count == 0;

            if (!stillQuesting)
            {
                foreach (Player player in Main.ActivePlayers)
                {
                    if (Main.anglerWhoFinishedToday.Contains(player.name))
                    {
                        continue;
                    }

                    if (player.GetModPlayer<QuestFishTimer>().inventoryQuestFishTimer > 0)
                    {
                        stillQuesting = true;
                        break;
                    }
                }
            }

            if (stillQuesting)
            {
                return;
            }

            firstQuestOfTheDay = false;

            if (Main.netMode == NetmodeID.Server)
            {
                ModPacket packetAnglerQuest = Mod.GetPacket();
                packetAnglerQuest.Write((byte)ReducedGrinding.MessageType.FirstQuestOfTheDay);
                packetAnglerQuest.Write(firstQuestOfTheDay);
                packetAnglerQuest.Send();
            }

            Main.AnglerQuestSwap();

            string newQuestText = ReducedGrinding.GetText("Misc.Fishing.NewQuestTextWithIcon").FormatWith(Main.anglerQuestItemNetIDs[Main.anglerQuest]);

            if (!anglerConfig.AnglerChatsCurrentQuest)
            {
                newQuestText = ReducedGrinding.GetText("Misc.Fishing.NewQuestText");
            }

            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(newQuestText, 50, 255, 130);
                return;
            }
            ChatHelper.BroadcastChatMessage(NetworkText.FromKey(newQuestText), new Color(50, 255, 130));
        }
    }
}
