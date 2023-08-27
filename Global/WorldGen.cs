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
        readonly static IOtherConfig otherConfig = GetInstance<IOtherConfig>();

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {

            if (otherConfig.WorldGeneration.AddMissingTreeLoot)
            {
                int LivingTreesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Living Trees"));
                if (LivingTreesIndex != -1)
                {
                    tasks.Insert(LivingTreesIndex + 1, new MissingTreeLootGen("Adding missing tree loot", 10f));
                }
            }

            if (otherConfig.WorldGeneration.AddMissingShroomLoot)
            {
                int BuriedChestsIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Buried Chests"));
                if (BuriedChestsIndex != -1)
                {
                    tasks.Insert(BuriedChestsIndex + 1, new MissingShroomLootGen("Adding missing shroom loot", 10f));
                }
            }

            if (otherConfig.WorldGeneration.AddMissingPyramidLoot || otherConfig.WorldGeneration.TerragrimChestChance > 0)
            {
                int FinalCleanupIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
                if (FinalCleanupIndex != -1)
                {
                    tasks.Insert(FinalCleanupIndex + 1, new MissingMiscLootGen("Adding other missing loot", 10f));
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

                static void ClearAndPlaceWall(int x, int y, int wall_id)
                {
                    Main.tile[x, y].ClearEverything();
                    WorldGen.PlaceWall(x, y, wall_id, true);
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
                        if (Main.tile[posX, posY].TileType == TileID.Dirt &&
                            Main.tile[posX + 1, posY].TileType == TileID.Dirt &&
                            Main.tile[posX + 2, posY].TileType == TileID.Dirt)
                        {
                            if (posY > 150)
                            {
                                bool validPos = true;

                                int trunkLength = WorldGen.genRand.Next(5, 11);

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
                                    bool saplingFlip = WorldGen.genRand.NextBool(2);

                                    posY++;
                                    posX += saplingFlip ? 0 : 1;

                                    WorldGen.PlaceTile(posX + 1, posY, TileID.LeafBlock, true, true);
                                    WorldGen.PlaceTile(posX, posY + 1, TileID.LeafBlock, true, true);
                                    WorldGen.PlaceTile(posX + 2, posY + 1, TileID.LeafBlock, true, true);

                                    posY++;
                                    for (int i = 0; i < trunkLength; i++)
                                    {
                                        WorldGen.PlaceTile(posX + 1, posY + i, TileID.LivingWood, true, true);
                                    }

                                    posY += trunkLength;

                                    for (int i = 0; i < trunkLength; i++)
                                    {
                                        WorldGen.PlaceTile(posX, posY + i, TileID.LivingWood, true, true);
                                        ClearAndPlaceWall(posX + 1, posY + i, WallID.LivingWoodUnsafe);
                                        WorldGen.PlaceTile(posX + 2, posY + i, TileID.LivingWood, true, true);
                                    }

                                    posY += trunkLength;

                                    posX -= saplingFlip ? 0 : 1;

                                    for (int i = 0; i < 2; i++)
                                    {
                                        WorldGen.PlaceTile(posX, posY + i, TileID.LivingWood, true, true);
                                        ClearAndPlaceWall(posX + 1, posY + i, WallID.LivingWoodUnsafe);
                                        ClearAndPlaceWall(posX + 2, posY + i, WallID.LivingWoodUnsafe);
                                        WorldGen.PlaceTile(posX + 3, posY + i, TileID.LivingWood, true, true);
                                    }

                                    WorldGen.PlaceTile(posX + 1, posY + 2, TileID.LivingWood, true, true);
                                    WorldGen.PlaceTile(posX + 2, posY + 2, TileID.LivingWood, true, true);

                                    int chestIndex = WorldGen.PlaceChest(posX + 1, posY + 1, style: 12);

                                    Chest chest = null;
                                    if (chestIndex > -1)
                                    {
                                        chest = Main.chest[chestIndex];
                                    }
                                    if (chest != null)
                                    {
                                        int slot = 0;

                                        if (WorldGen.genRand.NextBool(3))
                                        {
                                            int stack = WorldGen.genRand.Next(40, 76);
                                            chest.item[slot].SetDefaults(282);
                                            chest.item[slot].stack = stack;
                                            slot++;
                                        }

                                        chest.item[slot].SetDefaults(missingTreeItems[0]);
                                        missingTreeItems.RemoveAt(0);
                                        chest.item[slot].Prefix(-1);
                                        slot++;

                                        #region Common Surface Chest Loot
                                        if (WorldGen.genRand.NextBool(6))
                                        {
                                            int stack = WorldGen.genRand.Next(40, 76);
                                            chest.item[slot].SetDefaults(282);
                                            chest.item[slot].stack = stack;
                                            slot++;
                                        }
                                        if (WorldGen.genRand.NextBool(6))
                                        {
                                            int stack2 = WorldGen.genRand.Next(150, 301);
                                            chest.item[slot].SetDefaults(279);
                                            chest.item[slot].stack = stack2;
                                            slot++;
                                        }
                                        if (WorldGen.genRand.NextBool(6))
                                        {
                                            chest.item[slot].SetDefaults(3093);
                                            chest.item[slot].stack = 1;
                                            if (WorldGen.genRand.NextBool(5))
                                            {
                                                chest.item[slot].stack += WorldGen.genRand.Next(2);
                                            }
                                            if (WorldGen.genRand.NextBool(10))
                                            {
                                                chest.item[slot].stack += WorldGen.genRand.Next(3);
                                            }
                                            slot++;
                                        }
                                        if (WorldGen.genRand.NextBool(6))
                                        {
                                            chest.item[slot].SetDefaults(4345);
                                            chest.item[slot].stack = 1;
                                            if (WorldGen.genRand.NextBool(5))
                                            {
                                                chest.item[slot].stack += WorldGen.genRand.Next(2);
                                            }
                                            if (WorldGen.genRand.NextBool(10))
                                            {
                                                chest.item[slot].stack += WorldGen.genRand.Next(3);
                                            }
                                            slot++;
                                        }
                                        if (WorldGen.genRand.NextBool(3))
                                        {
                                            chest.item[slot].SetDefaults(168);
                                            chest.item[slot].stack = WorldGen.genRand.Next(3, 6);
                                            slot++;
                                        }
                                        if (WorldGen.genRand.NextBool(2))
                                        {
                                            int num15 = WorldGen.genRand.Next(2);
                                            int stack3 = WorldGen.genRand.Next(8) + 3;
                                            if (num15 == 0)
                                            {
                                                chest.item[slot].SetDefaults(GenVars.copperBar);
                                            }
                                            if (num15 == 1)
                                            {
                                                chest.item[slot].SetDefaults(GenVars.ironBar);
                                            }
                                            chest.item[slot].stack = stack3;
                                            slot++;
                                        }
                                        if (WorldGen.genRand.NextBool(2))
                                        {
                                            int stack4 = WorldGen.genRand.Next(50, 101);
                                            chest.item[slot].SetDefaults(965);
                                            chest.item[slot].stack = stack4;
                                            slot++;
                                        }
                                        if (!WorldGen.genRand.NextBool(3))
                                        {
                                            int num16 = WorldGen.genRand.Next(2);
                                            int stack5 = WorldGen.genRand.Next(26) + 25;
                                            if (num16 == 0)
                                            {
                                                chest.item[slot].SetDefaults(40);
                                            }
                                            if (num16 == 1)
                                            {
                                                chest.item[slot].SetDefaults(42);
                                            }
                                            chest.item[slot].stack = stack5;
                                            slot++;
                                        }
                                        if (WorldGen.genRand.NextBool(2))
                                        {
                                            int stack6 = WorldGen.genRand.Next(3) + 3;
                                            chest.item[slot].SetDefaults(28);
                                            chest.item[slot].stack = stack6;
                                            slot++;
                                        }
                                        if (!WorldGen.genRand.NextBool(3))
                                        {
                                            chest.item[slot].SetDefaults(2350);
                                            chest.item[slot].stack = WorldGen.genRand.Next(3, 6);
                                            slot++;
                                        }
                                        if (WorldGen.genRand.Next(3) > 0)
                                        {
                                            int num17 = WorldGen.genRand.Next(6);
                                            int stack7 = WorldGen.genRand.Next(1, 3);
                                            if (num17 == 0)
                                            {
                                                chest.item[slot].SetDefaults(292);
                                            }
                                            if (num17 == 1)
                                            {
                                                chest.item[slot].SetDefaults(298);
                                            }
                                            if (num17 == 2)
                                            {
                                                chest.item[slot].SetDefaults(299);
                                            }
                                            if (num17 == 3)
                                            {
                                                chest.item[slot].SetDefaults(290);
                                            }
                                            if (num17 == 4)
                                            {
                                                chest.item[slot].SetDefaults(2322);
                                            }
                                            if (num17 == 5)
                                            {
                                                chest.item[slot].SetDefaults(2325);
                                            }
                                            chest.item[slot].stack = stack7;
                                            slot++;
                                        }
                                        if (WorldGen.genRand.NextBool(2))
                                        {
                                            int num18 = WorldGen.genRand.Next(2);
                                            int stack8 = WorldGen.genRand.Next(11) + 10;
                                            if (num18 == 0)
                                            {
                                                chest.item[slot].SetDefaults(8);
                                            }
                                            if (num18 == 1)
                                            {
                                                chest.item[slot].SetDefaults(31);
                                            }
                                            chest.item[slot].stack = stack8;
                                            slot++;
                                        }
                                        if (WorldGen.genRand.NextBool(2))
                                        {
                                            chest.item[slot].SetDefaults(72);
                                            chest.item[slot].stack = WorldGen.genRand.Next(10, 30);
                                            slot++;
                                        }
                                        if (WorldGen.genRand.NextBool(2))
                                        {
                                            chest.item[slot].SetDefaults(9);
                                            chest.item[slot].stack = WorldGen.genRand.Next(50, 100);
                                        }
                                        #endregion
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
                    int posX = 0;
                    int posY = 0;
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
                            posX = WorldGen.genRand.Next(selectedBiomePosition.X - 100, selectedBiomePosition.X + 100);
                            posY = WorldGen.genRand.Next(selectedBiomePosition.Y - 100, selectedBiomePosition.Y + 100);
                        }
                        if (
                            !Framing.GetTileSafely(posX, posY).HasTile &&
                            !Framing.GetTileSafely(posX, posY + 1).HasTile &&
                            !Framing.GetTileSafely(posX + 1, posY).HasTile &&
                            !Framing.GetTileSafely(posX + 1, posY + 1).HasTile &&
                            Framing.GetTileSafely(posX, posY + 2).TileType == TileID.MushroomGrass &&
                            Framing.GetTileSafely(posX + 1, posY + 2).TileType == TileID.MushroomGrass
                            )
                        {
                            success = WorldGen.AddBuriedChest(posX + 1, posY + 1, Style: 32);
                            int chestIndex = Chest.FindChest(posX, posY);
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
                                    Chest.DestroyChestDirect(posX, posY, chestIndex);
                                    Main.tile[posX, posY].ClearTile();
                                    Main.tile[posX, posY + 1].ClearTile();
                                    Main.tile[posX + 1, posY].ClearTile();
                                    Main.tile[posX + 1, posY + 1].ClearTile();
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

                List<int> missingPyramidItems = otherConfig.WorldGeneration.AddMissingPyramidLoot ? new() { ItemID.PharaohsMask, ItemID.FlyingCarpet } : new() { };
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

                    if (chestType1)
                    {
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
                    }

                    if (otherConfig.WorldGeneration.TerragrimChestChance > 0)
                    {
                        bool deepChest = chest.y > Main.rockLayer;

                        if (deepChest && WorldGen.genRand.NextBool(otherConfig.WorldGeneration.TerragrimChestChance))
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
