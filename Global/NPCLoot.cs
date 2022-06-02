using ReducedGrinding.Common.ItemDropRules.Conditions;
using static Terraria.ModLoader.ModContent;
using System.Linq;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
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
                try_boss_loot(ItemID.TruffleWorm, GetInstance<AEnemyLootConfig>().LootTrufflewormFromDukeFishron);
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
            if (npc.type == NPCID.SkeletonArcher)
                try_loot(ItemID.Marrow, GetInstance<AEnemyLootConfig>().LootMarrowIncrease);
            if (npc.type == NPCID.ArmoredSkeleton)
                try_loot(ItemID.BeamSword, GetInstance<AEnemyLootConfig>().LootBeamSwordIncrease);
            if (npc.type == NPCID.FireImp)
                try_loot(ItemID.PlumbersHat, GetInstance<AEnemyLootConfig>().LootPlumbersHatIncrease);
            if (npc.type == NPCID.ChaosElemental)
                try_loot(ItemID.RodofDiscord, GetInstance<AEnemyLootConfig>().LootRodofDiscordIncrease);
            if (npc.type == NPCID.Lihzahrd || npc.type == NPCID.LihzahrdCrawler || npc.type == NPCID.FlyingSnake)
                try_loot(ItemID.LizardEgg, GetInstance<AEnemyLootConfig>().LootLizardEggIncrease);
            if (npc_is_any_types(-4, 1, 16, 138, 141, 147, 184, 187, 433, 204, 302, 333, 334, 335, 336, 535, 658, 659, 660, -6, -7, -8, -9, 537)) //Slimestaff Slimes
            {
                int slimestaffmultiplier = 100;
                if (npc.type == NPCID.Pinky)
                    slimestaffmultiplier = 1;
                if (npc.type == NPCID.SandSlime)
                    slimestaffmultiplier = 80;
                try_loot(ItemID.SlimeStaff, GetInstance<AEnemyLootConfig>().LootSlimeStaffIncrease * slimestaffmultiplier);
            }

            //Pirate Drops
            if (npc_is_any_types(212, 213, 214, 215, 216, 491)) //All Human Pirates and Flying Dutchman
            {
                //
                //TO-DO 1.4.4 is going to boost drop rates. I've adjusted multipliers to the new rates, but when the udpate comes out. Look into the new coding.
                //So far, it's unknown exactly how the Flying Dutchman rates will be. I've added coding to halve the vanilla denominators below. In 1.4.4 the Flying Dutchman //always drops 1 furniture; I tried to mimic this with a "drop 1 of the following" condition, but it didn't work.
                //
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

            //Drops that don't happen in vanilla
            if (npc.type == NPCID.DukeFishron)
                try_boss_loot(ItemID.TruffleWorm, GetInstance<AEnemyLootConfig>().LootTrufflewormFromDukeFishron);
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
                try_loot(ItemID.SandstorminaBottle, GetInstance<AEnemyLootConfig>().LootSandstormInABottleFromSandElemental);
            if (npc.type == NPCID.SpikedIceSlime)
                try_loot(ItemID.SnowballLauncher, GetInstance<AEnemyLootConfig>().LootSnowballLauncherFromSpikedIceSlime);
        }

        public override void ModifyGlobalLoot(GlobalLoot globalLoot)
        {
            int config = GetInstance<AEnemyLootConfig>().LootGoodieBagIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(1774, config, 1, 1, new Conditions.HalloweenGoodieBagDrop()));
            config = GetInstance<AEnemyLootConfig>().LootPresentIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(ItemID.Present, config, 1, 1, new Conditions.XmasPresentDrop()));
            config = GetInstance<AEnemyLootConfig>().LootKOCannonIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(1314, config, 1, 1, new Conditions.KOCannon()));
            config = GetInstance<AEnemyLootConfig>().LootBiomeKeyIncrease;
            if (config > 0)
            {
                globalLoot.Add(new ItemDropWithConditionRule(1533, config, 1, 1, new Conditions.JungleKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1534, config, 1, 1, new Conditions.CorruptKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1535, config, 1, 1, new Conditions.CrimsonKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1536, config, 1, 1, new Conditions.HallowKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1537, config, 1, 1, new Conditions.FrozenKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(4714, config, 1, 1, new Conditions.DesertKeyCondition()));
            }
            config = GetInstance<AEnemyLootConfig>().LootBloodyMacheteAndBladedGlovesIncrease;
            if (config > 0)
            {
                globalLoot.Add(ItemDropRule.ByCondition(new Conditions.HalloweenWeapons(), 1825, config));
                globalLoot.Add(ItemDropRule.ByCondition(new Conditions.HalloweenWeapons(), 1827, config));
            }
        }
    }
}
