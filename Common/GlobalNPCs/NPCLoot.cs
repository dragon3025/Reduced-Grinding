using ReducedGrinding.Common.DropConditions;
using ReducedGrinding.Configuration;
using System;
using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalNPCs
{
    public class NPCLoot : GlobalNPC
    {
        private static readonly EnemyLootConfig lootConfig = GetInstance<EnemyLootConfig>();

        public override void ModifyNPCLoot(NPC npc, Terraria.ModLoader.NPCLoot npcLoot)
        {
            if (!AdjustBossLoot(npc, npcLoot))
            {
                return;
            }
            if (!AdjustMiscLoot(npc, npcLoot))
            {
                return;
            }
            if (!AdjustCavernLoot(npc, npcLoot))
            {
                return;
            }
            if (!AdjustDungeonLoot(npc, npcLoot))
            {
                return;
            }
            if (!AdjustSlimeStaffLoot(npc, npcLoot))
            {
                return;
            }
            if (!AdjustTownNPCLoot(npc, npcLoot))
            {
                return;
            }
            if (!AddLoot(npc, npcLoot))
            {
                return;
            }
        }

        private static bool AdjustBossLoot(NPC npc, Terraria.ModLoader.NPCLoot npcLoot)
        {
            if (npc.type == NPCID.Golem)
            {
                if (lootConfig.MaxBeetleHuskInNormal > 8)
                {
                    return false;
                }
                foreach (IItemDropRule rule in npcLoot.Get())
                {
                    if (rule is not ItemDropWithConditionRule drop)
                    {
                        continue;
                    }
                    if (drop.itemId == ItemID.BeetleHusk)
                    {
                        drop.amountDroppedMaximum = lootConfig.MaxBeetleHuskInNormal;
                        drop.amountDroppedMinimum = 4 + 14 * ((drop.amountDroppedMaximum - 8) / 15);
                        return false;
                    }
                }
                return false;
            }
            if (npc.type == NPCID.DukeFishron)
            {
                if (lootConfig.FishronWings >= 10)
                {
                    return false;
                }
                foreach (IItemDropRule rule in npcLoot.Get())
                {
                    if (rule is not ItemDropWithConditionRule drop)
                    {
                        continue;
                    }
                    if (drop.itemId == ItemID.FishronWings)
                    {
                        drop.chanceDenominator = (int)(lootConfig.FishronWings * 3f / 2f);
                        return false;
                    }
                }
                return false;
            }
            if (npc.type == NPCID.HallowBoss)
            {
                foreach (IItemDropRule rule in npcLoot.Get())
                {
                    if (rule is not LeadingConditionRule drop)
                    {
                        continue;
                    }
                    foreach (IItemDropRuleChainAttempt chainedRule in drop.ChainedRules)
                    {
                        if (chainedRule.RuleToChain is not CommonDrop commonDrop)
                        {
                            continue;
                        }
                        switch (commonDrop.itemId)
                        {
                            case ItemID.RainbowWings when lootConfig.EmpressWings < 10:
                                commonDrop.chanceDenominator = (int)(lootConfig.EmpressWings * 3f / 2f);
                                continue;
                            case ItemID.SparkleGuitar when lootConfig.StellarTune < 20:
                                commonDrop.chanceDenominator = (int)(lootConfig.StellarTune * 5f / 2f);
                                continue;
                            case ItemID.RainbowCursor when lootConfig.RainbowCursor < 20:
                                commonDrop.chanceDenominator = lootConfig.RainbowCursor;
                                continue;
                            case ItemID.HallowBossDye when lootConfig.PrismaticDye < 4:
                                commonDrop.chanceDenominator = lootConfig.PrismaticDye;
                                //In 1.4.5+, the amount dropped is already 3.
                                commonDrop.amountDroppedMinimum = commonDrop.amountDroppedMaximum = 3;
                                continue;
                        }
                    }
                }
                return false;
            }
            if (npc.type == NPCID.EyeofCthulhu)
            {
                if (lootConfig.Binoculars >= 30)
                {
                    return false;
                }
                foreach (IItemDropRule rule in npcLoot.Get())
                {
                    if (rule is ItemDropWithConditionRule drop && drop.itemId == ItemID.Binoculars)
                    {
                        drop.chanceDenominator = (int)(lootConfig.Binoculars * 4f / 3f);
                        return false;
                    }
                }
                return false;
            }
            if (npc.type == NPCID.PirateShip)
            {
                if (lootConfig.CoinGun >= 50)
                {
                    return false;
                }
                foreach (IItemDropRule rule in npcLoot.Get())
                {
                    if (rule is CommonDrop commonDrop && commonDrop.itemId == ItemID.CoinGun)
                    {
                        commonDrop.chanceDenominator = lootConfig.CoinGun;
                        return false;
                    }
                }
                return false;
            }
            return true;
        }

        private static bool AdjustMiscLoot(NPC npc, Terraria.ModLoader.NPCLoot npcLoot)
        {
            if (lootConfig.Lens < 3)
            {
                int[] demonEyes =
                [
                    133,
                    190,
                    191,
                    192,
                    193,
                    194,
                    2,
                    317,
                    318
                ];
                if (demonEyes.Contains(npc.type))
                {
                    foreach (IItemDropRule rule in npcLoot.Get())
                    {
                        if (rule is not CommonDrop drop)
                        {
                            continue;
                        }
                        foreach (IItemDropRuleChainAttempt chainedRule in drop.ChainedRules)
                        {
                            if (chainedRule.RuleToChain is CommonDrop drop2 && drop2.itemId == ItemID.Lens)
                            {
                                drop2.chanceDenominator = lootConfig.Lens;
                                break;
                            }
                        }
                    }
                    return false;
                }
            }
            if (lootConfig.RottenChunkAndVertebra < 3)
            {
                int[] rottenChunkNPCs =
                [
                    6,
                    7,
                    8,
                    9,
                    94,
                ];
                if (rottenChunkNPCs.Contains(npc.type))
                {
                    foreach (IItemDropRule rule in npcLoot.Get())
                    {
                        if (rule is CommonDrop drop && drop.itemId == ItemID.RottenChunk)
                        {
                            drop.chanceDenominator = lootConfig.RottenChunkAndVertebra;
                        }
                    }
                    return false;
                }
                int[] vertebraNPCs =
                [
                    181,
                    173,
                    239,
                    182,
                    240,
                ];
                if (vertebraNPCs.Contains(npc.type))
                {
                    foreach (IItemDropRule rule in npcLoot.Get())
                    {
                        if (rule is CommonDrop drop && drop.itemId == ItemID.Vertebrae)
                        {
                            drop.chanceDenominator = lootConfig.RottenChunkAndVertebra;
                        }
                    }
                    return false;
                }
            }
            if (npc.type == NPCID.FireImp)
            {
                foreach (IItemDropRule rule in npcLoot.Get())
                {
                    if (lootConfig.ObsidianRose < 20 && rule is CommonDrop drop && drop.itemId == ItemID.ObsidianRose)
                    {
                        drop.chanceDenominator = lootConfig.ObsidianRose;
                    }
                    if (lootConfig.PlumbersHat < 250 && rule is CommonDrop drop2 && drop2.itemId == ItemID.PlumbersHat)
                    {
                        drop2.chanceDenominator = lootConfig.PlumbersHat;
                    }
                }
                return false;
            }
            if (npc.type == NPCID.ChaosElemental)
            {
                if (lootConfig.RodofDiscord >= 400)
                {
                    return false;
                }
                foreach (IItemDropRule rule in npcLoot.Get())
                {
                    if (rule is not LeadingConditionRule drop)
                    {
                        continue;
                    }
                    if (drop.condition is Conditions.TenthAnniversaryIsUp tenthAnniversaryIsUp)
                    {
                        foreach (IItemDropRuleChainAttempt chainedRule in drop.ChainedRules)
                        {
                            if (chainedRule.RuleToChain is CommonDrop commonDrop && commonDrop.itemId == ItemID.RodofDiscord)
                            {
                                commonDrop.chanceDenominator = Math.Max(1, (int)(lootConfig.RodofDiscord / 4f));
                                break;
                            }
                        }
                    }
                    else if (drop.condition is not Conditions.TenthAnniversaryIsNotUp tenthAnniversaryIsNotUp)
                    {
                        continue;
                    }
                    foreach (IItemDropRuleChainAttempt chainedRule in drop.ChainedRules)
                    {
                        if (chainedRule.RuleToChain is not DropBasedOnExpertMode dropBasedOnExpertMode)
                        {
                            continue;
                        }
                        if (dropBasedOnExpertMode.ruleForExpertMode is CommonDrop expertDrop && expertDrop.itemId == ItemID.RodofDiscord)
                        {
                            expertDrop.chanceDenominator = lootConfig.RodofDiscord;
                        }
                        if (dropBasedOnExpertMode.ruleForNormalMode is CommonDrop normalDrop && normalDrop.itemId == ItemID.RodofDiscord)
                        {
                            normalDrop.chanceDenominator = (int)(lootConfig.RodofDiscord * 5f / 4f);
                        }
                    }
                }
                return false;
            }
            return true;
        }

        private static bool AdjustCavernLoot(NPC npc, Terraria.ModLoader.NPCLoot npcLoot)
        {
            if (npc.type == NPCID.ArmoredSkeleton)
            {
                if (lootConfig.BeamSword >= 150)
                {
                    return false;
                }
                foreach (IItemDropRule rule in npcLoot.Get())
                {
                    if (rule is CommonDrop drop && drop.itemId == ItemID.BeamSword)
                    {
                        drop.chanceDenominator = lootConfig.BeamSword;
                        break;
                    }
                }
                return false;
            }
            if (npc.type == NPCID.SkeletonArcher)
            {
                if (lootConfig.Marrow >= 200)
                {
                    return false;
                }
                foreach (IItemDropRule rule in npcLoot.Get())
                {
                    if (rule is CommonDrop drop && drop.itemId == ItemID.Marrow)
                    {
                        drop.chanceDenominator = lootConfig.Marrow;
                        break;
                    }
                }
            }
            if (npc.type == NPCID.Lihzahrd || npc.type == NPCID.LihzahrdCrawler || npc.type == NPCID.FlyingSnake)
            {
                if (lootConfig.LizardEgg >= 1000)
                {
                    return false;
                }
                foreach (IItemDropRule rule in npcLoot.Get())
                {
                    if (rule is CommonDrop drop && drop.itemId == ItemID.LizardEgg)
                    {
                        drop.chanceDenominator = lootConfig.LizardEgg;
                        break;
                    }
                }
            }
            return true;
        }

        private static bool AdjustDungeonLoot(NPC npc, Terraria.ModLoader.NPCLoot npcLoot)
        {
            if (npc.type == NPCID.SkeletonSniper)
            {
                if (lootConfig.RifleScopeAndSniperRifle >= 12)
                {
                    return false;
                }
                foreach (IItemDropRule rule in npcLoot.Get())
                {
                    if (rule is not DropBasedOnExpertMode drop)
                    {
                        continue;
                    }
                    if (drop.ruleForNormalMode is CommonDropWithRerolls drop2 && (drop2.itemId == ItemID.RifleScope || drop2.itemId == ItemID.SniperRifle))
                    {
                        drop2.chanceDenominator = lootConfig.RifleScopeAndSniperRifle;
                    }
                    if (drop.ruleForExpertMode is CommonDropWithRerolls drop3 && (drop3.itemId == ItemID.RifleScope || drop3.itemId == ItemID.RifleScope))
                    {
                        drop3.chanceDenominator = lootConfig.RifleScopeAndSniperRifle;
                    }
                }
                return false;
            }
            if (npc.type == NPCID.TacticalSkeleton)
            {
                if (lootConfig.SWATHelmetAndTacticalShotgun >= 12)
                {
                    return false;
                }
                foreach (IItemDropRule rule in npcLoot.Get())
                {
                    if (rule is not DropBasedOnExpertMode drop)
                    {
                        continue;
                    }
                    if (drop.ruleForNormalMode is CommonDropWithRerolls drop2 && (drop2.itemId == ItemID.SWATHelmet || drop2.itemId == ItemID.TacticalShotgun))
                    {
                        drop2.chanceDenominator = lootConfig.SWATHelmetAndTacticalShotgun;
                    }
                    if (drop.ruleForExpertMode is CommonDropWithRerolls drop3 && (drop3.itemId == ItemID.SWATHelmet || drop3.itemId == ItemID.TacticalShotgun))
                    {
                        drop3.chanceDenominator = lootConfig.SWATHelmetAndTacticalShotgun;
                    }
                }
                return false;
            }
            if (npc.type == NPCID.SkeletonCommando)
            {
                if (lootConfig.RocketLauncher >= 18)
                {
                    return false;
                }
                foreach (IItemDropRule rule in npcLoot.Get())
                {
                    if (rule is not DropBasedOnExpertMode drop)
                    {
                        continue;
                    }
                    if (drop.ruleForNormalMode is CommonDropWithRerolls drop2 && drop2.itemId == ItemID.RocketLauncher)
                    {
                        drop2.chanceDenominator = lootConfig.RocketLauncher;
                    }
                    if (drop.ruleForExpertMode is CommonDropWithRerolls drop3 && drop3.itemId == ItemID.RocketLauncher)
                    {
                        drop3.chanceDenominator = lootConfig.RocketLauncher;
                    }
                }
                return false;
            }
            if (npc.type == NPCID.Paladin)
            {
                foreach (IItemDropRule rule in npcLoot.Get())
                {
                    if (rule is not DropBasedOnExpertMode drop)
                    {
                        continue;
                    }
                    if (lootConfig.PaladinsHammer < 15)
                    {
                        if (drop.ruleForNormalMode is CommonDropWithRerolls drop2 && drop2.itemId == ItemID.PaladinsHammer)
                        {
                            drop2.chanceDenominator = lootConfig.PaladinsHammer;
                        }
                        if (drop.ruleForExpertMode is CommonDropWithRerolls drop3 && drop3.itemId == ItemID.PaladinsHammer)
                        {
                            drop3.chanceDenominator = lootConfig.PaladinsHammer;
                        }
                    }
                    if (lootConfig.PaladinsShield < 10)
                    {
                        if (drop.ruleForNormalMode is CommonDropWithRerolls drop2 && drop2.itemId == ItemID.PaladinsShield)
                        {
                            drop2.chanceDenominator = lootConfig.PaladinsShield;
                        }
                        if (drop.ruleForExpertMode is CommonDropWithRerolls drop3 && drop3.itemId == ItemID.PaladinsShield)
                        {
                            drop3.chanceDenominator = lootConfig.PaladinsShield;
                        }
                    }
                }
                return false;
            }
            return true;
        }

        private static bool AdjustSlimeStaffLoot(NPC npc, Terraria.ModLoader.NPCLoot npcLoot)
        {
            if (lootConfig.SlimeStaffFromPinky >= 70)
            {
                return true;
            }
            int[] otherSlimeStaffSlimes =
                [
                    -6,
                    -7,
                    -8,
                    -9,
                    1,
                    16,
                    138,
                    141,
                    147,
                    184,
                    187,
                    204,
                    302,
                    333,
                    334,
                    335,
                    336,
                    433,
                    535,
                    658,
                    659,
                    660
                ];
            float pinkyToOtherSlimeRate;
            if (npc.netID == NPCID.Pinky)
            {
                pinkyToOtherSlimeRate = 1f;
            }
            else if (npc.type == NPCID.SandSlime)
            {
                pinkyToOtherSlimeRate = 5600f / 70f;
            }
            else if (otherSlimeStaffSlimes.Contains(npc.type))
            {
                pinkyToOtherSlimeRate = 7000f / 70f;
            }
            else
            {
                return true;
            }
            foreach (IItemDropRule rule in npcLoot.Get())
            {
                if (rule is not DropBasedOnExpertMode drop)
                {
                    continue;
                }
                if (drop.ruleForExpertMode is CommonDrop expertDrop && expertDrop.itemId == ItemID.SlimeStaff)
                {
                    expertDrop.chanceDenominator = (int)(lootConfig.SlimeStaffFromPinky * pinkyToOtherSlimeRate);
                }
                if (drop.ruleForNormalMode is CommonDrop normalDrop && normalDrop.itemId == ItemID.SlimeStaff)
                {
                    normalDrop.chanceDenominator = (int)(lootConfig.SlimeStaffFromPinky * pinkyToOtherSlimeRate * 10f / 7f);
                }
            }
            return false;
        }

        private static bool AdjustTownNPCLoot(NPC npc, Terraria.ModLoader.NPCLoot npcLoot)
        {
            if (lootConfig.TownNPCWeapons >= 8)
            {
                return true;
            }
            if (npc.type == NPCID.Painter)
            {
                foreach (IItemDropRule rule in npcLoot.Get())
                {
                    int denonminator = (int)(lootConfig.TownNPCWeapons / 8f * 10f);
                    if (rule is CommonDrop drop2 && drop2.itemId == ItemID.PainterPaintballGun)
                    {
                        drop2.chanceDenominator = denonminator;
                    }
                }
                return false;
            }
            if (npc.type == NPCID.PartyGirl)
            {
                foreach (IItemDropRule rule in npcLoot.Get())
                {
                    int denonminator = Math.Max(1, (int)(lootConfig.TownNPCWeapons / 8f * 4f));
                    if (rule is CommonDrop drop && drop.itemId == ItemID.PartyGirlGrenade)
                    {
                        drop.chanceDenominator = denonminator;
                    }
                }
                return false;
            }
            int[] otherTownNPCsWithLoot =
            [
                NPCID.DyeTrader,
                    NPCID.DD2Bartender,
                    NPCID.Stylist,
                    NPCID.Mechanic,
                    NPCID.PartyGirl,
                    NPCID.TaxCollector,
                    NPCID.Princess
            ];
            if (otherTownNPCsWithLoot.Contains(npc.type))
            {
                int[] otherTownNPCLoot =
                [
                    ItemID.DyeTradersScimitar,
                        ItemID.AleThrowingGlove,
                        ItemID.StylistKilLaKillScissorsIWish,
                        ItemID.CombatWrench,
                        ItemID.PartyGirlGrenade,
                        ItemID.TaxCollectorsStickOfDoom,
                        ItemID.PrincessWeapon
                ];
                foreach (IItemDropRule rule in npcLoot.Get())
                {
                    if (rule is CommonDrop drop && otherTownNPCLoot.Contains(drop.itemId))
                    {
                        drop.chanceDenominator = lootConfig.TownNPCWeapons;
                        break;
                    }
                }
                return false;
            }
            return true;
        }

        private static bool AddLoot(NPC npc, Terraria.ModLoader.NPCLoot npcLoot)
        {
            if (npc.type == NPCID.KingSlime)
            {
                //In 1.4.5+ Slime King drops Slime Staff, so this will need changed into a drop rate modification.
                if (lootConfig.SlimeStaffFromKingSlime < 30)
                {
                    npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.SlimeStaff, lootConfig.SlimeStaffFromKingSlime), new DropNothing()));
                }
                else
                {
                    npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.SlimeStaff, 30), new DropNothing()));
                }
                return false;
            }
            return true;
        }

        public override void ModifyGlobalLoot(GlobalLoot globalLoot)
        {
            foreach (IItemDropRule rule in globalLoot.Get())
            {
                if (rule is not ItemDropWithConditionRule drop)
                {
                    continue;
                }
                AdjustGlobalHolidayLoot(drop);
                AdjustGlobalMiscLoot(drop);
            }
        }

        private static bool AdjustGlobalMiscLoot(ItemDropWithConditionRule drop)
        {
            int[] biomeKeys =
            [
                1533,
                1534,
                1535,
                1536,
                1537,
                4714
            ];
            if (biomeKeys.Contains(drop.itemId))
            {
                if (lootConfig.GuaranteedBiomeKeyBehavior == GuaranteedBiomeKeyBehaviorEnums.GiveMultipleTimesDisableVanilla)
                {
                    drop.chanceNumerator = 0;
                }
                else if (lootConfig.BiomeKey < 2500)
                {
                    drop.chanceDenominator = lootConfig.BiomeKey;
                }
                return false;
            }
            if (drop.itemId == ItemID.SoulofLight || drop.itemId == ItemID.SoulofNight)
            {
                if (lootConfig.SoulOfLightAndNight < 5)
                {
                    drop.chanceDenominator = lootConfig.SoulOfLightAndNight;
                }
                return false;
            }
            return true;
        }

        private static bool AdjustGlobalHolidayLoot(ItemDropWithConditionRule drop)
        {
            if (drop.itemId == ItemID.BloodyMachete) //Bladded Glove is an On Failed Roll, so Bloody Machete uses the condition for both items.
            {
                drop.condition = new Conditions.HalloweenGoodieBagDrop();
                return false;
            }
            if (drop.itemId == ItemID.GoodieBag)
            {
                if (lootConfig.GoodieBag < 18)
                {
                    drop.chanceDenominator = lootConfig.GoodieBag;
                }
                if (lootConfig.GoodieBagMultiplierAfterPlantera > 1)
                {
                    int amount = lootConfig.GoodieBagMultiplierAfterPlantera - 1;
                    drop.OnSuccess(new ItemDropWithConditionRule(ItemID.GoodieBag, 1, amount, amount, new PostHalloweenPlantera()));
                }
                return false;
            }
            if (drop.itemId == ItemID.Present)
            {
                if (lootConfig.Present < 13)
                {
                    drop.chanceDenominator = lootConfig.Present;
                }
                if (lootConfig.PresentMultiplierAfterPlantera > 1)
                {
                    int amount = lootConfig.PresentMultiplierAfterPlantera - 1;
                    drop.OnSuccess(new ItemDropWithConditionRule(ItemID.Present, 1, amount, amount, new PostXmasPlantera()));
                }
                return false;
            }
            return true;
        }
    }
}
