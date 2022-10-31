using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class Item : GlobalItem
    {
        readonly static AEnemyLootConfig lootConfig = GetInstance<AEnemyLootConfig>();
        readonly static IOtherConfig lootOtherConfig = GetInstance<IOtherConfig>();

        public override void ModifyTooltips(Terraria.Item item, List<TooltipLine> tooltips)
        {
            //TO-DO When 1.4.4 comes out, the Pocket Mirror will become an Ankh Material. (With the Shimmer, will this feature even be necessary?).
            if (!GetInstance<IOtherConfig>().AnkhMaterialUseFromInventory)
                return;
            if (item.type == ItemID.Vitamins || item.type == ItemID.ArmorPolish || item.type == ItemID.AdhesiveBandage || item.type == ItemID.Bezoar || item.type == ItemID.Nazar || item.type == ItemID.Megaphone || item.type == ItemID.TrifoldMap || item.type == ItemID.FastClock || item.type == ItemID.Blindfold || item.type == ItemID.ArmorBracing || item.type == ItemID.MedicatedBandage || item.type == ItemID.CountercurseMantra || item.type == ItemID.ThePlan)
            {
                tooltips.Add(new TooltipLine(Mod, "AnkhMaterialUseFromInventory", "Ankh Material\n" +
                    "Equip to allow 'Ankh Material' accessories to work from your inventory"));
            }
            //TO-DO Remove when 1.4.4 comes out. This is disabled because I couldn't get it to work in modplayer (I used AnglerRewards.cs for this).
            /*if (item.type == ItemID.MiningShirt || item.type == ItemID.MiningPants)
            {
                tooltips.Add(new TooltipLine(Mod, "MiningGearNew", "10% increased mining speed"));
            }*/
        }

        public override void ModifyItemLoot(Terraria.Item item, ItemLoot itemLoot)
        {
            #region Boss Bags
            if (item.type == ItemID.FishronBossBag && lootConfig.EmpressAndFishronWings > 0)
            {
                foreach (var rule in itemLoot.Get())
                {
                    if (rule is CommonDropNotScalingWithLuck drop && drop.itemId == ItemID.FishronWings)
                    {
                        drop.chanceDenominator = lootConfig.EmpressAndFishronWings;
                    }
                }
                if (GetInstance<BEnemyLootNonVanillaConfig>().TrufflewormFromDukeFishron > 0)
                    itemLoot.Add(new CommonDropNotScalingWithLuck(ItemID.TruffleWorm, GetInstance<BEnemyLootNonVanillaConfig>().TrufflewormFromDukeFishron, 1, 1));
            }

            if (item.type == ItemID.KingSlimeBossBag && GetInstance<BEnemyLootNonVanillaConfig>().SlimeStaffFromSlimeKing > 0)
                itemLoot.Add(new CommonDropNotScalingWithLuck(ItemID.SlimeStaff, GetInstance<BEnemyLootNonVanillaConfig>().SlimeStaffFromSlimeKing, 1, 1));

            if (item.type == ItemID.FairyQueenBossBag)
            {
                foreach (var rule in itemLoot.Get())
                {
                    if (rule is CommonDropNotScalingWithLuck drop)
                    {
                        if (drop.itemId == ItemID.RainbowWings && lootConfig.EmpressAndFishronWings > 0)
                            drop.chanceDenominator = lootConfig.EmpressAndFishronWings;

                        if (drop.itemId == ItemID.SparkleGuitar && lootConfig.StellarTune > 0)
                            drop.chanceDenominator = lootConfig.StellarTune;

                        if (drop.itemId == ItemID.RainbowCursor && lootConfig.RainbowCursor > 0)
                            drop.chanceDenominator = lootConfig.RainbowCursor;

                        if (drop.itemId == ItemID.HallowBossDye)
                        {
                            drop.chanceDenominator = 1;
                            drop.amountDroppedMinimum = drop.amountDroppedMaximum = 3;
                        }
                    }
                }
            }

            if (item.type == ItemID.EyeOfCthulhuBossBag && lootConfig.Binoculars > 0)
            {
                foreach (var rule in itemLoot.Get())
                {
                    if (rule is CommonDropNotScalingWithLuck drop && drop.itemId == ItemID.Binoculars)
                    {
                        drop.chanceDenominator = lootConfig.Binoculars;
                    }
                }
            }
            #endregion

            #region Crates

            if (lootOtherConfig.DungeonCrateDungeonFurniture > 0 && (item.type == ItemID.DungeonFishingCrate || item.type == ItemID.DungeonFishingCrateHard))
            {
                IItemDropRule[] dungeonFurniture = new IItemDropRule[] {
                    ItemDropRule.Common(1396),
                    ItemDropRule.Common(1397),
                    ItemDropRule.Common(1398),
                    ItemDropRule.Common(1399),
                    ItemDropRule.Common(1400),
                    ItemDropRule.Common(1401),
                    ItemDropRule.Common(1402),
                    ItemDropRule.Common(1403),
                    ItemDropRule.Common(1404),
                    ItemDropRule.Common(1405),
                    ItemDropRule.Common(1406),
                    ItemDropRule.Common(1407),
                    ItemDropRule.Common(1408),
                    ItemDropRule.Common(1409),
                    ItemDropRule.Common(1410),
                    ItemDropRule.Common(1411),
                    ItemDropRule.Common(1412),
                    ItemDropRule.Common(1413),
                    ItemDropRule.Common(1414),
                    ItemDropRule.Common(1415),
                    ItemDropRule.Common(1416),
                    ItemDropRule.Common(1470),
                    ItemDropRule.Common(1471),
                    ItemDropRule.Common(1472),
                    ItemDropRule.Common(2376),
                    ItemDropRule.Common(2377),
                    ItemDropRule.Common(2378),
                    ItemDropRule.Common(2386),
                    ItemDropRule.Common(2387),
                    ItemDropRule.Common(2388),
                    ItemDropRule.Common(2402),
                    ItemDropRule.Common(2403),
                    ItemDropRule.Common(2404),
                    ItemDropRule.Common(2645),
                    ItemDropRule.Common(2646),
                    ItemDropRule.Common(2647),
                    ItemDropRule.Common(2652),
                    ItemDropRule.Common(2653),
                    ItemDropRule.Common(2654),
                    ItemDropRule.Common(2658),
                    ItemDropRule.Common(2659),
                    ItemDropRule.Common(2660),
                    ItemDropRule.Common(2664),
                    ItemDropRule.Common(2665),
                    ItemDropRule.Common(2666),
                    ItemDropRule.Common(3900),
                    ItemDropRule.Common(3901),
                    ItemDropRule.Common(3902)
                };
                itemLoot.Add(new OneFromRulesRule(lootOtherConfig.DungeonCrateDungeonFurniture, dungeonFurniture));
            }

            if (lootOtherConfig.CrateEnchantedSundial > 0 && (item.type == ItemID.GoldenCrateHard || item.type == ItemID.IronCrateHard || item.type == ItemID.WoodenCrateHard))
            {
                int denominatorMultiplier = item.type == ItemID.GoldenCrateHard ? 1 : item.type == ItemID.IronCrateHard ? 3 : 10;

                foreach (var rule in itemLoot.Get())
                {
                    if (rule is AlwaysAtleastOneSuccessDropRule drop)
                    {
                        foreach (var rule2 in drop.rules)
                        {
                            if (rule2 is SequentialRulesNotScalingWithLuckRule drop2)
                            {
                                foreach (var rule3 in drop2.rules)
                                {
                                    if (rule3 is ItemDropWithConditionRule drop3 && drop3.itemId == ItemID.Sundial)
                                        drop3.chanceDenominator = lootOtherConfig.CrateEnchantedSundial * denominatorMultiplier;
                                }
                            }
                        }
                    }
                }
            }

            if (lootOtherConfig.CrateStatue > 0)
            {
                IItemDropRule[] statues = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.KingStatue),
                ItemDropRule.Common(ItemID.QueenStatue),
                ItemDropRule.Common(ItemID.HeartStatue),
                ItemDropRule.Common(ItemID.StarStatue),
                ItemDropRule.Common(ItemID.BombStatue)
            };

                if (item.type == ItemID.GoldenCrate && item.type == ItemID.GoldenCrateHard)
                    itemLoot.Add(new OneFromRulesRule(lootOtherConfig.CrateStatue, statues));

                if (item.type == ItemID.IronCrate && item.type == ItemID.IronCrateHard)
                    itemLoot.Add(new OneFromRulesRule(lootOtherConfig.CrateStatue * 3, statues));

                if (item.type == ItemID.WoodenCrate && item.type == ItemID.WoodenCrateHard)
                    itemLoot.Add(new OneFromRulesRule(lootOtherConfig.CrateStatue * 10, statues));
            }

            if (item.type == ItemID.OasisCrate || item.type == ItemID.OasisCrateHard)
            {
                itemLoot.Add(new CommonDropNotScalingWithLuck(ItemID.SandstorminaBottle, 35, 1, 1)); //TO-DO Remove when 1.4.4+ adds this
                itemLoot.Add(new CommonDropNotScalingWithLuck(ItemID.FlyingCarpet, 35, 1, 1));
            }
            #endregion

            //TO-DO Remove when 1.4.4+ adds this
            #region 1.4.4 Stuff
            if (item.type == ItemID.WoodenCrate || item.type == ItemID.WoodenCrateHard || item.type == ItemID.GoldenCrate || item.type == ItemID.GoldenCrateHard)
            {
                foreach (var rule in itemLoot.Get())
                {
                    if (rule is AlwaysAtleastOneSuccessDropRule drop)
                    {
                        foreach (var rule2 in drop.rules)
                        {
                            if ((item.type == ItemID.WoodenCrate || item.type == ItemID.WoodenCrateHard) && rule2 is OneFromOptionsNotScaledWithLuckDropRule drop2 && drop2.dropIds.Contains(ItemID.Aglet))
                            {
                                for (int i = 0; i < drop2.dropIds.Length; i++)
                                {
                                    if (drop2.dropIds[i] == ItemID.Umbrella)
                                    {
                                        drop2.dropIds[i] = ItemID.PortableStool;
                                        break;
                                    }
                                }
                                drop2.chanceDenominator = 20;
                            }
                            if (item.type == ItemID.GoldenCrate || item.type == ItemID.GoldenCrateHard)
                            {
                                if (rule2 is SequentialRulesNotScalingWithLuckRule drop3)
                                {
                                    foreach (var rule3 in drop3.rules)
                                    {
                                        if (rule3 is CommonDropNotScalingWithLuck drop4 && drop4.itemId == ItemID.LifeCrystal)
                                            drop4.chanceDenominator = 8;
                                    }
                                }
                                if (rule2 is CommonDropNotScalingWithLuck drop5 && drop5.itemId == ItemID.EnchantedSword)
                                {
                                    if (item.type == ItemID.GoldenCrate)
                                        drop5.chanceDenominator = 30;
                                    else
                                        drop5.chanceDenominator = 15;
                                }
                            }
                        }
                    }
                }
            }
            if (item.type == ItemID.FloatingIslandFishingCrate || item.type == ItemID.FloatingIslandFishingCrateHard)
            {
                foreach (var rule in itemLoot.Get())
                {
                    if (rule is AlwaysAtleastOneSuccessDropRule drop)
                    {
                        foreach (var rule2 in drop.rules)
                        {
                            if (rule2 is OneFromOptionsNotScaledWithLuckDropRule drop2 && drop2.dropIds.Contains(ItemID.Starfury))
                            {
                                List<int> newDropOptions = drop2.dropIds.ToList();

                                newDropOptions.Remove(ItemID.CreativeWings);
                                newDropOptions.Add(ItemID.LuckyHorseshoe);
                                newDropOptions.Add(ItemID.CelestialMagnet);

                                drop2.dropIds = newDropOptions.ToArray();
                            }
                        }
                    }
                }
                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.CreativeWings, 40));
                itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.Cloud, 2, 50, 100));
            }
            if (item.type == ItemID.LavaCrate || item.type == ItemID.LavaCrateHard)
            {
                foreach (var rule in itemLoot.Get())
                {
                    if (rule is AlwaysAtleastOneSuccessDropRule drop)
                    {
                        List<IItemDropRule> newDropRules = drop.rules.ToList();
                        newDropRules.Add(ItemDropRule.NotScalingWithLuck(ItemID.HellMinecart, 20));
                        drop.rules = newDropRules.ToArray();
                    }
                }
            }
            if (item.type == ItemID.OceanCrate || item.type == ItemID.OceanCrateHard)
            {
                foreach (var rule in itemLoot.Get())
                {
                    if (rule is AlwaysAtleastOneSuccessDropRule drop)
                    {
                        foreach (var rule2 in drop.rules)
                        {
                            if (rule2 is SequentialRulesNotScalingWithLuckRule drop2)
                            {
                                foreach (var rule3 in drop2.rules)
                                {
                                    if (rule3 is CommonDropNotScalingWithLuck drop3 && drop3.itemId == ItemID.SharkBait)
                                    {
                                        List<IItemDropRule> newDropRules = drop2.rules.ToList();
                                        newDropRules.Remove(rule3);
                                        drop2.rules = newDropRules.ToArray();
                                    }
                                }
                            }
                        }
                        List<IItemDropRule> newDropRules2 = drop.rules.ToList();
                        newDropRules2.Add(ItemDropRule.NotScalingWithLuck(ItemID.SharkBait, 10));
                        drop.rules = newDropRules2.ToArray();
                    }
                }
            }
            if (item.type == ItemID.ObsidianLockbox)
            {
                foreach (var rule in itemLoot.Get())
                {
                    if (rule is OneFromOptionsNotScaledWithLuckDropRule drop)
                    {
                        List<int> newDrops = drop.dropIds.ToList();
                        newDrops.Remove(ItemID.TreasureMagnet);
                        drop.dropIds = newDrops.ToArray();
                    }
                }
                itemLoot.Add(new CommonDropNotScalingWithLuck(ItemID.TreasureMagnet, 5, 1, 1));
            }
            if (item.type == ItemID.BrainOfCthulhuBossBag)
            {
                foreach (var rule in itemLoot.Get())
                {
                    if (rule is CommonDrop drop && (drop.itemId == ItemID.TissueSample || drop.itemId == ItemID.CrimtaneOre))
                    {
                        itemLoot.Remove(rule);
                    }
                }
                itemLoot.Add(new DropBasedOnMasterMode(new CommonDrop(ItemID.TissueSample, 1, 20, 40), new CommonDrop(ItemID.TissueSample, 1, 30, 50)));
                itemLoot.Add(new DropBasedOnMasterMode(new CommonDrop(ItemID.CrimtaneOre, 1, 80, 110), new CommonDrop(ItemID.CrimtaneOre, 1, 110, 135)));
            }
            if (item.type == ItemID.EaterOfWorldsBossBag)
            {
                foreach (var rule in itemLoot.Get())
                {
                    if (rule is CommonDrop drop && drop.itemId == ItemID.ShadowScale)
                    {
                        itemLoot.Remove(rule);
                    }
                }
                itemLoot.Add(new DropBasedOnMasterMode(new CommonDrop(ItemID.ShadowScale, 1, 20, 40), new CommonDrop(ItemID.ShadowScale, 1, 30, 50)));
            }
            #endregion
        }
    }
}