using ReducedGrinding.Configuration;
using ReducedGrinding.Global;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Items.BuffPotions
{
    public class MultiBobberPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.value = Terraria.Item.sellPrice(0, 0, 2);
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.buffType = ModContent.BuffType<Buffs.MultiBobber>();
            Item.buffTime = 10800; //3 minutes
        }

        public override void AddRecipes()
        {
            if (GetInstance<CFishingConfig>().BobberPotions.MultiBobberPotionBonus > 0)
            {
                Recipe recipe = Recipe.Create(Type);
                recipe.AddIngredient(ItemID.BottledWater);
                recipe.AddIngredient(ItemID.Waterleaf);
                recipe.AddIngredient(ItemID.MasterBait);
                recipe.AddTile(TileID.Bottles);
                recipe.Register();
            }
        }
    }
}