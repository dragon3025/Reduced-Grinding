using ReducedGrinding.Configuration;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.ModSystems
{
    //In 1.4.5+ "AddBuriedChest" may work differently, and will need checked.

    public partial class RGWorldGen : ModSystem
    {
        private static readonly LimitedItemsConfig limitedItemsConfig = GetInstance<LimitedItemsConfig>();

        private static readonly int chestWidth = 36;
        //Containers
        private static readonly int surfaceChest = 0;
        private static readonly int goldChest = 1 * chestWidth;
        private static readonly int lockedGoldChest = 2 * chestWidth;
        private static readonly int lockedShadowChest = 4 * chestWidth;
        private static readonly int livingWoodChest = 12 * chestWidth;
        private static readonly int lihzahrdChest = 16 * chestWidth;
        private static readonly int lockedJungleChest = 23 * chestWidth;
        private static readonly int lockedIceChest = 27 * chestWidth;
        private static readonly int mushroomChest = 32 * chestWidth;
        //Containers2
        private static readonly int lockedDesertChest = 13 * chestWidth;

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            //NOTE: Don't turn chest into unnatural chest to debug. They can end up getting removed by vanilla generation. Insert unnatural items instead.

            if (limitedItemsConfig.AddMissingTreeLoot)
            {
                int LivingTreesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Living Trees"));
                if (LivingTreesIndex != -1)
                {
                    tasks.Insert(LivingTreesIndex + 1, new MissingTreeLootGen("Adding missing tree loot", 10f));
                }
            }

            if (limitedItemsConfig.AddMissingShroomLoot)
            {
                int BuriedChestsIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Buried Chests"));
                if (BuriedChestsIndex != -1)
                {
                    tasks.Insert(BuriedChestsIndex + 1, new MissingShroomLootGen("Adding missing shroom loot", 10f));
                }
            }

            if (limitedItemsConfig.AddMissingPyramidLoot)
            {
                int FinalCleanupIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Pyramids"));
                if (FinalCleanupIndex != -1)
                {
                    tasks.Insert(FinalCleanupIndex + 1, new MissingPyramidLoot("Adding missing Pyramid loot", 10f));
                }
            }

            if (limitedItemsConfig.TerragrimChestChance > 0)
            {
                int FinalCleanupIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
                if (FinalCleanupIndex != -1)
                {
                    tasks.Insert(FinalCleanupIndex + 1, new TerragrimGen("Placing Terragrims", 10f));
                }
            }

            if (limitedItemsConfig.TombstonesPerWorld > 0)
            {
                int PotsIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Pots"));
                if (PotsIndex != -1)
                {
                    tasks.Insert(PotsIndex + 1, new TombstonesGen("Adding Tombstones", 10f));
                }
            }

            //In 1.4.5's Dual Dungeons, Dungeon's work a lot differently.
            if (limitedItemsConfig.OtherEvilChest)
            {
                int DungeonIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Dungeon"));
                if (DungeonIndex != -1)
                {
                    tasks.Insert(DungeonIndex + 1, new OtherEvilChestGen("Placing the other Evil Chest", 1f));
                }
            }
        }

        public static bool AvoidedTilesNearby(int posX, int posY)
        {
            for (int tileCheckX = posX - 50; tileCheckX < posX + 51; tileCheckX++)
            {
                for (int tileCheckY = posY - 50; tileCheckY < posY + 51; tileCheckY++)
                {
                    Tile tileSafely = Framing.GetTileSafely(tileCheckX, tileCheckY);

                    if (tileSafely.HasTile)
                    {
                        switch (tileSafely.TileType)
                        {
                            case TileID.BlueDungeonBrick:
                            case TileID.GreenDungeonBrick:
                            case TileID.PinkDungeonBrick:
                            case TileID.Cloud:
                            case TileID.RainCloud:
                            case TileID.SnowCloud:
                            case TileID.CrackedBlueDungeonBrick:
                            case TileID.CrackedGreenDungeonBrick:
                            case TileID.CrackedPinkDungeonBrick:
                                return true;
                        }

                        if (TileID.Sets.BasicChest[tileSafely.TileType])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private static void SearchChestsForMissingItems(List<int> missingItems, int chestType)
        {
            for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
            {
                if (missingItems.Count == 0)
                {
                    break;
                }

                Chest chest = Main.chest[chestIndex];
                if (chest == null)
                {
                    continue;
                }

                Tile tile = Main.tile[chest.x, chest.y];
                if (tile.TileType != TileID.Containers || tile.TileFrameX != chestType)
                {
                    continue;
                }

                for (int slot = 0; slot < 40; slot++)
                {
                    List<int> missingItemsOld = [.. missingItems];

                    foreach (int itemType in missingItemsOld)
                    {
                        if (chest.item[slot].type == itemType)
                        {
                            missingItems.Remove(itemType);
                        }
                    }
                }
            }
        }

        ////Testing functions
        //public static void DebugAvoidedTilesNearby(int posX, int posY)
        //{
        //    for (int tileCheckX = posX - 50; tileCheckX < posX + 51; tileCheckX++)
        //    {
        //        for (int tileCheckY = posY - 50; tileCheckY < posY + 51; tileCheckY++)
        //        {
        //            Tile tileSafely = Framing.GetTileSafely(tileCheckX, tileCheckY);
        //            if (tileSafely.HasTile)
        //            {
        //                Main.tile[tileCheckX, tileCheckY].ClearEverything();
        //                WorldGen.PlaceTile(tileCheckX, tileCheckY, TileID.SapphireGemspark);
        //            }
        //            else
        //            {
        //                WorldGen.PlaceWall(tileCheckX, tileCheckY, WallID.SapphireGemspark);
        //            }
        //        }
        //    }
        //}

        //public static bool JustPressed(Microsoft.Xna.Framework.Input.Keys key)
        //{
        //    return Main.keyState.IsKeyDown(key) && !Main.oldKeyState.IsKeyDown(key);
        //}

        //public override void PostUpdateWorld()
        //{
        //    if (JustPressed(Microsoft.Xna.Framework.Input.Keys.D1))
        //    {
        //        TestMethod((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16);
        //    }
        //}

        //private static void TestMethod(int mouseX, int mouseY)
        //{
        //    Main.NewText("Test");
        //    WorldGen.AddBuriedChest(mouseX + 2, mouseY + 1, contain: ItemID.LivingWoodWand, Style: 12);
        //}
    }
}
