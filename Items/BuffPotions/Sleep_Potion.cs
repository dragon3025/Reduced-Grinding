using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Items.BuffPotions
{
    public class Sleep_Potion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sleep Potion");
            Tooltip.SetDefault("Increases sleep rate.");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.maxStack = 30;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.value = Terraria.Item.sellPrice(0, 0, 2, 0);
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.buffType = ModContent.BuffType<Buffs.Sleep>();
            Item.buffTime = 43200;
        }

        public override void AddRecipes()
        {
            if (GetInstance<IOtherConfig>().SleepBoostNoPotionBuffMultiplier < 1 || GetInstance<IOtherConfig>().SleepBoostBase == 0)
            {
                CreateRecipe()
                  .AddIngredient(ItemID.BottledWater)
                  .AddIngredient(ItemID.SpecularFish)
                  .AddIngredient(ItemID.FallenStar)
                  .AddTile(TileID.Bottles)
                  .Register();
            }
        }
    }
}