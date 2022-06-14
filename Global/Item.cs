using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class Item : GlobalItem
    {
        public override void OpenVanillaBag(string context, Terraria.Player player, int arg)
        {
            var source = player.GetSource_OpenItem(arg);

            void try_grab_bag_drop(int config, int itemType, int amount = 1)
            {
                if (config > 0)
                    if (Main.rand.NextBool(config))
                        player.QuickSpawnItem(source, itemType, amount);
            }

            // Boss Bags
            if (arg == ItemID.FishronBossBag)
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().EmpressAndFishronWingsIncrease, ItemID.FishronWings);
            if (arg == ItemID.FairyQueenBossBag)
            {
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().EmpressAndFishronWingsIncrease, ItemID.RainbowWings);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().StellarTuneIncrease, ItemID.SparkleGuitar);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().RainbowCursor, ItemID.RainbowCursor);
            }
            if (arg == ItemID.EyeOfCthulhuBossBag)
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().BinocularsIncrease, ItemID.Binoculars);

            //Other Grab Bags
            if (arg == ItemID.DungeonFishingCrate || arg == ItemID.DungeonFishingCrateHard)
            {
                List<int> dungeonFurniture = new() {
                    1396,
                    1397,
                    1398,
                    1399,
                    1400,
                    1401,
                    1402,
                    1403,
                    1404,
                    1405,
                    1406,
                    1407,
                    1408,
                    1409,
                    1410,
                    1411,
                    1412,
                    1413,
                    1414,
                    1415,
                    1416,
                    1470,
                    1471,
                    1472,
                    2376,
                    2377,
                    2378,
                    2386,
                    2387,
                    2388,
                    2402,
                    2403,
                    2404,
                    2645,
                    2646,
                    2647,
                    2652,
                    2653,
                    2654,
                    2658,
                    2659,
                    2660,
                    2664,
                    2665,
                    2666,
                    3900,
                    3901,
                    3902
                };
                try_grab_bag_drop(GetInstance<IOtherConfig>().DungeonCrateDungeonFurniture, dungeonFurniture[Main.rand.Next(dungeonFurniture.Count)]);
            }

            List<int> statues = new() {
                ItemID.KingStatue,
                ItemID.QueenStatue,
                ItemID.HeartStatue,
                ItemID.StarStatue,
                ItemID.BombStatue
            };

            if (arg == ItemID.GoldenCrateHard)
            {
                try_grab_bag_drop(GetInstance<IOtherConfig>().CrateEnchantedSundial, ItemID.Sundial);
                try_grab_bag_drop(GetInstance<IOtherConfig>().CrateStatue, statues[Main.rand.Next(statues.Count)]);
            }
            if (arg == ItemID.IronCrateHard)
            {
                try_grab_bag_drop(GetInstance<IOtherConfig>().CrateEnchantedSundial * 3, ItemID.Sundial);
                try_grab_bag_drop(GetInstance<IOtherConfig>().CrateStatue * 3, statues[Main.rand.Next(statues.Count)]);
            }
            if (arg == ItemID.WoodenCrateHard)
            {
                try_grab_bag_drop(GetInstance<IOtherConfig>().CrateEnchantedSundial * 10, ItemID.Sundial);
                try_grab_bag_drop(GetInstance<IOtherConfig>().CrateStatue * 10, statues[Main.rand.Next(statues.Count)]);
            }
            if (arg == ItemID.GoldenCrate)
                try_grab_bag_drop(GetInstance<IOtherConfig>().CrateStatue, statues[Main.rand.Next(statues.Count)]);
            if (arg == ItemID.IronCrate)
                try_grab_bag_drop(GetInstance<IOtherConfig>().CrateStatue * 3, statues[Main.rand.Next(statues.Count)]);
            if (arg == ItemID.WoodenCrate)
                try_grab_bag_drop(GetInstance<IOtherConfig>().CrateStatue * 10, statues[Main.rand.Next(statues.Count)]);

            //Boss Bag drops that don't happen in vanilla.
            if (arg == ItemID.FishronBossBag)
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().TrufflewormFromDukeFishron, ItemID.TruffleWorm);

            if (arg == ItemID.DestroyerBossBag || arg == ItemID.TwinsBossBag || arg == ItemID.SkeletronPrimeBossBag || arg == ItemID.PlanteraBossBag || arg == ItemID.GolemBossBag || arg == ItemID.FishronBossBag || arg == ItemID.MoonLordBossBag || arg == ItemID.FairyQueenBossBag)
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().TerragrimFromHardmodeGrabBag, ItemID.Terragrim);
        }
    }
}