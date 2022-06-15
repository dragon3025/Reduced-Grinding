using Terraria;
using Terraria.ModLoader;

namespace ReducedGrinding.Buffs
{
    public class SuperBattle : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Super Battle");
            Description.SetDefault("Enemy spawn rate massively increased");
        }
    }
}