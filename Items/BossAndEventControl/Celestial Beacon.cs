using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items.BossAndEventControl
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
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 1;
			Item.value = 0; //You can get this item infintely, so it shouldn't have a price.
			Item.rare = ItemRarityID.Red;
		}

		public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.FragmentVortex)
				.AddIngredient(ItemID.FragmentNebula)
				.AddIngredient(ItemID.FragmentSolar)
				.AddIngredient(ItemID.FragmentStardust)
				.AddIngredient(ItemID.LunarBar)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
        }
	}
}