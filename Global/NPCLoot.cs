using ReducedGrinding.Common.ItemDropRules.Conditions;
using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

//Note netID is sometimes used when involving NPCs with negative IDs (variant NPCs), otherwise it gives duplicate loot drops to multiple NPCs. Not always does this happen though.
namespace ReducedGrinding.Global
{
    public class NPCLoot : GlobalNPC
    {

        readonly static AEnemyLootConfig lootConfig = GetInstance<AEnemyLootConfig>();
        readonly static BEnemyLootNonVanillaConfig nonVanillaLootConfig = GetInstance<BEnemyLootNonVanillaConfig>();

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

            //Loot Removing Experimenting (so far not completely successful).
            //Conditions.NotExpert notExpert = new Conditions.NotExpert();
            //LeadingConditionRule notExpertLCR = new LeadingConditionRule(new Conditions.NotExpert());
            #region Boss Drops
            if (npc.type == NPCID.DukeFishron)
                lootAddBasedOnExpertMode(ItemID.FishronWings, (int)(lootConfig.EmpressAndFishronWingsIncrease * 3f / 2f), 0);
            /*if (npc.type == NPCID.DukeFishron && lootConfig.EmpressAndFishronWingsIncrease > 0)
            {
                //npcLoot.RemoveWhere(rule => rule is ItemDropWithConditionRule drop && drop.itemId == ItemID.FishronWings);
                npcLoot.Add(new ItemDropWithConditionRule(ItemID.FishronWings, lootConfig.EmpressAndFishronWingsIncrease, 1, 1, notExpert));
            }*/
            if (npc.type == NPCID.HallowBoss)
            {
                lootAddBasedOnExpertMode(ItemID.RainbowWings, (int)(lootConfig.EmpressAndFishronWingsIncrease * 3f / 2f), 0);
                lootAddBasedOnExpertMode(ItemID.SparkleGuitar, (int)(lootConfig.StellarTuneIncrease * 5f / 2f), 0);
                lootAddBasedOnExpertMode(ItemID.RainbowCursor, lootConfig.RainbowCursor, 0);
            }
            if (npc.type == NPCID.EyeofCthulhu)
                lootAddBasedOnExpertMode(ItemID.Binoculars, (int)(lootConfig.BinocularsIncrease * 4f / 3f), 0);
            /*if (npc.type == NPCID.EyeofCthulhu && lootConfig.BinocularsIncrease > 0)
            {
                //npcLoot.RemoveWhere(rule => rule is ItemDropWithConditionRule drop && drop.itemId == ItemID.Binoculars);
                lootAddBasedOnExpertMode(ItemID.Binoculars, (int)(lootConfig.BinocularsIncrease * 4f / 3f), 0);
            }*/
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
                lootAdd(ItemID.DyeTradersScimitar, lootConfig.TownNPCWeapons);
            if (npc.type == NPCID.Painter)
                lootAdd(ItemID.PainterPaintballGun, lootConfig.TownNPCWeapons);
            if (npc.type == NPCID.DD2Bartender)
                lootAdd(ItemID.AleThrowingGlove, lootConfig.TownNPCWeapons);
            if (npc.type == NPCID.Stylist)
                lootAdd(ItemID.StylistKilLaKillScissorsIWish, lootConfig.TownNPCWeapons);
            if (npc.type == NPCID.Mechanic)
                lootAdd(ItemID.CombatWrench, lootConfig.TownNPCWeapons);
            if (npc.type == NPCID.TaxCollector)
                lootAdd(ItemID.TaxCollectorsStickOfDoom, lootConfig.TownNPCWeapons);
            if (npc.type == NPCID.Princess)
                lootAdd(ItemID.PrincessWeapon, lootConfig.TownNPCWeapons);
            #endregion

