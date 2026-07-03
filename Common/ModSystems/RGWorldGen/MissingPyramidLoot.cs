using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace ReducedGrinding.Common.ModSystems
{
    public partial class RGWorldGen
    {
        public class MissingPyramidLoot(string name, float loadWeight) : GenPass(name, loadWeight)
        {
            protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
            {
                progress.Message = ReducedGrinding.GetText("Misc.WorldGeneration.MissingPyramidLoot");

                List<int> missingPyramidItems = limitedItemsConfig.AddMissingPyramidLoot ? new() { ItemID.PharaohsMask, ItemID.FlyingCarpet } : new() { };
                SearchChestsForMissingItems(missingPyramidItems, goldChest);

                int attempts = 0;
                int spawnSafeDistance = 200;
                while (missingPyramidItems.Count > 0 && attempts < Main.maxTilesX)
                {
                    attempts++;

                    int posX;
                    if (WorldGen.tenthAnniversaryWorldGen && !WorldGen.remixWorldGen)
                    {
                        posX = WorldGen.genRand.Next((int)(Main.maxTilesX * 0.15), (int)(Main.maxTilesX * 0.85f));
                    }
                    else
                    {
                        posX = WorldGen.genRand.Next(WorldGen.beachDistance, Main.maxTilesX - WorldGen.beachDistance);
                    }

                    if (posX > Main.maxTilesX / 2 - spawnSafeDistance && posX < Main.maxTilesX / 2 + spawnSafeDistance)
                    {
                        continue;
                    }

                    int posY = 0;
                    for (; !Main.tile[posX, posY].HasTile && posY < Main.worldSurface; posY++)
                    {
                    }
                    if (Main.tile[posX, posY].TileType != TileID.Sand || posY <= 150)
                    {
                        continue;
                    }

                    bool validPos = true;

                    int buildPosY = posY + 5;

                    if (AvoidedTilesNearby(posX, posY))
                    {
                        continue;
                    }

                    int sandCount = 0; //Max is 580
                    int sandCountMax = 580;
                    for (int i = posX - 14; i < posX + 15; i++)
                    {
                        for (int j = posY; j < buildPosY + 15; j++)
                        {
                            Tile tileSafely = Framing.GetTileSafely(i, j);

                            if (tileSafely.HasTile && tileSafely.TileType == TileID.Sand)
                            {
                                sandCount++;
                            }

                            if (TileID.Sets.BasicChest[tileSafely.TileType])
                            {
                                validPos = false;
                                goto finishedTileCheck;
                            }
                        }
                    }

                    if (sandCount < sandCountMax * 0.75f)
                    {
                        continue;
                    }

                    finishedTileCheck:
                    if (!validPos)
                    {
                        continue;
                    }

                    int pyramidLayer = 0;
                    while (pyramidLayer < 15)
                    {
                        for (int i = 0 - pyramidLayer; i < pyramidLayer + 1; i++)
                        {
                            Main.tile[posX + i, buildPosY + pyramidLayer].ClearEverything();
                            if (i > 0 - pyramidLayer && i < pyramidLayer && pyramidLayer < 14)
                            {
                                WorldGen.PlaceWall(posX + i, buildPosY + pyramidLayer, WallID.SandstoneBrick);
                            }
                            WorldGen.PlaceTile(posX + i, buildPosY + pyramidLayer, TileID.SandstoneBrick);
                        }
                        pyramidLayer++;
                    }

                    static void ClearAndPlace(int x, int y, int tileID)
                    {
                        Main.tile[x, y].ClearEverything();
                        WorldGen.PlaceTile(x, y, tileID);
                    }

                    ClearAndPlace(posX - 6, buildPosY + 6, TileID.Sand);
                    ClearAndPlace(posX - 6, buildPosY + 7, TileID.Sand);
                    ClearAndPlace(posX - 7, buildPosY + 7, TileID.Sand);
                    ClearAndPlace(posX - 6, buildPosY + 8, TileID.Sand);
                    ClearAndPlace(posX - 7, buildPosY + 8, TileID.Sand);
                    ClearAndPlace(posX - 8, buildPosY + 8, TileID.Sand);

                    for (int i = posX - 5; i < posX + 3; i++)
                    {
                        for (int j = buildPosY + 6; j < buildPosY + 9; j++)
                        {
                            Main.tile[i, j].ClearTile();
                        }
                    }
                    Main.tile[posX + 3, buildPosY + 7].ClearTile();

                    Main.tile[posX + 3, buildPosY + 8].ClearTile();
                    Main.tile[posX + 4, buildPosY + 8].ClearTile();

                    Main.tile[posX - 2, buildPosY + 9].ClearTile();
                    Main.tile[posX - 3, buildPosY + 9].ClearTile();
                    Main.tile[posX - 2, buildPosY + 10].ClearTile();

                    for (int i = posX - 1; i < posX + 6; i++)
                    {
                        for (int j = buildPosY + 9; j < buildPosY + 11; j++)
                        {
                            Main.tile[i, j].ClearTile();
                        }
                    }

                    Main.tile[posX + 6, buildPosY + 10].ClearTile();

                    if (WorldGen.genRand.NextBool())
                    {
                        WorldGen.PlaceSmallPile(posX - 1, buildPosY + 10, 16 + WorldGen.genRand.Next(3), 1);
                    }
                    else
                    {
                        WorldGen.PlacePot(posX - 1, buildPosY + 10, style: 25 + WorldGen.genRand.Next(3));
                    }

                    if (WorldGen.genRand.NextBool())
                    {
                        WorldGen.PlaceSmallPile(posX + 3, buildPosY + 10, 16 + WorldGen.genRand.Next(3), 1);
                    }
                    else
                    {
                        WorldGen.PlacePot(posX + 3, buildPosY + 10, style: 25 + WorldGen.genRand.Next(3));
                    }

                    WorldGen.PlaceBanner(posX + 2, buildPosY + 6, TileID.Banners, style: 4 + WorldGen.genRand.Next(3));
                    WorldGen.PlaceBanner(posX - 2, buildPosY + 6, TileID.Banners, style: 4 + WorldGen.genRand.Next(3));

                    if (!WorldGen.AddBuriedChest(posX + 2, buildPosY + 11, contain: missingPyramidItems[0], Style: 1))
                    {//Vanilla Pyramid Chests use contain.
                        continue; //This should not be possible.
                    }
                    missingPyramidItems.RemoveAt(0);
                }
            }
        }
    }
}
