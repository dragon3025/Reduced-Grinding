using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
	public class Chaos_Potion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chaos Potion");
			Tooltip.SetDefault("Massively increases enemy spawn rate.");
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
			item.value = (88 * Config.WarPotionPowderCost * 5);
			item.UseSound = SoundID.Item3;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return true;
		}

		public override bool UseItem(Player player)
		{
			player.AddBuff(13, 25200); //Battle
			player.AddBuff(mod.BuffType("War"), Config.WarPotionDurationInFrames);
			player.AddBuff(mod.BuffType("Chaos"), Config.WarPotionDurationInFrames);
			return true;
		}
	
		public override void AddRecipes()
		{
			if (Config.ChaosPotionRecipe)
			{
                ModRecipe recipe = new ModRecipe(mod);
				if (Config.WarPotionRecipe)
					recipe.AddIngredient(mod.ItemType("War_Potion"));
				else
					recipe.AddIngredient(ItemID.BattlePotion,1);
				if (Config.ChaosPotionPixieDustCost > 0)
					recipe.AddIngredient(501, Config.ChaosPotionPixieDustCost);
                recipe.AddTile(TileID.Bottles);
                recipe.SetResult(this);
                recipe.AddRecipe();
			}
		}
	}
}