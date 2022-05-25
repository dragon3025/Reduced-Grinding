using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ReducedGrinding.Items
{
	public class Moon_Ball : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moon Ball");
            Tooltip.SetDefault("Advances the Moon Phase.\nHaving this in your inventory removes all Moon Phase restrictions on the Skeleton Merchant.");
        }
		
		public override void SetDefaults()
		{
            Item.width = 28;
            Item.height = 30;
            Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
            Item.rare = ItemRarityID.Orange;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = true;
            Item.value = Terraria.Item.buyPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Orange;
			Item.createTile = ModContent.TileType<Tiles.Moon_Ball>();
		}
	}
}