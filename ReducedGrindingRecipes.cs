using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ReducedGrinding
{

	class ReducedGrindingRecipes : ModSystem
	{
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
			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.EnchantedBoomerang, 1);
			recipe.AddIngredient(ItemID.Katana, 1);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.EnchantedSword);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.EnchantedSword, 1);
			recipe.AddIngredient(ItemID.ShadowKey, 1);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.Arkhalis);
			recipe.AddRecipe();

			//Easier Celestial Sigil
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.FragmentSolar);
			recipe.AddIngredient(ItemID.FragmentVortex);
			recipe.AddIngredient(ItemID.FragmentNebula);
			recipe.AddIngredient(ItemID.FragmentStardust);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.CelestialSigil);
			recipe.AddRecipe();

			//Infection Key Switching
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.CorruptionKey);
			recipe.SetResult(ItemID.CrimsonKey);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.CrimsonKey);
			recipe.SetResult(ItemID.CorruptionKey);
			recipe.AddRecipe();

			//Giant Shelly, Salamander, Crawdad Banner Switching
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.GiantShellyBanner);
			recipe.AddIngredient(ItemID.SalamanderBanner);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(ItemID.CrawdadBanner);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.CrawdadBanner);
			recipe.AddIngredient(ItemID.GiantShellyBanner);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(ItemID.SalamanderBanner);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.SalamanderBanner);
			recipe.AddIngredient(ItemID.CrawdadBanner);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(ItemID.GiantShellyBanner);
			recipe.AddRecipe();

			//Easier Hardmode Voodoo Doll
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.ClothierVoodooDoll);
			recipe.AddIngredient(ItemID.SoulofLight);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.GuideVoodooDoll);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.ClothierVoodooDoll);
			recipe.AddIngredient(ItemID.SoulofNight);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(ItemID.GuideVoodooDoll);
			recipe.AddRecipe();

			//Golden Critters
			recipe = new ModRecipe(this);
			recipe.AddRecipeGroup("Birds");
			recipe.AddIngredient(this.ItemType("Gold_Reflection_Mirror"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.GoldBird);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Bunny);
			recipe.AddIngredient(this.ItemType("Gold_Reflection_Mirror"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.GoldBunny);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Frog);
			recipe.AddIngredient(this.ItemType("Gold_Reflection_Mirror"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.GoldFrog);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Grasshopper);
			recipe.AddIngredient(this.ItemType("Gold_Reflection_Mirror"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.GoldGrasshopper);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Mouse);
			recipe.AddIngredient(this.ItemType("Gold_Reflection_Mirror"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.GoldMouse);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddRecipeGroup("Squirrels");
			recipe.AddIngredient(this.ItemType("Gold_Reflection_Mirror"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.SquirrelGold);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Worm);
			recipe.AddIngredient(this.ItemType("Gold_Reflection_Mirror"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.GoldWorm);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddRecipeGroup("Butterflies");
			recipe.AddIngredient(this.ItemType("Gold_Reflection_Mirror"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.GoldButterfly);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddRecipeGroup("ReducedGrinding:goldAndBiomeCrates");
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.IronCrate);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.IronCrate);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.WoodenCrate);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.RottenChunk, 2);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(ItemID.Leather);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Vertebrae, 2);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(ItemID.Leather);
			recipe.AddRecipe();
		}
	}
}