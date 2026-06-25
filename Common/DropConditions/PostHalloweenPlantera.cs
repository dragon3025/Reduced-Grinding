using Terraria;
using Terraria.GameContent.ItemDropRules;

namespace ReducedGrinding.Common.DropConditions
{
    public class PostHalloweenPlantera : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            return Main.halloween && NPC.downedPlantBoss;
        }

        public bool CanShowItemDropInUI()
        {
            return false;
        }

        public string GetConditionDescription()
        {
            return "";
        }
    }
}
