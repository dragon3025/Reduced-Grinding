using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items.Placeable
{
    public class MoonBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("{$Mods.ReducedGrinding.ItemName.MoonBall}"); //I'm struggling to figure this out
            DisplayName.SetDefault("Moon Ball");
            Tooltip.SetDefault("Advances the Moon Phase");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
            Item.value = Item.buyPrice(0, 10, 0, 0);
            Item.createTile = ModContent.TileType<Tiles.MoonBall>();
        }
    }
}