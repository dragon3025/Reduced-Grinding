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
                void try_loot(int itemType, int denominator)
                {
                    if (denominator > 0)
                        npcLoot.Add(ItemDropRule.Common(itemType, denominator));
                }

                void try_loot_max_min(int itemType, int[] config)
                {
                    if (config.Max() > 0 && config.Min() >= 0)
                        npcLoot.Add(ItemDropRule.Common(itemType, 1, config.Min(), config.Max()));
                }

                void try_boss_loot(int itemType, int denominator)
                {
                    if (denominator > 0)
                        npcLoot.Add(new DropBasedOnExpertMode(ItemDropRule.Common(itemType, denominator), ItemDropRule.DropNothing()));
                }

                void try_boss_loot_eater_of_worlds(int itemType, int denominator)
                {
                    if (denominator > 0)
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.LegacyHack_IsBossAndNotExpert(), itemType, denominator));
                }

                void try_boss_loot_twins(int itemType, int denominator)
                {
                    IItemDropRule ruleMissingTwin = new LeadingConditionRule(new Conditions.MissingTwin());
                    ruleMissingTwin.OnSuccess(new DropBasedOnExpertMode(ItemDropRule.Common(itemType, denominator), ItemDropRule.DropNothing()));
                    if (denominator > 0)
                        npcLoot.Add(ruleMissingTwin);
                }

                void try_conditional_loot_max_min(int itemType, IItemDropRuleCondition condition, int[] config)
                {
                    if (config.Max() > 0 && config.Min() >= 0)
                    {
                        IItemDropRule conditionalRule = new LeadingConditionRule(condition);

                        IItemDropRule rule = ItemDropRule.Common(itemType, 1, config.Min(), config.Max());

                        conditionalRule.OnSuccess(rule);

                        npcLoot.Add(conditionalRule);
                    }
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

                //Boss Drops
                if (npc.type == NPCID.BrainofCthulhu)
                {
                    try_boss_loot(ItemID.BoneRattle, GetInstance<AEnemyDropConfig>().LootBoneRattleIncrease);
                    try_boss_loot(ItemID.BrainMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.DD2Betsy)
                {
                    try_boss_loot(ItemID.BossMaskBetsy, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.DukeFishron)
                {
                    try_boss_loot(ItemID.FishronWings, GetInstance<AEnemyDropConfig>().LootFishronWingsIncrease);
                    try_boss_loot(ItemID.TruffleWorm, GetInstance<AEnemyDropConfig>().LootFishronTruffleworm);
                    try_boss_loot(ItemID.DukeFishronMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc_is_any_types(NPCID.EaterofWorldsBody, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail))
                {
                    try_boss_loot_eater_of_worlds(ItemID.EatersBone, GetInstance<AEnemyDropConfig>().LootEatersBoneIncrease);
                    try_boss_loot_eater_of_worlds(ItemID.EaterMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.EyeofCthulhu)
                {
                    try_boss_loot(ItemID.Binoculars, GetInstance<AEnemyDropConfig>().LootBinocularsIncrease);
                    try_boss_loot(ItemID.EyeMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.Plantera)
                {
                    try_boss_loot(ItemID.TheAxe, GetInstance<AEnemyDropConfig>().LootTheAxeIncrease);
                    try_boss_loot(ItemID.Seedling, GetInstance<AEnemyDropConfig>().LootSeedlingIncrease);
                    try_boss_loot(ItemID.PlanteraMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.QueenBee)
                {
                    try_boss_loot(ItemID.HoneyedGoggles, GetInstance<AEnemyDropConfig>().LootHoneyedGogglesIncrease);
                    try_boss_loot(ItemID.Nectar, GetInstance<AEnemyDropConfig>().LootNectarIncrease);
                    try_boss_loot(ItemID.BeeMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.MoonLordCore)
                {
                    try_boss_loot(ItemID.BossMaskMoonlord, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                    try_boss_loot(ItemID.Meowmere, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    try_boss_loot(ItemID.Terrarian, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    try_boss_loot(ItemID.StarWrath, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    try_boss_loot(ItemID.SDMG, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    try_boss_loot(ItemID.FireworksLauncher, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    try_boss_loot(ItemID.LastPrism, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    try_boss_loot(ItemID.LunarFlareBook, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    try_boss_loot(ItemID.RainbowCrystalStaff, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    try_boss_loot(ItemID.MoonlordTurretStaff, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                }
                if (npc.type == NPCID.SkeletronHead)
                {
                    try_boss_loot(ItemID.BookofSkulls, GetInstance<AEnemyDropConfig>().LootBookofSkullsIncrease);
                    try_boss_loot(ItemID.BoneKey, GetInstance<AEnemyDropConfig>().LootSkeletronBoneKey);
                    try_boss_loot(ItemID.SkeletronMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.KingSlime)
                {
                    try_boss_loot(ItemID.KingSlimeMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.WallofFlesh)
                {
                    try_boss_loot(ItemID.FleshMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.TheDestroyer)
                {
                    try_boss_loot(ItemID.DestroyerMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism)
                {
                    try_boss_loot_twins(ItemID.TwinMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.SkeletronPrime)
                {
                    try_boss_loot(ItemID.SkeletronPrimeMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.Golem)
                {
                    try_boss_loot(ItemID.GolemMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                    try_boss_loot(ItemID.Picksaw, GetInstance<AEnemyDropConfig>().LootPicksawIncrease);
                }

                //Non-Boss Drops
                if (npc.type == NPCID.ChaosElemental)
                    try_loot(ItemID.RodofDiscord, GetInstance<AEnemyDropConfig>().LootRodofDiscordIncrease);
                if (npc.type == NPCID.TacticalSkeleton)
                    try_loot(ItemID.SWATHelmet, GetInstance<AEnemyDropConfig>().LootSWATHelmetIncrease);

                //Drops that don't happen in vanilla
                if (npc.type == NPCID.DukeFishron)
                    try_boss_loot(ItemID.TruffleWorm, GetInstance<AEnemyDropConfig>().LootFishronTruffleworm);
                if (npc.type == NPCID.DuneSplicerHead)
                {
                    try_loot_max_min(ItemID.DesertFossil, GetInstance<AEnemyDropConfig>().LootDesertFossilFromDuneSplicer);
                    try_conditional_loot_max_min(ItemID.SandBlock, new NoInfectionZone(), GetInstance<AEnemyDropConfig>().LootSandFromDuneSplicer);
                    try_conditional_loot_max_min(ItemID.EbonsandBlock, new ZoneCorruptnNoOtherInfection(), GetInstance<AEnemyDropConfig>().LootSandFromDuneSplicer);
                    try_conditional_loot_max_min(ItemID.CrimsandBlock, new ZoneCrimsonNoOtherInfection(), GetInstance<AEnemyDropConfig>().LootSandFromDuneSplicer);
                    try_conditional_loot_max_min(ItemID.PearlsandBlock, new ZoneHallow(), GetInstance<AEnemyDropConfig>().LootSandFromDuneSplicer);
                }
                if (npc.type == NPCID.TombCrawlerHead)
                {
                    try_loot_max_min(ItemID.DesertFossil, GetInstance<AEnemyDropConfig>().LootDesertFossilFromTombCrawler);
                    try_conditional_loot_max_min(ItemID.SandBlock, new NoInfectionZone(), GetInstance<AEnemyDropConfig>().LootSandFromTombCrawler);
                    try_conditional_loot_max_min(ItemID.EbonsandBlock, new ZoneCorruptnNoOtherInfection(), GetInstance<AEnemyDropConfig>().LootSandFromTombCrawler);
                    try_conditional_loot_max_min(ItemID.CrimsandBlock, new ZoneCrimsonNoOtherInfection(), GetInstance<AEnemyDropConfig>().LootSandFromTombCrawler);
                    try_conditional_loot_max_min(ItemID.PearlsandBlock, new ZoneHallow(), GetInstance<AEnemyDropConfig>().LootSandFromTombCrawler);
                }

                //Ankh Charm

                if (npc_is_any_types(104, 102, 269, 270, 271, 272))
                    try_loot(ItemID.AdhesiveBandage, GetInstance<AEnemyDropConfig>().LootAdhesiveBandageIncrease);

                if (npc_is_any_types(77, 273, 274, 275, 276))
                    try_loot(ItemID.ArmorPolish, GetInstance<AEnemyDropConfig>().LootArmorPolishIncrease);

                if (npc_is_any_types(141, 176, 42, 231, 232, 233, 234, 235))
                    try_loot(ItemID.Bezoar, GetInstance<AEnemyDropConfig>().LootBezoarIncrease);

                if (npc_is_any_types(81, 79, 183, 630))
                    try_loot(ItemID.Blindfold, GetInstance<AEnemyDropConfig>().LootBlindfoldIncrease);

                if (npc_is_any_types(78, 82, 75))
                    try_loot(ItemID.FastClock, GetInstance<AEnemyDropConfig>().LootFastClockBaseIncrease);

                if (npc_is_any_types(103, 75, 79, 630))
                    try_loot(ItemID.Megaphone, GetInstance<AEnemyDropConfig>().LootMegaphoneBaseIncrease);

                if (npc_is_any_types(34, 83, 84, 179, 289))
                    try_loot(ItemID.Nazar, GetInstance<AEnemyDropConfig>().LootNazarIncrease);

                if (npc_is_any_types(94, 182))
                    try_loot(ItemID.Vitamins, GetInstance<AEnemyDropConfig>().LootVitaminsIncrease);

                if (npc_is_any_types(93, 109, 80))
                    try_loot(ItemID.TrifoldMap, GetInstance<AEnemyDropConfig>().LootTrifoldMapIncrease);
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
