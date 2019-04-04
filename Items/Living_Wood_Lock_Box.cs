using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
	public class Living_Wood_Lock_Box : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Living Wood Lock Box");
			Tooltip.SetDefault("It's already unlocked\nRight click to open");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 22;
			item.maxStack = 99;
			item.rare = 0;
			item.value = 10000;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			ReducedGrindingPlayer mPlayer = player.GetModPlayer<ReducedGrindingPlayer>(mod);
			int itemid = 0;

			if (mPlayer.clientConf.LockBoxesGiveFurniture)
			{
				//Living Wood Chest Items
				switch (Main.rand.Next(3))
				{
					case 0:
						player.QuickSpawnItem(832, 1); //Living Wood Wand
						break;
					case 1:
						player.QuickSpawnItem(933, 1); //Leaf Wand
						break;
					case 2:
						player.QuickSpawnItem(2196, 1); //Living Loom
						break;
				}
			}

			if (mPlayer.clientConf.LockBoxesGiveNonFurniture)
			{
				//Surface Chest Rare Items
				switch (Main.rand.Next(11))
				{
					case 0:
						player.QuickSpawnItem(280, 1); //Spear
						break;
					case 1:
						player.QuickSpawnItem(284, 1); //Boomerang
						break;
					case 2:
						player.QuickSpawnItem(281, 1); //Blowpipe
						break;
					case 3:
						player.QuickSpawnItem(282, Main.rand.Next(40, 75)); //Glowstick
						break;
					case 4:
						player.QuickSpawnItem(279, Main.rand.Next(70, 150)); //Throwing Knife
						break;
					case 5:
						player.QuickSpawnItem(285, 1); //Aglet
						break;
					case 6:
						player.QuickSpawnItem(953, 1); //Climbing Claws
						break;
					case 7:
						player.QuickSpawnItem(946, 1); //Umbrella
						break;
					case 8:
						player.QuickSpawnItem(3084, 1); //Radar
						break;
					case 9:
						player.QuickSpawnItem(3068, 1); //Guide to Plant Fiber Cordage
						break;
					case 10:
						player.QuickSpawnItem(3069, 1); //Wand of Sparking
						break;
				}

				//Surface Chest Common Items
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(168, Main.rand.Next(3, 6)); //Grenade
				if (Main.rand.Next(2) == 0)
				{
					switch (Main.rand.Next(2))
					{
						case 0:
							itemid = WorldGen.copperBar;
							break;
						case 1:
							itemid = WorldGen.ironBar;
							break;
					}
					player.QuickSpawnItem(itemid, Main.rand.Next(3, 11));
				}
				if (Main.rand.Next(3) <= 1)
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
					switch (Main.rand.Next(6))
					{
						case 0:
							itemid = 292; //Ironskin Potion
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
							itemid = 2322; //Mining Potion
							break;
						case 5:
							itemid = 2325; //Builder Potion
							break;
					}
					player.QuickSpawnItem(itemid, Main.rand.Next(1, 3));
				}
				if (Main.rand.Next(2) == 0)
				{
					switch (Main.rand.Next(2))
					{
						case 0:
							itemid = 8; //Torch
							break;
						case 1:
							itemid = 31; //Bottle
							break;
					}
					player.QuickSpawnItem(itemid, Main.rand.Next(10, 21));
				}
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(965, Main.rand.Next(50, 101)); //Rope
				if (Main.rand.Next(6) == 0)
					player.QuickSpawnItem(3093, Main.rand.Next(1, 5)); //Herb Bag
				if (Main.rand.Next(3) <= 1)
					player.QuickSpawnItem(2350, Main.rand.Next(2, 5)); //Recall Potion
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(72, Main.rand.Next(10, 30)); //Silver Coins
			}
		}
	}
}