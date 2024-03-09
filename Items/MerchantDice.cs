using Humanizer;
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

        public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < Main.npc.Length; i++)
            {
                if (!Main.npc[i].active)
                {
                    continue;
                }

                if (Main.npc[i].type == NPCID.TravellingMerchant)
                {
                    return true;
                }
            }

            return false;
        }

        public override bool? UseItem(Player player)
        {
            if (Global.Update.travelingMerchantDiceRolls > 0)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Global.Update.travelingMerchantDiceRolls--;
                    Chest.SetupTravelShop();
                    string reRollsLeft = Language.GetTextValue("Mods.ReducedGrinding.Misc.MerchantDice.ReRollsLeft").FormatWith(Global.Update.travelingMerchantDiceRolls);
                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        Main.NewText(reRollsLeft, 255, 255, 0);
                    }
                    else
                    {
                        ChatHelper.BroadcastChatMessage(NetworkText.FromKey(reRollsLeft), new Color(255, 255, 0));

                        ModPacket packet = Mod.GetPacket();
                        packet.Write((byte)ReducedGrinding.MessageType.travelingMerchantDiceRolls);
                        packet.Write(Global.Update.travelingMerchantDiceRolls);
                        packet.Send();
                    }
                }
            }
            else if (player.whoAmI == Main.myPlayer)
            {
                Main.NewText(Language.GetTextValue("Mods.ReducedGrinding.Misc.MerchantDice.NoMoreReRolls"), 255, 127, 127);
            }

            return true;
        }
    }
}