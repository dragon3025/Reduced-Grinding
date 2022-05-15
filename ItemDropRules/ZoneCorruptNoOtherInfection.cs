using Terraria.GameContent.ItemDropRules;

namespace ReducedGrinding.Common.ItemDropRules.Conditions
{
	public class ZoneCorruptnNoOtherInfection : IItemDropRuleCondition
	{
		public bool CanDrop(DropAttemptInfo info)
		{
			if (!info.IsInSimulation)
			{
				if (info.player.ZoneCrimson)
					return false;
				if (info.player.ZoneHallow)
					return false;
				return info.player.ZoneCorrupt;
			}
			return false;
		}

		public bool CanShowItemDropInUI()
		{
			return true;
		}

		public string GetConditionDescription()
		{
			return "Only in the Corruption.";
		}
	}
}
