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
                void non_conditional_loot(int itemType, int denominator)
                {
                    if (denominator > 0)
                        npcLoot.Add(ItemDropRule.Common(itemType, denominator));
                }

                void normal_boss_loot(int itemType, int denominator)
                {
                    if (denominator > 0)
                        npcLoot.Add(new DropBasedOnExpertMode(ItemDropRule.Common(itemType, denominator), ItemDropRule.DropNothing()));
                }

                void normal_boss_loot_eater_of_worlds(int itemType, int denominator)
                {
                    if (denominator > 0)
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.LegacyHack_IsBossAndNotExpert(), itemType, denominator));
                }

                void normal_boss_loot_twins(int itemType, int denominator)
                {
                    IItemDropRule ruleMissingTwin = new LeadingConditionRule(new Conditions.MissingTwin());
                    ruleMissingTwin.OnSuccess(new DropBasedOnExpertMode(ItemDropRule.Common(itemType, denominator), ItemDropRule.DropNothing()));
                    if (denominator > 0)
                        npcLoot.Add(ruleMissingTwin);
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
                if (npc.type == NPCID.DD2Betsy)
                {
                    normal_boss_loot(ItemID.BossMaskBetsy, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.DukeFishron)
                {
                    normal_boss_loot(ItemID.FishronWings, GetInstance<AEnemyDropConfig>().LootFishronWingsIncrease);
                    normal_boss_loot(ItemID.TruffleWorm, GetInstance<AEnemyDropConfig>().LootFishronTruffleworm);
                    normal_boss_loot(ItemID.DukeFishronMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc_is_any_types(NPCID.EaterofWorldsBody, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail))
                {
                    normal_boss_loot_eater_of_worlds(ItemID.EatersBone, GetInstance<AEnemyDropConfig>().LootEatersBoneIncrease);
                    normal_boss_loot_eater_of_worlds(ItemID.EaterMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.EyeofCthulhu)
                {
                    normal_boss_loot(ItemID.Binoculars, GetInstance<AEnemyDropConfig>().LootBinocularsIncrease);
                    normal_boss_loot(ItemID.EyeMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.Plantera)
                {
                    normal_boss_loot(ItemID.TheAxe, GetInstance<AEnemyDropConfig>().LootTheAxeIncrease);
                    normal_boss_loot(ItemID.Seedling, GetInstance<AEnemyDropConfig>().LootSeedlingIncrease);
                    normal_boss_loot(ItemID.PlanteraMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.QueenBee)
                {
                    normal_boss_loot(ItemID.HoneyedGoggles, GetInstance<AEnemyDropConfig>().LootHoneyedGogglesIncrease);
                    normal_boss_loot(ItemID.Nectar, GetInstance<AEnemyDropConfig>().LootNectarIncrease);
                    normal_boss_loot(ItemID.BeeMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.MoonLordCore)
                {
                    normal_boss_loot(ItemID.BossMaskMoonlord, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                    normal_boss_loot(ItemID.Meowmere, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    normal_boss_loot(ItemID.Terrarian, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    normal_boss_loot(ItemID.StarWrath, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    normal_boss_loot(ItemID.SDMG, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    normal_boss_loot(ItemID.FireworksLauncher, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    normal_boss_loot(ItemID.LastPrism, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    normal_boss_loot(ItemID.LunarFlareBook, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    normal_boss_loot(ItemID.RainbowCrystalStaff, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    normal_boss_loot(ItemID.MoonlordTurretStaff, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                }
                if (npc.type == NPCID.SkeletronHead)
                {
                    normal_boss_loot(ItemID.BookofSkulls, GetInstance<AEnemyDropConfig>().LootBookofSkullsIncrease);
                    normal_boss_loot(ItemID.BoneKey, GetInstance<AEnemyDropConfig>().LootSkeletronBoneKey);
                    normal_boss_loot(ItemID.SkeletronMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.KingSlime)
                {
                    normal_boss_loot(ItemID.KingSlimeMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.WallofFlesh)
                {
                    normal_boss_loot(ItemID.FleshMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.TheDestroyer)
                {
                    normal_boss_loot(ItemID.DestroyerMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism)
                {
                    normal_boss_loot_twins(ItemID.TwinMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.SkeletronPrime)
                {
                    normal_boss_loot(ItemID.SkeletronPrimeMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.Golem)
                {
                    normal_boss_loot(ItemID.GolemMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                    normal_boss_loot(ItemID.Picksaw, GetInstance<AEnemyDropConfig>().LootPicksawIncrease);
                }

                //Non-Boss Drops
                if (npc.type == NPCID.ChaosElemental)
                    non_conditional_loot(ItemID.RodofDiscord, GetInstance<AEnemyDropConfig>().LootRodofDiscordIncrease);
                if (npc.type == NPCID.TacticalSkeleton)
                    non_conditional_loot(ItemID.SWATHelmet, GetInstance<AEnemyDropConfig>().LootSWATHelmetIncrease);

                if (npc_is_any_types(94, 182))
                    non_conditional_loot(ItemID.Vitamins, GetInstance<AEnemyDropConfig>().LootVitaminsIncrease);
                if (npc_is_any_types(104, 102, 269, 270, 271, 272))
                    non_conditional_loot(ItemID.AdhesiveBandage, GetInstance<AEnemyDropConfig>().LootAdhesiveBandageIncrease);
                if (npc_is_any_types(77, 273, 274, 275, 276))
                    non_conditional_loot(ItemID.ArmorPolish, GetInstance<AEnemyDropConfig>().LootArmorPolishIncrease);
                /*
                RegisterToMultipleNPCs(ItemDropRule.StatusImmunityItem(887, 100), 141, 176, 42, 231, 232, 233, 234, 235);
                RegisterToMultipleNPCs(ItemDropRule.StatusImmunityItem(888, 100), 81, 79, 183, 630);
                RegisterToMultipleNPCs(ItemDropRule.StatusImmunityItem(889, 100), 78, 82, 75);
                RegisterToMultipleNPCs(ItemDropRule.StatusImmunityItem(890, 100), 103, 75, 79, 630);
                RegisterToMultipleNPCs(ItemDropRule.StatusImmunityItem(891, 100), 34, 83, 84, 179, 289);
                RegisterToMultipleNPCs(ItemDropRule.StatusImmunityItem(893, 100), 93, 109, 80);
                */

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
