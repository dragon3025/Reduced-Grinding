using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ReducedGrinding.Items
{
	public class Pirate_Retreat_Order : ModItem
	{
		
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pirate Retreat Order");
            Tooltip.SetDefault("This will stop the Pirate Invasion.");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 99;
            item.rare = 0;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.value = Item.buyPrice(0, 2, 0 , 0);
            item.UseSound = SoundID.Item4;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
			if (Main.invasionType == 3)
				return true;
			else
				return false;
        }

        public override bool UseItem(Player player)
        {
			Main.invasionSize = 0;
			if (Main.netMode != 1)
			{
				Main.ReportInvasionProgress(Main.invasionSizeStart - Main.invasionSize, Main.invasionSizeStart, 6, 0);
			}
			if (Main.netMode == NetmodeID.Server)
			{
				NetMessage.SendData(78, -1, -1, null, Main.invasionProgress, Main.invasionProgressMax, Main.invasionProgressIcon);
			}
			return true;
        }
    }
}