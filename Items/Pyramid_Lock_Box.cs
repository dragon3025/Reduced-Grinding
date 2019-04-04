using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
	public class Pyramid_Lock_Box : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pyramid Lock Box");
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
				//Pyramid Banners
				if (Main.rand.Next(3) <= 1)
					player.QuickSpawnItem(789, 1); //Ankh Banner
				if (Main.rand.Next(3) <= 1)
					player.QuickSpawnItem(790, 1); //Snake Banner
				if (Main.rand.Next(3) <= 1)
					player.QuickSpawnItem(791, 1); //Omega Banner
			}

			if (mPlayer.clientConf.LockBoxesGiveNonFurniture)
			{
				//Pyramid Gold Chest Items
				switch (Main.rand.Next(3))
				{
					case 0:
						player.QuickSpawnItem(857, 1); //Sandstorm in a Bottle
						break;
					case 1:
						player.QuickSpawnItem(848, 1); //Pharaoh's Mask
						player.QuickSpawnItem(866, 1); //Pharaoh's Robe
						break;
					case 2:
						player.QuickSpawnItem(934); //Flying Carpet
						break;
				}

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
}