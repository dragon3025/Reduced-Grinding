using Terraria;
using Terraria.ModLoader;

namespace ReducedGrinding.Buffs
{
    public class SuperMultiBobber : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.ClearBuff(ModContent.BuffType<MultiBobber>());
            player.ClearBuff(ModContent.BuffType<GreaterMultiBobber>());
        }
    }
}