using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Buffs
{
    public class GreaterMultiBobber : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Greater Multi-Bobber Potion");
            Description.SetDefault("Increases bobber amount by " + GetInstance<CFishingConfig>().GreaterMultiBobberPotionBonus.ToString() + " bobbers when fishing");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.ClearBuff(ModContent.BuffType<MultiBobber>());
        }
    }
}