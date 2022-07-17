using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReducedGrinding
{
    [Label("Enemy Loot Vanilla")]
    public class AEnemyLootConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("These are extra item drop chances from enemy loot. Chance = 1 / configuration_setting. Set to 0 to disable.\n\nBoss Loot")]

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.BinocularsIncrease")]
        [Tooltip("If world difficulty is normal, this is multiplied by (4/3)")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int BinocularsIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.EmpressAndFishronWingsIncrease")]
        [Tooltip("" +
            "This sets the same drop rate for each. If the world difficulty is normal, this is\n" +
            "multiplied by (3/2)")]
        [Range(0, 10000)]
        [DefaultValue(7)]
        public int EmpressAndFishronWingsIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.StellarTuneIncrease")]
        [Tooltip("If world difficulty is normal, this is multiplied by (5/2)")]
        [Range(0, 10000)]
        [DefaultValue(4)]
        public int StellarTuneIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.RainbowCursor")]
        [Range(0, 10000)]
        [DefaultValue(4)]
        public int RainbowCursor;

        [Header("Non-Boss Loot")]

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.TownNPCWeapons")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TownNPCWeapons;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.BiomeKeyIncrease")]
        [Tooltip("This sets the same drop rate for each")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int BiomeKeyIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.BeamSwordIncrease")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int BeamSwordIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.BloodyMacheteAndBladedGloveIncrease")]
        [Tooltip("This sets the same drop rate for each")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int BloodyMacheteAndBladedGloveIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.GoodieBagIncrease")]
        [Tooltip("Only drops during Halloween")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int GoodieBagIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.KOCannonIncrease")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int KOCannonIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.LensIncrease")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LensIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.LizardEggIncrease")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LizardEggIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.MarrowIncrease")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int MarrowIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.PaladinsHammerIncrease")]
        [Tooltip("If world difficulty is normal, this is multiplied by 146.67%")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PaladinsHammerIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.PaladinsShieldIncrease")]
        [Tooltip("If world difficulty is normal, this is multiplied by 145.33%")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PaladinsShieldIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.PlumbersHatIncrease")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PlumbersHatIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.PresentIncrease")]
        [Tooltip("Only drops during Christmas")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PresentIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.RifleScopeAndSniperRifleIncrease")]
        [Tooltip("This sets the same drop rate for each. If world difficulty is normal, this is\n" +
            "multiplied by 183.33%")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int RifleScopeAndSniperRifleIncrease;

        [Range(0, 10000)]
        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.RocketLauncherIncrease")]
        [Tooltip("If world difficulty is normal, this is multiplied by 194.44%")]
        [DefaultValue(0)]
        public int RocketLauncherIncrease;

        [Range(0, 10000)]
        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.RodofDiscordIncrease")]
        [Tooltip("If world difficulty is normal, this is multiplied by (5/4)")]
        [DefaultValue(0)]
        public int RodofDiscordIncrease;

        [Range(0, 10000)]
        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.RottenChunkAndVertebra")]
        [Tooltip("This sets the same drop rate for each")]
        [DefaultValue(0)]
        public int RottenChunkAndVertebra;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.SWATHelmetAndTacticalShotgunIncrease")]
        [Tooltip("This sets the same drop rate for each. If world difficulty is normal, this is\n" +
            "multiplied by 191.66%")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int SWATHelmetAndTacticalShotgunIncrease;

        [Header("Pirate Loot (Before the additional chance from the settings below, items are set to drop twice as likely. Pirate ships will always drop 1 Golden Furniture item. This is done in attempt to imitate the upcoming 1.4.4 update)")] //TO-DO Remove info about the 1.4.4 mimic when that update comes out.

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.CoinGunBaseIncrease")]
        [Tooltip("This is multiplied by 2.5 for Pirate Captain and 10 for Regular Pirates")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CoinGunBaseIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.CutlassBaseIncrease")]
        [Tooltip("This is multiplied by 2.5 for Pirate Captain and 10 for Regular Pirates")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CutlassBaseIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.DiscountCardBaseIncrease")]
        [Tooltip("This is multiplied by 2.5 for Pirate Captain and 10 for Regular Pirates")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int DiscountCardBaseIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.GoldRingBaseIncrease")]
        [Tooltip("This is multiplied by 2.5 for Pirate Captain and 10 for Regular Pirates")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int GoldRingBaseIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.LuckyCoinBaseIncrease")]
        [Tooltip("This is multiplied by 2.5 for Pirate Captain and 10 for Regular Pirates")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int LuckyCoinBaseIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.PirateStaffBaseIncrease")]
        [Tooltip("This is multiplied by 2.5 for Pirate Captain and 10 for Regular Pirates")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int PirateStaffBaseIncrease;

        [Header("[i:1309] Slime Staff")]

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.SlimeStaffFromPinkyIncrease")]
        [Tooltip("" +
            "If world difficulty is normal, this multiplied by (10/7)")]
        [Range(0, 10000)]
        [DefaultValue(4)]
        public int SlimeStaffFromPinkyIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.SlimeStaffFromSandSlimeIncrease")]
        [Tooltip("" +
            "If world difficulty is normal, this multiplied by (10/7)")]
        [Range(0, 10000)]
        [DefaultValue(56)]
        public int SlimeStaffFromSandSlimeIncrease;

        [Label("$Mods.ReducedGrinding.Config.AEnemyLootConfig.Label.SlimeStaffFromOtherSlimesIncrease")]
        [Tooltip("" +
            "If world difficulty is normal, this multiplied by (10/7)")]
        [Range(0, 10000)]
        [DefaultValue(70)]
        public int SlimeStaffFromOtherSlimesIncrease;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    [Label("Enemy Loot Non-Vanilla")]
    public class BEnemyLootNonVanillaConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("These are item drop chances from enemy loot. These drop chances don't exist in vanilla. Chance = 1 / configuration_setting. Set to 0 to disable.\n\nBoss Loot")]

        [Label("$Mods.ReducedGrinding.Config.BEnemyLootNonVanillaConfig.Label.SlimeStaffFromSlimeKing")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int SlimeStaffFromSlimeKing;

        [Label("$Mods.ReducedGrinding.Config.BEnemyLootNonVanillaConfig.Label.TrufflewormFromDukeFishron")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int TrufflewormFromDukeFishron;

        [Label("$Mods.ReducedGrinding.Config.BEnemyLootNonVanillaConfig.Label.TerragrimFromHardmodeGrabBag")]
        [Tooltip("From all Boss Bags that can drop Developer Items")]
        [Range(0, 10000)]
        [DefaultValue(60)]
        public int TerragrimFromHardmodeGrabBag;

        [Header("Non-Boss Loot")]

        [Label("$Mods.ReducedGrinding.Config.BEnemyLootNonVanillaConfig.Label.DesertFossilFromDuneSplicer")]
        [Range(0, 999)]
        public int[] DesertFossilFromDuneSplicer = new int[] { 0, 0 };

        [Label("$Mods.ReducedGrinding.Config.BEnemyLootNonVanillaConfig.Label.DesertFossilFromTombCrawler")]
        [Range(0, 999)]
        public int[] DesertFossilFromTombCrawler = new int[] { 0, 0 };

        [Label("$Mods.ReducedGrinding.Config.BEnemyLootNonVanillaConfig.Label.MarbleFromMarbleCaveEnemies")]
        [Range(0, 999)]
        public int[] MarbleFromMarbleCaveEnemies = new int[] { 5, 10 };

        [Label("$Mods.ReducedGrinding.Config.BEnemyLootNonVanillaConfig.Label.SandFromDuneSplicer")]
        [Range(1, 999)]
        public int[] SandFromDuneSplicer = new int[] { 0, 0 };

        [Label("$Mods.ReducedGrinding.Config.BEnemyLootNonVanillaConfig.Label.SandFromTombCrawler")]
        [Range(1, 999)]
        public int[] SandFromTombCrawler = new int[] { 0, 0 };

        [Label("$Mods.ReducedGrinding.Config.BEnemyLootNonVanillaConfig.Label.SandstormInABottleFromSandElemental")]
        [Range(0, 10000)]
        [DefaultValue(4)]
        public int SandstormInABottleFromSandElemental;

        [Label("$Mods.ReducedGrinding.Config.BEnemyLootNonVanillaConfig.Label.SnowballLauncherFromSpikedIceSlime")]
        [Range(0, 10000)]
        [DefaultValue(60)]
        public int SnowballLauncherFromSpikedIceSlime;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    [Label("Fishing")]
    public class CFishingConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("$Mods.ReducedGrinding.Config.CFishingConfig.Label.MultiBobberPotionBobberAmount")]
        [Tooltip("Set to 1 to disable recipe")]
        [Range(1, 100)]
        [DefaultValue(10)]
        public int MultiBobberPotionBobberAmount;

        [Header("Angler Reset Chance\n\nThe configurations below will give a (1 / configuration_setting) chance at resetting the Angler Quest when finishing it. The chance to reset wont happen until the amount of players wearing any piece of Angler Armor is less than or equal to the amount of players that finished the current Quest. Set to 0 to disable.")]

        [Label("$Mods.ReducedGrinding.Config.CFishingConfig.Label.AnglerRecentChanceBeforeHardmode")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int AnglerRecentChanceBeforeHardmode;

        [Label("$Mods.ReducedGrinding.Config.CFishingConfig.Label.AnglerRecentChanceHardmode")]
        [Range(0, 10000)]
        [DefaultValue(2)]
        public int AnglerRecentChanceHardmode;

        [Label("$Mods.ReducedGrinding.Config.CFishingConfig.Label.AnglerRecentChanceAfterPlantera")]
        [Range(0, 10000)]
        [DefaultValue(2)]
        public int AnglerRecentChanceAfterPlantera;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    [Label("Other Modded Items")]
    public class HOtherModdedItemsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("$Mods.ReducedGrinding.Config.HOtherModdedItemsConfig.Label.MoonBall")]
        [Tooltip("$Mods.ReducedGrinding.Config.HOtherModdedItemsConfig.ToolTip.MoonBall")]
        [DefaultValue(true)]
        public bool MoonBall;

        [Label("$Mods.ReducedGrinding.Config.HOtherModdedItemsConfig.Label.SlimeTrophy")]
        [Tooltip("" +
            "This trophy's drop chances are the same as Slime Staff in vanilla. Slime staff is\n" +
            "sometimes seen as a trophy item, so this is an alternative if Slime Staff's drop rates\n" +
            "are increased.")]
        [DefaultValue(true)]
        public bool SlimeTrophy;

        [Label("$Mods.ReducedGrinding.Config.HOtherModdedItemsConfig.Label.BestiaryTrophy")]
        [Tooltip("" +
            "If the Bestiary is 100% complete, the Zoologoist will sell this Trophy. This acts as a\n" +
            "replacement reward if the Universal Pylon is set to be craftable.")]
        [DefaultValue(true)]
        public bool BestiaryTrophy;

        [Label("$Mods.ReducedGrinding.Config.HOtherModdedItemsConfig.Label.PlanteraSapFromPlantera")]
        [Tooltip("Summons Plantera. Chance = 1 / configuration_setting. Set to 0 to disable.")]
        [DefaultValue(0)]
        public int PlanteraSapFromPlantera;

        [Header("Spawn Increasing Potions\n\nIf you experience lag, try turning down max spawns first.\n\nGreater Battle Potion")]

        [Label("$Mods.ReducedGrinding.Config.HOtherModdedItemsConfig.Label.GreaterBattlePotionMaxSpawnsMultiplier")]
        [Increment(.1f)]
        [Range(1f, 10f)]
        [DefaultValue(3f)]
        public float GreaterBattlePotionMaxSpawnsMultiplier;

        [Label("$Mods.ReducedGrinding.Config.HOtherModdedItemsConfig.Label.GreaterBattlePotionSpawnrateMultiplier")]
        [Increment(.1f)]
        [Range(1f, 10f)]
        [DefaultValue(4f)]
        public float GreaterBattlePotionSpawnrateMultiplier;

        [Header("Super Battle Potion")]

        [Label("$Mods.ReducedGrinding.Config.HOtherModdedItemsConfig.Label.SuperBattlePotionMaxSpawnsMultiplier")]
        [Increment(.1f)]
        [Range(1f, 10f)]
        [DefaultValue(4f)]
        public float SuperBattlePotionMaxSpawnsMultiplier;

        [Label("$Mods.ReducedGrinding.Config.HOtherModdedItemsConfig.Label.SuperBattlePotionSpawnrateMultiplier")]
        [Increment(.1f)]
        [Range(1f, 10f)]
        [DefaultValue(8f)]
        public float SuperBattlePotionSpawnrateMultiplier;

        [Header("")]

        [Label("$Mods.ReducedGrinding.Config.HOtherModdedItemsConfig.Label.ModBattlePotionMaxSpawnEffectOnInvasion")]
        [Tooltip("" +
            "At 1, the invasion size will be multiplied by the max spawn multipliers by each buff.\n" +
            "At 0, it will be multiplied by 1.")]
        [Increment(0.01f)]
        [DefaultValue(1f)]
        public float ModBattlePotionMaxSpawnEffectOnInvasion;

        [Header("Staff of Difficulty. Disable all to disable the recipe.")]

        [Label("$Mods.ReducedGrinding.Config.HOtherModdedItemsConfig.Label.StaffOfDifficultyJourney")]
        [DefaultValue(false)]
        public bool StaffOfDifficultyJourney;

        [Label("$Mods.ReducedGrinding.Config.HOtherModdedItemsConfig.Label.StaffOfDifficultyNormal")]
        [DefaultValue(false)]
        public bool StaffOfDifficultyNormal;

        [Label("$Mods.ReducedGrinding.Config.HOtherModdedItemsConfig.Label.StaffOfDifficultyExpert")]
        [DefaultValue(false)]
        public bool StaffOfDifficultyExpert;

        [Label("$Mods.ReducedGrinding.Config.HOtherModdedItemsConfig.Label.StaffOfDifficultyMaster")]
        [DefaultValue(false)]
        public bool StaffOfDifficultyMaster;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }

    [Label("Other")]
    public class IOtherConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("World Generation")]

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.GenerateMissingRareChestItems")]
        [DefaultValue(true)]
        [Tooltip("" +
            "After Vanilla World Generation, this mod will detect if certain rare chest items are\n" +
            "missing from the world and add them to the world. For example: Pyramid items that are\n" +
            "missing because the world didn't generate enough Pyramids.")]
        public bool GenerateMissingRareChestItems;

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.FinchStaffFromTreeShaking")]
        [Tooltip("" +
            "Chance = 1 / configuration_setting. Note: Trees can only be shaken 300 times per day.\n" +
            "Set to 0 to disable.")]
        [DefaultValue(300)]
        public int FinchStaffFromTreeShaking;

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.TerragrimChests")]
        [Tooltip("" +
            "After world generation, this mod will select this many Gold Chest, and insert a\n" +
            "Terragrim into it.")]
        [DefaultValue(1)]
        public int TerragrimChests;

        [Header("\nSleep boost and Sleep Potion\n\nIn vanilla, sleeping makes time travel at 5 in-game minutes per real-life second. This mod will add more time after this. The amount of time added can be reduced by different conditions listed below.")]

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.SleepBoostBase")]
        [Tooltip("Set to 0 to disable Sleep Boost completely, and disable the Sleep Potion and Time Charm recipes.")]
        [Range(0, 55)]
        [DefaultValue(55)]
        public int SleepBoostBase;

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.SleepBoostNoPotionBuffMultiplier")]
        [Tooltip("" +
            "If less than 1, you'll be able to craft Sleep Potion, which gives the Sleep Buff. If\n" +
            "no player has a Sleep Buff, then the Sleep Boost is multiplied by this amount.")]
        [DefaultValue(0.5f)]
        [Increment(0.01f)]
        public float SleepBoostNoPotionBuffMultiplier;

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.SleepPotionDurationInHours")]
        [DefaultValue(12)]
        public int SleepPotionDurationInHours;

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.SleepBoostTimeCharmMultiplier")]
        [Tooltip("" +
            "If less than 1, you'll be able to craft the Time Charm at an Enchanted Sundial, whichs\n" +
            "its effect on or off for the world. If the world's Time Charm is on, Sleep Boost is\n" +
            "multiplied by this amount.")]
        [DefaultValue(0.5f)]
        [Increment(0.01f)]
        public float SleepBoostInactiveTimeCharmMultiplier;

        [Header("\nCrates\n\nAll configurations in this section will add an (1 / configuration_setting) to drop. Set to 0 to disable. Drops from Boss Treasure Bags use the configurations for Boss Loot.\n\n[i:3205] Dungeon / Stockade Crate")]

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.DungeonCrateDungeonFurniture")]
        [Range(0, 10000)]
        [DefaultValue(1)]
        public int DungeonCrateDungeonFurniture;

        [Header("[i:3981] Titanium / Mythril / Pearlwood")]

        [Label("")]
        [Tooltip("Denominator is multiplied by 3 for Mythril and 10 for Pearlwood")]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public int CrateEnchantedSundial;

        [Header("[i:3981] Titanium / Mythril / Pearlwood and Their Pre-Hardmode Variants")]

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.CrateStatue")]
        [Tooltip("" +
            "Randomly selects 1 of the 5 statues. Denominator is multiplied by 3 for Mythril and 10\n" +
            "for Pearlwood")]
        [Range(0, 10000)]
        [DefaultValue(5)]
        public int CrateStatue;

        [Header("Traveling Merchant")]

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.TravelingMerchantExtraRolls")]
        [Tooltip("" +
            "Shop inventories are limited to 40 items, unless you're using the Shop Expander mod.\n" +
            "This will roll item chances, but if it fails every item chance possible, it will skip\n" +
            "the roll to prevent crashing from an infinite loop.")]
        [Range(0, 600)]
        [DefaultValue(0)]
        public int TravelingMerchantExtraRolls;

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.TravelingMerchantChristmasChance")]
        [Tooltip("Chance = 1 / configuration_setting")]
        [Range(0, 600)]
        [DefaultValue(13)]
        public int TravelingMerchantChristmasChance;

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.TravelingMerchantMartianChance")]
        [Tooltip("Chance = 1 / configuration_setting")]
        [Range(0, 600)]
        [DefaultValue(0)]
        public int TravelingMerchantMartianChance;

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.TravelingMerchantNotAKidNorASquidChance")]
        [Tooltip("Chance = 1 / configuration_setting")]
        [Range(0, 600)]
        [DefaultValue(0)]
        public int TravelingMerchantNotAKidNorASquidChance;

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.TravelingMerchantPulseBowChance")]
        [Tooltip("Chance = 1 / configuration_setting")]
        [Range(0, 600)]
        [DefaultValue(100)]
        public int TravelingMerchantPulseBowChance;

      //[Header("Periodic Holiday Timeline.\n\nThis mod will run a looping timeline for periodically triggering Halloween and Christmas events. Real-world days of a year for Holidays is used to calculate when the events should happen.")]
        [Header("Periodic Holiday Timeline.\n\nThis mod will run a looping timeline for periodically triggering Halloween and Christmas events. A calendar item can also be purchased from the Merchant to see the current date. Halloween will happen on the last day of October and Christmas will happen around the end of December. Set to 0 to disable.")]
        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.HolidayTimelineDaysPerMonth")]
        [Range(1, 30)]
        [DefaultValue(2)]
        public int HolidayTimelineDaysPerMonth;

        [Header("Crafting")]

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.InfectionPowderPerMushroom")]
        [Tooltip("Set to 5 to disable custom recipe")]
        [Range(5, 999)]
        [DefaultValue(5)]
        public int InfectionPowderPerMushroom;

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.CraftableGoldCritters")]
        [Tooltip("Recipes use 10 Gold Coins to prevent exploiting the recipe for money.")]
        [DefaultValue(false)]
        public bool CraftableGoldCritters;

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.CraftableRareChests")]
        [DefaultValue(false)]
        public bool CraftableRareChests;

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.CraftableUniversalPylon")]
        [Tooltip("" +
            "0: Disabled, 1: Crafted out of all other Pylons, 2: Same as 1, + crafted at Crystal\n" +
            "Ball instead of Tinker's Workshop, 3: Same as 2 + crafted with all Souls")]
        [Range(0, 3)]
        [DefaultValue(1)]
        public int CraftableUniversalPylon;

        [Header("Other")]

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.CancelInvasionsIfAllPlayersAreUnderground")]
        [DefaultValue(true)]
        public bool CancelInvasionsIfAllPlayersAreUnderground;

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.LunarPillarShieldHealth")]
        [Tooltip("" +
            "The amount of enemies to lower their shield. If world difficulty is normal, this is\n" +
            "multiplied by (2/3)")]
        [Range(1, 150)]
        [DefaultListValue(150)] //TO-DO 1.4.4 May possibly lower the shield of pillar (https://www.youtube.com/watch?v=GjuunSx8k5o&t=223s&ab_channel=ChippyGaming). Wait for more info before setting a default amount.
        public int LunarPillarShieldHealth;

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.MerchantSellsMinersShirtAndPants")]
        [DefaultValue(false)]
        public bool MerchantSellsMinersShirtAndPants;

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.AdjustItemValuesForDropIncreases")]
        [Tooltip("" +
            "If enabled, items with extra drop rates will have their values reduced depending on\n" +
            "how much their drop rate is increased. New value is multiplied by (chance /\n" +
            "total_new_chance).")]
        [DefaultValue(true)]
        public bool AdjustItemValuesForDropIncreases;

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.SkeletonMerchantIgnoresMoonphases")]
        [DefaultValue(false)]
        public bool SkeletonMerchantIgnoresMoonphases;

        [Label("$Mods.ReducedGrinding.Config.IOtherConfig.Label.UniversalPylonBestiaryCompletionRate")]
        [Tooltip("" +
            "In vanilla, there are 523 entries. 51% can be achieved before Hardmode. Set to 100% to disable.")]
        [Increment(0.01f)]
        [DefaultValue(1f)]
        public float UniversalPylonBestiaryCompletionRate;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "Can't change settings in a server.";
            return false;
        }
    }
}
