using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.WorldBuilding;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Chat;
using System.IO;
using Terraria;
using log4net;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Content.Sources;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Terraria.GameContent.Bestiary;
using Terraria.Localization;
using Terraria.ModLoader.Assets;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Core;
using Terraria.ModLoader.UI;


namespace ReducedGrinding.Global
{
	public class WorldGen : ModSystem
    {
		public override void PostWorldGen()
		{
			if (GetInstance<IOtherConfig>().GenerateMissingRareChestItems == false)
				return;

			//int worldSize = Main.maxTilesX / 4200 == 1 ? 1 : Main.maxTilesX / 4200 == 1.5 ? 2 : 3; in case I need it.

			List<int> missingPyramidItems = new List<int> { ItemID.PharaohsMask, ItemID.PharaohsRobe, ItemID.FlyingCarpet , ItemID.SandstorminaBottle };
			List<int> missingLivingWoodItems = new List<int> { ItemID.BabyBirdStaff, ItemID.SunflowerMinecart, ItemID.LadybugMinecart};
			List<int> missingMushroomItems = new List<int> { ItemID.ShroomMinecart, ItemID.MushroomHat, ItemID.MushroomVest, ItemID.MushroomPants};
			bool beeMinecartMissing = true;

			List<int> desertChests = new List<int>();
			List<int> ivyChests = new List<int>();
			List<int> livingWoodChests = new List<int>();
			List<int> woodChests = new List<int>();
			List<int> mushroomChests = new List<int>();
			List<int> centerGoldChests = new List<int>();

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
							List<int> missingPyramidItemsOld = new List<int>();
							missingPyramidItemsOld.AddRange(missingPyramidItems);

							foreach (int itemType in missingPyramidItemsOld)
								if (chest.item[inventoryIndex].type == itemType)
								{
									missingPyramidItems.Remove(itemType);
									ModContent.GetInstance<ReducedGrinding>().Logger.Debug("Found pyramid item, missing count: " + missingPyramidItems.Count.ToString());
								}
						}
						if (chest.x >= worldCenterLeft && chest.x <= worldCenterRight && chest.y >= worldCenterTop && chest.y <= worldCenterBottom)
							centerGoldChests.Add(chestIndex);
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
								ModContent.GetInstance<ReducedGrinding>().Logger.Debug("Found Bee Minecart");
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
							List<int> missingLivingWoodItemsOld = new List<int>();
							missingLivingWoodItemsOld.AddRange(missingLivingWoodItems);

							foreach (int itemType in missingLivingWoodItemsOld)
								if (chest.item[inventoryIndex].type == itemType)
								{
									missingLivingWoodItems.Remove(itemType);
									ModContent.GetInstance<ReducedGrinding>().Logger.Debug("Found Living Wood item, missing count: " + missingLivingWoodItems.Count.ToString());
								}
						}
					}

					TileSubID = 32; //Mushroom Chest
					if (Main.tile[chest.x, chest.y].TileFrameX == TileSubID * 36)
					{
						mushroomChests.Add(chestIndex);
						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							List<int> missingMushroomItemsOld = new List<int>();
							missingMushroomItemsOld.AddRange(missingMushroomItems);

							foreach (int itemType in missingMushroomItemsOld)
								if (chest.item[inventoryIndex].type == itemType)
								{
									missingMushroomItems.Remove(itemType);
									ModContent.GetInstance<ReducedGrinding>().Logger.Debug("Found mushroom item, missing count: " + missingMushroomItems.Count.ToString());
								}
						}
					}
				}

				TileSubID = 10; //Sandstone Chest
				if (Main.tile[chest.x, chest.y].TileType == TileID.Containers2 && Main.tile[chest.x, chest.y].TileFrameX == TileSubID * 36)
					desertChests.Add(chestIndex);
			}

			ModContent.GetInstance<ReducedGrinding>().Logger.Debug("");

			ModContent.GetInstance<ReducedGrinding>().Logger.Debug("Desert Chests: " + desertChests.Count.ToString());
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
							ModContent.GetInstance<ReducedGrinding>().Logger.Debug("Placed pyramid item, missing count: " + missingPyramidItems.Count.ToString());
							if (desertChests.Count > 1)
								desertChests.RemoveAt(desertChestsIndex);
							break;
						}
					}
				}
            }

			ModContent.GetInstance<ReducedGrinding>().Logger.Debug("Ivy Chests: " + ivyChests.Count.ToString());
			if (beeMinecartMissing && ivyChests.Count > 0)
			{
				int chestIndex = ivyChests[Main.rand.Next(ivyChests.Count)];

				Chest chest = Main.chest[chestIndex];
				for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
				{
					if (chest.item[inventoryIndex].type == ItemID.None)
					{
						chest.item[inventoryIndex].SetDefaults(ItemID.BeeMinecart);
						ModContent.GetInstance<ReducedGrinding>().Logger.Debug("Placed Bee Minecart");
						break;
					}
				}
			}

			ModContent.GetInstance<ReducedGrinding>().Logger.Debug("Living Wood Chests: " + livingWoodChests.Count.ToString());
			ModContent.GetInstance<ReducedGrinding>().Logger.Debug("Surface Chests: " + woodChests.Count.ToString());
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
								ModContent.GetInstance<ReducedGrinding>().Logger.Debug("Placed Living Wood item, missing count: " + missingLivingWoodItems.Count.ToString());
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
								ModContent.GetInstance<ReducedGrinding>().Logger.Debug("Placed Living Wood item, missing count: " + missingLivingWoodItems.Count.ToString());
								if (woodChests.Count > 1)
									woodChests.RemoveAt(surfaceChestIndex);
								break;
							}
						}
					}
				}
			}

			ModContent.GetInstance<ReducedGrinding>().Logger.Debug("Mushroom Chests: " + mushroomChests.Count.ToString());
			ModContent.GetInstance<ReducedGrinding>().Logger.Debug("Center Gold Chests: " + centerGoldChests.Count.ToString());
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
								ModContent.GetInstance<ReducedGrinding>().Logger.Debug("Placed Mushroom item, missing count: " + missingMushroomItems.Count.ToString());
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
								ModContent.GetInstance<ReducedGrinding>().Logger.Debug("Placed Mushroom item, missing count: " + missingMushroomItems.Count.ToString());
								if (centerGoldChests.Count > 1)
									centerGoldChests.RemoveAt(centerGoldChestIndex);
								break;
							}
						}
					}
				}
			}
		}
	}
}