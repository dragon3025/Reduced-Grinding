using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
	public class Biome_Lock_Box : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Biome Lock Box");
			Tooltip.SetDefault("Right click to open\nRequires a Biome Key.\nWill only drop loot from Biome Chest that any player has obtained in this world.");
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
				if (player.HasItem(ItemID.JungleKey) && ReducedGrindingWorld.jungleChestMined)
					return true;
				else if (player.HasItem(ItemID.CorruptionKey) && ReducedGrindingWorld.infectionChestMined)
					return true;
				else if (player.HasItem(ItemID.CrimsonKey) && ReducedGrindingWorld.infectionChestMined)
					return true;
				else if (player.HasItem(ItemID.HallowedKey) && ReducedGrindingWorld.hallowedChestMined)
					return true;
				else if (player.HasItem(ItemID.FrozenKey) && ReducedGrindingWorld.frozenChestMined)
					return true;
				else
					return false;
		}

		public override void RightClick(Player player)
		{
			int itemid = 0;
			
			//Rare Biome Chest Item
			int itemDiscarded = 0;
			if (player.HasItem(ItemID.JungleKey) && ReducedGrindingWorld.jungleChestMined)
			{
				player.QuickSpawnItem(ItemID.PiranhaGun, 1);
				itemDiscarded = ItemID.JungleKey;
			}
			else if (player.HasItem(ItemID.CorruptionKey) && ReducedGrindingWorld.infectionChestMined)
			{
				player.QuickSpawnItem(ItemID.ScourgeoftheCorruptor, 1);
				itemDiscarded = ItemID.CorruptionKey;
			}
			else if (player.HasItem(ItemID.CrimsonKey) && ReducedGrindingWorld.infectionChestMined)
			{
				player.QuickSpawnItem(ItemID.VampireKnives, 1);
				itemDiscarded = ItemID.CrimsonKey;
			}
			else if (player.HasItem(ItemID.HallowedKey) && ReducedGrindingWorld.hallowedChestMined)
			{
				player.QuickSpawnItem(ItemID.RainbowGun, 1);
				itemDiscarded = ItemID.HallowedKey;
			}
			else if (player.HasItem(ItemID.FrozenKey) && ReducedGrindingWorld.frozenChestMined)
			{
				player.QuickSpawnItem(ItemID.StaffoftheFrostHydra, 1);
				itemDiscarded = ItemID.FrozenKey;
			}
			for (int i = 0; i < 58; i++)
			{
				if (player.inventory[i].type == itemDiscarded && player.inventory[i].stack > 0)
					player.inventory[i].stack--;
			}
			
			//Cavern Gold Chest Common Items
			if (Main.rand.Next(5) == 0)
				player.QuickSpawnItem(ItemID.SuspiciousLookingEye, 1);
			if (Main.rand.Next(3) == 0)
				player.QuickSpawnItem(ItemID.Dynamite, 1); //Dynamite
			if (Main.rand.Next(4) == 0)
				player.QuickSpawnItem(ItemID.JestersArrow, Main.rand.Next(25, 51)); //Jester's Arrow
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
						itemid = ItemID.FlamingArrow;
						break;
					case 1:
						itemid = ItemID.ThrowingKnife;
						break;
				}
				player.QuickSpawnItem(itemid, Main.rand.Next(25, 51));
			}
			if (Main.rand.Next(2) == 0)
				player.QuickSpawnItem(ItemID.HealingPotion, Main.rand.Next(3, 6));
			if (Main.rand.Next(3) <= 1)
			{
				switch (Main.rand.Next(6))
				{
					case 0:
						itemid = ItemID.SpelunkerPotion;
						break;
					case 1:
						itemid = ItemID.FeatherfallPotion;
						break;
					case 2:
						itemid = ItemID.NightOwlPotion;
						break;
					case 3:
						itemid = ItemID.WaterWalkingPotion;
						break;
					case 4:
						itemid = ItemID.ArcheryPotion;
						break;
					case 5:
						itemid = ItemID.GravitationPotion;
						break;
				}
				player.QuickSpawnItem(itemid, Main.rand.Next(1, 3));
			}
			else
			{
				switch (Main.rand.Next(6))
				{
					case 0:
						itemid = ItemID.ThornsPotion;
						break;
					case 1:
						itemid = ItemID.WaterWalkingPotion;
						break;
					case 2:
						itemid = ItemID.InvisibilityPotion;
						break;
					case 3:
						itemid = ItemID.HunterPotion;
						break;
					case 4:
						itemid = ItemID.TrapsightPotion; //Dangersense Potion
						break;
					case 5:
						itemid = ItemID.TeleportationPotion;
						break;
				}
				player.QuickSpawnItem(itemid, Main.rand.Next(1, 3));
			}
			if (Main.rand.Next(2) == 0)
				player.QuickSpawnItem(ItemID.RecallPotion, Main.rand.Next(1, 3));
			if (Main.rand.Next(2) == 0)
			{
				switch (Main.rand.Next(2))
				{
					case 0:
						itemid = ItemID.Torch;
						break;
					case 1:
						itemid = ItemID.Glowstick;
						break;
				}
				player.QuickSpawnItem(itemid, Main.rand.Next(15, 30));
			}
			if (Main.rand.Next(2) == 0)
				player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(2, 3));
		}
	}
}
