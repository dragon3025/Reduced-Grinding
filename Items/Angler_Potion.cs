using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
    public class Angler_Potion : ModItem
    {
		
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Angler Potion");
            Tooltip.SetDefault("One botle of this will make the Angler want to give you a new fishing quest right away.");
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
			Main.NewText("The angler has a new quest for you.", 0, 128, 255);
			Main.AnglerQuestSwap();
			if (Main.netMode == NetmodeID.Server)
				NetMessage.SendData(7);
			return true;
        }

        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(ItemID.SpecularFish);
			recipe.AddIngredient(ItemID.Moonglow);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}