using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration.DropDownBoxes
{
    public class Angler
    {
        public bool UnlimitedAnglerQuest;
        
        public bool AnglerTellsQuestCompleted;

        public bool AnglerChatsCurrentQuest;

        [Increment(0.1f)]
        public float ExtraQuestRewardChance;

        [Increment(0.01f)]
        public float BumblebeeTunaSwapChance;

        public Angler()
        {
            UnlimitedAnglerQuest = true;
            AnglerTellsQuestCompleted = true;
            AnglerChatsCurrentQuest = true;
            ExtraQuestRewardChance = 0.5f;
            BumblebeeTunaSwapChance = 0.1f;
        }

        public override bool Equals(object obj)
        {
            if (obj is Angler other)
                return UnlimitedAnglerQuest == other.UnlimitedAnglerQuest &&
                    AnglerTellsQuestCompleted == other.AnglerTellsQuestCompleted &&
                    AnglerChatsCurrentQuest == other.AnglerChatsCurrentQuest &&
                    ExtraQuestRewardChance == other.ExtraQuestRewardChance &&
                    BumblebeeTunaSwapChance == other.BumblebeeTunaSwapChance;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new
            {
                UnlimitedAnglerQuest,
                AnglerTellsQuestCompleted,
                AnglerChatsCurrentQuest,
                ExtraQuestRewardChance,
                BumblebeeTunaSwapChance
            }.GetHashCode();
        }
    }
}
