using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using ReducedGrinding.Common.ItemDropRules.Conditions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReducedGrinding;
using System.IO;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalNPCs
{
    public class ReducedGrindingNPCLoot : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if ((npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly) && npc.type != NPCID.Slimer && npc.value > 0f)
                if (npc.type == NPCID.ChaosElemental)
                {
                    TestDropRule testDropRule = new TestDropRule();
                    IItemDropRule conditionalRule = new LeadingConditionRule(testDropRule);

                    int itemType = ItemID.RodofDiscord;

                    IItemDropRule rule = ItemDropRule.Common(itemType, 10); //Temporary. These now use fractions; I'm not sure how I want to handle this.
                    //IItemDropRule rule = ItemDropRule.Common(itemType, GetInstance<AEnemyDropConfig>().LootRodofDiscordIncrease);

                    conditionalRule.OnSuccess(rule);

                    npcLoot.Add(conditionalRule);
                }
        }
    }
}
