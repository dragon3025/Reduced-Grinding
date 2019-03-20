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
    public class Halloween_Spirit : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Halloween Spirit");
            Tooltip.SetDefault("Make it Halloween until the next day.");
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
			if (Main.halloween)
			{
				Main.NewText("It's already Halloween.", 255, 255, 255);
				return false;
			}
			else
				return true;
        }

        public override bool UseItem(Player player)
        {
			if (Main.netMode == 0)
			{
				Main.NewText("It's Halloween today!", 255, 255, 0);
			}
			else if (Main.netMode == 2)
			{
				NetMessage.BroadcastChatMessage(NetworkText.FromKey("It's Halloween today!"), new Color(255, 255, 0));
			}
			Main.xMas = false;
			Main.halloween = true;
			return true;
        }

        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(315, 1);
			recipe.AddIngredient(1725, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}