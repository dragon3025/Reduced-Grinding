using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration
{
    public class AnglerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(true)]
        public bool UnlimitedAnglerQuest { get; set; }

        [DefaultValue(true)]
        public bool AnglerTellsQuestCompleted { get; set; }

        [DefaultValue(true)]
        public bool AnglerChatsCurrentQuest { get; set; }

        [Header("ExtraQuestRewardModifying")]

        [DefaultValue(0.9f)]
        [Increment(0.01f)]
        public float LowQualityRemovalChance
        {
            get;
            set
            {
                value = (float)Math.Round(value, 2);
                field = value;
            }
        }

        [DefaultValue(0.1f)]
        [Increment(0.01f)]
        public float CoinMultiplier
        {
            get;
            set
            {
                value = (float)Math.Round(value, 2);
                field = value;
            }
        }

        [Header("HoneyRewards")]

        [DefaultValue(true)]
        public bool AnglerChatsBumbleBeeTuna { get; set; }

        [DefaultValue(true)]
        public bool ShimmerHoneyRewards { get; set; }

        [DefaultValue(0f)]
        [BackgroundColor(128, 128, 128)]
        [Increment(0.01f)]
        public float BumblebeeTunaSwapChance
        {
            get;
            set
            {
                value = (float)Math.Round(value, 2);
                field = value;
            }
        }
    }
}
