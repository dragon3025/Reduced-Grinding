using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
	public class Time_Potion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Time Potion");
			Tooltip.SetDefault("Clears the Enchanted Sundial cooldown and skips to Night Time.");
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
			item.value = (Config.TimePotionNeonTetraCost * 7500 + Config.TimePotionGlowingMushroomCost * 50) * 105 / 100;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return true;
		}

		public override bool UseItem(Player player)
		{
			if (!Main.dayTime && Main.sundialCooldown == 0)
				return false;
			else
			{
				if (Main.dayTime)
				{
					Main.time = 54000.0;
				}
				if (Main.sundialCooldown > 0)
				{
					Main.sundialCooldown = 0;
					Main.NewText("Enchanted Sundial is now ready for use.", 0, 127, 255);
				}
				return true;
			}
		}
	
		public override void AddRecipes()
		{

			if (Config.UseTimePotionRecipe)
			{
				ModRecipe recipe = new ModRecipe(mod);
				if (Config.TimePotionNeonTetraCost > 0)
					recipe.AddIngredient(ItemID.NeonTetra, Config.TimePotionNeonTetraCost);
				if (Config.TimePotionGlowingMushroomCost > 0)
					recipe.AddIngredient(ItemID.GlowingMushroom, Config.TimePotionGlowingMushroomCost);
				
				recipe.AddIngredient(ItemID.BottledWater, 1);
				recipe.AddTile(TileID.Bottles);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		
		}
	}
}