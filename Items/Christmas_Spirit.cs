using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria;

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
            item.width = 12;
            item.height = 30;
            item.maxStack = 30;
            item.rare = 1;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.value = 20;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
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

        public override bool UseItem(Player player)
        {
			if (Main.netMode == 0)
			{
				Main.NewText("It's Christmas today!", 255, 255, 0);
			}
			else if (Main.netMode == 2)
			{
				NetMessage.BroadcastChatMessage(NetworkText.FromKey("It's Christmas today!"), new Color(255, 255, 0));
			}
			Main.halloween = false;
			Main.xMas = true;
			return true;
        }

        public override void AddRecipes()
        {
			if (Config.AnglerPotionRecipe)
			{
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.BottledWater, 1);
				recipe.AddIngredient(2358, 1);
				recipe.AddIngredient(593, 1);
                recipe.AddTile(TileID.Bottles);
                recipe.SetResult(this);
                recipe.AddRecipe();
			}
        }
    }
}