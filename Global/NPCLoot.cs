using System;
using System.Linq;
using ReducedGrinding.Configuration;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

//Note netID is sometimes used when involving NPCs with negative IDs (variant NPCs), otherwise it gives duplicate loot drops to multiple NPCs. Not always does this happen though.
namespace ReducedGrinding.Global
{
    public class NPCLoot : GlobalNPC
    {

        readonly static AEnemyLootConfig lootConfig = GetInstance<AEnemyLootConfig>();

        public override void ModifyNPCLoot(NPC npc, Terraria.ModLoader.NPCLoot npcLoot)
        {
            #region Boss Drops
            if (npc.type == NPCID.DukeFishron && lootConfig.BossLoot.EmpressAndFishronWings > 0)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is ItemDropWithConditionRule drop && drop.itemId == ItemID.FishronWings)
                    {
                        drop.chanceDenominator = (int)(lootConfig.BossLoot.EmpressAndFishronWings * 3f / 2f);
                    }
                }
            }
            if (npc.type == NPCID.HallowBoss)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is LeadingConditionRule drop)
                    {
                        foreach (var chainedRule in drop.ChainedRules)
                        {
                            if (chainedRule.RuleToChain is CommonDrop commonDrop)
                            {
                                if (commonDrop.itemId == ItemID.RainbowWings && lootConfig.BossLoot.EmpressAndFishronWings > 0)
                                {
                                    commonDrop.chanceDenominator = (int)(lootConfig.BossLoot.EmpressAndFishronWings * 3f / 2f);
                                }

                                if (commonDrop.itemId == ItemID.SparkleGuitar && lootConfig.BossLoot.StellarTune > 0)
                                {
                                    commonDrop.chanceDenominator = (int)(lootConfig.BossLoot.StellarTune * 5f / 2f);
                                }

                                if (commonDrop.itemId == ItemID.RainbowCursor && lootConfig.BossLoot.RainbowCursor > 0)
                                {
                                    commonDrop.chanceDenominator = lootConfig.BossLoot.RainbowCursor;
                                }

                                if (commonDrop.itemId == ItemID.HallowBossDye)
                                {
                                    commonDrop.chanceDenominator = 1;
                                    commonDrop.amountDroppedMinimum = commonDrop.amountDroppedMaximum = 3;
                                }
                            }
                        }
                    }
                }
            }
            if (npc.type == NPCID.EyeofCthulhu && lootConfig.BossLoot.Binoculars > 0)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is ItemDropWithConditionRule drop && drop.itemId == ItemID.Binoculars)
                    {
                        drop.chanceDenominator = (int)(lootConfig.BossLoot.Binoculars * 4f / 3f);
                    }
                }
            }
            if (npc.type == NPCID.PirateShip && lootConfig.BossLoot.CoinGun > 0)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is CommonDrop commonDrop)
                    {
                        if (commonDrop.itemId == ItemID.CoinGun)
                        {
                            commonDrop.chanceDenominator = lootConfig.BossLoot.CoinGun;
                        }
                    }
                }
            }
            #endregion

            #region Non-Boss Drops

            #region Town NPC Drops
            if (npc.type == NPCID.Guide)
            {
                npcLoot.RemoveWhere(rule => rule is ItemDropWithConditionRule drop && drop.itemId == ItemID.GreenCap);
                npcLoot.Add(ItemDropRule.Common(ItemID.GreenCap, 1));
            }
            if (npc.type == NPCID.Steampunker)
            {
                npcLoot.RemoveWhere(rule => rule is ItemDropWithConditionRule drop && drop.itemId == ItemID.IvyGuitar);
                npcLoot.Add(ItemDropRule.Common(ItemID.IvyGuitar, 1));
            }
            if (npc.type == NPCID.Painter)
            {
                npcLoot.RemoveWhere(rule => rule is ItemDropWithConditionRule drop && drop.itemId == ItemID.JimsCap);
                npcLoot.Add(ItemDropRule.Common(ItemID.JimsCap, 1));
            }

            if (lootConfig.NonBossLoot.TownNPCWeapons > 0)
            {
                int[] townNPCs = new int[]
                {
                    NPCID.DyeTrader,
                    NPCID.Painter,
                    NPCID.DD2Bartender,
                    NPCID.Stylist,
                    NPCID.Mechanic,
                    NPCID.PartyGirl,
                    NPCID.TaxCollector,
                    NPCID.Princess
                };
                if (townNPCs.Contains(npc.type))
                {
                    int[] townWeapons = new int[]
                    {
                    ItemID.DyeTradersScimitar,
                    ItemID.PainterPaintballGun,
                    ItemID.AleThrowingGlove,
                    ItemID.StylistKilLaKillScissorsIWish,
                    ItemID.CombatWrench,
                    ItemID.PartyGirlGrenade,
                    ItemID.TaxCollectorsStickOfDoom,
                    ItemID.PrincessWeapon
                    };
                    foreach (var rule in npcLoot.Get())
                    {
                        if (rule is CommonDrop drop && townWeapons.Contains(drop.itemId))
                        {
                            drop.chanceDenominator = lootConfig.NonBossLoot.TownNPCWeapons;
                        }
                    }
                }
            }
            #endregion

            #region Basic NPCs
            if (npc.type == NPCID.SkeletonArcher && lootConfig.NonBossLoot.Marrow > 0)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is CommonDrop drop && drop.itemId == ItemID.Marrow)
                    {
                        drop.chanceDenominator = lootConfig.NonBossLoot.Marrow;
                    }
                }
            }
            if (npc.type == NPCID.ArmoredSkeleton && lootConfig.NonBossLoot.BeamSword > 0)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is CommonDrop drop && drop.itemId == ItemID.BeamSword)
                    {
                        drop.chanceDenominator = lootConfig.NonBossLoot.BeamSword;
                    }
                }
            }
            if (npc.type == NPCID.FireImp && lootConfig.NonBossLoot.PlumbersHat > 0)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is CommonDrop drop && drop.itemId == ItemID.PlumbersHat)
                    {
                        drop.chanceDenominator = lootConfig.NonBossLoot.PlumbersHat;
                    }
                }
            }

            if (npc.type == NPCID.ChaosElemental && lootConfig.NonBossLoot.RodofDiscord > 0)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is LeadingConditionRule drop)
                    {
                        if (drop.condition is Conditions.TenthAnniversaryIsUp tenthAnniversaryIsUp)
                        {
                            foreach (var chainedRule in drop.ChainedRules)
                            {
                                if (chainedRule.RuleToChain is CommonDrop commonDrop)
                                {
                                    if (commonDrop.itemId == ItemID.RodofDiscord)
                                    {
                                        commonDrop.chanceDenominator = Math.Max(1, (int)(lootConfig.NonBossLoot.RodofDiscord / 4f));
                                    }
                                }
                            }
                        }
                        if (drop.condition is Conditions.TenthAnniversaryIsNotUp tenthAnniversaryIsNotUp)
                        {
                            foreach (var chainedRule in drop.ChainedRules)
                            {
                                if (chainedRule.RuleToChain is DropBasedOnExpertMode dropBasedOnExpertMode)
                                {
                                    if (dropBasedOnExpertMode.ruleForExpertMode is CommonDrop expertDrop && expertDrop.itemId == ItemID.RodofDiscord)
                                    {
                                        expertDrop.chanceDenominator = lootConfig.NonBossLoot.RodofDiscord;
                                    }

                                    if (dropBasedOnExpertMode.ruleForNormalMode is CommonDrop normalDrop && normalDrop.itemId == ItemID.RodofDiscord)
                                    {
                                        normalDrop.chanceDenominator = (int)(lootConfig.NonBossLoot.RodofDiscord * 5f / 4f);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if ((npc.type == NPCID.Lihzahrd || npc.type == NPCID.LihzahrdCrawler || npc.type == NPCID.FlyingSnake) && lootConfig.NonBossLoot.LizardEgg > 0)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is CommonDrop drop && drop.itemId == ItemID.LizardEgg)
                    {
                        drop.chanceDenominator = lootConfig.NonBossLoot.LizardEgg;
                    }
                }
            }
            //Negative IDs is used for slimes because weird duplicate loot issues involving their variants (negative IDs) happen. Looking at Terraria source code, slime drops is the only time they use coding to remove duplicate drops.
            if (npc.netID == NPCID.Pinky && lootConfig.NonBossLoot.SlimeStaffFromPinky > 0)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is DropBasedOnExpertMode drop)
                    {
                        if (drop.ruleForExpertMode is CommonDrop expertDrop && expertDrop.itemId == ItemID.SlimeStaff)
                        {
                            expertDrop.chanceDenominator = lootConfig.NonBossLoot.SlimeStaffFromPinky;
                        }

                        if (drop.ruleForNormalMode is CommonDrop normalDrop && normalDrop.itemId == ItemID.SlimeStaff)
                        {
                            normalDrop.chanceDenominator = (int)(lootConfig.NonBossLoot.SlimeStaffFromPinky * 10f / 7f);
                        }
                    }
                }
            }
            if (npc.netID == NPCID.SandSlime && lootConfig.NonBossLoot.SlimeStaffFromSandSlime > 0)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is DropBasedOnExpertMode drop)
                    {
                        if (drop.ruleForExpertMode is CommonDrop expertDrop && expertDrop.itemId == ItemID.SlimeStaff)
                        {
                            expertDrop.chanceDenominator = lootConfig.NonBossLoot.SlimeStaffFromSandSlime;
                        }

                        if (drop.ruleForNormalMode is CommonDrop normalDrop && normalDrop.itemId == ItemID.SlimeStaff)
                        {
                            normalDrop.chanceDenominator = (int)(lootConfig.NonBossLoot.SlimeStaffFromSandSlime * 10f / 7f);
                        }
                    }
                }
            }
            if (lootConfig.NonBossLoot.SlimeStaffFromOtherSlimes > 0)
            {
                int[] otherSlimeStaffSlimes = new int[] {
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
            };

                if (otherSlimeStaffSlimes.Contains(npc.netID))
                {
                    foreach (var rule in npcLoot.Get())
                    {
                        if (rule is DropBasedOnExpertMode drop)
                        {
                            if (drop.ruleForExpertMode is CommonDrop expertDrop && expertDrop.itemId == ItemID.SlimeStaff)
                            {
                                expertDrop.chanceDenominator = lootConfig.NonBossLoot.SlimeStaffFromOtherSlimes;
                            }

                            if (drop.ruleForNormalMode is CommonDrop normalDrop && normalDrop.itemId == ItemID.SlimeStaff)
                            {
                                normalDrop.chanceDenominator = (int)(lootConfig.NonBossLoot.SlimeStaffFromOtherSlimes * 10f / 7f);
                            }
                        }
                    }
                }
            }
            if (npc.type == NPCID.SkeletonSniper && lootConfig.NonBossLoot.RifleScopeAndSniperRifle > 0)
            {
                npcLoot.RemoveWhere(
                    rule => rule is DropBasedOnExpertMode drop && drop.ruleForExpertMode is CommonDropWithRerolls drop2 && (drop2.itemId == ItemID.RifleScope || drop2.itemId == ItemID.SniperRifle));

                int expertDenom = lootConfig.NonBossLoot.RifleScopeAndSniperRifle;
                int normalDenom = (int)(expertDenom * (22f / 144f / (1f / 12f)));

                npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.RifleScope, normalDenom), new CommonDrop(ItemID.RifleScope, expertDenom)));
                npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.SniperRifle, normalDenom), new CommonDrop(ItemID.SniperRifle, expertDenom)));
            }
            if (npc.type == NPCID.TacticalSkeleton && lootConfig.NonBossLoot.SWATHelmetAndTacticalShotgun > 0)
            {
                npcLoot.RemoveWhere(
                    rule => rule is DropBasedOnExpertMode drop && drop.ruleForExpertMode is CommonDropWithRerolls drop2 && (drop2.itemId == ItemID.SWATHelmet || drop2.itemId == ItemID.TacticalShotgun));

                int expertDenom = lootConfig.NonBossLoot.SWATHelmetAndTacticalShotgun;
                int normalDenom = (int)(expertDenom * (22f / 144f / (1f / 12f)));

                npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.SWATHelmet, normalDenom), new CommonDrop(ItemID.SWATHelmet, expertDenom)));
                npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.TacticalShotgun, normalDenom), new CommonDrop(ItemID.TacticalShotgun, expertDenom)));
            }
            if (npc.type == NPCID.SkeletonCommando && lootConfig.NonBossLoot.RocketLauncher > 0)
            {
                npcLoot.RemoveWhere(
                    rule => rule is DropBasedOnExpertMode drop && drop.ruleForExpertMode is CommonDropWithRerolls drop2 && drop2.itemId == ItemID.RocketLauncher);

                int expertDenom = lootConfig.NonBossLoot.RocketLauncher;
                int normalDenom = (int)(expertDenom * (35f / 324f / (1f / 18f)));

                npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.RocketLauncher, normalDenom), new CommonDrop(ItemID.RocketLauncher, expertDenom)));
            }
            if (npc.type == NPCID.Paladin)
            {
                if (lootConfig.NonBossLoot.PaladinsHammer > 0)
                {
                    npcLoot.RemoveWhere(
                    rule => rule is DropBasedOnExpertMode drop && drop.ruleForExpertMode is CommonDropWithRerolls drop2 && drop2.itemId == ItemID.PaladinsHammer);

                    int expertDenom = lootConfig.NonBossLoot.PaladinsHammer;
                    int normalDenom = (int)(expertDenom * (22f / 225f / (1f / 15f)));

                    npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.PaladinsHammer, normalDenom), new CommonDrop(ItemID.PaladinsHammer, expertDenom)));
                }
                if (lootConfig.NonBossLoot.PaladinsShield > 0)
                {
                    npcLoot.RemoveWhere(
                    rule => rule is DropBasedOnExpertMode drop && drop.ruleForExpertMode is CommonDropWithRerolls drop2 && drop2.itemId == ItemID.PaladinsShield);

                    int expertDenom = lootConfig.NonBossLoot.PaladinsShield;
                    int normalDenom = (int)(expertDenom * (763f / 5625f / (7f / 75f)));

                    npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.PaladinsShield, normalDenom), new CommonDrop(ItemID.PaladinsShield, expertDenom)));
                }
            }


            if (lootConfig.NonBossLoot.RottenChunkAndVertebra > 0)
            {
                int[] rottenChunkNPCs = new int[]
                {
                    6,
                    7,
                    8,
                    9,
                    94
                };
                if (rottenChunkNPCs.Contains(npc.type))
                {
                    foreach (var rule in npcLoot.Get())
                    {
                        if (rule is CommonDrop drop && drop.itemId == ItemID.RottenChunk)
                        {
                            drop.chanceDenominator = lootConfig.NonBossLoot.RottenChunkAndVertebra;
                        }
                    }
                }

                int[] vertebraNPCs = new int[]
                {
                181, 173, 239, 182, 240
                };

                if (vertebraNPCs.Contains(npc.type))
                {
                    foreach (var rule in npcLoot.Get())
                    {
                        if (rule is CommonDrop drop && drop.itemId == ItemID.Vertebrae)
                        {
                            drop.chanceDenominator = lootConfig.NonBossLoot.RottenChunkAndVertebra;
                        }
                    }
                }
            }

            if (lootConfig.NonBossLoot.Lens > 0)
            {
                int[] demonEyes = new int[]
                {
                    133,
                    190,
                    191,
                    192,
                    193,
                    194,
                    2,
                    317,
                    318
                };

                if (demonEyes.Contains(npc.type))
                {
                    foreach (var rule in npcLoot.Get())
                    {
                        if (rule is CommonDrop drop)
                        {
                            foreach (var chainedRule in drop.ChainedRules)
                            {
                                if (chainedRule.RuleToChain is CommonDrop drop2)
                                {
                                    if (drop2.itemId == ItemID.Lens)
                                    {
                                        drop2.chanceDenominator = lootConfig.NonBossLoot.Lens;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #endregion

            #region Drops That Don't Happen in Vanilla
            if (npc.type == NPCID.DukeFishron && lootConfig.TrufflewormFromDukeFishron > 0)
            {
                npcLoot.Add(new CommonDrop(ItemID.TruffleWorm, lootConfig.TrufflewormFromDukeFishron));
            }

            if (npc.type == NPCID.Plantera && GetInstance<HOtherModdedItemsConfig>().PlanteraSapFromPlantera > 0)
            {
                npcLoot.Add(new CommonDrop(ItemType<Items.PlanteraSap>(), GetInstance<HOtherModdedItemsConfig>().PlanteraSapFromPlantera));
            }

            if (npc.type == NPCID.KingSlime && lootConfig.SlimeStaffFromSlimeKing > 0)
            {
                npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.SlimeStaff, lootConfig.SlimeStaffFromSlimeKing), new DropNothing()));
            }
            #endregion
        }

        public override void ModifyGlobalLoot(GlobalLoot globalLoot)
        {
            globalLoot.RemoveWhere(rule => rule is ItemDropWithConditionRule drop && drop.itemId == ItemID.BloodyMachete);
            globalLoot.Add(new ItemDropWithConditionRule(ItemID.BloodyMachete, 2000, 1, 1, new Conditions.HalloweenGoodieBagDrop()));
            globalLoot.Add(new ItemDropWithConditionRule(ItemID.BladedGlove, 2000, 1, 1, new Conditions.HalloweenGoodieBagDrop()));

            foreach (var rule in globalLoot.Get())
            {
                if (rule is ItemDropWithConditionRule drop)
                {
                    if (drop.itemId == ItemID.GoodieBag && lootConfig.NonBossLoot.GoodieBag > 0)
                    {
                        drop.chanceDenominator = lootConfig.NonBossLoot.GoodieBag;
                    }

                    if (drop.itemId == ItemID.Present && lootConfig.NonBossLoot.Present > 0)
                    {
                        drop.chanceDenominator = lootConfig.NonBossLoot.Present;
                    }

                    if (drop.itemId == ItemID.KOCannon && lootConfig.NonBossLoot.KOCannon > 0)
                    {
                        drop.chanceDenominator = lootConfig.NonBossLoot.KOCannon;
                    }

                    if (lootConfig.NonBossLoot.BiomeKey > 0)
                    {
                        int[] biomeKeys = new int[]
                        {
                            1533,
                            1534,
                            1535,
                            1536,
                            1537,
                            4714
                        };
                        if (biomeKeys.Contains(drop.itemId))
                        {
                            drop.chanceDenominator = lootConfig.NonBossLoot.BiomeKey;
                        }
                    }

                    if (lootConfig.NonBossLoot.SoulOfLightAndNight > 0 && (drop.itemId == ItemID.SoulofLight || drop.itemId == ItemID.SoulofNight))
                    {
                        drop.chanceDenominator = lootConfig.NonBossLoot.SoulOfLightAndNight;
                    }
                }
            }
        }
    }
}
