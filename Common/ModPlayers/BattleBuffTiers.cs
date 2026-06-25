using ReducedGrinding.Configuration;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.ModPlayers
{
    public class BattleBuffTiers : ModPlayer
    {
        public int battleBuffTier;
        private static readonly BattlePotionConfig battlePotion = GetInstance<BattlePotionConfig>();

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write((byte)ReducedGrinding.MessageType.BattleBuffTier);
            packet.Write((byte)Player.whoAmI);
            packet.Write((byte)battleBuffTier);
            packet.Send(toWho, fromWho);
        }

        public void ReceivePlayerSync(BinaryReader reader)
        {
            battleBuffTier = reader.ReadByte();
        }

        public override void PostUpdateBuffs()
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            int prevbattleBuffTier = battleBuffTier;
            battleBuffTier = 0;

            int buffIndex = Player.FindBuffIndex(BuffID.Battle);
            if (buffIndex != -1)
            {
                if (Player.buffTime[buffIndex] > battlePotion.GreaterDuration * 60 * 60)
                {
                    battleBuffTier = 3;
                }
                else if (Player.buffTime[buffIndex] > battlePotion.VanillaDuration * 60 * 60)
                {
                    battleBuffTier = 2;
                }
                else
                {
                    battleBuffTier = 1;
                }
            }

            if (battleBuffTier != prevbattleBuffTier && Main.netMode == NetmodeID.MultiplayerClient)
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