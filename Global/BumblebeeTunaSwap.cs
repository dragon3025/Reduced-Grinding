using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class BumblebeeTunaSwap : GlobalNPC
    {
        readonly static CFishingConfig fishingConfig = GetInstance<CFishingConfig>();

        public override void OnKill(NPC npc)
        {
            if (npc.type != NPCID.QueenBee)
            {
                return;
            }

            if (Global.Update.tryBumblebeeTunaSwap > 0)
            {
                return;
            }

            bool AnglerExist = false;
            for (int i = 0; i < Main.npc.Length; i++)
            {
                if (!Main.npc[i].active)
                {
                    continue;
                }
                if (Main.npc[i].type == NPCID.Angler)
                {
                    AnglerExist = true;
                    break;
                }
            }

            if (!AnglerExist)
            {
                return;
            }

            if (fishingConfig.Angler.BumblebeeTunaSwapChance > 0f)
            {
                Global.Update.tryBumblebeeTunaSwap = 1;
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    ModPacket packet = Mod.GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.tryBumblebeeTunaSwap);
                    packet.Write(Global.Update.tryBumblebeeTunaSwap);
                    packet.Send();
                }

                string text = Language.GetTextValue("Mods.ReducedGrinding.Misc.Fishing.BumblebeeTunaIncrease");

                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText(text, new Color(50, 255, 130));
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey(text), new Color(50, 255, 130));
                }
            }
        }
    }
}
