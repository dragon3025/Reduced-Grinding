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

            //Crates
            if (arg == 3205) //Dungeon Crate
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateDungeonBoneWelder, ItemID.BoneWelder);
            if (arg == ItemID.JungleFishingCrate)
            {
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleSeaweed, ItemID.Seaweed);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleFlowerBoots, ItemID.FlowerBoots);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleLivingMahoganyWand, ItemID.LivingMahoganyWand);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleRichMahoganyLeafWand, ItemID.LivingMahoganyLeafWand);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleLivingLoom, ItemID.LivingLoom);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleLeafWand, ItemID.LeafWand);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleLivingWoodWand, ItemID.LivingWoodWand);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleAnkeltOfTheWindIncrease, ItemID.AnkletoftheWind);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleFeralClawsIncrease, ItemID.FeralClaws);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleStaffOfRegrowth, ItemID.StaffofRegrowth);
            }
            if (arg == 3206) //Sky Crate
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateSkySkyMill, ItemID.SkyMill);
            if (arg == ItemID.WoodenCrate)
            {
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateWoodenClimbingClawsIncrease, ItemID.ClimbingClaws);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateWoodenRadarIncrease, ItemID.Radar);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateWoodenAgletIncrease, ItemID.Aglet);
            }
            if (arg == ItemID.WoodenCrate)
            {
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateWaterWalkingBootsWooden, ItemID.WaterWalkingBoots);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateFlippersWooden, ItemID.Flipper);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateEnchantedSundialWoodenIncrease, ItemID.Sundial);
            }
            if (arg == ItemID.IronCrate)
            {
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateWaterWalkingBootsIron, ItemID.WaterWalkingBoots);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateFlippersIron, ItemID.Flipper);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateEnchantedSundialIronIncrease, ItemID.Sundial);
            }
            if (arg == ItemID.GoldenCrate)
            {
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateWaterWalkingBootsGolden, ItemID.WaterWalkingBoots);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateFlippersGolden, ItemID.Flipper);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateEnchantedSundialGoldenIncrease, ItemID.Sundial);
            }
            if (context == "present")
            {
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentDogWhistle, ItemID.DogWhistle);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentToolbox, ItemID.Toolbox);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentHandWarmer, ItemID.HandWarmer);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentCandyCanePickaxe, ItemID.CnadyCanePickaxe);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentCandyCaneHook, ItemID.CandyCaneHook);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentFruitcakeChakram, ItemID.FruitcakeChakram);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentRedRyderPlusMusketBall, ItemID.RedRyder);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentRedRyderPlusMusketBall, ItemID.Musket, Main.rand.Next(30, 60));
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentCandyCaneSword, ItemID.CandyCaneSword);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentMrsClausCostume, ItemID.MrsClauseHat);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentMrsClausCostume, ItemID.MrsClauseHeels);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentMrsClausCostume, ItemID.MrsClauseShirt);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentParkaOutfit, ItemID.ParkaCoat);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentParkaOutfit, ItemID.ParkaHood);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentParkaOutfit, ItemID.ParkaPants);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentTreeCostume, ItemID.TreeMask);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentTreeCostume, ItemID.TreeShirt);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentTreeCostume, ItemID.TreeTrunks);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentSnowHat, ItemID.SnowHat);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentUglySweater, ItemID.UglySweater);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentReindeerAntlers, ItemID.ReindeerAntlers);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentCoal, ItemID.Coal);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentChristmasPudding, ItemID.ChristmasPudding);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentSugarCookie, ItemID.SugarCookie);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentGingerbreadCookie, ItemID.GingerbreadCookie);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentStarAnise, ItemID.StarAnise, Main.rand.Next(20, 40));
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentEggnog, ItemID.Eggnog, Main.rand.Next(1, 3));
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentHolly, ItemID.Holly);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentHolly, 1908);
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentPineTreeBlock, ItemID.PineTreeBlock, Main.rand.Next(20, 49));
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentCandyCaneBlock, ItemID.CandyCaneBlock, Main.rand.Next(20, 49));
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentGreenCandyCaneBlock, ItemID.GreenCandyCaneBlock, Main.rand.Next(20, 49));
                try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentHardmodeSnowGlobe, ItemID.SnowGlobe);
            }

            //Boss Bag drops that don't happen in vanilla.
            if (arg == ItemID.FishronBossBag)
                try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootFishronTruffleworm, ItemID.TruffleWorm);
        }
    }
}