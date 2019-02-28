using System;
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
			item.value = (Config.ChlorophyteAcceleratorHallowedBarCost * 4000 + Config.ChlorophyteAcceleratorWireCost * 500 + Config.ChlorophyteAcceleratorChlorophyteOreCost * 600) * 105 / 100;
			item.createTile = mod.TileType("Chlorophyte_Accelerator");
		}
	
		public override void AddRecipes()
		{
			if (Config.ChlorophyteAcceleratorRecipe)
			{
				ModRecipe recipe = new ModRecipe(mod);
				if (Config.ChlorophyteAcceleratorHallowedBarCost > 0)
					recipe.AddIngredient(ItemID.HallowedBar, Config.ChlorophyteAcceleratorHallowedBarCost);
				if (Config.ChlorophyteAcceleratorLihzahrdBrickCost > 0)
					recipe.AddIngredient(ItemID.LihzahrdBrick, Config.ChlorophyteAcceleratorLihzahrdBrickCost);
				if (Config.ChlorophyteAcceleratorWireCost > 0)
					recipe.AddIngredient(ItemID.Wire, Config.ChlorophyteAcceleratorWireCost);
				if (Config.ChlorophyteAcceleratorChlorophyteOreCost > 0)
					recipe.AddIngredient(ItemID.ChlorophyteOre, Config.ChlorophyteAcceleratorChlorophyteOreCost);
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();
					
				recipe = new ModRecipe(mod);
				if (Config.ChlorophyteAcceleratorHallowedBarInput > 0)
					recipe.AddIngredient(ItemID.HallowedBar, Config.ChlorophyteAcceleratorHallowedBarInput);
				if (Config.ChlorophyteAcceleratorMudBlockInput > 0)
					recipe.AddIngredient(ItemID.MudBlock, Config.ChlorophyteAcceleratorMudBlockInput);
				if (Config.ChlorophyteAcceleratorLihzahrdPowerCellInput > 0)
					recipe.AddIngredient(ItemID.LihzahrdPowerCell, Config.ChlorophyteAcceleratorLihzahrdPowerCellInput);
				recipe.AddTile(mod.TileType("Chlorophyte_Accelerator"));
				recipe.SetResult(ItemID.ChlorophyteOre, Math.Max(1, Config.ChlorophyteAcceleratorChlorophyteOreOutput));
				recipe.AddRecipe();
			}
		}
	}
}