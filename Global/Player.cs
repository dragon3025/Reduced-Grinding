using Terraria;
using Terraria.ModLoader;

namespace ReducedGrinding.Global
{
    public class GlobalPlayer : ModPlayer
    {
        public int hasQuestFish = 0;

        public override void PreUpdate()
        {
            int questFish = Main.anglerQuestItemNetIDs[Main.anglerQuest];

            if (Player.HasItem(questFish))
            {
                hasQuestFish = 15;
            }
            else if (Player.inventory[58].type == questFish)
            {
                hasQuestFish = 15;
            }
            else if (hasQuestFish > 0)
            {
                hasQuestFish--;
            }
        }
    }
}