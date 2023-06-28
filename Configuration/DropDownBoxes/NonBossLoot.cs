using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration.DropDownBoxes
{
    public class NonBossLoot
    {
        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int TownNPCWeapons;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int BiomeKey;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int BeamSword;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int GoodieBag;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int KOCannon;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int Lens;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int LizardEgg;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int Marrow;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int PaladinsHammer;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int PaladinsShield;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int PlumbersHat;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int Present;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int RifleScopeAndSniperRifle;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int RocketLauncher;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int RodofDiscord;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int RottenChunkAndVertebra;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int SoulOfLightAndNight;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 10000)]
        public int SWATHelmetAndTacticalShotgun;

        [Header("SlimeStaff")]

        [Range(0, 10000)]
        public int SlimeStaffFromPinky;

        [Range(0, 10000)]
        public int SlimeStaffFromSandSlime;

        [Range(0, 10000)]
        public int SlimeStaffFromOtherSlimes;

        public NonBossLoot()
        {
            SlimeStaffFromPinky = 5;
            SlimeStaffFromSandSlime = 75;
            SlimeStaffFromOtherSlimes = 100;
        }

        public override bool Equals(object obj)
        {
            if (obj is NonBossLoot other)
                return TownNPCWeapons == other.TownNPCWeapons &&
                    BiomeKey == other.BiomeKey &&
                    BeamSword == other.BeamSword &&
                    GoodieBag == other.GoodieBag &&
                    KOCannon == other.KOCannon &&
                    Lens == other.Lens &&
                    LizardEgg == other.LizardEgg &&
                    Marrow == other.Marrow &&
                    PaladinsHammer == other.PaladinsHammer &&
                    PaladinsShield == other.PaladinsShield &&
                    PlumbersHat == other.PlumbersHat &&
                    Present == other.Present &&
                    RifleScopeAndSniperRifle == other.RifleScopeAndSniperRifle &&
                    RocketLauncher == other.RocketLauncher &&
                    RodofDiscord == other.RodofDiscord &&
                    RottenChunkAndVertebra == other.RottenChunkAndVertebra &&
                    SoulOfLightAndNight == other.SoulOfLightAndNight &&
                    SWATHelmetAndTacticalShotgun == other.SWATHelmetAndTacticalShotgun &&
                    SlimeStaffFromPinky == other.SlimeStaffFromPinky &&
                    SlimeStaffFromSandSlime == other.SlimeStaffFromSandSlime &&
                    SlimeStaffFromOtherSlimes == other.SlimeStaffFromOtherSlimes;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new
            {
                TownNPCWeapons,
                BiomeKey,
                BeamSword,
                GoodieBag,
                KOCannon,
                Lens,
                LizardEgg,
                Marrow,
                PaladinsHammer,
                PaladinsShield,
                PlumbersHat,
                Present,
                RifleScopeAndSniperRifle,
                RocketLauncher,
                RodofDiscord,
                RottenChunkAndVertebra,
                SoulOfLightAndNight,
                SWATHelmetAndTacticalShotgun,
                SlimeStaffFromPinky,
                SlimeStaffFromSandSlime,
                SlimeStaffFromOtherSlimes
            }.GetHashCode();
        }
    }
}
