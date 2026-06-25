using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration
{
    public class TravelingMerchantConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(true)]
        public bool TravelingMerchantChatsItems { get; set; }

        [Header("MerchantDice")]

        [BackgroundColor(128, 128, 128)]
        [Slider]
        [Range(0, 100)]
        [DefaultValue(0)]
        public int MerchantDiceUsesPreHardmode
        {
            get
            {
                field = Math.Min(
                    field,
                    Math.Min(MerchantDicePostHardmode,
                    Math.Min(MerchantDiceUsesPostMechBosses,
                    Math.Min(MerchantDiceUsesPostPlantera,
                    MerchantDiceUsesPostMoonlord
                    ))));
                return field;
            }
            set
            {
                MerchantDicePostHardmode = Math.Max(value, MerchantDicePostHardmode);
                MerchantDiceUsesPostMechBosses = Math.Max(MerchantDicePostHardmode, MerchantDiceUsesPostMechBosses);
                MerchantDiceUsesPostPlantera = Math.Max(MerchantDiceUsesPostMechBosses, MerchantDiceUsesPostPlantera);
                MerchantDiceUsesPostMoonlord = Math.Max(MerchantDiceUsesPostPlantera, MerchantDiceUsesPostMoonlord);
                field = value;
            }
        }

        [BackgroundColor(128, 128, 128)]
        [Slider]
        [Range(0, 100)]
        [DefaultValue(0)]
        public int MerchantDicePostHardmode
        {
            get
            {
                field = Math.Min(
                    field,
                    Math.Min(MerchantDiceUsesPostMechBosses,
                    Math.Min(MerchantDiceUsesPostPlantera,
                    MerchantDiceUsesPostMoonlord
                    )));
                return field;
            }
            set
            {
                MerchantDiceUsesPostMechBosses = Math.Max(value, MerchantDiceUsesPostMechBosses);
                MerchantDiceUsesPostPlantera = Math.Max(MerchantDiceUsesPostMechBosses, MerchantDiceUsesPostPlantera);
                MerchantDiceUsesPostMoonlord = Math.Max(MerchantDiceUsesPostPlantera, MerchantDiceUsesPostMoonlord);
                field = value;
            }
        }

        [Slider]
        [Range(0, 100)]
        [DefaultValue(3)]
        public int MerchantDiceUsesPostMechBosses
        {
            get
            {
                field = Math.Min(
                    field,
                    Math.Min(MerchantDiceUsesPostPlantera,
                    MerchantDiceUsesPostMoonlord
                    ));
                return field;
            }
            set
            {
                MerchantDiceUsesPostPlantera = Math.Max(value, MerchantDiceUsesPostPlantera);
                MerchantDiceUsesPostMoonlord = Math.Max(MerchantDiceUsesPostPlantera, MerchantDiceUsesPostMoonlord);
                field = value;
            }
        }

        [Slider]
        [Range(0, 100)]
        [DefaultValue(3)]
        public int MerchantDiceUsesPostPlantera
        {
            get
            {
                field = Math.Min(
                    field,
                    MerchantDiceUsesPostMoonlord
                    );
                return field;
            }
            set
            {
                MerchantDiceUsesPostMoonlord = Math.Max(value, MerchantDiceUsesPostMoonlord);
                field = value;
            }
        }

        [Slider]
        [Range(0, 100)]
        [DefaultValue(10)]
        public int MerchantDiceUsesPostMoonlord { get; set; }
    }
}
