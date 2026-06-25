using Terraria;
using Terraria.GameContent.ItemDropRules;

namespace ReducedGrinding.Common.DropConditions
{
    public class PostXmasPlantera : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            return Main.xMas && NPC.downedPlantBoss;
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
