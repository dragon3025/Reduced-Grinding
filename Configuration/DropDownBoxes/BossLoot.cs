using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration.DropDownBoxes
{
    public class BossLoot
    {
        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int Binoculars;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CoinGun;

        [Range(0, 10000)]
        [DefaultValue(5)]
        public int EmpressAndFishronWings;

        [Range(0, 10000)]
        [DefaultValue(5)]
        public int StellarTune;

        [Range(0, 10000)]
        [DefaultValue(3)]
        public int RainbowCursor;

        public BossLoot()
        {
            EmpressAndFishronWings = 5;
            StellarTune = 5;
            RainbowCursor = 3;
        }

        public override bool Equals(object obj)
        {
            if (obj is BossLoot other)
                return Binoculars == other.Binoculars &&
                    CoinGun == other.CoinGun &&
                    EmpressAndFishronWings == other.EmpressAndFishronWings &&
                    StellarTune == other.StellarTune &&
                    RainbowCursor == other.RainbowCursor;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new
            {
                CoinGun,
                EmpressAndFishronWings,
                StellarTune,
                RainbowCursor
            }.GetHashCode();
        }
    }
}
