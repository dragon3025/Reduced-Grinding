using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Global.GlobalBuffs
{
    public class ReducedGrindingBuffs : GlobalBuff
    {
        public override void Update(int type, Player player, ref int buffIndex)
        {
            if (type == BuffID.SugarRush)
            {
                player.buffTime[buffIndex] = 2;
            }
        }
    }
}
