using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Items.Material
{
    public class FishronScale : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 20;
            Item.maxStack = Item.CommonMaxStack;
            Item.value = Item.sellPrice(0, 0, 50);
            Item.rare = ItemRarityID.Yellow;
        }
    }

    public class FishronScaleNPC : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.DukeFishron && Helpers.MaterialIsNeeded(ItemType<FishronScale>());
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            CommonDrop ruleForNormalMode = new(ItemType<FishronScale>(), 1, 10, 20);
            DropNothing ruleForExpertMode = new();
            npcLoot.Add(new DropBasedOnExpertMode(ruleForNormalMode, ruleForExpertMode));
        }
    }

    public class FishronScaleItem : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == ItemID.FishronBossBag && Helpers.MaterialIsNeeded(ItemType<FishronScale>());
        }

        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            itemLoot.Add(new CommonDrop(ItemType<FishronScale>(), 1, 15, 25));
        }
    }
}