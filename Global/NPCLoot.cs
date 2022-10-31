using System;
using System.Linq;
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
        readonly static BEnemyLootNonVanillaConfig nonVanillaLootConfig = GetInstance<BEnemyLootNonVanillaConfig>();

        public override void ModifyNPCLoot(NPC npc, Terraria.ModLoader.NPCLoot npcLoot)
        {
            #region Boss Drops
            if (npc.type == NPCID.DukeFishron && lootConfig.EmpressAndFishronWings > 0)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is ItemDropWithConditionRule drop && drop.itemId == ItemID.FishronWings)
                        drop.chanceDenominator = (int)(lootConfig.EmpressAndFishronWings * 3f / 2f);
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
                                if (commonDrop.itemId == ItemID.RainbowWings && lootConfig.EmpressAndFishronWings > 0)
                                    commonDrop.chanceDenominator = (int)(lootConfig.EmpressAndFishronWings * 3f / 2f);

                                if (commonDrop.itemId == ItemID.SparkleGuitar && lootConfig.StellarTune > 0)
                                    commonDrop.chanceDenominator = (int)(lootConfig.StellarTune * 5f / 2f);

                                if (commonDrop.itemId == ItemID.RainbowCursor && lootConfig.RainbowCursor > 0)
                                    commonDrop.chanceDenominator = lootConfig.RainbowCursor;

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
            if (npc.type == NPCID.EyeofCthulhu && lootConfig.Binoculars > 0)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is ItemDropWithConditionRule drop && drop.itemId == ItemID.Binoculars)
                        drop.chanceDenominator = (int)(lootConfig.Binoculars * 4f / 3f);
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

            if (lootConfig.TownNPCWeapons > 0)
            {
                int[] otherTownNPCs = new int[]
                {
                    NPCID.DyeTrader,
                    NPCID.Painter,
                    NPCID.DD2Bartender,
                    NPCID.Stylist,
                    NPCID.Mechanic,
                    NPCID.TaxCollector,
                    NPCID.Princess
                }; //Excluding Party Girl
                foreach (int i in otherTownNPCs)
                {
                    if (npc.type == i)
                    {
                        foreach (var rule in npcLoot.Get())
                        {
                            if (rule is CommonDrop drop) //The all drop only 1 item, so we don't need to test the itemID.
                                drop.chanceDenominator = lootConfig.TownNPCWeapons;
                        }
                    }
                }
            }
            #endregion

            #region Basic NPCs
            if (npc.type == NPCID.SkeletonArcher && lootConfig.Marrow > 0)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is CommonDrop drop && drop.itemId == ItemID.Marrow)
                        drop.chanceDenominator = lootConfig.Marrow;
                }
            }
            if (npc.type == NPCID.ArmoredSkeleton && lootConfig.BeamSword > 0)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is CommonDrop drop && drop.itemId == ItemID.BeamSword)
                        drop.chanceDenominator = lootConfig.BeamSword;
                }
            }
            if (npc.type == NPCID.FireImp && lootConfig.PlumbersHat > 0)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is CommonDrop drop && drop.itemId == ItemID.PlumbersHat)
                        drop.chanceDenominator = lootConfig.PlumbersHat;
                }
            }

            if (npc.type == NPCID.ChaosElemental && lootConfig.RodofDiscord > 0)
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
                                        commonDrop.chanceDenominator = Math.Max(1, (int)(lootConfig.RodofDiscord / 4f));
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
                                        expertDrop.chanceDenominator = lootConfig.RodofDiscord;
                                    if (dropBasedOnExpertMode.ruleForNormalMode is CommonDrop normalDrop && normalDrop.itemId == ItemID.RodofDiscord)
                                        normalDrop.chanceDenominator = (int)(lootConfig.RodofDiscord * 5f / 4f);
                                }
                            }
                        }
                    }
                }
            }
            if ((npc.type == NPCID.Lihzahrd || npc.type == NPCID.LihzahrdCrawler || npc.type == NPCID.FlyingSnake) && lootConfig.LizardEgg > 0)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is CommonDrop drop && drop.itemId == ItemID.LizardEgg)
                        drop.chanceDenominator = lootConfig.LizardEgg;
                }
            }
            //Negative IDs is used for slimes because weird duplicate loot issues involving their variants (negative IDs) happen. Looking at Terraria source code, slime drops is the only time they use coding to remove duplicate drops.
            if (npc.netID == NPCID.Pinky && lootConfig.SlimeStaffFromPinky > 0)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is DropBasedOnExpertMode drop)
                    {
                        if (drop.ruleForExpertMode is CommonDrop expertDrop && expertDrop.itemId == ItemID.SlimeStaff)
                            expertDrop.chanceDenominator = lootConfig.SlimeStaffFromPinky;
                        if (drop.ruleForNormalMode is CommonDrop normalDrop && normalDrop.itemId == ItemID.SlimeStaff)
                            normalDrop.chanceDenominator = (int)(lootConfig.SlimeStaffFromPinky * 10f / 7f);
                    }
                }
            }
            if (npc.netID == NPCID.SandSlime && lootConfig.SlimeStaffFromSandSlime > 0)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is DropBasedOnExpertMode drop)
                    {
                        if (drop.ruleForExpertMode is CommonDrop expertDrop && expertDrop.itemId == ItemID.SlimeStaff)
                            expertDrop.chanceDenominator = lootConfig.SlimeStaffFromSandSlime;
                        if (drop.ruleForNormalMode is CommonDrop normalDrop && normalDrop.itemId == ItemID.SlimeStaff)
                            normalDrop.chanceDenominator = (int)(lootConfig.SlimeStaffFromSandSlime * 10f / 7f);
                    }
                }
            }
            if (lootConfig.SlimeStaffFromOtherSlimes > 0)
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
                foreach (int i in otherSlimeStaffSlimes)
                {
                    if (npc.netID == i)
                    {
                        foreach (var rule in npcLoot.Get())
                        {
                            if (rule is DropBasedOnExpertMode drop)
                            {
                                if (drop.ruleForExpertMode is CommonDrop expertDrop && expertDrop.itemId == ItemID.SlimeStaff)
                                    expertDrop.chanceDenominator = lootConfig.SlimeStaffFromOtherSlimes;
                                if (drop.ruleForNormalMode is CommonDrop normalDrop && normalDrop.itemId == ItemID.SlimeStaff)
                                    normalDrop.chanceDenominator = (int)(lootConfig.SlimeStaffFromOtherSlimes * 10f / 7f);
                            }
                        }
                    }
                }
            }
            if (npc.type == NPCID.SkeletonSniper && lootConfig.RifleScopeAndSniperRifle > 0)
            {
                npcLoot.RemoveWhere(
                    rule => rule is DropBasedOnExpertMode drop && drop.ruleForExpertMode is CommonDropWithRerolls drop2 && (drop2.itemId == ItemID.RifleScope || drop2.itemId == ItemID.SniperRifle));

                int expertDenom = lootConfig.RifleScopeAndSniperRifle;
                int normalDenom = (int)(expertDenom * (22f / 144f / (1f / 12f)));

                npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.RifleScope, normalDenom), new CommonDrop(ItemID.RifleScope, expertDenom)));
                npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.SniperRifle, normalDenom), new CommonDrop(ItemID.SniperRifle, expertDenom)));
            }
            if (npc.type == NPCID.TacticalSkeleton && lootConfig.SWATHelmetAndTacticalShotgun > 0)
            {
                npcLoot.RemoveWhere(
                    rule => rule is DropBasedOnExpertMode drop && drop.ruleForExpertMode is CommonDropWithRerolls drop2 && (drop2.itemId == ItemID.SWATHelmet || drop2.itemId == ItemID.TacticalShotgun));

                int expertDenom = lootConfig.SWATHelmetAndTacticalShotgun;
                int normalDenom = (int)(expertDenom * (22f / 144f / (1f / 12f)));

                npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.SWATHelmet, normalDenom), new CommonDrop(ItemID.SWATHelmet, expertDenom)));
                npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.TacticalShotgun, normalDenom), new CommonDrop(ItemID.TacticalShotgun, expertDenom)));
            }
            if (npc.type == NPCID.SkeletonCommando && lootConfig.RocketLauncher > 0)
            {
                npcLoot.RemoveWhere(
                    rule => rule is DropBasedOnExpertMode drop && drop.ruleForExpertMode is CommonDropWithRerolls drop2 && drop2.itemId == ItemID.RocketLauncher);

                int expertDenom = lootConfig.RocketLauncher;
                int normalDenom = (int)(expertDenom * (35f / 324f / (1f / 18f)));

                npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.RocketLauncher, normalDenom), new CommonDrop(ItemID.RocketLauncher, expertDenom)));
            }
            if (npc.type == NPCID.Paladin)
            {
                if (lootConfig.PaladinsHammer > 0)
                {
                    npcLoot.RemoveWhere(
                    rule => rule is DropBasedOnExpertMode drop && drop.ruleForExpertMode is CommonDropWithRerolls drop2 && drop2.itemId == ItemID.PaladinsHammer);

                    int expertDenom = lootConfig.PaladinsHammer;
                    int normalDenom = (int)(expertDenom * (22f / 225f / (1f / 15f)));

                    npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.PaladinsHammer, normalDenom), new CommonDrop(ItemID.PaladinsHammer, expertDenom)));
                }
                if (lootConfig.PaladinsShield > 0)
                {
                    npcLoot.RemoveWhere(
                    rule => rule is DropBasedOnExpertMode drop && drop.ruleForExpertMode is CommonDropWithRerolls drop2 && drop2.itemId == ItemID.PaladinsShield);

                    int expertDenom = lootConfig.PaladinsShield;
                    int normalDenom = (int)(expertDenom * (763f / 5625f / (7f / 75f)));

                    npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.PaladinsShield, normalDenom), new CommonDrop(ItemID.PaladinsShield, expertDenom)));
                }
            }


            if (lootConfig.RottenChunkAndVertebra > 0)
            {
                int[] rottenChunkNPCs = new int[]
                {
                    6,
                    7,
                    8,
                    9,
                    94
                };
                foreach (int i in rottenChunkNPCs)
                {
                    if (npc.type == i)
                    {
                        foreach (var rule in npcLoot.Get())
                        {
                            if (rule is CommonDrop drop && drop.itemId == ItemID.RottenChunk)
                            {
                                drop.chanceDenominator = lootConfig.RottenChunkAndVertebra;
                            }
                        }
                    }
                }

                int[] vertebraNPCs = new int[]
                {
                181, 173, 239, 182, 240
                };
                foreach (int i in vertebraNPCs)
                {
                    if (npc.type == i)
                    {
                        if (npc.type == i)
                        {
                            foreach (var rule in npcLoot.Get())
                            {
                                if (rule is CommonDrop drop && drop.itemId == ItemID.Vertebrae)
                                {
                                    drop.chanceDenominator = lootConfig.RottenChunkAndVertebra;
                                }
                            }
                        }
                    }
                }
            }
            if (lootConfig.Lens > 0)
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
                foreach (int i in demonEyes)
                {
                    if (npc.type == NPCID.WanderingEye)
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
                                            drop2.chanceDenominator = lootConfig.Lens;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region Pirates
            //TO-DO When 1.4.4+ comes out for tModLoader, remove all of this except for the Flying Dutchman Coingun configuration.
            int[] piratesGrunts = new int[] {
                212,
                213,
                214,
                215
            };
            foreach (int i in piratesGrunts)
            {
                if (npc.type == i)
                {
                    foreach (var rule in npcLoot.Get())
                    {
                        if (rule is CommonDrop commonDrop)
                        {
                            if (commonDrop.itemId == ItemID.CoinGun)
                            {
                                commonDrop.chanceDenominator = 4000;
                            }
                            if (commonDrop.itemId == ItemID.LuckyCoin)
                            {
                                commonDrop.chanceDenominator = 2000;
                            }
                            if (commonDrop.itemId == ItemID.DiscountCard)
                            {
                                commonDrop.chanceDenominator = 1000;
                            }
                            if (commonDrop.itemId == ItemID.PirateStaff)
                            {
                                commonDrop.chanceDenominator = 1000;
                            }
                            if (commonDrop.itemId == ItemID.GoldRing)
                            {
                                commonDrop.chanceDenominator = 500;
                            }
                            if (commonDrop.itemId == ItemID.Cutlass)
                            {
                                commonDrop.chanceDenominator = 200;
                            }
                            if (commonDrop.itemId == ItemID.GoldenPlatform)
                            {
                                commonDrop.amountDroppedMinimum = 90;
                                commonDrop.amountDroppedMaximum = 130;
                            }
                        }
                    }
                }
            }
            if (npc.type == NPCID.PirateCaptain)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is CommonDrop commonDrop)
                    {
                        if (commonDrop.itemId == ItemID.CoinGun)
                        {
                            commonDrop.chanceDenominator = 1000;
                        }
                        if (commonDrop.itemId == ItemID.LuckyCoin)
                        {
                            commonDrop.chanceDenominator = 500;
                        }
                        if (commonDrop.itemId == ItemID.DiscountCard)
                        {
                            commonDrop.chanceDenominator = 250;
                        }
                        if (commonDrop.itemId == ItemID.PirateStaff)
                        {
                            commonDrop.chanceDenominator = 250;
                        }
                        if (commonDrop.itemId == ItemID.GoldRing)
                        {
                            commonDrop.chanceDenominator = 125;
                        }
                        if (commonDrop.itemId == ItemID.Cutlass)
                        {
                            commonDrop.chanceDenominator = 50;
                        }
                    }
                }
            }
            if (npc.type == NPCID.PirateShip)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is CommonDrop commonDrop)
                    {
                        if (commonDrop.itemId == ItemID.CoinGun)
                        {
                            if (lootConfig.CoinGun > 0)
                                commonDrop.chanceDenominator = lootConfig.CoinGun;
                            else
                                commonDrop.chanceDenominator = 50;
                        }
                        if (commonDrop.itemId == ItemID.LuckyCoin)
                        {
                            commonDrop.chanceDenominator = 15;
                        }
                        if (commonDrop.itemId == ItemID.DiscountCard)
                        {
                            commonDrop.chanceDenominator = 15;
                        }
                        if (commonDrop.itemId == ItemID.PirateStaff)
                        {
                            commonDrop.chanceDenominator = 15;
                        }
                        if (commonDrop.itemId == ItemID.GoldRing)
                        {
                            commonDrop.chanceDenominator = 15;
                        }
                        if (commonDrop.itemId == ItemID.Cutlass)
                        {
                            commonDrop.chanceDenominator = 10;
                        }
                    }
                }
            }
            #endregion
            #endregion

            //TO-DO Remove when 1.4.4+ comes out
            #region Future Drop Adjustments
            //if (npc.type == NPCID.Shark)
            //{
            //    foreach (var rule in npcLoot.Get())
            //    {
            //        if (rule is CommonDrop drop)
            //        {
            //            foreach (var rule2 in drop.ChainedRules)
            //            {
            //                if (rule2 is CommonDrop drop2 && drop2.itemId == ItemID.DivingHelmet)
            //                {
            //                    drop2.chanceDenominator = 20;
            //                }
            //            }
            //        }
            //    }
            //}
            if (npc.type == NPCID.Medusa)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is DropBasedOnExpertMode drop)
                    {
                        if (drop.ruleForNormalMode is CommonDropWithRerolls drop2 && drop2.itemId == ItemID.PocketMirror)
                        {
                            drop2.chanceDenominator = 40;
                        }
                        if (drop.ruleForExpertMode is CommonDropWithRerolls drop3 && drop3.itemId == ItemID.PocketMirror)
                        {
                            drop3.chanceDenominator = 20;
                        }
                    }
                    if (rule is CommonDrop drop4 && drop4.itemId == ItemID.MedusaHead)
                    {
                        drop4.chanceDenominator = 25;
                    }
                }
            }
            if (npc.type == NPCID.GiantTortoise)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is CommonDrop drop && drop.itemId == ItemID.TurtleShell)
                    {
                        drop.chanceDenominator = 12;
                    }
                }
            }
            if (npc.type == NPCID.ScutlixRider)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is CommonDrop drop && drop.itemId == ItemID.BrainScrambler)
                    {
                        drop.chanceDenominator = 30;
                    }
                }
            }
            //if (npc.type == NPCID.DeadlySphere)
            //{
            //    foreach (var rule in npcLoot.Get())
            //    {
            //        if (rule is LeadingConditionRule drop)
            //        {
            //            foreach (var rule2 in drop.ChainedRules)
            //            {
            //                if (rule2 is DropBasedOnExpertMode drop2)
            //                {
            //                    if (drop2.ruleForNormalMode is CommonDropWithRerolls drop3 && drop3.itemId == ItemID.DeadlySphereStaff)
            //                    {
            //                        drop3.chanceDenominator = 30;
            //                    }
            //                    if (drop2.ruleForExpertMode is CommonDropWithRerolls drop4 && drop4.itemId == ItemID.DeadlySphereStaff)
            //                    {
            //                        drop4.chanceDenominator = 30;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            if (npc.type == NPCID.RedDevil)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is CommonDrop drop && drop.itemId == ItemID.FireFeather)
                    {
                        drop.chanceDenominator = 50;
                    }
                }
            }
            int[] boneFeatherDroppers = new int[] { 269, 270, 271, 272, 273, 274, 275, 276, 277, 278, 279, 280 };
            foreach (int i in boneFeatherDroppers)
            {
                if (npc.type == i)
                {
                    foreach (var rule in npcLoot.Get())
                    {
                        if (rule is CommonDrop drop && drop.itemId == ItemID.BoneFeather)
                        {
                            drop.chanceDenominator = 300;
                        }
                    }
                }
            }
            if (npc.type == NPCID.Harpy)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is CommonDrop drop && drop.itemId == ItemID.GiantHarpyFeather)
                    {
                        drop.chanceDenominator = 150;
                    }
                }
            }
            if (npc.type == NPCID.MossHornet)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is ItemDropWithConditionRule drop && drop.itemId == ItemID.TatteredBeeWing)
                    {
                        drop.chanceDenominator = 100;
                    }
                }
            }
            if (npc.type == NPCID.FireImp)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is CommonDrop drop && drop.itemId == ItemID.ObsidianRose)
                    {
                        drop.chanceDenominator = 20;
                    }
                }
            }
            if (npc.type == NPCID.IceTortoise)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is CommonDrop drop && drop.itemId == ItemID.FrozenTurtleShell)
                    {
                        drop.chanceDenominator = 50;
                    }
                }
            }
            int[] iceSickleDroppers = new int[] { 197, 206, 169, 154 };
            foreach (int i in iceSickleDroppers)
            {
                if (npc.type == i)
                {
                    foreach (var rule in npcLoot.Get())
                    {
                        if (rule is CommonDrop drop && drop.itemId == ItemID.IceSickle)
                        {
                            drop.chanceDenominator = 100;
                        }
                    }
                }
            }
            //int[] monsterMeatDroppers = new int[] { 6, 7, 8, 9, 94, 81, 121, 101, 173, 181, 239, 240, 174, 183, 242, 241, 268, 182, 98, 99, 100 };
            //foreach (int i in monsterMeatDroppers)
            //{
            //    if (npc.type == i)
            //    {
            //        foreach (var rule in npcLoot.Get())
            //        {
            //            if (rule is ItemDropWithConditionRule drop && drop.itemId == 5091/*Monster Meat*/)
            //            {
            //                if (drop.condition == new Conditions.DontStarveIsUp())
            //                {
            //                    drop.chanceDenominator = 500;
            //                }
            //                if (drop.condition == new Conditions.DontStarveIsNotUp())
            //                {
            //                    drop.chanceDenominator = 1500;
            //                }
            //            }
            //        }
            //    }
            //}
            //if (npc.type == NPCID.SnowFlinx)
            //{
            //    foreach (var rule in npcLoot.Get())
            //    {
            //        if (rule is DropBasedOnExpertMode drop)
            //        {
            //            if (drop.ruleForNormalMode is CommonDropWithRerolls drop2 && drop2.itemId == ItemID.FlinxFur)
            //            {
            //                drop2.chanceDenominator = 1;
            //                drop2.amountDroppedMaximum = 2;
            //            }
            //            if (drop.ruleForExpertMode is CommonDropWithRerolls drop3 && drop3.itemId == ItemID.FlinxFur)
            //            {
            //                drop3.chanceNumerator = 1;
            //                drop3.chanceDenominator = 1;
            //            }
            //        }
            //    }
            //}
            if (npc.type == NPCID.BrainofCthulhu)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is DropBasedOnExpertMode drop && drop.ruleForExpertMode is CommonDrop drop2 && (drop2.itemId == ItemID.CrimtaneOre || drop2.itemId == ItemID.TissueSample))
                    {
                        npcLoot.Remove(rule);
                    }
                }
                npcLoot.Add(new DropBasedOnMasterMode(new DropBasedOnExpertMode(new CommonDrop(1329, 3, 2, 5, 2), new CommonDrop(1329, 3, 1, 3, 2)), new CommonDrop(1329, 4, 1, 2, 2)));
                npcLoot.Add(new DropBasedOnMasterMode(new DropBasedOnExpertMode(new CommonDrop(880, 3, 5, 12, 2), new CommonDrop(880, 3, 5, 7, 2)), new CommonDrop(880, 3, 2, 4, 2)));
            }
            if (npc.type == NPCID.Creeper)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is DropBasedOnExpertMode drop && drop.ruleForExpertMode is CommonDrop drop2 && (drop2.itemId == ItemID.CrimtaneOre || drop2.itemId == ItemID.TissueSample))
                    {
                        npcLoot.Remove(rule);
                    }
                }
                npcLoot.Add(new DropBasedOnMasterMode(new DropBasedOnExpertMode(new CommonDrop(1329, 3, 2, 5, 2), new CommonDrop(1329, 3, 1, 3, 2)), new CommonDrop(1329, 4, 1, 2, 2)));
                npcLoot.Add(new DropBasedOnMasterMode(new DropBasedOnExpertMode(new CommonDrop(880, 3, 5, 12, 2), new CommonDrop(880, 3, 5, 7, 2)), new CommonDrop(880, 3, 2, 4, 2)));
            }
            int[] eaterOfWorldsParts = new int[] { 13, 14, 15 };
            foreach (int i in eaterOfWorldsParts)
            {
                if (npc.type == i)
                {
                    foreach (var rule in npcLoot.Get())
                    {
                        if (rule is DropBasedOnExpertMode drop && drop.ruleForExpertMode is CommonDrop drop2 && drop2.itemId == ItemID.ShadowScale)
                        {
                            npcLoot.Remove(rule);
                        }
                    }
                    npcLoot.Add(new DropBasedOnMasterMode(new DropBasedOnExpertMode(ItemDropRule.Common(86, 2, 1, 2), ItemDropRule.Common(86, 5, 1, 2)), ItemDropRule.Common(86, 10, 1, 2)));
                }
            }
            if (npc.type == NPCID.IceQueen)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is LeadingConditionRule drop)
                    {
                        foreach (var rule2 in drop.ChainedRules)
                        {
                            if (rule2 is ItemDropWithConditionRule drop2 && drop2.itemId == ItemID.ReindeerBells)
                            {
                                drop2.chanceDenominator = 15;
                            }
                        }
                    }
                }
            }
            if (npc.type == NPCID.DD2OgreT2)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is DropBasedOnExpertMode drop)
                    {
                        if (drop.ruleForNormalMode is OneFromOptionsNotScaledWithLuckDropRule rule2 && rule2.dropIds.Contains(ItemID.DD2PhoenixBow))
                        {
                            rule2.chanceDenominator = 2;
                        }
                        if (drop.ruleForExpertMode is OneFromOptionsNotScaledWithLuckDropRule rule3 && rule3.dropIds.Contains(ItemID.DD2PhoenixBow))
                        {
                            rule3.chanceDenominator = 1;
                        }
                    }
                }
            }
            if (npc.type == NPCID.DD2OgreT3)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is OneFromOptionsNotScaledWithLuckDropRule drop && drop.dropIds.Contains(ItemID.DD2PhoenixBow))
                    {
                        drop.chanceDenominator = 4;
                    }
                }
            }
            if (npc.type == NPCID.TheBride || npc.type == NPCID.TheGroom)
            {
                foreach (var rule in npcLoot.Get())
                {
                    if (rule is ItemDropWithConditionRule drop && drop.itemId == ItemID.BloodMoonStarter)
                    {
                        npcLoot.Remove(rule);
                    }
                }
                npcLoot.Add(ItemDropRule.Common(4271, 5));
            }
            #endregion

            #region Drops That Don't Happen in Vanilla
            #region Boss Drops
            if (npc.type == NPCID.DukeFishron && nonVanillaLootConfig.TrufflewormFromDukeFishron > 0)
                npcLoot.Add(new CommonDrop(ItemID.TruffleWorm, nonVanillaLootConfig.TrufflewormFromDukeFishron));

            if (npc.type == NPCID.Plantera && GetInstance<HOtherModdedItemsConfig>().PlanteraSapFromPlantera > 0)
                npcLoot.Add(new CommonDrop(ItemType<Items.PlanteraSap>(), GetInstance<HOtherModdedItemsConfig>().PlanteraSapFromPlantera));

            if (npc.type == NPCID.KingSlime && nonVanillaLootConfig.SlimeStaffFromSlimeKing > 0)
                npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.SlimeStaff, nonVanillaLootConfig.SlimeStaffFromSlimeKing), new DropNothing()));
            #endregion

            #region Non-Boss Drops
            //TO-DO in 1.4.4+ Flinx spawn easier. Test this out (both pre-hardmode and hardmode).
            if (npc.type == NPCID.SpikedIceSlime && nonVanillaLootConfig.SnowballLauncherFromSpikedIceSlime > 0)
                npcLoot.Add(new CommonDrop(ItemID.SnowballLauncher, nonVanillaLootConfig.SnowballLauncherFromSpikedIceSlime));

            if (nonVanillaLootConfig.MarbleFromMarbleCaveEnemies.Max() > 0 && (npc.type == NPCID.GreekSkeleton || npc.type == NPCID.Medusa))
                npcLoot.Add(new CommonDrop(ItemID.Marble, 1, nonVanillaLootConfig.MarbleFromMarbleCaveEnemies.Min(), nonVanillaLootConfig.MarbleFromMarbleCaveEnemies.Max()));
            #endregion
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
                    if (drop.itemId == ItemID.GoodieBag && lootConfig.GoodieBag > 0)
                        drop.chanceDenominator = lootConfig.GoodieBag;

                    if (drop.itemId == ItemID.Present && lootConfig.Present > 0)
                        drop.chanceDenominator = lootConfig.Present;

                    if (drop.itemId == ItemID.KOCannon && lootConfig.KOCannon > 0)
                        drop.chanceDenominator = lootConfig.KOCannon;

                    if (lootConfig.BiomeKey > 0)
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
                        foreach (int i in biomeKeys)
                        {
                            if (drop.itemId == i)
                                drop.chanceDenominator = lootConfig.BiomeKey;
                        }
                    }

                    if (lootConfig.SoulOfLightAndNight > 0 && (drop.itemId == ItemID.SoulofLight || drop.itemId == ItemID.SoulofNight))
                        drop.chanceDenominator = lootConfig.SoulOfLightAndNight;
                }
            }
        }
    }
}
