using ReducedGrinding.Common.ItemDropRules.Conditions;
using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class NPCLoot : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, Terraria.ModLoader.NPCLoot npcLoot)
        {
            void TryLoot(int itemType, int denominator)
            {
                if (denominator > 0)
                    npcLoot.Add(ItemDropRule.Common(itemType, denominator));
            }

            void TryLootMaxMin(int itemType, int[] config)
            {
                if (config.Max() > 0 && config.Min() >= 0)
                    npcLoot.Add(ItemDropRule.Common(itemType, 1, config.Min(), config.Max()));
            }

            void TryBossLoot(int itemType, int denominator)
            {
                if (denominator > 0)
                    npcLoot.Add(new DropBasedOnExpertMode(ItemDropRule.Common(itemType, denominator), ItemDropRule.DropNothing()));
            }

            void TryCondtionalLootMaxMin(int itemType, IItemDropRuleCondition condition, int[] config)
            {
                if (config.Max() > 0 && config.Min() >= 0)
                {
                    IItemDropRule conditionalRule = new LeadingConditionRule(condition);

                    IItemDropRule rule = ItemDropRule.Common(itemType, 1, config.Min(), config.Max());

                    conditionalRule.OnSuccess(rule);

                    npcLoot.Add(conditionalRule);
                }
            }

            bool NPC_IsAnyTypes(params int[] types)
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
            if (npc.type == NPCID.DukeFishron)
            {
                TryBossLoot(ItemID.FishronWings, GetInstance<AEnemyLootConfig>().EmpressAndFishronWingsIncrease);
                TryBossLoot(ItemID.TruffleWorm, GetInstance<BEnemyLootNonVanillaConfig>().TrufflewormFromDukeFishron);
            }
            if (npc.type == NPCID.HallowBoss)
            {
                TryBossLoot(ItemID.RainbowWings, GetInstance<AEnemyLootConfig>().EmpressAndFishronWingsIncrease);
                TryBossLoot(ItemID.SparkleGuitar, GetInstance<AEnemyLootConfig>().StellarTuneIncrease);
                TryBossLoot(ItemID.RainbowCursor, GetInstance<AEnemyLootConfig>().RainbowCursor);
            }
            if (npc.type == NPCID.EyeofCthulhu)
                TryBossLoot(ItemID.Binoculars, GetInstance<AEnemyLootConfig>().BinocularsIncrease);

            //Non-Boss Drops

            //Town NPC Drops
            if (npc.type == NPCID.Guide)
            {
                npcLoot.RemoveWhere(rule => rule is ItemDropWithConditionRule drop && drop.itemId == ItemID.GreenCap && drop.condition is Conditions.NamedNPC npcNameCondition && npcNameCondition.neededName == "Andrew");
                npcLoot.Add(ItemDropRule.Common(ItemID.GreenCap, 1));
            }
            if (npc.type == NPCID.Steampunker)
            {
                npcLoot.RemoveWhere(rule => rule is ItemDropWithConditionRule drop && drop.itemId == ItemID.IvyGuitar && drop.condition is Conditions.NamedNPC npcNameCondition && npcNameCondition.neededName == "Whitney");
                npcLoot.Add(ItemDropRule.Common(ItemID.IvyGuitar, 1));
            }
            if (npc.type == NPCID.DyeTrader)
                TryLoot(ItemID.DyeTradersScimitar, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.Painter)
                TryLoot(ItemID.PainterPaintballGun, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.DD2Bartender)
                TryLoot(ItemID.AleThrowingGlove, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.Stylist)
                TryLoot(ItemID.StylistKilLaKillScissorsIWish, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.Mechanic)
                TryLoot(ItemID.CombatWrench, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.TaxCollector)
                TryLoot(ItemID.TaxCollectorsStickOfDoom, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.Princess)
                TryLoot(ItemID.PrincessWeapon, GetInstance<AEnemyLootConfig>().TownNPCWeapons);

            //Basic NPCs
            if (npc.type == NPCID.SkeletonArcher)
                TryLoot(ItemID.Marrow, GetInstance<AEnemyLootConfig>().MarrowIncrease);
            if (npc.type == NPCID.ArmoredSkeleton)
                TryLoot(ItemID.BeamSword, GetInstance<AEnemyLootConfig>().BeamSwordIncrease);
            if (npc.type == NPCID.FireImp)
                TryLoot(ItemID.PlumbersHat, GetInstance<AEnemyLootConfig>().PlumbersHatIncrease);
            if (npc.type == NPCID.ChaosElemental)
                TryLoot(ItemID.RodofDiscord, GetInstance<AEnemyLootConfig>().RodofDiscordIncrease);
            if (npc.type == NPCID.Lihzahrd || npc.type == NPCID.LihzahrdCrawler || npc.type == NPCID.FlyingSnake)
                TryLoot(ItemID.LizardEgg, GetInstance<AEnemyLootConfig>().LizardEggIncrease);
            if (NPC_IsAnyTypes(-4, 1, 16, 138, 141, 147, 184, 187, 433, 204, 302, 333, 334, 335, 336, 535, 658, 659, 660, -6, -7, -8, -9, 537)) //Slimestaff Slimes
            {
                int slimestaffmultiplier = 100;
                if (npc.type == NPCID.Pinky)
                    slimestaffmultiplier = 1;
                if (npc.type == NPCID.SandSlime)
                    slimestaffmultiplier = 80;
                if (Main.GameMode == GameModeID.Normal)
                    slimestaffmultiplier = slimestaffmultiplier * 10 / 7;
                TryLoot(ItemID.SlimeStaff, GetInstance<AEnemyLootConfig>().SlimeStaffIncrease * slimestaffmultiplier);
            }
            if (npc.type == NPCID.SkeletonSniper)
            {
                TryLoot(ItemID.RifleScope, GetInstance<AEnemyLootConfig>().RifleScopeAndSniperRifleIncrease);
                TryLoot(ItemID.SniperRifle, GetInstance<AEnemyLootConfig>().RifleScopeAndSniperRifleIncrease);
            }
            if (npc.type == NPCID.TacticalSkeleton)
            {
                TryLoot(ItemID.SWATHelmet, GetInstance<AEnemyLootConfig>().SWATHelmetAndTacticalShotgunIncrease);
                TryLoot(ItemID.TacticalShotgun, GetInstance<AEnemyLootConfig>().SWATHelmetAndTacticalShotgunIncrease);
            }
            if (npc.type == NPCID.SkeletonCommando)
                TryLoot(ItemID.RocketLauncher, GetInstance<AEnemyLootConfig>().RocketLauncherIncrease);
            if (npc.type == NPCID.Paladin)
            {
                TryLoot(ItemID.PaladinsHammer, GetInstance<AEnemyLootConfig>().PaladinsHammerIncrease);
                TryLoot(ItemID.PaladinsShield, GetInstance<AEnemyLootConfig>().PaladinsShieldIncrease);
            }
            if (npc.type == NPCID.EaterofSouls || npc.type == NPCID.LittleEater || npc.type == NPCID.BigEater || npc.type == NPCID.DevourerHead || npc.type == NPCID.Corruptor)
                TryLoot(ItemID.RottenChunk, GetInstance<AEnemyLootConfig>().RottenChunkAndVertebra);
            if (npc.type == NPCID.BloodCrawler || npc.type == NPCID.BloodCrawlerWall || npc.type == NPCID.Crimera || npc.type == NPCID.LittleCrimera || npc.type == NPCID.BigCrimera || npc.type == NPCID.FaceMonster || npc.type == NPCID.FloatyGross)
                TryLoot(ItemID.Vertebrae, GetInstance<AEnemyLootConfig>().RottenChunkAndVertebra);
            if (npc.type == NPCID.DemonEye || npc.type == NPCID.DemonEye2 || npc.type == NPCID.CataractEye || npc.type == NPCID.CataractEye2 || npc.type == NPCID.SleepyEye || npc.type == NPCID.SleepyEye2 || npc.type == NPCID.DialatedEye || npc.type == NPCID.DialatedEye2 || npc.type == NPCID.GreenEye || npc.type == NPCID.GreenEye2 || npc.type == NPCID.PurpleEye || npc.type == NPCID.PurpleEye2 || npc.type == NPCID.DemonEyeOwl || npc.type == NPCID.DemonEyeSpaceship || npc.type == NPCID.WanderingEye)
                TryLoot(ItemID.Lens, GetInstance<AEnemyLootConfig>().LensIncrease);

            //Pirate Drops
            if (NPC_IsAnyTypes(212, 213, 214, 215, 216, 491)) //All Human Pirates and Flying Dutchman
            {
                //
                //TO-DO 1.4.4 is going to boost pirate drop rates. I added coding to immitate the new rates, but when the udpate comes out: look into the changes and the source code, and modify the coding below. So far, it's unknown exactly how the Flying Dutchman rates will be, but I assume it has to at least be twice as likely (some will go as far as 10 times more likely, but it's unknown what that is).

                float denominator_multiplier = 10;
                if (npc.type == NPCID.PirateCaptain)
                    denominator_multiplier = 2.5f;
                else if (npc.type == NPCID.PirateShip)
                    denominator_multiplier = 1;

                foreach (var rule in npcLoot.Get())
                {
                    if (rule is CommonDrop commonDrop && (commonDrop.itemId == ItemID.CoinGun || commonDrop.itemId == ItemID.CoinGun || commonDrop.itemId == ItemID.CoinGun || commonDrop.itemId == ItemID.LuckyCoin || commonDrop.itemId == ItemID.DiscountCard || commonDrop.itemId == ItemID.PirateStaff || commonDrop.itemId == ItemID.GoldRing || commonDrop.itemId == ItemID.Cutlass))
                        commonDrop.chanceDenominator /= 2;
                }

                if (npc.type == NPCID.PirateShip)
                    npcLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, 1704, 1705, 1710, 1716, 1720, 2133, 2137, 2143, 2147, 2151, 2155, 2238, 2379, 2389, 2405, 2663, 2843, 3885, 3904, 3910)); //Always drop 1 Golden Furniture

                TryLoot(ItemID.CoinGun, (int)(GetInstance<AEnemyLootConfig>().CoinGunBaseIncrease * denominator_multiplier));
                TryLoot(ItemID.LuckyCoin, (int)(GetInstance<AEnemyLootConfig>().LuckyCoinBaseIncrease * denominator_multiplier));
                TryLoot(ItemID.DiscountCard, (int)(GetInstance<AEnemyLootConfig>().DiscountCardBaseIncrease * denominator_multiplier));
                TryLoot(ItemID.PirateStaff, (int)(GetInstance<AEnemyLootConfig>().PirateStaffBaseIncrease * denominator_multiplier));
                TryLoot(ItemID.GoldRing, (int)(GetInstance<AEnemyLootConfig>().GoldRingBaseIncrease * denominator_multiplier));
                TryLoot(ItemID.Cutlass, (int)(GetInstance<AEnemyLootConfig>().CutlassBaseIncrease * denominator_multiplier));
            }

            //Drops that don't happen in vanilla

            //Boss Drops
            if (npc.type == NPCID.DukeFishron)
                TryBossLoot(ItemID.TruffleWorm, GetInstance<BEnemyLootNonVanillaConfig>().TrufflewormFromDukeFishron);

            if (npc.type == NPCID.Plantera)
                TryLoot(ItemType<Items.PlanteraSap>(), GetInstance<HOtherModdedItemsConfig>().PlanteraSapFromPlantera);

            if (npc.type == NPCID.KingSlime)
                TryBossLoot(ItemID.SlimeStaff, GetInstance<BEnemyLootNonVanillaConfig>().SlimeStaffFromSlimeKing);

            //Non-Boss Drops
            if (npc.type == NPCID.DuneSplicerHead)
            {
                TryLootMaxMin(ItemID.DesertFossil, GetInstance<BEnemyLootNonVanillaConfig>().DesertFossilFromDuneSplicer);
                TryCondtionalLootMaxMin(ItemID.SandBlock, new NoInfectionZone(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromDuneSplicer);
                TryCondtionalLootMaxMin(ItemID.EbonsandBlock, new ZoneCorruptnNoOtherInfection(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromDuneSplicer);
                TryCondtionalLootMaxMin(ItemID.CrimsandBlock, new ZoneCrimsonNoOtherInfection(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromDuneSplicer);
                TryCondtionalLootMaxMin(ItemID.PearlsandBlock, new ZoneHallow(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromDuneSplicer);
            }

            if (npc.type == NPCID.TombCrawlerHead)
            {
                TryLootMaxMin(ItemID.DesertFossil, GetInstance<BEnemyLootNonVanillaConfig>().DesertFossilFromTombCrawler);
                TryCondtionalLootMaxMin(ItemID.SandBlock, new NoInfectionZone(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromTombCrawler);
                TryCondtionalLootMaxMin(ItemID.EbonsandBlock, new ZoneCorruptnNoOtherInfection(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromTombCrawler);
                TryCondtionalLootMaxMin(ItemID.CrimsandBlock, new ZoneCrimsonNoOtherInfection(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromTombCrawler);
                TryCondtionalLootMaxMin(ItemID.PearlsandBlock, new ZoneHallow(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromTombCrawler);
            }

            if (npc.type == NPCID.SandElemental)
                TryLoot(ItemID.SandstorminaBottle, GetInstance<BEnemyLootNonVanillaConfig>().SandstormInABottleFromSandElemental);

            if (npc.type == NPCID.SpikedIceSlime)
                TryLoot(ItemID.SnowballLauncher, GetInstance<BEnemyLootNonVanillaConfig>().SnowballLauncherFromSpikedIceSlime);

            if (npc.type == NPCID.GreekSkeleton || npc.type == NPCID.Medusa)
                TryLootMaxMin(ItemID.Marble, GetInstance<BEnemyLootNonVanillaConfig>().MarbleFromMarbleCaveEnemies);
        }

        public override void ModifyGlobalLoot(GlobalLoot globalLoot)
        {
            //Non-Boss Loot
            int config = GetInstance<AEnemyLootConfig>().GoodieBagIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(1774, config, 1, 1, new Conditions.HalloweenGoodieBagDrop()));

            config = GetInstance<AEnemyLootConfig>().PresentIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(ItemID.Present, config, 1, 1, new Conditions.XmasPresentDrop()));

            config = GetInstance<AEnemyLootConfig>().KOCannonIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(1314, config, 1, 1, new Conditions.KOCannon()));

            config = GetInstance<AEnemyLootConfig>().BiomeKeyIncrease;
            if (config > 0)
            {
                globalLoot.Add(new ItemDropWithConditionRule(1533, config, 1, 1, new Conditions.JungleKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1534, config, 1, 1, new Conditions.CorruptKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1535, config, 1, 1, new Conditions.CrimsonKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1536, config, 1, 1, new Conditions.HallowKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1537, config, 1, 1, new Conditions.FrozenKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(4714, config, 1, 1, new Conditions.DesertKeyCondition()));
            }

            config = GetInstance<AEnemyLootConfig>().BloodyMacheteAndBladedGlovesIncrease;
            if (config > 0)
            {
                globalLoot.Add(ItemDropRule.ByCondition(new Conditions.HalloweenWeapons(), 1825, config));
                globalLoot.Add(ItemDropRule.ByCondition(new Conditions.HalloweenWeapons(), 1827, config));
            }
        }
    }
}
