using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items.BuffPotions
{
    public class SuperBattlePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Super Battle Potion");
            Tooltip.SetDefault("Massively increases enemy spawn rate");
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
            Item.value = Item.buyPrice(0, 0, 3);
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
        }

        public override bool CanUseItem(Terraria.Player player)
        {
            return true;
        }

        public override bool? UseItem(Terraria.Player player)
        {
            player.AddBuff(BuffID.Battle, 25200); //7 Hours
            player.AddBuff(ModContent.BuffType<Buffs.GreaterBattle>(), 25200); //7 Hours
            player.AddBuff(ModContent.BuffType<Buffs.SuperBattle>(), 25200); //7 Hours
            return true;
        }

        //Recipe is in Recipes.cs because it uses groups.
    }
}