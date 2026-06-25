using ReducedGrinding.Configuration;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalItems
{
    public class ValueModification : GlobalItem
    {
        private static readonly EnemyLootConfig lootConfig = GetInstance<EnemyLootConfig>();
        private static readonly OtherConfig otherConfig = GetInstance<OtherConfig>();
        private static readonly TimeAndWeatherConfig timeAndWeatherConfig = GetInstance<TimeAndWeatherConfig>();

        public override void SetDefaults(Item item)
        {
            if (!GetInstance<OtherConfig>().AdjustItemValuesForDropIncreases)
            {
                return;
            }

            if (!AdjustBossLootValues(item))
            {
                return;
            }
            if (!AdjustTownNPCLootValues(item))
            {
                return;
            }
            if (!AdjustDungeonAndBiomeKeyLootValues(item))
            {
                return;
            }
            if (!AdjustHolidayLootValues(item))
            {
                return;
            }
            if (!AdjustMiscEnemyLootValues(item))
            {
                return;
            }
            if (!AdjustMiscLootValues(item))
            {
                return;
            }
        }

        private static bool AdjustMiscLootValues(Item item)
        {
            switch (item.type)
            {
                case ItemID.Sundial:
                case ItemID.Moondial:
                    FindNewValue(0.05f, timeAndWeatherConfig.CrateEnchantedSundial, item);
                    return false;
                case ItemID.ArchaeologistsHat:
                case ItemID.ArchaeologistsJacket:
                case ItemID.ArchaeologistsPants:
                    item.value *= GetInstance<CraftingConfig>().LeatherPerArchaeologistsPiece / 15;
                    return false;
                case ItemID.AmberMosquito:
                    float oldChance = 0.00027f;
                    float newChance = oldChance + 1f / otherConfig.AmberMosquitoChance;
                    item.value = (int)Math.Round(item.value * oldChance / newChance);
                    FindNewValue(0.00027f, otherConfig.AmberMosquitoChance, item);
                    return false;
                default:
                    return true;
            }
        }

        private static bool AdjustMiscEnemyLootValues(Item item)
        {
            switch (item.type)
            {
                case ItemID.LizardEgg:
                    FindNewValue(0.001f, lootConfig.LizardEgg, item);
                    return false;
                case ItemID.Marrow:
                    FindNewValue(0.005f, lootConfig.Marrow, item);
                    return false;
                case ItemID.BeamSword:
                    FindNewValue(1f / 150, lootConfig.BeamSword, item);
                    return false;
                case ItemID.ObsidianRose:
                    FindNewValue(0.005f, lootConfig.ObsidianRose, item);
                    return false;
                case ItemID.PlumbersHat:
                    FindNewValue(0.004f, lootConfig.PlumbersHat, item);
                    return false;
                case ItemID.RodofDiscord:
                case ItemID.RodOfHarmony:
                    FindNewValue(0.0025f, lootConfig.RodofDiscord, item);
                    return false;
                case ItemID.SlimeStaff:
                    {
                        float pinkyChangeRate = lootConfig.SlimeStaffFromPinky / 70f;
                        float kingChangeRate = lootConfig.SlimeStaffFromKingSlime / 30f;
                        if (pinkyChangeRate < kingChangeRate)
                        {
                            FindNewValue(1f / 70f, lootConfig.SlimeStaffFromPinky, item);
                            return false;
                        }
                        FindNewValue(1f / 30f, lootConfig.SlimeStaffFromKingSlime, item);
                        return false;
                    }
                default:
                    return true;
            }
        }

        private static bool AdjustHolidayLootValues(Item item)
        {
            int[] goodieBagItems =
            [
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
            ];
            if (goodieBagItems.Contains(item.type))
            {
                FindNewValue(0.0125f, lootConfig.GoodieBag, item);
                if (lootConfig.GoodieBagMultiplierAfterPlantera > 1)
                {
                    item.value /= lootConfig.GoodieBagMultiplierAfterPlantera;
                }
                return false;
            }
            int[] presentItems =
            [
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
            ];
            if (presentItems.Contains(item.type))
            {
                FindNewValue(1f / 13, lootConfig.Present, item);
                if (lootConfig.PresentMultiplierAfterPlantera > 1)
                {
                    item.value /= lootConfig.PresentMultiplierAfterPlantera;
                }
                return false;
            }
            return true;
        }

        private static bool AdjustDungeonAndBiomeKeyLootValues(Item item)
        {
            int[] biomeChestItems =
            [
                ItemID.PiranhaGun,
                ItemID.ScourgeoftheCorruptor,
                ItemID.VampireKnives,
                ItemID.RainbowGun,
                ItemID.StaffoftheFrostHydra,
                ItemID.StormTigerStaff,
                ItemID.JungleChest,
                ItemID.CorruptionChest,
                ItemID.CrimsonChest,
                ItemID.HallowedChest,
                ItemID.FrozenChest,
                ItemID.DungeonDesertChest,
            ];
            if (biomeChestItems.Contains(item.type))
            {
                int config = lootConfig.BiomeKey;
                if (lootConfig.GuaranteedBiomeKeyBehavior == GuaranteedBiomeKeyBehaviorEnums.GiveMultipleTimes)
                {
                    config = Math.Min(config, lootConfig.GuaranteedBiomeKey);
                }
                else if (lootConfig.GuaranteedBiomeKeyBehavior == GuaranteedBiomeKeyBehaviorEnums.GiveMultipleTimesDisableVanilla)
                {
                    config = lootConfig.GuaranteedBiomeKey;
                }
                FindNewValue(0.0004f, config, item);
                return false;
            }
            switch (item.type)
            {
                case ItemID.PaladinsHammer:
                    FindNewValue(29f / 225, lootConfig.PaladinsHammer, item);
                    return false;
                case ItemID.PaladinsShield:
                    FindNewValue(0.19f, lootConfig.PaladinsShield, item);
                    return false;
                case ItemID.RifleScope:
                case ItemID.SniperRifle:
                    FindNewValue(23f / 144, lootConfig.RifleScopeAndSniperRifle, item);
                    return false;
                case ItemID.RocketLauncher:
                    FindNewValue(35f / 324, lootConfig.RocketLauncher, item);
                    return false;
                case ItemID.SWATHelmet:
                case ItemID.TacticalShotgun:
                    FindNewValue(23f / 144, lootConfig.SWATHelmetAndTacticalShotgun, item);
                    return false;
                default:
                    return true;
            }
        }

        private static bool AdjustTownNPCLootValues(Item item)
        {
            // In 1.4.5+ Ale Tosser's drop rate changes to 12.5%
            switch (item.type)
            {
                case ItemID.DyeTradersScimitar:
                case ItemID.StylistKilLaKillScissorsIWish:
                case ItemID.CombatWrench:
                case ItemID.TaxCollectorsStickOfDoom:
                case ItemID.PrincessWeapon:
                    FindNewValue(0.125f, lootConfig.TownNPCWeapons, item);
                    return false;
                case ItemID.AleThrowingGlove:
                    FindNewValue(1f / 6, lootConfig.TownNPCWeapons, item);
                    return false;
                case ItemID.PainterPaintballGun:
                    FindNewValue(0.1f, lootConfig.TownNPCWeapons, item);
                    return false;
                case ItemID.PartyGirlGrenade:
                    FindNewValue(0.25f, lootConfig.TownNPCWeapons, item);
                    return false;
                case ItemID.GreenCap:
                case ItemID.IvyGuitar:
                case ItemID.JimsCap:
                    {
                        var correctNameChance = item.type switch
                        {
                            ItemID.GreenCap => 1f / 36f,
                            ItemID.IvyGuitar => 1f / 20f,
                            _ => 1f / 19f,
                        };
                        FindNewValue(correctNameChance, 1, item);
                        return false;
                    }
                default:
                    return true;
            }
        }

        private static bool AdjustBossLootValues(Item item)
        {
            switch (item.type)
            {
                case ItemID.Binoculars:
                    FindNewValue(1f / 30, lootConfig.Binoculars, item);
                    return false;
                case ItemID.FishronWings:
                    FindNewValue(0.1f, lootConfig.FishronWings, item);
                    return false;
                case ItemID.RainbowWings:
                    FindNewValue(0.1f, lootConfig.EmpressWings, item);
                    return false;
                case ItemID.SparkleGuitar:
                    FindNewValue(0.05f, lootConfig.StellarTune, item);
                    return false;
                case ItemID.RainbowCursor:
                    FindNewValue(0.05f, lootConfig.RainbowCursor, item);
                    return false;
                case ItemID.HallowBossDye:
                    FindNewValue(0.05f, lootConfig.PrismaticDye, item);
                    return false;
                case ItemID.CoinGun:
                    FindNewValue(0.02f, lootConfig.CoinGun, item);
                    return false;
                default:
                    return true;
            }
        }

        private static void FindNewValue(float oldChance, int newDenominator, Item item)
        {
            if (newDenominator > 0)
            {
                float newChance = 1f / newDenominator;
                item.value = (int)Math.Round(item.value * oldChance / newChance);
            }
        }
    }
}
