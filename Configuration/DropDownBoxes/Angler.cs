using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration.DropDownBoxes
{
    public class Angler
    {
        public bool UnlimitedAnglerQuest;

        public bool AnglerTellsQuestCompleted;

        public bool AnglerChatsCurrentQuest;

        [Increment(0.01f)]
        public float BumblebeeTunaSwapChance;

        [Header("ExtraQuestRewardModifying")]

        [Increment(0.01f)]
        public float LowQualityRemovalChance;

        [Increment(0.01f)]
        public float CoinMultiplier;

        public Angler()
        {
            UnlimitedAnglerQuest = true;
            AnglerTellsQuestCompleted = true;
            AnglerChatsCurrentQuest = true;
            BumblebeeTunaSwapChance = 0.1f;
            LowQualityRemovalChance = 0.9f;
            CoinMultiplier = 0.1f;
        }

        public override bool Equals(object obj)
        {
            if (obj is Angler other)
                return UnlimitedAnglerQuest == other.UnlimitedAnglerQuest &&
                    AnglerTellsQuestCompleted == other.AnglerTellsQuestCompleted &&
                    AnglerChatsCurrentQuest == other.AnglerChatsCurrentQuest &&
                    BumblebeeTunaSwapChance == other.BumblebeeTunaSwapChance &&
                    LowQualityRemovalChance == other.LowQualityRemovalChance &&
                    CoinMultiplier == other.CoinMultiplier;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new
            {
                UnlimitedAnglerQuest,
                AnglerTellsQuestCompleted,
                AnglerChatsCurrentQuest,
                BumblebeeTunaSwapChance,
                LowQualityRemovalChance,
                CoinMultiplier
            }.GetHashCode();
        }
    }
}
