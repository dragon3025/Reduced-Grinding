using Terraria;
using Terraria.ModLoader;

namespace ReducedGrinding.Buffs
{
    public class SuperMultiBobber : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Super Multi-Bobber Potion");
			Description.SetDefault("Adds a lot of bobbers while fishing");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.ClearBuff(ModContent.BuffType<MultiBobber>());
            player.ClearBuff(ModContent.BuffType<SuperMultiBobber>());
        }
    }
}