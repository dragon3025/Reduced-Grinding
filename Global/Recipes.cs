using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.GlobalRecipes
{
    class Recipes : ModSystem
    {
        public static RecipeGroup baitCritterLow;
        public static RecipeGroup baitCritterMed;
        public static RecipeGroup baitCritterHigh;

        public override void Unload()
        {
            baitCritterLow = null;
            baitCritterMed = null;
            baitCritterHigh = null;
        }

        public override void AddRecipeGroups()
        {
            baitCritterLow = new RecipeGroup(() => "Any bait critter with less than 20 Power", new int[]
            {
                ItemID.MonarchButterfly,
                ItemID.SulphurButterfly,
                ItemID.Grasshopper,
                ItemID.Scorpion,
                ItemID.Snail,
                ItemID.BlackScorpion,
                ItemID.HellButterfly,
                ItemID.ZebraSwallowtailButterfly,
                ItemID.GlowingSnail,
                ItemID.Grubby,
                ItemID.LadyBug,
                ItemID.WaterStrider
            });
            RecipeGroup.RegisterGroup("ReducedGrinding:baitCritterLow", baitCritterLow);

            baitCritterMed = new RecipeGroup(() => "Any bait critter with at least 20 Power and less than 25 Power", new int[]
            {
                ItemID.UlyssesButterfly,
                ItemID.BlackDragonfly,
                ItemID.BlueDragonfly,
                ItemID.GreenDragonfly,
                ItemID.OrangeDragonfly,
                ItemID.RedDragonfly,
                ItemID.YellowDragonfly,
                ItemID.Firefly,
                ItemID.BlueJellyfish,
                ItemID.GreenJellyfish,
                ItemID.PinkJellyfish,
                ItemID.Maggot
            });
            RecipeGroup.RegisterGroup("ReducedGrinding:baitCritterMed", baitCritterMed);

            baitCritterHigh = new RecipeGroup(() => "Any bait critter with at least 25 Power", new int[]
            {
                ItemID.JuliaButterfly,
                ItemID.Lavafly,
                ItemID.Sluggy,
                ItemID.Worm,
                ItemID.RedAdmiralButterfly,
                ItemID.PurpleEmperorButterfly,
                ItemID.EnchantedNightcrawler,
                ItemID.LightningBug,
                ItemID.MagmaSnail,
                ItemID.Buggy,
                ItemID.TreeNymphButterfly,
                ItemID.GoldButterfly,
                ItemID.GoldDragonfly,
                ItemID.GoldGrasshopper,
                ItemID.GoldLadyBug,
                ItemID.GoldWaterStrider,
                ItemID.GoldWorm
            });
            RecipeGroup.RegisterGroup("ReducedGrinding:baitCritterHigh", baitCritterHigh);
        }

        public override void AddRecipes()
        {
            #region Infection Key Switching
            Recipe recipe = Recipe.Create(ItemID.CrimsonKey);
            recipe.AddIngredient(ItemID.CorruptionKey);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.CorruptionKey);
            recipe.AddIngredient(ItemID.CrimsonKey);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
            #endregion

            #region Crate Downgrading
            recipe = Recipe.Create(ItemID.WoodenCrate);
            recipe.AddIngredient(ItemID.WoodenCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.LavaCrate);
            recipe.AddIngredient(ItemID.LavaCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.JungleFishingCrate);
            recipe.AddIngredient(ItemID.JungleFishingCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.FloatingIslandFishingCrate);
            recipe.AddIngredient(ItemID.FloatingIslandFishingCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.CorruptFishingCrate);
            recipe.AddIngredient(ItemID.CorruptFishingCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.CrimsonFishingCrate);
            recipe.AddIngredient(ItemID.CrimsonFishingCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.HallowedFishingCrate);
            recipe.AddIngredient(ItemID.HallowedFishingCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.DungeonFishingCrate);
            recipe.AddIngredient(ItemID.DungeonFishingCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.FrozenCrate);
            recipe.AddIngredient(ItemID.FrozenCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.OasisCrate);
            recipe.AddIngredient(ItemID.OasisCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.OceanCrate);
            recipe.AddIngredient(ItemID.OceanCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.IronCrate);
            recipe.AddIngredient(ItemID.IronCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.GoldenCrate);
            recipe.AddIngredient(ItemID.GoldenCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
            #endregion

            #region Traps
            recipe = Recipe.Create(ItemID.DartTrap);
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddIngredient(ItemID.PoisonDart);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.Register();

            recipe = Recipe.Create(ItemID.Spike);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar);
            recipe.AddTile(TileID.BoneWelder);
            recipe.Register();

            recipe = Recipe.Create(ItemID.GeyserTrap);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddIngredient(ItemID.WaterBucket);
            recipe.AddIngredient(ItemID.LivingFireBlock);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.AddCondition(Recipe.Condition.InUnderworldHeight);
            recipe.Register();

            recipe = Recipe.Create(ItemID.WoodenSpike);
            recipe.AddIngredient(ItemID.RichMahogany);
            recipe.AddTile(TileID.LihzahrdFurnace);
            recipe.Register();

            recipe = Recipe.Create(ItemID.FlameTrap);
            recipe.AddIngredient(ItemID.LihzahrdBrick);
            recipe.AddIngredient(ItemID.LivingFireBlock);
            recipe.AddTile(TileID.LihzahrdFurnace);
            recipe.Register();

            recipe = Recipe.Create(ItemID.SpearTrap);
            recipe.AddIngredient(ItemID.LihzahrdBrick);
            recipe.AddIngredient(ItemID.WoodenSpike);
            recipe.AddIngredient(ItemID.RichMahogany, 10);
            recipe.AddTile(TileID.LihzahrdFurnace);
            recipe.Register();

            recipe = Recipe.Create(ItemID.SpikyBallTrap);
            recipe.AddIngredient(ItemID.LihzahrdBrick);
            recipe.AddIngredient(ItemID.WoodenSpike);
            recipe.AddIngredient(ItemID.PinkGel);
            recipe.AddTile(TileID.LihzahrdFurnace);
            recipe.Register();

            recipe = Recipe.Create(ItemID.SuperDartTrap);
            recipe.AddIngredient(ItemID.LihzahrdBrick);
            recipe.AddIngredient(ItemID.PoisonDart);
            recipe.AddTile(TileID.LihzahrdAltar);
            recipe.Register();
            #endregion

            #region Tinker's Accessory Downgrading
            int[] fartInAJarAccessory = new int[]
            {
                ItemID.BalloonHorseshoeFart,
                ItemID.FartInABalloon,
                ItemID.FartinaJar
            };

            foreach (int i in fartInAJarAccessory)
            {
                recipe = Recipe.Create(ItemID.CloudinaBottle);
                recipe.AddIngredient(i);
                recipe.AddTile(TileID.TinkerersWorkbench);
                recipe.Register();
            }

            recipe = Recipe.Create(ItemID.HoneyComb);
            recipe.AddIngredient(ItemID.HoneyBalloon);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();

            int[] horseshoeAccessory = new int[]
            {
                ItemID.BalloonHorseshoeFart,
                ItemID.BalloonHorseshoeHoney,
                ItemID.BalloonHorseshoeSharkron,
                ItemID.BlueHorseshoeBalloon,
                ItemID.ObsidianHorseshoe,
                ItemID.WhiteHorseshoeBalloon,
                ItemID.YellowHorseshoeBalloon
            };

            foreach (int i in horseshoeAccessory)
            {
                recipe = Recipe.Create(ItemID.LuckyHorseshoe);
                recipe.AddIngredient(i);
                recipe.AddTile(TileID.TinkerersWorkbench);
                recipe.Register();
            }

            int[] altBalloons = new int[]
            {
                ItemID.HoneyBalloon,
                ItemID.BalloonHorseshoeHoney,
                ItemID.FartInABalloon,
                ItemID.BalloonHorseshoeFart
            };

            foreach (int i in altBalloons)
            {
                recipe = Recipe.Create(ItemID.ShinyRedBalloon);
                recipe.AddIngredient(i);
                recipe.AddTile(TileID.TinkerersWorkbench);
                recipe.Register();
            }

            recipe = Recipe.Create(ItemID.SandstorminaBalloon);
            recipe.AddIngredient(ItemID.YellowHorseshoeBalloon);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlizzardinaBalloon);
            recipe.AddIngredient(ItemID.WhiteHorseshoeBalloon);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();

            recipe = Recipe.Create(ItemID.CloudinaBalloon);
            recipe.AddIngredient(ItemID.BlueHorseshoeBalloon);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();

            recipe = Recipe.Create(ItemID.ObsidianSkull);
            recipe.AddIngredient(ItemID.ObsidianHorseshoe);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
            #endregion

            #region Dungeon Bricks and Platforms
            recipe = Recipe.Create(ItemID.BlueBrick);
            recipe.AddIngredient(ItemID.GreenBrick);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlueBrick);
            recipe.AddIngredient(ItemID.PinkBrick);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.GreenBrick);
            recipe.AddIngredient(ItemID.BlueBrick);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.GreenBrick);
            recipe.AddIngredient(ItemID.PinkBrick);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.PinkBrick);
            recipe.AddIngredient(ItemID.BlueBrick);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.PinkBrick);
            recipe.AddIngredient(ItemID.GreenBrick);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlueBrick);
            recipe.AddIngredient(ItemID.BlueBrickPlatform, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            recipe = Recipe.Create(ItemID.GreenBrick);
            recipe.AddIngredient(ItemID.GreenBrickPlatform, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            recipe = Recipe.Create(ItemID.PinkBrick);
            recipe.AddIngredient(ItemID.PinkBrickPlatform, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlueBrickPlatform, 2);
            recipe.AddIngredient(ItemID.BlueBrick);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            recipe = Recipe.Create(ItemID.GreenBrickPlatform, 2);
            recipe.AddIngredient(ItemID.GreenBrick);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            recipe = Recipe.Create(ItemID.PinkBrickPlatform, 2);
            recipe.AddIngredient(ItemID.PinkBrick);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
            #endregion

            //TO-DO Remove when 1.4.4+ adds these
            recipe = Recipe.Create(ItemID.SandstorminaBottle);
            recipe.AddIngredient(ItemID.CloudinaBottle);
            recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlizzardinaBottle);
            recipe.AddIngredient(ItemID.CloudinaBottle);
            recipe.AddIngredient(ItemID.FrostCore);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            //Crystal Ball as Shimmer (Remove when 1.4.4+ comes out)
            recipe = Recipe.Create(ItemID.BabyBirdStaff);
            recipe.AddIngredient(ItemID.LivingWoodWand);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PharaohsMask);
            recipe.AddIngredient(ItemID.SandstorminaBottle);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PharaohsRobe);
            recipe.AddIngredient(ItemID.FlyingCarpet);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            //TO-DO when 1.4.4+ comes out, convert this into a shimmer transmutation if possible
            recipe = Recipe.Create(ItemID.SandstorminaBottle);
            recipe.AddIngredient(ItemID.PharaohsMask);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.FlyingCarpet);
            recipe.AddIngredient(ItemID.PharaohsRobe);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.SunflowerMinecart);
            recipe.AddIngredient(ItemID.LeafWand);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.LadybugMinecart);
            recipe.AddIngredient(ItemID.SunflowerMinecart);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.SunflowerMinecart);
            recipe.AddIngredient(ItemID.LadybugMinecart);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            if (GetInstance<CFishingConfig>().MultiBobberPotionBonus > 0)
            {
                recipe = Recipe.Create(ItemType<Items.BuffPotions.MultiBobberPotion>());
                recipe.AddIngredient(ItemID.BottledWater);
                recipe.AddIngredient(ItemID.Waterleaf);
                recipe.AddRecipeGroup("ReducedGrinding:baitCritterLow");
                recipe.AddRecipeGroup("ReducedGrinding:baitCritterMed");
                recipe.AddRecipeGroup("ReducedGrinding:baitCritterHigh");
                recipe.AddTile(TileID.Bottles);
                recipe.Register();
            }

            #region Other
            if (GetInstance<IOtherConfig>().CraftableUniversalPylon > 0)
            {
                recipe = Recipe.Create(ItemID.TeleportationPylonVictory);
                recipe.AddIngredient(ItemID.TeleportationPylonDesert);
                recipe.AddIngredient(ItemID.TeleportationPylonHallow);
                recipe.AddIngredient(ItemID.TeleportationPylonJungle);
                recipe.AddIngredient(ItemID.TeleportationPylonMushroom);
                recipe.AddIngredient(ItemID.TeleportationPylonOcean);
                recipe.AddIngredient(ItemID.TeleportationPylonPurity);
                recipe.AddIngredient(ItemID.TeleportationPylonSnow);
                recipe.AddIngredient(ItemID.TeleportationPylonUnderground);
                if (GetInstance<IOtherConfig>().CraftableUniversalPylon == 3)
                {
                    recipe.AddIngredient(ItemID.SoulofLight);
                    recipe.AddIngredient(ItemID.SoulofNight);
                    recipe.AddIngredient(ItemID.SoulofFlight);
                    recipe.AddIngredient(ItemID.SoulofFright);
                    recipe.AddIngredient(ItemID.SoulofMight);
                    recipe.AddIngredient(ItemID.SoulofSight);
                }
                if (GetInstance<IOtherConfig>().CraftableUniversalPylon > 1)
                    recipe.AddTile(TileID.CrystalBall);
                else
                    recipe.AddTile(TileID.TinkerersWorkbench);
                recipe.Register();
            }
            #endregion

            #region Disabled by Default

            #region Golden Critters
            if (GetInstance<IOtherConfig>().CraftableGoldCritters)
            {
                recipe = Recipe.Create(ItemID.GoldBird);
                recipe.AddRecipeGroup(RecipeGroupID.Birds);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldBunny);
                recipe.AddIngredient(ItemID.Bunny);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldButterfly);
                recipe.AddRecipeGroup(RecipeGroupID.Butterflies);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldDragonfly);
                recipe.AddRecipeGroup(RecipeGroupID.Dragonflies);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldFrog);
                recipe.AddIngredient(ItemID.Frog);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldGoldfish);
                recipe.AddIngredient(ItemID.Goldfish);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldGrasshopper);
                recipe.AddIngredient(ItemID.Grasshopper);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldLadyBug);
                recipe.AddIngredient(ItemID.LadyBug);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldMouse);
                recipe.AddIngredient(ItemID.Mouse);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldSeahorse);
                recipe.AddIngredient(ItemID.Seahorse);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Recipe.Create(ItemID.SquirrelGold);
                recipe.AddRecipeGroup(RecipeGroupID.Squirrels);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldWaterStrider);
                recipe.AddIngredient(ItemID.WaterStrider);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldWorm);
                recipe.AddIngredient(ItemID.Worm);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();
            }
            #endregion

            #region Craftable Rare Chests
            if (GetInstance<IOtherConfig>().CraftableRareChests)
            {
                recipe = Recipe.Create(ItemID.IvyChest);
                recipe.AddIngredient(ItemID.RichMahogany, 8);
                recipe.AddRecipeGroup(RecipeGroupID.IronBar, 2);
                recipe.AddTile(TileID.WorkBenches);
                recipe.Register();

                recipe = Recipe.Create(ItemID.WaterChest);
                recipe.AddIngredient(ItemID.Coral, 2);
                recipe.AddRecipeGroup(RecipeGroupID.IronBar, 2);
                recipe.AddTile(TileID.WorkBenches);
                recipe.Register();

                recipe = Recipe.Create(ItemID.WebCoveredChest);
                recipe.AddIngredient(ItemID.Cobweb, 5);
                recipe.AddIngredient(ItemID.Chest);
                recipe.AddTile(TileID.WorkBenches);
                recipe.Register();

                recipe = Recipe.Create(ItemID.CrimsonChest, 2);
                recipe.AddIngredient(ItemID.CrimsonChest);
                recipe.AddIngredient(ItemID.CrimsonKey);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Recipe.Create(ItemID.CorruptionChest, 2);
                recipe.AddIngredient(ItemID.CorruptionChest);
                recipe.AddIngredient(ItemID.CorruptionKey);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Recipe.Create(ItemID.HallowedChest, 2);
                recipe.AddIngredient(ItemID.HallowedChest);
                recipe.AddIngredient(ItemID.HallowedKey);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Recipe.Create(ItemID.IceChest, 2);
                recipe.AddIngredient(ItemID.IceChest);
                recipe.AddIngredient(ItemID.FrozenKey);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Recipe.Create(ItemID.JungleChest, 2);
                recipe.AddIngredient(ItemID.JungleChest);
                recipe.AddIngredient(ItemID.JungleKey);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Recipe.Create(ItemID.DesertChest, 2);
                recipe.AddIngredient(ItemID.DesertChest);
                recipe.AddIngredient(ItemID.DungeonDesertKey);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();
            }
            #endregion
            #endregion
        }


        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasResult(ItemID.CelestialSigil)) //Easier Celestial Sigil TO-DO (Remove once 1.4.4+ comes out).
                {
                    int[] fragments = new int[4]
                    {
                        ItemID.FragmentNebula,
                        ItemID.FragmentSolar,
                        ItemID.FragmentStardust,
                        ItemID.FragmentVortex
                    };
                    foreach (int j in fragments)
                    {
                        recipe.RemoveIngredient(j);
                        recipe.AddIngredient(j, 12);
                    }
                }

                int infectionPowderPerMushroom = GetInstance<IOtherConfig>().InfectionPowderPerMushroom;
                if (infectionPowderPerMushroom > 5)
                {
                    if (recipe.HasResult(ItemID.VilePowder))
                        recipe.ReplaceResult(ItemID.VilePowder, infectionPowderPerMushroom);

                    if (recipe.HasResult(ItemID.ViciousPowder))
                        recipe.ReplaceResult(ItemID.ViciousPowder, infectionPowderPerMushroom);
                }
            }
        }

    }
}
