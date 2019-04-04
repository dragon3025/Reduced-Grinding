using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
	public class Ice_Lock_Box : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Lock Box");
			Tooltip.SetDefault("It's already unlocked\nRight click to open");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 22;
			item.maxStack = 99;
			item.rare = 1;
			item.value = 10000;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			ReducedGrindingPlayer mPlayer = player.GetModPlayer<ReducedGrindingPlayer>(mod);

			float itemroll = 0f;
			float dropChance = 0f;
			int testItemID = 0;
			int chosenID = 0;

			if (mPlayer.clientConf.LockBoxesGiveFurniture)
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

			if (mPlayer.clientConf.LockBoxesGiveNonFurniture)
			{
				//Ice Chest Common Items
				switch (Main.rand.Next(6))
				{
					case 0:
						player.QuickSpawnItem(670, 1); //Ice Boomerang
						break;
					case 1:
						player.QuickSpawnItem(724, 1); //Ice Blade
						break;
					case 2:
						player.QuickSpawnItem(950, 1); //Ice Skates
						break;
					case 3:
						player.QuickSpawnItem(166, 1); //Snowball Cannon
						break;
					case 4:
						player.QuickSpawnItem(987, 1); //Blizzard in a Bottle
						break;
					case 5:
						player.QuickSpawnItem(1579, 1); //Flurry Boots
						break;
				}

				//Ice Chest Rare Items
				itemroll = Main.rand.NextFloat();
				if (itemroll < 0.05f)
					player.QuickSpawnItem(997, 1); //Extractinator
				else if (itemroll < 0.25f)
					player.QuickSpawnItem(2198, 1); //Ice Machine
				else if (itemroll < 0.45f)
					player.QuickSpawnItem(3199, 1); //Ice Mirror
				else if (itemroll < 0.49f)
					player.QuickSpawnItem(669, 1); //Fish (Item)

				//Cavern Gold Chest Common Items
				if (Main.rand.Next(5) == 0)
					player.QuickSpawnItem(43, 1); //Suspicious Looking Eye
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(167, 1); //Dynamite
				if (Main.rand.Next(4) == 0)
					player.QuickSpawnItem(51, Main.rand.Next(25, 51)); //Jester's Arrow
				if (Main.rand.Next(2) == 0)
				{
					switch (Main.rand.Next(4))
					{
						case 0:
							chosenID = WorldGen.silverBar;
							break;
						case 1:
							chosenID = WorldGen.goldBar;
							break;
						default:
							chosenID = 0;
							break;
					}
					player.QuickSpawnItem(chosenID, Main.rand.Next(3, 11));
				}
				if (Main.rand.Next(2) == 0)
				{
					switch (Main.rand.Next(2))
					{
						case 0:
							chosenID = 41; //Flaming Arrow
							break;
						case 1:
							chosenID = 279; //Throwing Knife
							break;
					}
					player.QuickSpawnItem(chosenID, Main.rand.Next(25, 51));
				}
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(188, Main.rand.Next(3, 6)); //Healing Potion
				if (Main.rand.Next(3) <= 1)
				{
					switch (Main.rand.Next(6))
					{
						case 0:
							chosenID = 296; //Spelunker Potion
							break;
						case 1:
							chosenID = 295; //Featherfall Potion
							break;
						case 2:
							chosenID = 299; //Night Owl Potion
							break;
						case 3:
							chosenID = 302; //Water Walking Potion
							break;
						case 4:
							chosenID = 303; //Archery Potion
							break;
						case 5:
							chosenID = 305; //Gravitation Potion
							break;
					}
					player.QuickSpawnItem(chosenID, Main.rand.Next(1, 3));
				}
				else
				{
					switch (Main.rand.Next(6))
					{
						case 0:
							chosenID = 301; //Thorns Potion
							break;
						case 1:
							chosenID = 302; //Water Walking Potion
							break;
						case 2:
							chosenID = 297; //Invisiblity Potion
							break;
						case 3:
							chosenID = 304; //Hunter Potion
							break;
						case 4:
							chosenID = 2329; //Dangersense Potion
							break;
						case 5:
							chosenID = 2351; //Teleportation Potion
							break;
					}
					player.QuickSpawnItem(chosenID, Main.rand.Next(1, 3));
				}
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(2350, Main.rand.Next(1, 3)); //Recal Potion
				if (Main.rand.Next(2) == 0)
				{
					switch (Main.rand.Next(2))
					{
						case 0:
							chosenID = 8; //Torch
							break;
						case 1:
							chosenID = 282; //Glowstick
							break;
					}
					player.QuickSpawnItem(chosenID, Main.rand.Next(15, 30));
				}
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(73, Main.rand.Next(2, 3)); //Gold Coin
			}
		}
	}
}