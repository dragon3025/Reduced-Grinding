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
			item.width = 28;
			item.height = 30;
			item.maxStack = 1;
			item.value = 10;
			item.rare = 1;
            item.useAnimation = 20;
            item.useTime = 45;
            item.useStyle = 4;
			item.UseSound = new Terraria.Audio.LegacySoundStyle(SoundID.ZombieMoan, 0);
            item.consumable = false;
		}

        public override bool CanUseItem(Player player)
        {
			bool boneMerchantExists = true;
			for (int i = 0; i < Terraria.Main.npc.Length; i++) //Do once for each NPC in the world
			{
				if (Terraria.Main.npc[i].type == mod.NPCType("BoneMerchant"))
				{
					boneMerchantExists = false;
					break;
				}
			}
			return boneMerchantExists;
		}

        public override bool UseItem(Player player)
        {
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("BoneMerchant"));
			return true;
		}
	}
}