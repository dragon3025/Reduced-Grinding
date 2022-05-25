using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ReducedGrinding.Items.BossAndEventControl
{
	public class Plantera_Bulb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plantera Bulb");
            Tooltip.SetDefault("This is a dangerous flower, use in the Jungle.");
        }
		
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 1;
			Item.value = Item.buyPrice(0, 10, 0, 0);
			Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 20;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
			Item.UseSound = new Terraria.Audio.LegacySoundStyle(SoundID.ForceRoar, 0);
			Item.consumable = true;
		}

        public override bool CanUseItem(Player player)
        {
			if (player.ZoneJungle)
				return true;
			else
				return false;
		}

        public override bool? UseItem(Player player)
        {
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.Plantera);
			return true;
		}
	}
}