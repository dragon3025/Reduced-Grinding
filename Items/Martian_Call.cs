using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Terraria.GameContent.Achievements;
using Microsoft.Xna.Framework;

namespace ReducedGrinding.Items
{
	public class Martian_Call : ModItem
    {
		
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Martian Call");
            Tooltip.SetDefault("Calls in a Martian Invasion.");
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
			return true;
        }

        public override bool UseItem(Player player)
        {
			Main.invasionDelay = 0;
			Main.StartInvasion(4);
			NetMessage.SendData(MessageID.WorldData);
			NetMessage.SendData(MessageID.InvasionProgressReport, -1, -1, null, 0, 1f, Main.invasionType + 3);
			return true;
        }
	}
}