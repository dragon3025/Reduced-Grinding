using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    // Inventory can only be altered by the player and not the server, which is the reason for this file.
    public class FishingTicketExpire : ModPlayer
    {
        private bool loaded = false;
        private bool dayTime = Main.dayTime;
        private int anglerQuestsPrevious = Update.anglerQuests;

        public override void PostUpdate()
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            bool newDay = false;
            if (dayTime != Main.dayTime)
            {
                newDay = dayTime = Main.dayTime;
            }

            bool noMoreExtraQuest = false;
            if (anglerQuestsPrevious != Update.anglerQuests)
            {
                anglerQuestsPrevious = Update.anglerQuests;
                if (anglerQuestsPrevious < 2)
                {
                    noMoreExtraQuest = true;
                }
            }

            if (newDay || noMoreExtraQuest || !loaded)
            {
                if (!loaded)
                {
                    loaded = true;
                }

                for (int i = 0; i < Player.inventory.Length; i++)
                {
                    if (Player.inventory[i].type == ItemType<Items.FishingTicket>())
                    {
                        Player.inventory[i].TurnToAir();
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            NetMessage.SendData(MessageID.SyncEquipment, -1, -1, null, Player.whoAmI, i);
                        }
                    }
                }
            }
        }
    }
}
