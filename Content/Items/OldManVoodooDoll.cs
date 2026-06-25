using ReducedGrinding.Configuration;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Items
{
    public class OldManVoodooDoll : ModItem
    {
        private readonly bool oldManVoodooDoll = GetInstance<EventAndBossConfig>().OldManVoodooDoll;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ClothierVoodooDoll);
            Item.width = 18;
            Item.height = 28;
            Item.accessory = false;
        }

        public override void AddRecipes()
        {
            if (oldManVoodooDoll != true)
            {
                return;
            }

            Recipe recipe = Recipe.Create(Type);
            recipe.AddIngredient(ItemID.ClothierVoodooDoll);
            recipe.AddTile(TileID.DemonAltar);
            Recipe recipe2 = recipe.Clone();

            recipe.AddIngredient(ItemID.VilePowder);
            recipe.Register();

            recipe2.AddIngredient(ItemID.ViciousPowder);
            recipe2.Register();
        }
    }
}