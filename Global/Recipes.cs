using ReducedGrinding.Configuration;
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
            Recipe recipe;

            #region Universal Pylon
            if (GetInstance<IOtherConfig>().UniversalPylon.CraftWithPylons ||
                GetInstance<IOtherConfig>().UniversalPylon.CraftWithPreMechSouls ||
                GetInstance<IOtherConfig>().UniversalPylon.CraftWithMechSouls ||
                GetInstance<IOtherConfig>().UniversalPylon.CraftWithFragments)
            {
                recipe = Recipe.Create(ItemID.TeleportationPylonVictory);
                if (GetInstance<IOtherConfig>().UniversalPylon.CraftWithPylons)
                {
                    recipe.AddIngredient(ItemID.TeleportationPylonDesert);
                    recipe.AddIngredient(ItemID.TeleportationPylonHallow);
                    recipe.AddIngredient(ItemID.TeleportationPylonJungle);
                    recipe.AddIngredient(ItemID.TeleportationPylonMushroom);
                    recipe.AddIngredient(ItemID.TeleportationPylonOcean);
                    recipe.AddIngredient(ItemID.TeleportationPylonPurity);
                    recipe.AddIngredient(ItemID.TeleportationPylonSnow);
                    recipe.AddIngredient(ItemID.TeleportationPylonUnderground);
                }
                if (GetInstance<IOtherConfig>().UniversalPylon.CraftWithPreMechSouls)
                {
                    recipe.AddIngredient(ItemID.SoulofLight, 5);
                    recipe.AddIngredient(ItemID.SoulofNight, 5);
                    recipe.AddIngredient(ItemID.SoulofFlight, 5);
                }
                if (GetInstance<IOtherConfig>().UniversalPylon.CraftWithMechSouls)
                {
                    recipe.AddIngredient(ItemID.SoulofFright, 5);
                    recipe.AddIngredient(ItemID.SoulofMight, 5);
                    recipe.AddIngredient(ItemID.SoulofSight, 5);
                }
                if (GetInstance<IOtherConfig>().UniversalPylon.CraftWithFragments)
                {
                    recipe.AddIngredient(ItemID.FragmentNebula, 5);
                    recipe.AddIngredient(ItemID.FragmentSolar, 5);
                    recipe.AddIngredient(ItemID.FragmentStardust, 5);
                    recipe.AddIngredient(ItemID.FragmentVortex, 5);
                }
                if (GetInstance<IOtherConfig>().UniversalPylon.CraftAtCrystalBall)
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
                recipe.AddTile(26); //Altars
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldBunny);
                recipe.AddIngredient(ItemID.Bunny);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(26); //Altars
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldButterfly);
                recipe.AddRecipeGroup(RecipeGroupID.Butterflies);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(26); //Altars
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldDragonfly);
                recipe.AddRecipeGroup(RecipeGroupID.Dragonflies);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(26); //Altars
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldFrog);
                recipe.AddIngredient(ItemID.Frog);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(26); //Altars
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldGoldfish);
                recipe.AddIngredient(ItemID.Goldfish);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(26); //Altars
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldGrasshopper);
                recipe.AddIngredient(ItemID.Grasshopper);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(26); //Altars
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldLadyBug);
                recipe.AddIngredient(ItemID.LadyBug);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(26); //Altars
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldMouse);
                recipe.AddIngredient(ItemID.Mouse);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(26); //Altars
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldSeahorse);
                recipe.AddIngredient(ItemID.Seahorse);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(26); //Altars
                recipe.Register();

                recipe = Recipe.Create(ItemID.SquirrelGold);
                recipe.AddRecipeGroup(RecipeGroupID.Squirrels);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(26); //Altars
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldWaterStrider);
                recipe.AddIngredient(ItemID.WaterStrider);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(26); //Altars
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldWorm);
                recipe.AddIngredient(ItemID.Worm);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(26); //Altars
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
