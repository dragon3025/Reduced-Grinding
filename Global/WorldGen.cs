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

namespace ReducedGrinding.Global.WorldGeneration
{
    public class ReducedGrindingWorldGen : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int FinalCleanupIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));

            if (FinalCleanupIndex != -1)
            {
                tasks.Insert(FinalCleanupIndex + 1, new ReducedGrindingGen("Adding Non-Existing Loot", 10f));
            }
        }

        public class ReducedGrindingGen : GenPass
        {
            public ReducedGrindingGen(string name, float loadWeight) : base(name, loadWeight) { }

            protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
            {
                progress.Message = "Adding Non-Existing Loot";

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

                List<int> missingMushroomItems = new() { ItemID.ShroomMinecart, ItemID.MushroomHat };
                List<int> terragrimChests = new();
                List<int> lockedGoldChests = new();

                List<int> mushroomBiomes = new();

                void tryToPlaceMushroomChest(int mushroomBiome, int item)
                {
                    Point selectedBiomePosition = GenVars.mushroomBiomesPosition[mushroomBiome];
                    mushroomBiomes.Remove(mushroomBiome);

	                int attempts = 0;
                    bool success = false;
                    int x;
                    int y;

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
                            chestIndex = WorldGen.PlaceChest(x, y);
                            success = chestIndex != -1;
                        }
                    }
                    if(success)
                    {
                        Main.NewText($"Placed chest at {x}, {y} after {attempts} attempts.");
                    }
                    else
                    {
                        Main.NewText($"Failed to place chest after {attempts} attempts.");
                    }
                    if (chestIndex != -1)
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
                        if (item != -1)
                        {
                            missingMushroomItems.Remove(item);
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
                    bool chestType2 = Main.tile[chest.x, chest.y].TileType == TileID.Containers2;

                    short tileFrameX = Main.tile[chest.x, chest.y].TileFrameX;
                    int chestHeight = 36;

                    if (GetInstance<IOtherConfig>().TerragrimChestChance > 0)
                    {
                        bool regularChest = chestType1 && tileFrameX == 0;

                        if (!regularChest)
                        {
                            terragrimChests.Add(chestIndex);
                        }
                    }

                    if (chestType1)
                    {
                        bool mushroomChest = tileFrameX == 32 * chestHeight;
                        bool lockedGoldChest = tileFrameX == 2 * chestHeight;

                        if (mushroomChest)
                        {
                            if (missingMushroomItems.Count > 0)
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
                        else if (lockedGoldChest)
                        {
                            lockedGoldChests.Add(chestIndex);
                        }
                    }
                }

                while (missingMushroomItems.Count > 0 && MushroomBiomes > 0)
                {
                    tryToPlaceMushroomChest(MushroomBiomes[WorldGen.genRand.Next(mushroomBiomes.Count)], missingMushroomItems[0]);
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

                foreach (int chestIndex in terragrimChests)
                {
                    if (WorldGen.genRand.NextBool(GetInstance<IOtherConfig>().TerragrimChestChance))
                    {
                        Chest chest = Main.chest[chestIndex];
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
            }
        }
    }
}
