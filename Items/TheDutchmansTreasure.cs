using Terraria;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
    // Basic code for a boss treasure bag
    public class TheDutchmansTreasure : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Dutchman's Treasure"); //Localize
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}\n'Don't worry, it's not made of plastic'"); //Localize
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.width = 32;
            Item.height = 28;
            Item.rare = ItemRarityID.LightRed;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.Common(ItemID.CoinGun, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.LuckyCoin, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.DiscountCard, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.PirateStaff, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.GoldRing, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.PirateMinecart, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.Cutlass, 5));

            itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, maximumDropped: 2));
        }
    }
}
