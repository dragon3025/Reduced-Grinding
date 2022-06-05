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
            if (npc.type == NPCID.DukeFishron)
            {
                try_boss_loot(ItemID.FishronWings, GetInstance<AEnemyLootConfig>().EmpressAndFishronWingsIncrease);
                try_boss_loot(ItemID.TruffleWorm, GetInstance<AEnemyLootConfig>().TrufflewormFromDukeFishron);
            }
            if (npc.type == NPCID.HallowBoss)
            {
                try_boss_loot(ItemID.RainbowWings, GetInstance<AEnemyLootConfig>().EmpressAndFishronWingsIncrease);
                try_boss_loot(ItemID.SparkleGuitar, GetInstance<AEnemyLootConfig>().StellarTuneIncrease);
                try_boss_loot(ItemID.RainbowCursor, GetInstance<AEnemyLootConfig>().RainbowCursor);
            }
            if (npc.type == NPCID.EyeofCthulhu)
                try_boss_loot(ItemID.Binoculars, GetInstance<AEnemyLootConfig>().BinocularsIncrease);

            //Non-Boss Drops

            //Town NPC Drops
            if (npc.type == NPCID.DyeTrader)
                try_loot(ItemID.DyeTradersScimitar, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.Painter)
                try_loot(ItemID.PainterPaintballGun, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.DD2Bartender)
                try_loot(ItemID.AleThrowingGlove, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.Stylist)
                try_loot(ItemID.StylistKilLaKillScissorsIWish, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.Mechanic)
                try_loot(ItemID.CombatWrench, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.TaxCollector)
                try_loot(ItemID.TaxCollectorsStickOfDoom, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.Princess)
                try_loot(ItemID.PrincessWeapon, GetInstance<AEnemyLootConfig>().TownNPCWeapons);

            if (npc.type == NPCID.SkeletonArcher)
                try_loot(ItemID.Marrow, GetInstance<AEnemyLootConfig>().MarrowIncrease);
            if (npc.type == NPCID.ArmoredSkeleton)
                try_loot(ItemID.BeamSword, GetInstance<AEnemyLootConfig>().BeamSwordIncrease);
            if (npc.type == NPCID.FireImp)
                try_loot(ItemID.PlumbersHat, GetInstance<AEnemyLootConfig>().PlumbersHatIncrease);
            if (npc.type == NPCID.ChaosElemental)
                try_loot(ItemID.RodofDiscord, GetInstance<AEnemyLootConfig>().RodofDiscordIncrease);
            if (npc.type == NPCID.Lihzahrd || npc.type == NPCID.LihzahrdCrawler || npc.type == NPCID.FlyingSnake)
                try_loot(ItemID.LizardEgg, GetInstance<AEnemyLootConfig>().LizardEggIncrease);
            if (npc_is_any_types(-4, 1, 16, 138, 141, 147, 184, 187, 433, 204, 302, 333, 334, 335, 336, 535, 658, 659, 660, -6, -7, -8, -9, 537)) //Slimestaff Slimes
            {
                int slimestaffmultiplier = 100;
                if (npc.type == NPCID.Pinky)
                    slimestaffmultiplier = 1;
                if (npc.type == NPCID.SandSlime)
                    slimestaffmultiplier = 80;
                try_loot(ItemID.SlimeStaff, GetInstance<AEnemyLootConfig>().SlimeStaffIncrease * slimestaffmultiplier);
            }
            if (npc.type == NPCID.SkeletonSniper)
            {
                try_loot(ItemID.RifleScope, GetInstance<AEnemyLootConfig>().RifleScopeAndSniperRifleIncrease);
                try_loot(ItemID.SniperRifle, GetInstance<AEnemyLootConfig>().RifleScopeAndSniperRifleIncrease);
            }
            if (npc.type == NPCID.TacticalSkeleton)
            {
                try_loot(ItemID.SWATHelmet, GetInstance<AEnemyLootConfig>().SWATHelmetAndTacticalShotgunIncrease);
                try_loot(ItemID.TacticalShotgun, GetInstance<AEnemyLootConfig>().SWATHelmetAndTacticalShotgunIncrease);
            }
            if (npc.type == NPCID.SkeletonCommando)
                try_loot(ItemID.RocketLauncher, GetInstance<AEnemyLootConfig>().RocketLauncherIncrease);
            if (npc.type == NPCID.Paladin)
            {
                try_loot(ItemID.PaladinsHammer, GetInstance<AEnemyLootConfig>().PaladinsHammerIncrease);
                try_loot(ItemID.PaladinsShield, GetInstance<AEnemyLootConfig>().PaladinsShieldIncrease);
            }
            if (npc.type == NPCID.EaterofSouls || npc.type == NPCID.LittleEater || npc.type == NPCID.BigEater || npc.type == NPCID.DevourerHead || npc.type == NPCID.Corruptor)
                try_loot(ItemID.RottenChunk, GetInstance<AEnemyLootConfig>().RottenChunkAndVertebra);
            if (npc.type == NPCID.BloodCrawler || npc.type == NPCID.BloodCrawlerWall || npc.type == NPCID.Crimera || npc.type == NPCID.LittleCrimera || npc.type == NPCID.BigCrimera || npc.type == NPCID.FaceMonster || npc.type == NPCID.FloatyGross)
                try_loot(ItemID.Vertebrae, GetInstance<AEnemyLootConfig>().RottenChunkAndVertebra);

            //Pirate Drops
            if (npc_is_any_types(212, 213, 214, 215, 216, 491)) //All Human Pirates and Flying Dutchman
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

                try_loot(ItemID.CoinGun, (int)(GetInstance<AEnemyLootConfig>().CoinGunBaseIncrease * denominator_multiplier));
                try_loot(ItemID.LuckyCoin, (int)(GetInstance<AEnemyLootConfig>().LuckyCoinBaseIncrease * denominator_multiplier));
                try_loot(ItemID.DiscountCard, (int)(GetInstance<AEnemyLootConfig>().DiscountCardBaseIncrease * denominator_multiplier));
                try_loot(ItemID.PirateStaff, (int)(GetInstance<AEnemyLootConfig>().PirateStaffBaseIncrease * denominator_multiplier));
                try_loot(ItemID.GoldRing, (int)(GetInstance<AEnemyLootConfig>().GoldRingBaseIncrease * denominator_multiplier));
                try_loot(ItemID.Cutlass, (int)(GetInstance<AEnemyLootConfig>().CutlassBaseIncrease * denominator_multiplier));
            }

            //Drops that don't happen in vanilla
            if (npc.type == NPCID.DukeFishron)
                try_boss_loot(ItemID.TruffleWorm, GetInstance<AEnemyLootConfig>().TrufflewormFromDukeFishron);
            if (npc.type == NPCID.DuneSplicerHead)
            {
                try_loot_max_min(ItemID.DesertFossil, GetInstance<AEnemyLootConfig>().DesertFossilFromDuneSplicer);
                try_conditional_loot_max_min(ItemID.SandBlock, new NoInfectionZone(), GetInstance<AEnemyLootConfig>().SandFromDuneSplicer);
                try_conditional_loot_max_min(ItemID.EbonsandBlock, new ZoneCorruptnNoOtherInfection(), GetInstance<AEnemyLootConfig>().SandFromDuneSplicer);
                try_conditional_loot_max_min(ItemID.CrimsandBlock, new ZoneCrimsonNoOtherInfection(), GetInstance<AEnemyLootConfig>().SandFromDuneSplicer);
                try_conditional_loot_max_min(ItemID.PearlsandBlock, new ZoneHallow(), GetInstance<AEnemyLootConfig>().SandFromDuneSplicer);
            }
            if (npc.type == NPCID.TombCrawlerHead)
            {
                try_loot_max_min(ItemID.DesertFossil, GetInstance<AEnemyLootConfig>().DesertFossilFromTombCrawler);
                try_conditional_loot_max_min(ItemID.SandBlock, new NoInfectionZone(), GetInstance<AEnemyLootConfig>().SandFromTombCrawler);
                try_conditional_loot_max_min(ItemID.EbonsandBlock, new ZoneCorruptnNoOtherInfection(), GetInstance<AEnemyLootConfig>().SandFromTombCrawler);
                try_conditional_loot_max_min(ItemID.CrimsandBlock, new ZoneCrimsonNoOtherInfection(), GetInstance<AEnemyLootConfig>().SandFromTombCrawler);
                try_conditional_loot_max_min(ItemID.PearlsandBlock, new ZoneHallow(), GetInstance<AEnemyLootConfig>().SandFromTombCrawler);
            }
            if (npc.type == NPCID.SandElemental)
                try_loot(ItemID.SandstorminaBottle, GetInstance<AEnemyLootConfig>().SandstormInABottleFromSandElemental);
            if (npc.type == NPCID.SpikedIceSlime)
                try_loot(ItemID.SnowballLauncher, GetInstance<AEnemyLootConfig>().SnowballLauncherFromSpikedIceSlime);
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
