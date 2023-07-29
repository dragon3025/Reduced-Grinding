using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global.WorldGeneration
{
    public class ReducedGrindingWorldGen : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {

            int LivingTreesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Living Trees"));
            if (LivingTreesIndex != -1)
            {
                tasks.Insert(LivingTreesIndex + 1, new MissingTreeLootGen("Adding missing tree loot", 10f));
            }

            int BuriedChestsIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Buried Chests"));
            if (BuriedChestsIndex != -1)
            {
                tasks.Insert(BuriedChestsIndex + 1, new MissingShroomLootGen("Adding missing shroom loot", 10f));
            }

            int FinalCleanupIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
            if (FinalCleanupIndex != -1)
            {
                tasks.Insert(FinalCleanupIndex + 1, new MissingMiscLootGen("Adding other missing loot", 10f));
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

                    if (chestType1)
                    {
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
                                bool validPos = true;

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
                            finishedTileCheck:
                                if (validPos)
                                {
                                    posY--;
                                    int chestIndex = WorldGen.PlaceChest(posX, posY, style: 12);
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
                /*
                // TO-DO My ability to test generation is very limited right now. When I can, try to make this the new
                // Living Wood Chest generation. NOTE: I DISCOVERED BEACH GEN WILL WIPE OUT PLACED TILES AND CHEST!
                int attempts = 0;
                int spawnSafeDistance = 200;
                int treePlacements = 0; //temporary

                while (treePlacements < 3 && attempts < 10000) //(missingTreeItems.Count > 0 && attempts < 10000) temporary
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
                                posX = 50 * treePlacements;
                                posY = 50;
                                int posXOriginal = posX;
                                int posYOriginal = posY;
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
                            finishedTileCheck:
                                if (validPos)
                                {
                                    treePlacements++; //Temporary
                                    posX = posXOriginal - 1;
                                    posY = posYOriginal - 3;
                                    int trunkLength = WorldGen.genRand.Next(17,26);
                                    for (int tileCheckX = posX; tileCheckX < posX + 5; tileCheckX++)
                                    {
                                        for (int tileCheckY = posY; tileCheckY < posY + trunkLength; tileCheckY++)
                                        {
                                            if (
                                                tileCheckY > posY &&
                                                tileCheckY < (posY + trunkLength) &&
                                                tileCheckX > posX &&
                                                tileCheckX < (posX + 5))
                                            {
                                                Main.tile[tileCheckX, tileCheckY].ClearTile()
                                                WorldGen.PlaceWall(tileCheckX, tileCheckY, WallID.Granite); //, WallID.LivingWood); Temporary
                                            }
                                            else
                                            {
                                                WorldGen.PlaceTile(tileCheckX, tileCheckY - i, TileID.Granite); //, TileID.LivingWood);
                                            }
                                        }
                                    }

                                    WorldGen.PlaceTile(posX + 1, posY + 3, TileID.Platform, style: 23);
                                    WorldGen.PlaceTile(posX + 2, posY + 3, TileID.Platform, style: 23);

                                    int chestIndex = WorldGen.PlaceChest(posX + 1, posY + trunkLength - 2, style: 12);
                                    bool success = chestIndex != -1;
                                    if (success)
                                    {
                                        Chest chest = Main.chest[chestIndex];

                                        chest.item[0].SetDefaults(missingTreeItems[0]);
                                        missingTreeItems.RemoveAt(0);
                                    }

                                    trunkLength = WorldGen.genRand.Next(5,11);
                                    posX += 1
                                    posY -= trunkLength
                                    for (int tileCheckX = posX; tileCheckX < posX + 3; tileCheckX++)
                                    {
                                        for (int tileCheckY = posY; tileCheckY < posY + trunkLength + 1; tileCheckY++)
                                        {
                                            WorldGen.PlaceTile(tileCheckX, tileCheckY, TileID.Granite); //, TileID.LivingWood);
                                        }
                                    }
                                    int leftBranchX = posX;
                                    int leftBranchY = posY;
                                    int leftBranchLength = WorldGen.genRand.Next(5, 11);
                                    int rightBranchX = posX+1;
                                    int rightBranchX = posY;
                                    int rightBranchLength = WorldGen.genRand.Next(5, 11);
                                    while (leftBranchLength > 0)
                                    {
                                        leftBranchLength--
                                        if (WorldGen.genRand.NextBool(2))
                                        {
                                            leftBranchX--;
                                        }
                                        else (WorldGen.genRand.NextBool(2))
                                        {
                                            leftBranchY--;
                                        }
                                        WorldGen.PlaceTile(leftBranchX, leftBranchY, TileID.Granite); //, TileID.LivingWood);
                                        if (leftBranchLength == 0)
                                        {
                                            Point point = new Point(leftBranchX, leftBranchY);
                                            WorldUtils.Gen(point, new Shapes.Circle(7 + WorldGen.genRand.Next(0, 2), 7 + WorldGen.genRand.Next(0, 2)), Actions.Chain(new GenAction[]
                                            {
                                                new Actions.SetTile(TileID.LeafBlock),
                                            }));
                                        }
                                    }
                                    while (rightBranchLength < 0)
                                    {
                                        rightBranchLength--
                                        if (WorldGen.genRand.NextBool(2))
                                        {
                                            rightBranchX++;
                                        }
                                        else (WorldGen.genRand.NextBool(2))
                                        {
                                            rightBranchY--;
                                        }
                                        WorldGen.PlaceTile(rightBranchX, rightBranchY, TileID.Granite); //, TileID.LivingWood);
                                        if (rightBranchLength == 0)
                                        {
                                            Point point = new Point(rightBranchX, rightBranchY);
                                            WorldUtils.Gen(point, new Shapes.Circle(7 + WorldGen.genRand.Next(0, 2), 7 + WorldGen.genRand.Next(0, 2)), Actions.Chain(new GenAction[]
                                            {
                                                new Actions.SetTile(TileID.LeafBlock),
                                            }));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                */
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
                    bool validLocation = false;

                    while (!success)
                    {
                        attempts++;
                        if (attempts > 10000)
                        {
                            break;
                        }
                        if (!validLocation)
                        {
                            x = WorldGen.genRand.Next(selectedBiomePosition.X - 100, selectedBiomePosition.X + 100);
                            y = WorldGen.genRand.Next(selectedBiomePosition.Y - 100, selectedBiomePosition.Y + 100);
                        }
                        if (
                            !Framing.GetTileSafely(x, y).HasTile &&
                            !Framing.GetTileSafely(x, y + 1).HasTile &&
                            !Framing.GetTileSafely(x + 1, y).HasTile &&
                            !Framing.GetTileSafely(x + 1, y + 1).HasTile &&
                            Framing.GetTileSafely(x, y + 2).TileType == TileID.MushroomGrass &&
                            Framing.GetTileSafely(x + 1, y + 2).TileType == TileID.MushroomGrass
                            )
                        {
                            success = WorldGen.AddBuriedChest(x + 1, y + 1, Style: 32);
                            int chestIndex = Chest.FindChest(x, y);
                            if (chestIndex > -1)
                            {
                                Chest chest = Main.chest[chestIndex];
                                bool correctItem = false;
                                for (int i = 0; i < 40; i++)
                                {
                                    if (chest.item[i].type == item)
                                    {
                                        correctItem = true;
                                        break;
                                    }
                                }
                                if (!correctItem)
                                {
                                    if (!validLocation)
                                    {
                                        validLocation = true;
                                        attempts = 0;
                                    }
                                    success = false;
                                    Chest.DestroyChestDirect(x, y, chestIndex);
                                    Main.tile[x, y].ClearTile();
                                    Main.tile[x, y + 1].ClearTile();
                                    Main.tile[x + 1, y].ClearTile();
                                    Main.tile[x + 1, y + 1].ClearTile();
                                }
                                else
                                {
                                    missingMushroomItems.Remove(item);
                                }
                            }
                        }
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
                        bool deepChest = chest.y > Main.rockLayer;

                        if (deepChest && WorldGen.genRand.NextBool(GetInstance<IOtherConfig>().TerragrimChestChance))
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
                                    if (chest.item[slot + 1].type == ItemID.None)
                                    {
                                        chest.item[slot + 1].SetDefaults(ItemID.PharaohsRobe);
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
