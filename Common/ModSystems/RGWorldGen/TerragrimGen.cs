using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace ReducedGrinding.Common.ModSystems
{
    public partial class RGWorldGen
    {
        public class TerragrimGen(string name, float loadWeight) : GenPass(name, loadWeight)
        {
            protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
            {
                progress.Message = ReducedGrinding.GetText("Misc.WorldGeneration.PlacingTerragrims");
                if (!PlaceTerragrims())
                {
                    bool placedTerragrim = false;
                    int attempts = 0;
                    while (!placedTerragrim && attempts < 10000)
                    {
                        placedTerragrim = PlaceTerragrims(true);
                    }
                }
            }

            public static bool PlaceTerragrims(bool forcedTerragrim = false)
            {
                bool terragrimExistInPreDungeonChest = false;

                static bool PreDungeonChest(Tile tile)
                {
                    int tileFrameX = tile.TileFrameX;
                    if (tile.TileType == TileID.Containers)
                    {
                        if (tileFrameX == lockedGoldChest ||
                            tileFrameX == lockedShadowChest ||
                            tileFrameX == lihzahrdChest ||
                            (tileFrameX >= lockedJungleChest && tileFrameX <= lockedIceChest)
                            )
                        {
                            return false;
                        }
                    }
                    else if (tile.TileType == TileID.Containers2 && tileFrameX == lockedDesertChest)
                    {
                        return false;
                    }
                    return true;
                }

                for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
                {
                    if (!WorldGen.genRand.NextBool(limitedItemsConfig.TerragrimChestChance))
                    {
                        continue;
                    }

                    Chest chest = Main.chest[chestIndex];

                    if (chest == null)
                    {
                        continue;
                    }

                    Tile tile = Main.tile[chest.x, chest.y];
                    int tileFrameX = tile.TileFrameX;

                    if (tile.TileType == TileID.Containers)
                    {
                        if (tileFrameX == surfaceChest ||
                            tileFrameX == livingWoodChest
                            )
                        {
                            continue;
                        }
                    }
                    else if (tile.TileType != TileID.Containers2)
                    {
                        continue;
                    }

                    if (forcedTerragrim)
                    {
                        if (!PreDungeonChest(tile))
                        {
                            continue;
                        }
                        terragrimExistInPreDungeonChest = true;
                    }

                    for (int slot = 39; slot > 0; slot--)
                    {
                        chest.item[slot] = chest.item[slot - 1].Clone();
                    }
                    chest.item[0].SetDefaults(ItemID.Terragrim);
                    if (!terragrimExistInPreDungeonChest)
                    {
                        terragrimExistInPreDungeonChest = PreDungeonChest(tile);
                    }
                    break;
                }
                return terragrimExistInPreDungeonChest;
            }
        }
    }
}
