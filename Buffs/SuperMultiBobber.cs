using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Buffs
{
    public class SuperMultiBobber : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Super Multi-Bobber Potion");
            Description.SetDefault("Increases bobber amount by " + GetInstance<CFishingConfig>().SuperMultiBobberPotionBonus.ToString() + " when fishing");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.ClearBuff(ModContent.BuffType<MultiBobber>());
            player.ClearBuff(ModContent.BuffType<GreaterMultiBobber>());
        }
    }
}