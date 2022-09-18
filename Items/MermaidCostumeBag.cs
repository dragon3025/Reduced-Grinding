using Terraria;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
    public class MermaidCostumeBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mermaid Costume Bag"); //Localize
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}"); //Localize
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.Orange;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.Common(ItemID.SeashellHairpin));
            itemLoot.Add(ItemDropRule.Common(ItemID.MermaidAdornment));
            itemLoot.Add(ItemDropRule.Common(ItemID.MermaidTail));
        }
    }
}
