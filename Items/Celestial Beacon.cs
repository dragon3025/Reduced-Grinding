using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
	public class Celestial_Beacon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestial Beacon");
			Tooltip.SetDefault("Having this in your inventory will allow the Moon Lord arrive instantly when summoned.");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 1;
			item.value = 18000;
			item.rare = 10;
		}

		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3456); //Vortext Fragment
			recipe.AddIngredient(3457); //Nebula Fragment
			recipe.AddIngredient(3458); //Solar Fragment
			recipe.AddIngredient(3459); //Stardust Fragment
			recipe.AddIngredient(3467); //Luminite Bar
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
		
	}
}