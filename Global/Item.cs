using System.Collections.Generic;
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
            if (!GetInstance<IOtherConfig>().AnkhMaterialUseFromInventory)
                return;
            if (item.type == ItemID.Vitamins || item.type == ItemID.ArmorPolish || item.type == ItemID.AdhesiveBandage || item.type == ItemID.Bezoar || item.type == ItemID.Nazar || item.type == ItemID.Megaphone || item.type == ItemID.TrifoldMap || item.type == ItemID.FastClock || item.type == ItemID.Blindfold || item.type == ItemID.ArmorBracing || item.type == ItemID.MedicatedBandage || item.type == ItemID.CountercurseMantra || item.type == ItemID.ThePlan)
            {
                tooltips.Add(new TooltipLine(Mod, "AnkhMaterialUseFromInventory", "Ankh Material" +
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
            // Boss Bags
            if (item.type == ItemID.FishronBossBag && lootConfig.EmpressAndFishronWings > 0)
            {
                foreach (var rule in itemLoot.Get())
                {
                    if (rule is CommonDropNotScalingWithLuck drop && drop.itemId == ItemID.FishronWings)
                    {
                        drop.chanceDenominator = lootConfig.EmpressAndFishronWings;
                    }
                }
            }
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

            //Other Grab Bags
            if (item.type == ItemID.DungeonFishingCrate || item.type == ItemID.DungeonFishingCrateHard)
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

            IItemDropRule[] statues = new IItemDropRule[] {
                ItemDropRule.Common(ItemID.KingStatue),
                ItemDropRule.Common(ItemID.QueenStatue),
                ItemDropRule.Common(ItemID.HeartStatue),
                ItemDropRule.Common(ItemID.StarStatue),
                ItemDropRule.Common(ItemID.BombStatue)
            };

            if (item.type == ItemID.GoldenCrateHard)
            {
                itemLoot.Add(new CommonDrop(ItemID.Sundial, lootOtherConfig.CrateEnchantedSundial));
                itemLoot.Add(new OneFromRulesRule(lootOtherConfig.CrateStatue, statues));
            }
            if (item.type == ItemID.IronCrateHard)
            {
                itemLoot.Add(new CommonDrop(ItemID.Sundial, lootOtherConfig.CrateEnchantedSundial * 3));
                itemLoot.Add(new OneFromRulesRule(lootOtherConfig.CrateStatue * 3, statues));
            }
            if (item.type == ItemID.WoodenCrateHard)
            {
                itemLoot.Add(new CommonDrop(ItemID.Sundial, lootOtherConfig.CrateEnchantedSundial * 10));
                itemLoot.Add(new OneFromRulesRule(lootOtherConfig.CrateStatue * 10, statues));
            }
            if (item.type == ItemID.GoldenCrate)
                itemLoot.Add(new OneFromRulesRule(lootOtherConfig.CrateStatue, statues));
            if (item.type == ItemID.IronCrate)
                itemLoot.Add(new OneFromRulesRule(lootOtherConfig.CrateStatue * 3, statues));
            if (item.type == ItemID.WoodenCrate)
                itemLoot.Add(new OneFromRulesRule(lootOtherConfig.CrateStatue * 10, statues));

            if (item.type == ItemID.OasisCrate || item.type == ItemID.OasisCrateHard)
            {
                itemLoot.Add(new CommonDrop(ItemID.SandstorminaBottle, 35)); //TO-DO Remove when 1.4.4+ adds this
                itemLoot.Add(new CommonDrop(ItemID.FlyingCarpet, 35));
            }

            //Boss Bag drops that don't happen in vanilla.
            if (item.type == ItemID.FishronBossBag)
                itemLoot.Add(new CommonDrop(ItemID.TruffleWorm, GetInstance<BEnemyLootNonVanillaConfig>().TrufflewormFromDukeFishron));

            if (item.type == ItemID.KingSlimeBossBag)
                itemLoot.Add(new CommonDrop(ItemID.SlimeStaff, GetInstance<BEnemyLootNonVanillaConfig>().SlimeStaffFromSlimeKing));
        }
    }
}