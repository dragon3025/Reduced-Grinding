using Terraria;
using Terraria.ModLoader;

namespace ReducedGrinding.Buffs
{
    public class GreaterBattle : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Greater Battle");
            Description.SetDefault("Enemy spawn rate greatly increased.");
        }
    }
}