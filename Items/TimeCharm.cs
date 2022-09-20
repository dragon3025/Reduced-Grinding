using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Items
{
    public class TimeCharm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Time Charm");
            Tooltip.SetDefault("Use to increase time rate while sleeping");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 34;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 0, 6);
            Item.rare = ItemRarityID.Pink;
            Item.useAnimation = 20;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item4;
            Item.consumable = false;
        }

        public override bool? UseItem(Player player)
        {
            if (Global.Update.timeCharm == false)
            {
                Global.Update.timeCharm = true;
                if (Main.netMode == NetmodeID.Server)
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Time rate while sleeping is increased."), new Color(255, 255, 0)); //Localize
                else
                    Main.NewText("Time rate while sleeping is increased.", 255, 255, 0); //Localize
            }
            else
            {
                Main.NewText("The effects of Time Charm is already active in this world.", 255, 255, 0); //Localize
            }
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                ModPacket packet = Mod.GetPacket();
                packet.Write((byte)ReducedGrinding.MessageType.timeCharm);
                packet.Write(Global.Update.timeCharm);
                packet.Send();
            }
            return true;
        }

        public override void AddRecipes()
        {
            if (GetInstance<IOtherConfig>().TimeCharmSleepRateIncrease > 0)
            {
                CreateRecipe()
                  .AddIngredient(ItemID.SunplateBlock)
                  .AddIngredient(ItemID.SoulofLight)
                  .AddIngredient(ItemID.SoulofNight)
                  .AddTile(TileID.Sundial)
                  .Register();
            }
        }
    }
}