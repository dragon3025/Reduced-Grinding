using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Buffs
{
    public class Fish_Upgrade : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Fish Upgrade");
			Description.SetDefault("Every 5 Fishing Quest completed will increase the chance of catching rare fish (Vanilla rods only), 500 Quest max");
        }
    }
}