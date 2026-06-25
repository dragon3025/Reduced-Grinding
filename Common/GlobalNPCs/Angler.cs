using Humanizer;
using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalNPCs
{
    public class Angler : GlobalNPC
    {
        private static readonly AnglerConfig anglerConfig = GetInstance<AnglerConfig>();

        public override void OnChatButtonClicked(NPC npc, bool firstButton)
        {
            if (npc.type != NPCID.Angler || !firstButton || !anglerConfig.AnglerChatsCurrentQuest)
            {
                return;
            }

            AnglerSystem.chatQuestFish = true;

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                ModPacket packet = Mod.GetPacket();
                packet.Write((byte)ReducedGrinding.MessageType.ChatQuestFish);
                packet.Write(AnglerSystem.chatQuestFish);
                packet.Send();
            }
        }

        public override void GetChat(NPC npc, ref string chat)
        {
            if (npc.type != NPCID.Angler)
            {
                return;
            }

            Player player = Main.LocalPlayer;
            if (anglerConfig.AnglerTellsQuestCompleted)
            {
                chat += $"\n\n" + ReducedGrinding.GetText("Misc.Fishing.QuestFinishedText").FormatWith(player.anglerQuestsFinished);
            }
        }
    }

    public class AnglerSystem : ModSystem
    {
        public static bool chatQuestFish;

        public override void PreUpdateTime()
        {
            if (!chatQuestFish || Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }

            chatQuestFish = false;

            string message = ReducedGrinding.GetText("Misc.Fishing.CurrentQuest").FormatWith(Main.anglerQuestItemNetIDs[Main.anglerQuest]);

            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(message, 255, 240, 20);
                return;
            }
            ChatHelper.BroadcastChatMessage(NetworkText.FromKey(message), new Color(255, 240, 20));
        }
    }
}
