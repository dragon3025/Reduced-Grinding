using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ReducedGrinding.Items
{
	public class Traveling_Merchant_Restock_Order : ModItem
	{
		
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Traveling Merchant Restock Order");
            Tooltip.SetDefault("If you have this in your inventory: each second will have a" +
                               "chance of restocking the Traveling Merchant's showp. This" +
                               "chance is greatly decreased by the amount of permanent" +
                               "vanilla and Reduced Grinding NPCs that you don't have.");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 1;
            item.rare = 0;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
			item.value = Item.buyPrice(0, 0, 0, 10);
            item.UseSound = SoundID.Item4;
            item.consumable = false;
        }

        public override bool CanUseItem(Player player)
        {
			return false;
        }
    }
}