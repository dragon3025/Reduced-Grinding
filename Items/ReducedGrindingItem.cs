using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
	public class ReducedGrindingItem : GlobalItem
	{

		/*public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			ReducedGrindingPlayer mPlayer = Main.LocalPlayer.GetModPlayer<ReducedGrindingPlayer>(mod);

			if (mPlayer.clientConf.LootAnkhCharmMaterialIncreasePerAnkhCharmInInventory > 0)
			{
				if (item.type == ItemID.Blindfold)
				{
					var line = new TooltipLine(mod, "AnkhMaterialInfo", "Boost the drop rate of Ankh Materials by " + (mPlayer.clientConf.LootAnkhCharmMaterialIncreasePerAnkhCharmInInventory * 100) + "%");
					tooltips.Add(line);
				}
			}
		}*/


		public override void SetDefaults(Item item)
		{
			ReducedGrindingPlayer mPlayer = Main.LocalPlayer.GetModPlayer<ReducedGrindingPlayer>(mod);

			if (item.type == ItemID.GreenCap && mPlayer.clientConf.AllNPCsSellTheirDeathLoot)
			{
				item.value = Item.buyPrice(0, 3);
			}
		}
	}
}