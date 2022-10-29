using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Items.Placeable
{
    public class MoonBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moon Ball");
            Tooltip.SetDefault("Advances the Moon Phase");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 3, 80, 0);
            Item.createTile = ModContent.TileType<Tiles.MoonBall>();
        }

        public override void AddRecipes()
        {
            if (GetInstance<HOtherModdedItemsConfig>().MoonBall)
            {
                CreateRecipe()
              .AddIngredient(ItemID.MeteoriteBar, 20)
              .AddIngredient(ItemID.FallenStar, 20)
              .AddIngredient(ItemID.Glass, 20)
              .AddTile(TileID.DemonAltar)
              .Register();
            }
        }
    }
}