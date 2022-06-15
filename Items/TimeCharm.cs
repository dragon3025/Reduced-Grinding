using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
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
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 34;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 0, 6);
            Item.rare = ItemRarityID.Orange;
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
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Time rate while sleeping is increased."), new Color(255, 255, 0));
                else
                    Main.NewText("Time rate while sleeping is increased.", 255, 255, 0);
            }
            else
            {
                Global.Update.timeCharm = false;
                if (Main.netMode == NetmodeID.Server)
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Time rate while sleeping is normal."), new Color(255, 255, 0));
                else
                    Main.NewText("Time rate while sleeping is normal.", 255, 255, 0);
            }
            if (Main.netMode == NetmodeID.MultiplayerClient) //Client
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
            if (GetInstance<IOtherConfig>().SleepBoostTimeCharmMultiplier < 1 || GetInstance<IOtherConfig>().SleepBoostBase == 0)
            {
                CreateRecipe()
                  .AddIngredient(ItemID.SunplateBlock)
                  .AddIngredient(ItemID.SoulofFlight)
                  .AddIngredient(ItemID.SoulofLight)
                  .AddIngredient(ItemID.SoulofNight)
                  .AddTile(TileID.Sundial)
                  .Register();
            }
        }
    }
}