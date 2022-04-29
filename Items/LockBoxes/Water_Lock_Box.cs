using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ReducedGrinding.Items.LockBoxes
{
	public class Water_Lock_Box : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Water Lock Box");
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

			//Water Chest Items
			if (Main.rand.Next(15) == 0)
				player.QuickSpawnItem(source, 863, 1); //Water Walking Boots
			else
			{
				switch (Main.rand.Next(3))
				{
					case 0:
						player.QuickSpawnItem(source, 277, 1); //Trident
						break;
					case 1:
						player.QuickSpawnItem(source, 186, 1); //Breathing Reed
						break;
					case 2:
						player.QuickSpawnItem(source, 187); //Flipper
						break;
				}
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