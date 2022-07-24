using System.Collections.Generic;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class Item : GlobalItem
    {
        public override void ModifyTooltips(Terraria.Item item, List<TooltipLine> tooltips)
        {
            if (!GetInstance<IOtherConfig>().AnkhMaterialUseFromInventory)
                return;
            if (item.type == ItemID.Vitamins || item.type == ItemID.ArmorPolish || item.type == ItemID.AdhesiveBandage || item.type == ItemID.Bezoar || item.type == ItemID.Nazar || item.type == ItemID.Megaphone || item.type == ItemID.TrifoldMap || item.type == ItemID.FastClock || item.type == ItemID.Blindfold || item.type == ItemID.ArmorBracing || item.type == ItemID.MedicatedBandage || item.type == ItemID.CountercurseMantra || item.type == ItemID.ThePlan)
            {
                tooltips.Add(new TooltipLine(Mod, "AnkhMaterialUseFromInventory", $"{Language.GetTextValue($"Mods.ReducedGrinding.Other.AnkhMaterialUseFromInventory")}"));
            }
        }

        public override void ModifyItemLoot(Terraria.Item item, ItemLoot itemLoot)
        {
            void AddLoot(int config, int itemType)
            {
                if (config > 0)
                    itemLoot.Add(ItemDropRule.Common(itemType, config));
            }

            void AddLootOneFromRule(int config, IItemDropRule[] itemTypes)
            {
                if (config > 0)
                    itemLoot.Add(new OneFromRulesRule(config, itemTypes));
            }

            // Boss Bags
            if (item.type == ItemID.FishronBossBag)
                AddLoot(GetInstance<AEnemyLootConfig>().EmpressAndFishronWingsIncrease, ItemID.FishronWings);
            if (item.type == ItemID.FairyQueenBossBag)
            {
                AddLoot(GetInstance<AEnemyLootConfig>().EmpressAndFishronWingsIncrease, ItemID.RainbowWings);
                AddLoot(GetInstance<AEnemyLootConfig>().StellarTuneIncrease, ItemID.SparkleGuitar);
                AddLoot(GetInstance<AEnemyLootConfig>().RainbowCursor, ItemID.RainbowCursor);
            }
            if (item.type == ItemID.EyeOfCthulhuBossBag)
                AddLoot(GetInstance<AEnemyLootConfig>().BinocularsIncrease, ItemID.Binoculars);

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
                AddLootOneFromRule(GetInstance<IOtherConfig>().DungeonCrateDungeonFurniture, dungeonFurniture);
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
                AddLoot(GetInstance<IOtherConfig>().CrateEnchantedSundial, ItemID.Sundial);
                AddLootOneFromRule(GetInstance<IOtherConfig>().CrateStatue, statues);
            }
            if (item.type == ItemID.IronCrateHard)
            {
                AddLoot(GetInstance<IOtherConfig>().CrateEnchantedSundial * 3, ItemID.Sundial);
                AddLootOneFromRule(GetInstance<IOtherConfig>().CrateStatue * 3, statues);
            }
            if (item.type == ItemID.WoodenCrateHard)
            {
                AddLoot(GetInstance<IOtherConfig>().CrateEnchantedSundial * 10, ItemID.Sundial);
                AddLootOneFromRule(GetInstance<IOtherConfig>().CrateStatue * 10, statues);
            }
            if (item.type == ItemID.GoldenCrate)
                AddLootOneFromRule(GetInstance<IOtherConfig>().CrateStatue, statues);
            if (item.type == ItemID.IronCrate)
                AddLootOneFromRule(GetInstance<IOtherConfig>().CrateStatue * 3, statues);
            if (item.type == ItemID.WoodenCrate)
                AddLootOneFromRule(GetInstance<IOtherConfig>().CrateStatue * 10, statues);

            //Boss Bag drops that don't happen in vanilla.
            if (item.type == ItemID.FishronBossBag)
                AddLoot(GetInstance<BEnemyLootNonVanillaConfig>().TrufflewormFromDukeFishron, ItemID.TruffleWorm);

            if (item.type == ItemID.DestroyerBossBag || item.type == ItemID.TwinsBossBag || item.type == ItemID.SkeletronPrimeBossBag || item.type == ItemID.PlanteraBossBag || item.type == ItemID.GolemBossBag || item.type == ItemID.FishronBossBag || item.type == ItemID.MoonLordBossBag || item.type == ItemID.FairyQueenBossBag)
                AddLoot(GetInstance<BEnemyLootNonVanillaConfig>().TerragrimFromHardmodeGrabBag, ItemID.Terragrim);

            if (item.type == ItemID.KingSlimeBossBag)
                AddLoot(GetInstance<BEnemyLootNonVanillaConfig>().SlimeStaffFromSlimeKing, ItemID.SlimeStaff);
        }
    }
}