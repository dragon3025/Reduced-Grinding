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

namespace ReducedGrinding.Common.GlobalNPCs
{
    public class ReducedGrindingNPCLoot : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.type != NPCID.Slimer && npc.value > 0f)
            {
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
                    try_boss_loot(ItemID.BoneRattle, GetInstance<AEnemyDropConfig>().LootBoneRattleIncrease);
                    try_boss_loot(ItemID.BrainMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.DD2Betsy)
                {
                    try_boss_loot(ItemID.BossMaskBetsy, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.DukeFishron)
                {
                    try_boss_loot(ItemID.FishronWings, GetInstance<AEnemyDropConfig>().LootFishronWingsIncrease);
                    try_boss_loot(ItemID.TruffleWorm, GetInstance<AEnemyDropConfig>().LootFishronTruffleworm);
                    try_boss_loot(ItemID.DukeFishronMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc_is_any_types(NPCID.EaterofWorldsBody, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail))
                {
                    try_boss_loot_eater_of_worlds(ItemID.EatersBone, GetInstance<AEnemyDropConfig>().LootEatersBoneIncrease);
                    try_boss_loot_eater_of_worlds(ItemID.EaterMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.EyeofCthulhu)
                {
                    try_boss_loot(ItemID.Binoculars, GetInstance<AEnemyDropConfig>().LootBinocularsIncrease);
                    try_boss_loot(ItemID.EyeMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.Plantera)
                {
                    try_boss_loot(ItemID.TheAxe, GetInstance<AEnemyDropConfig>().LootTheAxeIncrease);
                    try_boss_loot(ItemID.Seedling, GetInstance<AEnemyDropConfig>().LootSeedlingIncrease);
                    try_boss_loot(ItemID.PlanteraMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.QueenBee)
                {
                    try_boss_loot(ItemID.HoneyedGoggles, GetInstance<AEnemyDropConfig>().LootHoneyedGogglesIncrease);
                    try_boss_loot(ItemID.Nectar, GetInstance<AEnemyDropConfig>().LootNectarIncrease);
                    try_boss_loot(ItemID.BeeMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.MoonLordCore)
                {
                    try_boss_loot(ItemID.BossMaskMoonlord, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                    try_boss_loot(ItemID.Meowmere, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    try_boss_loot(ItemID.Terrarian, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    try_boss_loot(ItemID.StarWrath, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    try_boss_loot(ItemID.SDMG, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    try_boss_loot(ItemID.FireworksLauncher, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    try_boss_loot(ItemID.LastPrism, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    try_boss_loot(ItemID.LunarFlareBook, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    try_boss_loot(ItemID.RainbowCrystalStaff, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                    try_boss_loot(ItemID.MoonlordTurretStaff, GetInstance<AEnemyDropConfig>().LootMoonLordEachWeaponIncrease);
                }
                if (npc.type == NPCID.SkeletronHead)
                {
                    try_boss_loot(ItemID.BookofSkulls, GetInstance<AEnemyDropConfig>().LootBookofSkullsIncrease);
                    try_boss_loot(ItemID.BoneKey, GetInstance<AEnemyDropConfig>().LootSkeletronBoneKey);
                    try_boss_loot(ItemID.SkeletronMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.KingSlime)
                {
                    try_boss_loot(ItemID.KingSlimeMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.WallofFlesh)
                {
                    try_boss_loot(ItemID.FleshMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.TheDestroyer)
                {
                    try_boss_loot(ItemID.DestroyerMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism)
                {
                    try_boss_loot_twins(ItemID.TwinMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.SkeletronPrime)
                {
                    try_boss_loot(ItemID.SkeletronPrimeMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                }
                if (npc.type == NPCID.Golem)
                {
                    try_boss_loot(ItemID.GolemMask, GetInstance<AEnemyDropConfig>().LootBossMaskIncrease);
                    try_boss_loot(ItemID.Picksaw, GetInstance<AEnemyDropConfig>().LootPicksawIncrease);
                }

                //Non-Boss Drops
                if (npc.type == NPCID.ChaosElemental)
                    try_loot(ItemID.RodofDiscord, GetInstance<AEnemyDropConfig>().LootRodofDiscordIncrease);
                if (npc.type == NPCID.TacticalSkeleton)
                    try_loot(ItemID.SWATHelmet, GetInstance<AEnemyDropConfig>().LootSWATHelmetIncrease);
                if (npc.type == NPCID.AnglerFish || npc.type == NPCID.Piranha)
                    try_loot(ItemID.RobotHat, GetInstance<AEnemyDropConfig>().LootRobotHatIncrease);
                if (npc.type == NPCID.ChaosElemental)
                    try_loot(ItemID.RodofDiscord, GetInstance<AEnemyDropConfig>().LootRodofDiscordIncrease);
                if (npc.type == NPCID.Clown || npc.type == NPCID.LightMummy || npc.type == NPCID.GiantBat)
                    try_loot(ItemID.TrifoldMap, GetInstance<AEnemyDropConfig>().LootTrifoldMapIncrease);
                if (npc.type == NPCID.Clown)
                    try_loot(ItemID.Bananarang, GetInstance<AEnemyDropConfig>().LootBananarangIncrease);
                if (npc.type == NPCID.Hornet || (npc.type >= 231 && npc.type <= 235)) //Hornet Variants
                {
                    try_loot(ItemID.AncientCobaltHelmet, GetInstance<AEnemyDropConfig>().LootAncientCobaltHelmetIncrease);
                    try_loot(ItemID.AncientCobaltBreastplate, GetInstance<AEnemyDropConfig>().LootAncientCobaltBreastplateIncrease);
                    try_loot(ItemID.AncientCobaltLeggings, GetInstance<AEnemyDropConfig>().LootAncientCobaltLeggingsIncrease);
                }
                if (npc.type == NPCID.MossHornet)
                {
                    try_loot(ItemID.TatteredBeeWing, GetInstance<AEnemyDropConfig>().LootTatteredBeeWingIncrease);
                }
                if (npc_is_any_types(NPCID.Lihzahrd, NPCID.LihzahrdCrawler, NPCID.FlyingSnake))
                {
                    try_loot(ItemID.LizardEgg, GetInstance<AEnemyDropConfig>().LootLizardEggIncrease);
                    try_loot(ItemID.LihzahrdPowerCell, GetInstance<AEnemyDropConfig>().LootLihzahrdPowerCellIncrease);
                }
                if (npc.type == NPCID.GiantTortoise)
                {
                    try_loot(ItemID.TurtleShell, GetInstance<AEnemyDropConfig>().LootTurtleShellIncrease);
                }
                if (npc.type == NPCID.IceTortoise)
                {
                    try_loot(ItemID.FrozenTurtleShell, GetInstance<AEnemyDropConfig>().LootFrozenTurtleShellIncrease);
                }
                if (npc.type == NPCID.Paladin)
                {
                    try_loot(ItemID.PaladinsShield, GetInstance<AEnemyDropConfig>().LootPaladinsShieldIncrease);
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

                    try_loot(ItemID.CoinGun, (int)(GetInstance<AEnemyDropConfig>().PirateLootCoinGunBaseIncrease * denominator_multiplier));
                    try_loot(ItemID.LuckyCoin, (int)(GetInstance<AEnemyDropConfig>().PirateLootLuckyCoinBaseIncrease * denominator_multiplier));
                    try_loot(ItemID.DiscountCard, (int)(GetInstance<AEnemyDropConfig>().PirateLootDiscountCardBaseIncrease * denominator_multiplier));
                    try_loot(ItemID.PirateStaff, (int)(GetInstance<AEnemyDropConfig>().PirateLootPirateStaffBaseIncrease * denominator_multiplier));
                    try_loot(ItemID.GoldRing, (int)(GetInstance<AEnemyDropConfig>().PirateLootGoldRingBaseIncrease * denominator_multiplier));
                    try_loot(ItemID.Cutlass, (int)(GetInstance<AEnemyDropConfig>().PirateLootCutlassBaseIncrease * denominator_multiplier));
                    if (npc_is_any_types(212, 213, 214, 215))
                    {
                        int gold_furniture_config = GetInstance<AEnemyDropConfig>().LootGoldenFurnitureIncrease;
                        int sailor_outfit_config = GetInstance<AEnemyDropConfig>().LootSailorOutfitIncrease;

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
                    try_loot(ItemID.ElfHat, GetInstance<AEnemyDropConfig>().LootElfHatIncrease);
                    try_loot(ItemID.ElfShirt, GetInstance<AEnemyDropConfig>().LootElfShirtIncrease);
                    try_loot(ItemID.ElfPants, GetInstance<AEnemyDropConfig>().LootElfPantsIncrease);
                }
                if (npc.type >= 269 && npc.type <= 280)//All Armored Bones variants
                {
                    try_loot(ItemID.WispinaBottle, GetInstance<AEnemyDropConfig>().LootWispinaBottleIncrease);
                    try_loot(ItemID.BoneFeather, GetInstance<AEnemyDropConfig>().LootBoneFeatherIncrease);
                    try_loot(ItemID.MagnetSphere, GetInstance<AEnemyDropConfig>().LootMagnetSphereIncrease);
                    try_loot(ItemID.Keybrand, GetInstance<AEnemyDropConfig>().LootKeybrandIncrease);
                }
                if (npc.type == NPCID.EaterofSouls)
                {
                    try_loot(ItemID.AncientShadowHelmet, GetInstance<AEnemyDropConfig>().LootAncientShadowHelmetIncrease);
                    try_loot(ItemID.AncientShadowScalemail, GetInstance<AEnemyDropConfig>().LootAncientShadowScalemailIncrease);
                    try_loot(ItemID.AncientShadowGreaves, GetInstance<AEnemyDropConfig>().LootAncientShadowGreavesIncrease);
                }
                if (npc_is_any_types(21, 201, 202, 203, 322, 323, 324, 635, 449, 450, 451, 452)) //Skeletons
                {
                    try_loot(ItemID.Skull, GetInstance<AEnemyDropConfig>().LootSkullIncrease);
                    try_loot(ItemID.BoneSword, GetInstance<AEnemyDropConfig>().LootBoneSwordIncrease);
                    try_loot(ItemID.AncientGoldHelmet, GetInstance<AEnemyDropConfig>().LootAncientGoldHelmetIncrease);
                    try_loot(ItemID.AncientIronHelmet, GetInstance<AEnemyDropConfig>().LootAncientIronHelmetIncrease);
                }
                if (npc_is_any_types(31, 32, 294, 295, 296))
                {
                    try_loot(ItemID.AncientNecroHelmet, GetInstance<AEnemyDropConfig>().LootAncientNecroHelmetIncrease);
                    try_loot(ItemID.ClothierVoodooDoll, GetInstance<AEnemyDropConfig>().LootClothierVoodooDollIncrease);
                    try_loot(ItemID.BoneWand, GetInstance<AEnemyDropConfig>().LootBoneWandIncrease);
                }
                if (npc.type == NPCID.ManEater)
                {
                    try_loot(ItemID.AncientCobaltHelmet, GetInstance<AEnemyDropConfig>().LootAncientCobaltHelmetIncrease);
                    try_loot(ItemID.AncientCobaltBreastplate, GetInstance<AEnemyDropConfig>().LootAncientCobaltBreastplateIncrease);
                    try_loot(ItemID.AncientCobaltLeggings, GetInstance<AEnemyDropConfig>().LootAncientCobaltLeggingsIncrease);
                }
                if (npc.type == NPCID.FireImp)
                {
                    try_loot(ItemID.PlumbersHat, GetInstance<AEnemyDropConfig>().LootPlumbersHatIncrease);
                    try_loot(ItemID.ObsidianRose, GetInstance<AEnemyDropConfig>().LootObsidianRoseIncrease);
                }
                if (npc.type == NPCID.CursedSkull || npc.type == NPCID.DarkCaster)
                {
                    try_loot(ItemID.BoneWand, GetInstance<AEnemyDropConfig>().LootBoneWandIncrease);
                }
                if (npc.type == NPCID.CaveBat)
                {
                    try_loot(ItemID.ChainKnife, GetInstance<AEnemyDropConfig>().LootChainKnifeIncrease);
                }
                if (npc.type == NPCID.Reaper)
                {
                    try_loot(ItemID.DeathSickle, GetInstance<AEnemyDropConfig>().LootDeathSickleIncrease);
                }
                if (npc_is_any_types(3, 591, 590, 331, 332, 132, 161, 186, 187, 188, 189, 200, 223, 319, 320, 321, 430, 431, 432, 433, 434, 435, 436)) //Basic Zombies
                {
                    try_loot(ItemID.ZombieArm, GetInstance<AEnemyDropConfig>().LootZombieArmIncrease);
                    try_loot(ItemID.Shackle, GetInstance<AEnemyDropConfig>().LootShackleIncrease);
                }
                if (npc.type == NPCID.Unicorn)
                    try_loot(ItemID.BlessedApple, GetInstance<AEnemyDropConfig>().LootBlessedAppleIncrease);
                if (npc.type == NPCID.Mimic)
                {
                    try_loot(ItemID.DualHook, GetInstance<AEnemyDropConfig>().LootDualHookIncrease);
                    try_loot(ItemID.MagicDagger, GetInstance<AEnemyDropConfig>().LootMagicDaggerIncrease);
                    try_loot(ItemID.TitanGlove, GetInstance<AEnemyDropConfig>().LootTitanGloveIncrease);
                    try_loot(ItemID.PhilosophersStone, GetInstance<AEnemyDropConfig>().LootPhilosophersStoneIncrease);
                    try_loot(ItemID.CrossNecklace, GetInstance<AEnemyDropConfig>().LootCrossNecklaceIncrease);
                    try_loot(ItemID.StarCloak, GetInstance<AEnemyDropConfig>().LootStarCloakIncrease);
                }
                if (npc.type == NPCID.BigMimicCorruption)
                {
                    try_loot(ItemID.DartRifle, GetInstance<AEnemyDropConfig>().LootDartRifleIncrease);
                    try_loot(ItemID.WormHook, GetInstance<AEnemyDropConfig>().LootWormHookIncrease);
                    try_loot(ItemID.ChainGuillotines, GetInstance<AEnemyDropConfig>().LootChainGuillotinesIncrease);
                    try_loot(ItemID.ClingerStaff, GetInstance<AEnemyDropConfig>().LootClingerStaffIncrease);
                    try_loot(ItemID.PutridScent, GetInstance<AEnemyDropConfig>().LootPutridScentIncrease);
                }
                if (npc.type == NPCID.BigMimicCrimson)
                {
                    try_loot(ItemID.SoulDrain, GetInstance<AEnemyDropConfig>().LootLifeDrainIncrease);
                    try_loot(ItemID.DartPistol, GetInstance<AEnemyDropConfig>().LootDartPistolIncrease);
                    try_loot(ItemID.FetidBaghnakhs, GetInstance<AEnemyDropConfig>().LootFetidBaghnakhsIncrease);
                    try_loot(ItemID.FleshKnuckles, GetInstance<AEnemyDropConfig>().LootFleshKnucklesIncrease);
                    try_loot(ItemID.TendonHook, GetInstance<AEnemyDropConfig>().LootTendonHookIncrease);
                }
                if (npc.type == NPCID.BigMimicHallow)
                {
                    try_loot(ItemID.DaedalusStormbow, GetInstance<AEnemyDropConfig>().LootDaedalusStormbowIncrease);
                    try_loot(ItemID.FlyingKnife, GetInstance<AEnemyDropConfig>().LootFlyingKnifeIncrease);
                    try_loot(ItemID.CrystalVileShard, GetInstance<AEnemyDropConfig>().LootCrystalVileShardIncrease);
                    try_loot(ItemID.IlluminantHook, GetInstance<AEnemyDropConfig>().LootIlluminantHookIncrease);
                }
                if (npc.type == NPCID.Harpy)
                {
                    try_loot(ItemID.GiantHarpyFeather, GetInstance<AEnemyDropConfig>().LootGiantHarpyFeatherIncrease);
                    try_loot(ItemID.Cloud, GetInstance<AEnemyDropConfig>().LootCloudFromHarpies);
                }
                if ((npc.type >= 26 && npc.type <= 29) || npc.type == 111) //Goblin Army (Excluding Summoner)
                {
                    try_loot(ItemID.Harpoon, GetInstance<AEnemyDropConfig>().LootHarpoonIncrease);
                }
                if (npc.type == NPCID.ArmoredViking || npc.type == NPCID.IceElemental || npc.type == NPCID.IcyMerman || npc.type == NPCID.IceTortoise)
                {
                    try_loot(ItemID.IceSickle, GetInstance<AEnemyDropConfig>().LootIceSickleIncrease);
                }
                if (npc.type == NPCID.SkeletonArcher)
                {
                    try_loot(ItemID.Marrow, GetInstance<AEnemyDropConfig>().LootMarrowIncrease);
                    try_loot(ItemID.MagicQuiver, GetInstance<AEnemyDropConfig>().LootMagicQuiverIncrease);
                }
                if (npc.type == NPCID.Crimslime || npc.type == NPCID.CrimsonAxe || npc.type == NPCID.FloatyGross || npc.type == NPCID.Herpling)
                {
                    try_loot(ItemID.MeatGrinder, GetInstance<AEnemyDropConfig>().LootMeatGrinderIncrease);
                }
                if (npc.type == NPCID.AngryTrapper)
                {
                    try_loot(ItemID.Uzi, GetInstance<AEnemyDropConfig>().LootUziIncrease);
                }
                if (npc.type == NPCID.ArmoredSkeleton)
                {
                    try_loot(ItemID.BeamSword, GetInstance<AEnemyDropConfig>().LootBeamSwordIncrease);
                }
                if (npc_is_any_types(2, 317, 318, 190, 191, 192, 193, 194, 133)) //Demon Eye Variants and Wandering Eye
                {
                    try_loot(ItemID.BlackLens, GetInstance<AEnemyDropConfig>().LootBlackLensIncrease);
                }
                if (npc.type == NPCID.ZombieEskimo || npc.type == NPCID.ArmedZombieEskimo)
                {
                    try_loot(ItemID.EskimoHood, GetInstance<AEnemyDropConfig>().LootEskimoHoodIncrease);
                    try_loot(ItemID.EskimoCoat, GetInstance<AEnemyDropConfig>().LootEskimoCoatIncrease);
                    try_loot(ItemID.EskimoPants, GetInstance<AEnemyDropConfig>().LootEskimoPantsIncrease);
                }
                if (npc.type == NPCID.Hellbat)
                {
                    try_loot(ItemID.MagmaStone, GetInstance<AEnemyDropConfig>().HellBatLootMagmaStoneIncrease);
                }
                if (npc.type == NPCID.Lavabat)
                {
                    try_loot(ItemID.MagmaStone, GetInstance<AEnemyDropConfig>().LavaBatLootMagmaStoneIncrease);
                }
                if (npc.type == NPCID.SnowFlinx)
                {
                    try_loot(ItemID.SnowballLauncher, GetInstance<AEnemyDropConfig>().LootSnowballLauncherIncrease);
                }
                if (npc.type == NPCID.ScutlixRider)
                {
                    try_loot(ItemID.BrainScrambler, GetInstance<AEnemyDropConfig>().LootBrainScramblerIncrease);
                }
                if (npc_is_any_types(63, 64, 103)) //Basic Jellyfish
                {
                    try_loot(ItemID.JellyfishNecklace, GetInstance<AEnemyDropConfig>().LootJellyfishNecklaceIncrease);
                }
                if (npc.type == NPCID.DesertLamiaLight || npc.type == NPCID.DesertLamiaDark)
                {
                    try_loot(ItemID.LamiaHat, GetInstance<AEnemyDropConfig>().LootLamiaClothesIncrease);
                    try_loot(ItemID.LamiaPants, GetInstance<AEnemyDropConfig>().LootLamiaClothesIncrease);
                    try_loot(ItemID.LamiaShirt, GetInstance<AEnemyDropConfig>().LootLamiaClothesIncrease);
                }
                if (npc.type == NPCID.Vampire)
                {
                    try_loot(ItemID.MoonStone, GetInstance<AEnemyDropConfig>().LootMoonStoneIncrease);
                }
                if (npc.type == NPCID.RedDevil)
                {
                    try_loot(ItemID.FireFeather, GetInstance<AEnemyDropConfig>().LootFireFeatherIncrease);
                }
                if (npc_is_any_types(-4, 1, 16, 138, 141, 147, 184, 187, 433, 204, 302, 333, 334, 335, 336, 535, 658, 659, 660, -6, -7, -8, -9, 537)) //Slimestaff Slimes
                {
                    int slimestaffmultiplier = 100;
                    if (npc.type == NPCID.Pinky)
                        slimestaffmultiplier = 1;
                    if (npc.type == NPCID.SandSlime)
                        slimestaffmultiplier = 80;
                    try_loot(ItemID.SlimeStaff, GetInstance<AEnemyDropConfig>().LootSlimeStaffIncrease * slimestaffmultiplier);
                }
                if (npc.type == NPCID.Unicorn)
                {
                    try_loot(ItemID.UnicornonaStick, GetInstance<AEnemyDropConfig>().LootUnicornonaStickIncrease);
                }
                if (npc.type == NPCID.DiggerHead || npc.type == NPCID.GiantWormHead)
                {
                    try_loot(ItemID.WhoopieCushion, GetInstance<AEnemyDropConfig>().LootWhoopieCushionIncrease);
                }
                if (npc.type == NPCID.UndeadMiner)
                {
                    try_loot(ItemID.BonePickaxe, GetInstance<AEnemyDropConfig>().LootBonePickaxeIncrease);
                    try_loot(ItemID.MiningHelmet, GetInstance<AEnemyDropConfig>().LootMiningHelmetIncrease);
                    try_loot(ItemID.MiningShirt, GetInstance<AEnemyDropConfig>().LootMiningShirtIncrease);
                    try_loot(ItemID.MiningPants, GetInstance<AEnemyDropConfig>().LootMiningPantsIncrease);
                }
                if (npc.type == NPCID.Psycho)
                {
                    try_loot(ItemID.PsychoKnife, GetInstance<AEnemyDropConfig>().LootPsychoKnifeIncrease);
                }
                if (npc.type == NPCID.CorruptBunny)
                {
                    try_loot(ItemID.BunnyHood, GetInstance<AEnemyDropConfig>().LootBunnyHoodIncrease);
                }
                if (npc.type >= 78 && npc.type <= 80) //Mummies
                {
                    try_loot(ItemID.MummyMask, GetInstance<AEnemyDropConfig>().LootMummyCostumeIncrease);
                    try_loot(ItemID.MummyShirt, GetInstance<AEnemyDropConfig>().LootMummyCostumeIncrease);
                    try_loot(ItemID.MummyPants, GetInstance<AEnemyDropConfig>().LootMummyCostumeIncrease);
                }
                if (npc.type == 31 || (npc.type >= 294 && npc.type <= 296) || npc.type == NPCID.CursedSkull || npc.type == NPCID.DarkCaster) //Angry Bones, Cursed Skull, and Dark Caster
                {
                    try_loot(ItemID.GoldenKey, GetInstance<AEnemyDropConfig>().LootGoldenKeyIncrease);
                    try_loot(ItemID.TallyCounter, GetInstance<AEnemyDropConfig>().LootTallyCounterIncrease);
                }
                if (npc.type == NPCID.IceMimic)
                {
                    try_loot(ItemID.ToySled, GetInstance<AEnemyDropConfig>().LootToySledIncrease);
                }
                if (npc.type == NPCID.Werewolf)
                {
                    try_loot(ItemID.MoonCharm, GetInstance<AEnemyDropConfig>().LootMoonCharmIncrease);
                }
                if (npc.type == NPCID.DesertBeast)
                {
                    try_loot(ItemID.AncientHorn, GetInstance<AEnemyDropConfig>().LootAncientHornIncrease);
                }
                if (npc.type == NPCID.Demon)
                {
                    try_loot(ItemID.DemonScythe, GetInstance<AEnemyDropConfig>().LootDemonScytheIncrease);
                }
                if (npc.type == NPCID.Shark)
                {
                    try_loot(ItemID.DivingHelmet, GetInstance<AEnemyDropConfig>().LootDivingHelmetIncrease);
                }
                if (npc.type == NPCID.Eyezor)
                {
                    try_loot(ItemID.EyeSpring, GetInstance<AEnemyDropConfig>().LootEyeSpringIncrease);
                }
                if (npc.type == NPCID.IceElemental || npc.type == NPCID.IcyMerman)
                {
                    try_loot(ItemID.FrostStaff, GetInstance<AEnemyDropConfig>().LootFrostStaffIncrease);
                }
                if (npc.type == NPCID.WalkingAntlion)
                {
                    try_loot(ItemID.AntlionClaw, GetInstance<AEnemyDropConfig>().LootMandibleBladeIncrease);
                }
                if (npc.type == NPCID.MeteorHead)
                {
                    try_loot(ItemID.Meteorite, GetInstance<AEnemyDropConfig>().LootMeteoriteIncrease);
                }
                if (npc.type == NPCID.CorruptPenguin || npc.type == NPCID.CrimsonPenguin)
                {
                    try_loot(ItemID.PedguinHat, GetInstance<AEnemyDropConfig>().LootPedguinssuitIncrease);
                    try_loot(ItemID.PedguinShirt, GetInstance<AEnemyDropConfig>().LootPedguinssuitIncrease);
                    try_loot(ItemID.PedguinPants, GetInstance<AEnemyDropConfig>().LootPedguinssuitIncrease);
                }
                if (npc.type == NPCID.UndeadViking)
                {
                    try_loot(ItemID.VikingHelmet, GetInstance<AEnemyDropConfig>().LootVikingHelmetIncrease);
                }
                if (npc.type == NPCID.UmbrellaSlime)
                {
                    try_loot(ItemID.UmbrellaHat, GetInstance<AEnemyDropConfig>().LootUmbrellaHatIncrease);
                }
                if (npc.type == NPCID.Vampire || npc.type == NPCID.VampireBat)
                {
                    try_loot(ItemID.BrokenBatWing, GetInstance<AEnemyDropConfig>().LootBrokenBatWingIncrease);
                }
                if (npc.type == NPCID.DesertDjinn)
                {
                    try_loot(ItemID.DjinnLamp, GetInstance<AEnemyDropConfig>().LootDesertSpiritLampIncrease);
                }
                if (npc.type == NPCID.Piranha)
                {
                    try_loot(ItemID.Hook, GetInstance<AEnemyDropConfig>().LootHookIncrease);
                }
                if (npc.type == NPCID.LightMummy || npc.type == NPCID.DesertGhoulHallow || npc.type == NPCID.SandsharkHallow)
                {
                    try_loot(ItemID.LightShard, GetInstance<AEnemyDropConfig>().LootLightShardIncrease);
                }
                if (npc.type == NPCID.DesertLamiaLight)
                {
                    try_loot(ItemID.MoonMask, GetInstance<AEnemyDropConfig>().LootMoonMaskIncrease);
                }
                if (npc.type == NPCID.DesertLamiaDark)
                {
                    try_loot(ItemID.SunMask, GetInstance<AEnemyDropConfig>().LootSunMaskIncrease);
                }
                if (npc.type >= 333 && npc.type <= 336) //Present Slimes
                {
                    try_loot(ItemID.GiantBow, GetInstance<AEnemyDropConfig>().LootGiantBowIncrease);
                }
                if (npc.type == NPCID.ZombieRaincoat)
                {
                    try_loot(ItemID.RainCoat, GetInstance<AEnemyDropConfig>().LootRainArmorIncrease);
                    try_loot(ItemID.RainCoat, GetInstance<AEnemyDropConfig>().LootRainArmorIncrease);
                }
                if (npc.type == NPCID.SkeletonSniper)
                {
                    try_loot(ItemID.SniperRifle, GetInstance<AEnemyDropConfig>().LootSniperRifleIncrease);
                    try_loot(ItemID.RifleScope, GetInstance<AEnemyDropConfig>().LootRifleScopeIncrease);
                }
                if (npc.type == NPCID.TacticalSkeleton)
                {
                    try_loot(ItemID.TacticalShotgun, GetInstance<AEnemyDropConfig>().LootTacticalShotgunIncrease);
                    try_loot(ItemID.SWATHelmet, GetInstance<AEnemyDropConfig>().LootSWATHelmetIncrease);
                }
                if (npc.type >= 524 && npc.type <= 527) //Ghouls
                {
                    try_loot(ItemID.AncientCloth, GetInstance<AEnemyDropConfig>().LootAncientClothIncrease);
                }
                if (npc.type == NPCID.DesertGhoulCorruption || npc.type == NPCID.DesertGhoulCrimson)
                {
                    try_loot(ItemID.DarkShard, GetInstance<AEnemyDropConfig>().LootDarkShardIncrease);
                }
                if (npc.type == NPCID.AngryNimbus)
                {
                    try_loot(ItemID.NimbusRod, GetInstance<AEnemyDropConfig>().LootNimbusRodIncrease);
                }
                if (npc.type == NPCID.BoneLee)
                {
                    try_loot(ItemID.BlackBelt, GetInstance<AEnemyDropConfig>().LootBlackBeltIncrease);
                    try_loot(ItemID.Tabi, GetInstance<AEnemyDropConfig>().LootTabiIncrease);
                }
                if (Main.halloween && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead)
                {
                    try_loot(ItemID.GoodieBag, GetInstance<AEnemyDropConfig>().LootGoodieBagIncrease);
                }
                if (Main.xMas && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead)
                {
                    try_loot(ItemID.Present, GetInstance<AEnemyDropConfig>().LootPresentIncrease);
                }
                if (npc.type == NPCID.Drippler || npc.type == NPCID.BloodZombie)
                {
                    try_loot(ItemID.MoneyTrough, GetInstance<AEnemyDropConfig>().LootMoneyTroughIncrease);
                }
                if (npc.type >= 494 && npc.type <= 506) //Giant Shellies, Crawdads, and Salamanders
                {
                    try_loot(ItemID.Rally, GetInstance<AEnemyDropConfig>().LootRallyIncrease);
                }
                if (npc.type == NPCID.Medusa)
                {
                    try_loot(ItemID.PocketMirror, GetInstance<AEnemyDropConfig>().LootPocketMirrorIncrease);
                }
                if (npc.type == NPCID.Mothron)
                {
                    try_loot(ItemID.MothronWings, GetInstance<AEnemyDropConfig>().LootMothronWingsIncrease);
                }
                if (Main.bloodMoon && npc.type != NPCID.Slimer && npc.type != NPCID.MeteorHead && Main.hardMode)
                {
                    try_loot(ItemID.KOCannon, GetInstance<AEnemyDropConfig>().LootKOCannonIncrease);
                }
                if (npc.type == 16 || npc.type == 58 || npc.type == 167 || npc.type == 197 || npc.type == 185 || (npc.type >= 494 && npc.type <= 506)) //Salamanders, Giant Shellys, Crawdads, Mother Slimes, Piranhas, Snow Flinxes, Undead Vikings, and Armored Vikings.
                {
                    try_loot(ItemID.Compass, GetInstance<AEnemyDropConfig>().LootCompassIncrease);
                }
                if (npc.type == 49 || npc.type == 93 || npc.type == 51 || npc.type == 150 || (npc.type >= 494 && npc.type <= 506)) //Cave Bats, Giant Bats, Jungle Bats, Ice Bats, Salamanders, Giant Shellys, and Crawdads.
                {
                    try_loot(ItemID.DepthMeter, GetInstance<AEnemyDropConfig>().LootDepthMeterIncrease);
                }
                if (npc.type == NPCID.Guide) //Guide NPC
                {
                    try_loot(ItemID.GreenCap, GetInstance<AEnemyDropConfig>().LootGreenCapForNonAndrewGuide);
                }
                if (npc.type == NPCID.DyeTrader) //Dye Trader NPC
                {
                    try_loot(ItemID.DyeTradersScimitar, GetInstance<AEnemyDropConfig>().LootExoticScimitarIncrease);
                }
                if (npc.type == NPCID.DD2Bartender) //Tavernkeep NPC
                {
                    try_loot(ItemID.AleThrowingGlove, GetInstance<AEnemyDropConfig>().LootAleTosserIncrease);
                }
                if (npc.type == NPCID.Stylist) //Stylist NPC
                {
                    try_loot(ItemID.StylistKilLaKillScissorsIWish, GetInstance<AEnemyDropConfig>().LootStylishScissorsIncrease);
                }
                if (npc.type == NPCID.Painter) //Painter NPC
                {
                    try_loot(ItemID.PainterPaintballGun, GetInstance<AEnemyDropConfig>().LootPaintballGunIncrease);
                }
                if (npc.type == NPCID.PartyGirl) //Party Girl NPC
                {
                    try_loot(ItemID.PartyGirlGrenade, Main.rand.Next(30, GetInstance<AEnemyDropConfig>().LootHappyGrenadeIncrease));
                }
                if (npc.type == NPCID.TaxCollector) //Tax Collector Guide NPC
                {
                    try_loot(ItemID.TaxCollectorsStickOfDoom, GetInstance<AEnemyDropConfig>().LootClassyCane);
                }

                //Non-Boss Drops - Ankh Charm Material
                if (npc_is_any_types(104, 102, 269, 270, 271, 272))
                    try_loot(ItemID.AdhesiveBandage, GetInstance<AEnemyDropConfig>().LootAdhesiveBandageIncrease);
                if (npc_is_any_types(77, 273, 274, 275, 276))
                    try_loot(ItemID.ArmorPolish, GetInstance<AEnemyDropConfig>().LootArmorPolishIncrease);
                if (npc_is_any_types(141, 176, 42, 231, 232, 233, 234, 235))
                    try_loot(ItemID.Bezoar, GetInstance<AEnemyDropConfig>().LootBezoarIncrease);
                if (npc_is_any_types(81, 79, 183, 630))
                    try_loot(ItemID.Blindfold, GetInstance<AEnemyDropConfig>().LootBlindfoldIncrease);
                if (npc_is_any_types(78, 82, 75))
                    try_loot(ItemID.FastClock, GetInstance<AEnemyDropConfig>().LootFastClockBaseIncrease);
                if (npc_is_any_types(103, 75, 79, 630))
                    try_loot(ItemID.Megaphone, GetInstance<AEnemyDropConfig>().LootMegaphoneBaseIncrease);
                if (npc_is_any_types(34, 83, 84, 179, 289))
                    try_loot(ItemID.Nazar, GetInstance<AEnemyDropConfig>().LootNazarIncrease);
                if (npc_is_any_types(94, 182))
                    try_loot(ItemID.Vitamins, GetInstance<AEnemyDropConfig>().LootVitaminsIncrease);

                if (npc_is_any_types(93, 109, 80))
                    try_loot(ItemID.TrifoldMap, GetInstance<AEnemyDropConfig>().LootTrifoldMapIncrease);

                //Drops that don't happen in vanilla
                if (npc.type == NPCID.DukeFishron)
                    try_boss_loot(ItemID.TruffleWorm, GetInstance<AEnemyDropConfig>().LootFishronTruffleworm);
                if (npc.type == NPCID.DuneSplicerHead)
                {
                    try_loot_max_min(ItemID.DesertFossil, GetInstance<AEnemyDropConfig>().LootDesertFossilFromDuneSplicer);
                    try_conditional_loot_max_min(ItemID.SandBlock, new NoInfectionZone(), GetInstance<AEnemyDropConfig>().LootSandFromDuneSplicer);
                    try_conditional_loot_max_min(ItemID.EbonsandBlock, new ZoneCorruptnNoOtherInfection(), GetInstance<AEnemyDropConfig>().LootSandFromDuneSplicer);
                    try_conditional_loot_max_min(ItemID.CrimsandBlock, new ZoneCrimsonNoOtherInfection(), GetInstance<AEnemyDropConfig>().LootSandFromDuneSplicer);
                    try_conditional_loot_max_min(ItemID.PearlsandBlock, new ZoneHallow(), GetInstance<AEnemyDropConfig>().LootSandFromDuneSplicer);
                }
                if (npc.type == NPCID.TombCrawlerHead)
                {
                    try_loot_max_min(ItemID.DesertFossil, GetInstance<AEnemyDropConfig>().LootDesertFossilFromTombCrawler);
                    try_conditional_loot_max_min(ItemID.SandBlock, new NoInfectionZone(), GetInstance<AEnemyDropConfig>().LootSandFromTombCrawler);
                    try_conditional_loot_max_min(ItemID.EbonsandBlock, new ZoneCorruptnNoOtherInfection(), GetInstance<AEnemyDropConfig>().LootSandFromTombCrawler);
                    try_conditional_loot_max_min(ItemID.CrimsandBlock, new ZoneCrimsonNoOtherInfection(), GetInstance<AEnemyDropConfig>().LootSandFromTombCrawler);
                    try_conditional_loot_max_min(ItemID.PearlsandBlock, new ZoneHallow(), GetInstance<AEnemyDropConfig>().LootSandFromTombCrawler);
                }
            }
        }

        public override void ModifyGlobalLoot(GlobalLoot globalLoot)
        {
            int config = GetInstance<AEnemyDropConfig>().LootBiomeKeyIncrease;
            if (config > 0)
            {
                globalLoot.Add(new ItemDropWithConditionRule(1533, config, 1, 1, new Conditions.JungleKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1534, config, 1, 1, new Conditions.CorruptKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1535, config, 1, 1, new Conditions.CrimsonKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1536, config, 1, 1, new Conditions.HallowKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1537, config, 1, 1, new Conditions.FrozenKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(4714, config, 1, 1, new Conditions.DesertKeyCondition()));
            }
            config = GetInstance<AEnemyDropConfig>().LootHelFireIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(3290, config, 1, 1, new Conditions.YoyosHelFire()));
            config = GetInstance<AEnemyDropConfig>().LootCascadeIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(3290, config, 1, 1, new Conditions.YoyoCascade()));
            config = GetInstance<AEnemyDropConfig>().LootLivingFireBlockIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(2701, config, 20, 50, new Conditions.LivingFlames()));
            config = GetInstance<AEnemyDropConfig>().LootKrakenIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(3291, config, 1, 1, new Conditions.YoyosKraken()));
            config = GetInstance<AEnemyDropConfig>().LootYeletsIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(3289, config, 1, 1, new Conditions.YoyosAmarok()));
            config = GetInstance<AEnemyDropConfig>().LootPirateMapIncrease;
            if (config > 0)
                globalLoot.Add(ItemDropRule.ByCondition(new Conditions.PirateMap(), 1315, config));
            config = GetInstance<AEnemyDropConfig>().LootSoulofLightIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(520, config, 1, 1, new Conditions.SoulOfLight()));
            config = GetInstance<AEnemyDropConfig>().LootSoulofNightIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(521, config, 1, 1, new Conditions.SoulOfNight()));
            config = GetInstance<AEnemyDropConfig>().LootAmarokIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(3289, config, 1, 1, new Conditions.YoyosAmarok()));
            config = GetInstance<AEnemyDropConfig>().LootBloodyMacheteAndBladedGlovesIncrease;
            if (config > 0)
            {
                globalLoot.Add(ItemDropRule.ByCondition(new Conditions.HalloweenWeapons(), 1825, config));
                globalLoot.Add(ItemDropRule.ByCondition(new Conditions.HalloweenWeapons(), 1827, config));
            }
        }
    }
}
