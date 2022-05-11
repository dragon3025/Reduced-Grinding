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
                void non_conditional_loot(int itemType, int[] denominators)
                {
                    int expertDenominator;

                    expertDenominator = Math.Min(denominators[0], denominators[1]);
                    if (expertDenominator > 0)
                        npcLoot.Add(ItemDropRule.NormalvsExpert(itemType, denominators[0], expertDenominator));
                }

                void normal_boss_loot(int itemType, int[] denominators)
                {
                    int expertDenominator;

                    expertDenominator = Math.Min(denominators[0], denominators[1]);
                    if (expertDenominator > 0)
                        npcLoot.Add(new DropBasedOnExpertMode(ItemDropRule.Common(itemType, denominators[0]), ItemDropRule.DropNothing()));
                }

                bool npc_is_any_types(params int[] types)
                {
                    bool matches = false;
                    for (int i = 0; i < types.Length; i++)
                    {
                        if (npc.type == types[i])
                        {
                            matches = true;
                            break;
                        }
                    }
                    return matches;
                }

                //CONDITIONAL RULE EXAMPLE
                /*if (npc.type == NPCID.BlueSlime)
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

                //Boss Drops
                if (npc.type == NPCID.BrainofCthulhu)
                {
                    normal_boss_loot(ItemID.BoneRattle, GetInstance<AEnemyDropConfig>().LootBoneRattleIncrease);
                    normal_boss_loot(ItemID.BrainMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }

                if (npc.type == NPCID.ChaosElemental)
                    non_conditional_loot(ItemID.RodofDiscord, GetInstance<AEnemyDropConfig>().LootRodofDiscordIncrease);
                if (npc.type == NPCID.TacticalSkeleton)
                    non_conditional_loot(ItemID.SWATHelmet, GetInstance<AEnemyDropConfig>().LootSWATHelmetIncrease);

                /*if (npc_is_any_types(94, 182))
                    add_non_conditional_loot(ItemID.Vitamins, GetInstance<AEnemyDropConfig>().LootVitaminsIncrease);
                RegisterToMultipleNPCs(ItemDropRule.StatusImmunityItem(3781, 100), 480);
                RegisterToMultipleNPCs(ItemDropRule.StatusImmunityItem(885, 100), 104, 102, 269, 270, 271, 272);
                RegisterToMultipleNPCs(ItemDropRule.StatusImmunityItem(886, 100), 77, 273, 274, 275, 276);
                RegisterToMultipleNPCs(ItemDropRule.StatusImmunityItem(887, 100), 141, 176, 42, 231, 232, 233, 234, 235);
                RegisterToMultipleNPCs(ItemDropRule.StatusImmunityItem(888, 100), 81, 79, 183, 630);
                RegisterToMultipleNPCs(ItemDropRule.StatusImmunityItem(889, 100), 78, 82, 75);
                RegisterToMultipleNPCs(ItemDropRule.StatusImmunityItem(890, 100), 103, 75, 79, 630);
                RegisterToMultipleNPCs(ItemDropRule.StatusImmunityItem(891, 100), 34, 83, 84, 179, 289);
                RegisterToMultipleNPCs(ItemDropRule.StatusImmunityItem(892, 100), 94, 182);
                RegisterToMultipleNPCs(ItemDropRule.StatusImmunityItem(893, 100), 93, 109, 80);*/

            }
        }

        public override void ModifyGlobalLoot(GlobalLoot globalLoot)
        {
            int biomeKeyIncrease = GetInstance<AEnemyDropConfig>().LootBiomeKeyIncrease;
            if (biomeKeyIncrease > 0)
            {
                globalLoot.Add(new ItemDropWithConditionRule(1533, biomeKeyIncrease, 1, 1, new Conditions.JungleKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1534, biomeKeyIncrease, 1, 1, new Conditions.CorruptKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1535, biomeKeyIncrease, 1, 1, new Conditions.CrimsonKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1536, biomeKeyIncrease, 1, 1, new Conditions.HallowKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1537, biomeKeyIncrease, 1, 1, new Conditions.FrozenKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(4714, biomeKeyIncrease, 1, 1, new Conditions.DesertKeyCondition()));
            }
        }
    }
}
