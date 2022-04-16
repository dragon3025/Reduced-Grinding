using Terraria;
using Terraria.ModLoader;

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
            item.width = 28;
            item.height = 30;
            item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
            item.rare = 3;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
			item.consumable = true;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.rare = 3;
			item.createTile = mod.TileType("Moon_Ball");
		}
	}
}