using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Buffs
{
    public class MultiBobber : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Multi-Bobber Potion");
            Description.SetDefault("Increases bobber amount by " + GetInstance<CFishingConfig>().MultiBobberPotionBonus.ToString() + " when fishing");
        }
    }
}