using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace ReducedGrinding.Items.LockBoxes
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
				//Floating Island Banners
				if (Main.rand.Next(3) <= 1)
					player.QuickSpawnItem(source, 845, 1); //World Banner
				if (Main.rand.Next(3) <= 1)
					player.QuickSpawnItem(source, 846, 1); //Sun Banner
				if (Main.rand.Next(3) <= 1)
					player.QuickSpawnItem(source, 847, 1); //Gravity Banner
			}

			//Skyware Chest Items
			if (GetInstance<GLockbBoxConfig>().LockBoxesGiveNonFurniture)
			{
				switch (Main.rand.Next(3))
				{
					case 0:
						player.QuickSpawnItem(source, 159, 1); //Shiny Red Balloon
						break;
					case 1:
						player.QuickSpawnItem(source, 65, 1); //Starfury
						break;
					case 2:
						player.QuickSpawnItem(source, 158); //Lucky Horseshoe
						break;
				}
			}
			if (Main.rand.Next(3) == 0 && GetInstance<GLockbBoxConfig>().LockBoxesGiveFurniture)
				player.QuickSpawnItem(source, 2197, 1); //Skymill

			if (GetInstance<GLockbBoxConfig>().LockBoxesGiveNonFurniture)
			{
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
}