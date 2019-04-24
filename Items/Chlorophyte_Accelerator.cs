using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
	public class Chlorophyte_Accelerator : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chlorophyte Accelerator");
			Tooltip.SetDefault("Allows you to craft Chlorophyte Ore.");
		}
		
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.rare = 7;
			item.value = Item.buyPrice(0, 0, 58, 80);
			item.createTile = mod.TileType("Chlorophyte_Accelerator");
		}
	
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LihzahrdBrick, 10);
			recipe.AddIngredient(ItemID.Wire, 10);
			recipe.AddIngredient(ItemID.ChlorophyteOre, 1);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
				
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MudBlock, 60);
			recipe.AddIngredient(ItemID.LihzahrdPowerCell, 1);
			recipe.AddTile(mod.TileType("Chlorophyte_Accelerator"));
			recipe.SetResult(ItemID.ChlorophyteOre, 60);
			recipe.AddRecipe();
		}
	}
}