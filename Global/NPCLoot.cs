using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ReducedGrinding.Common.ItemDropRules.Conditions;
using ReducedGrinding;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;

namespace ReducedGrinding.Global
{
    public class NPCLoot : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, Terraria.ModLoader.NPCLoot npcLoot)
        {
            if (npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.type != NPCID.Slimer && npc.value > 0f)
                return;

            void try_loot(int itemType, int denominator)
            {
                if (denominator > 0)
                    npcLoot.Add(ItemDropRule.Common(itemType, denominator));
            }

            void try_loot_max_min(int itemType, int[] config)
            {
                if (config.Max() > 0 && config.Min() >= 0)
                    npcLoot.Add(ItemDropRule.Common(itemType, 1, config.Min(), config.Max()));
            }

            void try_boss_loot(int itemType, int denominator)
            {
                if (denominator > 0)
                    npcLoot.Add(new DropBasedOnExpertMode(ItemDropRule.Common(itemType, denominator), ItemDropRule.DropNothing()));
            }

            void try_boss_loot_eater_of_worlds(int itemType, int denominator)
            {
                if (denominator > 0)
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.LegacyHack_IsBossAndNotExpert(), itemType, denominator));
            }

            void try_boss_loot_twins(int itemType, int denominator)
            {
                IItemDropRule ruleMissingTwin = new LeadingConditionRule(new Conditions.MissingTwin());
                ruleMissingTwin.OnSuccess(new DropBasedOnExpertMode(ItemDropRule.Common(itemType, denominator), ItemDropRule.DropNothing()));
                if (denominator > 0)
                    npcLoot.Add(ruleMissingTwin);
            }

            void try_conditional_loot_max_min(int itemType, IItemDropRuleCondition condition, int[] config)
            {
                if (config.Max() > 0 && config.Min() >= 0)
                {
                    IItemDropRule conditionalRule = new LeadingConditionRule(condition);

                    IItemDropRule rule = ItemDropRule.Common(itemType, 1, config.Min(), config.Max());

                    conditionalRule.OnSuccess(rule);

                    npcLoot.Add(conditionalRule);
                }
            }

            bool npc_is_any_types(params int[] types)
            {
                bool matches = false;
                for (int i = 0; i < types.Length; i++)
                {
                    if (npc.type == types[i])
                    {
                        matches = true;
                        break;
                    }
                }
                return matches;
            }

            //Boss Drops
            if (npc.type == NPCID.BrainofCthulhu)
            {
                try_boss_loot(ItemID.BoneRattle, GetInstance<AEnemyLootConfig>().LootBoneRattleIncrease);
                try_boss_loot(ItemID.BrainMask, GetInstance<AEnemyLootConfig>().LootBossMaskIncrease);
            }
            if (npc.type == NPCID.DD2Betsy)
            {
                try_boss_loot(ItemID.BossMaskBetsy, GetInstance<AEnemyLootConfig>().LootBossMaskIncrease);
            }
            if (npc.type == NPCID.DukeFishron)
            {
                try_boss_loot(ItemID.FishronWings, GetInstance<AEnemyLootConfig>().LootFishronWingsIncrease);
                try_boss_loot(ItemID.TruffleWorm, GetInstance<AEnemyLootConfig>().LootFishronTruffleworm);
                try_boss_loot(ItemID.DukeFishronMask, GetInstance<AEnemyLootConfig>().LootBossMaskIncrease);
            }
            if (npc_is_any_types(NPCID.EaterofWorldsBody, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail))
            {
                try_boss_loot_eater_of_worlds(ItemID.EatersBone, GetInstance<AEnemyLootConfig>().LootEatersBoneIncrease);
                try_boss_loot_eater_of_worlds(ItemID.EaterMask, GetInstance<AEnemyLootConfig>().LootBossMaskIncrease);
            }
            if (npc.type == NPCID.EyeofCthulhu)
            {
                try_boss_loot(ItemID.Binoculars, GetInstance<AEnemyLootConfig>().LootBinocularsIncrease);
                try_boss_loot(ItemID.EyeMask, GetInstance<AEnemyLootConfig>().LootBossMaskIncrease);
            }
            if (npc.type == NPCID.Plantera)
            {
                try_boss_loot(ItemID.TheAxe, GetInstance<AEnemyLootConfig>().LootTheAxeIncrease);
                try_boss_loot(ItemID.Seedling, GetInstance<AEnemyLootConfig>().LootSeedlingIncrease);
                try_boss_loot(ItemID.PlanteraMask, GetInstance<AEnemyLootConfig>().LootBossMaskIncrease);
            }
            if (npc.type == NPCID.QueenBee)
            {
                try_boss_loot(ItemID.HoneyedGoggles, GetInstance<AEnemyLootConfig>().LootHoneyedGogglesIncrease);
                try_boss_loot(ItemID.Nectar, GetInstance<AEnemyLootConfig>().LootNectarIncrease);
                try_boss_loot(ItemID.BeeMask, GetInstance<AEnemyLootConfig>().LootBossMaskIncrease);
            }
            if (npc.type == NPCID.MoonLordCore)
            {
                try_boss_loot(ItemID.BossMaskMoonlord, GetInstance<AEnemyLootConfig>().LootBossMaskIncrease);
                try_boss_loot(ItemID.Meowmere, GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease);
                try_boss_loot(ItemID.Terrarian, GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease);
                try_boss_loot(ItemID.StarWrath, GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease);
                try_boss_loot(ItemID.SDMG, GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease);
                try_boss_loot(ItemID.FireworksLauncher, GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease);
                try_boss_loot(ItemID.LastPrism, GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease);
                try_boss_loot(ItemID.LunarFlareBook, GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease);
                try_boss_loot(ItemID.RainbowCrystalStaff, GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease);
                try_boss_loot(ItemID.MoonlordTurretStaff, GetInstance<AEnemyLootConfig>().LootMoonLordEachWeaponIncrease);
            }
            if (npc.type == NPCID.SkeletronHead)
            {
                try_boss_loot(ItemID.BookofSkulls, GetInstance<AEnemyLootConfig>().LootBookofSkullsIncrease);
                try_boss_loot(ItemID.BoneKey, GetInstance<AEnemyLootConfig>().LootSkeletronBoneKey);
                try_boss_loot(ItemID.SkeletronMask, GetInstance<AEnemyLootConfig>().LootBossMaskIncrease);
            }
            if (npc.type == NPCID.KingSlime)
            {
                try_boss_loot(ItemID.KingSlimeMask, GetInstance<AEnemyLootConfig>().LootBossMaskIncrease);
            }
            if (npc.type == NPCID.WallofFlesh)
            {
                try_boss_loot(ItemID.FleshMask, GetInstance<AEnemyLootConfig>().LootBossMaskIncrease);
            }
            if (npc.type == NPCID.TheDestroyer)
            {
                try_boss_loot(ItemID.DestroyerMask, GetInstance<AEnemyLootConfig>().LootBossMaskIncrease);
            }
            if (npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism)
            {
                try_boss_loot_twins(ItemID.TwinMask, GetInstance<AEnemyLootConfig>().LootBossMaskIncrease);
            }
            if (npc.type == NPCID.SkeletronPrime)
            {
                try_boss_loot(ItemID.SkeletronPrimeMask, GetInstance<AEnemyLootConfig>().LootBossMaskIncrease);
            }
            if (npc.type == NPCID.Golem)
            {
                try_boss_loot(ItemID.GolemMask, GetInstance<AEnemyLootConfig>().LootBossMaskIncrease);
                try_boss_loot(ItemID.Picksaw, GetInstance<AEnemyLootConfig>().LootPicksawIncrease);
            }

            //Non-Boss Drops
            if (npc.type == NPCID.ChaosElemental)
                try_loot(ItemID.RodofDiscord, GetInstance<AEnemyLootConfig>().LootRodofDiscordIncrease);
            if (npc.type == NPCID.TacticalSkeleton)
                try_loot(ItemID.SWATHelmet, GetInstance<AEnemyLootConfig>().LootSWATHelmetIncrease);
            if (npc.type == NPCID.AnglerFish || npc.type == NPCID.Piranha)
                try_loot(ItemID.RobotHat, GetInstance<AEnemyLootConfig>().LootRobotHatIncrease);
            if (npc.type == NPCID.ChaosElemental)
                try_loot(ItemID.RodofDiscord, GetInstance<AEnemyLootConfig>().LootRodofDiscordIncrease);
            if (npc.type == NPCID.Clown || npc.type == NPCID.LightMummy || npc.type == NPCID.GiantBat)
                try_loot(ItemID.TrifoldMap, GetInstance<AEnemyLootConfig>().LootTrifoldMapIncrease);
            if (npc.type == NPCID.Clown)
                try_loot(ItemID.Bananarang, GetInstance<AEnemyLootConfig>().LootBananarangIncrease);
            if (npc.type == NPCID.Hornet || (npc.type >= 231 && npc.type <= 235)) //Hornet Variants
            {
                try_loot(ItemID.AncientCobaltHelmet, GetInstance<AEnemyLootConfig>().LootAncientCobaltHelmetIncrease);
                try_loot(ItemID.AncientCobaltBreastplate, GetInstance<AEnemyLootConfig>().LootAncientCobaltBreastplateIncrease);
                try_loot(ItemID.AncientCobaltLeggings, GetInstance<AEnemyLootConfig>().LootAncientCobaltLeggingsIncrease);
            }
            if (npc.type == NPCID.MossHornet)
            {
                try_loot(ItemID.TatteredBeeWing, GetInstance<AEnemyLootConfig>().LootTatteredBeeWingIncrease);
            }
            if (npc_is_any_types(NPCID.Lihzahrd, NPCID.LihzahrdCrawler, NPCID.FlyingSnake))
            {
                try_loot(ItemID.LizardEgg, GetInstance<AEnemyLootConfig>().LootLizardEggIncrease);
                try_loot(ItemID.LihzahrdPowerCell, GetInstance<AEnemyLootConfig>().LootLihzahrdPowerCellIncrease);
            }
            if (npc.type == NPCID.GiantTortoise)
            {
                try_loot(ItemID.TurtleShell, GetInstance<AEnemyLootConfig>().LootTurtleShellIncrease);
            }
            if (npc.type == NPCID.IceTortoise)
            {
                try_loot(ItemID.FrozenTurtleShell, GetInstance<AEnemyLootConfig>().LootFrozenTurtleShellIncrease);
            }
            if (npc.type == NPCID.Paladin)
            {
                try_loot(ItemID.PaladinsShield, GetInstance<AEnemyLootConfig>().LootPaladinsShieldIncrease);
            }
            if (npc_is_any_types(212, 213, 214, 215, 216, 491)) //All Human Pirates and Flying Dutchman
            {
                /*
                 * TO-DO 1.4.4 is going to boost drop rates. I've adjusted multipliers to the new rates, but when the udpate comes out. Look into the new coding.
                 * So far, it's unknown exactly how the Flying Dutchman rates will be. I've added coding to double the vanilla denominator below. In 1.4.4 the Flying Dutchman always drops 1 furniture; I tried to mimic this with a "drop 1 of the following" condition, but it didn't work.
                 */
                float denominator_multiplier = 10;
                if (npc.type == NPCID.PirateCaptain)
                    denominator_multiplier = 2.5f;
                else if (npc.type == NPCID.PirateShip)
                    denominator_multiplier = 1;

                if (npc_is_any_types(212, 213, 214, 215, 216))
                {
                    foreach (var rule in npcLoot.Get())
                    {
                        if (rule is CommonDrop commonDrop && (commonDrop.itemId == ItemID.CoinGun || commonDrop.itemId == ItemID.CoinGun || commonDrop.itemId == ItemID.CoinGun || commonDrop.itemId == ItemID.LuckyCoin || commonDrop.itemId == ItemID.DiscountCard || commonDrop.itemId == ItemID.PirateStaff || commonDrop.itemId == ItemID.GoldRing || commonDrop.itemId == ItemID.Cutlass))
                            commonDrop.chanceDenominator /= 2;
                    }
                }

                if (npc.type == NPCID.PirateShip)
                    npcLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, 1704, 1705, 1710, 1716, 1720, 2133, 2137, 2143, 2147, 2151, 2155, 2238, 2379, 2389, 2405, 2663, 2843, 3885, 3904, 3910)); //Golden Furniture

                try_loot(ItemID.CoinGun, (int)(GetInstance<AEnemyLootConfig>().PirateLootCoinGunBaseIncrease * denominator_multiplier));
                try_loot(ItemID.LuckyCoin, (int)(GetInstance<AEnemyLootConfig>().PirateLootLuckyCoinBaseIncrease * denominator_multiplier));
                try_loot(ItemID.DiscountCard, (int)(GetInstance<AEnemyLootConfig>().PirateLootDiscountCardBaseIncrease * denominator_multiplier));
                try_loot(ItemID.PirateStaff, (int)(GetInstance<AEnemyLootConfig>().PirateLootPirateStaffBaseIncrease * denominator_multiplier));
                try_loot(ItemID.GoldRing, (int)(GetInstance<AEnemyLootConfig>().PirateLootGoldRingBaseIncrease * denominator_multiplier));
                try_loot(ItemID.Cutlass, (int)(GetInstance<AEnemyLootConfig>().PirateLootCutlassBaseIncrease * denominator_multiplier));
                if (npc_is_any_types(212, 213, 214, 215))
                {
                    int gold_furniture_config = GetInstance<AEnemyLootConfig>().LootGoldenFurnitureIncrease;
                    int sailor_outfit_config = GetInstance<AEnemyLootConfig>().LootSailorOutfitIncrease;

                    try_loot(ItemID.GoldenChair, gold_furniture_config);
                    try_loot(ItemID.GoldenToilet, gold_furniture_config);
                    try_loot(ItemID.GoldenDoor, gold_furniture_config);
                    try_loot(ItemID.GoldenTable, gold_furniture_config);
                    try_loot(ItemID.GoldenBed, gold_furniture_config);
                    try_loot(ItemID.GoldenPiano, gold_furniture_config);
                    try_loot(ItemID.GoldenDresser, gold_furniture_config);
                    try_loot(ItemID.GoldenSofa, gold_furniture_config);
                    try_loot(ItemID.GoldenBathtub, gold_furniture_config);
                    try_loot(ItemID.GoldenClock, gold_furniture_config);
                    try_loot(ItemID.GoldenLamp, gold_furniture_config);
                    try_loot(ItemID.GoldenBookcase, gold_furniture_config);
                    try_loot(ItemID.GoldenChandelier, gold_furniture_config);
                    try_loot(ItemID.GoldenLantern, gold_furniture_config);
                    try_loot(ItemID.GoldenCandelabra, gold_furniture_config);
                    try_loot(ItemID.GoldenCandle, gold_furniture_config);
                    try_loot(ItemID.GoldenSink, gold_furniture_config);

                    try_loot(ItemID.SailorHat, sailor_outfit_config);
                    try_loot(ItemID.SailorShirt, sailor_outfit_config);
                    try_loot(ItemID.SailorPants, sailor_outfit_config);
                    try_loot(ItemID.EyePatch, sailor_outfit_config);
                }
            }
            if ((npc.type == NPCID.ZombieElf || npc.type == NPCID.ZombieElfBeard || npc.type == NPCID.ZombieElfGirl))
            {
                try_loot(ItemID.ElfHat, GetInstance<AEnemyLootConfig>().LootElfHatIncrease);
                try_loot(ItemID.ElfShirt, GetInstance<AEnemyLootConfig>().LootElfShirtIncrease);
                try_loot(ItemID.ElfPants, GetInstance<AEnemyLootConfig>().LootElfPantsIncrease);
            }
            if (npc.type >= 269 && npc.type <= 280)//All Armored Bones variants
            {
                try_loot(ItemID.WispinaBottle, GetInstance<AEnemyLootConfig>().LootWispinaBottleIncrease);
                try_loot(ItemID.BoneFeather, GetInstance<AEnemyLootConfig>().LootBoneFeatherIncrease);
                try_loot(ItemID.MagnetSphere, GetInstance<AEnemyLootConfig>().LootMagnetSphereIncrease);
                try_loot(ItemID.Keybrand, GetInstance<AEnemyLootConfig>().LootKeybrandIncrease);
            }
            if (npc.type == NPCID.EaterofSouls)
            {
                try_loot(ItemID.AncientShadowHelmet, GetInstance<AEnemyLootConfig>().LootAncientShadowHelmetIncrease);
                try_loot(ItemID.AncientShadowScalemail, GetInstance<AEnemyLootConfig>().LootAncientShadowScalemailIncrease);
                try_loot(ItemID.AncientShadowGreaves, GetInstance<AEnemyLootConfig>().LootAncientShadowGreavesIncrease);
            }
            if (npc_is_any_types(21, 201, 202, 203, 322, 323, 324, 635, 449, 450, 451, 452)) //Skeletons
            {
                try_loot(ItemID.Skull, GetInstance<AEnemyLootConfig>().LootSkullIncrease);
                try_loot(ItemID.BoneSword, GetInstance<AEnemyLootConfig>().LootBoneSwordIncrease);
                try_loot(ItemID.AncientGoldHelmet, GetInstance<AEnemyLootConfig>().LootAncientGoldHelmetIncrease);
                try_loot(ItemID.AncientIronHelmet, GetInstance<AEnemyLootConfig>().LootAncientIronHelmetIncrease);
            }
            if (npc_is_any_types(31, 32, 294, 295, 296))
            {
                try_loot(ItemID.AncientNecroHelmet, GetInstance<AEnemyLootConfig>().LootAncientNecroHelmetIncrease);
                try_loot(ItemID.ClothierVoodooDoll, GetInstance<AEnemyLootConfig>().LootClothierVoodooDollIncrease);
                try_loot(ItemID.BoneWand, GetInstance<AEnemyLootConfig>().LootBoneWandIncrease);
            }
            if (npc.type == NPCID.ManEater)
            {
                try_loot(ItemID.AncientCobaltHelmet, GetInstance<AEnemyLootConfig>().LootAncientCobaltHelmetIncrease);
                try_loot(ItemID.AncientCobaltBreastplate, GetInstance<AEnemyLootConfig>().LootAncientCobaltBreastplateIncrease);
                try_loot(ItemID.AncientCobaltLeggings, GetInstance<AEnemyLootConfig>().LootAncientCobaltLeggingsIncrease);
            }
            if (npc.type == NPCID.FireImp)
            {
                try_loot(ItemID.PlumbersHat, GetInstance<AEnemyLootConfig>().LootPlumbersHatIncrease);
                try_loot(ItemID.ObsidianRose, GetInstance<AEnemyLootConfig>().LootObsidianRoseIncrease);
            }
            if (npc.type == NPCID.CursedSkull || npc.type == NPCID.DarkCaster)
            {
                try_loot(ItemID.BoneWand, GetInstance<AEnemyLootConfig>().LootBoneWandIncrease);
            }
            if (npc.type == NPCID.CaveBat)
            {
                try_loot(ItemID.ChainKnife, GetInstance<AEnemyLootConfig>().LootChainKnifeIncrease);
            }
            if (npc.type == NPCID.Reaper)
            {
                try_loot(ItemID.DeathSickle, GetInstance<AEnemyLootConfig>().LootDeathSickleIncrease);
            }
            if (npc_is_any_types(3, 591, 590, 331, 332, 132, 161, 186, 187, 188, 189, 200, 223, 319, 320, 321, 430, 431, 432, 433, 434, 435, 436)) //Basic Zombies
            {
                try_loot(ItemID.ZombieArm, GetInstance<AEnemyLootConfig>().LootZombieArmIncrease);
                try_loot(ItemID.Shackle, GetInstance<AEnemyLootConfig>().LootShackleIncrease);
            }
            if (npc.type == NPCID.Unicorn)
                try_loot(ItemID.BlessedApple, GetInstance<AEnemyLootConfig>().LootBlessedAppleIncrease);
            if (npc.type == NPCID.Mimic)
            {
                try_loot(ItemID.DualHook, GetInstance<AEnemyLootConfig>().LootDualHookIncrease);
                try_loot(ItemID.MagicDagger, GetInstance<AEnemyLootConfig>().LootMagicDaggerIncrease);
                try_loot(ItemID.TitanGlove, GetInstance<AEnemyLootConfig>().LootTitanGloveIncrease);
                try_loot(ItemID.PhilosophersStone, GetInstance<AEnemyLootConfig>().LootPhilosophersStoneIncrease);
                try_loot(ItemID.CrossNecklace, GetInstance<AEnemyLootConfig>().LootCrossNecklaceIncrease);
                try_loot(ItemID.StarCloak, GetInstance<AEnemyLootConfig>().LootStarCloakIncrease);
            }
            if (npc.type == NPCID.BigMimicCorruption)
            {
                try_loot(ItemID.DartRifle, GetInstance<AEnemyLootConfig>().LootDartRifleIncrease);
                try_loot(ItemID.WormHook, GetInstance<AEnemyLootConfig>().LootWormHookIncrease);
                try_loot(ItemID.ChainGuillotines, GetInstance<AEnemyLootConfig>().LootChainGuillotinesIncrease);
                try_loot(ItemID.ClingerStaff, GetInstance<AEnemyLootConfig>().LootClingerStaffIncrease);
                try_loot(ItemID.PutridScent, GetInstance<AEnemyLootConfig>().LootPutridScentIncrease);
            }
            if (npc.type == NPCID.BigMimicCrimson)
            {
                try_loot(ItemID.SoulDrain, GetInstance<AEnemyLootConfig>().LootLifeDrainIncrease);
                try_loot(ItemID.DartPistol, GetInstance<AEnemyLootConfig>().LootDartPistolIncrease);
                try_loot(ItemID.FetidBaghnakhs, GetInstance<AEnemyLootConfig>().LootFetidBaghnakhsIncrease);
                try_loot(ItemID.FleshKnuckles, GetInstance<AEnemyLootConfig>().LootFleshKnucklesIncrease);
                try_loot(ItemID.TendonHook, GetInstance<AEnemyLootConfig>().LootTendonHookIncrease);
            }
            if (npc.type == NPCID.BigMimicHallow)
            {
                try_loot(ItemID.DaedalusStormbow, GetInstance<AEnemyLootConfig>().LootDaedalusStormbowIncrease);
                try_loot(ItemID.FlyingKnife, GetInstance<AEnemyLootConfig>().LootFlyingKnifeIncrease);
                try_loot(ItemID.CrystalVileShard, GetInstance<AEnemyLootConfig>().LootCrystalVileShardIncrease);
                try_loot(ItemID.IlluminantHook, GetInstance<AEnemyLootConfig>().LootIlluminantHookIncrease);
            }
            if (npc.type == NPCID.Harpy)
            {
                try_loot(ItemID.GiantHarpyFeather, GetInstance<AEnemyLootConfig>().LootGiantHarpyFeatherIncrease);
                try_loot(ItemID.Cloud, GetInstance<AEnemyLootConfig>().LootCloudFromHarpies);
            }
            if ((npc.type >= 26 && npc.type <= 29) || npc.type == 111) //Goblin Army (Excluding Summoner)
            {
                try_loot(ItemID.Harpoon, GetInstance<AEnemyLootConfig>().LootHarpoonIncrease);
            }
            if (npc.type == NPCID.ArmoredViking || npc.type == NPCID.IceElemental || npc.type == NPCID.IcyMerman || npc.type == NPCID.IceTortoise)
            {
                try_loot(ItemID.IceSickle, GetInstance<AEnemyLootConfig>().LootIceSickleIncrease);
            }
            if (npc.type == NPCID.SkeletonArcher)
            {
                try_loot(ItemID.Marrow, GetInstance<AEnemyLootConfig>().LootMarrowIncrease);
                try_loot(ItemID.MagicQuiver, GetInstance<AEnemyLootConfig>().LootMagicQuiverIncrease);
            }
            if (npc.type == NPCID.Crimslime || npc.type == NPCID.CrimsonAxe || npc.type == NPCID.FloatyGross || npc.type == NPCID.Herpling)
            {
                try_loot(ItemID.MeatGrinder, GetInstance<AEnemyLootConfig>().LootMeatGrinderIncrease);
            }
            if (npc.type == NPCID.AngryTrapper)
            {
                try_loot(ItemID.Uzi, GetInstance<AEnemyLootConfig>().LootUziIncrease);
            }
            if (npc.type == NPCID.ArmoredSkeleton)
            {
                try_loot(ItemID.BeamSword, GetInstance<AEnemyLootConfig>().LootBeamSwordIncrease);
            }
            if (npc_is_any_types(2, 317, 318, 190, 191, 192, 193, 194, 133)) //Demon Eye Variants and Wandering Eye
            {
                try_loot(ItemID.BlackLens, GetInstance<AEnemyLootConfig>().LootBlackLensIncrease);
            }
            if (npc.type == NPCID.ZombieEskimo || npc.type == NPCID.ArmedZombieEskimo)
            {
                try_loot(ItemID.EskimoHood, GetInstance<AEnemyLootConfig>().LootEskimoHoodIncrease);
                try_loot(ItemID.EskimoCoat, GetInstance<AEnemyLootConfig>().LootEskimoCoatIncrease);
                try_loot(ItemID.EskimoPants, GetInstance<AEnemyLootConfig>().LootEskimoPantsIncrease);
            }
            if (npc.type == NPCID.Hellbat)
            {
                try_loot(ItemID.MagmaStone, GetInstance<AEnemyLootConfig>().HellBatLootMagmaStoneIncrease);
            }
            if (npc.type == NPCID.Lavabat)
            {
                try_loot(ItemID.MagmaStone, GetInstance<AEnemyLootConfig>().LavaBatLootMagmaStoneIncrease);
            }
            if (npc.type == NPCID.SnowFlinx)
            {
                try_loot(ItemID.SnowballLauncher, GetInstance<AEnemyLootConfig>().LootSnowballLauncherIncrease);
            }
            if (npc.type == NPCID.ScutlixRider)
            {
                try_loot(ItemID.BrainScrambler, GetInstance<AEnemyLootConfig>().LootBrainScramblerIncrease);
            }
            if (npc_is_any_types(63, 64, 103)) //Basic Jellyfish
            {
                try_loot(ItemID.JellyfishNecklace, GetInstance<AEnemyLootConfig>().LootJellyfishNecklaceIncrease);
            }
            if (npc.type == NPCID.DesertLamiaLight || npc.type == NPCID.DesertLamiaDark)
            {
                try_loot(ItemID.LamiaHat, GetInstance<AEnemyLootConfig>().LootLamiaClothesIncrease);
                try_loot(ItemID.LamiaPants, GetInstance<AEnemyLootConfig>().LootLamiaClothesIncrease);
                try_loot(ItemID.LamiaShirt, GetInstance<AEnemyLootConfig>().LootLamiaClothesIncrease);
            }
            if (npc.type == NPCID.Vampire)
            {
                try_loot(ItemID.MoonStone, GetInstance<AEnemyLootConfig>().LootMoonStoneIncrease);
            }
            if (npc.type == NPCID.RedDevil)
            {
                try_loot(ItemID.FireFeather, GetInstance<AEnemyLootConfig>().LootFireFeatherIncrease);
            }
            if (npc_is_any_types(-4, 1, 16, 138, 141, 147, 184, 187, 433, 204, 302, 333, 334, 335, 336, 535, 658, 659, 660, -6, -7, -8, -9, 537)) //Slimestaff Slimes
            {
                int slimestaffmultiplier = 100;
                if (npc.type == NPCID.Pinky)
                    slimestaffmultiplier = 1;
                if (npc.type == NPCID.SandSlime)
                    slimestaffmultiplier = 80;
                try_loot(ItemID.SlimeStaff, GetInstance<AEnemyLootConfig>().LootSlimeStaffIncrease * slimestaffmultiplier);
            }
            if (npc.type == NPCID.Unicorn)
            {
                try_loot(ItemID.UnicornonaStick, GetInstance<AEnemyLootConfig>().LootUnicornonaStickIncrease);
            }
            if (npc.type == NPCID.DiggerHead || npc.type == NPCID.GiantWormHead)
            {
                try_loot(ItemID.WhoopieCushion, GetInstance<AEnemyLootConfig>().LootWhoopieCushionIncrease);
            }
            if (npc.type == NPCID.UndeadMiner)
            {
                try_loot(ItemID.BonePickaxe, GetInstance<AEnemyLootConfig>().LootBonePickaxeIncrease);
                try_loot(ItemID.MiningHelmet, GetInstance<AEnemyLootConfig>().LootMiningHelmetIncrease);
                try_loot(ItemID.MiningShirt, GetInstance<AEnemyLootConfig>().LootMiningShirtIncrease);
                try_loot(ItemID.MiningPants, GetInstance<AEnemyLootConfig>().LootMiningPantsIncrease);
            }
            if (npc.type == NPCID.Psycho)
            {
                try_loot(ItemID.PsychoKnife, GetInstance<AEnemyLootConfig>().LootPsychoKnifeIncrease);
            }
            if (npc.type == NPCID.CorruptBunny)
            {
                try_loot(ItemID.BunnyHood, GetInstance<AEnemyLootConfig>().LootBunnyHoodIncrease);
            }
            if (npc.type >= 78 && npc.type <= 80) //Mummies
            {
                try_loot(ItemID.MummyMask, GetInstance<AEnemyLootConfig>().LootMummyCostumeIncrease);
                try_loot(ItemID.MummyShirt, GetInstance<AEnemyLootConfig>().LootMummyCostumeIncrease);
                try_loot(ItemID.MummyPants, GetInstance<AEnemyLootConfig>().LootMummyCostumeIncrease);
            }
            if (npc.type == 31 || (npc.type >= 294 && npc.type <= 296) || npc.type == NPCID.CursedSkull || npc.type == NPCID.DarkCaster) //Angry Bones, Cursed Skull, and Dark Caster
            {
                try_loot(ItemID.GoldenKey, GetInstance<AEnemyLootConfig>().LootGoldenKeyIncrease);
                try_loot(ItemID.TallyCounter, GetInstance<AEnemyLootConfig>().LootTallyCounterIncrease);
            }
            if (npc.type == NPCID.IceMimic)
            {
                try_loot(ItemID.ToySled, GetInstance<AEnemyLootConfig>().LootToySledIncrease);
            }
            if (npc.type == NPCID.Werewolf)
            {
                try_loot(ItemID.MoonCharm, GetInstance<AEnemyLootConfig>().LootMoonCharmIncrease);
            }
            if (npc.type == NPCID.DesertBeast)
            {
                try_loot(ItemID.AncientHorn, GetInstance<AEnemyLootConfig>().LootAncientHornIncrease);
            }
            if (npc.type == NPCID.Demon)
            {
                try_loot(ItemID.DemonScythe, GetInstance<AEnemyLootConfig>().LootDemonScytheIncrease);
            }
            if (npc.type == NPCID.Shark)
            {
                try_loot(ItemID.DivingHelmet, GetInstance<AEnemyLootConfig>().LootDivingHelmetIncrease);
            }
            if (npc.type == NPCID.Eyezor)
            {
                try_loot(ItemID.EyeSpring, GetInstance<AEnemyLootConfig>().LootEyeSpringIncrease);
            }
            if (npc.type == NPCID.IceElemental || npc.type == NPCID.IcyMerman)
            {
                try_loot(ItemID.FrostStaff, GetInstance<AEnemyLootConfig>().LootFrostStaffIncrease);
            }
            if (npc.type == NPCID.WalkingAntlion)
            {
                try_loot(ItemID.AntlionClaw, GetInstance<AEnemyLootConfig>().LootMandibleBladeIncrease);
            }
            if (npc.type == NPCID.MeteorHead)
            {
                try_loot(ItemID.Meteorite, GetInstance<AEnemyLootConfig>().LootMeteoriteIncrease);
            }
            if (npc.type == NPCID.CorruptPenguin || npc.type == NPCID.CrimsonPenguin)
            {
                try_loot(ItemID.PedguinHat, GetInstance<AEnemyLootConfig>().LootPedguinssuitIncrease);
                try_loot(ItemID.PedguinShirt, GetInstance<AEnemyLootConfig>().LootPedguinssuitIncrease);
                try_loot(ItemID.PedguinPants, GetInstance<AEnemyLootConfig>().LootPedguinssuitIncrease);
            }
            if (npc.type == NPCID.UndeadViking)
            {
                try_loot(ItemID.VikingHelmet, GetInstance<AEnemyLootConfig>().LootVikingHelmetIncrease);
            }
            if (npc.type == NPCID.UmbrellaSlime)
            {
                try_loot(ItemID.UmbrellaHat, GetInstance<AEnemyLootConfig>().LootUmbrellaHatIncrease);
            }
            if (npc.type == NPCID.Vampire || npc.type == NPCID.VampireBat)
            {
                try_loot(ItemID.BrokenBatWing, GetInstance<AEnemyLootConfig>().LootBrokenBatWingIncrease);
            }
            if (npc.type == NPCID.DesertDjinn)
            {
                try_loot(ItemID.DjinnLamp, GetInstance<AEnemyLootConfig>().LootDesertSpiritLampIncrease);
            }
            if (npc.type == NPCID.Piranha)
            {
                try_loot(ItemID.Hook, GetInstance<AEnemyLootConfig>().LootHookIncrease);
            }
            if (npc.type == NPCID.LightMummy || npc.type == NPCID.DesertGhoulHallow || npc.type == NPCID.SandsharkHallow)
            {
                try_loot(ItemID.LightShard, GetInstance<AEnemyLootConfig>().LootLightShardIncrease);
            }
            if (npc.type == NPCID.DesertLamiaLight)
            {
                try_loot(ItemID.MoonMask, GetInstance<AEnemyLootConfig>().LootMoonMaskIncrease);
            }
            if (npc.type == NPCID.DesertLamiaDark)
            {
                try_loot(ItemID.SunMask, GetInstance<AEnemyLootConfig>().LootSunMaskIncrease);
            }
            if (npc.type >= 333 && npc.type <= 336) //Present Slimes
            {
                try_loot(ItemID.GiantBow, GetInstance<AEnemyLootConfig>().LootGiantBowIncrease);
            }
            if (npc.type == NPCID.ZombieRaincoat)
            {
                try_loot(ItemID.RainCoat, GetInstance<AEnemyLootConfig>().LootRainArmorIncrease);
                try_loot(ItemID.RainCoat, GetInstance<AEnemyLootConfig>().LootRainArmorIncrease);
            }
            if (npc.type == NPCID.SkeletonSniper)
            {
                try_loot(ItemID.SniperRifle, GetInstance<AEnemyLootConfig>().LootSniperRifleIncrease);
                try_loot(ItemID.RifleScope, GetInstance<AEnemyLootConfig>().LootRifleScopeIncrease);
            }
            if (npc.type == NPCID.TacticalSkeleton)
            {
                try_loot(ItemID.TacticalShotgun, GetInstance<AEnemyLootConfig>().LootTacticalShotgunIncrease);
                try_loot(ItemID.SWATHelmet, GetInstance<AEnemyLootConfig>().LootSWATHelmetIncrease);
            }
            if (npc.type >= 524 && npc.type <= 527) //Ghouls
            {
                try_loot(ItemID.AncientCloth, GetInstance<AEnemyLootConfig>().LootAncientClothIncrease);
            }
            if (npc.type == NPCID.DesertGhoulCorruption || npc.type == NPCID.DesertGhoulCrimson)
            {
                try_loot(ItemID.DarkShard, GetInstance<AEnemyLootConfig>().LootDarkShardIncrease);
            }
            if (npc.type == NPCID.AngryNimbus)
            {
                try_loot(ItemID.NimbusRod, GetInstance<AEnemyLootConfig>().LootNimbusRodIncrease);
            }
            if (npc.type == NPCID.BoneLee)
            {
                try_loot(ItemID.BlackBelt, GetInstance<AEnemyLootConfig>().LootBlackBeltIncrease);
                try_loot(ItemID.Tabi, GetInstance<AEnemyLootConfig>().LootTabiIncrease);
            }
            if (Main.halloween && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead)
            {
                try_loot(ItemID.GoodieBag, GetInstance<AEnemyLootConfig>().LootGoodieBagIncrease);
            }
            if (Main.xMas && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead)
            {
                try_loot(ItemID.Present, GetInstance<AEnemyLootConfig>().LootPresentIncrease);
            }
            if (npc.type == NPCID.Drippler || npc.type == NPCID.BloodZombie)
            {
                try_loot(ItemID.MoneyTrough, GetInstance<AEnemyLootConfig>().LootMoneyTroughIncrease);
            }
            if (npc.type >= 494 && npc.type <= 506) //Giant Shellies, Crawdads, and Salamanders
            {
                try_loot(ItemID.Rally, GetInstance<AEnemyLootConfig>().LootRallyIncrease);
            }
            if (npc.type == NPCID.Medusa)
            {
                try_loot(ItemID.PocketMirror, GetInstance<AEnemyLootConfig>().LootPocketMirrorIncrease);
            }
            if (npc.type == NPCID.Mothron)
            {
                try_loot(ItemID.MothronWings, GetInstance<AEnemyLootConfig>().LootMothronWingsIncrease);
            }
            if (Main.bloodMoon && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead && Main.hardMode)
            {
                try_loot(ItemID.KOCannon, GetInstance<AEnemyLootConfig>().LootKOCannonIncrease);
            }
            if (npc.type == 16 || npc.type == 58 || npc.type == 167 || npc.type == 197 || npc.type == 185 || (npc.type >= 494 && npc.type <= 506)) //Salamanders, Giant Shellys, Crawdads, Mother Slimes, Piranhas, Snow Flinxes, Undead Vikings, and Armored Vikings.
            {
                try_loot(ItemID.Compass, GetInstance<AEnemyLootConfig>().LootCompassIncrease);
            }
            if (npc.type == 49 || npc.type == 93 || npc.type == 51 || npc.type == 150 || (npc.type >= 494 && npc.type <= 506)) //Cave Bats, Giant Bats, Jungle Bats, Ice Bats, Salamanders, Giant Shellys, and Crawdads.
            {
                try_loot(ItemID.DepthMeter, GetInstance<AEnemyLootConfig>().LootDepthMeterIncrease);
            }
            if (npc.type == NPCID.Guide) //Guide NPC
            {
                try_loot(ItemID.GreenCap, GetInstance<AEnemyLootConfig>().LootGreenCapForNonAndrewGuide);
            }
            if (npc.type == NPCID.DyeTrader) //Dye Trader NPC
            {
                try_loot(ItemID.DyeTradersScimitar, GetInstance<AEnemyLootConfig>().LootExoticScimitarIncrease);
            }
            if (npc.type == NPCID.DD2Bartender) //Tavernkeep NPC
            {
                try_loot(ItemID.AleThrowingGlove, GetInstance<AEnemyLootConfig>().LootAleTosserIncrease);
            }
            if (npc.type == NPCID.Stylist) //Stylist NPC
            {
                try_loot(ItemID.StylistKilLaKillScissorsIWish, GetInstance<AEnemyLootConfig>().LootStylishScissorsIncrease);
            }
            if (npc.type == NPCID.Painter) //Painter NPC
            {
                try_loot(ItemID.PainterPaintballGun, GetInstance<AEnemyLootConfig>().LootPaintballGunIncrease);
            }
            if (npc.type == NPCID.PartyGirl) //Party Girl NPC
            {
                try_loot(ItemID.PartyGirlGrenade, GetInstance<AEnemyLootConfig>().LootHappyGrenadeIncrease);
            }
            if (npc.type == NPCID.TaxCollector) //Tax Collector Guide NPC
            {
                try_loot(ItemID.TaxCollectorsStickOfDoom, GetInstance<AEnemyLootConfig>().LootClassyCane);
            }
            if (npc.type == NPCID.RainbowSlime)
            {
                try_loot_max_min(ItemID.RainbowBrick, GetInstance<AEnemyLootConfig>().LootRainbowBrickDrop);
            }

            //Non-Boss Drops - Ankh Charm Material
            if (npc_is_any_types(104, 102, 269, 270, 271, 272))
                try_loot(ItemID.AdhesiveBandage, GetInstance<AEnemyLootConfig>().LootAdhesiveBandageIncrease);
            if (npc_is_any_types(77, 273, 274, 275, 276))
                try_loot(ItemID.ArmorPolish, GetInstance<AEnemyLootConfig>().LootArmorPolishIncrease);
            if (npc_is_any_types(141, 176, 42, 231, 232, 233, 234, 235))
                try_loot(ItemID.Bezoar, GetInstance<AEnemyLootConfig>().LootBezoarIncrease);
            if (npc_is_any_types(81, 79, 183, 630))
                try_loot(ItemID.Blindfold, GetInstance<AEnemyLootConfig>().LootBlindfoldIncrease);
            if (npc_is_any_types(78, 82, 75))
                try_loot(ItemID.FastClock, GetInstance<AEnemyLootConfig>().LootFastClockBaseIncrease);
            if (npc_is_any_types(103, 75, 79, 630))
                try_loot(ItemID.Megaphone, GetInstance<AEnemyLootConfig>().LootMegaphoneBaseIncrease);
            if (npc_is_any_types(34, 83, 84, 179, 289))
                try_loot(ItemID.Nazar, GetInstance<AEnemyLootConfig>().LootNazarIncrease);
            if (npc_is_any_types(94, 182))
                try_loot(ItemID.Vitamins, GetInstance<AEnemyLootConfig>().LootVitaminsIncrease);

            if (npc_is_any_types(93, 109, 80))
                try_loot(ItemID.TrifoldMap, GetInstance<AEnemyLootConfig>().LootTrifoldMapIncrease);

            //Drops that don't happen in vanilla
            if (npc.type == NPCID.DukeFishron)
                try_boss_loot(ItemID.TruffleWorm, GetInstance<AEnemyLootConfig>().LootFishronTruffleworm);
            if (npc.type == NPCID.DuneSplicerHead)
            {
                try_loot_max_min(ItemID.DesertFossil, GetInstance<AEnemyLootConfig>().LootDesertFossilFromDuneSplicer);
                try_conditional_loot_max_min(ItemID.SandBlock, new NoInfectionZone(), GetInstance<AEnemyLootConfig>().LootSandFromDuneSplicer);
                try_conditional_loot_max_min(ItemID.EbonsandBlock, new ZoneCorruptnNoOtherInfection(), GetInstance<AEnemyLootConfig>().LootSandFromDuneSplicer);
                try_conditional_loot_max_min(ItemID.CrimsandBlock, new ZoneCrimsonNoOtherInfection(), GetInstance<AEnemyLootConfig>().LootSandFromDuneSplicer);
                try_conditional_loot_max_min(ItemID.PearlsandBlock, new ZoneHallow(), GetInstance<AEnemyLootConfig>().LootSandFromDuneSplicer);
            }
            if (npc.type == NPCID.TombCrawlerHead)
            {
                try_loot_max_min(ItemID.DesertFossil, GetInstance<AEnemyLootConfig>().LootDesertFossilFromTombCrawler);
                try_conditional_loot_max_min(ItemID.SandBlock, new NoInfectionZone(), GetInstance<AEnemyLootConfig>().LootSandFromTombCrawler);
                try_conditional_loot_max_min(ItemID.EbonsandBlock, new ZoneCorruptnNoOtherInfection(), GetInstance<AEnemyLootConfig>().LootSandFromTombCrawler);
                try_conditional_loot_max_min(ItemID.CrimsandBlock, new ZoneCrimsonNoOtherInfection(), GetInstance<AEnemyLootConfig>().LootSandFromTombCrawler);
                try_conditional_loot_max_min(ItemID.PearlsandBlock, new ZoneHallow(), GetInstance<AEnemyLootConfig>().LootSandFromTombCrawler);
            }
            if (npc.type == NPCID.SandElemental)
            {
                try_loot(ItemID.SandstorminaBottle, GetInstance<AEnemyLootConfig>().LootSandstormInABottleFromSandElemental);
            }
        }

        public override void ModifyGlobalLoot(GlobalLoot globalLoot)
        {
            int config = GetInstance<AEnemyLootConfig>().LootBiomeKeyIncrease;
            if (config > 0)
            {
                globalLoot.Add(new ItemDropWithConditionRule(1533, config, 1, 1, new Conditions.JungleKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1534, config, 1, 1, new Conditions.CorruptKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1535, config, 1, 1, new Conditions.CrimsonKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1536, config, 1, 1, new Conditions.HallowKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1537, config, 1, 1, new Conditions.FrozenKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(4714, config, 1, 1, new Conditions.DesertKeyCondition()));
            }
            config = GetInstance<AEnemyLootConfig>().LootHelFireIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(3290, config, 1, 1, new Conditions.YoyosHelFire()));
            config = GetInstance<AEnemyLootConfig>().LootCascadeIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(3290, config, 1, 1, new Conditions.YoyoCascade()));
            config = GetInstance<AEnemyLootConfig>().LootLivingFireBlockIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(2701, config, 20, 50, new Conditions.LivingFlames()));
            config = GetInstance<AEnemyLootConfig>().LootKrakenIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(3291, config, 1, 1, new Conditions.YoyosKraken()));
            config = GetInstance<AEnemyLootConfig>().LootYeletsIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(3289, config, 1, 1, new Conditions.YoyosAmarok()));
            config = GetInstance<AEnemyLootConfig>().LootPirateMapIncrease;
            if (config > 0)
                globalLoot.Add(ItemDropRule.ByCondition(new Conditions.PirateMap(), 1315, config));
            config = GetInstance<AEnemyLootConfig>().LootSoulofLightIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(520, config, 1, 1, new Conditions.SoulOfLight()));
            config = GetInstance<AEnemyLootConfig>().LootSoulofNightIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(521, config, 1, 1, new Conditions.SoulOfNight()));
            config = GetInstance<AEnemyLootConfig>().LootAmarokIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(3289, config, 1, 1, new Conditions.YoyosAmarok()));
            config = GetInstance<AEnemyLootConfig>().LootBloodyMacheteAndBladedGlovesIncrease;
            if (config > 0)
            {
                globalLoot.Add(ItemDropRule.ByCondition(new Conditions.HalloweenWeapons(), 1825, config));
                globalLoot.Add(ItemDropRule.ByCondition(new Conditions.HalloweenWeapons(), 1827, config));
            }
        }
    }
}
