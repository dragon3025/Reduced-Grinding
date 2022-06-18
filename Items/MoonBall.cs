using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
    public class MoonBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moon Ball");
            Tooltip.SetDefault("Advances the Moon Phase");
        }
		
		public override void SetDefaults()
		{
            Item.width = 28;
            Item.height = 30;
            Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
            Item.rare = ItemRarityID.Orange;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = true;
            Item.value = Item.buyPrice(0, 10, 0, 0);
			Item.rare = ItemRarityID.Orange;
			Item.createTile = ModContent.TileType<Tiles.Moon_Ball>();
		}
	}
}