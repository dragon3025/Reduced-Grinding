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
	public class Granite_Moondial : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Moondial");
			Tooltip.SetDefault("Skips to Night Time.\nThis day wont count twoards the Enchanted Sundial cooldown.");
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
			item.value = 2 + 33 * Config.GraniteAndMarbleDialRecipeBlockCost + Config.GraniteAndMarbleDialRecipeBlinkroot * 100;
			item.rare = 1;
			item.createTile = mod.TileType("Granite_Moondial");
		}
	
		public override void AddRecipes()
		{
			if (Config.MarbleMoondialRecipe)
			{
				ModRecipe recipe = new ModRecipe(mod);
				if (Config.GraniteAndMarbleDialRecipeBlockCost > 0)
					recipe.AddIngredient(3087, Config.GraniteAndMarbleDialRecipeBlockCost); //Smooth Granite Blcok
				if (Config.GraniteAndMarbleDialRecipeBlinkroot > 0)
					recipe.AddIngredient(315, Config.GraniteAndMarbleDialRecipeBlinkroot); //Blinkroot
                recipe.AddTile(283); //Heavy Workbench
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}