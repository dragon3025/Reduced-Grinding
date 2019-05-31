using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Terraria.GameContent.Achievements;
using Microsoft.Xna.Framework;

namespace ReducedGrinding.Items
{
	public class Lunar_Call : ModItem
    {
		
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lunar Call");
            Tooltip.SetDefault("Instantly kills the Lunatic Cultist and Summons the Celestial Invasion.");
        }
		
		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 34;
			item.maxStack = 99;
			item.value = Item.buyPrice(0, 0, 50, 0);
			item.rare = 1;
            item.useAnimation = 20;
            item.useTime = 45;
            item.useStyle = 4;
			item.UseSound = new Terraria.Audio.LegacySoundStyle(SoundID.ForceRoar, 0);
            item.consumable = true;
		}

        public override bool CanUseItem(Player player)
		{
			bool LunaticCultistExists = false;
			for (int i = 0; i < Main.npc.Length; i++)
			{
				if (Main.npc[i].type == NPCID.CultistBoss)
				{
					LunaticCultistExists = true;
				}
			}
			if (LunaticCultistExists)
				return true;
			else
				return false;
        }

        public override bool UseItem(Player player)
        {
			Main.invasionDelay = 0;
			//Main.StartInvasion(4);
			for (int i = 0; i < Main.npc.Length; i++)
			{
				if (Main.npc[i].type == NPCID.CultistBoss)
				{
					Main.npc[i].type = NPCID.BlueSlime;
					Main.npc[i].life = 0;
				}
			}
			WorldGen.TriggerLunarApocalypse();
			NetMessage.SendData(7);
			NetMessage.SendData(78, -1, -1, null, 0, 1f, Main.invasionType + 3);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentVortex);
			recipe.AddIngredient(ItemID.FragmentNebula);
			recipe.AddIngredient(ItemID.FragmentSolar);
			recipe.AddIngredient(ItemID.FragmentStardust);
			recipe.AddIngredient(ItemID.ChlorophyteBar);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
