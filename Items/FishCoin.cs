using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
    public class FishCoin : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fish Coin"); //Localize
            Tooltip.SetDefault("Currency for trading with the Fish Merchant"); //Localize
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Orange;
        }
    }
}