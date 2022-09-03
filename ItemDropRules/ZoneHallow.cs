using Terraria.GameContent.ItemDropRules;

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
			return "Only in the Hallow"; //Localize
		}
	}
}
