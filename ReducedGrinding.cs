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
            ModTranslation text = LocalizationLoader.CreateTranslation("Common.CavernLockboxLable");
            text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Cavern_Lock_Box>()}] Cavern Lockbox");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.DungeonBiomeLockboxLabel");
            text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Biome_Lock_Box>()}] Biome Lockbox");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.DungeonFurnitureLockboxLabel");
            text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Blue_Dungeon_Lock_Box>()}] Dungeon Furniture Lockbox");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.ShadowLockboxLable");
            text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Shadow_Lock_Box>()}] Shadow Lockbox");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.LihzahrdLockboxLable");
            text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Lihzahrd_Lock_Box>()}] Lihzahrd Lockbox");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.PyramidLockBoxLable");
            text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Pyramid_Lock_Box>()}] Pyramid Lockbox");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.SkywareLockBoxLable");
            text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Skyware_Lock_Box>()}] Skyware Lockbox");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.WebCoveredLockboxLable");
            text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Web_Covered_Lock_Box>()}] Web Covered Lockbox");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.LivingWoodLockBoxLable");
            text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Living_Wood_Lock_Box>()}] Living Wood Lockbox");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.IvyLockBoxLable");
            text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Ivy_Lock_Box>()}] Ivy Lockbox");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.IceLockBoxLable");
            text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Ice_Lock_Box>()}] Ice Lockbox");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.WaterLockBoxLable");
            text.SetDefault($"[i:{ModContent.ItemType<Items.LockBoxes.Water_Lock_Box>()}] Water Lockbox");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.PlanteraBulbLable");
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

        /*public override void PostSetupContent()
		{
			Mod censusMod = ModLoader.GetMod("Census");
			if (censusMod != null)
			{
				if (GetInstance<IOtherCustomNPCsConfig>().BoneMerchant)
					censusMod.Call("TownNPCCondition", NPCType("BoneMerchant"), "Summon with a \"Skull Call\".");
				else
					censusMod.Call("TownNPCCondition", NPCType("BoneMerchant"), "[c/FF7F7F:DISABLED IN THE CONFIGURATIONS.]");

				if (GetInstance<IOtherCustomNPCsConfig>().ChestSalesman)
					censusMod.Call("TownNPCCondition", NPCType("ChestSalesman"), "No conditions.");
				else
					censusMod.Call("TownNPCCondition", NPCType("ChestSalesman"), "[c/FF7F7F:DISABLED IN THE CONFIGURATIONS.]");

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
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootBoneRattleIncrease, ItemID.BoneRattle);
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootBossMaskIncrease, ItemID.BrainMask);
                }
                if (arg == ItemID.FishronBossBag)
                {
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootFishronWingsIncrease, ItemID.FishronWings);
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootBossMaskIncrease, ItemID.DukeFishronMask);
                }
                if (arg == ItemID.EaterOfWorldsBossBag)
                {
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootEatersBoneIncrease, ItemID.EatersBone);
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootBossMaskIncrease, ItemID.EaterMask);
                }
                if (arg == ItemID.EyeOfCthulhuBossBag)
                {
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootBinocularsIncrease, ItemID.Binoculars);
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootBossMaskIncrease, ItemID.EyeMask);
                }
                if (arg == ItemID.PlanteraBossBag)
                {
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootTheAxeIncrease, ItemID.TheAxe);
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootSeedlingIncrease, ItemID.Seedling);
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootBossMaskIncrease, ItemID.PlanteraMask);
                }
                if (arg == ItemID.QueenBeeBossBag)
                {
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootHoneyedGogglesIncrease, ItemID.HoneyedGoggles);
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootNectarIncrease, ItemID.Nectar);
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootBossMaskIncrease, ItemID.BeeMask);
                }
                if (arg == ItemID.MoonLordBossBag)
                {
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootBossMaskIncrease, ItemID.BossMaskMoonlord);
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease, ItemID.Meowmere);
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease, ItemID.Terrarian);
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease, ItemID.StarWrath);
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease, ItemID.SDMG);
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease, ItemID.FireworksLauncher); //Celebration
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease, ItemID.LastPrism);
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease, ItemID.LunarFlareBook);
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease, ItemID.RainbowCrystalStaff);
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease, ItemID.MoonlordTurretStaff); //Lunar Portal Staff
                }
                if (arg == ItemID.SkeletronBossBag)
                {
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootBookofSkullsIncrease, ItemID.BookofSkulls);
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootSkeletronBoneKey, ItemID.BoneKey);
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootBossMaskIncrease, ItemID.SkeletronMask);
                }
                if (arg == 3318) //King Slime
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootBossMaskIncrease, ItemID.KingSlimeMask);
                if (arg == 3324) //Wall of Flesh
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootBossMaskIncrease, ItemID.FleshMask);
                if (arg == 3325) //The Destroyer
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootBossMaskIncrease, ItemID.DestroyerMask);
                if (arg == 3326) //The Twins
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootBossMaskIncrease, ItemID.TwinMask);
                if (arg == 3327) //Skeletron Prime
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootBossMaskIncrease, ItemID.SkeletronPrimeMask);
                if (arg == 3329) //Golem
                {
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootBossMaskIncrease, ItemID.GolemMask);
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootPicksawIncrease, ItemID.Picksaw);
                }
                if (arg == 3860) //Betsy
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootBossMaskIncrease, ItemID.BossMaskBetsy);

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
                    try_grab_bag_drop(GetInstance<AEnemyDropConfig>().LootFishronTruffleworm, ItemID.TruffleWorm);
            }
        }

        /*public class ModGlobalNPC : GlobalNPC
        {
            public override void OnKill(NPC npc)
            {
                if (npc.lifeMax > 5 && npc.type != NPCID.Bee && npc.type != NPCID.BeeSmall)
                {
                    Player player = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];

                    int npcTileX;
                    int npcTileY;
                    npcTileX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
                    npcTileY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;

                    if (npc.type == NPCID.AnglerFish || npc.type == NPCID.Piranha)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootRobotHatIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RobotHat, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.AnglerFish || (npc.type >= 269 && npc.type <= 272) || npc.type == NPCID.Werewolf) //269 to 272 is Rusty Armored Bones
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAdhesiveBandageIncrease
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AdhesiveBandage, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.ChaosElemental && GetInstance<AEnemyDropConfig>().LootRodofDiscordIncrease > 0)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootRodofDiscordIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RodofDiscord, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Clown || npc.type == NPCID.LightMummy || npc.type == NPCID.GiantBat)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootTrifoldMapIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TrifoldMap, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Clown)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBananarangIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bananarang, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.EnchantedSword || npc.type == NPCID.CrimsonAxe || npc.type == NPCID.CursedHammer || npc.type == NPCID.CursedSkull)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootNazarIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Nazar, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Hornet || (npc.type >= 231 && npc.type <= 235)) //Hornet
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMegaphoneBaseIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Megaphone, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientCobaltHelmetIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltHelmet, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientCobaltBreastplateIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltBreastplate, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientCobaltLeggingsIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltLeggings, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootHiveBlockFromHornetsAndMossHornetsAfterQueenBeDowned && NPC.downedQueenBee)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Hive, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.MossHornet)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootTatteredBeeWingIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TatteredBeeWing, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootHiveBlockFromHornetsAndMossHornetsAfterQueenBeDowned && NPC.downedQueenBee)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Hive, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Corruptor || npc.type == NPCID.FloatyGross)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootVitaminsIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Vitamins, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Crimslime || npc.type == NPCID.BigCrimslime || npc.type == NPCID.LittleCrimslime)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBlindfoldIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Blindfold, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Mummy || npc.type == NPCID.Pixie || npc.type == NPCID.Wraith)
                    {
                        int fastClockMultiplier = 1;
                        if (npc.type != NPCID.Pixie)
                            fastClockMultiplier = 2;
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootFastClockBaseIncrease * fastClockMultiplier)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FastClock, 1, false, -1, false, false);
                    }
                    if (Main.tile[npcTileX, npcTileY].wall == WallID.LihzahrdBrickUnsafe && NPC.downedPlantBoss)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootLizardEggIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LizardEgg, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootLihzahrdPowerCellIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LihzahrdPowerCell, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.GiantTortoise && GetInstance<AEnemyDropConfig>().LootTurtleShellIncrease > 0)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootTurtleShellIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TurtleShell, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.IceTortoise && GetInstance<AEnemyDropConfig>().LootFrozenTurtleShellIncrease > 0)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootFrozenTurtleShellIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FrozenTurtleShell, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Paladin)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPaladinsShieldIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PaladinsShield, 1, false, -1, false, false);
                    }
                    if ((npc.type >= 212 && npc.type <= 216) || npc.type == NPCID.PirateShip) //All Human Pirates and Flying Dutchman
                    {
                        int pirateLootMultiplier = 1;
                        int pirateLootMultiplier2 = 1;
                        if (npc.type == NPCID.PirateCaptain || npc.type == NPCID.PirateShip)
                            pirateLootMultiplier = 4;
                        if (npc.type == NPCID.PirateShip)
                            pirateLootMultiplier2 = 4;
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().PirateLootCoinGunBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CoinGun, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().PirateLootLuckyCoinBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LuckyCoin, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().PirateLootDiscountCardBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DiscountCard, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().PirateLootPirateStaffBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PirateStaff, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().PirateLootGoldRingBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldRing, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().PirateLootCutlassBaseIncrease * pirateLootMultiplier * pirateLootMultiplier2)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cutlass, 1, false, -1, false, false);
                        if (npc.type != NPCID.PirateCaptain && npc.type != NPCID.PirateShip)
                        {
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSailorHatIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SailorHat, 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSailorShirtIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SailorShirt, 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSailorPantsIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SailorPants, 1, false, -1, false, false);
                        }
                        if (GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease > 0 && npc.type != NPCID.PirateCaptain && npc.type != NPCID.PirateShip)
                        {
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenChair, 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenToilet, 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenDoor, 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenTable, 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenBed, 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenPiano, 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenDresser, 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenSofa, 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenBathtub, 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenClock, 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenLamp, 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenBookcase, 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenChandelier, 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenLantern, 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenCandelabra, 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenCandle, 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenSink, 1, false, -1, false, false);
                        }
                    }
                    if (npc.type == NPCID.Pixie || npc.type == NPCID.GreenJellyfish || npc.type == NPCID.DarkMummy)
                    {
                        int megaphoneMultiplier = 1;
                        if (npc.type == NPCID.GreenJellyfish)
                            megaphoneMultiplier = 2;
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMegaphoneBaseIncrease * megaphoneMultiplier)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Megaphone, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.ArmoredSkeleton || (npc.type >= 273 && npc.type <= 276)) //Blue Amored Bones and Armored Skeleton
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootArmorPolishIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ArmorPolish, 1, false, -1, false, false);
                    }
                    if ((npc.type == NPCID.ZombieElf || npc.type == NPCID.ZombieElfBeard || npc.type == NPCID.ZombieElfGirl))
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootElfHatIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ElfHat, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootElfShirtIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ElfShirt, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootElfPantsIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ElfPants, 1, false, -1, false, false);
                    }
                    if (npc.type >= 269 && npc.type <= 280)//All Armored Bones variants
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootWispinaBottleIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WispinaBottle, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBoneFeatherIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneFeather, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMagnetSphereIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagnetSphere, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootKeybrandIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Keybrand, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.EaterofSouls)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientShadowHelmetIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientShadowHelmet, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientShadowScalemailIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientShadowScalemail, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientShadowGreavesIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientShadowGreaves, 1, false, -1, false, false);
                    }
                    if (npc.type == 21 || (npc.type >= 201 && npc.type <= 203) || (npc.type >= 322 && npc.type <= 323) || (npc.type >= 449 && npc.type <= 452)) //Skeleton
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSkullIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Skull, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBoneSwordIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneSword, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientGoldHelmetIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientGoldHelmet, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientIronHelmetIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientIronHelmet, 1, false, -1, false, false);
                    }
                    if (npc.type == 31 || (npc.type >= 294 && npc.type <= 296)) //Angry Bones
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientNecroHelmetIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientNecroHelmet, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootClothierVoodooDollIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ClothierVoodooDoll, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBoneWandIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneWand, 1, false, -1, false, false);
                    }
                    if (player.ZoneUnderworldHeight)
                    {

                        if (Main.hardMode)
                        {
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootHelFireIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HelFire, 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootLivingFireBlockIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LivingFireBlock, 1, false, -1, false, false);
                        }
                        else if (NPC.downedBoss3) //Skeletron
                        {
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootCascadeIncrease)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cascade, 1, false, -1, false, false);
                        }
                    }
                    if (npc.type == NPCID.ManEater)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientCobaltHelmetIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltHelmet, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientCobaltBreastplateIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltBreastplate, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientCobaltLeggingsIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCobaltLeggings, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.FireImp)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPlumbersHatIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PlumbersHat, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootObsidianRoseIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ObsidianRose, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.CursedSkull || npc.type == NPCID.DarkCaster)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBoneWandIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BoneWand, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.CaveBat)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootChainKnifeIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ChainKnife, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Reaper)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDeathSickleIncrease)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1327, 1, false, -1, false, false); //Death Sickle
                        }
                    }
                    if (npc.type == 3 || npc.type == 132 || npc.type == 161 || (npc.type >= 186 && npc.type <= 200) || npc.type == 223 || (npc.type >= 430 && npc.type <= 436)) //Normal Zombie Variants, Raincoat Zombie, and Zombie Eskimo
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootZombieArmIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ZombieArm, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootShackleIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Shackle, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Pixie || npc.type == NPCID.Unicorn || npc.type == NPCID.RainbowSlime || npc.type == NPCID.Gastropod || npc.type == NPCID.LightMummy || npc.type == NPCID.IlluminantSlime || npc.type == NPCID.IlluminantBat || npc.type == NPCID.ChaosElemental || npc.type == NPCID.EnchantedSword || npc.type == NPCID.BigMimicHallow) //Hallow Enemies
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBlessedAppleIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlessedApple, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Mimic)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDualHookIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DualHook, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMagicDaggerIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagicDagger, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootTitanGloveIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TitanGlove, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPhilosophersStoneIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PhilosophersStone, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootCrossNecklaceIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CrossNecklace, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootStarCloakIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.StarCloak, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.BigMimicCorruption)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDartRifleIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DartRifle, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootWormHookIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WormHook, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootChainGuillotinesIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ChainGuillotines, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootClingerStaffIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ClingerStaff, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPutridScentIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PutridScent, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.BigMimicCrimson)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootLifeDrainIncrease)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulDrain, 1, false, -1, false, false);//Life Drain
                        }
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDartPistolIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DartPistol, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootFetidBaghnakhsIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FetidBaghnakhs, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootFleshKnucklesIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FleshKnuckles, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootTendonHookIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TendonHook, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.BigMimicHallow)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDaedalusStormbowIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DaedalusStormbow, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootFlyingKnifeIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FlyingKnife, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootCrystalVileShardIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CrystalVileShard, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootIlluminantHookIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IlluminantHook, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Harpy)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGiantHarpyFeatherIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GiantHarpyFeather, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootCloudFromHarpies)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cloud, 1, false, -1, false, false);
                    }
                    if ((npc.type >= 26 && npc.type <= 29) || npc.type == 111) //Goblin Army (Excluding Summoner)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootHarpoonIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Harpoon, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.ArmoredViking || npc.type == NPCID.IceElemental || npc.type == NPCID.IcyMerman || npc.type == NPCID.IceTortoise)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootIceSickleIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IceSickle, 1, false, -1, false, false);
                    }
                    if (npc.type >= 269 && npc.type <= 293)// Post-plantera dungeon enemies
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootKrakenIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Kraken, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.SkeletonArcher)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMarrowIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Marrow, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMagicQuiverIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagicQuiver, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Crimslime || npc.type == NPCID.CrimsonAxe || npc.type == NPCID.FloatyGross || npc.type == NPCID.Herpling)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMeatGrinderIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MeatGrinder, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.AngryTrapper)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootUziIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Uzi, 1, false, -1, false, false);
                    }
                    if (NPC.downedMechBoss1 && player.ZoneJungle)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootYeletsIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Yelets, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.ArmoredSkeleton)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBeamSwordIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BeamSword, 1, false, -1, false, false);
                    }
                    if (npc.type == 2 || (npc.type >= 190 && npc.type <= 194) || npc.type == 317 || npc.type == 318) //Demon Eye and Wandering Eye
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBlackLensIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlackLens, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.ZombieEskimo || npc.type == NPCID.ArmedZombieEskimo)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootEskimoHoodIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EskimoHood, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootEskimoCoatIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EskimoCoat, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootEskimoPantsIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EskimoPants, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Hellbat)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().HellBatLootMagmaStoneIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagmaStone, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Lavabat)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LavaBatLootMagmaStoneIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagmaStone, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.SnowFlinx)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSnowballLauncherIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SnowballLauncher, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.ScutlixRider)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBrainScramblerIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BrainScrambler, 1, false, -1, false, false);
                    }
                    if (npc.type == 63 || npc.type == 64 || npc.type == 103) //Basic Jellyfish
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootJellyfishNecklaceIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.JellyfishNecklace, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.DesertLamiaLight || npc.type == NPCID.DesertLamiaDark)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootLamiaClothesIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LamiaHat, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootLamiaClothesIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LamiaPants, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootLamiaClothesIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LamiaShirt, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Vampire)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonStoneIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonStone, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.RedDevil)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootFireFeatherIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FireFeather, 1, false, -1, false, false);
                    }
                    if (GetInstance<AEnemyDropConfig>().SlimeStaffIncreaseToSurfaceSlimes && (npc.type == NPCID.GreenSlime || npc.type == NPCID.BlueSlime || npc.type == NPCID.PurpleSlime || npc.type == NPCID.IceSlime || npc.type == NPCID.SandSlime || npc.type == NPCID.JungleSlime))
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSlimeStaffIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
                    }
                    if (GetInstance<AEnemyDropConfig>().SlimeStaffIncreaseToUndergroundSlimes && (npc.type == NPCID.RedSlime || npc.type == NPCID.YellowSlime))
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSlimeStaffIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
                    }
                    if (GetInstance<AEnemyDropConfig>().SlimeStaffIncreaseToCavernSlimess && (npc.type == NPCID.BlackSlime || npc.type == NPCID.MotherSlime || npc.type == NPCID.BabySlime))
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSlimeStaffIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
                    }
                    if (GetInstance<AEnemyDropConfig>().SlimeStaffIncreaseToIceSpikedSlimes && npc.type == NPCID.SpikedIceSlime)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSlimeStaffIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
                    }
                    if (GetInstance<AEnemyDropConfig>().SlimeStaffIncreaseToSpikedJungleSlimes && npc.type == NPCID.SpikedJungleSlime)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSlimeStaffIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1, false, -1, false, false);
                    }
                    if (Main.hardMode && player.ZoneBeach)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPirateMapIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PirateMap, 1, false, -1, false, false);
                    }
                    if (Main.hardMode && player.ZoneRockLayerHeight && (player.ZoneCorrupt || player.ZoneCrimson))
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSoulofNightIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofNight, 1, false, -1, false, false);
                    }
                    if (Main.hardMode && player.ZoneRockLayerHeight && player.ZoneHallow)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSoulofLightIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofLight, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Unicorn)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootUnicornonaStickIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.UnicornonaStick, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.DiggerHead || npc.type == NPCID.GiantWormHead)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootWhoopieCushionIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WhoopieCushion, 1, false, -1, false, false);
                    }
                    if (player.ZoneSnow && Main.hardMode) //Skeletron
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAmarokIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Amarok, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.UndeadMiner)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBonePickaxeIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BonePickaxe, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMiningHelmetIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MiningHelmet, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMiningShirtIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MiningShirt, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMiningPantsIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MiningPants, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Psycho)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPsychoKnifeIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PsychoKnife, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.CorruptBunny)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBunnyHoodIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BunnyHood, 1, false, -1, false, false);
                    }
                    if (npc.type >= 78 && npc.type <= 80) //Mummies
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMummyCostumeIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MummyMask, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMummyCostumeIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MummyShirt, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMummyCostumeIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MummyPants, 1, false, -1, false, false);
                    }
                    if (npc.type == 31 || (npc.type >= 294 && npc.type <= 296) || npc.type == NPCID.CursedSkull || npc.type == NPCID.DarkCaster) //Angry Bones, Cursed Skull, and Dark Caster
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoldenKeyIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldenKey, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootTallyCounterIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TallyCounter, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Werewolf)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonCharmIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonCharm, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.DesertBeast)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientHornIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientHorn, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Demon)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDemonScytheIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DemonScythe, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Shark)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDivingHelmetIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DivingHelmet, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Eyezor)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootEyeSpringIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EyeSpring, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.IceElemental || npc.type == NPCID.IcyMerman)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootFrostStaffIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FrostStaff, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.WalkingAntlion)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMandibleBladeIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AntlionClaw, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.MeteorHead)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMeteoriteIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Meteorite, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.CorruptPenguin || npc.type == NPCID.CrimsonPenguin)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPedguinssuitIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PedguinHat, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPedguinssuitIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PedguinShirt, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPedguinssuitIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PedguinPants, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.UndeadViking)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootVikingHelmetIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.VikingHelmet, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.UmbrellaSlime)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootUmbrellaHatIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.UmbrellaHat, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Vampire || npc.type == NPCID.VampireBat)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBrokenBatWingIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BrokenBatWing, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.DesertDjinn)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDesertSpiritLampIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DjinnLamp, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Piranha)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootHookIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Hook, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.LightMummy || npc.type == NPCID.DesertGhoulHallow || npc.type == NPCID.SandsharkHallow)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootLightShardIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LightShard, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.DesertLamiaLight)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoonMaskIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonMask, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.DesertLamiaDark)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSunMaskIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SunMask, 1, false, -1, false, false);
                    }
                    if (npc.type >= 333 && npc.type <= 336) //Present Slimes
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGiantBowIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GiantBow, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.ZombieRaincoat)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootRainArmorIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RainCoat, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootRainArmorIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RainCoat, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Mimic && player.ZoneSnow)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootToySledIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ToySled, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.SkeletonSniper)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSniperRifleIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SniperRifle, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootRifleScopeIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RifleScope, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.TacticalSkeleton)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootTacticalShotgunIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TacticalShotgun, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootSWATHelmetIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SWATHelmet, 1, false, -1, false, false);
                    }
                    if (npc.type >= 524 && npc.type <= 527) //Ghouls
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAncientClothIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientCloth, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.DesertGhoulCorruption || npc.type == NPCID.DesertGhoulCrimson)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDarkShardIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DarkShard, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.AngryNimbus)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootNimbusRodIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.NimbusRod, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.BoneLee)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBlackBeltIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlackBelt, 1, false, -1, false, false);
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootTabiIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Tabi, 1, false, -1, false, false);
                    }
                    if (Main.halloween && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGoodieBagIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoodieBag, 1, false, -1, false, false);
                    }
                    if (Main.xMas && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPresentIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Present, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Drippler || npc.type == NPCID.BloodZombie)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMoneyTroughIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoneyTrough, 1, false, -1, false, false);
                    }
                    if (npc.type == 42 || npc.type == 141 || npc.type == 176 || (npc.type >= 231 && npc.type <= 235)) //Hornet, Moss Hornet, and Toxic Sludge
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootBezoarIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bezoar, 1, false, -1, false, false);
                    }
                    if (Main.halloween && npc.value < 500f)
                    {
                        if (npc.damage >= 40 && npc.defense >= 20 && GetInstance<AEnemyDropConfig>().LootBloodyMacheteAndBladedGlovesAreNotLimitedByDamageAndDefense) //Add Vanilla Drop Rate to the enemies that vanilla limits
                        {
                            if (Main.rand.Next(2000) == 0)
                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1825, 1, false, -1, false, false); //Bloody Machete
                            }
                            if (Main.rand.Next(2000) == 0)
                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1827, 1, false, -1, false, false); //Bladed Gloves
                            }
                        }
                        if ((npc.damage < 40 && npc.defense < 20) || (GetInstance<AEnemyDropConfig>().LootBloodyMacheteAndBladedGlovesAreNotLimitedByDamageAndDefense)) //Add this mod's increase
                        {
                            if (Main.rand.Next(2000) == 0)
                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1825, 1, false, -1, false, false); //Bloody Machete
                            }
                            if (Main.rand.Next(2000) == 0)
                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1827, 1, false, -1, false, false); //Bladed Gloves
                            }
                        }
                    }
                    if (npc.type >= 494 && npc.type <= 506) //Giant Shellies, Crawdads, and Salamanders
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootRallyIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Rally, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Medusa)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPocketMirrorIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PocketMirror, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Mothron)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootMothronWingsIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MothronWings, 1, false, -1, false, false);
                    }
                    if (Main.bloodMoon && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead && Main.hardMode)
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootKOCannonIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.KOCannon, 1, false, -1, false, false);
                    }
                    if (npc.type == 16 || npc.type == 58 || npc.type == 167 || npc.type == 197 || npc.type == 185 || (npc.type >= 494 && npc.type <= 506)) //Salamanders, Giant Shellys, Crawdads, Mother Slimes, Piranhas, Snow Flinxes, Undead Vikings, and Armored Vikings.
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootCompassIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Compass, 1, false, -1, false, false);
                    }
                    if (npc.type == 49 || npc.type == 93 || npc.type == 51 || npc.type == 150 || (npc.type >= 494 && npc.type <= 506)) //Cave Bats, Giant Bats, Jungle Bats, Ice Bats, Salamanders, Giant Shellys, and Crawdads.
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootDepthMeterIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DepthMeter, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Guide) //Guide NPC
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootGreenCapForNonAndrewGuide)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GreenCap, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.DyeTrader) //Dye Trader NPC
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootExoticScimitarIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DyeTradersScimitar, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.DD2Bartender) //Tavernkeep NPC
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootAleTosserIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AleThrowingGlove, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Stylist) //Stylist NPC
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootStylishScissorsIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.StylistKilLaKillScissorsIWish, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.Painter) //Painter NPC
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootPaintballGunIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PainterPaintballGun, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.PartyGirl) //Party Girl NPC
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootHappyGrenadeIncrease)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PartyGirlGrenade, Main.rand.Next(30, 61), false, -1, false, false);
                    }
                    if (npc.type == NPCID.TaxCollector) //Tax Collector Guide NPC
                    {
                        if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().LootClassyCane)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TaxCollectorsStickOfDoom, 1, false, -1, false, false);
                    }
                    if (npc.type == NPCID.RainbowSlime && (GetInstance<AEnemyDropConfig>().LootRainbowBlockDropMinIncrease < GetInstance<AEnemyDropConfig>().LootRainbowBlockDropMaxIncrease)) //RainbowSlime
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RainbowBrick, Main.rand.Next(GetInstance<AEnemyDropConfig>().LootRainbowBlockDropMinIncrease - 30, GetInstance<AEnemyDropConfig>().LootRainbowBlockDropMaxIncrease - 60), false, -1, false, false); //Rainbow Block
                    }

                    //Chest Drop
                    if (GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop > 0)
                    {
                        if (player.ZoneSnow && player.ZoneRockLayerHeight && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 681, 1, false, -1, false, false); //Ice Chest
                        else if (player.ZoneJungle && player.ZoneRockLayerHeight && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 680, 1, false, -1, false, false); //Ivy Chest
                        else if ((Main.tile[npcTileX, npcTileY].wall == WallID.LihzahrdBrickUnsafe && NPC.downedPlantBoss) && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop) //Lihzahrd Temple Enemies
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1142, 1, false, -1, false, false); //Lihzahrd Chest
                        else if (player.ZoneUnderworldHeight && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 328, 1, false, -1, false, false); //Shadow Chest
                        else if (player.ZoneDungeon && NPC.downedPlantBoss)
                        {
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1528, 1, false, -1, false, false); //Jungle Chest
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1529, 1, false, -1, false, false); //Corruption Chest
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1530, 1, false, -1, false, false); //Crimson Chest
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1531, 1, false, -1, false, false); //Hallowed Chest
                            if (Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1532, 1, false, -1, false, false); //Frozen Chest
                        }
                        else if (player.ZoneOverworldHeight && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 831, 1, false, -1, false, false); //Living Wood Chest
                        else if ((player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight) && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 306, 1, false, -1, false, false); //Gold Chest
                        else if (player.ZoneSkyHeight && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 838, 1, false, -1, false, false); //Skyware Chest
                        if ((npc.type == 57 || npc.type == 58 || (npc.type >= 63 && npc.type <= 65) || npc.type == 67 || npc.type == 102 || npc.type == 103 || npc.type == 157 || npc.type == 220 || npc.type == 221 || npc.type == 241 || npc.type == 242 || npc.type == 256 || npc.type == 465) && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop) //Water Enemies (https://terraria.gamepedia.com/Water#Contents)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1298, 1, false, -1, false, false); //Water Chest
                        if (((npc.type >= 163 && npc.type <= 165) || npc.type == 238) && Main.rand.NextFloat() < GetInstance<AEnemyDropConfig>().AllEnemiesLootBiomeMatchingFoundOnlyChestDrop) //Spider Nest Enemies
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 952, 1, false, -1, false, false); //Web Covered Chest
                    }

                    //Modded Loot
                    float lockboxDropModdifier = 0.0f;
                    if (Main.hardMode)
                        lockboxDropModdifier = GetInstance<GLockbBoxConfig>().HardmodeModdedLockBoxDropRateModifier;
                    else
                        lockboxDropModdifier = GetInstance<GLockbBoxConfig>().NormalmodeModdedLockBoxDropRateModifier;

                    if (GetInstance<GLockbBoxConfig>().LockBoxesGiveNonFurniture && (npc.type == 57 || npc.type == 58 || (npc.type >= 63 && npc.type <= 65) || npc.type == 67 || npc.type == 102 || npc.type == 103 || npc.type == 157 || npc.type == 220 || npc.type == 221 || npc.type == 241 || npc.type == 242 || npc.type == 256 || npc.type == 465)) //Water Enemies (https://terraria.gamepedia.com/Water#Contents)
                    {
                        if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().WaterEnemyModdedWaterLockBoxLoot * lockboxDropModdifier)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.LockBoxes.Water_Lock_Box>(), 1, false, -1, false, false);
                    }
                    else if (npc.type == 48) //Harpy
                    {
                        if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().SkyModdedSkywareLockBoxLoot * lockboxDropModdifier)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.LockBoxes.Skyware_Lock_Box>(), 1, false, -1, false, false);
                    }
                    else if (GetInstance<GLockbBoxConfig>().LockBoxesGiveNonFurniture && ((npc.type >= 163 && npc.type <= 165) || npc.type == 238)) //Spider Nest Enemies
                    {
                        if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().SpiderNestWebCoveredLockBoxLoot * lockboxDropModdifier)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.LockBoxes.Web_Covered_Lock_Box>(), 1, false, -1, false, false);
                    }
                    else if (player.ZoneDungeon)
                    {
                        if (GetInstance<GLockbBoxConfig>().LockBoxesGiveFurniture)
                        {
                            if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().DungeonFurnitureLockBoxLoot * lockboxDropModdifier)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.LockBoxes.Blue_Dungeon_Lock_Box>(), 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().DungeonFurnitureLockBoxLoot * lockboxDropModdifier)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.LockBoxes.Green_Dungeon_Lock_Box>(), 1, false, -1, false, false);
                            if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().DungeonFurnitureLockBoxLoot * lockboxDropModdifier)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.LockBoxes.Pink_Dungeon_Lock_Box>(), 1, false, -1, false, false);
                        }
                        if (GetInstance<GLockbBoxConfig>().LockBoxesGiveNonFurniture && NPC.downedPlantBoss)
                        {
                            if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().DungeonModdedBiomeLockBoxLoot * lockboxDropModdifier)
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.LockBoxes.Biome_Lock_Box>(), 1, false, -1, false, false);
                        }
                    }
                    else if (player.ZoneUnderworldHeight)
                    {
                        if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().HellBiomeModdedShadowLockBoxLoot * lockboxDropModdifier)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.LockBoxes.Shadow_Lock_Box>(), 1, false, -1, false, false);
                    }
                    else if (player.ZoneSnow && player.ZoneRockLayerHeight)
                    {
                        if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().UndergroundSnowBiomeModdedIceLockBoxLoot * lockboxDropModdifier)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.LockBoxes.Ice_Lock_Box>(), 1, false, -1, false, false);
                    }
                    else if (player.ZoneJungle && player.ZoneRockLayerHeight)
                    {
                        if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().UndergroundJungleBiomeModdedIvyLockBoxLoot * lockboxDropModdifier)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.LockBoxes.Ivy_Lock_Box>(), 1, false, -1, false, false);
                    }
                    else if (player.ZoneSandstorm || player.ZoneUndergroundDesert)
                    {
                        if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().SandstormAndUndergroundDesertPyramidLockBoxLoot * lockboxDropModdifier)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.LockBoxes.Pyramid_Lock_Box>(), 1, false, -1, false, false);
                    }
                    else if (Main.tile[npcTileX, npcTileY].wall == WallID.LihzahrdBrickUnsafe && NPC.downedPlantBoss) //Lihzahrd Temple Enemies
                    {
                        if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().JungleTempleLihzahrd_Lock_Box * lockboxDropModdifier)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.LockBoxes.Lihzahrd_Lock_Box>(), 1, false, -1, false, false);
                    }
                    else if (player.ZoneOverworldHeight)
                    {
                        if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().SurfaceModdedLivingWoodLockBoxLoot * lockboxDropModdifier)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.LockBoxes.Living_Wood_Lock_Box>(), 1, false, -1, false, false);
                    }
                    else if (player.ZoneDirtLayerHeight)
                    {
                        if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().CavernModdedCavernLockBoxLoot * lockboxDropModdifier)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.LockBoxes.Underground_Lock_Box>(), 1, false, -1, false, false);
                    }
                    else if (player.ZoneRockLayerHeight)
                    {
                        if (Main.rand.NextFloat() < GetInstance<GLockbBoxConfig>().CavernModdedCavernLockBoxLoot * lockboxDropModdifier)
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.LockBoxes.Cavern_Lock_Box>(), 1, false, -1, false, false);
                    }
                }
            }
        }*/
    }

    class SpawnRateMultiplierGlobalNPC : GlobalNPC
    {
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {

            if (player.FindBuffIndex(ModContent.BuffType<Buffs.War>()) != -1)
            {
                spawnRate = (int)(spawnRate / GetInstance<HOtherModdedItemsConfig>().WarPotionSpawnrateMultiplier);
                maxSpawns = (int)(maxSpawns * GetInstance<HOtherModdedItemsConfig>().WarPotionMaxSpawnsMultiplier);
            }
            if (player.FindBuffIndex(ModContent.BuffType<Buffs.Chaos>()) != -1)
            {
                spawnRate = (int)(spawnRate / GetInstance<HOtherModdedItemsConfig>().ChaosPotionSpawnrateMultiplier);
                maxSpawns = (int)(maxSpawns * GetInstance<HOtherModdedItemsConfig>().ChaosPotionMaxSpawnsMultiplier);
            }
        }
    }

    enum ReducedGrindingMessageType : byte
    {
        advanceMoonPhase
    }

}