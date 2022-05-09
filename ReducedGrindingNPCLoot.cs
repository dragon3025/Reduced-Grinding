using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ReducedGrinding.Common.ItemDropRules.Conditions;
using ReducedGrinding;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;

namespace ReducedGrinding.Common.GlobalNPCs
{
    public class ReducedGrindingNPCLoot : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.type != NPCID.Slimer && npc.value > 0f)
            {
                int normalDenominator;
                int expertDenominator;
                void add_non_conditional_loot(int itemType, int[] denominators)
                {
                    normalDenominator = denominators[0];
                    expertDenominator = Math.Min(normalDenominator, denominators[1]);
                    if (expertDenominator > 0)
                        npcLoot.Add(ItemDropRule.NormalvsExpert(itemType, normalDenominator, expertDenominator));
                }
                /*//CONDITIONAL RULE EXAMPLE
                if (npc.type == NPCID.BlueSlime)
                {
                    itemType = ItemID.RodofDiscord;
                    normalDenominator = GetInstance<AEnemyDropConfig>().LootRodofDiscordIncrease[0];
                    expertDenominator = Math.Min(normalDenominator, GetInstance<AEnemyDropConfig>().LootRodofDiscordIncrease[1]);

                    if (expertDenominator > 0)
                    {
                        TestDropRule testDropRule = new TestDropRule();
                        IItemDropRule conditionalRule = new LeadingConditionRule(testDropRule);

                        IItemDropRule rule = ItemDropRule.NormalvsExpert(itemType, normalDenominator, expertDenominator);

                        conditionalRule.OnSuccess(rule);

                        npcLoot.Add(conditionalRule);
                    }
                }*/
                if (npc.type == NPCID.ChaosElemental)
                    add_non_conditional_loot(ItemID.RodofDiscord, GetInstance<AEnemyDropConfig>().LootRodofDiscordIncrease);
                if (npc.type == NPCID.TacticalSkeleton)
                    add_non_conditional_loot(ItemID.SWATHelmet, GetInstance<AEnemyDropConfig>().LootSWATHelmetIncrease);
            }
        }
    }
}
