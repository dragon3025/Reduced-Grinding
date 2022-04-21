using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Items
{
	public class ReducedGrindingItem : GlobalItem
	{

		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{

			if (GetInstance<AEnemyDropConfig>().LootAnkhCharmMaterialIncreasePerAnkhCharmInInventory > 0)
			{
				if (item.type >= ItemID.AdhesiveBandage && item.type <= ItemID.TrifoldMap) //All low-tier materials for Ankh Charm.
				{
					var AnkhMaterialInfo = new TooltipLine(Mod, "AnkhMaterialInfo", "Increases the drop rate of \"Ankh Charm\" material.");
					tooltips.Add(AnkhMaterialInfo);
				}
				if (item.type == ItemID.ArmorBracing)
				{
					var ArmorBracingInfo = new TooltipLine(Mod, "ArmorBracingInfo", "Increases the drop rate of \"Ankh Charm\" material twice.\n" +
						"Cancels the\"Ankh Charm\" material drop rate increase given by \"Vitamins\" and \"Armor Polish\".");
					tooltips.Add(ArmorBracingInfo);
				}
				if (item.type == ItemID.MedicatedBandage)
				{
					var MedicatedBandageInfo = new TooltipLine(Mod, "MedicatedBandageInfo", "Increases the drop rate of \"Ankh Charm\" material twice.\n" +
						"Cancels the\"Ankh Charm\" material drop rate increase given by \"Adhesive Bandage\" and \"Bezoar\".");
					tooltips.Add(MedicatedBandageInfo);
				}
				if (item.type == ItemID.CountercurseMantra)
				{
					var CountercurseMantraInfo = new TooltipLine(Mod, "CountercurseMantraInfo", "Increases the drop rate of \"Ankh Charm\" material twice.\n" +
						"Cancels the\"Ankh Charm\" material drop rate increase given by \"Nazar\" and \"Megaphone\".");
					tooltips.Add(CountercurseMantraInfo);
				}
				if (item.type == ItemID.ThePlan)
				{
					var ThePlanInfo = new TooltipLine(Mod, "ThePlanInfo", "Increases the drop rate of \"Ankh Charm\" material twice.\n" +
						"Cancels the\"Ankh Charm\" material drop rate increase given by \"Trifold Map\" and \"Fast Clock\".");
					tooltips.Add(ThePlanInfo);
				}
			}
		}

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