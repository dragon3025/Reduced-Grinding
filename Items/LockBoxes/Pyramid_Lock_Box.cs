using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace ReducedGrinding.Items.LockBoxes
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
				//Pyramid Banners
				if (Main.rand.Next(3) <= 1)
					player.QuickSpawnItem(source, 789, 1); //Ankh Banner
				if (Main.rand.Next(3) <= 1)
					player.QuickSpawnItem(source, 790, 1); //Snake Banner
				if (Main.rand.Next(3) <= 1)
					player.QuickSpawnItem(source, 791, 1); //Omega Banner
			}

			if (GetInstance<GLockbBoxConfig>().LockBoxesGiveNonFurniture)
			{
				//Pyramid Gold Chest Items
				switch (Main.rand.Next(3))
				{
					case 0:
						player.QuickSpawnItem(source, 857, 1); //Sandstorm in a Bottle
						break;
					case 1:
						player.QuickSpawnItem(source, 848, 1); //Pharaoh's Mask
						player.QuickSpawnItem(source, 866, 1); //Pharaoh's Robe
						break;
					case 2:
						player.QuickSpawnItem(source, 934); //Flying Carpet
						break;
				}

				//Cavern Gold Chest Common Items
				if (Main.rand.Next(5) == 0)
					player.QuickSpawnItem(source, 43, 1); //Suspicious Looking Eye
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(source, 167, 1); //Dynamite
				if (Main.rand.Next(4) == 0)
					player.QuickSpawnItem(source, 51, Main.rand.Next(25, 51)); //Jester's Arrow
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
					player.QuickSpawnItem(source, itemid, Main.rand.Next(3, 11));
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
					player.QuickSpawnItem(source, itemid, Main.rand.Next(25, 51));
				}
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(source, 188, Main.rand.Next(3, 6)); //Healing Potion
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
					player.QuickSpawnItem(source, itemid, Main.rand.Next(1, 3));
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
					player.QuickSpawnItem(source, itemid, Main.rand.Next(1, 3));
				}
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(source, 2350, Main.rand.Next(1, 3)); //Recal Potion
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
					player.QuickSpawnItem(source, itemid, Main.rand.Next(15, 30));
				}
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(source, 73, Main.rand.Next(2, 3)); //Gold Coin
			}
		}
	}
}