using ReducedGrinding.Configuration;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Content.Items.Placeable
{
    public class PlaceableLog : ModItem
    {
        public override void SetDefaults()
        {
            //In 1.4.5, Fairy Log has a new Sprite.

            Item.CloneDefaults(ItemID.WoodenTable);
            Item.width = 44;
            Item.height = 24;
            Item.createTile = ModContent.TileType<Tiles.PlacedLog>();
        }

        public override void AddRecipes()
        {
            if (!ModContent.GetInstance<OtherConfig>().PlaceableLog)
            {
                return;
            }
            Recipe recipe = Recipe.Create(Type);
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.AddTile(TileID.LivingLoom);
            recipe.Register();
        }
    }
}