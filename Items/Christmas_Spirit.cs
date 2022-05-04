using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
    public class Christmas_Spirit : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Christmas Spirit");
            Tooltip.SetDefault("Make it Christmas until the next day.");
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

        public override bool CanUseItem(Player player)
        {
			if (Main.xMas)
			{
				Main.NewText("It's already Christmas.", 255, 255, 255);
				return false;
			}
			else
				return true;
        }

        public override bool? UseItem(Player player)
        {
			if (Main.netMode == NetmodeID.SinglePlayer)
			{
				Main.NewText("It's Christmas today!", 255, 255, 0);
			}
			/*else if (Main.netMode == NetmodeID.Server)
			{
                Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromKey("It's Christmas today!"), new Color(255, 255, 0));
			}*/
			Main.halloween = false;
			Main.xMas = true;
			if (Main.netMode == NetmodeID.Server)
				NetMessage.SendData(MessageID.WorldData);
			return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BottledWater, 1)
                .AddIngredient(ItemID.Shiverthorn, 1)
                .AddIngredient(ItemID.SnowBlock, 1)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}