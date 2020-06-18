using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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
			item.rare = 2;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 4;
            item.useTurn = true;
            item.value = Item.buyPrice(0, 0, 1, 13);
			item.UseSound = SoundID.Item3;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.consumable = true;
            item.buffType = BuffType<Buffs.War>();
            item.buffTime = 25200;

        }

        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(13, 25200); //Battle
            return true;
        }

        public override void AddRecipes()
		{
			
			//War Potion recipe for corruption
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BattlePotion,1);
			recipe.AddIngredient(ItemID.VileMushroom, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
				
			//War Potion recipe for crimson
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BattlePotion,1);
			recipe.AddIngredient(ItemID.ViciousMushroom, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}