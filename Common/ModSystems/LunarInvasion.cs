using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.ModSystems
{
    internal class LunarInvasion : ModSystem
    {
        internal static bool lunarApocalypseIsUp;
        internal static bool moonLordCountdownRunning;

        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(lunarApocalypseIsUp);
            writer.Write(moonLordCountdownRunning);
        }

        public override void NetReceive(BinaryReader reader)
        {
            lunarApocalypseIsUp = reader.ReadBoolean();
            moonLordCountdownRunning = reader.ReadBoolean();
        }

        public static void UpdateStatus()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }

            if (lunarApocalypseIsUp != NPC.LunarApocalypseIsUp)
            {
                lunarApocalypseIsUp = NPC.LunarApocalypseIsUp;
                if (Main.netMode == NetmodeID.Server)
                {
                    ModPacket packet = GetInstance<ReducedGrinding>().GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.LunarApocalypseIsUp);
                    packet.Write(lunarApocalypseIsUp);
                    packet.Send();
                }
            }
            if (moonLordCountdownRunning != (NPC.MoonLordCountdown > 0))
            {
                moonLordCountdownRunning = NPC.MoonLordCountdown > 0;
                if (Main.netMode == NetmodeID.Server)
                {
                    ModPacket packet = GetInstance<ReducedGrinding>().GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.MoonLordCountdownRunning);
                    packet.Write(moonLordCountdownRunning);
                    packet.Send();
                }
            }
        }
    }
}
