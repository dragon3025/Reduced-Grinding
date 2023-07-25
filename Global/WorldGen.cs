using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;
using System;
using ReducedGrinding.Configuration;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global.WorldGeneration
{
    public class ReducedGrindingWorldGen : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int DungeonIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Dungeon"));
            int LivingTreesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Living Trees"));
            int BuriedChestsIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Buried Chests"));
            int FinalCleanupIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));

            if (DungeonIndex != -1)
            {
                tasks.Insert(DungeonIndex + 1, new MissingDungeonFurniture("Adding missing dungeon furniture", 10f));
            }
            if (LivingTreesIndex != -1)
            {
                tasks.Insert(LivingTreesIndex + 1, new MissingTreeLootGen("Adding missing tree loot", 10f));
            }
            if (BuriedChestsIndex != -1)
            {
                tasks.Insert(BuriedChestsIndex + 1, new MissingShroomLootGen("Adding missing shroom loot", 10f));
            }
            if (FinalCleanupIndex != -1)
            {
                tasks.Insert(FinalCleanupIndex + 1, new MissingMiscLootGen("Adding other missing loot", 10f));
            }
        }

        public class MissingDungeonFurniture : GenPass
        {
            public MissingDungeonFurniture(string name, float loadWeight) : base(name, loadWeight) { }

            protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
            {
                progress.Message = "Adding missing dungeon furniture";

                int dungeonColor = 0;
                if (GenVars.dungeonSide == -1)
                {
                    for (int y = (int)GenVars.worldSurfaceHigh; y < Main.maxTilesY; y++)
                    {
                        for (int x = GenVars.beachBordersWidth; x < (Main.maxTilesX / 4); x++)
                        {
                            int type = Main.tile[x, y].TileType;
                            if (type == TileID.BlueDungeonBrick || type == TileID.GreenDungeonBrick || type == TileID.PinkDungeonBrick)
                            {
                                dungeonColor = TileID.BlueDungeonBrick;
                                goto FinishedDungeonColorCheck;
                            }
                        }
                    }
                }
                else
                {
                    for (int y = (int)GenVars.worldSurfaceHigh; y < Main.maxTilesY; y++)
                    {
                        for (int x = Main.maxTilesX - GenVars.beachBordersWidth; x > (Main.maxTilesX * 3 / 4); x--)
                        {
                            int type = Main.tile[x, y].TileType;
                            if (type == TileID.BlueDungeonBrick || type == TileID.GreenDungeonBrick || type == TileID.PinkDungeonBrick)
                            {
                                dungeonColor = type;
                                goto FinishedDungeonColorCheck;
                            }
                        }
                    }
                }

                FinishedDungeonColorCheck:
                List<int> dungeonFurniture;
                List<int> lockedGoldChests = new();

                #region Make Furniture List
                switch (dungeonColor)
                {
                    case TileID.BlueDungeonBrick:
                        dungeonFurniture = new()
                        {
                            ItemID.BlueDungeonBathtub,
                            ItemID.BlueDungeonBed,
                            ItemID.BlueDungeonBookcase,
                            ItemID.BlueDungeonCandelabra,
                            ItemID.BlueDungeonCandle,
                            ItemID.BlueDungeonChair,
                            ItemID.BlueDungeonChandelier,
                            ItemID.DungeonClockBlue,
                            ItemID.BlueDungeonDoor,
                            ItemID.BlueDungeonDresser,
                            ItemID.BlueDungeonLamp,
                            ItemID.BlueDungeonPiano,
                            ItemID.BlueDungeonSofa,
                            ItemID.BlueDungeonTable,
                            ItemID.BlueDungeonVase,
                            ItemID.BlueDungeonWorkBench,
                            3900 //Grandfather Clock
                        };
                        break;
                    case TileID.GreenDungeonBrick:
                        dungeonFurniture = new()
                        {
                            ItemID.GreenDungeonBathtub,
                            ItemID.GreenDungeonBed,
                            ItemID.GreenDungeonBookcase,
                            ItemID.GreenDungeonCandelabra,
                            ItemID.GreenDungeonCandle,
                            ItemID.GreenDungeonChair,
                            ItemID.GreenDungeonChandelier,
                            ItemID.DungeonClockGreen,
                            ItemID.GreenDungeonDoor,
                            ItemID.GreenDungeonDresser,
                            ItemID.GreenDungeonLamp,
                            ItemID.GreenDungeonPiano,
                            ItemID.GreenDungeonSofa,
                            ItemID.GreenDungeonTable,
                            ItemID.GreenDungeonVase,
                            ItemID.GreenDungeonWorkBench,
                            3901 //Grandfather Clock
                        };
                        break;
                    default:
                        dungeonFurniture = new()
                        {
                            ItemID.PinkDungeonBathtub,
                            ItemID.PinkDungeonBed,
                            ItemID.PinkDungeonBookcase,
                            ItemID.PinkDungeonCandelabra,
                            ItemID.PinkDungeonCandle,
                            ItemID.PinkDungeonChair,
                            ItemID.PinkDungeonChandelier,
                            ItemID.DungeonClockPink,
                            ItemID.PinkDungeonDoor,
                            ItemID.PinkDungeonDresser,
                            ItemID.PinkDungeonLamp,
                            ItemID.PinkDungeonPiano,
                            ItemID.PinkDungeonSofa,
                            ItemID.PinkDungeonTable,
                            ItemID.PinkDungeonVase,
                            ItemID.PinkDungeonWorkBench,
                            3902 //Grandfather Clock
                        };
                        break;
                }
                dungeonFurniture.Add(ItemID.GothicBookcase);
                dungeonFurniture.Add(ItemID.GothicChair);
                dungeonFurniture.Add(ItemID.GothicTable);
                dungeonFurniture.Add(ItemID.GothicWorkBench);
                dungeonFurniture.Add(ItemID.DungeonDoor);
                #endregion

                for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
                {
                    Chest chest = Main.chest[chestIndex];

                    if (chest == null)
                    {
                        continue;
                    }

                    bool chestType1 = Main.tile[chest.x, chest.y].TileType == TileID.Containers;

                    short tileFrameX = Main.tile[chest.x, chest.y].TileFrameX;
                    int chestWidth = 36;

                    if (chestType1)
                    {
                        bool lockedGoldChest = tileFrameX == 2 * chestWidth;

                        if (lockedGoldChest)
                        {
                            lockedGoldChests.Add(chestIndex);
                        }
                    }
                }


                if (GenVars.dungeonSide == -1)
                {
                    GetInstance<ReducedGrinding>().Logger.Debug("Furniture List Size: "+ dungeonFurniture.Count.ToString());
                    for (int y = (int)GenVars.worldSurfaceHigh; y < Main.maxTilesY; y++)
                    {
                        for (int x = GenVars.beachBordersWidth; x < (Main.maxTilesX / 4); x++)
                        {
                            int wall = Main.tile[x, y].WallType;
                            bool dungeonWall = ((wall >= 7 && wall <= 9) || (wall >= 94 && wall <= 99));
                            if (!dungeonWall)
                            {
                                continue;
                            }

                            int tileFrameX = Main.tile[x, y].TileFrameX / 18;
                            int tileFrameY = Main.tile[x, y].TileFrameY / 18;
                            switch (Main.tile[x, y].TileType)
                            {
                                case 41: //Dungeon Bricks
                                case 42:
                                case 43:
                                case 44:
                                case 481:
                                case 482:
                                case 483:
                                    break;
                                case TileID.Bathtubs:
                                    dungeonFurniture.Remove(ItemID.BlueDungeonBathtub);
                                    dungeonFurniture.Remove(ItemID.GreenDungeonBathtub);
                                    dungeonFurniture.Remove(ItemID.PinkDungeonBathtub);
                                    break;
                                case TileID.Beds:
                                    dungeonFurniture.Remove(ItemID.BlueDungeonBed);
                                    dungeonFurniture.Remove(ItemID.GreenDungeonBed);
                                    dungeonFurniture.Remove(ItemID.PinkDungeonBed);
                                    break;
                                case TileID.Bookcases:
                                    if (tileFrameX >= 3 && tileFrameX <= 9 && tileFrameY == 0)
                                    {
                                        dungeonFurniture.Remove(ItemID.BlueDungeonBookcase);
                                        dungeonFurniture.Remove(ItemID.GreenDungeonBookcase);
                                        dungeonFurniture.Remove(ItemID.PinkDungeonBookcase);
                                    }
                                    else if (tileFrameX == 15 && tileFrameY == 0)
                                    {
                                        dungeonFurniture.Remove(ItemID.GothicBookcase);
                                    }
                                    break;
                                case TileID.Candelabras:
                                    dungeonFurniture.Remove(ItemID.BlueDungeonCandelabra);
                                    dungeonFurniture.Remove(ItemID.GreenDungeonCandelabra);
                                    dungeonFurniture.Remove(ItemID.PinkDungeonCandelabra);
                                    break;
                                case TileID.Candles: //Water Candle has it's own Tile ID
                                    dungeonFurniture.Remove(ItemID.BlueDungeonCandle);
                                    dungeonFurniture.Remove(ItemID.GreenDungeonCandle);
                                    dungeonFurniture.Remove(ItemID.PinkDungeonCandle);
                                    break;
                                case TileID.Chairs:
                                    tileFrameY = Main.tile[x, y].TileFrameY / 20;
                                    if (tileFrameY >= 26 && tileFrameY <= 30)
                                    {
                                        dungeonFurniture.Remove(ItemID.BlueDungeonChair);
                                        dungeonFurniture.Remove(ItemID.GreenDungeonChair);
                                        dungeonFurniture.Remove(ItemID.PinkDungeonChair);
                                    }
                                    else if (tileFrameY == 34)
                                    {
                                        dungeonFurniture.Remove(ItemID.GothicChair);
                                    }
                                    break;
                                case TileID.Chandeliers:
                                    dungeonFurniture.Remove(ItemID.BlueDungeonChandelier);
                                    dungeonFurniture.Remove(ItemID.GreenDungeonChandelier);
                                    dungeonFurniture.Remove(ItemID.PinkDungeonChandelier);
                                    break;
                                case TileID.GrandfatherClocks:
                                    dungeonFurniture.Remove(3900);
                                    dungeonFurniture.Remove(3901);
                                    dungeonFurniture.Remove(3902);
                                    break;
                                case TileID.OpenDoor:
                                    if (tileFrameX < 4 && tileFrameY >= 48 && tileFrameY <= 54)
                                    {
                                        dungeonFurniture.Remove(ItemID.BlueDungeonDoor);
                                        dungeonFurniture.Remove(ItemID.GreenDungeonDoor);
                                        dungeonFurniture.Remove(ItemID.PinkDungeonDoor);
                                    }
                                    else if (tileFrameX < 4 && tileFrameY == 39)
                                    {
                                        dungeonFurniture.Remove(ItemID.DungeonDoor);
                                    }
                                    break;
                                case TileID.ClosedDoor:
                                    if (tileFrameX < 3 && tileFrameY >= 48 && tileFrameY <= 54)
                                    {
                                        dungeonFurniture.Remove(ItemID.BlueDungeonDoor);
                                        dungeonFurniture.Remove(ItemID.GreenDungeonDoor);
                                        dungeonFurniture.Remove(ItemID.PinkDungeonDoor);
                                    }
                                    else if (tileFrameX < 3 && tileFrameY == 39)
                                    {
                                        dungeonFurniture.Remove(ItemID.DungeonDoor);
                                    }
                                    break;
                                case TileID.Dressers:
                                    dungeonFurniture.Remove(ItemID.BlueDungeonDresser);
                                    dungeonFurniture.Remove(ItemID.GreenDungeonDresser);
                                    dungeonFurniture.Remove(ItemID.PinkDungeonDresser);
                                    break;
                                case TileID.Lamps:
                                    dungeonFurniture.Remove(ItemID.BlueDungeonLamp);
                                    dungeonFurniture.Remove(ItemID.GreenDungeonLamp);
                                    dungeonFurniture.Remove(ItemID.PinkDungeonLamp);
                                    break;
                                case TileID.Pianos:
                                    dungeonFurniture.Remove(ItemID.BlueDungeonPiano);
                                    dungeonFurniture.Remove(ItemID.GreenDungeonPiano);
                                    dungeonFurniture.Remove(ItemID.PinkDungeonPiano);
                                    break;
                                case 89: //Sofas
                                    dungeonFurniture.Remove(ItemID.BlueDungeonSofa);
                                    dungeonFurniture.Remove(ItemID.GreenDungeonSofa);
                                    dungeonFurniture.Remove(ItemID.PinkDungeonSofa);
                                    break;
                                case TileID.Tables:
                                    if (tileFrameX >= 30 && tileFrameX <= 36 && tileFrameY == 0)
                                    {
                                        dungeonFurniture.Remove(ItemID.BlueDungeonTable);
                                        dungeonFurniture.Remove(ItemID.GreenDungeonTable);
                                        dungeonFurniture.Remove(ItemID.PinkDungeonTable);
                                    }
                                    else if (tileFrameX == 42 && tileFrameY == 0)
                                    {
                                        dungeonFurniture.Remove(ItemID.GothicTable);
                                    }
                                    break;
                                case TileID.Statues:
                                    if (tileFrameX >= 92 && tileFrameX <= 96 && tileFrameY == 0)
                                    {
                                        dungeonFurniture.Remove(ItemID.BlueDungeonVase);
                                        dungeonFurniture.Remove(ItemID.GreenDungeonVase);
                                        dungeonFurniture.Remove(ItemID.PinkDungeonVase);
                                    }
                                    break;
                                case TileID.WorkBenches:
                                    if (tileFrameX >= 22 && tileFrameX <= 26 && tileFrameY == 0)
                                    {
                                        dungeonFurniture.Remove(ItemID.BlueDungeonWorkBench);
                                        dungeonFurniture.Remove(ItemID.GreenDungeonWorkBench);
                                        dungeonFurniture.Remove(ItemID.PinkDungeonWorkBench);
                                    }
                                    else if (tileFrameX == 30 && tileFrameY == 0)
                                    {
                                        dungeonFurniture.Remove(ItemID.GothicWorkBench);
                                    }
                                    break;
                            }
                        }
                    }
                    GetInstance<ReducedGrinding>().Logger.Debug("Furniture List Size (New): "+ dungeonFurniture.Count.ToString());
                }

                while (dungeonFurniture.Count > 0)
                {
                    foreach (int chestIndex in lockedGoldChests)
                    {
                        if (dungeonFurniture.Count > 0)
                        {
                            Chest chest = Main.chest[chestIndex];
                            for (int slot = 0; slot < 40; slot++)
                            {
                                if (chest.item[slot].type == ItemID.None)
                                {
                                    chest.item[slot].SetDefaults(dungeonFurniture[0]);
                                    chest.item[slot].stack = WorldGen.genRand.Next(1, 3);
                                    break;
                                }
                            }
                            dungeonFurniture.RemoveAt(0);
                        }
                    }
                }
            }
        }

        public class MissingTreeLootGen : GenPass
        {
            public MissingTreeLootGen(string name, float loadWeight) : base(name, loadWeight) { }

            protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
            {
                progress.Message = "Adding missing tree loot";

                List<int> missingTreeItems = new() { ItemID.SunflowerMinecart, ItemID.LadybugMinecart };

                for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
                {
                    Chest chest = Main.chest[chestIndex];

                    if (chest == null)
                    {
                        continue;
                    }

                    bool chestType1 = Main.tile[chest.x, chest.y].TileType == TileID.Containers;

                    short tileFrameX = Main.tile[chest.x, chest.y].TileFrameX;
                    int chestWidth = 36;

                    bool treeChest = tileFrameX == 12 * chestWidth;

                    if (treeChest && missingTreeItems.Count > 0)
                    {
                        for (int slot = 0; slot < 40; slot++)
                        {
                            List<int> missingTreeItemsOld = new();
                            missingTreeItemsOld.AddRange(missingTreeItems);

                            foreach (int itemType in missingTreeItemsOld)
                            {
                                if (chest.item[slot].type == itemType)
                                {
                                    missingTreeItems.Remove(itemType);
                                }
                            }
                        }
                    }
                }

                int attempts = 0;
                int spawnSafeDistance = 200;
                while (missingTreeItems.Count > 0 && attempts < 10000)
                {
                    attempts++;
                    int posX = WorldGen.genRand.Next(WorldGen.beachDistance, Main.maxTilesX - WorldGen.beachDistance);
                    if (WorldGen.tenthAnniversaryWorldGen && !WorldGen.remixWorldGen)
                    {
                        posX = WorldGen.genRand.Next((int)((double)Main.maxTilesX * 0.15), (int)((float)Main.maxTilesX * 0.85f));
                    }
                    if (posX <= Main.maxTilesX / 2 - spawnSafeDistance || posX >= Main.maxTilesX / 2 + spawnSafeDistance)
                    {
                        int posY = 0;
                        for (; !Main.tile[posX, posY].HasTile && (double)posY < Main.worldSurface; posY++)
                        {
                        }
                        if (Main.tile[posX, posY].TileType == TileID.Dirt)
                        {
                            if (posY > 150)
                            {
                                //int posXOriginal = posX; //Temporary
                                //int posYOriginal = posY;
                                int xAdjust;
                                bool validPos = true;

                                //Temporary====================================
                                posX = 50 * missingTreeItems.Count;
                                posY = 50;
                                int posXOriginal = posX;
                                int posYOriginal = posY;
                                goto finishedTileCheck;
                                //============================================

                                for (int tileCheckX = posX - 50; tileCheckX < posX + 50; tileCheckX++)
                                {
                                    for (int tileCheckY = posY - 50; tileCheckY < posY + 50; tileCheckY++)
                                    {
                                        if (Main.tile[tileCheckX, tileCheckY].HasTile)
                                        {
                                            //Check for clouds and dungeon tiles.
                                            switch (Main.tile[tileCheckX, tileCheckY].TileType)
                                            {
                                                case 41:
                                                case 43:
                                                case 44:
                                                case 189:
                                                case 196:
                                                case 460:
                                                case 481:
                                                case 482:
                                                case 483:
                                                    validPos = false;
                                                    goto finishedTileCheck;
                                            }
                                        }
                                    }
                                }
                                posX -= 3;
                                for (int tileCheckX = posX; tileCheckX < posX + 9; tileCheckX++)
                                {
                                    for (int tileCheckY = posY; tileCheckY < posY + 4; tileCheckY++)
                                    {
                                        if (Main.tile[tileCheckX, tileCheckY].HasTile && Main.tile[tileCheckX, tileCheckY].TileType != TileID.Dirt)
                                        {
                                            validPos = false;
                                            goto finishedTileCheck;
                                        }
                                    }
                                }
                                posX -= 5;
                                posY += 3;
                                for (int tileCheckX = posX; tileCheckX < posX + 18; tileCheckX++)
                                {
                                    for (int tileCheckY = posY; tileCheckY < posY + 9; tileCheckY++)
                                    {
                                        xAdjust = Math.Max(0, tileCheckY - posY - 3);
                                        if (tileCheckX < posX + 5 - xAdjust || tileCheckX > posX + 13 + xAdjust)
                                        {
                                            continue;
                                        }
                                        if (tileCheckY < posY + 6)
                                        {
                                            if (!Main.tile[tileCheckX, tileCheckY].HasTile || Main.tile[tileCheckX, tileCheckY].TileType != TileID.Dirt)
                                            {
                                                validPos = false;
                                                goto finishedTileCheck;
                                            }
                                        }
                                        else
                                        {
                                            if (Main.tile[tileCheckX, tileCheckY].HasTile && Main.tile[tileCheckX, tileCheckY].TileType != TileID.Dirt)
                                            {
                                                validPos = false;
                                                goto finishedTileCheck;
                                            }
                                        }
                                    }
                                }
                            finishedTileCheck:
                                if (validPos)
                                {
                                    posX = posXOriginal;
                                    posY = posYOriginal + 2;
                                    for (int tileCheckX = posX; tileCheckX < posX + 18; tileCheckX++)
                                    {
                                        for (int tileCheckY = posY; tileCheckY < posY + 10; tileCheckY++)
                                        {
                                            xAdjust = Math.Max(0, tileCheckY - posY - 4);
                                            if (tileCheckX < posX + 5 - xAdjust || tileCheckX > posX + 13 + xAdjust)
                                            {
                                                continue;
                                            }
                                            if (tileCheckY == posY)
                                            {
                                                for (int i = -1; i < WorldGen.genRand.Next(4) - 1; i++)
                                                {
                                                    if (i == -1)
                                                    {
                                                        continue;
                                                    }
                                                    if (tileCheckX > posX + 8 && tileCheckX < posX + 10)
                                                    {
                                                        WorldGen.PlaceWall(tileCheckX, tileCheckY - i, WallID.Granite); //, WallID.LivingWood); Temporary
                                                    }
                                                    else
                                                    {
                                                        WorldGen.PlaceTile(tileCheckX, tileCheckY - i, TileID.Granite); //, TileID.LivingWood);
                                                    }
                                                }
                                            }
                                            else if (tileCheckY < posY + 3)
                                            {
                                                if (tileCheckX > posX + 8 && tileCheckX < posX + 10)
                                                {
                                                    WorldGen.PlaceWall(tileCheckX, tileCheckY, WallID.Granite); //, WallID.LivingWood); Temporary
                                                }
                                                else
                                                {
                                                    WorldGen.PlaceTile(tileCheckX, tileCheckY, TileID.Granite); //, TileID.LivingWood);
                                                }
                                            }
                                            else if (tileCheckY < posY + 7)
                                            {
                                                WorldGen.PlaceTile(tileCheckX, tileCheckY, TileID.Granite); //, TileID.LivingWood);
                                            }
                                            else
                                            {
                                                int placeChance = tileCheckY - posY - 6;
                                                if (WorldGen.genRand.NextBool(placeChance))
                                                {
                                                    WorldGen.PlaceTile(tileCheckX, tileCheckY, TileID.Granite); //, TileID.LivingWood);
                                                }
                                            }
                                        }
                                    }
                                    int chestIndex = WorldGen.PlaceChest(posX + 2, posY + 8, style: 12);
                                    bool success = chestIndex != -1;
                                    if (success)
                                    {
                                        Chest chest = Main.chest[chestIndex];

                                        chest.item[0].SetDefaults(missingTreeItems[0]);
                                        missingTreeItems.RemoveAt(0);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public class MissingShroomLootGen : GenPass
        {
            public MissingShroomLootGen(string name, float loadWeight) : base(name, loadWeight) { }

            protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
            {
                progress.Message = "Adding missing shroom loot";

                List<int> missingMushroomItems = new() { ItemID.ShroomMinecart, ItemID.MushroomHat };
                List<int> mushroomBiomes = new();

                void tryToPlaceMushroomChest(int mushroomBiome, int item)
                {
                    Point selectedBiomePosition = GenVars.mushroomBiomesPosition[mushroomBiome];
                    mushroomBiomes.Remove(mushroomBiome);

	                int attempts = 0;
                    bool success = false;
                    int x = 0;
                    int y = 0;

                    int chestIndex = -1;
                    while (!success) {
                        attempts++;
                        if (attempts > 10000) {
                            break;
                        }
                        x = WorldGen.genRand.Next(selectedBiomePosition.X - 100, selectedBiomePosition.X + 100);
                        y = WorldGen.genRand.Next(selectedBiomePosition.Y - 100, selectedBiomePosition.Y + 100);
                        if (Framing.GetTileSafely(x, y+1).TileType == TileID.MushroomGrass)
                        {
                            chestIndex = WorldGen.PlaceChest(x, y, style: 32);
                            success = chestIndex != -1;
                        }
                    }
                    if (success)
                    {
                        Chest chest = Main.chest[chestIndex];

                        int slot = 0;
                        if (item == ItemID.MushroomHat)
                        {
                            chest.item[slot].SetDefaults(ItemID.MushroomHat);
                            slot++;
                            chest.item[slot].SetDefaults(ItemID.MushroomVest);
                            slot++;
                            chest.item[slot].SetDefaults(ItemID.MushroomPants);
                            slot++;
                        }
                        else
                        {
                            chest.item[0].SetDefaults(ItemID.ShroomMinecart);
                        }
                        missingMushroomItems.Remove(item);
                    }
                }

                for (int i = 0; i < GenVars.mushroomBiomesPosition.Length; i++)
                {
                    if (GenVars.mushroomBiomesPosition[i].X != 0 && GenVars.mushroomBiomesPosition[i].Y != 0)
                    {
                        mushroomBiomes.Add(i);
                    }
                }

                for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
                {
                    Chest chest = Main.chest[chestIndex];

                    if (chest == null)
                    {
                        continue;
                    }

                    bool chestType1 = Main.tile[chest.x, chest.y].TileType == TileID.Containers;

                    short tileFrameX = Main.tile[chest.x, chest.y].TileFrameX;
                    int chestWidth = 36;

                    if (chestType1)
                    {
                        bool mushroomChest = tileFrameX == 32 * chestWidth;

                        if (mushroomChest && missingMushroomItems.Count > 0)
                        {
                            for (int slot = 0; slot < 40; slot++)
                            {
                                List<int> missingMushroomItemsOld = new();
                                missingMushroomItemsOld.AddRange(missingMushroomItems);

                                foreach (int itemType in missingMushroomItemsOld)
                                {
                                    if (chest.item[slot].type == itemType)
                                    {
                                        missingMushroomItems.Remove(itemType);
                                    }
                                }
                            }
                        }
                    }
                }

                while (missingMushroomItems.Count > 0 && mushroomBiomes.Count > 0)
                {
                    tryToPlaceMushroomChest(mushroomBiomes[WorldGen.genRand.Next(mushroomBiomes.Count)], missingMushroomItems[0]);
                }
            }
        }

        public class MissingMiscLootGen : GenPass
        {
            public MissingMiscLootGen(string name, float loadWeight) : base(name, loadWeight) { }

            protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
            {
                progress.Message = "Adding other missing loot";

                List<int> terragrimChests = new();
                List<int> missingPyramidItems = new() { ItemID.PharaohsMask, ItemID.FlyingCarpet };
                List<int> sandstoneChests = new();

                for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
                {
                    Chest chest = Main.chest[chestIndex];

                    if (chest == null)
                    {
                        continue;
                    }

                    bool chestType1 = Main.tile[chest.x, chest.y].TileType == TileID.Containers;
                    bool chestType2 = Main.tile[chest.x, chest.y].TileType == TileID.Containers2;

                    short tileFrameX = Main.tile[chest.x, chest.y].TileFrameX;
                    int chestWidth = 36;

                    bool goldChest = tileFrameX == 1 * chestWidth;

                    if (goldChest && missingPyramidItems.Count > 0)
                    {
                        for (int slot = 0; slot < 40; slot++)
                        {
                            List<int> missingPyramidItemsOld = new();
                            missingPyramidItemsOld.AddRange(missingPyramidItems);

                            foreach (int itemType in missingPyramidItemsOld)
                            {
                                if (chest.item[slot].type == itemType)
                                {
                                    missingPyramidItems.Remove(itemType);
                                }
                            }
                        }
                    }

                    if (GetInstance<IOtherConfig>().TerragrimChestChance > 0)
                    {
                        bool regularChest = chestType1 && tileFrameX == 0;

                        if (!regularChest && WorldGen.genRand.NextBool(GetInstance<IOtherConfig>().TerragrimChestChance))
                        {
                            for (int slot = 0; slot < 40; slot++)
                            {
                                if (chest.item[slot].type == ItemID.None)
                                {
                                    chest.item[slot].SetDefaults(ItemID.Terragrim);
                                    break;
                                }
                            }
                        }
                    }

                    if (chestType2)
                    {
                        bool sandstoneChest = tileFrameX == 10 * chestWidth;

                        if (sandstoneChest)
                        {
                            sandstoneChests.Add(chestIndex);
                        }
                    }
                }

                while (missingPyramidItems.Count > 0 && sandstoneChests.Count > 0)
                {
                    Chest chest = Main.chest[sandstoneChests[WorldGen.genRand.Next(sandstoneChests.Count)]];
                    for (int slot = 0; slot < 40; slot++)
                    {
                        if (chest.item[slot].type == ItemID.None)
                        {
                            chest.item[slot].SetDefaults(missingPyramidItems[0]);
                            if (missingPyramidItems[0] == ItemID.PharaohsMask)
                            {
                                if (slot == 39)
                                {
                                    chest.item[slot].SetDefaults(ItemID.PharaohsRobe);
                                }
                                else
                                {
                                    if (chest.item[slot+1].type == ItemID.None)
                                    {
                                        chest.item[slot+1].SetDefaults(ItemID.PharaohsRobe);
                                    }
                                    else
                                    {
                                        chest.item[slot].SetDefaults(ItemID.PharaohsRobe);
                                    }
                                }
                            }
                            missingPyramidItems.RemoveAt(0);
                            break;
                        }
                    }
                }
            }
        }
    }
}
