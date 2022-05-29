using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Buffs
{
    public class Multi_Bobber : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Multi-Bobber Potion");
			Description.SetDefault("Use 10 Bobbers at a time.");
        }
    }
}