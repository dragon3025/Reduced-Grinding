using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items.BuffPotions
{
    public class GreaterBattlePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Greater Battle Potion");
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
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.value = Item.buyPrice(0, 0, 14);
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.buffType = ModContent.BuffType<Buffs.GreaterBattle>();
            Item.buffTime = 25200; //7 Hours
        }

        //Recipe is in Recipes.cs because it uses groups.

    }
}