using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ReducedGrinding.Items
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
			item.width = 32;
			item.height = 32;
			item.maxStack = 1;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 1;
            item.useAnimation = 20;
            item.useTime = 45;
            item.useStyle = 4;
			item.UseSound = new Terraria.Audio.LegacySoundStyle(SoundID.ForceRoar, 0);
			item.consumable = true;
		}

        public override bool CanUseItem(Player player)
        {
			if (player.ZoneJungle)
				return true;
			else
				return false;
		}

        public override bool UseItem(Player player)
        {
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.Plantera);
			return true;
		}
	}
}