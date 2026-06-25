using ReducedGrinding.Configuration;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Items.Material
{
    internal static class Helpers
    {
        internal static bool MaterialIsNeeded(int item)
        {
            BobberPotionConfig bobberPotionConfig = GetInstance<BobberPotionConfig>();
            TimeAndWeatherConfig timeAndWeatherConfig = GetInstance<TimeAndWeatherConfig>();

            return bobberPotionConfig.BobberPotionIngredient.Type == item
                || bobberPotionConfig.BobberPotionAlternateIngredient.Type == item
                || bobberPotionConfig.GreaterBobberPotionIngredient.Type == item
                || bobberPotionConfig.GreaterBobberPotionAlternateIngredient.Type == item
                || bobberPotionConfig.SuperBobberPotionIngredient.Type == item
                || bobberPotionConfig.SuperBobberPotionAlternateIngredient.Type == item
                || timeAndWeatherConfig.MoonWatchMaterial.Type == item
                || timeAndWeatherConfig.MoonWatchAlternateMaterial.Type == item
                || timeAndWeatherConfig.ItemShimmeredForRain.Type == item
                || timeAndWeatherConfig.ItemShimmeredForWind.Type == item;
        }
    }
}