using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria.DataStructures;
using Terraria.GameContent.Events;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria;

namespace ReducedGrinding.Items
{
    public class Sandstorm_Potion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandstorm Potion");
            Tooltip.SetDefault("Starts/stops sandstorm");
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
            item.value = (Config.SandstormPotionBlinkrootCost * 200);
            item.UseSound = SoundID.Item3;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override bool UseItem(Player player)
        {
            if (Sandstorm.Happening)
                StopSandstorm();
            else
                StartSandstorm();
           
            return true;
        }
		
		private static void ChangeSeverityIntentions()
		{
			if (Sandstorm.Happening)
			{
				Sandstorm.IntendedSeverity = 0.4f + Main.rand.NextFloat();
			}
			else
			{
				if (Main.rand.Next(3) == 0)
				{
					Sandstorm.IntendedSeverity = 0f;
				}
				else
				{
					Sandstorm.IntendedSeverity = Main.rand.NextFloat() * 0.3f;
				}
			}
			if (Main.netMode != 1)
			{
				NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
			}
		}
       
		private static void StopSandstorm()
		{
			if (Main.netMode == 2) // Server
				NetMessage.BroadcastChatMessage(NetworkText.FromKey("The sandstorm stopped."), new Color(0, 128, 255));
			else if (Main.netMode == 0) // Single Player
				Main.NewText("The sandstorm stopped.", 0, 128, 255);
			Sandstorm.Happening = false;
			Sandstorm.TimeLeft = 0;
			ChangeSeverityIntentions();
		}

		private static void StartSandstorm()
		{
			if (Main.netMode == 2) // Server
			{
				NetMessage.BroadcastChatMessage(NetworkText.FromKey("The sandstorm started."), new Color(0, 128, 255));
			}
			else if (Main.netMode == 0) // Single Player
			{
				Main.NewText("The sandstorm started.", 0, 128, 255);
			}
			Sandstorm.Happening = true;
			Sandstorm.TimeLeft = (int)(3600f * (8f + Main.rand.NextFloat() * 16f));
			ChangeSeverityIntentions();
		}

        public override void AddRecipes()
        {
			if (Config.SandstormPotionRecipe)
			{
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.BottledWater, 1);
				if (Config.SandstormPotionBlinkrootCost > 0)
					recipe.AddIngredient(ItemID.Blinkroot, Config.SandstormPotionBlinkrootCost);
				if (Config.SandstormPotionSandBlockCost > 0)
					recipe.AddIngredient(ItemID.SandBlock, Config.SandstormPotionSandBlockCost);
                recipe.AddTile(TileID.Bottles);
                recipe.SetResult(this);
                recipe.AddRecipe();
			}
        }
    }
}