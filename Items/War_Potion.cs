using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
	public class War_Potion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("War Potion");
			Tooltip.SetDefault("Greatly increases enemy spawn rate.");
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
			player.AddBuff(mod.BuffType("War"), Config.WarPotionDurationInFrames);
			return true;
		}
	
		public override void AddRecipes()
		{
			if (Config.UseWarPotionRecipe)
			{
				//Set Powder and Mushroom cost
				int WarPowderCost = Config.WarPotionPowderCost;
				int WarMushroomCost = 0;
				while (WarPowderCost >= 5)
				{
					WarPowderCost -= 5;
					WarMushroomCost++;
				}
				
				//War Potion recipe for corruption
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.BattlePotion,1);
				if (WarMushroomCost > 0)
				{
					recipe.AddIngredient(ItemID.VileMushroom,WarMushroomCost);
				}
				if (WarPowderCost > 0){
					recipe.AddIngredient(ItemID.VilePowder,WarPowderCost);
				}
				recipe.AddTile(TileID.Bottles);
				recipe.SetResult(this);
				recipe.AddRecipe();
					
				//War Potion recipe for crimson
				recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.BattlePotion,1);
				if (WarMushroomCost > 0)
				{
					recipe.AddIngredient(ItemID.ViciousMushroom,WarMushroomCost);
				}
				if (WarPowderCost > 0){
					recipe.AddIngredient(ItemID.ViciousPowder,WarPowderCost);
				}
				recipe.AddTile(TileID.Bottles);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		
		}
	}
}