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

            //Remove when 1.4.4+ Adds these
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

            recipe = Recipe.Create(ItemID.MagicMirror);
            recipe.AddIngredient(ItemID.Glass, 10);
            recipe.AddIngredient(ItemID.GoldBar, 8);
            recipe.AddIngredient(ItemID.Diamond, 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();

            recipe = Recipe.Create(ItemID.MagicMirror);
            recipe.AddIngredient(ItemID.Glass, 10);
            recipe.AddIngredient(ItemID.PlatinumBar, 8);
            recipe.AddIngredient(ItemID.Diamond, 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();

            //Crystal Ball as Shimmer (Remove these when 1.4.4+ comes out)
            #region Shimmer-Like Recipes


            #region Tinker's Accessory Downgrading
            //This mimics de-crafting. Unfortunatley it's not perfect, I can't output more than 1 item.
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
                recipe.AddTile(TileType<Tiles.ShimmeringStar>());
                recipe.Register();
            }

            recipe = Recipe.Create(ItemID.HoneyComb);
            recipe.AddIngredient(ItemID.HoneyBalloon);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
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
                recipe.AddTile(TileType<Tiles.ShimmeringStar>());
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
                recipe.AddTile(TileType<Tiles.ShimmeringStar>());
                recipe.Register();
            }

            recipe = Recipe.Create(ItemID.SandstorminaBalloon);
            recipe.AddIngredient(ItemID.YellowHorseshoeBalloon);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlizzardinaBalloon);
            recipe.AddIngredient(ItemID.WhiteHorseshoeBalloon);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.CloudinaBalloon);
            recipe.AddIngredient(ItemID.BlueHorseshoeBalloon);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.ObsidianSkull);
            recipe.AddIngredient(ItemID.ObsidianHorseshoe);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();
            #endregion

            #region Buckets
            recipe = Recipe.Create(ItemID.HoneyBucket);
            recipe.AddIngredient(ItemID.LavaBucket);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.LavaBucket);
            recipe.AddIngredient(ItemID.WaterBucket);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.WaterBucket);
            recipe.AddIngredient(ItemID.HoneyBucket);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();
            #endregion

            recipe = Recipe.Create(ItemID.Trident);
            recipe.AddIngredient(ItemID.Spear);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.BabyBirdStaff);
            recipe.AddIngredient(ItemID.LivingWoodWand);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            #region Dungeon Defenders
            recipe = Recipe.Create(ItemID.DD2BallistraTowerT1Popper);
            recipe.AddIngredient(ItemID.DD2FlameburstTowerT1Popper);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.DD2BallistraTowerT2Popper);
            recipe.AddIngredient(ItemID.DD2FlameburstTowerT2Popper);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.DD2BallistraTowerT3Popper);
            recipe.AddIngredient(ItemID.DD2FlameburstTowerT3Popper);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.DD2ExplosiveTrapT1Popper);
            recipe.AddIngredient(ItemID.DD2BallistraTowerT1Popper);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.DD2ExplosiveTrapT2Popper);
            recipe.AddIngredient(ItemID.DD2BallistraTowerT2Popper);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.DD2ExplosiveTrapT3Popper);
            recipe.AddIngredient(ItemID.DD2BallistraTowerT3Popper);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.DD2LightningAuraT1Popper);
            recipe.AddIngredient(ItemID.DD2ExplosiveTrapT1Popper);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.DD2LightningAuraT2Popper);
            recipe.AddIngredient(ItemID.DD2ExplosiveTrapT2Popper);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.DD2LightningAuraT3Popper);
            recipe.AddIngredient(ItemID.DD2ExplosiveTrapT3Popper);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.DD2FlameburstTowerT1Popper);
            recipe.AddIngredient(ItemID.DD2LightningAuraT1Popper);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.DD2FlameburstTowerT2Popper);
            recipe.AddIngredient(ItemID.DD2LightningAuraT2Popper);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.DD2FlameburstTowerT3Popper);
            recipe.AddIngredient(ItemID.DD2LightningAuraT3Popper);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();
            #endregion

            #region Armor
            recipe = Recipe.Create(ItemID.MiningPants);
            recipe.AddIngredient(ItemID.MiningShirt);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.MiningShirt);
            recipe.AddIngredient(ItemID.MiningPants);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.AncientIronHelmet);
            recipe.AddIngredient(ItemID.IronHelmet);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.IronHelmet);
            recipe.AddIngredient(ItemID.AncientIronHelmet);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.AncientGoldHelmet);
            recipe.AddIngredient(ItemID.GoldHelmet);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.GoldHelmet);
            recipe.AddIngredient(ItemID.AncientGoldHelmet);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.AncientCobaltHelmet);
            recipe.AddIngredient(ItemID.JungleHat);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.AncientCobaltBreastplate);
            recipe.AddIngredient(ItemID.JungleShirt);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.AncientCobaltLeggings);
            recipe.AddIngredient(ItemID.JunglePants);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.AncientNecroHelmet);
            recipe.AddIngredient(ItemID.NecroHelmet);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.NecroHelmet);
            recipe.AddIngredient(ItemID.AncientNecroHelmet);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.AncientShadowHelmet);
            recipe.AddIngredient(ItemID.ShadowHelmet);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.AncientShadowScalemail);
            recipe.AddIngredient(ItemID.ShadowScalemail);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.AncientShadowGreaves);
            recipe.AddIngredient(ItemID.ShadowGreaves);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.ShadowHelmet);
            recipe.AddIngredient(ItemID.AncientShadowHelmet);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.ShadowScalemail);
            recipe.AddIngredient(ItemID.AncientShadowScalemail);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.ShadowGreaves);
            recipe.AddIngredient(ItemID.AncientShadowGreaves);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.AncientHallowedMask);
            recipe.AddIngredient(ItemID.HallowedMask);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.AncientHallowedHelmet);
            recipe.AddIngredient(ItemID.HallowedHelmet);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.AncientHallowedHeadgear);
            recipe.AddIngredient(ItemID.HallowedHeadgear);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.AncientHallowedHood);
            recipe.AddIngredient(ItemID.HallowedHood);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.AncientHallowedPlateMail);
            recipe.AddIngredient(ItemID.HallowedPlateMail);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.AncientHallowedGreaves);
            recipe.AddIngredient(ItemID.HallowedGreaves);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.HallowedMask);
            recipe.AddIngredient(ItemID.AncientHallowedMask);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.HallowedHelmet);
            recipe.AddIngredient(ItemID.AncientHallowedHelmet);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.HallowedHeadgear);
            recipe.AddIngredient(ItemID.AncientHallowedHeadgear);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.HallowedHood);
            recipe.AddIngredient(ItemID.AncientHallowedHood);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.HallowedPlateMail);
            recipe.AddIngredient(ItemID.AncientHallowedPlateMail);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.HallowedGreaves);
            recipe.AddIngredient(ItemID.AncientHallowedGreaves);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();
            #endregion

            recipe = Recipe.Create(ItemID.BewitchingTable);
            recipe.AddIngredient(ItemID.AlchemyTable);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.AlchemyTable);
            recipe.AddIngredient(ItemID.BewitchingTable);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            #region Biome Chests
            recipe = Recipe.Create(ItemID.CorruptionChest);
            recipe.AddIngredient(ItemID.CorruptionKey);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.CrimsonChest);
            recipe.AddIngredient(ItemID.CrimsonKey);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.HallowedChest);
            recipe.AddIngredient(ItemID.HallowedKey);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.IceChest);
            recipe.AddIngredient(ItemID.FrozenKey);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.JungleChest);
            recipe.AddIngredient(ItemID.JungleKey);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.DesertChest);
            recipe.AddIngredient(ItemID.DungeonDesertKey);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();
            #endregion

            #region Crates
            recipe = Recipe.Create(ItemID.WoodenCrate);
            recipe.AddIngredient(ItemID.WoodenCrateHard);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.IronCrate);
            recipe.AddIngredient(ItemID.IronCrateHard);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.GoldenCrate);
            recipe.AddIngredient(ItemID.GoldenCrateHard);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.JungleFishingCrate);
            recipe.AddIngredient(ItemID.JungleFishingCrateHard);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.FloatingIslandFishingCrate);
            recipe.AddIngredient(ItemID.FloatingIslandFishingCrateHard);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.CorruptFishingCrate);
            recipe.AddIngredient(ItemID.CorruptFishingCrateHard);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.CrimsonFishingCrate);
            recipe.AddIngredient(ItemID.CrimsonFishingCrateHard);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.HallowedFishingCrate);
            recipe.AddIngredient(ItemID.HallowedFishingCrateHard);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.DungeonFishingCrate);
            recipe.AddIngredient(ItemID.DungeonFishingCrateHard);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.FrozenCrate);
            recipe.AddIngredient(ItemID.FrozenCrateHard);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.OasisCrate);
            recipe.AddIngredient(ItemID.OasisCrateHard);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.LavaCrate);
            recipe.AddIngredient(ItemID.LavaCrateHard);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.OceanCrate);
            recipe.AddIngredient(ItemID.OceanCrateHard);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();
            #endregion

            recipe = Recipe.Create(ItemID.CanOfWorms);
            recipe.AddIngredient(ItemID.HerbBag);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            #region Accessories
            recipe = Recipe.Create(ItemID.HerbBag);
            recipe.AddIngredient(ItemID.CanOfWorms);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.ShinyRedBalloon);
            recipe.AddIngredient(ItemID.BalloonPufferfish);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.SandstorminaBottle);
            recipe.AddIngredient(ItemID.PharaohsMask);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.FlyingCarpet);
            recipe.AddIngredient(ItemID.PharaohsRobe);
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

            recipe = Recipe.Create(ItemID.LavaCharm);
            recipe.AddIngredient(ItemID.MagmaStone);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.FishermansGuide);
            recipe.AddIngredient(ItemID.WeatherRadio);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Sextant);
            recipe.AddIngredient(ItemID.FishermansGuide);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.WeatherRadio);
            recipe.AddIngredient(ItemID.Sextant);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Bezoar);
            recipe.AddIngredient(ItemID.AdhesiveBandage);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.AdhesiveBandage);
            recipe.AddIngredient(ItemID.Bezoar);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.ArmorPolish);
            recipe.AddIngredient(ItemID.Vitamins);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Vitamins);
            recipe.AddIngredient(ItemID.ArmorPolish);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PocketMirror);
            recipe.AddIngredient(ItemID.Blindfold);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Blindfold);
            recipe.AddIngredient(ItemID.PocketMirror);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.TrifoldMap);
            recipe.AddIngredient(ItemID.FastClock);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.FastClock);
            recipe.AddIngredient(ItemID.TrifoldMap);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Nazar);
            recipe.AddIngredient(ItemID.Megaphone);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Megaphone);
            recipe.AddIngredient(ItemID.Nazar);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.WarriorEmblem);
            recipe.AddIngredient(ItemID.SummonerEmblem);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.RangerEmblem);
            recipe.AddIngredient(ItemID.WarriorEmblem);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.SorcererEmblem);
            recipe.AddIngredient(ItemID.RangerEmblem);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.SummonerEmblem);
            recipe.AddIngredient(ItemID.SorcererEmblem);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.AnglerEarring);
            recipe.AddIngredient(ItemID.HighTestFishingLine);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.TackleBox);
            recipe.AddIngredient(ItemID.AnglerEarring);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.HighTestFishingLine);
            recipe.AddIngredient(ItemID.TackleBox);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.GoldRing);
            recipe.AddIngredient(ItemID.LuckyCoin);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.DiscountCard);
            recipe.AddIngredient(ItemID.GoldRing);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.LuckyCoin);
            recipe.AddIngredient(ItemID.DiscountCard);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();
            #endregion

            recipe = Recipe.Create(ItemID.DirtBlock);
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.DirtBlock);
            recipe.AddIngredient(ItemID.Wood);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.StoneBlock);
            recipe.AddIngredient(ItemID.CopperOre);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.StoneBlock);
            recipe.AddIngredient(ItemID.Amethyst);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.GraniteBlock);
            recipe.AddIngredient(ItemID.MarbleBlock);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.MarbleBlock);
            recipe.AddIngredient(ItemID.GraniteBlock);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            #region Sand
            recipe = Recipe.Create(ItemID.SandBlock);
            recipe.AddIngredient(ItemID.Sandstone);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.SandBlock);
            recipe.AddIngredient(ItemID.HardenedSand);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.EbonsandBlock);
            recipe.AddIngredient(ItemID.EbonstoneBlock);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.EbonsandBlock);
            recipe.AddIngredient(ItemID.CorruptHardenedSand);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.CrimsandBlock);
            recipe.AddIngredient(ItemID.CrimstoneBlock);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.CrimsandBlock);
            recipe.AddIngredient(ItemID.CrimsonHardenedSand);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PearlsandBlock);
            recipe.AddIngredient(ItemID.PearlstoneBlock);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PearlsandBlock);
            recipe.AddIngredient(ItemID.HallowHardenedSand);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();
            #endregion

            recipe = Recipe.Create(ItemID.SnowBlock);
            recipe.AddIngredient(ItemID.IceBlock);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Hive);
            recipe.AddIngredient(ItemID.HoneyBlock);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Hive);
            recipe.AddIngredient(ItemID.CrispyHoneyBlock);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            #region Wood
            recipe = Recipe.Create(ItemID.Wood);
            recipe.AddIngredient(ItemID.RichMahogany);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Wood);
            recipe.AddIngredient(ItemID.Ebonwood);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Wood);
            recipe.AddIngredient(ItemID.Shadewood);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Wood);
            recipe.AddIngredient(ItemID.Pearlwood);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Wood);
            recipe.AddIngredient(ItemID.BorealWood);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Wood);
            recipe.AddIngredient(ItemID.PalmWood);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Wood);
            recipe.AddIngredient(ItemID.DynastyWood);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Wood);
            recipe.AddIngredient(ItemID.SpookyWood);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();
            #endregion

            recipe = Recipe.Create(ItemID.Pumpkin);
            recipe.AddIngredient(ItemID.Cactus);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Cactus);
            recipe.AddIngredient(ItemID.Pumpkin);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            //TO-DO What happened here? There's a duplicate recipes, was something else supposed to go here?
            recipe = Recipe.Create(ItemID.Cactus);
            recipe.AddIngredient(ItemID.Pumpkin);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            #region Downgrading Ores
            recipe = Recipe.Create(ItemID.CopperOre);
            recipe.AddIngredient(ItemID.TinOre);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.TinOre);
            recipe.AddIngredient(ItemID.IronOre);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.IronOre);
            recipe.AddIngredient(ItemID.LeadOre);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.LeadOre);
            recipe.AddIngredient(ItemID.SilverOre);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.SilverOre);
            recipe.AddIngredient(ItemID.TungstenOre);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.TungstenOre);
            recipe.AddIngredient(ItemID.GoldOre);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.GoldOre);
            recipe.AddIngredient(ItemID.PlatinumOre);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PlatinumOre);
            recipe.AddIngredient(ItemID.CobaltOre);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.CobaltOre);
            recipe.AddIngredient(ItemID.PalladiumOre);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PalladiumOre);
            recipe.AddIngredient(ItemID.MythrilOre);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.MythrilOre);
            recipe.AddIngredient(ItemID.OrichalcumOre);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.OrichalcumOre);
            recipe.AddIngredient(ItemID.AdamantiteOre);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.AdamantiteOre);
            recipe.AddIngredient(ItemID.TitaniumOre);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.TitaniumOre);
            recipe.AddIngredient(ItemID.ChlorophyteOre);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.ChlorophyteOre);
            recipe.AddIngredient(ItemID.LunarOre);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();
            #endregion

            #region Downgrading Gems and Gem Critters
            recipe = Recipe.Create(ItemID.Amethyst);
            recipe.AddIngredient(ItemID.Topaz);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Amethyst);
            recipe.AddIngredient(ItemID.GemBunnyAmethyst);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Amethyst);
            recipe.AddIngredient(ItemID.GemSquirrelAmethyst);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Topaz);
            recipe.AddIngredient(ItemID.Sapphire);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Topaz);
            recipe.AddIngredient(ItemID.GemBunnyTopaz);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Topaz);
            recipe.AddIngredient(ItemID.GemSquirrelTopaz);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Sapphire);
            recipe.AddIngredient(ItemID.Emerald);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Sapphire);
            recipe.AddIngredient(ItemID.GemBunnySapphire);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Sapphire);
            recipe.AddIngredient(ItemID.GemSquirrelSapphire);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Emerald);
            recipe.AddIngredient(ItemID.Ruby);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Emerald);
            recipe.AddIngredient(ItemID.GemBunnyEmerald);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Emerald);
            recipe.AddIngredient(ItemID.GemSquirrelEmerald);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Ruby);
            recipe.AddIngredient(ItemID.Diamond);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Ruby);
            recipe.AddIngredient(ItemID.GemBunnyRuby);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Ruby);
            recipe.AddIngredient(ItemID.GemSquirrelRuby);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Diamond);
            recipe.AddIngredient(ItemID.GemBunnyDiamond);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Diamond);
            recipe.AddIngredient(ItemID.GemSquirrelDiamond);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Amber);
            recipe.AddIngredient(ItemID.GemBunnyAmber);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.Amber);
            recipe.AddIngredient(ItemID.GemSquirrelAmber);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();
            #endregion

            recipe = Recipe.Create(ItemID.MushroomGrassSeeds);
            recipe.AddIngredient(ItemID.JungleGrassSeeds);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.JungleGrassSeeds);
            recipe.AddIngredient(ItemID.MushroomGrassSeeds);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PurificationPowder);
            recipe.AddIngredient(ItemID.VilePowder);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PurificationPowder);
            recipe.AddIngredient(ItemID.ViciousPowder);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.WhoopieCushion);
            recipe.AddIngredient(ItemID.ZombieArm);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();
            #endregion

            //TO-DO when 1.4.4+ comes out, convert this into a shimmer transmutation if possible
            #region Shimmer-Like Recipes not existing in 1.4.4+
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
            #endregion

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
            }
        }
    }
}
