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
			item.rare = 3;
			item.value = 10000;
			
			
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			//Ice Chest Common Items
			int itemid = 0;
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
			int itemroll = Main.rand.Next(100);
			if (itemroll < 5)
				player.QuickSpawnItem(997, 1); //Extractinator
			else if (itemroll < 25)
				player.QuickSpawnItem(2198, 1); //Ice Machine
			else if (itemroll < 45)
				player.QuickSpawnItem(3199, 1); //Ice Mirror
			else if (itemroll < 45)
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
							itemid = 21; //Silver Bar
							break;
						case 1:
							itemid = 705; //Tungsten Bar
							break;
						case 2:
							itemid = 19; //Gold Bar
							break;
						case 3:
							itemid = 706; //Platinum Bar
							break;
					}
				player.QuickSpawnItem(itemid, Main.rand.Next(3, 11));
			}
			if (Main.rand.Next(2) == 0)
			{
				switch (Main.rand.Next(2))
					{
						case 0:
							itemid = 988; //Frostburn Arrow
							break;
						case 1:
							itemid = 279; //Throwing Knife
							break;
					}
				player.QuickSpawnItem(itemid, Main.rand.Next(25, 51));
			}
			if (Main.rand.Next(2) == 0)
				player.QuickSpawnItem(188, Main.rand.Next(3, 6)); //Healing Potion
			if (Main.rand.Next(3) <= 1)
			{
				switch (Main.rand.Next(6))
					{
						case 0:
							itemid = 296; //Spelunker Potion
							break;
						case 1:
							itemid = 295; //Featherfall Potion
							break;
						case 2:
							itemid = 299; //Night Owl Potion
							break;
						case 3:
							itemid = 302; //Water Walking Potion
							break;
						case 4:
							itemid = 303; //Archery Potion
							break;
						case 5:
							itemid = 305; //Gravitation Potion
							break;
					}
				player.QuickSpawnItem(itemid, Main.rand.Next(1, 3));
			}
			else
			{
				switch (Main.rand.Next(6))
					{
						case 0:
							itemid = 301; //Thorns Potion
							break;
						case 1:
							itemid = 302; //Water Walking Potion
							break;
						case 2:
							itemid = 297; //Invisiblity Potion
							break;
						case 3:
							itemid = 304; //Hunter Potion
							break;
						case 4:
							itemid = 2329; //Dangersense Potion
							break;
						case 5:
							itemid = 2351; //Teleportation Potion
							break;
					}
				player.QuickSpawnItem(itemid, Main.rand.Next(1, 3));
			}
			if (Main.rand.Next(2) == 0)
				player.QuickSpawnItem(2350, Main.rand.Next(1, 3)); //Recal Potion
			if (Main.rand.Next(2) == 0)
			{
				switch (Main.rand.Next(2))
					{
						case 0:
							itemid = 974; //Ice Torch
							break;
						case 1:
							itemid = 282; //Glowstick
							break;
					}
				player.QuickSpawnItem(itemid, Main.rand.Next(15, 30));
			}
			if (Main.rand.Next(2) == 0)
				player.QuickSpawnItem(73, Main.rand.Next(1, 3)); //Gold Coin
		}

	}
}