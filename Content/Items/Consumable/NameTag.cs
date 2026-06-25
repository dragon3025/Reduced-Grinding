using Humanizer;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ReducedGrinding.Content.Items.Consumable
{
    public class NameTag : ModItem
    {
        public static int travelingMerchantDiceRolls;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LifeCrystal);
            Item.width = 32;
            Item.height = 24;
            Item.rare = ItemRarityID.White;
            Item.value = Item.buyPrice(0, 1);
        }

        public override bool CanUseItem(Player player)
        {
            foreach (NPC npc in Main.ActiveNPCs)
            {
                if (!npc.townNPC)
                {
                    continue;
                }

                if (player.Distance(npc.Center) <= 16 * 16)
                {
                    return true;
                }
            }

            return false;
        }

        public override bool? UseItem(Player player)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return true;
            }

            float closestNPCDistance = -1f;
            NPC closestNPC = null;
            foreach (NPC npc in Main.ActiveNPCs)
            {
                if (!npc.townNPC)
                {
                    continue;
                }

                if (closestNPCDistance == -1f)
                {
                    closestNPCDistance = player.Distance(npc.Center);
                    closestNPC = npc;
                }
                else
                {
                    float NPCDistance = player.Distance(npc.Center);
                    if (NPCDistance < closestNPCDistance)
                    {
                        closestNPCDistance = NPCDistance;
                        closestNPC = npc;
                    }
                }
            }

            if (closestNPC == null)
            {
                return true;
            }

            string newName = closestNPC.getNewNPCName();
            if (newName != "")
            {
                string message = ReducedGrinding.GetText("Misc.NameTag").FormatWith(closestNPC.GivenName, newName);
                closestNPC.GivenName = newName;
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.UniqueTownNPCInfoSyncRequest, number: closestNPC.whoAmI);
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey(message), new Color(255, 240, 20));
                }
                else
                {
                    Main.NewText(message, new Color(255, 240, 20));
                }
            }

            return true;
        }
    }
}