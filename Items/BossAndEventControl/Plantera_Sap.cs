using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ReducedGrinding.Items.BossAndEventControl
{
	public class Plantera_Sap : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plantera Sap");
			Tooltip.SetDefault("Use in the Jungle to summon Plantera.");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 24;
			Item.maxStack = 1;
			Item.value = 0;
			Item.rare = ItemRarityID.Lime;
			Item.useAnimation = 20;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.UseSound = SoundID.ForceRoar;
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