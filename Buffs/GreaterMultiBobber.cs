using Terraria;
using Terraria.ModLoader;

namespace ReducedGrinding.Buffs
{
    public class GreaterMultiBobber : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Greater Multi-Bobber Potion");
			Description.SetDefault("Adds even more bobbers while fishing");
        }
    }
}