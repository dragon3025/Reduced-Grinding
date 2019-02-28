using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
	public class Ivy_Lock_Box : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ivy Lock Box");
			Tooltip.SetDefault("It's already unlocked\nRight click to open");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 22;
			item.maxStack = 99;
			item.rare = 3;
			item.value = 10000;
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
			player.QuickSpawnItem(chosenID);
			if (chosenID != 476 && chosenID != 477 && Main.rand.Next(4) == 0)
				player.QuickSpawnItem(Main.rand.Next(476, 478));
			
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
			
			//Undereground Jungle Cabin Sharpening Station
			if (Main.rand.Next(5) <= 1)
			{
				player.QuickSpawnItem(3198, 1); //Sharpening Station
			}
			
			float itemroll = Main.rand.NextFloat();
			
			//Ivy Chest Primary Items
			if (itemroll < 0.225f)
				player.QuickSpawnItem(212, 1); //Anklet of the Wind
			else if (itemroll < 0.45f)
				player.QuickSpawnItem(211, 1); //Feral Claws
			else if (itemroll < 0.675f)
				player.QuickSpawnItem(213, 1); //Staff of Regrowth
			else if (itemroll < 0.9f)
				player.QuickSpawnItem(964, 1); //Boomstick
			else if (itemroll < 0.92f)
				player.QuickSpawnItem(964, 1); //Seaweed
			else if (itemroll < 0.953f)
				player.QuickSpawnItem(2292, 1); //Fiberglass Fishing Pole
			else
				player.QuickSpawnItem(3017, 1); //Flower Boots
			
			//Ivy Chest Secondary Items
			if (Main.rand.Next(6) == 0)
			{
				player.QuickSpawnItem(3360, 1); //Living Mahogany Wand
				player.QuickSpawnItem(3361, 1); //Living Mahogany Leaf Wand
			}
			if (Main.rand.Next(4) == 0)
				player.QuickSpawnItem(2204, 1); //Honey Dispenser
			
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