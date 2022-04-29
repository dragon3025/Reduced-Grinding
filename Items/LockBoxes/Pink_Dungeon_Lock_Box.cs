using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items.LockBoxes
{
	public class Pink_Dungeon_Lock_Box : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pink Dungeon Lock Box");
			Tooltip.SetDefault("Right click to open\nRequires a Shadow Key");
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 22;
			Item.maxStack = 99;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(0, 1, 0, 0);
		}

		public override bool CanRightClick()
		{
			Player player = Main.player[Main.myPlayer];
			if (player.HasItem(ItemID.ShadowKey))
				return true;
			else
				return false;
		}

		public override void RightClick(Player player)
		{
			float dropChance = 0f;
			int testItemID = 0;
			int chosenID = 0;
			var source = player.GetSource_DropAsItem();

			player.QuickSpawnItem(source, ItemID.PinkBrick, Main.rand.Next(10, 21));


			//Faction Banners
			if (Main.rand.Next(3) == 0)
				player.QuickSpawnItem(source, 1451, 1);
			if (Main.rand.Next(3) == 0)
				player.QuickSpawnItem(source, 1452, 1);
			if (Main.rand.Next(3) == 0)
				player.QuickSpawnItem(source, 1453, 1);
			if (Main.rand.Next(3) == 0)
				player.QuickSpawnItem(source, 1454, 1);
			if (Main.rand.Next(3) == 0)
				player.QuickSpawnItem(source, 1455, 1);
			if (Main.rand.Next(3) == 0)
				player.QuickSpawnItem(source, 1456, 1);
			
			//Dungeon Furniture
			dropChance = 0.02f; //About 8 furniture for rollng 10 times for 40 furnitures.
			for (int i = 0; i <= 9; i++)
			{
				//Blue Dungeon
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1385;
				for (testItemID = 1402; testItemID <= 1404; testItemID++)
				{
					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1407;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1410;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1413;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1416;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1472;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 2378;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 2388;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 2404;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 2647;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 2654;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 2660;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 2666;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 2839;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 3902;
				//Other
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 136;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 149;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1138;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1376;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1377;
				for (testItemID = 1388; testItemID <= 1395; testItemID++)
				{
					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1417;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1418;
				for (testItemID = 1509; testItemID <= 1512; testItemID++)
				{
					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 3000;
				//Spawn Item
				if (chosenID == 1384 || chosenID == 1418 || (chosenID >= 1387 && chosenID <= 1389))
					player.QuickSpawnItem(source, chosenID, Main.rand.Next(2, 11));
				else if (chosenID == 149)
					player.QuickSpawnItem(source, chosenID, Main.rand.Next(10, 16));
				else
					player.QuickSpawnItem(source, chosenID);
				chosenID = 0;
			}
			
			//Dungeon Paintings
			dropChance = 0.0556f; //About 2 paintings when rolling 3 times for 12 paintings
			for (int i = 0; i <= 2; i++)
			{
				for (testItemID = 1372; testItemID <= 1375; testItemID++)
				{
					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				for (testItemID = 1419; testItemID <= 1426; testItemID++)
				{
					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				for (testItemID = 1433; testItemID <= 1439; testItemID++)
				{
					if (Main.rand.NextFloat() < dropChance)
						chosenID = testItemID;
				}
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1441;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1500;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1502;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 1573;
				if (Main.rand.NextFloat() < dropChance)
					chosenID = 2995;
				player.QuickSpawnItem(source, chosenID);
				chosenID = 0;
			}
		}

	}
}