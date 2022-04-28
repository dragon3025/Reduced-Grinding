using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Buffs
{
    public class War : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("War");
            Description.SetDefault("Enemy spawn rate greatly increased.");
        }
    }
}