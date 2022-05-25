using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Terraria.GameContent.Achievements;
using Microsoft.Xna.Framework;

namespace ReducedGrinding.Items.BossAndEventControl
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
			Item.width = 34;
			Item.height = 34;
			Item.maxStack = 99;
			Item.value = Item.buyPrice(0, 0, 50, 0);
			Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 20;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
			Item.UseSound = new Terraria.Audio.LegacySoundStyle(SoundID.ForceRoar, 0);
            Item.consumable = true;
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

        public override bool? UseItem(Player player)
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
			NetMessage.SendData(MessageID.WorldData);
			NetMessage.SendData(MessageID.InvasionProgressReport, -1, -1, null, 0, 1f, Main.invasionType + 3);
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.FragmentVortex)
				.AddIngredient(ItemID.FragmentNebula)
				.AddIngredient(ItemID.FragmentSolar)
				.AddIngredient(ItemID.FragmentStardust)
				.AddIngredient(ItemID.ChlorophyteBar)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}
