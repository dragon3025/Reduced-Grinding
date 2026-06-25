using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace ReducedGrinding.Common.ModSystems
{
    public partial class RGWorldGen
    {
        public class MissingTreeLootGen(string name, float loadWeight) : GenPass(name, loadWeight)
        {
            protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
            {
                progress.Message = ReducedGrinding.GetText("Misc.WorldGeneration.MissingTreeLoot");

                List<int> missingTreeItems = [ItemID.SunflowerMinecart, ItemID.LadybugMinecart];
                SearchChestsForMissingItems(missingTreeItems, livingWoodChest);

                static void ClearAndPlaceTile(int x, int y, int tileID)
                {
                    Main.tile[x, y].ClearEverything();
                    WorldGen.PlaceTile(x, y, tileID, true);
                }

                static void ClearAndPlaceWall(int x, int y, int wallID)
                {
                    Main.tile[x, y].ClearEverything();
                    WorldGen.PlaceWall(x, y, wallID, true);
                }

                int attempts = 0;
                int spawnSafeDistance = 200;

                while (missingTreeItems.Count > 0 && attempts < Main.maxTilesX)
                {
                    attempts++;
                    int posX = WorldGen.genRand.Next(WorldGen.beachDistance, Main.maxTilesX - WorldGen.beachDistance);
                    if (WorldGen.tenthAnniversaryWorldGen && !WorldGen.remixWorldGen)
                    {
                        posX = WorldGen.genRand.Next((int)(Main.maxTilesX * 0.15), (int)(Main.maxTilesX * 0.85f));
                    }
                    if (posX > Main.maxTilesX / 2 - spawnSafeDistance && posX < Main.maxTilesX / 2 + spawnSafeDistance)
                    {
                        continue;
                    }

                    bool saplingFlip = WorldGen.genRand.NextBool(2);
                    posX += saplingFlip ? 0 : 1;

                    int posY = 0;
                    for (; !Main.tile[posX, posY].HasTile && posY < Main.worldSurface; posY++)
                    {
                    }
                    if (Main.tile[posX, posY].TileType != TileID.Dirt ||
                        Main.tile[posX + 1, posY].TileType != TileID.Dirt ||
                        Main.tile[posX + 2, posY].TileType != TileID.Dirt ||
                        posY <= 150)
                    {
                        continue;
                    }

                    bool validPos = true;
                    int trunkLength = WorldGen.genRand.Next(5, 11);

                    for (int tileCheckX = posX - 2; tileCheckX < posX + 5; tileCheckX++)
                    {
                        for (int tileCheckY = posY; tileCheckY < posY + trunkLength * 2 + 6; tileCheckY++)
                        {
                            Tile tileSafely = Framing.GetTileSafely(tileCheckX, tileCheckY);
                            if (tileSafely.HasTile)
                            {
                                switch (tileSafely.TileType)
                                {
                                    case TileID.Sand:
                                    case TileID.Ebonsand:
                                    case TileID.Crimsand:
                                    case TileID.SnowBlock:
                                    case TileID.IceBlock:
                                    case TileID.Ebonstone:
                                    case TileID.Crimstone:
                                    case TileID.Mud:
                                        validPos = false;
                                        goto finishedTileCheck;
                                }
                            }
                        }
                    }

                    for (int tileCheckX = posX; tileCheckX < posX + 4; tileCheckX++)
                    {
                        for (int tileCheckY = posY + trunkLength * 2; tileCheckY < posY + trunkLength * 2 + 5; tileCheckY++)
                        {
                            if (!Main.tile[tileCheckX, tileCheckY].HasTile)
                            {
                                validPos = false;
                                goto finishedTileCheck;
                            }
                        }
                    }

                    for (int tileCheckX = posX; tileCheckX < posX + 3; tileCheckX++)
                    {
                        for (int tileCheckY = posY - 4; tileCheckY < posY + 1; tileCheckY++)
                        {
                            Tile tileSafely = Framing.GetTileSafely(tileCheckX, tileCheckY);
                            if (tileSafely.LiquidType == LiquidID.Water && tileSafely.LiquidAmount == 255)
                            {
                                validPos = false;
                                goto finishedTileCheck;
                            }
                        }
                    }

                    if (AvoidedTilesNearby(posX, posY))
                    {
                        continue;
                    }

                    finishedTileCheck:
                    if (!validPos)
                    {
                        continue;
                    }

                    posY++;

                    ClearAndPlaceTile(posX + 1, posY, TileID.LeafBlock);
                    ClearAndPlaceTile(posX, posY + 1, TileID.LeafBlock);
                    ClearAndPlaceTile(posX + 2, posY + 1, TileID.LeafBlock);

                    posY++;
                    for (int i = 0; i < trunkLength; i++)
                    {
                        ClearAndPlaceTile(posX + 1, posY + i, TileID.LivingWood);
                    }

                    posY += trunkLength;

                    ClearAndPlaceTile(posX, posY - 1, TileID.LivingWood);
                    ClearAndPlaceTile(posX + 2, posY - 1, TileID.LivingWood);

                    for (int i = 0; i < trunkLength; i++)
                    {
                        ClearAndPlaceTile(posX, posY + i, TileID.LivingWood);
                        ClearAndPlaceWall(posX + 1, posY + i, WallID.LivingWoodUnsafe);
                        ClearAndPlaceTile(posX + 2, posY + i, TileID.LivingWood);
                    }

                    posY += trunkLength;

                    posX -= saplingFlip ? 0 : 1;

                    for (int i = -1; i < 3; i++)
                    {
                        ClearAndPlaceTile(posX, posY + i, TileID.LivingWood);
                        if (i > -1 && i < 2)
                        {
                            ClearAndPlaceWall(posX + 1, posY + i, WallID.LivingWoodUnsafe);
                            ClearAndPlaceWall(posX + 2, posY + i, WallID.LivingWoodUnsafe);
                        }
                        else if (i == 2)
                        {
                            WorldGen.PlaceTile(posX + 1, posY + i, TileID.LivingWood, true, true);
                            WorldGen.PlaceTile(posX + 2, posY + i, TileID.LivingWood, true, true);
                        }
                        ClearAndPlaceTile(posX + 3, posY + i, TileID.LivingWood);
                    }

                    if (!WorldGen.AddBuriedChest(posX + 2, posY + 1, contain: ItemID.LivingWoodWand, Style: 12))
                    {
                        continue;
                    }

                    bool placedItem = false;
                    int itemAttempts = 0;
                    int chestIndex = Chest.FindChest(posX + 1, posY);
                    if (chestIndex == -1)
                    {
                        continue; //This should not be possible.
                    }
                    while (!placedItem && itemAttempts < 10000)
                    {
                        itemAttempts++;
                        Chest chest = Main.chest[chestIndex];
                        for (int slot = 0; slot < 40; slot++)
                        {
                            if (chest.item[slot].type == missingTreeItems[0])
                            {
                                placedItem = true;
                                missingTreeItems.RemoveAt(0);
                                break;
                            }
                        }
                        if (!placedItem)
                        {
                            Chest.DestroyChestDirect(posX + 1, posY, chestIndex);
                            Main.tile[posX + 1, posY].ClearTile();
                            Main.tile[posX + 1, posY + 1].ClearTile();
                            Main.tile[posX + 2, posY].ClearTile();
                            Main.tile[posX + 2, posY + 1].ClearTile();
                            WorldGen.AddBuriedChest(posX + 2, posY + 1, contain: ItemID.LivingWoodWand, Style: 12);
                            chestIndex = Chest.FindChest(posX + 1, posY);
                            continue;
                        }
                    }
                }
            }
        }
    }
}
