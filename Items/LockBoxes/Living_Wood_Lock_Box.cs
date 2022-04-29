using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace ReducedGrinding.Items.LockBoxes
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
			Item.width = 32;
			Item.height = 22;
			Item.maxStack = 99;
			Item.rare = ItemRarityID.White;
			Item.value = Item.buyPrice(0, 1, 0, 0);
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			int itemid = 0;
			var source = player.GetSource_DropAsItem();

			if (GetInstance<GLockbBoxConfig>().LockBoxesGiveFurniture)
			{
				//Living Wood Chest Items
				switch (Main.rand.Next(3))
				{
					case 0:
						player.QuickSpawnItem(source, 832, 1); //Living Wood Wand
						break;
					case 1:
						player.QuickSpawnItem(source, 933, 1); //Leaf Wand
						break;
					case 2:
						player.QuickSpawnItem(source, 2196, 1); //Living Loom
						break;
				}
			}

			if (GetInstance<GLockbBoxConfig>().LockBoxesGiveNonFurniture)
			{
				//Surface Chest Rare Items
				switch (Main.rand.Next(11))
				{
					case 0:
						player.QuickSpawnItem(source, 280, 1); //Spear
						break;
					case 1:
						player.QuickSpawnItem(source, 284, 1); //Boomerang
						break;
					case 2:
						player.QuickSpawnItem(source, 281, 1); //Blowpipe
						break;
					case 3:
						player.QuickSpawnItem(source, 282, Main.rand.Next(40, 75)); //Glowstick
						break;
					case 4:
						player.QuickSpawnItem(source, 279, Main.rand.Next(70, 150)); //Throwing Knife
						break;
					case 5:
						player.QuickSpawnItem(source, 285, 1); //Aglet
						break;
					case 6:
						player.QuickSpawnItem(source, 953, 1); //Climbing Claws
						break;
					case 7:
						player.QuickSpawnItem(source, 946, 1); //Umbrella
						break;
					case 8:
						player.QuickSpawnItem(source, 3084, 1); //Radar
						break;
					case 9:
						player.QuickSpawnItem(source, 3068, 1); //Guide to Plant Fiber Cordage
						break;
					case 10:
						player.QuickSpawnItem(source, 3069, 1); //Wand of Sparking
						break;
				}

				//Surface Chest Common Items
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(source, 168, Main.rand.Next(3, 6)); //Grenade
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
					player.QuickSpawnItem(source, itemid, Main.rand.Next(3, 11));
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
					player.QuickSpawnItem(source, itemid, Main.rand.Next(25, 51));
				}
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(source, 28, Main.rand.Next(3, 6)); //Lesser Healing Potion
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
					player.QuickSpawnItem(source, itemid, Main.rand.Next(1, 3));
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
					player.QuickSpawnItem(source, itemid, Main.rand.Next(10, 21));
				}
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(source, 965, Main.rand.Next(50, 101)); //Rope
				if (Main.rand.Next(6) == 0)
					player.QuickSpawnItem(source, 3093, Main.rand.Next(1, 5)); //Herb Bag
				if (Main.rand.Next(3) <= 1)
					player.QuickSpawnItem(source, 2350, Main.rand.Next(2, 5)); //Recall Potion
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(source, 72, Main.rand.Next(10, 30)); //Silver Coins
			}
		}
	}
}