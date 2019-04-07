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
            Tooltip.SetDefault("Having this in your inventory will cause the Traveling Merchant\n" +
							   "to restock his items even if the Stationary Merchant already\n" +
							   "has all that he can get from him. USEFULL FOR TRAVELING\n" +
							   "MERCHANT ITEMS THAT OTHER MODS ADD.");
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
            item.value = 10;
            item.UseSound = SoundID.Item4;
            item.consumable = false;
        }

        public override bool CanUseItem(Player player)
        {
			return false;
        }
    }
}