using Terraria;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
	public class Gold_Reflection_Mirror : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gold Reflection Mirror");
			Tooltip.SetDefault("Used to transform some Critters into Golden Critters.");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 1;
			item.value = Item.buyPrice(0, 12);
			item.rare = 0;
		}
	}
}