using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
	public class ReducedGrindingItem : GlobalItem
	{

		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			ReducedGrindingPlayer mPlayer = Main.LocalPlayer.GetModPlayer<ReducedGrindingPlayer>(mod);

			if (mPlayer.clientConf.LootAnkhCharmMaterialIncreasePerAnkhCharmInInventory > 0)
			{
				if (item.type >= 885 && item.type <= 893) //All low-tier materials for Ankh Charm.
				{
					var AnkhMaterialInfo = new TooltipLine(mod, "AnkhMaterialInfo", "Increases the drop rate of \"Ankh Charm\" material.");
					tooltips.Add(AnkhMaterialInfo);
				}
				if (item.type == ItemID.ArmorBracing)
				{
					var ArmorBracingInfo = new TooltipLine(mod, "ArmorBracingInfo", "Increases the drop rate of \"Ankh Charm\" material twice.\n" +
						"Cancels the\"Ankh Charm\" material drop rate increase given by \"Vitamins\" and \"Armor Polish\".");
					tooltips.Add(ArmorBracingInfo);
				}
				if (item.type == ItemID.MedicatedBandage)
				{
					var MedicatedBandageInfo = new TooltipLine(mod, "MedicatedBandageInfo", "Increases the drop rate of \"Ankh Charm\" material twice.\n" +
						"Cancels the\"Ankh Charm\" material drop rate increase given by \"Adhesive Bandage\" and \"Bezoar\".");
					tooltips.Add(MedicatedBandageInfo);
				}
				if (item.type == ItemID.CountercurseMantra)
				{
					var CountercurseMantraInfo = new TooltipLine(mod, "CountercurseMantraInfo", "Increases the drop rate of \"Ankh Charm\" material twice.\n" +
						"Cancels the\"Ankh Charm\" material drop rate increase given by \"Nazar\" and \"Megaphone\".");
					tooltips.Add(CountercurseMantraInfo);
				}
				if (item.type == ItemID.ThePlan)
				{
					var ThePlanInfo = new TooltipLine(mod, "ThePlanInfo", "Increases the drop rate of \"Ankh Charm\" material twice.\n" +
						"Cancels the\"Ankh Charm\" material drop rate increase given by \"Trifold Map\" and \"Fast Clock\".");
					tooltips.Add(ThePlanInfo);
				}
			}
		}

		public override void SetDefaults(Item item)
		{
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
		}
	}
}