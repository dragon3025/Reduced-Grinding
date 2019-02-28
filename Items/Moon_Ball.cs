using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Linq;
using System;
using Terraria.ID;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria;

namespace ReducedGrinding.Items
{
    public class Moon_Ball : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moon Ball");
            Tooltip.SetDefault("Advances the Moon Phase.");
        }
		
		public override void SetDefaults()
		{
            item.width = 12;
            item.height = 30;
            item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
            item.rare = 3;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
			item.consumable = true;
            item.value = 10000;
			item.rare = 3;
			item.createTile = mod.TileType("Moon_Ball");
		}
	}
}