using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;

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
            item.rare = 0;
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
			Main.NewText("The sandstorm stopped.", 255, 255, 0);
			Sandstorm.Happening = false;
			Sandstorm.TimeLeft = 0;
			ChangeSeverityIntentions();
		}

		private static void StartSandstorm()
		{
			Main.NewText("The sandstorm started.", 255, 255, 0);
			Sandstorm.Happening = true;
			Sandstorm.TimeLeft = (int)(3600f * (8f + Main.rand.NextFloat() * 16f));
			ChangeSeverityIntentions();
		}

        public override void AddRecipes()
        {
			if (Config.UseSandstormPotionRecipe)
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