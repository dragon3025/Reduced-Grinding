using ReducedGrinding.Configuration;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Items.Material
{
    public class LunarTablet : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 14;
            Item.maxStack = Item.CommonMaxStack;
            Item.value = Item.sellPrice(0, 0, 25);
            Item.rare = ItemRarityID.Red;
        }
    }

    public class LunarTabletNPC : GlobalNPC
    {
        private static readonly int lunarSigil = GetInstance<EventAndBossConfig>().LunarSigil;

        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.CultistBoss && lunarSigil > 0;
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            //Cultist doesn't drop a boss bag
            npcLoot.Add(new CommonDropNotScalingWithLuck(ItemType<LunarTablet>(), 1, lunarSigil, lunarSigil));
        }
    }
}