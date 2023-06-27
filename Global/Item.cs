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
                {
                    itemLoot.Add(new CommonDropNotScalingWithLuck(ItemID.TruffleWorm, GetInstance<BEnemyLootNonVanillaConfig>().TrufflewormFromDukeFishron, 1, 1));
                }
            }

            if (item.type == ItemID.KingSlimeBossBag && GetInstance<BEnemyLootNonVanillaConfig>().SlimeStaffFromSlimeKing > 0)
            {
                itemLoot.Add(new CommonDropNotScalingWithLuck(ItemID.SlimeStaff, GetInstance<BEnemyLootNonVanillaConfig>().SlimeStaffFromSlimeKing, 1, 1));
            }

            if (item.type == ItemID.FairyQueenBossBag)
            {
                foreach (var rule in itemLoot.Get())
                {
                    if (rule is CommonDropNotScalingWithLuck drop)
                    {
                        if (drop.itemId == ItemID.RainbowWings && lootConfig.EmpressAndFishronWings > 0)
                        {
                            drop.chanceDenominator = lootConfig.EmpressAndFishronWings;
                        }

                        if (drop.itemId == ItemID.SparkleGuitar && lootConfig.StellarTune > 0)
                        {
                            drop.chanceDenominator = lootConfig.StellarTune;
                        }

                        if (drop.itemId == ItemID.RainbowCursor && lootConfig.RainbowCursor > 0)
                        {
                            drop.chanceDenominator = lootConfig.RainbowCursor;
                        }

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
            if (lootOtherConfig.EnchantedSundialConfig.CrateEnchantedSundial > 0 && (item.type == ItemID.GoldenCrateHard || item.type == ItemID.IronCrateHard || item.type == ItemID.WoodenCrateHard))
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
                                        drop3.chanceDenominator = lootOtherConfig.EnchantedSundialConfig.CrateEnchantedSundial * denominatorMultiplier;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (item.type == ItemID.OasisCrate || item.type == ItemID.OasisCrateHard)
            {
                itemLoot.Add(new CommonDropNotScalingWithLuck(ItemID.FlyingCarpet, 35, 1, 1));
            }
            #endregion
        }
    }
}