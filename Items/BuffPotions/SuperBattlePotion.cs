using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace ReducedGrinding.Items.BuffPotions
{
    public class SuperBattlePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Super Battle Potion");
            Tooltip.SetDefault("Massively increases enemy spawn rate");
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
            Item.value = Item.sellPrice(0, 0, 12, 10);
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.buffType = BuffType<Buffs.SuperBattle>();
            Item.buffTime = 25200; //7 Minutes
        }

        public override bool? UseItem(Player player)
        {
            player.AddBuff(BuffID.Battle, 25200); //7 minutes
            player.AddBuff(BuffType<Buffs.GreaterBattle>(), 25200); //7 minutes
            return true;
        }

        public override void AddRecipes()
        {
            if (GetInstance<HOtherModdedItemsConfig>().SuperBattlePotionMaxSpawnsMultiplier > 1 || GetInstance<HOtherModdedItemsConfig>().SuperBattlePotionSpawnrateMultiplier > 1)
            {
                Recipe recipe = Recipe.Create(Type);
                recipe.AddIngredient(ItemType<GreaterBattlePotion>());
                recipe.AddIngredient(ItemID.DemoniteOre);
                recipe.AddTile(TileID.Bottles);
                recipe.Register();

                recipe = Recipe.Create(Type);
                recipe.AddIngredient(ItemType<GreaterBattlePotion>());
                recipe.AddIngredient(ItemID.CrimtaneOre);
                recipe.AddTile(TileID.Bottles);
                recipe.Register();
            }
        }
    }
}