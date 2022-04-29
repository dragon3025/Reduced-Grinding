using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
    public class War_Potion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("War Potion");
            Tooltip.SetDefault("Greatly increases enemy spawn rate.");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.maxStack = 30;
            Item.rare = ItemRarityID.Green;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.value = Item.buyPrice(0, 0, 1, 13);
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.buffType = ModContent.BuffType<Buffs.War>();
            Item.buffTime = 25200;
        }

        public override void AddRecipes()
        {

            //War Potion recipe for corruption
            CreateRecipe()
                .AddIngredient(ItemID.BattlePotion)
                .AddIngredient(ItemID.VileMushroom)
                .AddTile(TileID.Bottles)
                .Register();

            //War Potion recipe for crimson
            CreateRecipe()
                .AddIngredient(ItemID.BattlePotion)
                .AddIngredient(ItemID.ViciousMushroom)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}