using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

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
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 1;
			Item.value = Item.buyPrice(0, 12);
			Item.rare = ItemRarityID.White;
		}
	}
}