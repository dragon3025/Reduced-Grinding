using Terraria;
using Terraria.ModLoader;

namespace ReducedGrinding.Common.ModPlayers
{
    public class QuestFishTimer : ModPlayer
    {
        public int inventoryQuestFishTimer;
        public static readonly int maxInventoryQuestFishTimer = 60 * 3;

        public override void PreUpdate()
        {
            int questFish = Main.anglerQuestItemNetIDs[Main.anglerQuest];

            if (Player.HasItem(questFish))
            {
                inventoryQuestFishTimer = maxInventoryQuestFishTimer;
            }
            else if (Player.inventory[58].type == questFish)
            {
                inventoryQuestFishTimer = maxInventoryQuestFishTimer;
            }
            else if (inventoryQuestFishTimer > 0)
            {
                inventoryQuestFishTimer--;
            }
        }
    }
}