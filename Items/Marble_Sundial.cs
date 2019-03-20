using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace ReducedGrinding.Items
{
	public class Marble_Sundial : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Marble Sundial");
			Tooltip.SetDefault("Skips to day time.\nThis day wont count twoards the Enchanted Sundial cooldown.");
		}
		
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 32;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 300;
			item.rare = 1;
			item.createTile = mod.TileType("Marble_Sundial");
		}
	
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3066, 1); //Smooth Marble Block
			recipe.AddIngredient(315, 1); //Blinkroot
			recipe.AddTile(283); //Heavy Workbench
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}