            #region Basic NPCs
            if (npc.type == NPCID.SkeletonArcher)
                lootAdd(ItemID.Marrow, lootConfig.MarrowIncrease);
            if (npc.type == NPCID.ArmoredSkeleton)
                lootAdd(ItemID.BeamSword, lootConfig.BeamSwordIncrease);
            if (npc.type == NPCID.FireImp)
                lootAdd(ItemID.PlumbersHat, lootConfig.PlumbersHatIncrease);
            if (npc.type == NPCID.ChaosElemental)
                lootAddBasedOnExpertMode(ItemID.RodofDiscord, (int)(lootConfig.RodofDiscordIncrease * 5f / 4f), lootConfig.RodofDiscordIncrease);
            if (npc.type == NPCID.Lihzahrd || npc.type == NPCID.LihzahrdCrawler || npc.type == NPCID.FlyingSnake)
                lootAdd(ItemID.LizardEgg, lootConfig.LizardEggIncrease);
            //netID is used for slimes because weird duplicate loot issues involving their variants (negative IDs) happen. Looking at Terraria source code, slime drops is the only time they use coding to remove duplicate drops.
            if (npc.netID == NPCID.Pinky)
                lootAddBasedOnExpertMode(ItemID.SlimeStaff, (int)(lootConfig.SlimeStaffFromPinkyIncrease * 10f / 7f), lootConfig.SlimeStaffFromPinkyIncrease);
            if (npc.netID == NPCID.SandSlime)
                lootAddBasedOnExpertMode(ItemID.SlimeStaff, (int)(lootConfig.SlimeStaffFromSandSlimeIncrease * 10f / 7f), lootConfig.SlimeStaffFromSandSlimeIncrease);
            int[] otherSlimeStaffSlimes = new int[] {
                -6,
                -7,
                -8,
                -9,
                1,
                16,
                138,
                141,
                147,
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
                658,
                659,
                660
            };
            foreach (int i in otherSlimeStaffSlimes)
            {
                if (npc.netID == i)
                    lootAddBasedOnExpertMode(ItemID.SlimeStaff, (int)(lootConfig.SlimeStaffFromOtherSlimesIncrease * 10f / 7), lootConfig.SlimeStaffFromOtherSlimesIncrease);
            }
            if (npc.type == NPCID.SkeletonSniper)
            {
                lootAddBasedOnExpertMode(ItemID.RifleScope, (int)(lootConfig.RifleScopeAndSniperRifleIncrease * (22f / 144f / (1f / 12f))), lootConfig.RifleScopeAndSniperRifleIncrease);
                lootAddBasedOnExpertMode(ItemID.SniperRifle, (int)(lootConfig.RifleScopeAndSniperRifleIncrease * (22f / 144f / (1f / 12f))), lootConfig.RifleScopeAndSniperRifleIncrease);
            }
            if (npc.type == NPCID.TacticalSkeleton)
            {
                lootAddBasedOnExpertMode(ItemID.SWATHelmet, (int)(lootConfig.SWATHelmetAndTacticalShotgunIncrease * (23f / 144f / (1f / 12f))), lootConfig.SWATHelmetAndTacticalShotgunIncrease);
                lootAddBasedOnExpertMode(ItemID.TacticalShotgun, (int)(lootConfig.SWATHelmetAndTacticalShotgunIncrease * (23f / 144f / (1f / 12f))), lootConfig.SWATHelmetAndTacticalShotgunIncrease);
            }
            if (npc.type == NPCID.SkeletonCommando)
                lootAddBasedOnExpertMode(ItemID.RocketLauncher, (int)(lootConfig.RocketLauncherIncrease * (35f / 324f / (1f / 18f))), lootConfig.RocketLauncherIncrease);
            if (npc.type == NPCID.Paladin)
            {
                lootAddBasedOnExpertMode(ItemID.PaladinsHammer, (int)(lootConfig.PaladinsHammerIncrease * (22f / 225f / (1f / 15f))), lootConfig.PaladinsHammerIncrease);
                lootAddBasedOnExpertMode(ItemID.PaladinsShield, (int)(lootConfig.PaladinsShieldIncrease * (763f / 5625f / (7f / 75f))), lootConfig.PaladinsShieldIncrease);
            }
            if (npc.type == NPCID.EaterofSouls || npc.type == NPCID.LittleEater || npc.type == NPCID.BigEater || npc.type == NPCID.Corruptor)
                lootAdd(ItemID.RottenChunk, lootConfig.RottenChunkAndVertebra);
            if (npc.type == NPCID.DevourerHead || npc.type == NPCID.DevourerBody || npc.type == NPCID.DevourerBody)
            {
                if (lootConfig.RottenChunkAndVertebra > 0)
                    npcLoot.Add(ItemDropRule.Common(ItemID.RottenChunk, lootConfig.RottenChunkAndVertebra, 1, 2));
            }
            int[] vertebraDroppers = new int[]
            {
                181, 173, 239, 182, 240
            };
            foreach (int i in vertebraDroppers)
            {
                if (npc.type == i)
                    lootAdd(ItemID.Vertebrae, lootConfig.RottenChunkAndVertebra);
            }
            int[] demonEyes = new int[] {
                190,
                191,
                192,
                193,
                194,
                2,
                317,
                318
                -38,
                -39,
                -40,
                -41,
                -42,
                -43
            };
            foreach (int i in demonEyes)
            {
                if (npc.type == i)
                    lootAdd(ItemID.Lens, lootConfig.LensIncrease);
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
                    var TheDutchmansTresureChance = lootConfig.TheDutchmansTresureChance;
                    if (TheDutchmansTresureChance > 0)
                        lootAddMinMaxConditional(ItemType<Items.TheDutchmansTreasure>(), new FirstDutchman(), new int[] { TheDutchmansTresureChance, TheDutchmansTresureChance }); //TO-DO When 1.4.4 comes out, it's possible that I'll adjust these or remove the item.
                }

                lootAdd(ItemID.CoinGun, lootConfig.CoinGunBaseIncrease * denominator_multiplier);
                lootAdd(ItemID.LuckyCoin, lootConfig.LuckyCoinBaseIncrease * denominator_multiplier);
                lootAdd(ItemID.DiscountCard, lootConfig.DiscountCardBaseIncrease * denominator_multiplier);
                lootAdd(ItemID.PirateStaff, lootConfig.PirateStaffBaseIncrease * denominator_multiplier);
                lootAdd(ItemID.GoldRing, lootConfig.GoldRingBaseIncrease * denominator_multiplier);
                lootAdd(ItemID.Cutlass, lootConfig.CutlassBaseIncrease * denominator_multiplier);
            }
            #endregion
            #endregion

