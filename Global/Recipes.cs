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

            if (GetInstance<IOtherConfig>().CraftableRareChests)
            {
                recipe = Recipe.Create(ItemID.ShadowChest);
                recipe.AddIngredient(ItemID.ShadowKey);
                recipe.AddTile(TileType<Tiles.ShimmeringStar>());
                recipe.Register();

                recipe = Recipe.Create(ItemID.ShadowKey);
                recipe.AddIngredient(ItemID.ShadowChest);
                recipe.AddTile(TileType<Tiles.ShimmeringStar>());
                recipe.Register();
            }

            #region Dungeon Furniture

            #region Blue to Green
            recipe = Recipe.Create(ItemID.BlueDungeonBathtub);
            recipe.AddIngredient(ItemID.GreenDungeonBathtub);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlueDungeonBed);
            recipe.AddIngredient(ItemID.GreenDungeonBed);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlueDungeonBookcase);
            recipe.AddIngredient(ItemID.GreenDungeonBookcase);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlueDungeonCandelabra);
            recipe.AddIngredient(ItemID.GreenDungeonCandelabra);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlueDungeonCandle);
            recipe.AddIngredient(ItemID.GreenDungeonCandle);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlueDungeonChair);
            recipe.AddIngredient(ItemID.GreenDungeonChair);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlueDungeonChandelier);
            recipe.AddIngredient(ItemID.GreenDungeonChandelier);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.DungeonClockBlue);
            recipe.AddIngredient(ItemID.DungeonClockGreen);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlueDungeonDoor);
            recipe.AddIngredient(ItemID.GreenDungeonDoor);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlueDungeonDresser);
            recipe.AddIngredient(ItemID.GreenDungeonDresser);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlueDungeonLamp);
            recipe.AddIngredient(ItemID.GreenDungeonLamp);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlueDungeonPiano);
            recipe.AddIngredient(ItemID.GreenDungeonPiano);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlueDungeonSofa);
            recipe.AddIngredient(ItemID.GreenDungeonSofa);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlueDungeonTable);
            recipe.AddIngredient(ItemID.GreenDungeonTable);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlueDungeonVase);
            recipe.AddIngredient(ItemID.GreenDungeonVase);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlueDungeonWorkBench);
            recipe.AddIngredient(ItemID.GreenDungeonWorkBench);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();
            #endregion

            #region Green to Pink
            recipe = Recipe.Create(ItemID.GreenDungeonBathtub);
            recipe.AddIngredient(ItemID.PinkDungeonBathtub);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.GreenDungeonBed);
            recipe.AddIngredient(ItemID.PinkDungeonBed);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.GreenDungeonBookcase);
            recipe.AddIngredient(ItemID.PinkDungeonBookcase);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.GreenDungeonCandelabra);
            recipe.AddIngredient(ItemID.PinkDungeonCandelabra);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.GreenDungeonCandle);
            recipe.AddIngredient(ItemID.PinkDungeonCandle);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.GreenDungeonChair);
            recipe.AddIngredient(ItemID.PinkDungeonChair);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.GreenDungeonChandelier);
            recipe.AddIngredient(ItemID.PinkDungeonChandelier);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.DungeonClockGreen);
            recipe.AddIngredient(ItemID.DungeonClockPink);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.GreenDungeonDoor);
            recipe.AddIngredient(ItemID.PinkDungeonDoor);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.GreenDungeonDresser);
            recipe.AddIngredient(ItemID.PinkDungeonDresser);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.GreenDungeonLamp);
            recipe.AddIngredient(ItemID.PinkDungeonLamp);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.GreenDungeonPiano);
            recipe.AddIngredient(ItemID.PinkDungeonPiano);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.GreenDungeonSofa);
            recipe.AddIngredient(ItemID.PinkDungeonSofa);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.GreenDungeonTable);
            recipe.AddIngredient(ItemID.PinkDungeonTable);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.GreenDungeonVase);
            recipe.AddIngredient(ItemID.PinkDungeonVase);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.GreenDungeonWorkBench);
            recipe.AddIngredient(ItemID.PinkDungeonWorkBench);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();
            #endregion

            #region Pink to Blue
            recipe = Recipe.Create(ItemID.PinkDungeonBathtub);
            recipe.AddIngredient(ItemID.BlueDungeonBathtub);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PinkDungeonBed);
            recipe.AddIngredient(ItemID.BlueDungeonBed);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PinkDungeonBookcase);
            recipe.AddIngredient(ItemID.BlueDungeonBookcase);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PinkDungeonCandelabra);
            recipe.AddIngredient(ItemID.BlueDungeonCandelabra);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PinkDungeonCandle);
            recipe.AddIngredient(ItemID.BlueDungeonCandle);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PinkDungeonChair);
            recipe.AddIngredient(ItemID.BlueDungeonChair);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PinkDungeonChandelier);
            recipe.AddIngredient(ItemID.BlueDungeonChandelier);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.DungeonClockPink);
            recipe.AddIngredient(ItemID.DungeonClockBlue);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PinkDungeonDoor);
            recipe.AddIngredient(ItemID.BlueDungeonDoor);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PinkDungeonDresser);
            recipe.AddIngredient(ItemID.BlueDungeonDresser);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PinkDungeonLamp);
            recipe.AddIngredient(ItemID.BlueDungeonLamp);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PinkDungeonPiano);
            recipe.AddIngredient(ItemID.BlueDungeonPiano);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PinkDungeonSofa);
            recipe.AddIngredient(ItemID.BlueDungeonSofa);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PinkDungeonTable);
            recipe.AddIngredient(ItemID.BlueDungeonTable);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PinkDungeonVase);
            recipe.AddIngredient(ItemID.BlueDungeonVase);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.PinkDungeonWorkBench);
            recipe.AddIngredient(ItemID.BlueDungeonWorkBench);
            recipe.AddTile(TileType<Tiles.ShimmeringStar>());
            recipe.Register();
            #endregion

            #endregion

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
                //Shadow Chest also requires this condition, but is crafted using shimmering, so it's in the shimmering section above.

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
