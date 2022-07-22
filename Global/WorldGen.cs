using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class WorldGen : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
			int FinalCleanupIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));

			if (FinalCleanupIndex != -1)
			{
				tasks.Insert(FinalCleanupIndex + 1, new ReducedGrindingGen($"{Language.GetTextValue($"Mods.ReducedGrinding.Other.AddingRareChestLoot")}", 10f));
			}
		}

		public class ReducedGrindingGen : GenPass
		{
			public ReducedGrindingGen(string name, float loadWeight) : base(name, loadWeight) {}

			protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
			{
				if (GetInstance<IOtherConfig>().GenerateMissingRareChestItems == false)
					return;

				progress.Message = $"{Language.GetTextValue($"Mods.ReducedGrinding.Other.AddingRareChestLoot")}";

				//TO-DO 1.4.4 will make it easier to get sandstorm in a bottle.
				List<int> missingPyramidItems = new() { ItemID.PharaohsMask, ItemID.PharaohsRobe, ItemID.FlyingCarpet, ItemID.SandstorminaBottle };
				List<int> missingLivingWoodItems = new() { ItemID.SunflowerMinecart, ItemID.LadybugMinecart };
				List<int> missingMushroomItems = new() { ItemID.ShroomMinecart, ItemID.MushroomHat, ItemID.MushroomVest, ItemID.MushroomPants };
				bool beeMinecartMissing = true;

				List<int> desertChests = new();
				List<int> ivyChests = new();
				List<int> livingWoodChests = new();
				List<int> woodChests = new();
				List<int> mushroomChests = new();
				List<int> centerGoldChests = new();
				List<int> goldChests = new();

				int worldCenterLeft = (Main.maxTilesX / 2) - 420;
				int worldCenterRight = (Main.maxTilesX / 2) + 420;
				int worldCenterTop = (Main.maxTilesY / 2) - 600;
				int worldCenterBottom = (Main.maxTilesY / 2) + 600;

				for (int chestIndex = 0; chestIndex < 8000; chestIndex++)
				{
					Chest chest = Main.chest[chestIndex];

					if (chest == null)
						continue;

					int TileSubID = 1; //Gold Chest
					if (Main.tile[chest.x, chest.y].TileType == TileID.Containers)
					{
						if (Main.tile[chest.x, chest.y].TileFrameX == TileSubID * 36)
						{
							for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
							{
								List<int> missingPyramidItemsOld = new();
								missingPyramidItemsOld.AddRange(missingPyramidItems);

								foreach (int itemType in missingPyramidItemsOld)
									if (chest.item[inventoryIndex].type == itemType)
									{
										missingPyramidItems.Remove(itemType);
									}
							}
							if (chest.x >= worldCenterLeft && chest.x <= worldCenterRight && chest.y >= worldCenterTop && chest.y <= worldCenterBottom)
								centerGoldChests.Add(chestIndex);
							goldChests.Add(chestIndex);
						}

						TileSubID = 10; //Ivy Chest
						if (Main.tile[chest.x, chest.y].TileFrameX == TileSubID * 36)
						{
							ivyChests.Add(chestIndex);
							for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
							{
								if (chest.item[inventoryIndex].type == ItemID.BeeMinecart)
								{
									beeMinecartMissing = false;
								}
							}
						}

						TileSubID = 0; //Surface Chest
						if (Main.tile[chest.x, chest.y].TileFrameX == TileSubID * 36)
							woodChests.Add(chestIndex);

						TileSubID = 12; //Living Wood Chest
						if (Main.tile[chest.x, chest.y].TileFrameX == TileSubID * 36)
						{
							livingWoodChests.Add(chestIndex);
							for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
							{
								List<int> missingLivingWoodItemsOld = new();
								missingLivingWoodItemsOld.AddRange(missingLivingWoodItems);

								foreach (int itemType in missingLivingWoodItemsOld)
									if (chest.item[inventoryIndex].type == itemType)
									{
										missingLivingWoodItems.Remove(itemType);
									}
							}
						}

						TileSubID = 32; //Mushroom Chest
						if (Main.tile[chest.x, chest.y].TileFrameX == TileSubID * 36)
						{
							mushroomChests.Add(chestIndex);
							for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
							{
								List<int> missingMushroomItemsOld = new();
								missingMushroomItemsOld.AddRange(missingMushroomItems);

								foreach (int itemType in missingMushroomItemsOld)
									if (chest.item[inventoryIndex].type == itemType)
									{
										missingMushroomItems.Remove(itemType);
									}
							}
						}
					}

					TileSubID = 10; //Sandstone Chest
					if (Main.tile[chest.x, chest.y].TileType == TileID.Containers2 && Main.tile[chest.x, chest.y].TileFrameX == TileSubID * 36)
						desertChests.Add(chestIndex);
				}

				if (desertChests.Count > 0)
				{
					while (missingPyramidItems.Count > 0)
					{
						int desertChestsIndex = Main.rand.Next(desertChests.Count);
						int chestIndex = desertChests[desertChestsIndex];

						Chest chest = Main.chest[chestIndex];
						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == ItemID.None)
							{
								chest.item[inventoryIndex].SetDefaults(missingPyramidItems[0]);
								missingPyramidItems.RemoveAt(0);
								if (desertChests.Count > 1)
									desertChests.RemoveAt(desertChestsIndex);
								break;
							}
						}
					}
				}

				if (beeMinecartMissing && ivyChests.Count > 0)
				{
					int chestIndex = ivyChests[Main.rand.Next(ivyChests.Count)];

					Chest chest = Main.chest[chestIndex];
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == ItemID.None)
						{
							chest.item[inventoryIndex].SetDefaults(ItemID.BeeMinecart);
							break;
						}
					}
				}

				if ((woodChests.Count + livingWoodChests.Count) > 0)
				{
					while (missingLivingWoodItems.Count > 0)
					{
						if (livingWoodChests.Count > 0)
						{
							int livingWoodChestsIndex = Main.rand.Next(livingWoodChests.Count);
							int chestIndex = livingWoodChests[livingWoodChestsIndex];

							Chest chest = Main.chest[chestIndex];
							for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
							{
								if (chest.item[inventoryIndex].type == ItemID.None)
								{
									chest.item[inventoryIndex].SetDefaults(missingLivingWoodItems[0]);
									missingLivingWoodItems.RemoveAt(0);
									livingWoodChests.RemoveAt(livingWoodChestsIndex);
									break;
								}
							}
						}
						else
						{
							int surfaceChestIndex = Main.rand.Next(woodChests.Count);
							int chestIndex = woodChests[surfaceChestIndex];

							Chest chest = Main.chest[chestIndex];
							for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
							{
								if (chest.item[inventoryIndex].type == ItemID.None)
								{
									chest.item[inventoryIndex].SetDefaults(missingLivingWoodItems[0]);
									missingLivingWoodItems.RemoveAt(0);
									if (woodChests.Count > 1)
										woodChests.RemoveAt(surfaceChestIndex);
									break;
								}
							}
						}
					}
				}

				if ((mushroomChests.Count + centerGoldChests.Count) > 0)
				{
					while (missingMushroomItems.Count > 0)
					{
						if (mushroomChests.Count > 0)
						{
							int mushroomChestIndex = Main.rand.Next(mushroomChests.Count);
							int chestIndex = mushroomChests[mushroomChestIndex];

							Chest chest = Main.chest[chestIndex];
							for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
							{
								if (chest.item[inventoryIndex].type == ItemID.None)
								{
									chest.item[inventoryIndex].SetDefaults(missingMushroomItems[0]);
									missingMushroomItems.RemoveAt(0);
									mushroomChests.RemoveAt(mushroomChestIndex);
									break;
								}
							}
						}
						else
						{
							int centerGoldChestIndex = Main.rand.Next(centerGoldChests.Count);
							int chestIndex = centerGoldChests[centerGoldChestIndex];

							Chest chest = Main.chest[chestIndex];
							for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
							{
								if (chest.item[inventoryIndex].type == ItemID.None)
								{
									chest.item[inventoryIndex].SetDefaults(missingMushroomItems[0]);
									missingMushroomItems.RemoveAt(0);
									if (centerGoldChests.Count > 1)
										centerGoldChests.RemoveAt(centerGoldChestIndex);
									break;
								}
							}
						}
					}
				}

				int terragrimToAdd = GetInstance<IOtherConfig>().TerragrimChests;
				while (terragrimToAdd > 0)
				{
					if (goldChests.Count > 0)
					{
						int goldChestIndex = Main.rand.Next(goldChests.Count);
						int chestIndex = goldChests[goldChestIndex];

						Chest chest = Main.chest[chestIndex];
						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == ItemID.None)
							{
								chest.item[inventoryIndex].SetDefaults(ItemID.Terragrim);
								terragrimToAdd--;
								goldChests.RemoveAt(goldChestIndex);
								break;
							}
						}
					}
					else
						terragrimToAdd = 0;
				}
			}
		}
	}
}
