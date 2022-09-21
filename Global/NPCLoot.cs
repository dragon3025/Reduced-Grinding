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
            void lootAdd(int itemType, int denominator)
            {
                if (denominator > 0)
                    npcLoot.Add(ItemDropRule.Common(itemType, denominator));
            }

            void lootAddMinMax(int itemType, int[] config)
            {
                if (config.Max() > 0)
                    npcLoot.Add(ItemDropRule.Common(itemType, 1, config.Min(), config.Max()));
            }

            void lootAddBasedOnExpertMode(int itemType, int normalDenominator, int expertDenominator)
            {
                if (normalDenominator > 0 || expertDenominator > 0)
                {
                    IItemDropRule normalDrop = ItemDropRule.Common(itemType, normalDenominator);
                    IItemDropRule expertDrop = ItemDropRule.Common(itemType, expertDenominator);

                    if (normalDenominator == 0)
                        normalDrop = ItemDropRule.DropNothing();

                    if (expertDenominator == 0)
                        expertDrop = ItemDropRule.DropNothing();

                    if (normalDenominator > 0)
                        npcLoot.Add(new DropBasedOnExpertMode(normalDrop, expertDrop));
                }
            }

            void lootAddMinMaxConditional(int itemType, IItemDropRuleCondition condition, int[] config)
            {
                if (config.Max() > 0 && config.Min() >= 0)
                {
                    IItemDropRule conditionalRule = new LeadingConditionRule(condition);

                    IItemDropRule rule = ItemDropRule.Common(itemType, 1, config.Min(), config.Max());

                    conditionalRule.OnSuccess(rule);

                    npcLoot.Add(conditionalRule);
                }
            }
            #endregion

            #region Boss Drops
            if (npc.type == NPCID.DukeFishron)
            {
                lootAddBasedOnExpertMode(ItemID.FishronWings, (int)(GetInstance<AEnemyLootConfig>().EmpressAndFishronWingsIncrease * 3f / 2f), 0);
                lootAddBasedOnExpertMode(ItemID.TruffleWorm, GetInstance<BEnemyLootNonVanillaConfig>().TrufflewormFromDukeFishron, 0);
            }
            if (npc.type == NPCID.HallowBoss)
            {
                lootAddBasedOnExpertMode(ItemID.RainbowWings, (int)(GetInstance<AEnemyLootConfig>().EmpressAndFishronWingsIncrease * 3f / 2f), 0);
                lootAddBasedOnExpertMode(ItemID.SparkleGuitar, (int)(GetInstance<AEnemyLootConfig>().StellarTuneIncrease * 5f / 2f), 0);
                lootAddBasedOnExpertMode(ItemID.RainbowCursor, GetInstance<AEnemyLootConfig>().RainbowCursor, 0);
            }
            if (npc.type == NPCID.EyeofCthulhu)
                lootAddBasedOnExpertMode(ItemID.Binoculars, (int)(GetInstance<AEnemyLootConfig>().BinocularsIncrease * 4f / 3f), 0);
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
                lootAdd(ItemID.DyeTradersScimitar, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.Painter)
                lootAdd(ItemID.PainterPaintballGun, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.DD2Bartender)
                lootAdd(ItemID.AleThrowingGlove, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.Stylist)
                lootAdd(ItemID.StylistKilLaKillScissorsIWish, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.Mechanic)
                lootAdd(ItemID.CombatWrench, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.TaxCollector)
                lootAdd(ItemID.TaxCollectorsStickOfDoom, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            if (npc.type == NPCID.Princess)
                lootAdd(ItemID.PrincessWeapon, GetInstance<AEnemyLootConfig>().TownNPCWeapons);
            #endregion

            #region Basic NPCs
            if (npc.type == NPCID.SkeletonArcher)
                lootAdd(ItemID.Marrow, GetInstance<AEnemyLootConfig>().MarrowIncrease);
            if (npc.type == NPCID.ArmoredSkeleton)
                lootAdd(ItemID.BeamSword, GetInstance<AEnemyLootConfig>().BeamSwordIncrease);
            if (npc.type == NPCID.FireImp)
                lootAdd(ItemID.PlumbersHat, GetInstance<AEnemyLootConfig>().PlumbersHatIncrease);
            if (npc.type == NPCID.ChaosElemental)
                lootAddBasedOnExpertMode(ItemID.RodofDiscord, (int)(GetInstance<AEnemyLootConfig>().RodofDiscordIncrease * 5f / 4f), GetInstance<AEnemyLootConfig>().RodofDiscordIncrease);
            if (npc.type == NPCID.Lihzahrd || npc.type == NPCID.LihzahrdCrawler || npc.type == NPCID.FlyingSnake)
                lootAdd(ItemID.LizardEgg, GetInstance<AEnemyLootConfig>().LizardEggIncrease);
            if (npc.type == NPCID.Pinky)
                lootAddBasedOnExpertMode(ItemID.SlimeStaff, (int)(GetInstance<AEnemyLootConfig>().SlimeStaffFromPinkyIncrease * 10f / 7f), GetInstance<AEnemyLootConfig>().SlimeStaffFromPinkyIncrease);
            if (npc.type == NPCID.SandSlime)
                lootAddBasedOnExpertMode(ItemID.SlimeStaff, (int)(GetInstance<AEnemyLootConfig>().SlimeStaffFromSandSlimeIncrease * 10f / 7f), GetInstance<AEnemyLootConfig>().SlimeStaffFromSandSlimeIncrease);
            int[] otherSlimeStaffSlimes = new int[] {
                1,
                138,
                141,
                147,
                16,
                184,
                187,
                204,
                302,
                333,
                334,
                335,
                336,
                433,
                535,
                -6,
                658,
                659,
                660,
                -7,
                -8,
                -9
            };
            foreach (int i in otherSlimeStaffSlimes)
            {
                if (npc.type == i)
                    lootAddBasedOnExpertMode(ItemID.SlimeStaff, (int)(GetInstance<AEnemyLootConfig>().SlimeStaffFromOtherSlimesIncrease * 10f / 7), GetInstance<AEnemyLootConfig>().SlimeStaffFromOtherSlimesIncrease);
            }
            if (npc.type == NPCID.SkeletonSniper)
            {
                lootAddBasedOnExpertMode(ItemID.RifleScope, (int)(GetInstance<AEnemyLootConfig>().RifleScopeAndSniperRifleIncrease * (22f / 144f / (1f / 12f))), GetInstance<AEnemyLootConfig>().RifleScopeAndSniperRifleIncrease);
                lootAddBasedOnExpertMode(ItemID.SniperRifle, (int)(GetInstance<AEnemyLootConfig>().RifleScopeAndSniperRifleIncrease * (22f / 144f / (1f / 12f))), GetInstance<AEnemyLootConfig>().RifleScopeAndSniperRifleIncrease);
            }
            if (npc.type == NPCID.TacticalSkeleton)
            {
                lootAddBasedOnExpertMode(ItemID.SWATHelmet, (int)(GetInstance<AEnemyLootConfig>().SWATHelmetAndTacticalShotgunIncrease * (23f / 144f / (1f / 12f))), GetInstance<AEnemyLootConfig>().SWATHelmetAndTacticalShotgunIncrease);
                lootAddBasedOnExpertMode(ItemID.TacticalShotgun, (int)(GetInstance<AEnemyLootConfig>().SWATHelmetAndTacticalShotgunIncrease * (23f / 144f / (1f / 12f))), GetInstance<AEnemyLootConfig>().SWATHelmetAndTacticalShotgunIncrease);
            }
            if (npc.type == NPCID.SkeletonCommando)
                lootAddBasedOnExpertMode(ItemID.RocketLauncher, (int)(GetInstance<AEnemyLootConfig>().RocketLauncherIncrease * (35f / 324f / (1f / 18f))), GetInstance<AEnemyLootConfig>().RocketLauncherIncrease);
            if (npc.type == NPCID.Paladin)
            {
                lootAddBasedOnExpertMode(ItemID.PaladinsHammer, (int)(GetInstance<AEnemyLootConfig>().PaladinsHammerIncrease * (22f / 225f / (1f / 15f))), GetInstance<AEnemyLootConfig>().PaladinsHammerIncrease);
                lootAddBasedOnExpertMode(ItemID.PaladinsShield, (int)(GetInstance<AEnemyLootConfig>().PaladinsShieldIncrease * (763f / 5625f / (7f / 75f))), GetInstance<AEnemyLootConfig>().PaladinsShieldIncrease);
            }
            if (npc.type == NPCID.EaterofSouls || npc.type == NPCID.LittleEater || npc.type == NPCID.BigEater || npc.type == NPCID.DevourerHead || npc.type == NPCID.Corruptor)
                lootAdd(ItemID.RottenChunk, GetInstance<AEnemyLootConfig>().RottenChunkAndVertebra);
            if (npc.type == NPCID.BloodCrawler || npc.type == NPCID.BloodCrawlerWall || npc.type == NPCID.Crimera || npc.type == NPCID.LittleCrimera || npc.type == NPCID.BigCrimera || npc.type == NPCID.FaceMonster || npc.type == NPCID.FloatyGross)
                lootAdd(ItemID.Vertebrae, GetInstance<AEnemyLootConfig>().RottenChunkAndVertebra);

            int[] demonEyes = new int[] {
                190,
                191,
                192,
                193,
                194,
                2,
                317,
                318
                - 38,
                -39,
                -40,
                -41,
                -42,
                -43
            };
            foreach (int i in demonEyes)
            {
                if (npc.type == i)
                    lootAdd(ItemID.Lens, GetInstance<AEnemyLootConfig>().LensIncrease);
            }
            #endregion

            #region Pirates
            int[] pirates = new int[] {
                491,
                216,
                215,
                214,
                213,
                212
            };
            foreach (int i in pirates)
            if (npc.type == i) //All Human Pirates and Flying Dutchman
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
                    var TheDutchmansTresureChance = GetInstance<AEnemyLootConfig>().TheDutchmansTresureChance;
                    if (TheDutchmansTresureChance > 0)
                        lootAddMinMaxConditional(ItemType<Items.TheDutchmansTreasure>(), new FirstDutchman(), new int[] { TheDutchmansTresureChance, TheDutchmansTresureChance }); //TO-DO When 1.4.4 comes out, it's possible that I'll adjust these or remove the item.
                }

                lootAdd(ItemID.CoinGun, GetInstance<AEnemyLootConfig>().CoinGunBaseIncrease * denominator_multiplier);
                lootAdd(ItemID.LuckyCoin, GetInstance<AEnemyLootConfig>().LuckyCoinBaseIncrease * denominator_multiplier);
                lootAdd(ItemID.DiscountCard, GetInstance<AEnemyLootConfig>().DiscountCardBaseIncrease * denominator_multiplier);
                lootAdd(ItemID.PirateStaff, GetInstance<AEnemyLootConfig>().PirateStaffBaseIncrease * denominator_multiplier);
                lootAdd(ItemID.GoldRing, GetInstance<AEnemyLootConfig>().GoldRingBaseIncrease * denominator_multiplier);
                lootAdd(ItemID.Cutlass, GetInstance<AEnemyLootConfig>().CutlassBaseIncrease * denominator_multiplier);
            }
            #endregion
            #endregion

            #region Drops That Don't Happen in Vanilla

            #region Boss Drops
            if (npc.type == NPCID.DukeFishron)
                lootAddBasedOnExpertMode(ItemID.TruffleWorm, GetInstance<BEnemyLootNonVanillaConfig>().TrufflewormFromDukeFishron, 0);

            if (npc.type == NPCID.Plantera)
                lootAdd(ItemType<Items.PlanteraSap>(), GetInstance<HOtherModdedItemsConfig>().PlanteraSapFromPlantera);

            if (npc.type == NPCID.KingSlime)
                lootAddBasedOnExpertMode(ItemID.SlimeStaff, GetInstance<BEnemyLootNonVanillaConfig>().SlimeStaffFromSlimeKing, 0);
            #endregion

            #region Non-Boss Drops
            if (npc.type == NPCID.DuneSplicerHead)
            {
                lootAddMinMax(ItemID.DesertFossil, GetInstance<BEnemyLootNonVanillaConfig>().DesertFossilFromDuneSplicer);
                lootAddMinMaxConditional(ItemID.SandBlock, new ZoneNonInfection(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromDuneSplicer);
                lootAddMinMaxConditional(ItemID.EbonsandBlock, new ZoneCorruptnNoOtherInfection(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromDuneSplicer);
                lootAddMinMaxConditional(ItemID.CrimsandBlock, new ZoneCrimsonNoOtherInfection(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromDuneSplicer);
                lootAddMinMaxConditional(ItemID.PearlsandBlock, new ZoneHallow(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromDuneSplicer);
            }

            if (npc.type == NPCID.TombCrawlerHead)
            {
                lootAddMinMax(ItemID.DesertFossil, GetInstance<BEnemyLootNonVanillaConfig>().DesertFossilFromTombCrawler);
                lootAddMinMaxConditional(ItemID.SandBlock, new ZoneNonInfection(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromTombCrawler);
                lootAddMinMaxConditional(ItemID.EbonsandBlock, new ZoneCorruptnNoOtherInfection(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromTombCrawler);
                lootAddMinMaxConditional(ItemID.CrimsandBlock, new ZoneCrimsonNoOtherInfection(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromTombCrawler);
                lootAddMinMaxConditional(ItemID.PearlsandBlock, new ZoneHallow(), GetInstance<BEnemyLootNonVanillaConfig>().SandFromTombCrawler);
            }

            if (npc.type == NPCID.SandElemental)
                lootAdd(ItemID.SandstorminaBottle, GetInstance<BEnemyLootNonVanillaConfig>().SandstormInABottleFromSandElemental);

            if (npc.type == NPCID.SpikedIceSlime)
                lootAdd(ItemID.SnowballLauncher, GetInstance<BEnemyLootNonVanillaConfig>().SnowballLauncherFromSpikedIceSlime); //TO-DO This might not be needed it 1.4.4

            if (npc.type == NPCID.GreekSkeleton || npc.type == NPCID.Medusa)
                lootAddMinMax(ItemID.Marble, GetInstance<BEnemyLootNonVanillaConfig>().MarbleFromMarbleCaveEnemies);
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
                if (!Update.dutchManKilled)
                {
                    Update.dutchManKilled = true;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        ModPacket packet = Mod.GetPacket();
                        packet.Write((byte)ReducedGrinding.MessageType.dutchmanKilled);
                        packet.Write(Update.dutchManKilled);
                        packet.Send();
                    }
                }
            }
        }
    }
}
