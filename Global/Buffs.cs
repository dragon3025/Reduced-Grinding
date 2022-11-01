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
            //TO-DO 1.4.4+ will make all buffs below infinite. SugarRush wont be infinte though.
            if (type == BuffID.Sharpened)
            {
                player.buffTime[buffIndex] = 2;
            }

            if (type == BuffID.Clairvoyance)
            {
                player.buffTime[buffIndex] = 2;
            }

            if (type == BuffID.AmmoBox)
            {
                player.buffTime[buffIndex] = 2;
            }

            if (type == BuffID.Bewitched)
            {
                player.buffTime[buffIndex] = 2;
            }
        }
    }
}
