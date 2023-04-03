using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

//Remove when 1.4.4+ comes out unless there isn't a way to add shimmer features
namespace ReducedGrinding.Items.Placeable
{
    [LegacyName("LumaniteShimmeringStar")]

    public class LuminiteShimmeringStar : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Red;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 10);
            Item.createTile = ModContent.TileType<Tiles.LumaniteShimmeringStar>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
              .AddIngredient(ModContent.ItemType<ShimmeringStar>())
              .AddIngredient(ItemID.LunarBar, 10)
              .Register();
        }
    }
}