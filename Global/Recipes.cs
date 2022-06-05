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
            //Arkhalis Crafting Tree

            Recipe recipe = Mod.CreateRecipe(ItemID.EnchantedSword);
            recipe.AddIngredient(ItemID.EnchantedBoomerang, 1);
            recipe.AddIngredient(ItemID.Katana, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.Arkhalis);
            recipe.AddIngredient(ItemID.EnchantedSword, 1);
            recipe.AddIngredient(ItemID.ShadowKey, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();

            //Easier Celestial Sigil
            recipe = Mod.CreateRecipe(ItemID.CelestialSigil);
            recipe.AddIngredient(ItemID.FragmentSolar);
            recipe.AddIngredient(ItemID.FragmentVortex);
            recipe.AddIngredient(ItemID.FragmentNebula);
            recipe.AddIngredient(ItemID.FragmentStardust);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();

            //Infection Key Switching
            recipe = Mod.CreateRecipe(ItemID.CrimsonKey);
            recipe.AddIngredient(ItemID.CorruptionKey);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.CorruptionKey);
            recipe.AddIngredient(ItemID.CrimsonKey);
            recipe.Register();

            //Giant Shelly, Salamander, Crawdad Banner Switching
            recipe = Mod.CreateRecipe(ItemID.CrawdadBanner);
            recipe.AddIngredient(ItemID.GiantShellyBanner);
            recipe.AddIngredient(ItemID.SalamanderBanner);
            recipe.AddTile(TileID.Loom);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.SalamanderBanner);
            recipe.AddIngredient(ItemID.CrawdadBanner);
            recipe.AddIngredient(ItemID.GiantShellyBanner);
            recipe.AddTile(TileID.Loom);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.GiantShellyBanner);
            recipe.AddIngredient(ItemID.SalamanderBanner);
            recipe.AddIngredient(ItemID.CrawdadBanner);
            recipe.AddTile(TileID.Loom);
            recipe.Register();

            //Easier Hardmode Voodoo Doll
            recipe = Mod.CreateRecipe(ItemID.GuideVoodooDoll);
            recipe.AddIngredient(ItemID.ClothierVoodooDoll);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.GuideVoodooDoll);
            recipe.AddIngredient(ItemID.ClothierVoodooDoll);
            recipe.AddIngredient(ItemID.SoulofNight);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            //Golden Critters
            recipe = Mod.CreateRecipe(ItemID.GoldBird);
            recipe.AddRecipeGroup("Birds");
            recipe.AddIngredient(ModContent.ItemType<Items.Gold_Reflection_Mirror>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.GoldBunny);
            recipe.AddIngredient(ItemID.Bunny);
            recipe.AddIngredient(ModContent.ItemType<Items.Gold_Reflection_Mirror>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.GoldFrog);
            recipe.AddIngredient(ItemID.Frog);
            recipe.AddIngredient(ModContent.ItemType<Items.Gold_Reflection_Mirror>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.GoldGrasshopper);
            recipe.AddIngredient(ItemID.Grasshopper);
            recipe.AddIngredient(ModContent.ItemType<Items.Gold_Reflection_Mirror>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.GoldMouse);
            recipe.AddIngredient(ItemID.Mouse);
            recipe.AddIngredient(ModContent.ItemType<Items.Gold_Reflection_Mirror>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.SquirrelGold);
            recipe.AddRecipeGroup("Squirrels");
            recipe.AddIngredient(ModContent.ItemType<Items.Gold_Reflection_Mirror>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.GoldWorm);
            recipe.AddIngredient(ItemID.Worm);
            recipe.AddIngredient(ModContent.ItemType<Items.Gold_Reflection_Mirror>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.GoldButterfly);
            recipe.AddRecipeGroup("Butterflies");
            recipe.AddIngredient(ModContent.ItemType<Items.Gold_Reflection_Mirror>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.Leather);
            recipe.AddIngredient(ItemID.RottenChunk, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            recipe = Mod.CreateRecipe(ItemID.Leather);
            recipe.AddIngredient(ItemID.Vertebrae, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

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

            if (GetInstance<CFishingConfig>().MultiBobberPotionBobberAmount > 1)
            {
                recipe = Mod.CreateRecipe(ModContent.ItemType<Items.BuffPotions.Multi_Bobber_Potion>());
                recipe.AddIngredient(ItemID.BottledWater);
                recipe.AddIngredient(ItemID.Waterleaf);
                recipe.AddRecipeGroup("ReducedGrinding:baitCritterLow");
                recipe.AddRecipeGroup("ReducedGrinding:baitCritterMed");
                recipe.AddRecipeGroup("ReducedGrinding:baitCritterHigh");
                recipe.AddTile(TileID.Bottles);
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
        }
    }
}