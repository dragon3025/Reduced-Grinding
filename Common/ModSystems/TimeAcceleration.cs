using ReducedGrinding.Configuration;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.ModSystems
{
    public class TimeAcceleration : ModSystem
    {
        private static readonly TimeAndWeatherConfig timeAndWeatherConfig = GetInstance<TimeAndWeatherConfig>();

        public override void ModifyTimeRate(ref double timeRate, ref double tileUpdateRate, ref double eventUpdateRate)
        {
            float rateMultiplier = 1f;
            if (timeAndWeatherConfig.EnchantedDialMultiplier > 1f && Main.IsFastForwardingTime())
            {
                rateMultiplier *= timeAndWeatherConfig.EnchantedDialMultiplier;
            }

            if (!CreativePowerManager.Instance.GetPower<CreativePowers.FreezeTime>().Enabled &&
                Main.CurrentFrameFlags.SleepingPlayersCount == Main.CurrentFrameFlags.ActivePlayersCount &&
                Main.CurrentFrameFlags.SleepingPlayersCount > 0)
            {
                if (timeAndWeatherConfig.SleepRateMultiplier >= 1f)
                {
                    rateMultiplier *= timeAndWeatherConfig.SleepRateMultiplier;
                }
            }

            if (rateMultiplier > 1f)
            {
                timeRate *= rateMultiplier;
                tileUpdateRate *= rateMultiplier;
                eventUpdateRate *= rateMultiplier;
            }
        }

        public override void PostUpdateTime()
        {
            int cooldownMax = timeAndWeatherConfig.EnchantedDialCooldown;

            if (Main.IsFastForwardingTime())
            {
                cooldownMax++;
            }
            if (Main.sundialCooldown > cooldownMax)
            {
                Main.sundialCooldown = cooldownMax;
            }
            if (Main.moondialCooldown > cooldownMax)
            {
                Main.moondialCooldown = cooldownMax;
            }
        }
    }
}
