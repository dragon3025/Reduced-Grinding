using Terraria;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
	public class Marble_Sundial : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Marble Sundial");
			Tooltip.SetDefault("Skips to day time.\nThis day won't count towards the Enchanted Sundial cooldown.");
		}
		
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 38;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = Item.buyPrice(0, 0, 3, 0);
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