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
            int LivingTreesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Living Trees"));
            int BuriedChestsIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Buried Chests"));
            int FinalCleanupIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));

            if (LivingTreesIndex != -1)
            {
                tasks.Insert(LivingTreesIndex + 1, new MissingTreeLootGen("Adding Missing Tree Loot", 10f));
            }
            if (BuriedChestsIndex != -1)
            {
                tasks.Insert(BuriedChestsIndex + 1, new MissingShroomLootGen("Adding Missing Shroom Loot", 10f));
            }
            if (FinalCleanupIndex != -1)
            {
                tasks.Insert(FinalCleanupIndex + 1, new MissingMiscLootGen("Adding Other Missing Loot", 10f));
            }
        }



        public class MissingTreeLootGen : GenPass
        {
            public MissingTreeLootGen(string name, float loadWeight) : base(name, loadWeight) { }

            protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
            {
                progress.Message = "Adding Missing Tree Loot";

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
                while (missingTreeItems.Count > 0 && attempts < 10000)
                {
                    attempts++;
                    int posX = genRand.Next(beachDistance, Main.maxTilesX - beachDistance);
                    if (tenthAnniversaryWorldGen && !remixWorldGen)
                    {
                        posX = genRand.Next((int)((double)Main.maxTilesX * 0.15), (int)((float)Main.maxTilesX * 0.85f));
                    }
                    if (posX <= Main.maxTilesX / 2 - spawnSafeDistance || posX >= Main.maxTilesX / 2 + spawnSafeDistance)
                    {
                        int posY;
                        for (posY = 0; !Main.tile[posX, posY].active() && (double)posY < Main.worldSurface; posY++)
                        {
                        }
                        if (Main.tile[posX, posY].type == TileID.Dirt)
                        {
                            if (posY > 150)
                            {
                                bool validPos = true;
                                for (int tileCheckX = posX - 50; tileCheckX < posX + 50; tileCheckX++)
                                {
                                    for (int tileCheckY = posY - 50; tileCheckY < posY + 50; tileCheckY++)
                                    {
                                        if (Main.tile[tileCheckX, tileCheckY].active())
                                        {
                                            //Check for clouds and dungeon tiles.
                                            switch (Main.tile[tileCheckX, tileCheckY].type)
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
                                                goto finishedCloudCheck;
                                            }
                                        }
                                    }
                                }
                                posXOriginal = posX;
                                posYOriginal = posY;
                                posX -= 3
                                for (int tileCheckX = posX; tileCheckX < posX + 9; tileCheckX++)
                                {
                                    for (int tileCheckY = posY; tileCheckY < posY + 4; tileCheckY++)
                                    {
                                        if (Main.tile[tileCheckX, tileCheckY].active() && Main.tile[tileCheckX, tileCheckY].type != TileID.Dirt)
                                        {
                                                validPos = false;
                                                goto finishedCloudCheck;
                                        }
                                    }
                                }
                                posX -= 5
                                posY += 3
                                int xAdjust;
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
                                            if (!Main.tile[tileCheckX, tileCheckY].active() || Main.tile[tileCheckX, tileCheckY].type != TileID.Dirt)
                                            {
                                                    validPos = false;
                                                    goto finishedCloudCheck;
                                            }
                                        }
                                        else
                                        {
                                            if (Main.tile[tileCheckX, tileCheckY].active() && Main.tile[tileCheckX, tileCheckY].type != TileID.Dirt)
                                            {
                                                    validPos = false;
                                                    goto finishedCloudCheck;
                                            }
                                        }
                                    }
                                }
                                finishedTileCheck:
                                if (validPos)
                                {
                                    posX = posXOriginal;
                                    posY = posYOriginal + 2;
                                    int xAdjust;
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
                                                for (int i = -1; i < WorldGen.genRand.Next(4)-1; i++)
                                                {
                                                    if (i == -1)
                                                    {
                                                        continue;
                                                    }
                                                    if (tileCheckX > posX + 8 && tileCheckX < posX + 10)
                                                    {
                                                        PlaceWall(x, y-i, WallID.LivingWood)
                                                    }
                                                    else
                                                    {
                                                        PlaceTile(x, y-i, TileID.LivingWood);
                                                    }
                                                }
                                            }
                                            else if (tileCheckY < posY + 3)
                                            {
                                                if (tileCheckX > posX + 8 && tileCheckX < posX + 10)
                                                {
                                                    PlaceWall(x, y-i, WallID.LivingWood)
                                                }
                                                else
                                                {
                                                    PlaceTile(x, y-i, TileID.LivingWood);
                                                }
                                            }
                                            else if (tileCheckY < posY + 7)
                                            {
                                                PlaceTile(x, y-i, TileID.LivingWood);
                                            }
                                            else
                                            {
                                                int placeChance = 10 - tileCheckY - posY;
                                                if (WorldGen.genRand.NextBool(placeChance))
                                                {
                                                    PlaceTile(x, y-i, TileID.LivingWood);
                                                }
                                            }
                                        }
                                    }
                                    chestIndex = WorldGen.PlaceChest(posX+2, posY+8, style: 12);
                                    success = chestIndex != -1;
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
                progress.Message = "Adding Missing Shroom Loot";

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
                progress.Message = "Adding Other Missing Loot";

                #region Decide Dungeon Furniture Color
                int dungeonColor = 0;
                if (GenVars.dungeonSide == -1)
                {
                    for (int x = 0; x < Main.maxTilesX; x++)
                    {
                        for (int y = (int)GenVars.worldSurfaceHigh; y < Main.maxTilesY; y++)
                        {
                            int type = Main.tile[x, y].TileType;
                            if (type == TileID.BlueDungeonBrick || type == TileID.GreenDungeonBrick || type == TileID.PinkDungeonBrick)
                            {
                                dungeonColor = TileID.BlueDungeonBrick;
                                break;
                            }
                        }
                        if (dungeonColor != 0)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    for (int x = Main.maxTilesX; x < 0; x++)
                    {
                        for (int y = (int)GenVars.worldSurfaceHigh; y < Main.maxTilesY; y++)
                        {
                            int type = Main.tile[x, y].TileType;
                            if (type == TileID.BlueDungeonBrick || type == TileID.GreenDungeonBrick || type == TileID.PinkDungeonBrick)
                            {
                                dungeonColor = type;
                                break;
                            }
                        }
                        if (dungeonColor != 0)
                        {
                            break;
                        }
                    }
                }

                List<int> dungeonFurniture;

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
                            ItemID.BlueDungeonWorkBench
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
                            ItemID.GreenDungeonWorkBench
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
                            ItemID.PinkDungeonWorkBench
                        };
                        break;
                }
                #endregion

                List<int> terragrimChests = new();
                List<int> lockedGoldChests = new();
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

                    if (chestType1)
                    {
                        bool lockedGoldChest = tileFrameX == 2 * chestWidth;

                        if (lockedGoldChest)
                        {
                            lockedGoldChests.Add(chestIndex);
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
                                    chest.item[slot].stack = WorldGen.genRand.Next(2, 5);
                                    break;
                                }
                            }
                            dungeonFurniture.RemoveAt(0);
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
