using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace ReducedGrinding.Items.LockBoxes
{
	public class Biome_Lock_Box : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Biome Lock Box");
			string KeysRequired = GetInstance<GLockbBoxConfig>().BiomeLockboxKeysRequired.ToString();
			Tooltip.SetDefault("Right click to open.\n" +
							   "Requires any Biome key with a stack size of "+ KeysRequired + ". The key used will be choosen at random if more\n" +
							   "than one stack meets this requirement. The Rare item inside will match the key type used.");
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

			bool HasEnoughKeys = false;

			for (int i = 0; i < 58; i++)
			{
				if ((player.inventory[i].type == ItemID.JungleKey || player.inventory[i].type == ItemID.CorruptionKey || player.inventory[i].type == ItemID.CrimsonKey || player.inventory[i].type == ItemID.HallowedKey || player.inventory[i].type == ItemID.FrozenKey) && player.inventory[i].stack >= GetInstance<GLockbBoxConfig>().BiomeLockboxKeysRequired)
				{
					HasEnoughKeys = true;
					break;
				}
			}
			return HasEnoughKeys;
		}

		public override void RightClick(Player player)
		{
			int itemid = 0;
			var source = player.GetSource_DropAsItem();

			List<int> keys = new(new int[] { ItemID.JungleKey, ItemID.CorruptionKey, ItemID.CrimsonKey, ItemID.HallowedKey, ItemID.FrozenKey });
			int n = keys.Count;
			while (n > 1)
			{
				n--;
				int k = Main.rand.Next(n + 1);
                (keys[n], keys[k]) = (keys[k], keys[n]);
            }

            int KeyType = 0;

			for (int i = 0; i < keys.Count; i++)
			{
				if (player.HasItem(keys[i]))
				{
					for (int j = 0; j < 58; j++)
					{
						if (player.inventory[j].type == keys[i] && player.inventory[j].stack >= GetInstance<GLockbBoxConfig>().BiomeLockboxKeysRequired)
						{
							player.inventory[j].stack -= GetInstance<GLockbBoxConfig>().BiomeLockboxKeysRequired;
							KeyType = keys[i];
							break;
						}
					}
				}
				if (KeyType > 0)
					break;
			}

			//Rare Item
			switch (KeyType)
			{
				case ItemID.JungleKey:
					player.QuickSpawnItem(source, ItemID.PiranhaGun);
					break;
				case ItemID.CorruptionKey:
					player.QuickSpawnItem(source, ItemID.ScourgeoftheCorruptor);
					break;
				case ItemID.CrimsonKey:
					player.QuickSpawnItem(source, ItemID.VampireKnives);
					break;
				case ItemID.HallowedKey:
					player.QuickSpawnItem(source, ItemID.RainbowGun);
					break;
				case ItemID.FrozenKey:
					player.QuickSpawnItem(source, ItemID.StaffoftheFrostHydra);
					break;
			}

			//Cavern Gold Chest Common Items
			if (Main.rand.Next(5) == 0)
				player.QuickSpawnItem(source, ItemID.SuspiciousLookingEye);
			if (Main.rand.Next(3) == 0)
				player.QuickSpawnItem(source, ItemID.Dynamite); //Dynamite
			if (Main.rand.Next(4) == 0)
				player.QuickSpawnItem(source, ItemID.JestersArrow, Main.rand.Next(25, 51)); //Jester's Arrow
			if (Main.rand.Next(2) == 0)
			{
                itemid = Main.rand.Next(4) switch
                {
                    0 => WorldGen.silverBar,
                    1 => WorldGen.goldBar,
                    _ => 0,
                };
                player.QuickSpawnItem(source, itemid, Main.rand.Next(3, 11));
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
				player.QuickSpawnItem(source, itemid, Main.rand.Next(25, 51));
			}
			if (Main.rand.Next(2) == 0)
				player.QuickSpawnItem(source, ItemID.HealingPotion, Main.rand.Next(3, 6));
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
				player.QuickSpawnItem(source, itemid, Main.rand.Next(1, 3));
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
				player.QuickSpawnItem(source, itemid, Main.rand.Next(1, 3));
			}
			if (Main.rand.Next(2) == 0)
				player.QuickSpawnItem(source, ItemID.RecallPotion, Main.rand.Next(1, 3));
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
				player.QuickSpawnItem(source, itemid, Main.rand.Next(15, 30));
			}
			if (Main.rand.Next(2) == 0)
				player.QuickSpawnItem(source, ItemID.GoldCoin, Main.rand.Next(2, 3));
		}
	}
}
