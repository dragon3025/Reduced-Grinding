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
            DisplayName.SetDefault("Greater Battle Potion");
            Tooltip.SetDefault("Greatly increases enemy spawn rate");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.maxStack = 300;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.value = Item.sellPrice(0, 0, 2, 10);
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.buffType = ModContent.BuffType<Buffs.GreaterBattle>();
            Item.buffTime = 25200; //7 Minutes
        }

        public override bool? UseItem(Player player)
        {
            player.AddBuff(BuffID.Battle, 25200); //7 minutes
            return true;
        }

        public override void AddRecipes()
        {
            if (GetInstance<HOtherModdedItemsConfig>().GreaterBattlePotionMaxSpawnsMultiplier > 1 || GetInstance<HOtherModdedItemsConfig>().GreaterBattlePotionSpawnrateMultiplier > 1)
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