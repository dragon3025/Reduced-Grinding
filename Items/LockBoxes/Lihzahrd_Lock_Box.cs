using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Items.LockBoxes
{
	public class Lihzahrd_Lock_Box : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lihzahrd Lock Box");
			Tooltip.SetDefault("It's already unlocked\nRight click to open");
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
			return true;
		}

		public override void RightClick(Player player)
		{

			int itemid = 0;
			float itemroll = Main.rand.NextFloat();
			var source = player.GetSource_DropAsItem();

			player.QuickSpawnItem(source, ItemID.LihzahrdBrick, Main.rand.Next(10, 21));

			if (GetInstance<GLockbBoxConfig>().LockBoxesGiveFurniture)
			{
				//Lihzahrd Temple Statues
				player.QuickSpawnItem(source, Main.rand.Next(1152, 1155));
			}

			//Lihzahrd Chest Primary Items
			if (GetInstance<GLockbBoxConfig>().LockBoxesGiveFurniture)
			{
				player.QuickSpawnItem(source, 2195, 1); //Lihzahrd Furnace
			}
			if (GetInstance<GLockbBoxConfig>().LockBoxesGiveNonFurniture)
			{
				player.QuickSpawnItem(source, 1293, 1); //Lihzahrd Power Cell
				if (Main.rand.Next(5) == 0)
					player.QuickSpawnItem(source, 2767, 1); //Solar Tablet
				else
					player.QuickSpawnItem(source, 2766, 1); //Solar Tablet Fragment
			}

			if (GetInstance<GLockbBoxConfig>().LockBoxesGiveNonFurniture)
			{
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