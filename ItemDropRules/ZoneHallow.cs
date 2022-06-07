using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.ItemDropRules.Conditions
{
	public class ZoneHallow : IItemDropRuleCondition
	{
		public bool CanDrop(DropAttemptInfo info)
		{
			if (!info.IsInSimulation)
				return info.player.ZoneHallow;
			return false;
		}

		public bool CanShowItemDropInUI()
		{
			return true;
		}

		public string GetConditionDescription()
		{
			return "Only in the Hallow.";
		}
	}
}
