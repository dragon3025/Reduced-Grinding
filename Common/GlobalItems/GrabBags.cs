using ReducedGrinding.Configuration;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalItems
{
    public class GrabBags : GlobalItem
    {

        public override void ModifyItemLoot(Terraria.Item item, ItemLoot itemLoot)
        {
            if (!ModifyBossBagLoot(item, itemLoot))
            {
                return;
            }
            if (!ModifyCrateLoot(item, itemLoot))
            {
                return;
            }
        }

        private static bool ModifyBossBagLoot(Terraria.Item item, ItemLoot itemLoot)
        {
            EnemyLootConfig enemyLootConfig = GetInstance<EnemyLootConfig>();
            switch (item.type)
            {
                case ItemID.FishronBossBag:
                    if (enemyLootConfig.FishronWings >= 10)
                    {
                        return false;
                    }
                    foreach (IItemDropRule rule in itemLoot.Get())
                    {
                        if (rule is CommonDropNotScalingWithLuck drop && drop.itemId == ItemID.FishronWings)
                        {
                            drop.chanceDenominator = enemyLootConfig.FishronWings;
                            return false;
                        }
                    }
                    return false;
                case ItemID.KingSlimeBossBag:
                    //In 1.4.5+ Slime King drops Slime Staff, so this will need changed into a drop rate modification.
                    if (enemyLootConfig.SlimeStaffFromKingSlime < 30)
                    {
                        itemLoot.Add(new CommonDropNotScalingWithLuck(ItemID.SlimeStaff, enemyLootConfig.SlimeStaffFromKingSlime, 1, 1));
                    }
                    return false;
                case ItemID.FairyQueenBossBag:
                    foreach (IItemDropRule rule in itemLoot.Get())
                    {
                        if (rule is not CommonDropNotScalingWithLuck drop)
                        {
                            continue;
                        }
                        switch (drop.itemId)
                        {
                            case ItemID.RainbowWings when enemyLootConfig.EmpressWings < 10:
                                drop.chanceDenominator = enemyLootConfig.EmpressWings;
                                continue;
                            case ItemID.SparkleGuitar when enemyLootConfig.StellarTune < 20:
                                drop.chanceDenominator = enemyLootConfig.StellarTune;
                                continue;
                            case ItemID.RainbowCursor when enemyLootConfig.RainbowCursor < 20:
                                drop.chanceDenominator = enemyLootConfig.RainbowCursor;
                                continue;
                            case ItemID.HallowBossDye when enemyLootConfig.PrismaticDye < 4:
                                drop.chanceDenominator = enemyLootConfig.PrismaticDye;
                                //In 1.4.5+, the amount dropped is already 3.
                                drop.amountDroppedMinimum = drop.amountDroppedMaximum = 3;
                                continue;
                        }
                    }
                    return false;
                case ItemID.EyeOfCthulhuBossBag:
                    if (enemyLootConfig.Binoculars >= 30)
                    {
                        return false;
                    }
                    foreach (IItemDropRule rule in itemLoot.Get())
                    {
                        if (rule is CommonDropNotScalingWithLuck drop && drop.itemId == ItemID.Binoculars)
                        {
                            drop.chanceDenominator = enemyLootConfig.Binoculars;
                        }
                    }
                    return false;
                default:
                    return true;
            }
        }

        private static bool ModifyCrateLoot(Terraria.Item item, ItemLoot itemLoot)
        {
            TimeAndWeatherConfig timeAndWeatherConfig = GetInstance<TimeAndWeatherConfig>();
            int enchantedSundialDenominator = timeAndWeatherConfig.CrateEnchantedSundial;
            int decorativeBannersFromCrates = GetInstance<LimitedItemsConfig>().DecorativeBannersFromCrates;

            switch (item.type)
            {
                case ItemID.DungeonFishingCrate:
                case ItemID.DungeonFishingCrateHard:
                    if (decorativeBannersFromCrates <= 0)
                    {
                        return false;
                    }
                    itemLoot.Add(new CommonDrop(1451, decorativeBannersFromCrates));
                    itemLoot.Add(new CommonDrop(1452, decorativeBannersFromCrates));
                    itemLoot.Add(new CommonDrop(1453, decorativeBannersFromCrates));
                    itemLoot.Add(new CommonDrop(1454, decorativeBannersFromCrates));
                    itemLoot.Add(new CommonDrop(1455, decorativeBannersFromCrates));
                    itemLoot.Add(new CommonDrop(1456, decorativeBannersFromCrates));
                    return true;
                case ItemID.FloatingIslandFishingCrate:
                case ItemID.FloatingIslandFishingCrateHard:
                    if (decorativeBannersFromCrates <= 0)
                    {
                        return false;
                    }
                    itemLoot.Add(new CommonDrop(845, decorativeBannersFromCrates));
                    itemLoot.Add(new CommonDrop(846, decorativeBannersFromCrates));
                    itemLoot.Add(new CommonDrop(847, decorativeBannersFromCrates));
                    return true;
                case ItemID.LavaCrate:
                case ItemID.LavaCrateHard:
                    if (decorativeBannersFromCrates <= 0)
                    {
                        return false;
                    }
                    itemLoot.Add(new CommonDrop(1464, decorativeBannersFromCrates));
                    itemLoot.Add(new CommonDrop(1465, decorativeBannersFromCrates));
                    itemLoot.Add(new CommonDrop(1466, decorativeBannersFromCrates));
                    itemLoot.Add(new CommonDrop(1467, decorativeBannersFromCrates));
                    itemLoot.Add(new CommonDrop(1468, decorativeBannersFromCrates));
                    itemLoot.Add(new CommonDrop(1469, decorativeBannersFromCrates));
                    return true;
                case ItemID.OasisCrate:
                case ItemID.OasisCrateHard:
                    if (decorativeBannersFromCrates <= 0)
                    {
                        return false;
                    }
                    itemLoot.Add(new CommonDrop(789, decorativeBannersFromCrates));
                    itemLoot.Add(new CommonDrop(790, decorativeBannersFromCrates));
                    itemLoot.Add(new CommonDrop(791, decorativeBannersFromCrates));
                    return true;
                case ItemID.GoldenCrateHard:
                case ItemID.IronCrateHard:
                case ItemID.WoodenCrateHard:
                    if (enchantedSundialDenominator == 20)
                    {
                        return false;
                    }
                    int denominatorMultiplier = item.type == ItemID.GoldenCrateHard ? 1 : item.type == ItemID.IronCrateHard ? 3 : 10;
                    foreach (IItemDropRule rule in itemLoot.Get())
                    {
                        if (rule is not AlwaysAtleastOneSuccessDropRule drop)
                        {
                            continue;
                        }
                        foreach (IItemDropRule rule2 in drop.rules)
                        {
                            if (rule2 is not SequentialRulesNotScalingWithLuckRule drop2)
                            {
                                continue;
                            }
                            foreach (IItemDropRule rule3 in drop2.rules)
                            {
                                if (rule3 is ItemDropWithConditionRule drop3 && drop3.itemId == ItemID.Sundial)
                                {
                                    drop3.chanceDenominator = enchantedSundialDenominator * denominatorMultiplier;
                                    return false;
                                }
                            }
                        }
                    }
                    return false;
                case ItemID.GoldenCrate:
                case ItemID.IronCrate:
                case ItemID.WoodenCrate:
                    if (!timeAndWeatherConfig.PreHardmodeSundials)
                    {
                        return false;
                    }
                    int denominator = enchantedSundialDenominator;
                    denominator *= item.type == ItemID.GoldenCrate ? 1 : item.type == ItemID.IronCrate ? 3 : 10;
                    itemLoot.Add(new CommonDropNotScalingWithLuck(ItemID.Sundial, denominator, 1, 1));
                    return false;
                default:
                    return true;
            }
        }
    }
}
