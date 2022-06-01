using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
	public class Item : GlobalItem
	{
		public override void SetDefaults(Terraria.Item item)
		{
			int originalValue;
			if (item.type == ItemID.GreenCap)
			{
				item.value = Terraria.Item.buyPrice(0, 0, 2);
			}
			if (item.type == ItemID.Spike)
			{
				item.value = Terraria.Item.buyPrice(0, 0, 0, 20);
			}
			if (item.type == ItemID.WoodenSpike)
			{
				item.value = Terraria.Item.buyPrice(0, 0, 20);
			}
			//The items below assume that the configurations for all these drops are set to 100% (because GetModPlayer doesn't work here).
			if (item.type == ItemID.DyeTradersScimitar || item.type == ItemID.AleThrowingGlove || item.type == ItemID.StylistKilLaKillScissorsIWish || item.type == ItemID.TaxCollectorsStickOfDoom)
			{
				originalValue = item.value;
				item.value = (int)(originalValue * 0.125);
			}
			if (item.type == ItemID.PainterPaintballGun)
			{
				originalValue = item.value;
				item.value = (int)(originalValue * 0.1);
			}
			if (item.type == ItemID.PinkPricklyPear)
			{
				item.placeStyle = 0;
				item.createTile = TileID.Cactus;
			}
		}

        public override void ModifyTooltips(Terraria.Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.Sundial && GetInstance<IOtherConfig>().SleepBoostNoSundialMultiplier < 1)
            {
                TooltipLine tooltip = new TooltipLine(Mod, "Test","Place in the world to make time travel faster while sleeping.");
                tooltips.Add(tooltip);
            }
        }

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
            if (arg == ItemID.BrainOfCthulhuBossBag)
            {
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBoneRattleIncrease, ItemID.BoneRattle);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.BrainMask);
            }
            if (arg == ItemID.FishronBossBag)
            {
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootFishronWingsIncrease, ItemID.FishronWings);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.DukeFishronMask);
            }
            if (arg == ItemID.EaterOfWorldsBossBag)
            {
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootEatersBoneIncrease, ItemID.EatersBone);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.EaterMask);
            }
            if (arg == ItemID.EyeOfCthulhuBossBag)
            {
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBinocularsIncrease, ItemID.Binoculars);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.EyeMask);
            }
            if (arg == ItemID.PlanteraBossBag)
            {
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootTheAxeIncrease, ItemID.TheAxe);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootSeedlingIncrease, ItemID.Seedling);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.PlanteraMask);
            }
            if (arg == ItemID.QueenBeeBossBag)
            {
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootHoneyedGogglesIncrease, ItemID.HoneyedGoggles);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootNectarIncrease, ItemID.Nectar);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.BeeMask);
            }
            if (arg == ItemID.MoonLordBossBag)
            {
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.BossMaskMoonlord);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease, ItemID.Meowmere);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease, ItemID.Terrarian);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease, ItemID.StarWrath);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease, ItemID.SDMG);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease, ItemID.FireworksLauncher); //Celebration
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease, ItemID.LastPrism);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease, ItemID.LunarFlareBook);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease, ItemID.RainbowCrystalStaff);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease, ItemID.MoonlordTurretStaff); //Lunar Portal Staff
            }
            if (arg == ItemID.SkeletronBossBag)
            {
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBookofSkullsIncrease, ItemID.BookofSkulls);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootSkeletronBoneKey, ItemID.BoneKey);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.SkeletronMask);
            }
            if (arg == 3318) //King Slime
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.KingSlimeMask);
            if (arg == 3324) //Wall of Flesh
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.FleshMask);
            if (arg == 3325) //The Destroyer
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.DestroyerMask);
            if (arg == 3326) //The Twins
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.TwinMask);
            if (arg == 3327) //Skeletron Prime
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.SkeletronPrimeMask);
            if (arg == 3329) //Golem
            {
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.GolemMask);
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootPicksawIncrease, ItemID.Picksaw);
            }
            if (arg == 3860) //Betsy
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.BossMaskBetsy);

            //Other Grab Bags
            if (arg == ItemID.DungeonFishingCrate || arg == ItemID.DungeonFishingCrateHard)
            {
                List<int> dungeonFurniture = new List<int>() {
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
            if (arg == ItemID.GoldenCrate)
                try_grab_bag_drop(GetInstance<IOtherConfig>().CrateEnchantedSundial, ItemID.Sundial);
            if (arg == ItemID.IronCrateHard)
                try_grab_bag_drop(GetInstance<IOtherConfig>().CrateEnchantedSundial * 3, ItemID.Sundial);
            if (arg == ItemID.WoodenCrateHard)
                try_grab_bag_drop(GetInstance<IOtherConfig>().CrateEnchantedSundial * 10, ItemID.Sundial);

            //Boss Bag drops that don't happen in vanilla.
            if (arg == ItemID.FishronBossBag)
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootFishronTruffleworm, ItemID.TruffleWorm);
        }
    }
}