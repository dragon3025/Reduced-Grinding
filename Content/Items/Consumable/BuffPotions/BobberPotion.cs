using ReducedGrinding.Configuration;
using ReducedGrinding.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Items.Consumable.BuffPotions
{
    public class BobberPotion : ModItem
    {
        private static int type;
        private static int type2;

        public override void SetDefaults()
        {
            type = GetInstance<BobberPotionConfig>().BobberPotionIngredient.Type;
            type2 = GetInstance<BobberPotionConfig>().BobberPotionAlternateIngredient.Type;
            Item.CloneDefaults(ItemID.ObsidianSkinPotion);
            Item.width = 28;
            Item.height = 30;
            Item.rare = ItemHelper.GetItemRarityFromIngredients(ItemRarityID.White, type, type2);
            Item.buffType = BuffType<Bobber>();
            Item.buffTime = 3 * 60 * 60;
        }

        public override void AddRecipes()
        {
            if (type != ItemID.None)
            {
                Recipe recipe = Recipe.Create(Type);
                recipe.AddIngredient(type);
                recipe.AddIngredient(ItemID.BottledWater);
                recipe.AddIngredient(ItemID.Waterleaf);
                recipe.AddTile(TileID.Bottles);
                recipe.Register();
            }

            if (type2 == ItemID.None)
            {
                return;
            }
            Recipe recipe2 = Recipe.Create(Type);
            recipe2.AddIngredient(type2);
            recipe2.AddIngredient(ItemID.BottledWater);
            recipe2.AddIngredient(ItemID.Waterleaf);
            recipe2.AddTile(TileID.Bottles);
            recipe2.Register();
        }
    }
}