using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
    public class Fish_Upgrade_Potion : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fish Upgrade Potion");
            Tooltip.SetDefault("Every 5 Fishing Quest completed will increase the chance of catching rare fish (Vanilla rods only), 500 Quest max");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 30;
            Item.maxStack = 30;
            Item.rare = ItemRarityID.Green;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.value = Item.buyPrice(0, 0, 2);
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.buffType = ModContent.BuffType<Buffs.Fish_Upgrade>();
            Item.buffTime = 25200;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BottledWater)
                .AddIngredient(ItemID.NeonTetra)
                .AddIngredient(ItemID.Blinkroot)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}