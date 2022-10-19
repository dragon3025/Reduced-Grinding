using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items.Placeable
{
    public class ShimmeringStar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shimmering Star");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Green;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 25);
            Item.createTile = ModContent.TileType<Tiles.ShimmeringStar>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
              .AddIngredient(ModContent.ItemType<Items.Placeable.ShimmeringStar>())
              .AddIngredient(ItemID.LunarBar, 10)
              .Register();
        }
    }
}