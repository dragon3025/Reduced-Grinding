using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items.BuffPotions
{
    public class Chaos_Potion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaos Potion");
            Tooltip.SetDefault("Massively increases enemy spawn rate.");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.maxStack = 30;
            Item.rare = ItemRarityID.Green;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.value = Terraria.Item.buyPrice(0, 0, 2, 34);
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
        }

        public override bool CanUseItem(Terraria.Player player)
        {
            return true;
        }

        public override bool? UseItem(Terraria.Player player)
        {
            player.AddBuff(BuffID.Battle, 25200);
            player.AddBuff(ModContent.BuffType<Buffs.War>(), 25200);
            player.AddBuff(ModContent.BuffType<Buffs.Chaos>(), 25200);
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Items.BuffPotions.War_Potion>())
                .AddIngredient(ItemID.PixieDust, 1)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}