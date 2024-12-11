using ReducedGrinding.Configuration;
using System.Configuration;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Items.BuffPotions
{
    public class GreaterBattlePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.value = Item.sellPrice(0, 0, 2, 10);
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.buffType = BuffID.Battle;
            Item.buffTime = 50400; //14 Minutes
        }

        public override void AddRecipes()
        {
            if (GetInstance<HOtherModdedItemsConfig>().BattlePotion.GreaterMax > 2 || GetInstance<HOtherModdedItemsConfig>().BattlePotion.GreaterSpawnRate > 2)
            {
                Recipe recipe = Recipe.Create(Type);
                recipe.AddIngredient(ItemID.BattlePotion);
                recipe.AddIngredient(ItemID.VileMushroom);
                recipe.AddTile(TileID.Bottles);
                recipe.Register();

                recipe = Recipe.Create(Type);
                recipe.AddIngredient(ItemID.BattlePotion);
                recipe.AddIngredient(ItemID.ViciousMushroom);
                recipe.AddTile(TileID.Bottles);
                recipe.Register();
            }
        }
    }
}