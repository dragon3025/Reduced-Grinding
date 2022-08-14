using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ReducedGrinding.Global;

namespace ReducedGrinding.Items.BuffPotions
{
    public class SuperMultiBobberPotion : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Super Multi-Bobber Potion");
            Tooltip.SetDefault("Adds a lot of bobbers when fishing");
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
            Item.value = Terraria.Item.sellPrice(0, 0, 68);
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.buffType = ModContent.BuffType<Buffs.SuperMultiBobber>();
            Item.buffTime = 10800; //3 hours
        }

        public override bool? UseItem(Player player)
        {
            player.ClearBuff(ModContent.BuffType<Buffs.MultiBobber>());
            player.ClearBuff(ModContent.BuffType<Buffs.GreaterMultiBobber>());
            return base.UseItem(player);
        }

        //Recipe uses groups so I added it in Recipes.
    }
}