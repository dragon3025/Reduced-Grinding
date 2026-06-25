using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.WorldBuilding;

namespace ReducedGrinding.Common.ModSystems
{
    public partial class RGWorldGen
    {
        public class TombstonesGen(string name, float loadWeight) : GenPass(name, loadWeight)
        {
            protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
            {
                progress.Message = Lang.gen[35].Value; //Progress message for Pots and 1.4.5+ Graveyards

                int tombsToAdd = limitedItemsConfig.TombstonesPerWorld * Main.maxTilesX / 8400;
                int attempts = 0;
                int spawnSafeDistance = 200;
                int posXOverride = -1;
                while (tombsToAdd > 0 && attempts < Main.maxTilesX)
                {
                    attempts++;
                    int posX;
                    if (posXOverride > -1)
                    {
                        posX = posXOverride;
                        posXOverride = -1;
                    }
                    else
                    {
                        posX = WorldGen.genRand.Next(WorldGen.beachDistance, Main.maxTilesX - WorldGen.beachDistance);
                        if (WorldGen.tenthAnniversaryWorldGen && !WorldGen.remixWorldGen)
                        {
                            posX = WorldGen.genRand.Next((int)(Main.maxTilesX * 0.15), (int)(Main.maxTilesX * 0.85f));
                        }
                        if (posX > Main.maxTilesX / 2 - spawnSafeDistance && posX < Main.maxTilesX / 2 + spawnSafeDistance)
                        {
                            continue;
                        }
                    }
                    int posY = 0;
                    for (; !Main.tile[posX, posY].HasTile && posY < Main.worldSurface; posY++)
                    {
                    }

                    int[] validTiles =
                        [
                        TileID.Dirt,
                        TileID.Sand,
                        TileID.Ebonsand,
                        TileID.Crimsand,
                        TileID.JungleGrass,
                        TileID.SnowBlock,
                        TileID.CorruptGrass,
                        TileID.CrimsonGrass,
                        ];
                    if (!validTiles.Contains(Main.tile[posX, posY].TileType) ||
                        !validTiles.Contains(Main.tile[posX + 1, posY].TileType) ||
                        posY <= 150)
                    {
                        continue;
                    }

                    if (AvoidedTilesNearby(posX, posY))
                    {
                        continue;
                    }

                    bool validPos = true;

                    for (int tileCheckX = posX; tileCheckX < posX + 1; tileCheckX++)
                    {
                        for (int tileCheckY = posY - 2; tileCheckY < posY - 1; tileCheckY++)
                        {
                            if (WorldGen.SolidTile(tileCheckX, tileCheckY))
                            {
                                validPos = false;
                                goto finishedTileCheck;
                            }
                        }
                    }

                    finishedTileCheck:
                    if (!validPos)
                    {
                        continue;
                    }

                    posY -= 1;

                    WorldGen.PlaceTile(posX, posY, TileID.Tombstones, mute: true, forced: false, style: WorldGen.genRand.Next(6));

                    if (Main.tile[posX, posY].TileType == TileID.Tombstones)
                    {
                        tombsToAdd--;
                        int num5 = Sign.ReadSign(posX, posY);
                        if (num5 >= 0)
                        {
                            //In 1.4.5+ remove the Tombstone localization and use the newly added vanilla localization: Sign.TextSign(num5, Language.RandomFromCategory("Epitaph", genRand).Value);
                            int textID = 1;// 1 + WorldGen.genRand.Next(47);
                            Sign.TextSign(num5, Language.GetTextValue($"Mods.ReducedGrinding.Misc.Epitaph.{textID}"));

                            //In 1.4.5+ try to place I'm with stupid to the right of another Tombstone.
                            //if (textID == 37) //If tombstone is "<-- I'm with stupid", try to place the next tombstone to the left of it.
                            //{
                            //    posXOverride = posX - 2;
                            //}
                        }
                    }
                }
            }
        }
    }
}
