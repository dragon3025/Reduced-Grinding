using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.GlobalFasterBossSummons
{
    public class PriceModification : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (!GetInstance<IOtherConfig>().AdjustItemValuesForDropIncreases)
                return;
            void FindNewValue(float oldChance, int newChance)
            {
                if (newChance > 0)
                {
                    float chanceChange = 1f;
                    chanceChange = oldChance / (oldChance + (1f / newChance));
                    if (item.value > 5)
                        item.value = Math.Max(5, (int)(item.value * chanceChange));
                }
            }

            if (item.type == ItemID.Binoculars)
                FindNewValue(1f / 30f, GetInstance<AEnemyLootConfig>().BinocularsIncrease);

            if (item.type == ItemID.FishronWings || item.type == ItemID.RainbowWings)
                FindNewValue(0.1f, GetInstance<AEnemyLootConfig>().EmpressAndFishronWingsIncrease);

            if (item.type == ItemID.SparkleGuitar)
                FindNewValue(0.05f, GetInstance<AEnemyLootConfig>().StellarTuneIncrease);

            if (item.type == ItemID.RainbowCursor)
                FindNewValue(0.05f, GetInstance<AEnemyLootConfig>().RainbowCursor);

            if (item.type == ItemID.DyeTradersScimitar || item.type == ItemID.StylistKilLaKillScissorsIWish || item.type == ItemID.CombatWrench || item.type == ItemID.TaxCollectorsStickOfDoom || item.type == ItemID.PrincessWeapon)
                FindNewValue(0.125f, GetInstance<AEnemyLootConfig>().TownNPCWeapons);

            if (item.type == ItemID.AleThrowingGlove)
                FindNewValue(1f / 6f, GetInstance<AEnemyLootConfig>().TownNPCWeapons);

            if (item.type == ItemID.PainterPaintballGun)
                FindNewValue(0.1f, GetInstance<AEnemyLootConfig>().TownNPCWeapons);

            if (item.type == ItemID.PiranhaGun || item.type == ItemID.ScourgeoftheCorruptor || item.type == ItemID.VampireKnives || item.type == ItemID.RainbowGun || item.type == ItemID.StaffoftheFrostHydra || item.type == ItemID.StormTigerStaff)
                FindNewValue(0.0004f, GetInstance<AEnemyLootConfig>().BiomeKeyIncrease);

            if (item.type == ItemID.BeamSword)
                FindNewValue(1f / 150f, GetInstance<AEnemyLootConfig>().BeamSwordIncrease);

            if (item.type == ItemID.BloodyMachete || item.type == ItemID.BladedGlove)
                FindNewValue(0.0005f, GetInstance<AEnemyLootConfig>().BloodyMacheteAndBladedGloveIncrease);

            int[] goodieBagItems = new int[]
            {
                1746,
                1747,
                1748,
                1749,
                1750,
                1751,
                1752,
                1753,
                1754,
                1755,
                1756,
                1757,
                1758,
                1759,
                1760,
                1761,
                1762,
                1763,
                1764,
                1765,
                1766,
                1767,
                1768,
                1769,
                1770,
                1771,
                1772,
                1773,
                1774,
                1775,
                1776,
                1777,
                1778,
                1779,
                1780,
                1781,
                1800,
                1809,
                1810,
                1819,
                1820,
                1821,
                1822,
                1823,
                1824,
                1838,
                1839,
                1840,
                1841,
                1842,
                1843,
                1847,
                1848,
                1849,
                1850,
                1851,
                1852
            };
            foreach (int i in goodieBagItems)
                if (item.type == i)
                    FindNewValue(0.0125f, GetInstance<AEnemyLootConfig>().GoodieBagIncrease);

            if (item.type == ItemID.KOCannon)
                FindNewValue(0.001f, GetInstance<AEnemyLootConfig>().KOCannonIncrease);

            if (item.type == ItemID.LizardEgg)
                FindNewValue(0.001f, GetInstance<AEnemyLootConfig>().LizardEggIncrease);

            if (item.type == ItemID.Marrow)
                FindNewValue(0.005f, GetInstance<AEnemyLootConfig>().MarrowIncrease);

            if (item.type == ItemID.PaladinsHammer)
                FindNewValue(22f / 225f, GetInstance<AEnemyLootConfig>().PaladinsHammerIncrease);

            if (item.type == ItemID.PaladinsShield)
                FindNewValue(763f / 5625f, GetInstance<AEnemyLootConfig>().PaladinsShieldIncrease);

            if (item.type == ItemID.PlumbersHat)
                FindNewValue(0.004f, GetInstance<AEnemyLootConfig>().PlumbersHatIncrease);

            int[] presentItems = new int[]
            {
                586,
                591,
                602,
                1870,
                1872,
                1909,
                1911,
                1912,
                1913,
                1915,
                1917,
                1918,
                1919,
                1920,
                1921,
                1922,
                1923,
                1907,
                1908,
                1927,
                1932,
                1933,
                1934,
                1935,
                1936,
                1937,
                1938,
                1939,
                1940,
                1941,
                1942
            };
            foreach (int i in presentItems)
                if (item.type == i)
                    FindNewValue(1f / 13f, GetInstance<AEnemyLootConfig>().PresentIncrease);

            if (item.type == ItemID.RifleScope || item.type == ItemID.SniperRifle)
                FindNewValue(23f / 144f, GetInstance<AEnemyLootConfig>().RifleScopeAndSniperRifleIncrease);

            if (item.type == ItemID.RocketLauncher)
                FindNewValue(35f / 324f, GetInstance<AEnemyLootConfig>().RocketLauncherIncrease);

            if (item.type == ItemID.RodofDiscord)
                FindNewValue(0.0025f, GetInstance<AEnemyLootConfig>().RodofDiscordIncrease);

            if (item.type == ItemID.SWATHelmet || item.type == ItemID.TacticalShotgun)
                FindNewValue(23f / 144f, GetInstance<AEnemyLootConfig>().SWATHelmetAndTacticalShotgunIncrease);

            if (item.type == ItemID.CoinGun)
                FindNewValue(0.0025f, GetInstance<AEnemyLootConfig>().CoinGunBaseIncrease);

            if (item.type == ItemID.SlimeStaff)
            {
                float chanceChangeOther = 1f;
                float chanceChangePinky = 1f;
                float chanceChangeSand = 1f;

                float chanceOther = GetInstance<AEnemyLootConfig>().SlimeStaffFromOtherSlimesIncrease;
                float chancePinky = GetInstance<AEnemyLootConfig>().SlimeStaffFromPinkyIncrease;
                float chanceSand = GetInstance<AEnemyLootConfig>().SlimeStaffFromSandSlimeIncrease;

                if (chanceOther > 0)
                    chanceChangeOther = 1f / 7000f / ((1f / 7000f) + (1f / chanceOther));
                if (chancePinky > 0)
                    chanceChangePinky = 1f / 7000f / ((1f / 7000f) + (1f / chancePinky));
                if (chanceSand > 0)
                    chanceChangeSand = 1f / 7000f / ((1f / 7000f) + (1f / chanceSand));

                float chanceChangeAverage = (chanceChangeOther + chanceChangePinky + chanceChangeSand) / 3f;

                item.value = (int)(item.value * chanceChangeAverage);
            }
        }
    }
}
