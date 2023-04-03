using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.NPCs
{
    public class FishMerchant : ModNPC
    {
        public const string ShopName = "Shop";
        readonly static CFishingConfig fishingConfig = GetInstance<CFishingConfig>();
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.GoldfishWalker];
            NPCID.Sets.DangerDetectRange[Type] = 700;
            NPCID.Sets.AttackType[Type] = 0;
            NPCID.Sets.AttackTime[Type] = 90;
            NPCID.Sets.AttackAverageChance[Type] = 30;
            NPCID.Sets.HatOffsetY[Type] = 4;

            NPCID.Sets.ActsLikeTownNPC[Type] = true;

            NPCID.Sets.SpawnsWithCustomName[Type] = true;

            NPCID.Sets.NPCBestiaryDrawModifiers bestiaryData = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Hide = true
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, bestiaryData);
        }

        public override void SetDefaults()
        {
            NPC.friendly = true;
            NPC.width = 24;
            NPC.height = 30;
            NPC.aiStyle = NPCAIStyleID.Passive;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;

            AnimationType = NPCID.GoldfishWalker;
        }

        public override bool CanChat()
        {
            return true;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string> {
                "Fish Merchant"
            };
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();

            chat.Add("Bloop. Buy something?");
            chat.Add(Language.GetTextValue("Bloop Bloop, Buy?"));
            chat.Add(Language.GetTextValue("Fish has wares, if you have Fish Coin."));
            return chat;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        { // What the chat buttons are when you open up the chat UI
            button = Language.GetTextValue("LegacyInterface.28"); //This is the key to the word "Shop"
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = "Shop";
            }
        }

        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName);

            Player player = Main.LocalPlayer;
            void addShopItem(int price, int itemID, int questRequirement = 0)
            {
                if (price > 0)
                {
                    if (player.anglerQuestsFinished >= questRequirement)
                    {

                        npcShop.Add(new Item(itemID)
                        {
                            shopCustomPrice = price,
                            shopSpecialCurrency = ReducedGrinding.FishCoin
                        });
                    }
                }
            }

            #region Guaranteed Items
            addShopItem(fishingConfig.FuzzyCarrotPrice, ItemID.FuzzyCarrot, fishingConfig.FuzzyCarrotQuestRewarded);
            addShopItem(fishingConfig.AnglerHatPrice, ItemID.AnglerHat, fishingConfig.AnglerHatQuestRewarded);
            addShopItem(fishingConfig.AnglerVestPrice, ItemID.AnglerVest, fishingConfig.AnglerVestQuestRewarded);
            addShopItem(fishingConfig.AnglerPantsPrice, ItemID.AnglerPants, fishingConfig.AnglerPantsQuestRewarded);
            addShopItem(fishingConfig.AnglerPantsPrice, ItemID.GoldenFishingRod, fishingConfig.GoldenFishingRod);
            if (fishingConfig.BottomlessWaterBucket > 0)
            {
                addShopItem(fishingConfig.AnglerPantsPrice, ItemID.GoldenFishingRod, fishingConfig.BottomlessWaterBucket);
            }
            #endregion

            #region Hardmode Items
            if (Main.hardMode)
            {
                addShopItem(fishingConfig.HotlineFishingHook, ItemID.HotlineFishingHook, 25);
                addShopItem(fishingConfig.FinWings, ItemID.FinWings, 11);
                addShopItem(fishingConfig.SuperAbsorbantSponge, ItemID.SuperAbsorbantSponge, 10);
                if (fishingConfig.BottomlessWaterBucket == 0)
                {
                    addShopItem(fishingConfig.BottomlessWaterBucket, ItemID.BottomlessBucket, 10);
                }
            }
            #endregion

            #region Items Always Available
            addShopItem(fishingConfig.GoldenBugNet, ItemID.GoldenBugNet);
            addShopItem(fishingConfig.FishHook, ItemID.FishHook);
            addShopItem(fishingConfig.Minecarp, ItemID.FishMinecart);
            addShopItem(fishingConfig.AnglerTackleBagIngredients, ItemID.HighTestFishingLine);
            addShopItem(fishingConfig.AnglerTackleBagIngredients, ItemID.AnglerEarring);
            addShopItem(fishingConfig.AnglerTackleBagIngredients, ItemID.TackleBox);
            addShopItem(fishingConfig.FishFinderIngredients, ItemID.FishermansGuide);
            addShopItem(fishingConfig.FishFinderIngredients, ItemID.WeatherRadio);
            addShopItem(fishingConfig.FishFinderIngredients, ItemID.Sextant);
            addShopItem(fishingConfig.VanitySets, ItemType<Items.MermaidCostumeBag>());
            addShopItem(fishingConfig.VanitySets, ItemType<Items.FishCostumeBag>());
            #endregion
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 1;
            knockback = 1f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 1f;
        }
    }
}
