using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ReducedGrinding.Items
{
	public class Granite_Moondial : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Moondial");
			Tooltip.SetDefault("Skips to Night Time.\nThis day won't count towards the Enchanted Sundial cooldown");
		}
		
		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 38;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = Item.buyPrice(0, 0, 3, 0);
			Item.rare = ItemRarityID.Blue;
			Item.createTile = ModContent.TileType<Tiles.Granite_Moondial>();
		}
	
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.GraniteBlock, 20)
				.AddIngredient(ItemID.Blinkroot)
				.AddTile(TileID.HeavyWorkBench)
				.Register();
		}
	}
}