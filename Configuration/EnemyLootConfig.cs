using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration
{
    public enum GuaranteedBiomeKeyBehaviorEnums
    {
        GiveOneTime,
        GiveMultipleTimes,
        GiveMultipleTimesDisableVanilla,
    }

    public class EnemyLootConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Main")]

        [ReloadRequired]
        [Range(8, 23)]
        [DefaultValue(16)]
        public int MaxBeetleHuskInNormal { get; set; }

        [ReloadRequired]
        [Range(1, 10)]
        [DefaultValue(5)]
        public int FishronWings { get; set; }

        [ReloadRequired]
        [Range(1, 10)]
        [DefaultValue(5)]
        public int EmpressWings { get; set; }

        [ReloadRequired]
        [Range(1, 20)]
        [DefaultValue(5)]
        public int StellarTune { get; set; }

        [ReloadRequired]
        [Range(1, 20)]
        [DefaultValue(3)]
        public int RainbowCursor { get; set; }

        [ReloadRequired]
        [Range(1, 4)]
        [DefaultValue(1)]
        public int PrismaticDye { get; set; }

        [BackgroundColor(128, 128, 128)]
        [ReloadRequired]
        [Range(1, 30)]
        [DefaultValue(30)]
        public int SlimeStaffFromKingSlime { get; set; }

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [Range(1, 30)]
        [DefaultValue(30)]
        public int Binoculars { get; set; }

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [Range(1, 50)]
        [DefaultValue(50)]
        public int CoinGun { get; set; }

        [Header("Surface")]

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [Range(1, 3)]
        [DefaultValue(3)]
        public int Lens { get; set; }

        [Header("Cavern")]

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [Range(1, 150)]
        [DefaultValue(150)]
        public int BeamSword { get; set; }

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [Range(1, 200)]
        [DefaultValue(200)]
        public int Marrow { get; set; }

        [Header("CorruptionAndCrimson")]

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [Range(1, 3)]
        [DefaultValue(3)]
        public int RottenChunkAndVertebra { get; set; }

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [Range(1, 5)]
        [DefaultValue(5)]
        public int SoulOfLightAndNight { get; set; }

        [Header("Dungeon")]

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [Range(1, 15)]
        [DefaultValue(15)]
        public int PaladinsHammer { get; set; }

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [Range(1, 10)]
        [DefaultValue(10)]
        public int PaladinsShield { get; set; }

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [Range(1, 12)]
        [DefaultValue(12)]
        public int RifleScopeAndSniperRifle { get; set; }

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [Range(1, 18)]
        [DefaultValue(18)]
        public int RocketLauncher { get; set; }

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [Range(1, 12)]
        [DefaultValue(12)]
        public int SWATHelmetAndTacticalShotgun { get; set; }

        [Header("Underworld")]

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [Range(1, 20)]
        [DefaultValue(20)]
        public int ObsidianRose { get; set; }

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [Range(1, 250)]
        [DefaultValue(250)]
        public int PlumbersHat { get; set; }

        [Header("Hallow")]

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [Range(1, 400)]
        [DefaultValue(400)]
        public int RodofDiscord { get; set; }

        [Header("JungleTemple")]

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [Range(1, 1000)]
        [DefaultValue(1000)]
        public int LizardEgg { get; set; }

        [Header("Holiday")]

        [ReloadRequired]
        [Range(1, 80)]
        [DefaultValue(18)]
        public int GoodieBag { get; set; }

        [ReloadRequired]
        [Range(1, 1000)]
        [DefaultValue(9)]
        public int GoodieBagMultiplierAfterPlantera { get; set; }

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [Range(1, 13)]
        [DefaultValue(13)]
        public int Present { get; set; }

        [Range(1, 1000)]
        [DefaultValue(4)]
        public int PresentMultiplierAfterPlantera { get; set; }

        [Header("OtherVanilla")]

        [ReloadRequired]
        [Range(1, 2500)]
        [DefaultValue(1000)]
        public int BiomeKey { get; set; }

        [ReloadRequired]
        [Range(0, 2500)]
        [DefaultValue(1000)]
        public int GuaranteedBiomeKey { get; set; }

        [ReloadRequired]
        [DefaultValue(GuaranteedBiomeKeyBehaviorEnums.GiveOneTime)]
        public GuaranteedBiomeKeyBehaviorEnums GuaranteedBiomeKeyBehavior { get; set; }

        [ReloadRequired]
        [Range(1, 70)]
        [BackgroundColor(128, 128, 128)]
        [DefaultValue(70)]
        public int SlimeStaffFromPinky { get; set; }

        [ReloadRequired]
        [BackgroundColor(128, 128, 128)]
        [Range(1, 8)]
        [DefaultValue(8)]
        public int TownNPCWeapons { get; set; }

        public EnemyLootConfig()
        {
        }
    }
}
