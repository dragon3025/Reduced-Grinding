using ReducedGrinding.Configuration;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class GlobalPlayer : ModPlayer
    {
        public int hasQuestFish = 0;

        readonly static IOtherConfig otherConfig = GetInstance<IOtherConfig>();

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

        public bool showLuck;

        public override void ResetInfoAccessories()
        {
            if (!otherConfig.ClairvoyanceShowsLuck)
            {
                return;
            }

            showLuck = false;

            if (Player.HasBuff(BuffID.Clairvoyance))
            {
                showLuck = true;
            }
        }

        public override void RefreshInfoAccessoriesFromTeamPlayers(Player otherPlayer)
        {
            if (otherPlayer.GetModPlayer<GlobalPlayer>().showLuck)
            {
                showLuck = true;
            }
        }
    }
}