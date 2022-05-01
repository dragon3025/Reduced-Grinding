using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ReducedGrinding
{

	class ReducedGrindingRecipes : ModSystem
	{
		// A place to store the recipe group so we can easily use it later
		public static RecipeGroup goldAndBiomeCrates;

		public override void Unload()
		{
			goldAndBiomeCrates = null;
		}

		public override void AddRecipeGroups()
		{
			goldAndBiomeCrates = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Golden or Biome Crate", new int[]
			{
				ItemID.JungleFishingCrate,
				ItemID.FloatingIslandFishingCrate,
				ItemID.CorruptFishingCrate,
				ItemID.CrimsonFishingCrate,
				ItemID.HallowedFishingCrate,
				ItemID.DungeonFishingCrate,
				ItemID.GoldenCrate
			});
			RecipeGroup.RegisterGroup("ReducedGrinding:goldAndBiomeCrates", goldAndBiomeCrates);
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

			recipe = Mod.CreateRecipe(ItemID.IronCrate);
			recipe.AddRecipeGroup("ReducedGrinding:goldAndBiomeCrates");
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();

			recipe = Mod.CreateRecipe(ItemID.WoodenCrate);
			recipe.AddIngredient(ItemID.IronCrate);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();

			recipe = Mod.CreateRecipe(ItemID.Leather);
			recipe.AddIngredient(ItemID.RottenChunk, 2);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();

			recipe = Mod.CreateRecipe(ItemID.Leather);
			recipe.AddIngredient(ItemID.Vertebrae, 2);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}