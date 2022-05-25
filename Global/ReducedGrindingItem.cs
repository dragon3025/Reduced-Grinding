using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding
{
	public class ReducedGrindingItem : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			int originalValue;
			if (item.type == ItemID.GreenCap)
			{
				item.value = Item.buyPrice(0, 0, 2);
			}
			if (item.type == ItemID.Spike)
			{
				item.value = Item.buyPrice(0, 0, 0, 20);
			}
			if (item.type == ItemID.WoodenSpike)
			{
				item.value = Item.buyPrice(0, 0, 20);
			}
			//The items below assume that the configurations for all these drops are set to 100% (because GetModPlayer doesn't work here).
			if (item.type == ItemID.DyeTradersScimitar || item.type == ItemID.AleThrowingGlove || item.type == ItemID.StylistKilLaKillScissorsIWish || item.type == ItemID.TaxCollectorsStickOfDoom)
			{
				originalValue = item.value;
				item.value = (int)(originalValue * 0.125);
			}
			if (item.type == ItemID.PainterPaintballGun)
			{
				originalValue = item.value;
				item.value = (int)(originalValue * 0.1);
			}
			if (item.type == ItemID.PinkPricklyPear)
			{
				item.placeStyle = 0;
				item.createTile = TileID.Cactus;
			}
		}
	}
}