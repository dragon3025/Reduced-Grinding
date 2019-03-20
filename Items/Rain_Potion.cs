using Terraria;
using Terraria.World.Generation;
using Terraria.ObjectData;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.ID;
using Terraria.GameContent.Generation;
using Terraria.GameContent.Events;
using Terraria.GameContent.Achievements;
using Terraria.Enums;
using Terraria.DataStructures;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ReducedGrinding.Items
{
    public class Rain_Potion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rain Potion");
            Tooltip.SetDefault("Starts/stops rain.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.maxStack = 30;
            item.rare = 2;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.value = 200;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override bool UseItem(Player player)
        {
            if (Main.raining)
                StopRain();
            else
                StartRain();
           
            return true;
        }
       
        private static void StopRain()
        {
			if (Main.netMode == 2) // Server
				NetMessage.BroadcastChatMessage(NetworkText.FromKey("The rain started to fade away."), new Color(0, 128, 255));
			else if (Main.netMode == 0) // Single Player
				Main.NewText("The rain started to fade away.", 0, 128, 255);
            Main.rainTime = 0;
            Main.raining = false;
            Main.maxRaining = 0f;
        }

        private static void StartRain()
        {
			if (Main.netMode == 2) // Server
			{
				NetMessage.BroadcastChatMessage(NetworkText.FromKey("The rain started to fade in."), new Color(0, 128, 255));
			}
			else if (Main.netMode == 0) // Single Player
			{
				Main.NewText("The rain started to fade in.", 0, 128, 255);
			}
            int num = 86400;
            int num2 = num / 24;
            Main.rainTime = Main.rand.Next(num2 * 8, num);
            if (Main.rand.Next(3) == 0)
            {
                Main.rainTime += Main.rand.Next(0, num2);
            }
            if (Main.rand.Next(4) == 0)
            {
                Main.rainTime += Main.rand.Next(0, num2 * 2);
            }
            if (Main.rand.Next(5) == 0)
            {
                Main.rainTime += Main.rand.Next(0, num2 * 2);
            }
            if (Main.rand.Next(6) == 0)
            {
                Main.rainTime += Main.rand.Next(0, num2 * 3);
            }
            if (Main.rand.Next(7) == 0)
            {
                Main.rainTime += Main.rand.Next(0, num2 * 4);
            }
            if (Main.rand.Next(8) == 0)
            {
                Main.rainTime += Main.rand.Next(0, num2 * 5);
            }
            float num3 = 1f;
            if (Main.rand.Next(2) == 0)
            {
                num3 += 0.05f;
            }
            if (Main.rand.Next(3) == 0)
            {
                num3 += 0.1f;
            }
            if (Main.rand.Next(4) == 0)
            {
                num3 += 0.15f;
            }
            if (Main.rand.Next(5) == 0)
            {
                num3 += 0.2f;
            }
            Main.rainTime = (int)((float)Main.rainTime * num3);
            ChangeRain();
            Main.raining = true;
        }
       
        private static void ChangeRain()
        {
            if (Main.cloudBGActive >= 1f || (double)Main.numClouds > 150.0)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Main.maxRaining = (float)Main.rand.Next(20, 90) * 0.01f;
                    return;
                }
                Main.maxRaining = (float)Main.rand.Next(40, 90) * 0.01f;
                return;
            }
            else if ((double)Main.numClouds > 100.0)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Main.maxRaining = (float)Main.rand.Next(10, 70) * 0.01f;
                    return;
                }
                Main.maxRaining = (float)Main.rand.Next(20, 60) * 0.01f;
                return;
            }
            else
            {
                if (Main.rand.Next(3) == 0)
                {
                    Main.maxRaining = (float)Main.rand.Next(5, 40) * 0.01f;
                    return;
                }
                Main.maxRaining = (float)Main.rand.Next(5, 30) * 0.01f;
                return;
            }
        }

        public override void AddRecipes()
        {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.BottledWater, 1);
				recipe.AddIngredient(ItemID.Waterleaf, 1);
				recipe.AddIngredient(ItemID.RainCloud, 1);
                recipe.AddTile(TileID.Bottles);
                recipe.SetResult(this);
                recipe.AddRecipe();
        }
    }
}