            #region Drops That Don't Happen in Vanilla
                #region Boss Drops
            if (npc.type == NPCID.DukeFishron)
                lootAddBasedOnExpertMode(ItemID.TruffleWorm, nonVanillaLootConfig.TrufflewormFromDukeFishron, 0);

            if (npc.type == NPCID.Plantera)
                lootAdd(ItemType<Items.PlanteraSap>(), GetInstance<HOtherModdedItemsConfig>().PlanteraSapFromPlantera);

            if (npc.type == NPCID.KingSlime)
                lootAddBasedOnExpertMode(ItemID.SlimeStaff, nonVanillaLootConfig.SlimeStaffFromSlimeKing, 0);
            #endregion

                #region Non-Boss Drops
            if (npc.type == NPCID.DuneSplicerHead)
            {
                lootAddMinMax(ItemID.DesertFossil, nonVanillaLootConfig.DesertFossilFromDuneSplicer);
                lootAddMinMaxConditional(ItemID.SandBlock, new ZoneNonInfection(), nonVanillaLootConfig.SandFromDuneSplicer);
                lootAddMinMaxConditional(ItemID.EbonsandBlock, new ZoneCorruptnNoOtherInfection(), nonVanillaLootConfig.SandFromDuneSplicer);
                lootAddMinMaxConditional(ItemID.CrimsandBlock, new ZoneCrimsonNoOtherInfection(), nonVanillaLootConfig.SandFromDuneSplicer);
                lootAddMinMaxConditional(ItemID.PearlsandBlock, new ZoneHallow(), nonVanillaLootConfig.SandFromDuneSplicer);
            }

            if (npc.type == NPCID.TombCrawlerHead)
            {
                lootAddMinMax(ItemID.DesertFossil, nonVanillaLootConfig.DesertFossilFromTombCrawler);
                lootAddMinMaxConditional(ItemID.SandBlock, new ZoneNonInfection(), nonVanillaLootConfig.SandFromTombCrawler);
                lootAddMinMaxConditional(ItemID.EbonsandBlock, new ZoneCorruptnNoOtherInfection(), nonVanillaLootConfig.SandFromTombCrawler);
                lootAddMinMaxConditional(ItemID.CrimsandBlock, new ZoneCrimsonNoOtherInfection(), nonVanillaLootConfig.SandFromTombCrawler);
                lootAddMinMaxConditional(ItemID.PearlsandBlock, new ZoneHallow(), nonVanillaLootConfig.SandFromTombCrawler);
            }

            if (npc.type == NPCID.SandElemental)
                lootAdd(ItemID.SandstorminaBottle, nonVanillaLootConfig.SandstormInABottleFromSandElemental);

            if (npc.type == NPCID.SpikedIceSlime)
                lootAdd(ItemID.SnowballLauncher, nonVanillaLootConfig.SnowballLauncherFromSpikedIceSlime); //TO-DO This might not be needed it 1.4.4

            if (npc.type == NPCID.GreekSkeleton || npc.type == NPCID.Medusa)
                lootAddMinMax(ItemID.Marble, nonVanillaLootConfig.MarbleFromMarbleCaveEnemies);
            #endregion
            #endregion
        }

        public override void ModifyGlobalLoot(GlobalLoot globalLoot)
        {
            //Non-Boss Loot
            int config = lootConfig.GoodieBagIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(1774, config, 1, 1, new Conditions.HalloweenGoodieBagDrop()));

            config = lootConfig.PresentIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(ItemID.Present, config, 1, 1, new Conditions.XmasPresentDrop()));

            config = lootConfig.KOCannonIncrease;
            if (config > 0)
                globalLoot.Add(new ItemDropWithConditionRule(1314, config, 1, 1, new Conditions.KOCannon()));

            config = lootConfig.BiomeKeyIncrease;
            if (config > 0)
            {
                globalLoot.Add(new ItemDropWithConditionRule(1533, config, 1, 1, new Conditions.JungleKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1534, config, 1, 1, new Conditions.CorruptKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1535, config, 1, 1, new Conditions.CrimsonKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1536, config, 1, 1, new Conditions.HallowKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(1537, config, 1, 1, new Conditions.FrozenKeyCondition()));
                globalLoot.Add(new ItemDropWithConditionRule(4714, config, 1, 1, new Conditions.DesertKeyCondition()));
            }

            config = lootConfig.BloodyMacheteAndBladedGloveIncrease;
            if (config > 0)
            {
                globalLoot.Add(ItemDropRule.ByCondition(new Conditions.HalloweenWeapons(), 1825, config));
                globalLoot.Add(ItemDropRule.ByCondition(new Conditions.HalloweenWeapons(), 1827, config));
            }

            config = lootConfig.SoulOfLightAndNight;
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
