using Terraria;
using Terraria.ModLoader;

namespace ReducedGrinding.Buffs
{
    public class SuperBattle : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
        }
    }
}