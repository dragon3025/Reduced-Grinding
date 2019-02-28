using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Buffs
{
    public class Chaos : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Chaos");
            Description.SetDefault("Enemy spawn rate massively increased.");
        }
    }
}