using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
			item.width = 32;
			item.height = 22;
			item.maxStack = 99;
			item.rare = 3;
			item.value = Item.buyPrice(0, 1, 0, 0);
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
			ReducedGrindingPlayer mPlayer = player.GetModPlayer<ReducedGrindingPlayer>(mod);

			float dropChance = 0f;
			int testItemID = 0;
			int chosenID = 0;

			if (mPlayer.clientConf.LockBoxesGiveFurniture)
			{
				//Ruined House Banners
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(1464, 1); //Hellhound Banner
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(1465, 1); //Hell Hammer Banner
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(1466, 1); //Hell Tower Banner
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(1467, 1); //Lost Hopes Banner
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(1468, 1); //Obsidian Watcher Banner
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(1469, 1); //Lava Erupts Banner

				//Ruined House Furniture
				if (Main.rand.Next(5) == 0)
				{
					player.QuickSpawnItem(221, 1); //Hellforge
				}
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(433, Main.rand.Next(5, 11)); //Demon Torch
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
					player.QuickSpawnItem(chosenID);
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
					player.QuickSpawnItem(chosenID);
					chosenID = 0;
				}
			}

			if (mPlayer.clientConf.LockBoxesGiveNonFurniture)
			{
				//Shadow Lock Box Rare Items
				switch (Main.rand.Next(5))
				{
					case 0:
						player.QuickSpawnItem(ItemID.DarkLance, 1);
						break;
					case 1:
						player.QuickSpawnItem(ItemID.Flamelash, 1);
						break;
					case 2:
						player.QuickSpawnItem(ItemID.FlowerofFire, 1);
						break;
					case 3:
						player.QuickSpawnItem(ItemID.Sunfury, 1);
						break;
					case 4:
						player.QuickSpawnItem(ItemID.HellwingBow, 1);
						break;
				}
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(ItemID.Dynamite, 1);
				if (Main.rand.Next(2) == 0)
				{
					if (Main.rand.Next(1) == 0)
					{
						player.QuickSpawnItem(ItemID.MeteoriteBar, Main.rand.Next(15, 30)); //First number in inclusive, 2nd is exclusive
					}
					else
					{
						player.QuickSpawnItem(WorldGen.goldBar, Main.rand.Next(15, 30));
					}
				}
				if (Main.rand.Next(2) == 0)
				{
					if (Main.rand.Next(1) == 0)
					{
						player.QuickSpawnItem(ItemID.HellfireArrow, Main.rand.Next(50, 75));
					}
					else
					{
						player.QuickSpawnItem(ItemID.SilverBullet, Main.rand.Next(50, 75));
					}
				}
				if (Main.rand.Next(2) == 0)
				{
					if (Main.rand.Next(1) == 0)
					{
						player.QuickSpawnItem(ItemID.LesserRestorationPotion, Main.rand.Next(15, 21));
					}
					else
					{
						player.QuickSpawnItem(ItemID.RestorationPotion, Main.rand.Next(15, 21));
					}
				}
				if (Main.rand.Next(4) <= 2)
				{
					switch (Main.rand.Next(8))
					{
						case 0:
							player.QuickSpawnItem(ItemID.SpelunkerPotion, Main.rand.Next(1, 3));
							break;
						case 1:
							player.QuickSpawnItem(ItemID.FeatherfallPotion, Main.rand.Next(1, 3));
							break;
						case 2:
							player.QuickSpawnItem(ItemID.ManaRegenerationPotion, Main.rand.Next(1, 3));
							break;
						case 3:
							player.QuickSpawnItem(ItemID.ObsidianSkinPotion, Main.rand.Next(1, 3));
							break;
						case 4:
							player.QuickSpawnItem(ItemID.MagicPowerPotion, Main.rand.Next(1, 3));
							break;
						case 5:
							player.QuickSpawnItem(ItemID.InvisibilityPotion, Main.rand.Next(1, 3));
							break;
						case 6:
							player.QuickSpawnItem(ItemID.HunterPotion, Main.rand.Next(1, 3));
							break;
						case 7:
							player.QuickSpawnItem(ItemID.HeartreachPotion, Main.rand.Next(1, 3));
							break;
					}
				}
				if (Main.rand.Next(3) <= 1)
				{
					switch (Main.rand.Next(8))
					{
						case 0:
							player.QuickSpawnItem(ItemID.GravitationPotion, Main.rand.Next(1, 3));
							break;
						case 1:
							player.QuickSpawnItem(ItemID.ThornsPotion, Main.rand.Next(1, 3));
							break;
						case 2:
							player.QuickSpawnItem(ItemID.WaterWalkingPotion, Main.rand.Next(1, 3));
							break;
						case 3:
							player.QuickSpawnItem(ItemID.ObsidianSkinPotion, Main.rand.Next(1, 3));
							break;
						case 4:
							player.QuickSpawnItem(ItemID.BattlePotion, Main.rand.Next(1, 3));
							break;
						case 5:
							player.QuickSpawnItem(ItemID.TeleportationPotion, Main.rand.Next(1, 3));
							break;
						case 6:
							player.QuickSpawnItem(ItemID.InfernoPotion, Main.rand.Next(1, 3));
							break;
						case 7:
							player.QuickSpawnItem(ItemID.LifeforcePotion, Main.rand.Next(1, 3));
							break;
					}
				}
				if (Main.rand.Next(3) == 0)
				{
					player.QuickSpawnItem(ItemID.RecallPotion, Main.rand.Next(1, 3));
				}
				if (Main.rand.Next(2) == 0)
				{
					if (Main.rand.Next(1) == 0)
					{
						player.QuickSpawnItem(ItemID.Torch, Main.rand.Next(15, 30));
					}
					else
					{
						player.QuickSpawnItem(ItemID.Glowstick, Main.rand.Next(15, 30));
					}
				}
				if (Main.rand.Next(2) == 0)
					player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(2, 5));
			}
		}
	}
}