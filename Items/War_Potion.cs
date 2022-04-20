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
            item.rare = 2;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.value = Item.buyPrice(0, 0, 1, 13);
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
            player.AddBuff(mod.BuffType("War"), 25200);
            return true;
        }

        public override void AddRecipes()
        {

            //War Potion recipe for corruption
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BattlePotion, 1);
            recipe.AddIngredient(ItemID.VileMushroom, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

            //War Potion recipe for crimson
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BattlePotion, 1);
            recipe.AddIngredient(ItemID.ViciousMushroom, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}