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

            #region Functions
            void AddLoot(int itemType, int denominator)
            {
                if (denominator > 0)
                    npcLoot.Add(ItemDropRule.Common(itemType, denominator));
            }

            void AddLootMaxMin(int itemType, int[] config)
            {
                if (config.Max() > 0 && config.Min() >= 0)
                    npcLoot.Add(ItemDropRule.Common(itemType, 1, config.Min(), config.Max()));
            }

            void AddBossLoot(int itemType, int denominator)
            {
                if (denominator > 0)
                    npcLoot.Add(new DropBasedOnExpertMode(ItemDropRule.Common(itemType, denominator), ItemDropRule.DropNothing()));
            }

            void AddCondtionalLootMaxMin(int itemType, IItemDropRuleCondition condition, int[] config)
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
            #endregion

            #region Boss Drops
            if (npc.type == NPCID.DukeFishron)
            {
                AddBossLoot(ItemID.FishronWings, (int)(GetInstance<AEnemyLootConfig>().EmpressAndFishronWingsIncrease * 3f / 2f));
                AddBossLoot(ItemID.TruffleWorm, GetInstance<BEnemyLootNonVanillaConfig>().TrufflewormFromDukeFishron);
            }
            if (npc.type == NPCID.HallowBoss)
            {
                AddBossLoot(ItemID.RainbowWings, (int)(GetInstance<AEnemyLootConfig>().EmpressAndFishronWingsIncrease * 3f / 2f));
                AddBossLoot(ItemID.SparkleGuitar, (int)(GetInstance<AEnemyLootConfig>().StellarTuneIncrease * 5f / 2f));
                AddBossLoot(ItemID.RainbowCursor, GetInstance<AEnemyLootConfig>().RainbowCursor);
            }
            if (npc.type == NPCID.EyeofCthulhu)
                AddBossLoot(ItemID.Binoculars, (int)(GetInstance<AEnemyLootConfig>().BinocularsIncrease * 4f / 3f));
            #endregion

            #region Non-Boss Drops

            #region Town NPC Drops
            if (npc.type == NPCID.Guide)
            {
                npcLoot.RemoveWhere(rule => rule is ItemDropWithConditionRule drop && drop.itemId == ItemID.GreenCap);
                npcLoot.Add(ItemDropRule.Common(ItemID.GreenCap, 1));
            }
            if (npc.type == NPCID.Steampunker)
            {
                npcLoot.RemoveWhere(rule => rule is ItemDropWithConditionRule drop && drop.itemId == ItemID.IvyGuitar);
                npcLoot.Add(ItemDropRule.Common(ItemID.IvyGuitar, 1));
            }

            if (npc.type == NPCID.DyeTrader)
                AddLoot(ItemID.DyeTradersScimitar, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.Painter)
                AddLoot(ItemID.PainterPaintballGun, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.DD2Bartender)
                AddLoot(ItemID.AleThrowingGlove, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.Stylist)
                AddLoot(ItemID.StylistKilLaKillScissorsIWish, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.Mechanic)
                AddLoot(ItemID.CombatWrench, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.TaxCollector)
                AddLoot(ItemID.TaxCollectorsStickOfDoom, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.Princess)
                AddLoot(ItemID.PrincessWeapon, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            #endregion

            #region Basic NPCs
            if (npc.type == NPCID.SkeletonArcher)
                AddLoot(ItemID.Marrow, GetInstance<AEnemyLootConfig>().MarrowIncrease);
            if (npc.type == NPCID.ArmoredSkeleton)
                AddLoot(ItemID.BeamSword, GetInstance<AEnemyLootConfig>().BeamSwordIncrease);
            if (npc.type == NPCID.FireImp)
                AddLoot(ItemID.PlumbersHat, GetInstance<AEnemyLootConfig>().PlumbersHatIncrease);
            if (npc.type == NPCID.ChaosElemental)
            {
                float multiplier = 1f;
                if (Main.GameMode == GameModeID.Normal)
                    multiplier = 5f / 4f;
                AddLoot(ItemID.RodofDiscord, (int)(GetInstance<AEnemyLootConfig>().RodofDiscordIncrease * multiplier));
            }
            if (npc.type == NPCID.Lihzahrd || npc.type == NPCID.LihzahrdCrawler || npc.type == NPCID.FlyingSnake)
                AddLoot(ItemID.LizardEgg, GetInstance<AEnemyLootConfig>().LizardEggIncrease);
            if (npc.type == NPCID.Pinky)
            {
                float multiplier = 1f;
                if (Main.GameMode == GameModeID.Normal)
                    multiplier = 10f / 7f;
                AddLoot(ItemID.SlimeStaff, (int)(GetInstance<AEnemyLootConfig>().SlimeStaffFromPinkyIncrease * multiplier));
            }
            if (npc.type == NPCID.SandSlime)
            {
                float multiplier = 1f;
                if (Main.GameMode == GameModeID.Normal)
                    multiplier = 10f / 7f;
                AddLoot(ItemID.SlimeStaff, (int)(GetInstance<AEnemyLootConfig>().SlimeStaffFromSandSlimeIncrease * multiplier));
            }
            if (NPC_IsAnyTypes(1, 16, 138, 141, 147, 184, 187, 433, 204, 302, 333, 334, 335, 336, 535, 658, 659, 660, -6, -7, -8, -9)) //All other Slime Staff Slimes.
            {
                float multiplier = 1f;
                if (Main.GameMode == GameModeID.Normal)
                    multiplier = 10f / 7f;
                AddLoot(ItemID.SlimeStaff, (int)(GetInstance<AEnemyLootConfig>().SlimeStaffFromOtherSlimesIncrease * multiplier));
            }
            if (npc.type == NPCID.SkeletonSniper)
            {
                float multiplier = 1f;
                if (Main.GameMode == GameModeID.Normal)
                    multiplier = 22f / 144f / (1f / 12f);
                AddLoot(ItemID.RifleScope, (int)(GetInstance<AEnemyLootConfig>().RifleScopeAndSniperRifleIncrease * multiplier));
                AddLoot(ItemID.SniperRifle, (int)(GetInstance<AEnemyLootConfig>().RifleScopeAndSniperRifleIncrease * multiplier));
            }
            if (npc.type == NPCID.TacticalSkeleton)
            {
                float multiplier = 1f;
                if (Main.GameMode == GameModeID.Normal)
                {
                    multiplier = 23f / 144f / (1f / 12f);
                }
                AddLoot(ItemID.SWATHelmet, (int)(GetInstance<AEnemyLootConfig>().SWATHelmetAndTacticalShotgunIncrease * multiplier));
                AddLoot(ItemID.TacticalShotgun, (int)(GetInstance<AEnemyLootConfig>().SWATHelmetAndTacticalShotgunIncrease * multiplier));
            }
            if (npc.type == NPCID.SkeletonCommando)
            {
                float multiplier = 1f;
                if (Main.GameMode == GameModeID.Normal)
                    multiplier = 35f / 324f / (1f / 18f);
                AddLoot(ItemID.RocketLauncher, (int)(GetInstance<AEnemyLootConfig>().RocketLauncherIncrease * multiplier));
            }
            if (npc.type == NPCID.Paladin)
            {
                float PaladinsHammerIncreasemultiplier = 1f;
                float PaladinsShieldIncreasemultiplier = 1f;
                if (Main.GameMode == GameModeID.Normal)
                {
                    PaladinsHammerIncreasemultiplier = 22f / 225f / (1f / 15f);
                    PaladinsShieldIncreasemultiplier = 763f / 5625f / (7f / 75f);
                }
                AddLoot(ItemID.PaladinsHammer, (int)(GetInstance<AEnemyLootConfig>().PaladinsHammerIncrease * PaladinsHammerIncreasemultiplier));
                AddLoot(ItemID.PaladinsShield, (int)(GetInstance<AEnemyLootConfig>().PaladinsShieldIncrease * PaladinsShieldIncreasemultiplier));
            }
            if (npc.type == NPCID.EaterofSouls || npc.type == NPCID.LittleEater || npc.type == NPCID.BigEater || npc.type == NPCID.DevourerHead || npc.type == NPCID.Corruptor)
                AddLoot(ItemID.RottenChunk, GetInstance<AEnemyLootConfig>().RottenChunkAndVertebra);
            if (npc.type == NPCID.BloodCrawler || npc.type == NPCID.BloodCrawlerWall || npc.type == NPCID.Crimera || npc.type == NPCID.LittleCrimera || npc.type == NPCID.BigCrimera || npc.type == NPCID.FaceMonster || npc.type == NPCID.FloatyGross)
                AddLoot(ItemID.Vertebrae, GetInstance<AEnemyLootConfig>().RottenChunkAndVertebra);
            if (npc.type == NPCID.DemonEye || npc.type == NPCID.DemonEye2 || npc.type == NPCID.CataractEye || npc.type == NPCID.CataractEye2 || npc.type == NPCID.SleepyEye || npc.type == NPCID.SleepyEye2 || npc.type == NPCID.DialatedEye || npc.type == NPCID.DialatedEye2 || npc.type == NPCID.GreenEye || npc.type == NPCID.GreenEye2 || npc.type == NPCID.PurpleEye || npc.type == NPCID.PurpleEye2 || npc.type == NPCID.DemonEyeOwl || npc.type == NPCID.DemonEyeSpaceship || npc.type == NPCID.WanderingEye)
                AddLoot(ItemID.Lens, GetInstance<AEnemyLootConfig>().LensIncrease);
            #endregion

            #region Pirates
            if (NPC_IsAnyTypes(212, 213, 214, 215, 216, 491)) //All Human Pirates and Flying Dutchman
            {
                //
                //TO-DO 1.4.4 is going to boost pirate drop rates. I added coding to immitate the new rates, but when the udpate comes out: look into the changes and the source code, and modify the coding below. So far, it's unknown exactly how the Flying Dutchman rates will be, but I assume it has to at least be twice as likely (some will go as far as 10 times more likely, but it's unknown what that is).

                int denominator_multiplier = 10;
                if (npc.type == NPCID.PirateCaptain)
                    denominator_multiplier = 5;
                else if (npc.type == NPCID.PirateShip)
                    denominator_multiplier = 1;

                foreach (var rule in npcLoot.Get())
                {
                    if (rule is CommonDrop commonDrop && (commonDrop.itemId == ItemID.CoinGun || commonDrop.itemId == ItemID.CoinGun || commonDrop.itemId == ItemID.CoinGun || commonDrop.itemId == ItemID.LuckyCoin || commonDrop.itemId == ItemID.DiscountCard || commonDrop.itemId == ItemID.PirateStaff || commonDrop.itemId == ItemID.GoldRing || commonDrop.itemId == ItemID.Cutlass))
                        commonDrop.chanceDenominator /= 2;
                }

                if (npc.type == NPCID.PirateShip)
                {
                    npcLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, 1704, 1705, 1710, 1716, 1720, 2133, 2137, 2143, 2147, 2151, 2155, 2238, 2379, 2389, 2405, 2663, 2843, 3885, 3904, 3910)); //Always drop 1 Golden Furniture
                    var config = GetInstance<AEnemyLootConfig>().TheDutchmansTresureChance;
                    if (config > 0)
                        AddCondtionalLootMaxMin(ItemType<Items.TheDutchmansTreasure>(), new FirstDutchman(), new int[] { config, config }); //TO-DO When 1.4.4 comes out, it's possible that I'll adjust these or remove the item.
                }

                AddLoot(ItemID.CoinGun, GetInstance<AEnemyLootConfig>().CoinGunBaseIncrease * denominator_multiplier);
                AddLoot(ItemID.LuckyCoin, GetInstance<AEnemyLootConfig>().LuckyCoinBaseIncrease * denominator_multiplier);
                AddLoot(ItemID.DiscountCard, GetInstance<AEnemyLootConfig>().DiscountCardBaseIncrease * denominator_multiplier);
                AddLoot(ItemID.PirateStaff, GetInstance<AEnemyLootConfig>().PirateStaffBaseIncrease * denominator_multiplier);
                AddLoot(ItemID.GoldRing, GetInstance<AEnemyLootConfig>().GoldRingBaseIncrease * denominator_multiplier);
                AddLoot(ItemID.Cutlass, GetInstance<AEnemyLootConfig>().CutlassBaseIncrease * denominator_multiplier);
            }
            #endregion
            #endregion

            #region Drops That Don't Happen in Vanilla

            #region Boss Drops
            if (npc.type == NPCID.DukeFishron)
                AddBossLoot(ItemID.TruffleWorm, GetInstance<BEnemyLootNonVanillaConfig>().TrufflewormFromDukeFishron);

            if (npc.type == NPCID.Plantera)
                AddLoot(ItemType<Items.PlanteraSap>(), GetInstance<HOtherModdedItemsConfig>().PlanteraSapFromPlantera);

            if (npc.type == NPCID.KingSlime)
                AddBossLoot(ItemID.SlimeStaff, GetInstance<BEnemyLootNonVanillaConfig>().SlimeStaffFromSlimeKing);
            #endregion

            #region Non-Boss Drops
            if (npc.type == NPCID.DuneSplicerHead)
            {
                AddLootMaxMin(ItemID.DesertFossil, GetInstance<BEnemyLootNonVanillaConfig>().DesertFossilFromDuneSplicer);
                AddCondtionalLootMaxMin(ItemID.SandBlock, new ZoneNonInfection(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromDuneSplicer);
                AddCondtionalLootMaxMin(ItemID.EbonsandBlock, new ZoneCorruptnNoOtherInfection(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromDuneSplicer);
                AddCondtionalLootMaxMin(ItemID.CrimsandBlock, new ZoneCrimsonNoOtherInfection(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromDuneSplicer);
                AddCondtionalLootMaxMin(ItemID.PearlsandBlock, new ZoneHallow(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromDuneSplicer);
            }

            if (npc.type == NPCID.TombCrawlerHead)
            {
                AddLootMaxMin(ItemID.DesertFossil, GetInstance<BEnemyLootNonVanillaConfig>().DesertFossilFromTombCrawler);
                AddCondtionalLootMaxMin(ItemID.SandBlock, new ZoneNonInfection(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromTombCrawler);
                AddCondtionalLootMaxMin(ItemID.EbonsandBlock, new ZoneCorruptnNoOtherInfection(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromTombCrawler);
                AddCondtionalLootMaxMin(ItemID.CrimsandBlock, new ZoneCrimsonNoOtherInfection(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromTombCrawler);
                AddCondtionalLootMaxMin(ItemID.PearlsandBlock, new ZoneHallow(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromTombCrawler);
            }

            if (npc.type == NPCID.SandElemental)
                AddLoot(ItemID.SandstorminaBottle, GetInstance<BEnemyLootNonVanillaConfig>().SandstormInABottleFromSandElemental);

            if (npc.type == NPCID.SpikedIceSlime)
                AddLoot(ItemID.SnowballLauncher, GetInstance<BEnemyLootNonVanillaConfig>().SnowballLauncherFromSpikedIceSlime); //TO-DO This might not be needed it 1.4.4

            if (npc.type == NPCID.GreekSkeleton || npc.type == NPCID.Medusa)
                AddLootMaxMin(ItemID.Marble, GetInstance<BEnemyLootNonVanillaConfig>().MarbleFromMarbleCaveEnemies);
            #endregion
            #endregion
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

            config = GetInstance<AEnemyLootConfig>().BloodyMacheteAndBladedGloveIncrease;
            if (config > 0)
            {
                globalLoot.Add(ItemDropRule.ByCondition(new Conditions.HalloweenWeapons(), 1825, config));
                globalLoot.Add(ItemDropRule.ByCondition(new Conditions.HalloweenWeapons(), 1827, config));
            }

            config = GetInstance<AEnemyLootConfig>().SoulOfLightAndNight;
            if (config > 0)
            {
                globalLoot.Add(ItemDropRule.ByCondition(new Conditions.SoulOfLight(), ItemID.SoulofLight, config));
                globalLoot.Add(ItemDropRule.ByCondition(new Conditions.SoulOfNight(), ItemID.SoulofNight, config));
            }
        }

        public override void OnKill(NPC npc)
        {
            if (npc.type == NPCID.PirateShip)
            {
                Update.dutchmanKills++;
                if (Main.netMode == NetmodeID.Server)
                {
                    ModPacket packet = Mod.GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.dutchmanKills);
                    packet.Write(Update.dutchmanKills);
                    packet.Send();
                }
            }
        }
    }
}
