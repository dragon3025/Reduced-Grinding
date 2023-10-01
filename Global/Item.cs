using ReducedGrinding.Configuration;
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

        public override void ModifyItemLoot(Terraria.Item item, ItemLoot itemLoot)
        {
            #region Boss Bags
            if (item.type == ItemID.FishronBossBag && lootConfig.BossLoot.EmpressAndFishronWings > 0)
            {
                foreach (var rule in itemLoot.Get())
                {
                    if (rule is CommonDropNotScalingWithLuck drop && drop.itemId == ItemID.FishronWings)
                    {
                        drop.chanceDenominator = lootConfig.BossLoot.EmpressAndFishronWings;
                    }
                }
                if (lootConfig.TrufflewormFromDukeFishron > 0)
                {
                    itemLoot.Add(new CommonDropNotScalingWithLuck(ItemID.TruffleWorm, lootConfig.TrufflewormFromDukeFishron, 1, 1));
                }
            }

            if (item.type == ItemID.KingSlimeBossBag && lootConfig.SlimeStaffFromSlimeKing > 0)
            {
                itemLoot.Add(new CommonDropNotScalingWithLuck(ItemID.SlimeStaff, lootConfig.SlimeStaffFromSlimeKing, 1, 1));
            }

            if (item.type == ItemID.FairyQueenBossBag)
            {
                foreach (var rule in itemLoot.Get())
                {
                    if (rule is CommonDropNotScalingWithLuck drop)
                    {
                        if (drop.itemId == ItemID.RainbowWings && lootConfig.BossLoot.EmpressAndFishronWings > 0)
                        {
                            drop.chanceDenominator = lootConfig.BossLoot.EmpressAndFishronWings;
                        }

                        if (drop.itemId == ItemID.SparkleGuitar && lootConfig.BossLoot.StellarTune > 0)
                        {
                            drop.chanceDenominator = lootConfig.BossLoot.StellarTune;
                        }

                        if (drop.itemId == ItemID.RainbowCursor && lootConfig.BossLoot.RainbowCursor > 0)
                        {
                            drop.chanceDenominator = lootConfig.BossLoot.RainbowCursor;
                        }

                        if (drop.itemId == ItemID.HallowBossDye)
                        {
                            drop.chanceDenominator = 1;
                            drop.amountDroppedMinimum = drop.amountDroppedMaximum = 3;
                        }
                    }
                }
            }

            if (item.type == ItemID.EyeOfCthulhuBossBag && lootConfig.BossLoot.Binoculars > 0)
            {
                foreach (var rule in itemLoot.Get())
                {
                    if (rule is CommonDropNotScalingWithLuck drop && drop.itemId == ItemID.Binoculars)
                    {
                        drop.chanceDenominator = lootConfig.BossLoot.Binoculars;
                    }
                }
            }
            #endregion

            #region Crates
            int enchantedSundialDenominator = lootOtherConfig.EnchantedSundial.CrateEnchantedSundial;
            if (enchantedSundialDenominator > 0 && (item.type == ItemID.GoldenCrateHard || item.type == ItemID.IronCrateHard || item.type == ItemID.WoodenCrateHard))
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
                                    {
                                        drop3.chanceDenominator = enchantedSundialDenominator * denominatorMultiplier;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (lootOtherConfig.EnchantedSundial.PreHardmodeSundials && (item.type == ItemID.GoldenCrate || item.type == ItemID.IronCrate || item.type == ItemID.WoodenCrate))
            {
                int denominator = enchantedSundialDenominator > 0 ? enchantedSundialDenominator : 20;
                denominator *= item.type == ItemID.GoldenCrate ? 1 : item.type == ItemID.IronCrate ? 3 : 10;

                itemLoot.Add(new CommonDropNotScalingWithLuck(ItemID.Sundial, denominator, 1, 1));
            }

            #endregion
        }
    }
}