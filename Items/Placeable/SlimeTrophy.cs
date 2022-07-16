using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace ReducedGrinding.Items.Placeable
{
    public class SlimeTrophy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slime Trophy");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.LightRed;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
            Item.value = Item.buyPrice(0, 10);
            Item.createTile = ModContent.TileType<Tiles.SlimeTrophy>();
        }
    }
}