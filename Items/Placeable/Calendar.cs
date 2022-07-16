using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace ReducedGrinding.Items.Placeable
{
    public class Calendar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Calendar");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 46;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.White;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
            Item.value = Item.buyPrice(0, 0, 1);
            Item.createTile = ModContent.TileType<Tiles.Calendar>();
        }
    }
}