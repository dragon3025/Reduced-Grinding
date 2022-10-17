using Microsoft.Xna.Framework;
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
                tasks.Insert(FinalCleanupIndex + 1, new ReducedGrindingGen("Increasing Mushroom Chests and rolling for Terragrims", 10f));
            }
        }

        public class ReducedGrindingGen : GenPass
        {
            public ReducedGrindingGen(string name, float loadWeight) : base(name, loadWeight) { }

            protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
            {
                //TO-DO 1.4.4+ will contain secret seeds that flip progression upsidedown and the vanilla worldgen adjust to this. This mod will also have to adjsut to it.

                progress.Message = "Adding Non-Existing Rare Chest Loot";

                List<int> missingMushroomItems = new() { ItemID.ShroomMinecart, ItemID.MushroomHat };

                void tryToPlaceMushroomChest(int mushroomBiome, int item = -1)
                {
                    Point biomePosition = WorldGen.mushroomBiomesPosition[mushroomBiome].ToPoint();

                    for (int i = 0; i < 5; i++)
                    {
                        int x = WorldGen.genRand.Next(biomePosition.X - 100, biomePosition.X + 100);
                        int y = WorldGen.genRand.Next(biomePosition.Y - 100, biomePosition.Y + 100);
                        int yDirection = 1;
                        if (y > biomePosition.Y)
                            yDirection = -1;
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
                                        }
                                        else
                                            chest.item[0].SetDefaults(ItemID.ShroomMinecart);
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
                                                int num23 = WorldGen.genRand.Next(2);
                                                int stack10 = WorldGen.genRand.Next(10) + 5;
                                                if (num23 == 0)
                                                {
                                                    chest.item[slot].SetDefaults(WorldGen.ironBar);
                                                }
                                                if (num23 == 1)
                                                {
                                                    chest.item[slot].SetDefaults(WorldGen.silverBar);
                                                }
                                                chest.item[slot].stack = stack10;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(2))
                                            {
                                                int num24 = WorldGen.genRand.Next(2);
                                                int stack11 = WorldGen.genRand.Next(25) + 25;
                                                if (num24 == 0)
                                                {
                                                    chest.item[slot].SetDefaults(40);
                                                }
                                                if (num24 == 1)
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
                                                int num25 = WorldGen.genRand.Next(9);
                                                int stack13 = WorldGen.genRand.Next(1, 3);
                                                if (num25 == 0)
                                                {
                                                    chest.item[slot].SetDefaults(289);
                                                }
                                                if (num25 == 1)
                                                {
                                                    chest.item[slot].SetDefaults(298);
                                                }
                                                if (num25 == 2)
                                                {
                                                    chest.item[slot].SetDefaults(299);
                                                }
                                                if (num25 == 3)
                                                {
                                                    chest.item[slot].SetDefaults(290);
                                                }
                                                if (num25 == 4)
                                                {
                                                    chest.item[slot].SetDefaults(303);
                                                }
                                                if (num25 == 5)
                                                {
                                                    chest.item[slot].SetDefaults(291);
                                                }
                                                if (num25 == 6)
                                                {
                                                    chest.item[slot].SetDefaults(304);
                                                }
                                                if (num25 == 7)
                                                {
                                                    chest.item[slot].SetDefaults(2322);
                                                }
                                                if (num25 == 8)
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
                                                int num32 = WorldGen.genRand.Next(2);
                                                int stack16 = WorldGen.genRand.Next(8) + 3;
                                                if (num32 == 0)
                                                {
                                                    chest.item[slot].SetDefaults(WorldGen.goldBar);
                                                }
                                                if (num32 == 1)
                                                {
                                                    chest.item[slot].SetDefaults(WorldGen.silverBar);
                                                }
                                                chest.item[slot].stack = stack16;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(2))
                                            {
                                                int num33 = WorldGen.genRand.Next(2);
                                                int stack17 = WorldGen.genRand.Next(26) + 25;
                                                if (num33 == 0)
                                                {
                                                    chest.item[slot].SetDefaults(41);
                                                }
                                                if (num33 == 1)
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
                                                int num34 = WorldGen.genRand.Next(6);
                                                int stack19 = WorldGen.genRand.Next(1, 3);
                                                if (num34 == 0)
                                                {
                                                    chest.item[slot].SetDefaults(296);
                                                }
                                                if (num34 == 1)
                                                {
                                                    chest.item[slot].SetDefaults(295);
                                                }
                                                if (num34 == 2)
                                                {
                                                    chest.item[slot].SetDefaults(299);
                                                }
                                                if (num34 == 3)
                                                {
                                                    chest.item[slot].SetDefaults(302);
                                                }
                                                if (num34 == 4)
                                                {
                                                    chest.item[slot].SetDefaults(303);
                                                }
                                                if (num34 == 5)
                                                {
                                                    chest.item[slot].SetDefaults(305);
                                                }
                                                chest.item[slot].stack = stack19;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.Next(3) > 1)
                                            {
                                                int num35 = WorldGen.genRand.Next(6);
                                                int stack20 = WorldGen.genRand.Next(1, 3);
                                                if (num35 == 0)
                                                {
                                                    chest.item[slot].SetDefaults(301);
                                                }
                                                if (num35 == 1)
                                                {
                                                    chest.item[slot].SetDefaults(297);
                                                }
                                                if (num35 == 2)
                                                {
                                                    chest.item[slot].SetDefaults(304);
                                                }
                                                if (num35 == 3)
                                                {
                                                    chest.item[slot].SetDefaults(2329);
                                                }
                                                if (num35 == 4)
                                                {
                                                    chest.item[slot].SetDefaults(2351);
                                                }
                                                if (num35 == 5)
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
                                                int num36 = WorldGen.genRand.Next(2);
                                                int stack22 = WorldGen.genRand.Next(15) + 15;
                                                if (num36 == 0)
                                                {
                                                    chest.item[slot].SetDefaults(8);
                                                }
                                                if (num36 == 1)
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
                                                int num38 = WorldGen.genRand.Next(2);
                                                int stack23 = WorldGen.genRand.Next(15) + 15;
                                                if (num38 == 0)
                                                {
                                                    chest.item[slot].SetDefaults(117);
                                                }
                                                if (num38 == 1)
                                                {
                                                    chest.item[slot].SetDefaults(WorldGen.goldBar);
                                                }
                                                chest.item[slot].stack = stack23;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.NextBool(2))
                                            {
                                                int num39 = WorldGen.genRand.Next(2);
                                                int stack24 = WorldGen.genRand.Next(25) + 50;
                                                if (num39 == 0)
                                                {
                                                    chest.item[slot].SetDefaults(265);
                                                }
                                                if (num39 == 1)
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
                                                int num40 = WorldGen.genRand.Next(8);
                                                int stack26 = WorldGen.genRand.Next(1, 3);
                                                if (num40 == 0)
                                                {
                                                    chest.item[slot].SetDefaults(296);
                                                }
                                                if (num40 == 1)
                                                {
                                                    chest.item[slot].SetDefaults(295);
                                                }
                                                if (num40 == 2)
                                                {
                                                    chest.item[slot].SetDefaults(293);
                                                }
                                                if (num40 == 3)
                                                {
                                                    chest.item[slot].SetDefaults(288);
                                                }
                                                if (num40 == 4)
                                                {
                                                    chest.item[slot].SetDefaults(294);
                                                }
                                                if (num40 == 5)
                                                {
                                                    chest.item[slot].SetDefaults(297);
                                                }
                                                if (num40 == 6)
                                                {
                                                    chest.item[slot].SetDefaults(304);
                                                }
                                                if (num40 == 7)
                                                {
                                                    chest.item[slot].SetDefaults(2323);
                                                }
                                                chest.item[slot].stack = stack26;
                                                slot++;
                                            }
                                            if (WorldGen.genRand.Next(3) > 0)
                                            {
                                                int num41 = WorldGen.genRand.Next(8);
                                                int stack27 = WorldGen.genRand.Next(1, 3);
                                                if (num41 == 0)
                                                {
                                                    chest.item[slot].SetDefaults(305);
                                                }
                                                if (num41 == 1)
                                                {
                                                    chest.item[slot].SetDefaults(301);
                                                }
                                                if (num41 == 2)
                                                {
                                                    chest.item[slot].SetDefaults(302);
                                                }
                                                if (num41 == 3)
                                                {
                                                    chest.item[slot].SetDefaults(288);
                                                }
                                                if (num41 == 4)
                                                {
                                                    chest.item[slot].SetDefaults(300);
                                                }
                                                if (num41 == 5)
                                                {
                                                    chest.item[slot].SetDefaults(2351);
                                                }
                                                if (num41 == 6)
                                                {
                                                    chest.item[slot].SetDefaults(2348);
                                                }
                                                if (num41 == 7)
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
                                                int num42 = WorldGen.genRand.Next(2);
                                                int stack29 = WorldGen.genRand.Next(15) + 15;
                                                if (num42 == 0)
                                                {
                                                    chest.item[slot].SetDefaults(8);
                                                }
                                                if (num42 == 1)
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
                        mushroomBiomes.Add(i);
                }

                for (int i = 0; i < mushroomBiomes.Count; i++)
                {
                    if (WorldGen.genRand.NextBool(4))
                    {
                        tryToPlaceMushroomChest(i);
                    }
                }

                #region Scan For Missing Mushroom Items and Add Terragrim
                for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
                {
                    Chest chest = Main.chest[chestIndex];

                    if (chest == null)
                        continue;

                    int tileSubID;
                    bool chestType1 = Main.tile[chest.x, chest.y].TileType == TileID.Containers;
                    short tileFrameX = Main.tile[chest.x, chest.y].TileFrameX;

                    if (WorldGen.genRand.NextBool(GetInstance<IOtherConfig>().TerragrimChestChance))
                    {
                        tileSubID = 0; //Regular Chest
                        if (!(chestType1 && tileFrameX == tileSubID * 36))
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

                    tileSubID = 32; //Mushroom Chest
                    if (chestType1 && tileFrameX == tileSubID * 36)
                    {
                        if (missingMushroomItems.Count > 0)
                        {
                            for (int slot = 0; slot < 40; slot++)
                            {
                                List<int> missingMushroomItemsOld = new();
                                missingMushroomItemsOld.AddRange(missingMushroomItems);

                                foreach (int itemType in missingMushroomItemsOld)
                                    if (chest.item[slot].type == itemType)
                                    {
                                        missingMushroomItems.Remove(itemType);
                                    }
                            }
                        }
                    }
                }
                #endregion

                #region Add Missing Items

                int mushroomChestAttempts = 0;
                while (missingMushroomItems.Count > 0)
                {
                    tryToPlaceMushroomChest(WorldGen.genRand.Next(0, mushroomBiomes.Count), missingMushroomItems[0]);
                    mushroomChestAttempts++;
                    if (mushroomChestAttempts >= 5)
                        break;
                }
                #endregion
            }
        }
    }
}
