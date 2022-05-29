using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using ReducedGrinding.Global;

namespace ReducedGrinding.Items.BuffPotions
{
    public class Multi_Bobber_Potion : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Multi-Bobber Potion");
            Tooltip.SetDefault("Use 10 Bobbers at a time.");
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
            Item.value = Terraria.Item.buyPrice(0, 0, 2);
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.buffType = ModContent.BuffType<Buffs.Multi_Bobber>();
            Item.buffTime = 10800;
        }

        //Recipe uses groups so I added it in Recipes.
    }
}