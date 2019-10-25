using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items.LockBoxes
{
	public class Underground_Lock_Box : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Underground Lock Box");
			Tooltip.SetDefault("It's already unlocked\nRight click to open");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 22;
			item.maxStack = 99;
			item.rare = 0;
			item.value = Item.buyPrice(0, 1, 0, 0);
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			float dropChance = 0f;
			int testItemID = 0;
			int chosenID = 0;
			int itemid = 0;

			if (Config.LockBoxesGiveFurniture)
			{
				//Cabin Statues
				dropChance = 0.0169f;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 52;
				for (testItemID = 438; testItemID <= 441; testItemID++)
				{
					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 443;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 446;
				for (testItemID = 448; testItemID <= 455; testItemID++)
				{

					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				for (testItemID = 457; testItemID <= 463; testItemID++)
				{
					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				for (testItemID = 465; testItemID <= 473; testItemID++)
				{
					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				for (testItemID = 475; testItemID <= 478; testItemID++)
				{
					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 2672;
				for (testItemID = 3708; testItemID <= 3720; testItemID++)
				{
					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				if (chosenID != 476 && chosenID != 477 && Main.rand.Next(10) == 0) //10% chance of being king or queen statue
					player.QuickSpawnItem(Main.rand.Next(476, 478));
				else
					player.QuickSpawnItem(chosenID);
				chosenID = 0;

				//Cabin Paintings
				dropChance = 0.0067f; //About 0.1 paintings when rolling 1 time for 15 paintings
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1427;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1428;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1442;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1443;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1474;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1480;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1495;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1496;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1498;
				for (testItemID = 1574; testItemID <= 1577; testItemID++)
				{
					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				player.QuickSpawnItem(chosenID);
				chosenID = 0;
			}

			if (Config.LockBoxesGiveNonFurniture)
			{
				//Underground Rare Items
				if (Main.rand.Next(20) == 0)
				{
					player.QuickSpawnItem(ItemID.Extractinator);
				}
				else
				{
					switch (Main.rand.Next(7))
					{
						case 0:
							player.QuickSpawnItem(49, 1); //Band of Regeneration
							break;
						case 1:
							player.QuickSpawnItem(50, 1); //Magic Mirror
							break;
						case 2:
							player.QuickSpawnItem(53, 1); //Cloud in a Bottle
							break;
						case 3:
							player.QuickSpawnItem(54, 1); //Hermes Boots
							break;
						case 4:
							player.QuickSpawnItem(55, 1); //Enchanted Boomerang
							break;
						case 5:
							player.QuickSpawnItem(975, 1); //Shoe Spikes
							break;
						case 6:
							player.QuickSpawnItem(930); //Flare Gun
							player.QuickSpawnItem(931, Main.rand.Next(25, 51)); //Flares
							break;
					}
				}

				//Underground Chest Common Items			
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(166, Main.rand.Next(10, 20)); //Bomb
				if (Main.rand.Next(5) == 0)
					player.QuickSpawnItem(52, 1); //Angel Statue
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(965, Main.rand.Next(50, 101)); //Rope
				if (Main.rand.Next(2) == 0)
				{
					switch (Main.rand.Next(2))
					{
						case 0:
							itemid = WorldGen.ironBar;
							break;
						case 1:
							itemid = WorldGen.silverBar;
							break;
					}
					player.QuickSpawnItem(itemid, Main.rand.Next(5, 15));
				}
				if (Main.rand.Next(2) == 0)
				{
					switch (Main.rand.Next(2))
					{
						case 0:
							itemid = 40; //Arrow
							break;
						case 1:
							itemid = 42; //Shuriken
							break;
					}
					player.QuickSpawnItem(itemid, Main.rand.Next(25, 51));
				}
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(28, Main.rand.Next(3, 6)); //Lesser Healing Potion
				if (Main.rand.Next(3) <= 1)
				{
					switch (Main.rand.Next(9))
					{
						case 0:
							itemid = 289; //Regeneration Potion
							break;
						case 1:
							itemid = 298; //Shine Potion
							break;
						case 2:
							itemid = 299; //Night Owl Potion
							break;
						case 3:
							itemid = 290; //Swiftness Potion
							break;
						case 4:
							itemid = 303; //Archery Potion
							break;
						case 5:
							itemid = 291; //Gills Potion
							break;
						case 6:
							itemid = 304; //Hunter Potion
							break;
						case 7:
							itemid = 2322; //Mining Potion
							break;
						case 8:
							itemid = 2329; //Dangersense Potion
							break;
					}
					player.QuickSpawnItem(itemid, Main.rand.Next(1, 3));
				}
				if (Main.rand.Next(2) == 0)
				{
					player.QuickSpawnItem(8, Main.rand.Next(10, 21)); //Torch
				}
				if (Main.rand.Next(3) <= 1)
					player.QuickSpawnItem(2350, Main.rand.Next(1, 3)); //Recall Potion
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(72, Main.rand.Next(50, 90)); //Silver Coins
			}
		}
	}
}