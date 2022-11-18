using Microsoft.Xna.Framework;
using System;
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
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
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
                //TO-DO 1.4.4+ will contain secret seeds that flip progression upsidedown and the vanilla worldgen adjust to this. This mod will also have to adjsut to it.

                progress.Message = "Adding Non-Existing Loot";

                int dungeonColor = 0;
                if (WorldGen.dungeonSide == -1)
                {
                    for (int x = 0; x < Main.maxTilesX; x++)
                    {
                        for (int y = (int)WorldGen.worldSurfaceHigh; y < Main.maxTilesY; y++)
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
                        for (int y = (int)WorldGen.worldSurfaceHigh; y < Main.maxTilesY; y++)
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

                List<int> dungeonFurniture = new();

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

                List<int> missingMushroomItems = new() { ItemID.ShroomMinecart, ItemID.MushroomHat };
                //TO-DO Remove changes to Skyware Chests when 1.4.4+ comes out
                List<int> missingSkywareItems = new() {
                    ItemID.ShinyRedBalloon,
                    ItemID.Starfury,
                    ItemID.LuckyHorseshoe,
                    ItemID.CelestialMagnet
                }; //Vanilla Skyware items will generate making sure to add rare items that haven't been added yet by going down the list, then it will be random.
				
				if (!GetInstance<IOtherConfig>().FutureFledglingChestChance)
				{
					missingSkywareItems.Add(ItemID.CreativeWings);
				}
				
                List<int> terragrimChests = new();
                List<int> nonSkywareChests = new(); //TO-DO Remove when 1.4.4+ comes out
                List<int> lockedGoldChest = new();

                void tryToPlaceMushroomChest(int mushroomBiome, int item = -1)
                {
                    Point biomePosition = WorldGen.mushroomBiomesPosition[mushroomBiome].ToPoint();

                    for (int i = 0; i < 5; i++)
                    {
                        int x = WorldGen.genRand.Next(biomePosition.X - 100, biomePosition.X + 100);
                        int y = WorldGen.genRand.Next(biomePosition.Y - 100, biomePosition.Y + 100);
                        int yDirection = 1;
                        if (y > biomePosition.Y)
                        {
                            yDirection = -1;
                        }

                        for (; (yDirection == 1 && y < biomePosition.Y + 100) || (yDirection == -1 && y > biomePosition.Y - 100); y += yDirection)
                        {
                            if (Framing.GetTileSafely(x, y).TileType == TileID.MushroomPlants)
                            {
                                for (int chestX = x - 5; chestX < x + 5; chestX++)
                                {
                                    int chestIndex = WorldGen.PlaceChest(chestX, y, style: 32);
                                    if (chestIndex != -1)
                                    {
                                        Chest chest = Main.chest[chestIndex];

                                        int slot = 0;
                                        if (item == ItemID.MushroomHat || (item != ItemID.ShroomMinecart && WorldGen.genRand.NextBool(2)))
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
                                            slot++;
                                        }
                                        slot++;
                                        if (item != -1)
                                        {
                                            missingMushroomItems.Remove(item);
                                        }

                                        #region Common Loot Based on World Layer (no Primary or Secondary Loot)
                                        if (y < WorldGen.rockLayer)
                                        {
                                            if (WorldGen.genRand.NextBool(3))
                                            {
                                                chest.item[slot].SetDefaults(166);
                                                chest.item[slot].stack = WorldGen.genRand.Next(10, 20);
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(5))
                                            {
                                                chest.item[slot].SetDefaults(52);
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(3))
                                            {
                                                int stack9 = WorldGen.genRand.Next(50, 101);
                                                chest.item[slot].SetDefaults(965);
                                                chest.item[slot].stack = stack9;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(2))
                                            {
                                                int itemChance = WorldGen.genRand.Next(2);
                                                int stack10 = WorldGen.genRand.Next(10) + 5;
                                                if (itemChance == 0)
                                                {
                                                    chest.item[slot].SetDefaults(WorldGen.ironBar);
                                                }
                                                if (itemChance == 1)
                                                {
                                                    chest.item[slot].SetDefaults(WorldGen.silverBar);
                                                }
                                                chest.item[slot].stack = stack10;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(2))
                                            {
                                                int itemChance = WorldGen.genRand.Next(2);
                                                int stack11 = WorldGen.genRand.Next(25) + 25;
                                                if (itemChance == 0)
                                                {
                                                    chest.item[slot].SetDefaults(40);
                                                }
                                                if (itemChance == 1)
                                                {
                                                    chest.item[slot].SetDefaults(42);
                                                }
                                                chest.item[slot].stack = stack11;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(2))
                                            {
                                                int stack12 = WorldGen.genRand.Next(3) + 3;
                                                chest.item[slot].SetDefaults(28);
                                                chest.item[slot].stack = stack12;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.Next(3) > 0)
                                            {
                                                int itemChance = WorldGen.genRand.Next(9);
                                                int stack13 = WorldGen.genRand.Next(1, 3);
                                                if (itemChance == 0)
                                                {
                                                    chest.item[slot].SetDefaults(289);
                                                }
                                                if (itemChance == 1)
                                                {
                                                    chest.item[slot].SetDefaults(298);
                                                }
                                                if (itemChance == 2)
                                                {
                                                    chest.item[slot].SetDefaults(299);
                                                }
                                                if (itemChance == 3)
                                                {
                                                    chest.item[slot].SetDefaults(290);
                                                }
                                                if (itemChance == 4)
                                                {
                                                    chest.item[slot].SetDefaults(303);
                                                }
                                                if (itemChance == 5)
                                                {
                                                    chest.item[slot].SetDefaults(291);
                                                }
                                                if (itemChance == 6)
                                                {
                                                    chest.item[slot].SetDefaults(304);
                                                }
                                                if (itemChance == 7)
                                                {
                                                    chest.item[slot].SetDefaults(2322);
                                                }
                                                if (itemChance == 8)
                                                {
                                                    chest.item[slot].SetDefaults(2329);
                                                }
                                                chest.item[slot].stack = stack13;
                                                slot++;
                                            }
                                            if (!WorldGen.genRand.NextBool(3))
                                            {
                                                int stack14 = WorldGen.genRand.Next(2, 5);
                                                chest.item[slot].SetDefaults(2350);
                                                chest.item[slot].stack = stack14;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(2))
                                            {
                                                int stack15 = WorldGen.genRand.Next(11) + 10;
                                                chest.item[slot].SetDefaults(8);
                                                chest.item[slot].stack = stack15;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(2))
                                            {
                                                chest.item[slot].SetDefaults(72);
                                                chest.item[slot].stack = WorldGen.genRand.Next(50, 90);
                                                slot++;
                                            }
                                        }
                                        else if (y < Main.maxTilesY - 250)
                                        {
                                            if (WorldGen.genRand.NextBool(5))
                                            {
                                                chest.item[slot].SetDefaults(43);
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(3))
                                            {
                                                chest.item[slot].SetDefaults(167);
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(4))
                                            {
                                                chest.item[slot].SetDefaults(51);
                                                chest.item[slot].stack = WorldGen.genRand.Next(26) + 25;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(2))
                                            {
                                                int itemChance = WorldGen.genRand.Next(2);
                                                int stack16 = WorldGen.genRand.Next(8) + 3;
                                                if (itemChance == 0)
                                                {
                                                    chest.item[slot].SetDefaults(WorldGen.goldBar);
                                                }
                                                if (itemChance == 1)
                                                {
                                                    chest.item[slot].SetDefaults(WorldGen.silverBar);
                                                }
                                                chest.item[slot].stack = stack16;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(2))
                                            {
                                                int itemChance = WorldGen.genRand.Next(2);
                                                int stack17 = WorldGen.genRand.Next(26) + 25;
                                                if (itemChance == 0)
                                                {
                                                    chest.item[slot].SetDefaults(41);
                                                }
                                                if (itemChance == 1)
                                                {
                                                    chest.item[slot].SetDefaults(279);
                                                }
                                                chest.item[slot].stack = stack17;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(2))
                                            {
                                                int stack18 = WorldGen.genRand.Next(3) + 3;
                                                chest.item[slot].SetDefaults(188);
                                                chest.item[slot].stack = stack18;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.Next(3) > 0)
                                            {
                                                int itemChance = WorldGen.genRand.Next(6);
                                                int stack19 = WorldGen.genRand.Next(1, 3);
                                                if (itemChance == 0)
                                                {
                                                    chest.item[slot].SetDefaults(296);
                                                }
                                                if (itemChance == 1)
                                                {
                                                    chest.item[slot].SetDefaults(295);
                                                }
                                                if (itemChance == 2)
                                                {
                                                    chest.item[slot].SetDefaults(299);
                                                }
                                                if (itemChance == 3)
                                                {
                                                    chest.item[slot].SetDefaults(302);
                                                }
                                                if (itemChance == 4)
                                                {
                                                    chest.item[slot].SetDefaults(303);
                                                }
                                                if (itemChance == 5)
                                                {
                                                    chest.item[slot].SetDefaults(305);
                                                }
                                                chest.item[slot].stack = stack19;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.Next(3) > 1)
                                            {
                                                int itemChance = WorldGen.genRand.Next(6);
                                                int stack20 = WorldGen.genRand.Next(1, 3);
                                                if (itemChance == 0)
                                                {
                                                    chest.item[slot].SetDefaults(301);
                                                }
                                                if (itemChance == 1)
                                                {
                                                    chest.item[slot].SetDefaults(297);
                                                }
                                                if (itemChance == 2)
                                                {
                                                    chest.item[slot].SetDefaults(304);
                                                }
                                                if (itemChance == 3)
                                                {
                                                    chest.item[slot].SetDefaults(2329);
                                                }
                                                if (itemChance == 4)
                                                {
                                                    chest.item[slot].SetDefaults(2351);
                                                }
                                                if (itemChance == 5)
                                                {
                                                    chest.item[slot].SetDefaults(2326);
                                                }
                                                chest.item[slot].stack = stack20;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(2))
                                            {
                                                int stack21 = WorldGen.genRand.Next(2, 5);
                                                chest.item[slot].SetDefaults(2350);
                                                chest.item[slot].stack = stack21;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(2))
                                            {
                                                int itemChance = WorldGen.genRand.Next(2);
                                                int stack22 = WorldGen.genRand.Next(15) + 15;
                                                if (itemChance == 0)
                                                {
                                                    chest.item[slot].SetDefaults(8);
                                                }
                                                if (itemChance == 1)
                                                {
                                                    chest.item[slot].SetDefaults(282);
                                                }
                                                chest.item[slot].stack = stack22;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(2))
                                            {
                                                chest.item[slot].SetDefaults(73);
                                                chest.item[slot].stack = WorldGen.genRand.Next(1, 3);
                                                slot++;
                                            }
                                        }
                                        else //Mushroom Chest is near hell biome
                                        {
                                            if (WorldGen.genRand.NextBool(3))
                                            {
                                                chest.item[slot].SetDefaults(167);
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(2))
                                            {
                                                int itemChance = WorldGen.genRand.Next(2);
                                                int stack23 = WorldGen.genRand.Next(15) + 15;
                                                if (itemChance == 0)
                                                {
                                                    chest.item[slot].SetDefaults(117);
                                                }
                                                if (itemChance == 1)
                                                {
                                                    chest.item[slot].SetDefaults(WorldGen.goldBar);
                                                }
                                                chest.item[slot].stack = stack23;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(2))
                                            {
                                                int itemChance = WorldGen.genRand.Next(2);
                                                int stack24 = WorldGen.genRand.Next(25) + 50;
                                                if (itemChance == 0)
                                                {
                                                    chest.item[slot].SetDefaults(265);
                                                }
                                                if (itemChance == 1)
                                                {
                                                    if (WorldGen.SavedOreTiers.Silver == 168)
                                                    {
                                                        chest.item[slot].SetDefaults(4915);
                                                    }
                                                    else
                                                    {
                                                        chest.item[slot].SetDefaults(278);
                                                    }
                                                }
                                                chest.item[slot].stack = stack24;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(2))
                                            {
                                                int stack25 = WorldGen.genRand.Next(6) + 15;
                                                chest.item[slot].SetDefaults(227);
                                                chest.item[slot].stack = stack25;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.Next(4) > 0)
                                            {
                                                int itemChance = WorldGen.genRand.Next(8);
                                                int stack26 = WorldGen.genRand.Next(1, 3);
                                                if (itemChance == 0)
                                                {
                                                    chest.item[slot].SetDefaults(296);
                                                }
                                                if (itemChance == 1)
                                                {
                                                    chest.item[slot].SetDefaults(295);
                                                }
                                                if (itemChance == 2)
                                                {
                                                    chest.item[slot].SetDefaults(293);
                                                }
                                                if (itemChance == 3)
                                                {
                                                    chest.item[slot].SetDefaults(288);
                                                }
                                                if (itemChance == 4)
                                                {
                                                    chest.item[slot].SetDefaults(294);
                                                }
                                                if (itemChance == 5)
                                                {
                                                    chest.item[slot].SetDefaults(297);
                                                }
                                                if (itemChance == 6)
                                                {
                                                    chest.item[slot].SetDefaults(304);
                                                }
                                                if (itemChance == 7)
                                                {
                                                    chest.item[slot].SetDefaults(2323);
                                                }
                                                chest.item[slot].stack = stack26;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.Next(3) > 0)
                                            {
                                                int itemChance = WorldGen.genRand.Next(8);
                                                int stack27 = WorldGen.genRand.Next(1, 3);
                                                if (itemChance == 0)
                                                {
                                                    chest.item[slot].SetDefaults(305);
                                                }
                                                if (itemChance == 1)
                                                {
                                                    chest.item[slot].SetDefaults(301);
                                                }
                                                if (itemChance == 2)
                                                {
                                                    chest.item[slot].SetDefaults(302);
                                                }
                                                if (itemChance == 3)
                                                {
                                                    chest.item[slot].SetDefaults(288);
                                                }
                                                if (itemChance == 4)
                                                {
                                                    chest.item[slot].SetDefaults(300);
                                                }
                                                if (itemChance == 5)
                                                {
                                                    chest.item[slot].SetDefaults(2351);
                                                }
                                                if (itemChance == 6)
                                                {
                                                    chest.item[slot].SetDefaults(2348);
                                                }
                                                if (itemChance == 7)
                                                {
                                                    chest.item[slot].SetDefaults(2345);
                                                }
                                                chest.item[slot].stack = stack27;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(3))
                                            {
                                                int stack28 = WorldGen.genRand.Next(1, 3);
                                                if (WorldGen.genRand.NextBool(2))
                                                {
                                                    chest.item[slot].SetDefaults(2350);
                                                }
                                                else
                                                {
                                                    chest.item[slot].SetDefaults(4870);
                                                }
                                                chest.item[slot].stack = stack28;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(2))
                                            {
                                                int itemChance = WorldGen.genRand.Next(2);
                                                int stack29 = WorldGen.genRand.Next(15) + 15;
                                                if (itemChance == 0)
                                                {
                                                    chest.item[slot].SetDefaults(8);
                                                }
                                                if (itemChance == 1)
                                                {
                                                    chest.item[slot].SetDefaults(282);
                                                }
                                                chest.item[slot].stack = stack29;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(2))
                                            {
                                                chest.item[slot].SetDefaults(73);
                                                chest.item[slot].stack = WorldGen.genRand.Next(2, 5);
                                                slot++;
                                            }
                                        }
                                        #endregion
                                        goto placedMushroomChest;
                                    }
                                }
                            }
                        }
                    }
                    placedMushroomChest: { };
                }

                List<int> mushroomBiomes = new();
                for (int i = 0; i < WorldGen.mushroomBiomesPosition.Length; i++)
                {
                    if (WorldGen.mushroomBiomesPosition[i].X != 0 && WorldGen.mushroomBiomesPosition[i].Y != 0)
                    {
                        mushroomBiomes.Add(i);
                    }
                }

                for (int i = 0; i < mushroomBiomes.Count; i++)
                {
                    if (WorldGen.genRand.NextBool(4))
                    {
                        tryToPlaceMushroomChest(i);
                    }
                }

                int kingStatueDenominator = 5;
                int queenStatueDenominator = 5;

                #region Scan For Missing Mushroom Items and Add Terragrim
                for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
                {
                    Chest chest = Main.chest[chestIndex];

                    if (chest == null)
                    {
                        continue;
                    }

                    int tileSubID;
                    bool chestType1 = Main.tile[chest.x, chest.y].TileType == TileID.Containers;
                    short tileFrameX = Main.tile[chest.x, chest.y].TileFrameX;

                    if (GetInstance<IOtherConfig>().TerragrimChestChance > 0)
                    {
                        tileSubID = 0; //Regular Chest
                        if (!(chestType1 && tileFrameX == tileSubID * 36))
                        {
                            terragrimChests.Add(chestIndex);
                        }
                    }

                    //TO-DO Remove when 1.4.4+ comes out
                    tileSubID = 13; //Skyware Chest
                    if (chestType1 && tileFrameX == tileSubID * 36)
                    {
                        bool adjustedRareItem = false;
                        int[] emptySlot = new int[] { -1, -1 };
                        int eSlot = 0;
                        for (int slot = 0; slot < 40; slot++)
                        {
                            int type = chest.item[slot].type;
                            if (type == ItemID.None && emptySlot[1] == -1)
                            {
                                emptySlot[eSlot] = slot;
                                eSlot++;
                            }
                            else if (type == ItemID.CreativeWings || type == ItemID.Starfury || type == ItemID.ShinyRedBalloon)
                            {
                                if (missingSkywareItems.Count > 0)
                                {
                                    chest.item[slot].SetDefaults(missingSkywareItems[0]);
                                    missingSkywareItems.RemoveAt(0);
                                }
                                else
                                {
									int chance = GetInstance<IOtherConfig>().FutureFledglingChestChance ? 4 : 5;
                                    switch (WorldGen.genRand.Next(chance))
                                    {
                                        case 0:
                                            chest.item[slot].SetDefaults(ItemID.Starfury);
                                            break;
                                        case 1:
                                            chest.item[slot].SetDefaults(ItemID.LuckyHorseshoe);
                                            break;
                                        case 2:
                                            chest.item[slot].SetDefaults(ItemID.ShinyRedBalloon);
                                            break;
                                        case 3:
                                            chest.item[slot].SetDefaults(ItemID.CelestialMagnet);
                                            break;
                                        case 4:
                                            chest.item[slot].SetDefaults(ItemID.CreativeWings);
                                            break;
                                    }
                                }
                                adjustedRareItem = true;
                            }
                            if (adjustedRareItem && emptySlot[1] > -1)
                            {
                                break;
                            }
                        }
                        eSlot = 0;
                        if (adjustedRareItem && emptySlot[eSlot] > -1 && GetInstance<IOtherConfig>().FutureFledglingChestChance)
                        {
                            if (WorldGen.genRand.NextBool(40))
                            {
                                chest.item[emptySlot[eSlot]].SetDefaults(ItemID.CreativeWings);
                                chest.item[emptySlot[eSlot]].Prefix(-1);
                                eSlot++;
                            }
                        }
                        if (emptySlot[eSlot] > -1)
                        {
                            chest.item[emptySlot[eSlot]].SetDefaults(ItemID.Cloud);
                            chest.item[emptySlot[eSlot]].stack = WorldGen.genRand.Next(50, 101);
                        }
                    }
                    else
                    {
                        nonSkywareChests.Add(chestIndex);
                    }

                    int waterChestItem = 0;
                    if (chestType1)
                    {
                        tileSubID = 32; //Mushroom Chest
                        int waterChestSubID = 17; //Remove when 1.4.4+ comes out
                        int woodChestSubID = 0; //Remove when 1.4.4+ comes out
                        int livingWoodChestSubID = 12; //Remove when 1.4.4+ comes out
                        int lockedShadowChestSubID = 4; //Remove when 1.4.4+ comes out
                        int goldChestSubID = 1; //Remove when 1.4.4+ comes out
                        int goldLockedChestSubID = 2;
                        if (tileFrameX == tileSubID * 36)
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
                        else if (tileFrameX == waterChestSubID * 36) //TO-DO Remove when 1.4.4+ comes out
                        {
                            int emptySlot = -1;
                            bool needToFixRareItem = true;
                            for (int slot = 0; slot < 40; slot++)
                            {
                                int type = chest.item[slot].type;
                                if (emptySlot == -1 && type == ItemID.None)
                                {
                                    emptySlot = slot;
                                }
                                else if (type == ItemID.SharkBait)
                                {
                                    if (WorldGen.genRand.NextBool(10))
                                    {
                                        chest.item[slot].SetDefaults(ItemID.WaterWalkingBoots);
                                        chest.item[slot].Prefix(-1);
                                    }
                                    else
                                    {
                                        waterChestItem++;
                                        switch (waterChestItem)
                                        {
                                            case 1:
                                                chest.item[slot].SetDefaults(ItemID.BreathingReed);
                                                break;
                                            case 2:
                                                chest.item[slot].SetDefaults(ItemID.Flipper);
                                                chest.item[slot].Prefix(-1);
                                                break;
                                            case 3:
                                                chest.item[slot].SetDefaults(ItemID.Trident);
                                                chest.item[slot].Prefix(-1);
                                                break;
                                            default:
                                                chest.item[slot].SetDefaults(ItemID.FloatingTube);
                                                chest.item[slot].Prefix(-1);
                                                waterChestItem = 0;
                                                break;
                                        }
                                    }
                                    needToFixRareItem = false;
                                }
                                else if (type == ItemID.WaterWalkingBoots || type == ItemID.BreathingReed || type == ItemID.Flipper || type == ItemID.Trident || type == ItemID.FloatingTube)
                                {
                                    needToFixRareItem = false;
                                }

                                if (emptySlot > -1 && !needToFixRareItem)
                                {
                                    break;
                                }
                            }
                            if (emptySlot > -1 && WorldGen.genRand.NextBool(2))
                            {
                                chest.item[emptySlot].SetDefaults(ItemID.SharkBait);
                            }
                        }
                        else if (tileFrameX == woodChestSubID * 36) //TO-DO Remove when 1.4.4+ comes out
                        {
                            bool fixedRareLoot = false;
                            int[] emptySlot = new int[] { -1, -1 };
                            int eSlot = 0;
                            for (int slot = 0; slot < 40; slot++)
                            {
                                int type = chest.item[slot].type;
                                if (type == ItemID.None && emptySlot[1] == -1)
                                {
                                    emptySlot[eSlot] = slot;
                                    eSlot++;
                                }
                                else if (type == ItemID.ThrowingKnife || type == ItemID.Glowstick)
                                {
                                    switch (WorldGen.genRand.Next(9))
                                    {
                                        case 0:
                                            chest.item[slot].SetDefaults(ItemID.Spear);
                                            break;
                                        case 1:
                                            chest.item[slot].SetDefaults(ItemID.Blowpipe);
                                            break;
                                        case 2:
                                            chest.item[slot].SetDefaults(ItemID.WoodenBoomerang);
                                            break;
                                        case 3:
                                            chest.item[slot].SetDefaults(ItemID.Aglet);
                                            break;
                                        case 4:
                                            chest.item[slot].SetDefaults(ItemID.ClimbingClaws);
                                            break;
                                        case 5:
                                            chest.item[slot].SetDefaults(ItemID.Umbrella);
                                            break;
                                        case 6:
                                            chest.item[slot].SetDefaults(3068/*GuideToPlantFiberCordage*/);
                                            break;
                                        case 7:
                                            chest.item[slot].SetDefaults(ItemID.WandofSparking);
                                            break;
                                        case 8:
                                            chest.item[slot].SetDefaults(ItemID.Radar);
                                            break;
                                        case 9:
                                            chest.item[slot].SetDefaults(ItemID.PortableStool);
                                            break;
                                    }
                                    fixedRareLoot = true;
                                }
                                if (fixedRareLoot && emptySlot[1] > -1)
                                {
                                    break;
                                }
                            }
                            eSlot = 0;
                            if (WorldGen.genRand.NextBool(6))
                            {
                                chest.item[emptySlot[eSlot]].SetDefaults(ItemID.ThrowingKnife);
                                chest.item[emptySlot[eSlot]].stack = WorldGen.genRand.Next(150, 301);
                                eSlot++;
                            }
                            if (WorldGen.genRand.NextBool(6))
                            {
                                chest.item[emptySlot[eSlot]].SetDefaults(ItemID.ThrowingKnife);
                                chest.item[emptySlot[eSlot]].stack = WorldGen.genRand.Next(150, 301);
                            }
                        }
                        else if (tileFrameX == livingWoodChestSubID * 36) //TO-DO Remove when 1.4.4+ comes out
                        {
                            int emptySlot = -1;
                            for (int slot = 0; slot < 40; slot++)
                            {
                                int type = chest.item[slot].type;
                                if (emptySlot == -1 && type == ItemID.None)
                                {
                                    emptySlot = slot;
                                }
                                else if (type == ItemID.SunflowerMinecart || type == ItemID.LadybugMinecart)
                                {
                                    emptySlot = -1;
                                    break;
                                }
                            }
                            if (emptySlot > -1 && WorldGen.genRand.NextBool(15))
                            {
                                if (WorldGen.genRand.NextBool(2))
                                {
                                    chest.item[emptySlot].SetDefaults(ItemID.SunflowerMinecart);
                                }
                                else
                                {
                                    chest.item[emptySlot].SetDefaults(ItemID.LadybugMinecart);
                                }
                            }
                        }
                        else if (tileFrameX == lockedShadowChestSubID * 36) //TO-DO Remove when 1.4.4+ comes out
                        {
                            bool fixedRareItem = false;
                            int emptySlot = -1;
                            for (int slot = 0; slot < 40; slot++)
                            {
                                if (emptySlot == -1 && chest.item[slot].type == ItemID.None)
                                {
                                    emptySlot = slot;
                                }
                                else if (chest.item[slot].type == ItemID.TreasureMagnet)
                                {
                                    switch (WorldGen.genRand.Next(5))
                                    {
                                        case 0:
                                            chest.item[slot].SetDefaults(ItemID.Sunfury);
                                            chest.item[slot].Prefix(-1);
                                            break;
                                        case 1:
                                            chest.item[slot].SetDefaults(ItemID.FlowerofFire);
                                            chest.item[slot].Prefix(-1);
                                            break;
                                        case 2:
                                            chest.item[slot].SetDefaults(ItemID.Flamelash);
                                            chest.item[slot].Prefix(-1);
                                            break;
                                        case 3:
                                            chest.item[slot].SetDefaults(ItemID.DarkLance);
                                            chest.item[slot].Prefix(-1);
                                            break;
                                        case 4:
                                            chest.item[slot].SetDefaults(ItemID.HellwingBow);
                                            chest.item[slot].Prefix(-1);
                                            break;
                                    }
                                    fixedRareItem = true;
                                }
                                if (emptySlot > -1 && fixedRareItem)
                                {
                                    break;
                                }
                            }
                            if (emptySlot > -1 && WorldGen.genRand.NextBool(5))
                            {
                                chest.item[emptySlot].SetDefaults(ItemID.TreasureMagnet);
                                chest.item[emptySlot].Prefix(-1);
                            }
                        }
                        else if (tileFrameX == goldChestSubID * 36)
                        {
                            //Remove when 1.4.4+ comes out
                            #region Pyramid Items
                            bool changedItem = false;
                            int pharoahsRobeSlot = -1;
                            for (int slot = 0; slot < 40; slot++)
                            {
                                if (chest.item[slot].type == ItemID.PharaohsMask)
                                {
                                    switch (WorldGen.genRand.Next(3))
                                    {
                                        case 1:
                                            chest.item[slot].SetDefaults(ItemID.SandstorminaBottle);
                                            chest.item[slot].Prefix(-1);
                                            changedItem = true;
                                            break;
                                        case 2:
                                            chest.item[slot].SetDefaults(ItemID.FlyingCarpet);
                                            chest.item[slot].Prefix(-1);
                                            changedItem = true;
                                            break;
                                    }
                                }
                                else if (chest.item[slot].type == ItemID.PharaohsRobe)
                                {
                                    pharoahsRobeSlot = slot;
                                }

                                if (changedItem && pharoahsRobeSlot > -1)
                                {
                                    break;
                                }
                            }
                            if (changedItem && pharoahsRobeSlot > -1)
                            {
                                for (int slot = pharoahsRobeSlot; slot < 39; slot++)
                                {
                                    chest.item[slot] = chest.item[slot + 1];
                                }
                                chest.item[39].SetDefaults(ItemID.None);
                            }
                            #endregion
                            if (chest.y > WorldGen.lavaLine || Math.Abs(chest.x - Main.spawnTileX) > (Main.maxTilesX / 4))
                            {
                                if (WorldGen.genRand.NextBool(kingStatueDenominator))
                                {
                                    for (int slot = 0; slot < 40; slot++)
                                    {
                                        if (chest.item[slot].type == ItemID.None)
                                        {
                                            chest.item[slot].SetDefaults(ItemID.KingStatue);
                                            kingStatueDenominator += 5;
                                            break;
                                        }
                                    }
                                }
                                if (WorldGen.genRand.NextBool(queenStatueDenominator))
                                {
                                    for (int slot = 0; slot < 40; slot++)
                                    {
                                        if (chest.item[slot].type == ItemID.None)
                                        {
                                            chest.item[slot].SetDefaults(ItemID.QueenStatue);
                                            queenStatueDenominator += 5;
                                            break;
                                        }
                                    }
                                }
                                kingStatueDenominator = Math.Max(1, kingStatueDenominator - 1);
                                queenStatueDenominator = Math.Max(1, queenStatueDenominator - 1);
                            }
                        }
                        else if (tileFrameX == goldLockedChestSubID * 36)
                        {
                            lockedGoldChest.Add(chestIndex);
                        }
                    }
                }
                #endregion

                #region Final Chest Tweaks
                //TO-DO Remove when 1.4.4+ comes out
                foreach (int chestIndex in nonSkywareChests)
                {
                    Chest chest = Main.chest[chestIndex];
                    for (int slot = 0; slot < 40; slot++)
                    {
                        int type = chest.item[slot].type;
                        if (type == ItemID.LuckyHorseshoe)
                        {
                            //Regenerate Rare Loot
                            if (chest.y < Main.rockLayer)
                            {
                                switch (WorldGen.genRand.Next(6))
                                {
                                    case 0:
                                        chest.item[slot].SetDefaults(49);
                                        chest.item[slot].Prefix(-1);
                                        break;
                                    case 1:
                                        chest.item[slot].SetDefaults(50);
                                        chest.item[slot].Prefix(-1);
                                        break;
                                    case 2:
                                        chest.item[slot].SetDefaults(53);
                                        chest.item[slot].Prefix(-1);
                                        break;
                                    case 3:
                                        chest.item[slot].SetDefaults(54);
                                        chest.item[slot].Prefix(-1);
                                        break;
                                    case 4:
                                        chest.item[slot].SetDefaults(5011);
                                        chest.item[slot].Prefix(-1);
                                        break;
                                    default:
                                        chest.item[slot].SetDefaults(975);
                                        chest.item[slot].Prefix(-1);
                                        break;
                                }
                            }
                            else if (chest.y < Main.maxTilesY - 250)
                            {
                                int itemChance = WorldGen.genRand.Next(7);
                                bool flag14 = chest.y > WorldGen.lavaLine;
                                int maxValue = 20;
                                if (WorldGen.tenthAnniversaryWorldGen)
                                {
                                    maxValue = 15;
                                }
                                if (WorldGen.genRand.NextBool(maxValue) && flag14)
                                {
                                    chest.item[slot].SetDefaults(906);
                                    chest.item[slot].Prefix(-1);
                                }
                                else if (WorldGen.genRand.NextBool(15))
                                {
                                    chest.item[slot].SetDefaults(997);
                                    chest.item[slot].Prefix(-1);
                                }
                                else
                                {
                                    if (itemChance == 0)
                                    {
                                        chest.item[slot].SetDefaults(49);
                                        chest.item[slot].Prefix(-1);
                                    }
                                    if (itemChance == 1)
                                    {
                                        chest.item[slot].SetDefaults(50);
                                        chest.item[slot].Prefix(-1);
                                    }
                                    if (itemChance == 2)
                                    {
                                        chest.item[slot].SetDefaults(53);
                                        chest.item[slot].Prefix(-1);
                                    }
                                    if (itemChance == 3)
                                    {
                                        chest.item[slot].SetDefaults(54);
                                        chest.item[slot].Prefix(-1);
                                    }
                                    if (itemChance == 4)
                                    {
                                        chest.item[slot].SetDefaults(5011);
                                        chest.item[slot].Prefix(-1);
                                    }
                                    if (itemChance == 5)
                                    {
                                        chest.item[slot].SetDefaults(975);
                                        chest.item[slot].Prefix(-1);
                                    }
                                    if (itemChance == 6)
                                    {
                                        chest.item[slot].SetDefaults(930);
                                        chest.item[slot].Prefix(-1);
                                        slot++;
                                        chest.item[slot].SetDefaults(931);
                                        chest.item[slot].stack = WorldGen.genRand.Next(26) + 25;
                                    }
                                }
                            }
                            else
                            {
                                int itemChance = WorldGen.genRand.Next(4);
                                if (itemChance == 0)
                                {
                                    chest.item[slot].SetDefaults(49);
                                    chest.item[slot].Prefix(-1);
                                }
                                if (itemChance == 1)
                                {
                                    chest.item[slot].SetDefaults(50);
                                    chest.item[slot].Prefix(-1);
                                }
                                if (itemChance == 2)
                                {
                                    chest.item[slot].SetDefaults(53);
                                    chest.item[slot].Prefix(-1);
                                }
                                if (itemChance == 3)
                                {
                                    chest.item[slot].SetDefaults(54);
                                    chest.item[slot].Prefix(-1);
                                }
                            }
                        }
                    }
                }

                int mushroomChestAttempts = 0;
                while (missingMushroomItems.Count > 0)
                {
                    tryToPlaceMushroomChest(WorldGen.genRand.Next(0, mushroomBiomes.Count), missingMushroomItems[0]);
                    mushroomChestAttempts++;
                    if (mushroomChestAttempts >= 5)
                    {
                        break;
                    }
                }

                while (dungeonFurniture.Count > 0)
                {
                    foreach (int chestIndex in lockedGoldChest)
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
                #endregion
            }
        }
    }
}
