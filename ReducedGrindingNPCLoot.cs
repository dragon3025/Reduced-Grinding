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
using System.Collections.Generic;
using System.Linq;
using Terraria.ID;


namespace ReducedGrinding.Common.GlobalNPCs
{
    public class ReducedGrindingNPCLoot : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.type != NPCID.Slimer && npc.value > 0f)
                if (npc.type == NPCID.ChaosElemental)
                {
                    TestDropRule testDropRule = new TestDropRule();
                    IItemDropRule conditionalRule = new LeadingConditionRule(testDropRule);

                    int itemType = ItemID.RodofDiscord;
                    int normalDenominator = GetInstance<AEnemyDropConfig>().LootRodofDiscordIncrease[0];
                    int expertDenominator = GetInstance<AEnemyDropConfig>().LootRodofDiscordIncrease[1];

                    IItemDropRule rule = ItemDropRule.NormalvsExpert(itemType, normalDenominator, expertDenominator);

                    conditionalRule.OnSuccess(rule); //TODO Temporary, wont actually have a custom condition.

                    npcLoot.Add(conditionalRule);
                }
            if (npc.type == NPCID.TacticalSkeleton)
            {
                int itemType = ItemID.SWATHelmet;
                int normalDenominator = GetInstance<AEnemyDropConfig>().LootSWATHelmetIncrease[0];
                int expertDenominator = GetInstance<AEnemyDropConfig>().LootSWATHelmetIncrease[1];

                npcLoot.Add(ItemDropRule.NormalvsExpert(itemType, normalDenominator, expertDenominator));
            }
        }
    }
}
