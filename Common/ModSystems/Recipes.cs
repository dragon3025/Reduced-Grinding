using ReducedGrinding.Configuration;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.ModSystems
{
    public class Recipes : ModSystem
    {
        public static readonly OtherConfig otherConfig = GetInstance<OtherConfig>();
        public static readonly CraftingConfig craftingConfig = GetInstance<CraftingConfig>();
        public static RecipeGroup GoldBar;

        public override void Unload()
        {
            GoldBar = null;
        }

        public override void AddRecipeGroups()
        {
            GoldBar = new RecipeGroup(
                static () => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldBar)}",
                ItemID.GoldBar,
                ItemID.PlatinumBar);
            RecipeGroup.RegisterGroup("ReducedGrinding:GoldBar", GoldBar);
        }

        public override void AddRecipes()
        {
            //Recipe recipe;
            PylonRecipe();
            CraftableRareChests();
            RecipeGoldenCritters(); //Disabled by Default

            if (craftingConfig.SturdyFossilsToDesertFossils == 0)
            {
                return;
            }

            Recipe recipe = Recipe.Create(ItemID.DesertFossil, craftingConfig.SturdyFossilsToDesertFossils);
            recipe.AddIngredient(ItemID.FossilOre, 13);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddCondition(Condition.InGraveyard);
            recipe.Register();
        }

        public override void PostAddRecipes()
        {
            if (craftingConfig.LeatherPerArchaeologistsPiece == 15)
            {
                return;
            }

            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.TryGetResult(ItemID.ArchaeologistsJacket, out _) || recipe.TryGetResult(ItemID.ArchaeologistsPants, out _))
                {
                    if (recipe.TryGetIngredient(ItemID.Leather, out Item ingredient))
                    {
                        ingredient.stack = craftingConfig.LeatherPerArchaeologistsPiece;
                    }
                }
            }
        }

        private static void RecipeGoldenCritters()
        {
            if (!craftingConfig.CraftableGoldCritters)
            {
                return;
            }
            Recipe recipe;
            void newGoldCritterRecipe(int result, int ingredient = 0, int group = -1)
            {
                recipe = Recipe.Create(result);
                if (ingredient > 0)
                {
                    recipe.AddIngredient(ingredient);
                }
                else
                {
                    recipe.AddRecipeGroup(group);
                }
                recipe.AddIngredient(ItemID.GoldCoin, 14);
                recipe.AddTile(TileID.DemonAltar);
                recipe.Register();
            }

            newGoldCritterRecipe(ItemID.GoldBird, group: RecipeGroupID.Birds);
            newGoldCritterRecipe(ItemID.GoldBunny, ItemID.Bunny);
            newGoldCritterRecipe(ItemID.GoldButterfly, group: RecipeGroupID.Butterflies);
            newGoldCritterRecipe(ItemID.GoldDragonfly, group: RecipeGroupID.Dragonflies);
            newGoldCritterRecipe(ItemID.GoldFrog, ItemID.Frog);
            newGoldCritterRecipe(ItemID.GoldGoldfish, ItemID.Goldfish);
            newGoldCritterRecipe(ItemID.GoldGrasshopper, ItemID.Grasshopper);
            newGoldCritterRecipe(ItemID.GoldLadyBug, ItemID.LadyBug);
            newGoldCritterRecipe(ItemID.GoldMouse, ItemID.Mouse);
            newGoldCritterRecipe(ItemID.GoldSeahorse, ItemID.Seahorse);
            newGoldCritterRecipe(ItemID.SquirrelGold, group: RecipeGroupID.Squirrels);
            newGoldCritterRecipe(ItemID.GoldWaterStrider, ItemID.WaterStrider);
            newGoldCritterRecipe(ItemID.GoldWorm, ItemID.Worm);
        }

        private static void CraftableRareChests()
        {
            if (!GetInstance<LimitedItemsConfig>().CraftableRareChests)
            {
                return;
            }
            //For Shadow Chest, this is done through Shimmering.
            Recipe recipe = Recipe.Create(ItemID.GoldChest);
            recipe.AddRecipeGroup(RecipeGroupID.Wood, 8);
            recipe.AddRecipeGroup(GoldBar, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            recipe = Recipe.Create(ItemID.DeadMansChest);
            recipe.AddIngredient(ItemID.GoldChest);
            recipe.AddIngredient(ItemID.Lever);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            recipe = Recipe.Create(ItemID.IvyChest);
            recipe.AddIngredient(ItemID.RichMahoganyChest);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddCondition(Condition.InGraveyard);
            recipe.Register();

            recipe = Recipe.Create(ItemID.WebCoveredChest);
            recipe.AddIngredient(ItemID.Cobweb, 8);
            recipe.AddIngredient(ItemID.Chest);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddCondition(Condition.InGraveyard);
            recipe.Register();

            //In 1.4.5+ Water Chest is given a recipe. 16 Bottled Water is the equivalent of 8 1.4.5+ Aquarium blocks.
            recipe = Recipe.Create(ItemID.WaterChest);
            recipe.AddIngredient(ItemID.BottledWater, 16);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

        private static void PylonRecipe()
        {
            if (craftingConfig.UniPylonCraftWithPylons == UniPylonCraftWithPylonsEnums.Disabled &&
                !craftingConfig.UniPylonCraftWithMechSouls &&
                !craftingConfig.UniPylonCraftWithFragments)
            {
                return;
            }

            // 1.4.5+ added the Aether Pylon and Underworld Pylon. Aether Pylon can be aquired by shimmering any Pylon including Universal Pylon.
            Recipe recipe = Recipe.Create(ItemID.TeleportationPylonVictory);
            if (craftingConfig.UniPylonCraftWithPylons != UniPylonCraftWithPylonsEnums.Disabled)
            {
                recipe.AddIngredient(ItemID.TeleportationPylonPurity);
                recipe.AddIngredient(ItemID.TeleportationPylonDesert);
                recipe.AddIngredient(ItemID.TeleportationPylonSnow);
                recipe.AddIngredient(ItemID.TeleportationPylonJungle);
                recipe.AddIngredient(ItemID.TeleportationPylonOcean);
                recipe.AddIngredient(ItemID.TeleportationPylonUnderground);
                recipe.AddIngredient(ItemID.TeleportationPylonMushroom);
            }
            int craftingStation = TileID.TinkerersWorkbench;
            if (craftingConfig.UniPylonCraftWithPylons == UniPylonCraftWithPylonsEnums.All)
            {
                recipe.AddIngredient(ItemID.TeleportationPylonHallow);
                craftingStation = TileID.CrystalBall;
            }
            if (craftingConfig.UniPylonCraftWithMechSouls)
            {
                recipe.AddIngredient(ItemID.SoulofFright, 5);
                recipe.AddIngredient(ItemID.SoulofMight, 5);
                recipe.AddIngredient(ItemID.SoulofSight, 5);
                craftingStation = TileID.CrystalBall;
            }
            if (craftingConfig.UniPylonCraftWithFragments)
            {
                recipe.AddIngredient(ItemID.FragmentNebula, 5);
                recipe.AddIngredient(ItemID.FragmentSolar, 5);
                recipe.AddIngredient(ItemID.FragmentStardust, 5);
                recipe.AddIngredient(ItemID.FragmentVortex, 5);
                craftingStation = TileID.CrystalBall;
            }
            recipe.AddTile(craftingStation);
            recipe.Register();
        }
    }
}
