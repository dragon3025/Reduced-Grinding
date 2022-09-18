using Microsoft.Xna.Framework;
using Terraria.GameContent.UI;

namespace ReducedGrinding.Currencies
{
    public class FishCoinCurrency : CustomCurrencySingleCoin
    {
        public FishCoinCurrency(int coinItemID, long currencyCap, string CurrencyTextKey) : base(coinItemID, currencyCap)
        {
            this.CurrencyTextKey = CurrencyTextKey;
            CurrencyTextColor = Color.Aqua;
        }
    }
}