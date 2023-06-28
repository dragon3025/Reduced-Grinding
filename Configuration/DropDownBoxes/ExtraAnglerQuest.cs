using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration.DropDownBoxes
{
    public class ExtraAnglerQuest
    {
        [Header("ExtraAnglerQuest")]

        [BackgroundColor(128, 128, 128)]
        [Range(1, 10000)]
        [DefaultValue(1)]
        public int PreHardmodeBossBonus;

        [Range(1, 10000)]
        [DefaultValue(2)]
        public int HardmodeBonus;

        [Range(1, 10000)]
        [DefaultValue(3)]
        public int QueenSlimeAndMechBossBonus;

        [Range(1, 10000)]
        [DefaultValue(6)]
        public int LateGameBossBonus;

        https://docs.google.com/spreadsheets/d/1vtPzYSjFzGhmv1qJ6y_PYarkG0liGT9VIgeU5DDQgqI/edit#gid=0

        https://docs.google.com/document/d/190-gwv4Jr29LnrFgj5MVObOoZuOARsY3RWt0IDRrVlE/edit

        https://terraria.wiki.gg/wiki/NPCs#Stat_boosts

        [Range(1, 10000)]
        [DefaultValue(10)]
        public int QuestCountHardmode;

        [Range(1, 10000)]
        [DefaultValue(10)]
        public int QuestCountAfterPlantera;

        public ExtraAnglerQuest()
        {
            QuestCountBeforeEye = 0;
            QuestCountAfterEye = 0;
            QuestCountAfterInfectionBoss = 0;
            QuestCountAfterSkeletron = 0;
            QuestCountHardmode = 0;
            QuestCountAfterPlantera = 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is ExtraAnglerQuest other)
                return QuestCountBeforeEye == other.QuestCountBeforeEye &&
                    QuestCountAfterEye == other.QuestCountAfterEye &&
                    QuestCountAfterInfectionBoss == other.QuestCountAfterInfectionBoss &&
                    QuestCountAfterSkeletron == other.QuestCountAfterSkeletron &&
                    QuestCountHardmode == other.QuestCountHardmode &&
                    QuestCountAfterPlantera == other.QuestCountAfterPlantera;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new
            {
                QuestCountBeforeEye,
                QuestCountAfterEye,
                QuestCountAfterInfectionBoss,
                QuestCountAfterSkeletron,
                QuestCountHardmode,
                QuestCountAfterPlantera
            }.GetHashCode();
        }
    }
}
