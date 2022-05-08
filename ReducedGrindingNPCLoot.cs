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

                int itemType;
                int normalDenominator;
                int expertDenominator;

                if (npc.type == NPCID.ChaosElemental)
                {
                    itemType = ItemID.RodofDiscord;
                    normalDenominator = GetInstance<AEnemyDropConfig>().LootRodofDiscordIncrease[0];
                    expertDenominator = Math.Min(normalDenominator, GetInstance<AEnemyDropConfig>().LootRodofDiscordIncrease[1]);

                    if (expertDenominator > 0)
                    {
                        TestDropRule testDropRule = new TestDropRule();
                        IItemDropRule conditionalRule = new LeadingConditionRule(testDropRule);

                        IItemDropRule rule = ItemDropRule.NormalvsExpert(itemType, normalDenominator, expertDenominator);

                        conditionalRule.OnSuccess(rule); //TODO Temporary, wont actually have a custom condition.

                        npcLoot.Add(conditionalRule);
                    }
                }
                if (npc.type == NPCID.TacticalSkeleton)
                {
                    itemType = ItemID.SWATHelmet;
                    normalDenominator = GetInstance<AEnemyDropConfig>().LootSWATHelmetIncrease[0];
                    expertDenominator = Math.Min(normalDenominator, GetInstance<AEnemyDropConfig>().LootSWATHelmetIncrease[1]);

                    if (expertDenominator > 0)
                        npcLoot.Add(ItemDropRule.NormalvsExpert(itemType, normalDenominator, expertDenominator));
                }
            }
        }
    }
}
