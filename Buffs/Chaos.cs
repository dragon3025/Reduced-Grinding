using Terraria;
using Terraria.ModLoader;

namespace ReducedGrinding.Buffs
{
    public class Chaos : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Chaos");
            Description.SetDefault("Enemy spawn rate massively increased.");
        }
    }
}