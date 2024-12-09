using ReducedGrinding.Configuration;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.GlobalFasterBossSummons
{
    public class ValueModification : GlobalItem
    {
        readonly static AEnemyLootConfig lootConfig = GetInstance<AEnemyLootConfig>();

        public override void SetDefaults(Item item)
        {
            if (!GetInstance<IOtherConfig>().AdjustItemValuesForDropIncreases)
            {
                return;
            }

            void FindNewValue(float oldChance, int newChance)
            {
                if (newChance > 0)
                {
                    item.value = (int)(item.value * oldChance / newChance);
                }
            }

            if (item.type == ItemID.Binoculars)
            {
                FindNewValue(1f / 30, lootConfig.BossLoot.Binoculars);
            }

            if (item.type == ItemID.FishronWings || item.type == ItemID.RainbowWings)
            {
                FindNewValue(0.1f, lootConfig.BossLoot.EmpressAndFishronWings);
            }

            if (item.type == ItemID.SparkleGuitar)
            {
                FindNewValue(0.05f, lootConfig.BossLoot.StellarTune);
            }

            if (item.type == ItemID.RainbowCursor)
            {
                FindNewValue(0.05f, lootConfig.BossLoot.RainbowCursor);
            }

            if (item.type == ItemID.HallowBossDye)
            {
                item.value = item.value / 12; //Rate increased from 25% to 100% and drop amount increased from 1 to 3.
            }

            if (item.type == ItemID.DyeTradersScimitar || item.type == ItemID.StylistKilLaKillScissorsIWish || item.type == ItemID.CombatWrench || item.type == ItemID.TaxCollectorsStickOfDoom || item.type == ItemID.PrincessWeapon)
            {
                FindNewValue(0.125f, lootConfig.NonBossLoot.TownNPCWeapons);
            }

            if (item.type == ItemID.AleThrowingGlove)
            {
                FindNewValue(1f / 6, lootConfig.NonBossLoot.TownNPCWeapons);
            }

            if (item.type == ItemID.PainterPaintballGun)
            {
                FindNewValue(0.1f, lootConfig.NonBossLoot.TownNPCWeapons);
            }

            if (item.type == ItemID.PartyGirlGrenade)
            {
                FindNewValue(0.25f, lootConfig.NonBossLoot.TownNPCWeapons);
            }

            if (item.type == ItemID.PiranhaGun || item.type == ItemID.ScourgeoftheCorruptor || item.type == ItemID.VampireKnives || item.type == ItemID.RainbowGun || item.type == ItemID.StaffoftheFrostHydra || item.type == ItemID.StormTigerStaff)
            {
                FindNewValue(0.0004f, lootConfig.NonBossLoot.BiomeKey);
            }

            if (item.type == ItemID.BeamSword)
            {
                FindNewValue(1f / 150, lootConfig.NonBossLoot.BeamSword);
            }

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
            {
                if (item.type == i)
                {
                    FindNewValue(0.0125f, lootConfig.NonBossLoot.GoodieBag);
                }
            }

            if (item.type == ItemID.KOCannon)
            {
                FindNewValue(0.001f, lootConfig.NonBossLoot.KOCannon);
            }

            if (item.type == ItemID.LizardEgg)
            {
                FindNewValue(0.001f, lootConfig.NonBossLoot.LizardEgg);
            }

            if (item.type == ItemID.Marrow)
            {
                FindNewValue(0.005f, lootConfig.NonBossLoot.Marrow);
            }

            if (item.type == ItemID.ObsidianRose)
            {
                FindNewValue(0.005f, lootConfig.NonBossLoot.ObsidianRose);
            }

            if (item.type == ItemID.PaladinsHammer)
            {
                FindNewValue(22f / 225, lootConfig.NonBossLoot.PaladinsHammer);
            }

            if (item.type == ItemID.PaladinsShield)
            {
                FindNewValue(763f / 5625, lootConfig.NonBossLoot.PaladinsShield);
            }

            if (item.type == ItemID.PlumbersHat)
            {
                FindNewValue(0.004f, lootConfig.NonBossLoot.PlumbersHat);
            }

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
            {
                if (item.type == i)
                {
                    FindNewValue(1f / 13, lootConfig.NonBossLoot.Present);
                }
            }

            if (item.type == ItemID.RifleScope || item.type == ItemID.SniperRifle)
            {
                FindNewValue(23f / 144, lootConfig.NonBossLoot.RifleScopeAndSniperRifle);
            }

            if (item.type == ItemID.RocketLauncher)
            {
                FindNewValue(35f / 324, lootConfig.NonBossLoot.RocketLauncher);
            }

            if (item.type == ItemID.RodofDiscord || item.type == ItemID.RodOfHarmony)
            {
                FindNewValue(0.0025f, lootConfig.NonBossLoot.RodofDiscord);
            }

            if (item.type == ItemID.SWATHelmet || item.type == ItemID.TacticalShotgun)
            {
                FindNewValue(23f / 144, lootConfig.NonBossLoot.SWATHelmetAndTacticalShotgun);
            }

            if (item.type == ItemID.CoinGun)
            {
                FindNewValue(0.0025f, lootConfig.BossLoot.CoinGun);
            }

            if (item.type == ItemID.SlimeStaff)
            {
                float chanceChangePinky = 1f;
                float chanceChangeSand = 1f;
                float chanceChangeOther = 1f;

                float chancePinky = lootConfig.NonBossLoot.SlimeStaffFromPinky;
                float chanceSand = lootConfig.NonBossLoot.SlimeStaffFromSandSlime;
                float chanceOther = lootConfig.NonBossLoot.SlimeStaffFromOtherSlimes;

                if (chancePinky > 0)
                {
                    chanceChangePinky = 1f / 70 / (1f / chancePinky);
                }

                if (chanceSand > 0)
                {
                    chanceChangeSand = 1f / 5600 / (1f / chanceSand);
                }

                if (chanceOther > 0)
                {
                    chanceChangeOther = 1f / 7000 / (1f / chanceOther);
                }

                float chanceChange = Math.Min(chanceChangePinky, Math.Min(chanceChangeSand, chanceChangeOther));

                item.value = (int)(item.value * chanceChange);
            }

            if (item.type == ItemID.GreenCap)
            {
                FindNewValue(1f / 36f, 1);
            }

            if (item.type == ItemID.IvyGuitar)
            {
                FindNewValue(1f / 20f, 1);
            }
        }
    }
}
