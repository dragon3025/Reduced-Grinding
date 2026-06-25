using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace ReducedGrinding.Common.ModSystems
{
    public partial class RGWorldGen
    {
        public class MissingShroomLootGen(string name, float loadWeight) : GenPass(name, loadWeight)
        {
            protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
            {
                progress.Message = ReducedGrinding.GetText("Misc.WorldGeneration.MissingShroomLoot");

                List<int> missingMushroomItems = [ItemID.ShroomMinecart, ItemID.MushroomHat];
                SearchChestsForMissingItems(missingMushroomItems, mushroomChest);

                List<int> mushroomBiomes = [];
                for (int i = 0; i < GenVars.mushroomBiomesPosition.Length; i++)
                {
                    if (GenVars.mushroomBiomesPosition[i].X != 0 && GenVars.mushroomBiomesPosition[i].Y != 0)
                    {
                        mushroomBiomes.Add(i);
                    }
                }

                while (missingMushroomItems.Count > 0)
                {
                    if (!TryToPlaceMushroomChest(mushroomBiomes, missingMushroomItems))
                    {
                        missingMushroomItems.RemoveAt(0); //Remove even if it failed, to prevent an unlikely infinite loop.
                    }
                }
            }

            private static bool TryToPlaceMushroomChest(List<int> mushroomBiomes, List<int> missingMushroomItems)
            {
                bool placedMissingItem = false;
                int attempts = 0;
                while (!placedMissingItem && attempts < Main.maxTilesX)
                {
                    attempts++;

                    int mushroomBiomeIndex = mushroomBiomes[WorldGen.genRand.Next(mushroomBiomes.Count)];
                    Point selectedBiomePosition = GenVars.mushroomBiomesPosition[mushroomBiomeIndex];

                    //Biome position is the center of the Mushroom Biome, and the biome is about 200x200 blocks.
                    int posX = WorldGen.genRand.Next(selectedBiomePosition.X - 100, selectedBiomePosition.X + 100);
                    int posY = WorldGen.genRand.Next(selectedBiomePosition.Y - 100, selectedBiomePosition.Y + 100);

                    for (int tileCheckX = posX - 1; tileCheckX < posX + 3; tileCheckX++)
                    {
                        for (int tileCheckY = posY - 1; tileCheckY < posY + 3; tileCheckY++)
                        {
                            Tile tileSafely = Framing.GetTileSafely(tileCheckX, tileCheckY);

                            if (tileSafely.HasTile)
                            {
                                if (TileID.Sets.BasicChest[tileSafely.TileType])
                                {
                                    continue;
                                }
                            }
                        }
                    }

                    if (!WorldGen.AddBuriedChest(posX + 1, posY + 2, Style: 32))
                    {
                        continue;
                    }
                    int chestIndex = -1;
                    while (chestIndex < 0 && posY < Main.maxTilesY)
                    {
                        chestIndex = Chest.FindChest(posX, posY);
                        if (chestIndex == -1)
                        {
                            posY++;
                        }
                    }
                    if (posY == Main.maxTilesY)
                    {
                        continue; //This should not be possible.
                    }

                    Chest chest = Main.chest[chestIndex];

                    //In special world types, it's possible for a chest to generate with more than 1 missing item.
                    List<int> missingMushroomItemsCopy = [.. missingMushroomItems];
                    for (int i = 0; i < 40; i++)
                    {
                        foreach (int item in missingMushroomItemsCopy)
                        {
                            if (chest.item[i].type == item)
                            {
                                placedMissingItem = true;
                                missingMushroomItems.Remove(item);
                            }
                        }
                        if (missingMushroomItems.Count == 0)
                        {
                            break;
                        }
                    }

                    if (!placedMissingItem)
                    {
                        Chest.DestroyChestDirect(posX, posY, chestIndex);
                        Main.tile[posX, posY].ClearTile();
                        Main.tile[posX, posY + 1].ClearTile();
                        Main.tile[posX + 1, posY].ClearTile();
                        Main.tile[posX + 1, posY + 1].ClearTile();
                        continue;
                    }
                }
                return placedMissingItem;
            }
        }
    }
}
