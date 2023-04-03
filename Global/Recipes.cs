using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.GlobalRecipes
{
    class Recipes : ModSystem
    {
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
            recipe.AddCondition(Condition.InUnderworldHeight);
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
                {
                    recipe.AddTile(TileID.CrystalBall);
                }
                else
                {
                    recipe.AddTile(TileID.TinkerersWorkbench);
                }

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
                //For Shadow Chest, this is done through Shimmering.

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
            }
            #endregion
            #endregion
        }
    }
}
