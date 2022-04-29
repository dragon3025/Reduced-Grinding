using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Items.LockBoxes
{
	public class Shadow_Lock_Box : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Lock Box");
			Tooltip.SetDefault("Right click to open\nRequires a Shadow Key");
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
			Player player = Main.player[Main.myPlayer];
			if (player.HasItem(ItemID.ShadowKey))
				return true;
			else
				return false;
		}

		public override void RightClick(Player player)
		{
			float dropChance = 0f;
			int testItemID = 0;
			int chosenID = 0;
			var source = player.GetSource_DropAsItem();

			if (GetInstance<GLockbBoxConfig>().LockBoxesGiveFurniture)
			{
				//Ruined House Banners
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(source, 1464, 1); //Hellhound Banner
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(source, 1465, 1); //Hell Hammer Banner
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(source, 1466, 1); //Hell Tower Banner
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(source, 1467, 1); //Lost Hopes Banner
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(source, 1468, 1); //Obsidian Watcher Banner
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(source, 1469, 1); //Lava Erupts Banner

				//Ruined House Furniture
				if (Main.rand.Next(5) == 0)
				{
					player.QuickSpawnItem(source, 221, 1); //Hellforge
				}
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(source, 433, Main.rand.Next(5, 11)); //Demon Torch
				dropChance = 0.04f; //About 4 furniture for rollng 5 times for 20 furnitures.
				for (int i = 0; i <= 4; i++) //Other Furniture
				{
					for (testItemID = 1457; testItemID <= 1463; testItemID++)
					{
						if (Main.rand.NextFloat() < dropChance)
							chosenID = testItemID;
					}
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 1473;
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 2380;
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 2390;
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 2406;
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 2600;
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 2618;
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 2642;
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 2644;
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 2651;
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 2657;
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 2662;
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 2667;
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 2840;
					player.QuickSpawnItem(source, chosenID);
					chosenID = 0;
				}

				//Ruined House Paintings
				dropChance = 0.0556f; //About 2 paintings when rolling 3 times for 12 paintings
				for (int i = 0; i <= 2; i++)
				{
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 1475;
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 1476;
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 1478;
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 1479;
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 1497;
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 1499;
					if (Main.rand.NextFloat() < dropChance)
						chosenID = 1501;
					for (testItemID = 1538; testItemID <= 1542; testItemID++)
					{
						if (Main.rand.NextFloat() < dropChance)
							chosenID = testItemID;
					}
					player.QuickSpawnItem(source, chosenID);
					chosenID = 0;
				}
			}

			if (GetInstance<GLockbBoxConfig>().LockBoxesGiveNonFurniture)
			{
				//Shadow Lock Box Rare Items
				switch (Main.rand.Next(5))
				{
					case 0:
						player.QuickSpawnItem(source, ItemID.DarkLance, 1);
						break;
					case 1:
						player.QuickSpawnItem(source, ItemID.Flamelash, 1);
						break;
					case 2:
						player.QuickSpawnItem(source, ItemID.FlowerofFire, 1);
						break;
					case 3:
						player.QuickSpawnItem(source, ItemID.Sunfury, 1);
						break;
					case 4:
						player.QuickSpawnItem(source, ItemID.HellwingBow, 1);
						break;
				}
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(source, ItemID.Dynamite, 1);
				if (Main.rand.Next(2) == 0)
				{
					if (Main.rand.Next(1) == 0)
					{
						player.QuickSpawnItem(source, ItemID.MeteoriteBar, Main.rand.Next(15, 30)); //First number in inclusive, 2nd is exclusive
					}
					else
					{
						player.QuickSpawnItem(source, WorldGen.goldBar, Main.rand.Next(15, 30));
					}
				}
				if (Main.rand.Next(2) == 0)
				{
					if (Main.rand.Next(1) == 0)
					{
						player.QuickSpawnItem(source, ItemID.HellfireArrow, Main.rand.Next(50, 75));
					}
					else
					{
						player.QuickSpawnItem(source, ItemID.SilverBullet, Main.rand.Next(50, 75));
					}
				}
				if (Main.rand.Next(2) == 0)
				{
					if (Main.rand.Next(1) == 0)
					{
						player.QuickSpawnItem(source, ItemID.LesserRestorationPotion, Main.rand.Next(15, 21));
					}
					else
					{
						player.QuickSpawnItem(source, ItemID.RestorationPotion, Main.rand.Next(15, 21));
					}
				}
				if (Main.rand.Next(4) <= 2)
				{
					switch (Main.rand.Next(8))
					{
						case 0:
							player.QuickSpawnItem(source, ItemID.SpelunkerPotion, Main.rand.Next(1, 3));
							break;
						case 1:
							player.QuickSpawnItem(source, ItemID.FeatherfallPotion, Main.rand.Next(1, 3));
							break;
						case 2:
							player.QuickSpawnItem(source, ItemID.ManaRegenerationPotion, Main.rand.Next(1, 3));
							break;
						case 3:
							player.QuickSpawnItem(source, ItemID.ObsidianSkinPotion, Main.rand.Next(1, 3));
							break;
						case 4:
							player.QuickSpawnItem(source, ItemID.MagicPowerPotion, Main.rand.Next(1, 3));
							break;
						case 5:
							player.QuickSpawnItem(source, ItemID.InvisibilityPotion, Main.rand.Next(1, 3));
							break;
						case 6:
							player.QuickSpawnItem(source, ItemID.HunterPotion, Main.rand.Next(1, 3));
							break;
						case 7:
							player.QuickSpawnItem(source, ItemID.HeartreachPotion, Main.rand.Next(1, 3));
							break;
					}
				}
				if (Main.rand.Next(3) <= 1)
				{
					switch (Main.rand.Next(8))
					{
						case 0:
							player.QuickSpawnItem(source, ItemID.GravitationPotion, Main.rand.Next(1, 3));
							break;
						case 1:
							player.QuickSpawnItem(source, ItemID.ThornsPotion, Main.rand.Next(1, 3));
							break;
						case 2:
							player.QuickSpawnItem(source, ItemID.WaterWalkingPotion, Main.rand.Next(1, 3));
							break;
						case 3:
							player.QuickSpawnItem(source, ItemID.ObsidianSkinPotion, Main.rand.Next(1, 3));
							break;
						case 4:
							player.QuickSpawnItem(source, ItemID.BattlePotion, Main.rand.Next(1, 3));
							break;
						case 5:
							player.QuickSpawnItem(source, ItemID.TeleportationPotion, Main.rand.Next(1, 3));
							break;
						case 6:
							player.QuickSpawnItem(source, ItemID.InfernoPotion, Main.rand.Next(1, 3));
							break;
						case 7:
							player.QuickSpawnItem(source, ItemID.LifeforcePotion, Main.rand.Next(1, 3));
							break;
					}
				}
				if (Main.rand.Next(3) == 0)
				{
					player.QuickSpawnItem(source, ItemID.RecallPotion, Main.rand.Next(1, 3));
				}
				if (Main.rand.Next(2) == 0)
				{
					if (Main.rand.Next(1) == 0)
					{
						player.QuickSpawnItem(source, ItemID.Torch, Main.rand.Next(15, 30));
					}
					else
					{
						player.QuickSpawnItem(source, ItemID.Glowstick, Main.rand.Next(15, 30));
					}
				}
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(source, ItemID.GoldCoin, Main.rand.Next(2, 5));
			}
		}
	}
}