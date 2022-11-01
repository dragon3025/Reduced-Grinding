using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
    public class MerchantDice : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Merchant Dice");
            Tooltip.SetDefault("Use to reroll the Traveling Merchant shop (with limited uses per day)");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 30;
            Item.maxStack = 1;
            Item.value = Item.buyPrice(0, 10);
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item4;
            Item.consumable = false;
        }

        public override bool? UseItem(Player player)
        {
            if (Global.Update.travelingMerchantDiceRolls > 0)
            {
                Chest.SetupTravelShop();
                Global.Update.travelingMerchantDiceRolls--;
                if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Traveling Merchant shop re-rolled. Re-rolls left: " + Global.Update.travelingMerchantDiceRolls.ToString()), new Color(255, 255, 0));
                    NetMessage.SendData(MessageID.WorldData);
                }
                else if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    ModPacket packet = Mod.GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.travelingMerchantDiceRolls);
                    packet.Write(Global.Update.travelingMerchantDiceRolls);
                    packet.Send();
                }
                else
                {
                    Main.NewText("Traveling Merchant shop re-rolled. Re-rolls left: " + Global.Update.travelingMerchantDiceRolls.ToString(), 255, 255, 0);
                }
            }
            else
            {
                Main.NewText("You have no more re-rolls left.", 255, 127, 127);
            }

            return true;
        }
    }
}