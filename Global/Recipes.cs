using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
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
            baitCritterLow = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " bait critter with less than 20 Power.", new int[]
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

            baitCritterMed = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " bait critter with at least 20 Power and less than 25 Power.", new int[]
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

            baitCritterHigh = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " bait critter with at least 25 Power.", new int[]
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
            //Easier Celestial Sigil TO-DO (Remove once 1.4.4 comes out).
            Recipe recipe = Mod.CreateRecipe(ItemID.CelestialSigil);
            recipe.AddIngredient(ItemID.FragmentSolar, 12);
            recipe.AddIngredient(ItemID.FragmentVortex, 12);
            recipe.AddIngredient(ItemID.FragmentNebula, 12);
            recipe.AddIngredient(ItemID.FragmentStardust, 12);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();

            //Infection Key Switching
            recipe = Mod.CreateRecipe(ItemID.CrimsonKey);
            recipe.AddIngredient(ItemID.CorruptionKey);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.CorruptionKey);
            recipe.AddIngredient(ItemID.CrimsonKey);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            //Golden Critters (Disabled by Default)
            if (GetInstance<IOtherConfig>().CraftableGoldCritters)
            {
                recipe = Mod.CreateRecipe(ItemID.GoldBird);
                recipe.AddRecipeGroup(RecipeGroupID.Birds);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.GoldBunny);
                recipe.AddIngredient(ItemID.Bunny);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.GoldButterfly);
                recipe.AddRecipeGroup(RecipeGroupID.Butterflies);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.GoldDragonfly);
                recipe.AddRecipeGroup(RecipeGroupID.Dragonflies);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.GoldFrog);
                recipe.AddIngredient(ItemID.Frog);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.GoldGoldfish);
                recipe.AddIngredient(ItemID.Goldfish);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.GoldGrasshopper);
                recipe.AddIngredient(ItemID.Grasshopper);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.GoldLadyBug);
                recipe.AddIngredient(ItemID.LadyBug);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.GoldMouse);
                recipe.AddIngredient(ItemID.Mouse);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.GoldSeahorse);
                recipe.AddIngredient(ItemID.Seahorse);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.SquirrelGold);
                recipe.AddRecipeGroup(RecipeGroupID.Squirrels);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.GoldWaterStrider);
                recipe.AddIngredient(ItemID.WaterStrider);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.GoldWorm);
                recipe.AddIngredient(ItemID.Worm);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();
            }

            //Craftable Rare Chest (Disabled by Default)
            if (GetInstance<IOtherConfig>().CraftableRareChests)
            {
                recipe = Mod.CreateRecipe(ItemID.IvyChest);
                recipe.AddIngredient(ItemID.RichMahogany, 8);
                recipe.AddRecipeGroup(RecipeGroupID.IronBar, 2);
                recipe.AddTile(TileID.WorkBenches);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.WaterChest);
                recipe.AddIngredient(ItemID.Coral, 2);
                recipe.AddRecipeGroup(RecipeGroupID.IronBar, 2);
                recipe.AddTile(TileID.WorkBenches);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.WebCoveredChest);
                recipe.AddIngredient(ItemID.Cobweb, 5);
                recipe.AddIngredient(ItemID.Chest);
                recipe.AddTile(TileID.WorkBenches);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.CrimsonChest, 2);
                recipe.AddIngredient(ItemID.CrimsonChest);
                recipe.AddIngredient(ItemID.CrimsonKey);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.CorruptionChest, 2);
                recipe.AddIngredient(ItemID.CorruptionChest);
                recipe.AddIngredient(ItemID.CorruptionKey);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.HallowedChest, 2);
                recipe.AddIngredient(ItemID.HallowedChest);
                recipe.AddIngredient(ItemID.HallowedKey);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.IceChest, 2);
                recipe.AddIngredient(ItemID.IceChest);
                recipe.AddIngredient(ItemID.FrozenKey);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.JungleChest, 2);
                recipe.AddIngredient(ItemID.JungleChest);
                recipe.AddIngredient(ItemID.JungleKey);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.DesertChest, 2);
                recipe.AddIngredient(ItemID.DesertChest);
                recipe.AddIngredient(ItemID.DungeonDesertKey);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();
            }

            //Crates
            recipe = Mod.CreateRecipe(ItemID.WoodenCrate);
            recipe.AddIngredient(ItemID.WoodenCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.LavaCrate);
            recipe.AddIngredient(ItemID.LavaCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.JungleFishingCrate);
            recipe.AddIngredient(ItemID.JungleFishingCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.FloatingIslandFishingCrate);
            recipe.AddIngredient(ItemID.FloatingIslandFishingCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.CorruptFishingCrate);
            recipe.AddIngredient(ItemID.CorruptFishingCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.CrimsonFishingCrate);
            recipe.AddIngredient(ItemID.CrimsonFishingCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.HallowedFishingCrate);
            recipe.AddIngredient(ItemID.HallowedFishingCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.DungeonFishingCrate);
            recipe.AddIngredient(ItemID.DungeonFishingCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.FrozenCrate);
            recipe.AddIngredient(ItemID.FrozenCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.OasisCrate);
            recipe.AddIngredient(ItemID.OasisCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.OceanCrate);
            recipe.AddIngredient(ItemID.OceanCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.IronCrate);
            recipe.AddIngredient(ItemID.IronCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.GoldenCrate);
            recipe.AddIngredient(ItemID.GoldenCrateHard);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            //Traps
            recipe = Mod.CreateRecipe(ItemID.DartTrap);
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddIngredient(ItemID.PoisonDart);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.Spike);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar);
            recipe.AddTile(TileID.BoneWelder);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.GeyserTrap);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddIngredient(ItemID.WaterBucket);
            recipe.AddIngredient(ItemID.LivingFireBlock);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.AddCondition(Recipe.Condition.InUnderworldHeight);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.WoodenSpike);
            recipe.AddIngredient(ItemID.RichMahogany);
            recipe.AddTile(TileID.LihzahrdFurnace);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.FlameTrap);
            recipe.AddIngredient(ItemID.LihzahrdBrick);
            recipe.AddIngredient(ItemID.LivingFireBlock);
            recipe.AddTile(TileID.LihzahrdFurnace);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.SpearTrap);
            recipe.AddIngredient(ItemID.LihzahrdBrick);
            recipe.AddIngredient(ItemID.WoodenSpike);
            recipe.AddIngredient(ItemID.RichMahogany, 10);
            recipe.AddTile(TileID.LihzahrdFurnace);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.SpikyBallTrap);
            recipe.AddIngredient(ItemID.LihzahrdBrick);
            recipe.AddIngredient(ItemID.WoodenSpike);
            recipe.AddIngredient(ItemID.PinkGel);
            recipe.AddTile(TileID.LihzahrdFurnace);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.SuperDartTrap);
            recipe.AddIngredient(ItemID.LihzahrdBrick);
            recipe.AddIngredient(ItemID.PoisonDart);
            recipe.AddTile(TileID.LihzahrdAltar);
            recipe.Register();

            //Other
            recipe = Mod.CreateRecipe(ItemID.PurpleSolution, 100);
            recipe.AddIngredient(ItemID.VilePowder);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.RedSolution, 100);
            recipe.AddIngredient(ItemID.ViciousPowder);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            if (GetInstance<CFishingConfig>().MultiBobberPotionBobberAmount > 1)
            {
                recipe = Mod.CreateRecipe(ItemType<Items.BuffPotions.Multi_Bobber_Potion>());
                recipe.AddIngredient(ItemID.BottledWater);
                recipe.AddIngredient(ItemID.Waterleaf);
                recipe.AddRecipeGroup("ReducedGrinding:baitCritterLow");
                recipe.AddRecipeGroup("ReducedGrinding:baitCritterMed");
                recipe.AddRecipeGroup("ReducedGrinding:baitCritterHigh");
                recipe.AddTile(TileID.Bottles);
                recipe.Register();
            }

            if (GetInstance<IOtherConfig>().InfectionPowderPerMushroom > 5)
            {
                recipe = Mod.CreateRecipe(ItemID.VilePowder, GetInstance<IOtherConfig>().InfectionPowderPerMushroom);
                recipe.AddIngredient(ItemID.VileMushroom);
                recipe.AddTile(TileID.DemonAltar);
                recipe.Register();

                recipe = Mod.CreateRecipe(ItemID.ViciousPowder, GetInstance<IOtherConfig>().InfectionPowderPerMushroom);
                recipe.AddIngredient(ItemID.ViciousMushroom);
                recipe.AddTile(TileID.DemonAltar);
                recipe.Register();
            }
        }
    }
}