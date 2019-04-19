using Terraria;
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
			item.value = 0; //You can get this item infintely, so it shouldn't have a price.
			item.rare = 10;
		}

		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentVortex);
			recipe.AddIngredient(ItemID.FragmentNebula);
			recipe.AddIngredient(ItemID.FragmentSolar);
			recipe.AddIngredient(ItemID.FragmentStardust);
			recipe.AddIngredient(ItemID.LunarBar);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}