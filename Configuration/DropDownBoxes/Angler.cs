using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration.DropDownBoxes
{
    public class Angler
    {
        public bool AnglerTellsQuestCompleted;

        [Header("QuestPerDay")]

        [BackgroundColor(128, 128, 128)]
        [Range(1, 1000)]
        public int StartingQuestPerDay;

        [Range(1, 1000)]
        public int EndGameQuestPerDay;

        public Angler()
        {
            AnglerTellsQuestCompleted = true;
            StartingQuestPerDay = 1;
            EndGameQuestPerDay = 10;
        }

        public override bool Equals(object obj)
        {
            if (obj is Angler other)
                return AnglerTellsQuestCompleted == other.AnglerTellsQuestCompleted &&
                    StartingQuestPerDay == other.StartingQuestPerDay &&
                    EndGameQuestPerDay == other.EndGameQuestPerDay;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new
            {
                AnglerTellsQuestCompleted,
                StartingQuestPerDay,
                EndGameQuestPerDay
            }.GetHashCode();
        }
    }
}
