using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using ReducedGrinding.Content.Items;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalNPCs
{
    public class TravelingMerchant : GlobalNPC
    {
        public static bool chatMerchantItems;
        private static readonly TravelingMerchantConfig travelingMerchant = GetInstance<TravelingMerchantConfig>();

        public override void SetupTravelShop(int[] shop, ref int nextSlot)
        {

            if (SellMerchantDice())
            {
                shop[nextSlot] = ItemType<MerchantDice>();
                nextSlot++;
            }

            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.TravelMerchantItems);
            }

            chatMerchantItems = travelingMerchant.TravelingMerchantChatsItems;
        }

        private static bool SellMerchantDice()
        {
            if (NPC.downedMoonlord)
            {
                return travelingMerchant.MerchantDiceUsesPostMoonlord > 0;
            }
            else if (NPC.downedPlantBoss)
            {
                return travelingMerchant.MerchantDiceUsesPostPlantera > 0;
            }
            else if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                return travelingMerchant.MerchantDiceUsesPostMechBosses > 0;
            }
            else if (Main.hardMode)
            {
                return travelingMerchant.MerchantDicePostHardmode > 0;
            }
            else
            {
                return travelingMerchant.MerchantDiceUsesPreHardmode > 0;
            }
        }
    }

    public class TravelingMerchantModSystem : ModSystem
    {
        public override void PostUpdateTime()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient || !TravelingMerchant.chatMerchantItems)
            {
                return;
            }

            TravelingMerchant.chatMerchantItems = false;

            string itemList = "";

            for (int slot = 0; slot < Main.travelShop.Length; slot++)
            {
                if (Main.travelShop[slot] != ItemID.None)
                {
                    itemList += $"[i:{Main.travelShop[slot]}]";
                }
            }

            if (itemList == "")
            {
                return;
            }

            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(itemList);
                return;
            }
            ChatHelper.BroadcastChatMessage(NetworkText.FromKey(itemList), new Color(0, 0, 0));
        }
    }
}
