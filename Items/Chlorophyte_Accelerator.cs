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
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.Lime;
            Item.value = Terraria.Item.buyPrice(0, 0, 58, 80);
			Item.createTile = ModContent.TileType<Tiles.Chlorophyte_Accelerator>();
		}
	
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.LihzahrdBrick, 10)
				.AddIngredient(ItemID.Wire, 10)
				.AddIngredient(ItemID.ChlorophyteOre, 1)
				.AddTile(TileID.TinkerersWorkbench)
				.Register();

				Recipe recipe = Mod.CreateRecipe(ItemID.ChlorophyteOre, 60);
				recipe.AddIngredient(ItemID.MudBlock, 60);
				recipe.AddIngredient(ItemID.LihzahrdPowerCell, 1);
				recipe.AddTile(ModContent.TileType<Tiles.Chlorophyte_Accelerator>());
				recipe.Register();
		}
	}
}