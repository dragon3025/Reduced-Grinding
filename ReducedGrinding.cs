/*To debug, use:
ErrorLogger.Log(<string>);

To turn into a string use:
Value.ToString()

To show text in chat use:
Main.NewText(string);
or
Main.NewText(string, red, green, blue);

Chatting a value:
Main.NewText(Value.ToString(), 255, 255, 255);
*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReducedGrinding;
using System.IO;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding
{

    class ReducedGrinding : Mod
    {

        public override void Load()
        {
            ModTranslation text = LocalizationLoader.CreateTranslation("Common.PlanteraBulbLable");
            text.SetDefault($"Dryad Sells [i:{ModContent.ItemType<Items.Plantera_Bulb>()}] Plantera Bulb After Plantera Defeated");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.GoblinRetreatOrderLable");
            text.SetDefault($"Goblin Tinkerer Sells [i:{ModContent.ItemType<Items.Goblin_Retreat_Order>()}] Goblin Retreat Order");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.GoldReflectionMirror");
            text.SetDefault($"Merchant Sells [i:{ModContent.ItemType<Items.Gold_Reflection_Mirror>()}] Gold Reflection Mirror For Crafting Gold Critters Item");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.PirateRetreatOrder");
            text.SetDefault($"Pirate Sells [i:{ModContent.ItemType<Items.Pirate_Retreat_Order>()}] Pirate Retreat Order");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.MoonBall");
            text.SetDefault($"Wizard Sells [i:{ModContent.ItemType<Items.Moon_Ball>()}] Moon Ball");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.WarPotion");
            text.SetDefault($"[i:{ModContent.ItemType<Items.War_Potion>()}] War Potion (Crafted with [i:300] Battle Potion; gives Battle and War Buffs).");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.ChaosPotion");
            text.SetDefault($"[i:{ModContent.ItemType<Items.Chaos_Potion>()}] Chaos Potion (Crafted with [i:{ModContent.ItemType<Items.War_Potion>()}] War Potion; gives Battle, War, and Chaos Buffs).");
            LocalizationLoader.AddTranslation(text);
        }

        /*public override void PostSetupContent() TODO
		{
			Mod censusMod = ModLoader.GetMod("Census");
			if (censusMod != null)
			{
				if (GetInstance<IOtherCustomNPCsConfig>().BoneMerchant)
					censusMod.Call("TownNPCCondition", NPCType("BoneMerchant"), "Summon with a \"Skull Call\".");
				else
					censusMod.Call("TownNPCCondition", NPCType("BoneMerchant"), "[c/FF7F7F:DISABLED IN THE CONFIGURATIONS.]");

				if (GetInstance<IOtherCustomNPCsConfig>().LootMerchant)
					censusMod.Call("TownNPCCondition", NPCType("LootMerchant"), "No conditions.");
				else
					censusMod.Call("TownNPCCondition", NPCType("LootMerchant"), " [c/FF7F7F:DISABLED IN THE CONFIGURATIONS.]");

				if (GetInstance<IOtherCustomNPCsConfig>().ChristmasElf)
					censusMod.Call("TownNPCCondition", NPCType("Christmas_Elf"), "Defeat the Frost Legion.");
				else
					censusMod.Call("TownNPCCondition", NPCType("Christmas_Elf"), "[c/FF7F7F:DISABLED IN THE CONFIGURATIONS.]");

				if (GetInstance<ETravelingAndStationaryMerchantConfig>().StationaryMerchant)
					censusMod.Call("TownNPCCondition", NPCType("StationaryMerchant"), "No conditions.");
				else
					censusMod.Call("TownNPCCondition", NPCType("StationaryMerchant"), "[c/FF7F7F:DISABLED IN THE CONFIGURATIONS.]");
			}
		}*/

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            ReducedGrindingMessageType msgType = (ReducedGrindingMessageType)reader.ReadByte();
            switch (msgType)
            {
                case ReducedGrindingMessageType.advanceMoonPhase:
                    ReducedGrindingWorld.advanceMoonPhase = reader.ReadBoolean();
                    break;
            }
        }

        public class VanillaBagsAndExtractinator : GlobalItem  //Rates show in comments are in addition to vanilla rates.
        {
            public override void OpenVanillaBag(string context, Player player, int arg)
            {
                var source = player.GetSource_OpenItem(arg);

                void try_grab_bag_drop(int config, int itemType, int amount = 1)
                {
                    if (config > 0)
                        if (Main.rand.NextBool(config))
                            player.QuickSpawnItem(source, itemType, amount);
                }

                // Boss Bags
                if (arg == ItemID.BrainOfCthulhuBossBag)
                {
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBoneRattleIncrease, ItemID.BoneRattle);
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.BrainMask);
                }
                if (arg == ItemID.FishronBossBag)
                {
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootFishronWingsIncrease, ItemID.FishronWings);
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.DukeFishronMask);
                }
                if (arg == ItemID.EaterOfWorldsBossBag)
                {
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootEatersBoneIncrease, ItemID.EatersBone);
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.EaterMask);
                }
                if (arg == ItemID.EyeOfCthulhuBossBag)
                {
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBinocularsIncrease, ItemID.Binoculars);
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.EyeMask);
                }
                if (arg == ItemID.PlanteraBossBag)
                {
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootTheAxeIncrease, ItemID.TheAxe);
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootSeedlingIncrease, ItemID.Seedling);
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.PlanteraMask);
                }
                if (arg == ItemID.QueenBeeBossBag)
                {
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootHoneyedGogglesIncrease, ItemID.HoneyedGoggles);
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootNectarIncrease, ItemID.Nectar);
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.BeeMask);
                }
                if (arg == ItemID.MoonLordBossBag)
                {
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.BossMaskMoonlord);
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease, ItemID.Meowmere);
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease, ItemID.Terrarian);
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease, ItemID.StarWrath);
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease, ItemID.SDMG);
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease, ItemID.FireworksLauncher); //Celebration
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease, ItemID.LastPrism);
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease, ItemID.LunarFlareBook);
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease, ItemID.RainbowCrystalStaff);
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease, ItemID.MoonlordTurretStaff); //Lunar Portal Staff
                }
                if (arg == ItemID.SkeletronBossBag)
                {
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBookofSkullsIncrease, ItemID.BookofSkulls);
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootSkeletronBoneKey, ItemID.BoneKey);
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.SkeletronMask);
                }
                if (arg == 3318) //King Slime
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.KingSlimeMask);
                if (arg == 3324) //Wall of Flesh
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.FleshMask);
                if (arg == 3325) //The Destroyer
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.DestroyerMask);
                if (arg == 3326) //The Twins
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.TwinMask);
                if (arg == 3327) //Skeletron Prime
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.SkeletronPrimeMask);
                if (arg == 3329) //Golem
                {
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.GolemMask);
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootPicksawIncrease, ItemID.Picksaw);
                }
                if (arg == 3860) //Betsy
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootBossMaskIncrease, ItemID.BossMaskBetsy);

                //Crates
                if (arg == 3205) //Dungeon Crate
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateDungeonBoneWelder, ItemID.BoneWelder);
                if (arg == ItemID.JungleFishingCrate)
                {
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleSeaweed, ItemID.Seaweed);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleFlowerBoots, ItemID.FlowerBoots);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleLivingMahoganyWand, ItemID.LivingMahoganyWand);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleRichMahoganyLeafWand, ItemID.LivingMahoganyLeafWand);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleLivingLoom, ItemID.LivingLoom);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleLeafWand, ItemID.LeafWand);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleLivingWoodWand, ItemID.LivingWoodWand);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleAnkeltOfTheWindIncrease, ItemID.AnkletoftheWind);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleFeralClawsIncrease, ItemID.FeralClaws);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateJungleStaffOfRegrowth, ItemID.StaffofRegrowth);
                }
                if (arg == 3206) //Sky Crate
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateSkySkyMill, ItemID.SkyMill);
                if (arg == ItemID.WoodenCrate)
                {
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateWoodenClimbingClawsIncrease, ItemID.ClimbingClaws);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateWoodenRadarIncrease, ItemID.Radar);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateWoodenAgletIncrease, ItemID.Aglet);
                }
                if (arg == ItemID.WoodenCrate)
                {
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateWaterWalkingBootsWooden, ItemID.WaterWalkingBoots);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateFlippersWooden, ItemID.Flipper);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateEnchantedSundialWoodenIncrease, ItemID.Sundial);
                }
                if (arg == ItemID.IronCrate)
                {
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateWaterWalkingBootsIron, ItemID.WaterWalkingBoots);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateFlippersIron, ItemID.Flipper);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateEnchantedSundialIronIncrease, ItemID.Sundial);
                }
                if (arg == ItemID.GoldenCrate)
                {
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateWaterWalkingBootsGolden, ItemID.WaterWalkingBoots);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateFlippersGolden, ItemID.Flipper);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().CrateEnchantedSundialGoldenIncrease, ItemID.Sundial);
                }
                if (context == "present")
                {
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentDogWhistle, ItemID.DogWhistle);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentToolbox, ItemID.Toolbox);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentHandWarmer, ItemID.HandWarmer);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentCandyCanePickaxe, ItemID.CnadyCanePickaxe);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentCandyCaneHook, ItemID.CandyCaneHook);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentFruitcakeChakram, ItemID.FruitcakeChakram);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentRedRyderPlusMusketBall, ItemID.RedRyder);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentRedRyderPlusMusketBall, ItemID.Musket, Main.rand.Next(30, 60));
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentCandyCaneSword, ItemID.CandyCaneSword);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentMrsClausCostume, ItemID.MrsClauseHat);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentMrsClausCostume, ItemID.MrsClauseHeels);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentMrsClausCostume, ItemID.MrsClauseShirt);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentParkaOutfit, ItemID.ParkaCoat);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentParkaOutfit, ItemID.ParkaHood);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentParkaOutfit, ItemID.ParkaPants);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentTreeCostume, ItemID.TreeMask);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentTreeCostume, ItemID.TreeShirt);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentTreeCostume, ItemID.TreeTrunks);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentSnowHat, ItemID.SnowHat);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentUglySweater, ItemID.UglySweater);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentReindeerAntlers, ItemID.ReindeerAntlers);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentCoal, ItemID.Coal);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentChristmasPudding, ItemID.ChristmasPudding);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentSugarCookie, ItemID.SugarCookie);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentGingerbreadCookie, ItemID.GingerbreadCookie);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentStarAnise, ItemID.StarAnise, Main.rand.Next(20, 40));
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentEggnog, ItemID.Eggnog, Main.rand.Next(1, 3));
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentHolly, ItemID.Holly);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentHolly, 1908);
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentPineTreeBlock, ItemID.PineTreeBlock, Main.rand.Next(20, 49));
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentCandyCaneBlock, ItemID.CandyCaneBlock, Main.rand.Next(20, 49));
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentGreenCandyCaneBlock, ItemID.GreenCandyCaneBlock, Main.rand.Next(20, 49));
                    try_grab_bag_drop(GetInstance<BGrabBagConfig>().PresentHardmodeSnowGlobe, ItemID.SnowGlobe);
                }

                //Boss Bag drops that don't happen in vanilla.
                if (arg == ItemID.FishronBossBag)
                    try_grab_bag_drop(GetInstance<AEnemyLootConfig>().LootFishronTruffleworm, ItemID.TruffleWorm);
            }
        }
    }

    class SpawnRateMultiplierGlobalNPC : GlobalNPC
    {
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {

            if (player.FindBuffIndex(ModContent.BuffType<Buffs.War>()) != -1)
            {
                spawnRate = (int) (spawnRate / GetInstance<HOtherModdedItemsConfig>().WarPotionSpawnrateMultiplier);
                maxSpawns = (int) (maxSpawns * GetInstance<HOtherModdedItemsConfig>().WarPotionMaxSpawnsMultiplier);
            }
            if (player.FindBuffIndex(ModContent.BuffType<Buffs.Chaos>()) != -1)
            {
                spawnRate = (int) (spawnRate / GetInstance<HOtherModdedItemsConfig>().ChaosPotionSpawnrateMultiplier);
                maxSpawns = (int) (maxSpawns * GetInstance<HOtherModdedItemsConfig>().ChaosPotionMaxSpawnsMultiplier);
            }
        }
    }

    enum ReducedGrindingMessageType : byte
    {
        advanceMoonPhase
    }

}