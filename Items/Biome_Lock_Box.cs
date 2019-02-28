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
				if (player.HasItem(1533) && ReducedGrindingWorld.jungleChestMined)
					return true;
				else if (player.HasItem(1534) && ReducedGrindingWorld.infectionChestMined) //Corruption Key
					return true;
				else if (player.HasItem(1535) && ReducedGrindingWorld.infectionChestMined) //Crimson Key
					return true;
				else if (player.HasItem(1536) && ReducedGrindingWorld.hallowedChestMined)
					return true;
				else if (player.HasItem(1537) && ReducedGrindingWorld.frozenChestMined)
					return true;
				else
					return false;
		}

		public override void RightClick(Player player)
		{
			int itemid = 0;
			
			//Rare Biome Chest Item
			int itemDiscarded = 0;
			if (player.HasItem(1533) && ReducedGrindingWorld.jungleChestMined)
			{
				player.QuickSpawnItem(1156, 1); //Piranha Gun
				itemDiscarded = 1533;
			}
			else if (player.HasItem(1534) && ReducedGrindingWorld.infectionChestMined)
			{
				player.QuickSpawnItem(1571, 1); //Scourge of the Corruptor
				itemDiscarded = 1534;
			}
			else if (player.HasItem(1535) && ReducedGrindingWorld.infectionChestMined)
			{
				player.QuickSpawnItem(1569, 1); //Vampire Knives
				itemDiscarded = 1535;
			}
			else if (player.HasItem(1536) && ReducedGrindingWorld.hallowedChestMined)
			{
				player.QuickSpawnItem(1260, 1); //Rainbow Gun
				itemDiscarded = 1536;
			}
			else if (player.HasItem(1537) && ReducedGrindingWorld.frozenChestMined)
			{
				player.QuickSpawnItem(1572, 1); //Staff of the Frost Hydra
				itemDiscarded = 1537;
			}
			for (int i = 0; i < 58; i++)
			{
				if (player.inventory[i].type == itemDiscarded && player.inventory[i].stack > 0)
					player.inventory[i].stack--;
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