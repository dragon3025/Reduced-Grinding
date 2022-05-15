using Terraria.GameContent.ItemDropRules;

namespace ReducedGrinding.Common.ItemDropRules.Conditions
{
	public class ZoneCrimsonNoOtherInfection : IItemDropRuleCondition
	{
		public bool CanDrop(DropAttemptInfo info)
		{
			if (!info.IsInSimulation)
			{
				if (info.player.ZoneCorrupt)
					return false;
				if (info.player.ZoneHallow)
					return false;
				return info.player.ZoneCrimson;
			}
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
