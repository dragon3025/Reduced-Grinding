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
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.White;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.value = Item.buyPrice(0, 2, 0 , 0);
            Item.UseSound = SoundID.Item4;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
			if (Main.invasionType == 3)
				return true;
			else
				return false;
        }

        public override bool? UseItem(Player player)
        {
			Main.invasionSize = 0;
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				Main.ReportInvasionProgress(Main.invasionSizeStart - Main.invasionSize, Main.invasionSizeStart, 6, 0);
			}
			if (Main.netMode == NetmodeID.Server)
			{
				NetMessage.SendData(MessageID.InvasionProgressReport, -1, -1, null, Main.invasionProgress, Main.invasionProgressMax, Main.invasionProgressIcon);
			}
			return true;
        }
    }
}