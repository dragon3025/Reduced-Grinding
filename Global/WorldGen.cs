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
                tasks.Insert(FinalCleanupIndex + 1, new ReducedGrindingGen("Adding Non-Existing Rare Chest Loot", 10f));
            }
        }

        public class ReducedGrindingGen : GenPass
        {
            public ReducedGrindingGen(string name, float loadWeight) : base(name, loadWeight) { }

            protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
            {
                //NOTE: Random generation fucntions like Main.Rand will automatically use the world's seed when generating numbers which means every action and every random number will the same for 2 worlds with the same seed.

                progress.Message = "Adding Non-Existing Rare Chest Loot";

                List<int> missingMushroomItems = new() { ItemID.ShroomMinecart, ItemID.MushroomHat };
                bool beeMinecartMissing = true;

                void tryToPlaceMushroomChest(int mushroomBiome, int item = -1)
                {
                    Point biomePosition = WorldGen.mushroomBiomesPosition[mushroomBiome].ToPoint();

                    for (int i = 0; i < 5; i++)
                    {
                        int x = Main.rand.Next(biomePosition.X - 100, biomePosition.X + 100);
                        int y = Main.rand.Next(biomePosition.Y - 100, biomePosition.Y + 100);
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

                                        if (item == ItemID.MushroomHat || (item != ItemID.ShroomMinecart && Main.rand.NextBool(2)))
                                        {
                                            int slot = 0;
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
                    if (Main.rand.NextBool(4))
                    {
                        tryToPlaceMushroomChest(i);
                    }
                }

                if (GetInstance<IOtherConfig>().GenerateMissingRareChestItems == false)
                    return;

                List<int> ivyChests = new();
                List<int> centerGoldChests = new();
                List<int> goldChests = new();

                //TO-DO In certain secret seeds, it may be best to look for chest in different sections. In 1.4.4 there are secret seeds that starts the player down below.
                int worldCenterLeft = (Main.maxTilesX / 2) - 420;
                int worldCenterRight = (Main.maxTilesX / 2) + 420;
                int worldCenterTop = (Main.maxTilesY / 2) - 600;
                int worldCenterBottom = (Main.maxTilesY / 2) + 600;

                #region Scan Chests and Add Terragrim
                for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
                {
                    Chest chest = Main.chest[chestIndex];

                    if (chest == null)
                        continue;

                    int TileSubID = 0; //Regular Chest
                    if (!(Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == TileSubID * 36))
                    {
                        for (int slot = 0; slot < 40; slot++)
                        {
                            if (chest.item[slot].type == ItemID.None)
                            {
                                if (Main.rand.NextBool(GetInstance<IOtherConfig>().TerragrimChestChance))
                                    chest.item[slot].SetDefaults(ItemID.Terragrim);
                                break;
                            }
                        }
                    }

                    TileSubID = 1; //Gold Chest
                    if (Main.tile[chest.x, chest.y].TileType == TileID.Containers)
                    {
                        if (Main.tile[chest.x, chest.y].TileFrameX == TileSubID * 36)
                        {
                            if (chest.x >= worldCenterLeft && chest.x <= worldCenterRight && chest.y >= worldCenterTop && chest.y <= worldCenterBottom)
                                centerGoldChests.Add(chestIndex);
                            goldChests.Add(chestIndex);
                        }

                        TileSubID = 10; //Ivy Chest
                        if (Main.tile[chest.x, chest.y].TileFrameX == TileSubID * 36)
                        {
                            ivyChests.Add(chestIndex);
                            if (beeMinecartMissing)
                            {
                                for (int slot = 0; slot < 40; slot++)
                                {
                                    if (chest.item[slot].type == ItemID.BeeMinecart)
                                    {
                                        beeMinecartMissing = false;
                                    }
                                }
                            }
                        }

                        TileSubID = 32; //Mushroom Chest
                        if (Main.tile[chest.x, chest.y].TileFrameX == TileSubID * 36)
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
                }
                #endregion

                #region Add Missing Items
                if (beeMinecartMissing && ivyChests.Count > 0)
                {
                    int chestIndex = ivyChests[Main.rand.Next(ivyChests.Count)];

                    Chest chest = Main.chest[chestIndex];
                    for (int slot = 0; slot < 40; slot++)
                    {
                        if (chest.item[slot].type == ItemID.None)
                        {
                            chest.item[slot].SetDefaults(ItemID.BeeMinecart);
                            break;
                        }
                    }
                }

                int mushroomChestAttempts = 0;
                while (missingMushroomItems.Count > 0)
                {
                    tryToPlaceMushroomChest(Main.rand.Next(0, mushroomBiomes.Count), missingMushroomItems[0]);
                    mushroomChestAttempts++;
                    if (mushroomChestAttempts >= 5)
                        break;
                }
                #endregion
            }
        }
    }
}
