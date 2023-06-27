using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration.DropDownBoxes
{
    public class TravelingMerchant
    {
        public bool TravelingMerchantChatsItems;

        [Header("MerchantDice")]

        [BackgroundColor(128, 128, 128)]
        [Range(0, 100)]
        public int TravelingMerchantDiceUsesBeforeHardmode;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 100)]
        public int TravelingMerchantDiceUsesHardmode;

        [BackgroundColor(128, 128, 128)]
        [Range(0, 100)]
        public int TravelingMerchantDiceUsesAfterPlantera;

        public TravelingMerchant()
        {
            TravelingMerchantChatsItems = true;
            TravelingMerchantDiceUsesBeforeHardmode = 0;
            TravelingMerchantDiceUsesHardmode = 0;
            TravelingMerchantDiceUsesAfterPlantera = 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is TravelingMerchant other)
                return TravelingMerchantChatsItems == other.TravelingMerchantChatsItems &&
                    TravelingMerchantDiceUsesBeforeHardmode == other.TravelingMerchantDiceUsesBeforeHardmode &&
                    TravelingMerchantDiceUsesHardmode == other.TravelingMerchantDiceUsesHardmode &&
                    TravelingMerchantDiceUsesAfterPlantera == other.TravelingMerchantDiceUsesAfterPlantera;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new
            {
                TravelingMerchantChatsItems,
                TravelingMerchantDiceUsesBeforeHardmode,
                TravelingMerchantDiceUsesHardmode,
                TravelingMerchantDiceUsesAfterPlantera
            }.GetHashCode();
        }
    }
}
