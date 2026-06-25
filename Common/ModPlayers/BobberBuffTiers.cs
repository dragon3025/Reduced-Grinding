using ReducedGrinding.Content.Buffs;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.ModPlayers
{
    public class BobberBuffTiers : ModPlayer
    {
        public int bobberBuffTier;

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write((byte)ReducedGrinding.MessageType.BobberBuffTier);
            packet.Write((byte)Player.whoAmI);
            packet.Write((byte)bobberBuffTier);
            packet.Send(toWho, fromWho);
        }

        public void ReceivePlayerSync(BinaryReader reader)
        {
            bobberBuffTier = reader.ReadByte();
        }

        public override void PostUpdateBuffs()
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            int prevBobberBuffTier = bobberBuffTier;
            bobberBuffTier = 0;

            int buffIndex = Player.FindBuffIndex(BuffType<Bobber>());
            if (buffIndex != -1)
            {
                if (Player.buffTime[buffIndex] > 6 * 60 * 60)
                {
                    bobberBuffTier = 3;
                }
                else if (Player.buffTime[buffIndex] > 3 * 60 * 60)
                {
                    bobberBuffTier = 2;
                }
                else
                {
                    bobberBuffTier = 1;
                }
            }

            if (bobberBuffTier != prevBobberBuffTier && Main.netMode == NetmodeID.MultiplayerClient)
            {
                SyncPlayer(-1, Main.myPlayer, false);
            }
        }

        public override void OnEnterWorld()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                SyncPlayer(-1, Main.myPlayer, true);
            }
        }
    }
}