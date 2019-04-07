 using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items.LockBoxes
{
	public class Web_Covered_Lock_Box : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Web Covered Lock Box");
			Tooltip.SetDefault("It's already unlocked\nRight click to open");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 22;
			item.maxStack = 99;
			item.rare = 3;
			item.value = Item.buyPrice(0, 0, 1, 0);
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			int itemid = 0;
			float itemroll = Main.rand.NextFloat();
			
			//Web Covered Chest Primary Items
			player.QuickSpawnItem(939, 1); //Web Slinger
			
			//Cavern Gold Chest Common Items
			if (Main.rand.Next(5) == 0)
				player.QuickSpawnItem(ItemID.SuspiciousLookingEye, 1);
			if (Main.rand.Next(3) == 0)
				player.QuickSpawnItem(ItemID.Dynamite, 1);
			if (Main.rand.Next(4) == 0)
				player.QuickSpawnItem(ItemID.JestersArrow, Main.rand.Next(25, 51));
			if (Main.rand.Next(2) == 0)
			{
				switch (Main.rand.Next(4))
				{
					case 0:
						itemid = WorldGen.silverBar;
						break;
					case 1:
						itemid = WorldGen.goldBar;
						break;
					default:
						itemid = 0;
						break;
				}
				player.QuickSpawnItem(itemid, Main.rand.Next(3, 11));
			}
			if (Main.rand.Next(2) == 0)
			{
				switch (Main.rand.Next(2))
				{
					case 0:
						itemid = 41; //Flaming Arrow
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
						itemid = 8; //Torch
						break;
					case 1:
						itemid = 282; //Glowstick
						break;
				}
				player.QuickSpawnItem(itemid, Main.rand.Next(15, 30));
			}
			if (Main.rand.Next(2) == 0)
				player.QuickSpawnItem(73, Main.rand.Next(2, 3)); //Gold Coin
		}

	}
}