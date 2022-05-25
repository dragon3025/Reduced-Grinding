using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;
using Terraria.Chat;

namespace ReducedGrinding.Items
{
	public class Halloween_Spirit : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Halloween Spirit");
            Tooltip.SetDefault("Make it Halloween until the next day.");
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 30;
            Item.maxStack = 30;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.value = 20;
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
        }

        public override bool CanUseItem(Terraria.Player player)
        {
			if (Main.halloween)
			{
				Main.NewText("It's already Halloween.", 255, 255, 255);
				return false;
			}
			else
				return true;
        }

        public override bool? UseItem(Terraria.Player player)
        {
			if (Main.netMode == NetmodeID.SinglePlayer)
			{
				Main.NewText("It's Halloween today!", 255, 255, 0);
			}
			else if (Main.netMode == NetmodeID.Server)
			{
                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("It's Halloween today!"), new Color(255, 255, 0));
			}
			Main.xMas = false;
			Main.halloween = true;
			if (Main.netMode == NetmodeID.Server)
				NetMessage.SendData(MessageID.WorldData);
			return true;
        }

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ItemID.Blinkroot)
				.AddIngredient(ItemID.Pumpkin)
				.AddTile(TileID.Bottles)
				.Register();
        }
    }
}