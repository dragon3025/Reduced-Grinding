using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using Terraria;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalNPCs
{
    public class NPCArrivalMessages : GlobalNPC
    {
        internal static bool oldMan;
        internal static bool cultists;
        internal static int cultistsMessageCooldown;

        public override void OnSpawn(NPC npc, IEntitySource source)
        {
            if (!GetInstance<EventAndBossConfig>().NPCArrivalMessages)
            {
                return;
            }

            switch (npc.type)
            {
                case NPCID.OldMan when oldMan:
                    ShowArrivalMessage(npc);
                    break;
                case NPCID.CultistTablet when cultists && cultistsMessageCooldown <= 0:
                    ShowArrivalMessage(npc);
                    break;
                case NPCID.SkeletronHead:
                    oldMan = true;
                    break;
                case NPCID.CultistBoss:
                    cultists = true;
                    break;
                default:
                    break;
            }
        }

        private static void ShowArrivalMessage(NPC npc)
        {
            string message;
            if (npc.type == NPCID.OldMan)
            {
                message = ReducedGrinding.GetText("Misc.ArrivalMessage.OldMan");
            }
            else
            {
                message = ReducedGrinding.GetText("Misc.ArrivalMessage.Cultists");
            }
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(message, 50, 255, 130);
                return;
            }
            ChatHelper.BroadcastChatMessage(NetworkText.FromKey(message), new Color(50, 255, 130));
        }
    }

    public class NPCArrivalMessagesSystem : ModSystem
    {
        public override void PostUpdateTime()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }

            if (NPCArrivalMessages.cultistsMessageCooldown > 0)
            {
                NPCArrivalMessages.cultistsMessageCooldown -= (int)Main.dayRate;
            }
        }
    }
}
