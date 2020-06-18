using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 4;
            item.useTurn = true;
            item.value = Item.buyPrice(0, 0, 2, 34);
			item.UseSound = SoundID.Item3;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.consumable = true;
            item.buffType = BuffType<Buffs.Chaos>();
            item.buffTime = 25200;
        }

		public override bool CanUseItem(Player player)
		{
			return true;
		}

		public override bool UseItem(Player player)
		{
			player.AddBuff(BuffID.Battle, 25200);
			player.AddBuff(mod.BuffType("War"), 25200);
			return true;
		}
	
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("War_Potion"));
			recipe.AddIngredient(ItemID.PixieDust, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}