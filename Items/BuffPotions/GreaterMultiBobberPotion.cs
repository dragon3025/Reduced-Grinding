using ReducedGrinding.Global;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Items.BuffPotions
{
    public class GreaterMultiBobberPotion : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Greater Multi-Bobber Potion");
            Tooltip.SetDefault("Adds even more bobbers when fishing");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
            Item.maxStack = 300;
            Item.rare = ReducedGrindingSave.usingCalamity ? ItemRarityID.Lime : ItemRarityID.Pink;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.value = Terraria.Item.sellPrice(0, 0, 2, 40);
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.buffType = BuffType<Buffs.GreaterMultiBobber>();
            Item.buffTime = 10800; //3 minutes
        }

        public override bool? UseItem(Player player)
        {
            player.ClearBuff(BuffType<Buffs.MultiBobber>());
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            if (GetInstance<CFishingConfig>().GreaterMultiBobberPotionBonus > 0)
            {
                Recipe recipe = Recipe.Create(ItemType<GreaterMultiBobberPotion>());
                recipe.AddIngredient(ItemType<MultiBobberPotion>());
                recipe.AddIngredient(ItemID.GelBalloon);
                if (ReducedGrindingSave.usingCalamity)
                {
                    recipe.AddIngredient(ItemID.VialofVenom);
                }

                recipe.AddTile(TileID.Bottles);
                recipe.Register();
            }
        }
    }
}