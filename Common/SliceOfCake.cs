using ReducedGrinding.Configuration;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common
{
    public class SliceOfCake : GlobalTile
    {
        private static readonly OtherConfig otherConfig = GetInstance<OtherConfig>();

        public override void RightClick(int i, int j, int type)
        {
            if (type != TileID.SliceOfCake || otherConfig.SliceOfCakeDuration == 2 || otherConfig.SliceOfCakeDuration == 61)
            {
                return;
            }

            Player player = Main.LocalPlayer;
            player.AddBuff(BuffID.SugarRush, 60 * 60 * otherConfig.SliceOfCakeDuration, false);
        }
    }

    public class SliceOfCakeBuff : GlobalBuff
    {
        public override void Update(int type, Player player, ref int buffIndex)
        {
            if (GetInstance<OtherConfig>().SliceOfCakeDuration < 61)
            {
                return;
            }

            if (type == BuffID.SugarRush)
            {
                player.buffTime[buffIndex] = 2;
                Main.buffNoSave[type] = true;
            }
        }
    }
}
