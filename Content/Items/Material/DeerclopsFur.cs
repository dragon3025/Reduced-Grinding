using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Items.Material
{
    public class DeerclopsFur : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 26;
            Item.maxStack = Item.CommonMaxStack;
            Item.value = Item.sellPrice(0, 0, 5);
            Item.rare = ItemRarityID.Green;
        }
    }

    public class DeerclopsFurNPC : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.Deerclops && Helpers.MaterialIsNeeded(ItemType<DeerclopsFur>());
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            CommonDrop ruleForNormalMode = new(ItemType<DeerclopsFur>(), 1, 10, 20);
            DropNothing ruleForExpertMode = new();
            npcLoot.Add(new DropBasedOnExpertMode(ruleForNormalMode, ruleForExpertMode));
        }
    }

    public class DeerclopsFurItem : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == ItemID.DeerclopsBossBag && Helpers.MaterialIsNeeded(ItemType<DeerclopsFur>());
        }

        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            itemLoot.Add(new CommonDrop(ItemType<DeerclopsFur>(), 1, 15, 25));
        }
    }
}