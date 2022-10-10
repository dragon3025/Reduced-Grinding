using ReducedGrinding.Global;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items.BuffPotions
{
    public class MultiBobberPotion : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Multi-Bobber Potion");
            Tooltip.SetDefault("Adds more bobbers when fishing");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
            Item.maxStack = 300;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.value = Terraria.Item.sellPrice(0, 0, 2);
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.buffType = ModContent.BuffType<Buffs.MultiBobber>();
            Item.buffTime = 10800; //3 minutes
        }

        //Recipe uses groups so I added it in Recipes.
    }
}