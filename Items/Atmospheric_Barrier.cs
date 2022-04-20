using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ReducedGrinding.Items
{
	public class Atmospheric_Barrier : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Atmospheric Barrier");
            Tooltip.SetDefault("Sends the Celestial Invasion back to where they came from.");
        }
		
		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 40;
			item.maxStack = 1;
			item.value = Item.buyPrice(0, 3, 46);
			item.rare = 10;
            item.useAnimation = 20;
            item.useTime = 45;
            item.useStyle = 4;
			item.UseSound = SoundID.Item79;
            item.consumable = false;
		}

        public override bool CanUseItem(Player player)
        {
			return true;
        }

        public override bool UseItem(Player player)
        {
			if (Main.netMode == NetmodeID.Server)
				NetMessage.BroadcastChatMessage(NetworkText.FromKey("The Celestial Invasion was stopped."), new Color(255, 0, 255));
			else if (Main.netMode == NetmodeID.SinglePlayer) // Single Player
				Main.NewText("The Celestial Invasion was stopped.", 255, 0, 255);
			NPC.TowerActiveVortex = false;
			NPC.TowerActiveNebula = false;
			NPC.TowerActiveSolar = false;
			NPC.TowerActiveStardust = false;
			NPC.LunarApocalypseIsUp = false;
			for (int i = 0; i < Main.npc.Length; i++)
			{
				if ((Main.npc[i].type >= NPCID.StardustWormHead && Main.npc[i].type <= NPCID.VortexSoldier) || Main.npc[i].type == NPCID.LunarTowerNebula || (Main.npc[i].type >= NPCID.SolarFlare && Main.npc[i].type <= NPCID.SolarGoop) || Main.npc[i].type == NPCID.LunarTowerStardust) //Celestial Pillars and all of their enemy spawns
					Main.npc[i].life = 0;
			}
			Terraria.GameContent.Events.CultistRitual.delay = 0;
			return true;
        }
		
		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(520); //Soul of Light
			recipe.AddIngredient(521); //Soul of Night
			recipe.AddIngredient(547); //Soul of Fright
			recipe.AddIngredient(548); //Soul of Might
			recipe.AddIngredient(549); //Soul of Sight
			recipe.AddIngredient(575); //Soul of Flight
			recipe.AddIngredient(3467); //Luminite Bar
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}