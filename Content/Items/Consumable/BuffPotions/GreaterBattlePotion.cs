using ReducedGrinding.Configuration;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Items.Consumable.BuffPotions
{
    public class GreaterBattlePotion : ModItem
    {
        private static readonly BattlePotionConfig battlePotion = GetInstance<BattlePotionConfig>();

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BattlePotion);
            Item.width = 20;
            Item.height = 30;
            Item.buffTime = battlePotion.GreaterDuration * 60 * 60;
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            if (GetInstance<BattlePotionConfig>().GreaterBattlePotion)
            {
                Recipe recipe = Recipe.Create(Type);
                recipe.AddIngredient(ItemID.BattlePotion, 3);
                recipe.AddTile(TileID.Bottles);
                Recipe recipe2 = recipe.Clone();

                recipe.AddIngredient(ItemID.VilePowder);
                recipe.Register();

                recipe2.AddIngredient(ItemID.ViciousPowder);
                recipe2.Register();
            }
        }
    }
}