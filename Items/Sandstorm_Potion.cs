using Microsoft.Xna.Framework;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;
using Terraria.Chat;

namespace ReducedGrinding.Items
{
	public class Sandstorm_Potion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandstorm Potion");
            Tooltip.SetDefault("Starts/stops sandstorm");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.maxStack = 30;
            Item.rare = ItemRarityID.Green;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
			Item.value = Item.buyPrice(0, 0, 2, 0);
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override bool? UseItem(Player player)
        {
            if (Sandstorm.Happening)
                StopSandstorm();
            else
                StartSandstorm();
           
            return true;
        }
		
		private static void ChangeSeverityIntentions()
		{
			if (Sandstorm.Happening)
			{
				Sandstorm.IntendedSeverity = 0.4f + Main.rand.NextFloat();
			}
			else
			{
				if (Main.rand.Next(3) == 0)
				{
					Sandstorm.IntendedSeverity = 0f;
				}
				else
				{
					Sandstorm.IntendedSeverity = Main.rand.NextFloat() * 0.3f;
				}
			}
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				NetMessage.SendData(MessageID.WorldData, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
			}
		}
       
		private static void StopSandstorm()
		{
			if (Main.netMode == NetmodeID.Server)
				ChatHelper.BroadcastChatMessage(NetworkText.FromKey("The sandstorm stopped."), new Color(0, 128, 255));
			else if (Main.netMode == NetmodeID.SinglePlayer) // Single Player
				Main.NewText("The sandstorm stopped.", 0, 128, 255);
			Sandstorm.Happening = false;
			Sandstorm.TimeLeft = 0;
			ChangeSeverityIntentions();
		}

		private static void StartSandstorm()
		{
			if (Main.netMode == NetmodeID.Server)
			{
				ChatHelper.BroadcastChatMessage(NetworkText.FromKey("The sandstorm started."), new Color(0, 128, 255));
			}
			else if (Main.netMode == NetmodeID.SinglePlayer) // Single Player
			{
				Main.NewText("The sandstorm started.", 0, 128, 255);
			}
			Sandstorm.Happening = true;
			Sandstorm.TimeLeft = (int)(3600f * (8f + Main.rand.NextFloat() * 16f));
			ChangeSeverityIntentions();
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ItemID.Blinkroot)
				.AddIngredient(ItemID.SandBlock)
				.AddTile(TileID.Bottles)
				.Register();
        }
    }
}