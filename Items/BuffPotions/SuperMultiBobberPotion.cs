using ReducedGrinding.Configuration;
using ReducedGrinding.Global;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Items.BuffPotions
{
    public class SuperMultiBobberPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.height = 30;
            Item.maxStack = 9999;
            Item.rare = ReducedGrindingSave.usingCalamity ? ItemRarityID.Red : ItemRarityID.Yellow;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.value = Terraria.Item.sellPrice(0, 0, 52, 40);
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.buffType = BuffType<Buffs.SuperMultiBobber>();
            Item.buffTime = 10800; //3 minutes
        }

        public override bool? UseItem(Player player)
        {
            player.ClearBuff(BuffType<Buffs.MultiBobber>());
            player.ClearBuff(BuffType<Buffs.GreaterMultiBobber>());
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            if (GetInstance<CFishingConfig>().BobberPotions.SuperMultiBobberPotionBonus > 0)
            {
                Recipe recipe = Recipe.Create(Type);
                if (GetInstance<CFishingConfig>().BobberPotions.GreaterMultiBobberPotionBonus > 0)
                {
                    recipe.AddIngredient(ItemType<GreaterMultiBobberPotion>());
                }
                else
                {
                    if (GetInstance<CFishingConfig>().BobberPotions.MultiBobberPotionBonus > 0)
                    {
                        recipe.AddIngredient(ItemType<MultiBobberPotion>());
                    }
                    else
                    {
                        recipe.AddIngredient(ItemID.BottledWater);
                        recipe.AddIngredient(ItemID.Waterleaf);
                        recipe.AddIngredient(ItemID.MasterBait);
                    }
                    recipe.AddIngredient(ItemID.GelBalloon);
                    if (ReducedGrindingSave.usingCalamity)
                    {
                        recipe.AddIngredient(ItemID.VialofVenom);
                    }
                }
                recipe.AddIngredient(ItemID.Ectoplasm);
                if (ReducedGrindingSave.usingCalamity)
                {
                    recipe.AddIngredient(ItemID.LunarOre);
                }
                recipe.AddTile(TileID.Bottles);
                recipe.Register();
            }
        }
    }
}