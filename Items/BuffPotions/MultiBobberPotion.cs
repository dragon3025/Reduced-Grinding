using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ReducedGrinding.Global;

namespace ReducedGrinding.Items.BuffPotions
{
    public class MultiBobberPotion : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Multi-Bobber Potion");
            Tooltip.SetDefault("Use multiple bobbers at a time");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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
            Item.value = Terraria.Item.buyPrice(0, 0, 2);
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.buffType = ModContent.BuffType<Buffs.MultiBobber>();
            Item.buffTime = 10800; //3 hours
        }

        //Recipe uses groups so I added it in Recipes.
    }
}