using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration.DropDownBoxes
{
    public class BobberPotions
    {
        [Header("MultiBobberPotions")]

        [BackgroundColor(128, 128, 128)]
        [Range(0, 100)]
        public int MultiBobberPotionBonus;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 100)]
        public int GreaterMultiBobberPotionBonus;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 100)]
        public int SuperMultiBobberPotionBonus;

        public BobberPotions()
        {
            MultiBobberPotionBonus = 0;
            GreaterMultiBobberPotionBonus = 0;
            SuperMultiBobberPotionBonus = 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is BobberPotions other)
                return MultiBobberPotionBonus == other.MultiBobberPotionBonus &&
                    GreaterMultiBobberPotionBonus == other.GreaterMultiBobberPotionBonus &&
                    SuperMultiBobberPotionBonus == other.SuperMultiBobberPotionBonus;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new
            {
                MultiBobberPotionBonus,
                GreaterMultiBobberPotionBonus,
                SuperMultiBobberPotionBonus
            }.GetHashCode();
        }
    }
}
