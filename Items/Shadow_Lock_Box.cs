using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
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
			item.value = 10000;
			
			
		}

		public override bool CanRightClick()
		{
			Player player = Main.player[Main.myPlayer];
			if (player.HasItem(ItemID.ShadowKey))
				return true;
			else
				return false;
			
			return true;
		}

		public override void RightClick(Player player)
		{
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
					player.QuickSpawnItem(ItemID.GoldBar, Main.rand.Next(15, 30));
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
					player.QuickSpawnItem(ItemID.LesserRestorationPotion, Main.rand.Next(15, 30));
				}
				else
				{
					player.QuickSpawnItem(ItemID.RestorationPotion, Main.rand.Next(15, 30));
				}
			}
			if (Main.rand.Next(4) <= 2)
			{
				switch (Main.rand.Next(7))
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
				}
			}
			if (Main.rand.Next(3) <= 1)
			{
				switch (Main.rand.Next(5))
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
				}
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