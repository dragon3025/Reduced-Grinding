using ReducedGrinding.Global;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;

namespace ReducedGrinding.Common.ItemDropRules.Conditions
{
    public class FirstDutchman : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            if (info.IsInSimulation)
                return false;
            if (Main.invasionType != InvasionID.PirateInvasion)
                return false;
            if (!Update.dutchManKilled)
                return true;
            return false;
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return "Only 1 per invasion"; //Localize
        }
    }
}
