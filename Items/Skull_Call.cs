using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ReducedGrinding.Items
{
	public class Skull_Call : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skull Call");
            Tooltip.SetDefault("A friend of mine would like to live in the overworld. Use this in a safe place when if have an open house for him.");
        }
		
		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 30;
			Item.maxStack = 1;
			Item.value = 10;
			Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 20;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
			Item.UseSound = new Terraria.Audio.LegacySoundStyle(SoundID.ZombieMoan, 0);
            Item.consumable = false;
		}

        public override bool CanUseItem(Player player)
        {
			bool boneMerchantExists = true;
			for (int i = 0; i < Main.npc.Length; i++) //Do once for each NPC in the world
			{
				if (Main.npc[i].type == ModContent.NPCType<NPCs.BoneMerchant>())
				{
					boneMerchantExists = false;
					break;
				}
			}
			return boneMerchantExists;
		}

        public override bool? UseItem(Player player)
        {
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.BoneMerchant>());
			return true;
		}
	}
}