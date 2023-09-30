using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration.DropDownBoxes
{
    public class Angler
    {
        public bool AnglerTellsQuestCompleted;

        public bool AnglerChatsCurrentQuest;

        [Header("QuestPerDay")]

        [BackgroundColor(128, 128, 128)]
        [Range(1, 1000)]
        public int StartingQuestPerDay;

        [Range(1, 1000)]
        public int EndGameQuestPerDay;

        [Increment(0.1f)]
        public float ExtraQuestRewardChance;

        public Angler()
        {
            AnglerTellsQuestCompleted = true;
            AnglerChatsCurrentQuest = true;
            StartingQuestPerDay = 1;
            EndGameQuestPerDay = 10;
            ExtraQuestRewardChance = 0.1f;
        }

        public override bool Equals(object obj)
        {
            if (obj is Angler other)
                return AnglerTellsQuestCompleted == other.AnglerTellsQuestCompleted &&
                    AnglerChatsCurrentQuest == other.AnglerChatsCurrentQuest &&
                    StartingQuestPerDay == other.StartingQuestPerDay &&
                    EndGameQuestPerDay == other.EndGameQuestPerDay &&
                    ExtraQuestRewardChance == other.ExtraQuestRewardChance;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new
            {
                AnglerTellsQuestCompleted,
                AnglerChatsCurrentQuest,
                StartingQuestPerDay,
                EndGameQuestPerDay,
                ExtraQuestRewardChance
            }.GetHashCode();
        }
    }
}
