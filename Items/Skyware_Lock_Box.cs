using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
	public class Skyware_Lock_Box : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skyware Lock Box");
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
				//Floating Island Banners
				if (Main.rand.Next(3) <= 1)
					player.QuickSpawnItem(845, 1); //World Banner
				if (Main.rand.Next(3) <= 1)
					player.QuickSpawnItem(846, 1); //Sun Banner
				if (Main.rand.Next(3) <= 1)
					player.QuickSpawnItem(847, 1); //Gravity Banner
			}

			//Skyware Chest Items
			if (mPlayer.clientConf.LockBoxesGiveNonFurniture)
			{
				switch (Main.rand.Next(3))
				{
					case 0:
						player.QuickSpawnItem(159, 1); //Shiny Red Balloon
						break;
					case 1:
						player.QuickSpawnItem(65, 1); //Starfury
						break;
					case 2:
						player.QuickSpawnItem(158); //Lucky Horseshoe
						break;
				}
			}
			if (Main.rand.Next(3) == 0 && mPlayer.clientConf.LockBoxesGiveFurniture)
				player.QuickSpawnItem(2197, 1); //Skymill

			if (mPlayer.clientConf.LockBoxesGiveNonFurniture)
			{
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
				if (Main.rand.Next(2) <= 1)
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