using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.NPCs
{
	[AutoloadHead]
    public class StationaryMerchant : ModNPC
	{
		public override string Texture => "ReducedGrinding/NPCs/StationaryMerchant";

		public override string[] AltTextures => new[] { "ReducedGrinding/NPCs/StationaryMerchant_alt" };

		public static bool baseshop = false;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stationary Merchant");
		}
		
        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 32; //His hitbox, the visual width/height is affected by frame count below.
			npc.height = 50;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            Main.npcFrameCount[npc.type] = 26;
            animationType = NPCID.Guide;
        }
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
			if (GetInstance<ETravelingAndStationaryMerchantConfig>().StationaryMerchant)
				return true;
			else
				return false;
        }

        public override string TownNPCName()
        {										//NPC names
            switch (Main.rand.Next(18))
            {
                case 0:
                    return "Abe";
                case 1:
                    return "Alph";
                case 2:
                    return "Elmer";
                case 3:
                    return "Lewis";
                case 4:
					return "Ralph";
                case 5:
					return "Rodney";
                case 6:
					return "Romero";
                case 7:
					return "Will";
                case 8:
					return "Dan";
                case 9:
					return "Boyd";
                case 10:
					return "Galahan";
                case 11:
					return "Mervin";
				case 12:
					return "Rico";
				case 13:
					return "Albert";
				case 14:
					return "Archibald";
				case 15:
					return "Graham";
				case 16:
					return "Gray";
				default:
					return "Stephan";
            }
        }

        public override string GetChat()
		{
			if (!ReducedGrindingWorld.smItemDecorShopNotEmpty && !ReducedGrindingWorld.smItemShopNotEmpty)
				return "I don't have anything at the moment. I sometimes get supplies from merchants who travel by here. Check back later.";
			else if (!ReducedGrindingWorld.smItemDecorShopNotEmpty)
				return "I don't have decor at the moment. I sometimes get supplies from merchants who travel by here. Check back later if you want decor.";
			else if (!ReducedGrindingWorld.smItemShopNotEmpty)
				return "I don't have non-decor at the moment. I sometimes get supplies from merchants who travel by here. Check back later if you want non-decor.";
			else
			{
				if (Terraria.GameContent.Events.BirthdayParty.PartyIsUp && Main.rand.Next(3) == 0)
				{
					return "I bet travelers miss parties a lot.";
				}
				else
				{
					switch (Main.rand.Next(4))
					{
						case 0:
							return "Don't worry, I'm not going anywhere!";
						case 1:
							return "I like to stock up on goods from merchants that pass by here.";
						case 2:
							return "I could go hunting for rare items, but I'd rather buy them from those who do.";
						default:
							return "Would you like to see some goods that I've aquired from travelers?";
					}
				}
			}
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
            button2 = "Decor Shop";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
			{
				shop = true;
				baseshop = true;
			}
			else //Docor Shop
			{
				shop = true;
				baseshop = false;
			}
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
			if (baseshop)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("Traveling_Merchant_Restock_Order"));
				nextSlot++;
				if (ReducedGrindingWorld.smItemSake)
				{
					shop.item[nextSlot].SetDefaults(ItemID.Sake);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemPho)
				{
					shop.item[nextSlot].SetDefaults(ItemID.Pho);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemPadThai)
				{
					shop.item[nextSlot].SetDefaults(ItemID.PadThai);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemUltrabrightTorch)
				{
					shop.item[nextSlot].SetDefaults(ItemID.UltrabrightTorch);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemAmmoBox)
				{
					shop.item[nextSlot].SetDefaults(ItemID.AmmoBox);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemMagicHat)
				{
					shop.item[nextSlot].SetDefaults(ItemID.MagicHat);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemGypsyRobe)
				{
					shop.item[nextSlot].SetDefaults(ItemID.GypsyRobe);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemGi)
				{
					shop.item[nextSlot].SetDefaults(ItemID.Gi);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemCelestialMagnet)
				{
					shop.item[nextSlot].SetDefaults(ItemID.CelestialMagnet);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemDPSMeter)
				{
					shop.item[nextSlot].SetDefaults(ItemID.DPSMeter);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemLifeformAnalyzer)
				{
					shop.item[nextSlot].SetDefaults(ItemID.LifeformAnalyzer);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemStopwatch)
				{
					shop.item[nextSlot].SetDefaults(ItemID.Stopwatch);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemPaintSprayer)
				{
					shop.item[nextSlot].SetDefaults(ItemID.PaintSprayer);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemBrickLayer)
				{
					shop.item[nextSlot].SetDefaults(ItemID.BrickLayer);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemPortableCementMixer)
				{
					shop.item[nextSlot].SetDefaults(ItemID.PortableCementMixer);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemExtendoGrip)
				{
					shop.item[nextSlot].SetDefaults(ItemID.ExtendoGrip);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemPresserator)
				{
					shop.item[nextSlot].SetDefaults(ItemID.ActuationAccessory);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemBlackCounterweight)
				{
					shop.item[nextSlot].SetDefaults(ItemID.BlackCounterweight);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemYellowCounterweight)
				{
					shop.item[nextSlot].SetDefaults(ItemID.YellowCounterweight);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemSittingDucksFishingPole)
				{
					shop.item[nextSlot].SetDefaults(ItemID.SittingDucksFishingRod);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemKatana)
				{
					shop.item[nextSlot].SetDefaults(ItemID.Katana);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemCode1)
				{
					shop.item[nextSlot].SetDefaults(ItemID.Code1);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemRevolver)
				{
					shop.item[nextSlot].SetDefaults(ItemID.Revolver);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemGatligator)
				{
					shop.item[nextSlot].SetDefaults(ItemID.Gatligator);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemCode2)
				{
					shop.item[nextSlot].SetDefaults(ItemID.Code2);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemPulseBow)
				{
					shop.item[nextSlot].SetDefaults(ItemID.PulseBow);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemDiamondRing)
				{
					shop.item[nextSlot].SetDefaults(ItemID.DiamondRing);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemAngelHalo)
				{
					shop.item[nextSlot].SetDefaults(ItemID.AngelHalo);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemFez)
				{
					shop.item[nextSlot].SetDefaults(ItemID.Fez);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemWinterCape)
				{
					shop.item[nextSlot].SetDefaults(ItemID.WinterCape);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemRedCape)
				{
					shop.item[nextSlot].SetDefaults(ItemID.RedCape);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemCrimsonCloak)
				{
					shop.item[nextSlot].SetDefaults(ItemID.CrimsonCloak);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemMysteriousCape)
				{
					shop.item[nextSlot].SetDefaults(ItemID.MysteriousCape);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemKimono)
				{
					shop.item[nextSlot].SetDefaults(ItemID.Kimono);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemWaterGun)
				{
					shop.item[nextSlot].SetDefaults(ItemID.WaterGun);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemCompanionCube)
				{
					shop.item[nextSlot].SetDefaults(ItemID.CompanionCube);
					nextSlot++;
				}
			}
			else //Docor Shop
			{
				if (ReducedGrindingWorld.smItemRedTeamBlock)
				{
					shop.item[nextSlot].SetDefaults(ItemID.TeamBlockRed);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.TeamBlockRedPlatform);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemYellowTeamBlock)
				{
					shop.item[nextSlot].SetDefaults(ItemID.TeamBlockYellow);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.TeamBlockYellowPlatform);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemGreenTeamBlock)
				{
					shop.item[nextSlot].SetDefaults(ItemID.TeamBlockGreen);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.TeamBlockGreenPlatform);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemBlueTeamBlock)
				{
					shop.item[nextSlot].SetDefaults(ItemID.TeamBlockBlue);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.TeamBlockBluePlatform);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemPinkTeamBlock)
				{
					shop.item[nextSlot].SetDefaults(ItemID.TeamBlockPink);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.TeamBlockPinkPlatform);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemWhiteTeamBlock)
				{
					shop.item[nextSlot].SetDefaults(ItemID.TeamBlockWhite);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.TeamBlockWhitePlatform);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemChalice)
				{
					shop.item[nextSlot].SetDefaults(ItemID.SteampunkCup);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemArcaneRuneWall)
				{
					shop.item[nextSlot].SetDefaults(ItemID.ArcaneRuneWall);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemFancyDishes)
				{
					shop.item[nextSlot].SetDefaults(ItemID.FancyDishes);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemDynastyWood)
				{
					shop.item[nextSlot].SetDefaults(ItemID.DynastyWood);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.RedDynastyShingles);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.BlueDynastyShingles);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemZebraSkin)
				{
					shop.item[nextSlot].SetDefaults(ItemID.ZebraSkin);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemLeopardSkin)
				{
					shop.item[nextSlot].SetDefaults(ItemID.LeopardSkin);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemTigerSkin)
				{
					shop.item[nextSlot].SetDefaults(ItemID.TigerSkin);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemCastleMarsberg)
				{
					shop.item[nextSlot].SetDefaults(ItemID.PaintingCastleMarsberg);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemMartiaLisa)
				{
					shop.item[nextSlot].SetDefaults(ItemID.PaintingMartiaLisa);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemTheTruthIsUpThere)
				{
					shop.item[nextSlot].SetDefaults(ItemID.PaintingTheTruthIsUpThere);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemNotAKidNorASquid)
				{
					shop.item[nextSlot].SetDefaults(ItemID.MoonLordPainting);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemAcorns)
				{
					shop.item[nextSlot].SetDefaults(ItemID.PaintingAcorns);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemColdSnap)
				{
					shop.item[nextSlot].SetDefaults(ItemID.PaintingColdSnap);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemCursedSaint)
				{
					shop.item[nextSlot].SetDefaults(ItemID.PaintingCursedSaint);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemSnowfellas)
				{
					shop.item[nextSlot].SetDefaults(ItemID.PaintingSnowfellas);
					nextSlot++;
				}
				if (ReducedGrindingWorld.smItemTheSeason)
				{
					shop.item[nextSlot].SetDefaults(ItemID.PaintingTheSeason);
					nextSlot++;
				}
			}
		}
    }
}