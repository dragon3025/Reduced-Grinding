using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Chat;

namespace ReducedGrinding.Items.BossAndEventControl
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
			Item.width = 36;
			Item.height = 40;
			Item.maxStack = 1;
            Item.value = Terraria.Item.buyPrice(0, 3, 46);
			Item.rare = ItemRarityID.Red;
            Item.useAnimation = 20;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
			Item.UseSound = SoundID.Item79;
            Item.consumable = false;
		}

        public override bool CanUseItem(Terraria.Player player)
        {
			return true;
        }

        public override bool? UseItem(Terraria.Player player)
        {
			if (Main.netMode == NetmodeID.Server)
				ChatHelper.BroadcastChatMessage(NetworkText.FromKey("The Celestial Invasion was stopped."), new Color(255, 0, 255));
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
			CreateRecipe()
				.AddIngredient(ItemID.SoulofLight)
				.AddIngredient(ItemID.SoulofNight)
				.AddIngredient(ItemID.SoulofFright)
				.AddIngredient(ItemID.SoulofMight)
				.AddIngredient(ItemID.SoulofSight)
				.AddIngredient(ItemID.SoulofFlight)
				.AddIngredient(ItemID.LunarBar)
				.Register();
        }
	}
}