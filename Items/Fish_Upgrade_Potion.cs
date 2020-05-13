using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
    public class Fish_Upgrade_Potion : ModItem
    {

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fish Upgrade Potion");
			Tooltip.SetDefault("Every 5 Fishing Quest completed will increase the chance of catching rare fish (Vanilla rods only), 500 Quest max");
		}

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 30;
            item.maxStack = 30;
            item.rare = 2;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.value = Item.buyPrice(0, 0, 2);
            item.UseSound = SoundID.Item3;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return true;
		}

		public override bool UseItem(Player player)
		{
			player.AddBuff(BuffID.Battle, 25200);
			player.AddBuff(mod.BuffType("Fish_Upgrade"), 28800);
			return true;
		}

		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.NeonTetra);
			recipe.AddIngredient(ItemID.Blinkroot);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}