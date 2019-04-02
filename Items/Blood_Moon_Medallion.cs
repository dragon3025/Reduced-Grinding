using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Terraria.GameContent.Achievements;
using Microsoft.Xna.Framework;

namespace ReducedGrinding.Items
{
	public class Blood_Moon_Medallion : ModItem
    {
		
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Moon Medallion");
            Tooltip.SetDefault("Causes a blood moon.");
        }
		
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 30;
			item.maxStack = 99;
			item.value = 2000;
			item.rare = 1;
            item.useAnimation = 20;
            item.useTime = 45;
            item.useStyle = 4;
			item.UseSound = new Terraria.Audio.LegacySoundStyle(SoundID.ForceRoar, 0);
            item.consumable = true;
		}

        public override bool CanUseItem(Player player)
        {
			if (Main.dayTime == false)
				return true;
			else
			{
				Main.NewText("You can only use this at night.");
				return false;
			}
        }

        public override bool UseItem(Player player)
        {
			if (Main.moonPhase == 4)
			{
				if (Main.netMode == NetmodeID.Server)
					NetMessage.BroadcastChatMessage(NetworkText.FromKey("The moon phase advanced in order to start the blood moon."), new Color(255, 255, 0));
				else if (Main.netMode == NetmodeID.SinglePlayer) // Single Player
					Main.NewText("The moon phase advanced in order to start the blood moon.", 255, 255, 0);
				Main.moonPhase++;
			}
			Main.bloodMoon = true;
			AchievementsHelper.NotifyProgressionEvent(4);
			if (Main.netMode == NetmodeID.SinglePlayer)
			{
				Main.NewText(Lang.misc[8].Value, 50, byte.MaxValue, 130);
			}
			else if (Main.netMode == NetmodeID.Server)
			{
				NetMessage.BroadcastChatMessage(Lang.misc[8].ToNetworkText(), new Color(50, 255, 130));
			}
			if (Main.netMode == NetmodeID.Server)
			{
				NetMessage.SendData(7);
			}
			return true;
        }
	}
}