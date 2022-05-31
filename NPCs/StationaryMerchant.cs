using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using static Terraria.ModLoader.ModContent;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System.Collections.Generic;
using ReLogic.Content;

namespace ReducedGrinding.NPCs
{
    [AutoloadHead]
    public class StationaryMerchant : ModNPC
	{
		/*public override string Texture => "ReducedGrinding/NPCs/StationaryMerchant";

		public override string[] AltTextures => new[] { "ReducedGrinding/NPCs/StationaryMerchant_alt" };*/

		public class ExamplePersonProfile : ITownNPCProfile
		{
			public int RollVariation() => 0;
			public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

			public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
			{
				if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
					return ModContent.Request<Texture2D>("ReducedGrinding/NPCs/StationaryMerchant");

				if (npc.altTexture == 1)
					return ModContent.Request<Texture2D>("ReducedGrinding/NPCs/StationaryMerchant_alt");

				return ModContent.Request<Texture2D>("ReducedGrinding/NPCs/StationaryMerchant");
			}

			public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("ReducedGrinding/NPCs/StationaryMerchant_Head.png");
		}

		public static bool baseshop = false;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stationary Merchant");
		}
		
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 32; //His hitbox, the visual width/height is affected by frame count below.
			NPC.height = 50;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            Main.npcFrameCount[Type] = 26;
            AnimationType = NPCID.Guide;
			NPCID.Sets.HatOffsetY[Type] = 12;
		}
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
			if (GetInstance<ETravelingAndStationaryMerchantConfig>().StationaryMerchant)
				return true;
			else
				return false;
        }

		public override List<string> SetNPCNameList()
		{
			return new List<string>() {
				"Albert",
				"Archibald",
				"Graham",
				"Gray"
			};
        }

        public override string GetChat()
        {
			bool TravellingMerchantExists = false;

			for (int i = 0; i < Terraria.Main.npc.Length; i++)
			{
				if (Terraria.Main.npc[i].type == NPCID.TravellingMerchant)
				{
					TravellingMerchantExists = true;
					break;
				}
			}

			int SaleType;
			if (GetInstance<ETravelingAndStationaryMerchantConfig>().S_MerchantPriceMultiplierDuringSale < GetInstance<ETravelingAndStationaryMerchantConfig>().S_MerchantPriceMultiplier)
				SaleType = 1;
			else if (GetInstance<ETravelingAndStationaryMerchantConfig>().S_MerchantPriceMultiplierDuringSale > GetInstance<ETravelingAndStationaryMerchantConfig>().S_MerchantPriceMultiplier)
				SaleType = -1;
			else
				SaleType = 0;

			if ((TravellingMerchantExists && SaleType == 1) || (!TravellingMerchantExists && SaleType == -1))
				return "Everything is on sale!";
			else
			{
				if (Terraria.GameContent.Events.BirthdayParty.PartyIsUp && Main.rand.NextBool(3))
				{
					return "I bet travelers miss parties a lot.";
				}
				else
				{
					switch (Main.rand.Next(2))
					{
						case 0:
							return "Don't worry, I'm not going anywhere!";
						default:
							if (SaleType == 1)
								return "I like to have a sales when traveling merchants arrive.";
							else if (SaleType == -1)
								return "I like to have sales when traveling merchants are away.";
							else
								return "My prices never change.";
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
			bool TravellingMerchantExists = false;
			float BaseMultiplier;
			for (int i = 0; i < Terraria.Main.npc.Length; i++)
			{
				if (Terraria.Main.npc[i].type == NPCID.TravellingMerchant)
				{
					TravellingMerchantExists = true;
					break;
				}
			}
			if (TravellingMerchantExists)
				BaseMultiplier = GetInstance<ETravelingAndStationaryMerchantConfig>().S_MerchantPriceMultiplierDuringSale;
			else
				BaseMultiplier = GetInstance<ETravelingAndStationaryMerchantConfig>().S_MerchantPriceMultiplier;

			float RarityMultiplier = GetInstance<ETravelingAndStationaryMerchantConfig>().S_MerchantRarityFee;
			int Rarity;

			int MaxPrice = 999999999;

			if (baseshop)
			{
				Rarity = 1;
				shop.item[nextSlot].SetDefaults(ItemID.DPSMeter);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 5) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.LifeformAnalyzer);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 5) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.Stopwatch);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 5) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.Sake);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 5) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.Pho);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 30) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.PadThai);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 20) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				Rarity = 2;
				shop.item[nextSlot].SetDefaults(ItemID.UltrabrightTorch);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 3) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.PaintSprayer);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 10) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.BrickLayer);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 10) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.PortableCementMixer);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 10) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.ExtendoGrip);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 10) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.ActuationAccessory);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 10) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.Katana);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 4) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				Rarity = 3;
				shop.item[nextSlot].SetDefaults(ItemID.AmmoBox);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 15) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.MagicHat);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 3) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.GypsyRobe);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 3, 50) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.Gi);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 2) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				if (NPC.downedBoss1)
				{
					shop.item[nextSlot].SetDefaults(ItemID.Code1);
					shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 5) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
					nextSlot++;
				}

				if (NPC.downedMechBossAny)
				{
					shop.item[nextSlot].SetDefaults(ItemID.Code2);
					shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 25) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
					nextSlot++;
				}

				if (WorldGen.shadowOrbSmashed)
				{
					shop.item[nextSlot].SetDefaults(ItemID.Revolver);
					shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 10) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
					nextSlot++;
				}

				shop.item[nextSlot].SetDefaults(ItemID.Fez);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 3, 50) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;


				Rarity = 4;
				shop.item[nextSlot].SetDefaults(ItemID.CelestialMagnet);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 15) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.YellowCounterweight);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 5) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.SittingDucksFishingRod);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 35) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				if (NPC.downedPlantBoss)
				{
					shop.item[nextSlot].SetDefaults(ItemID.PulseBow);
					shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 45) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
					nextSlot++;
				}

				shop.item[nextSlot].SetDefaults(ItemID.DiamondRing);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(2) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.WinterCape);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 5) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.RedCape);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 5) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.CrimsonCloak);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 5) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.MysteriousCape);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 5) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.WaterGun);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 1, 50) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.CompanionCube);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(5) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				Rarity = 5;
				shop.item[nextSlot].SetDefaults(ItemID.BlackCounterweight);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 5) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				if (Main.hardMode)
				{
					shop.item[nextSlot].SetDefaults(ItemID.Gatligator);
					shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 35) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
					nextSlot++;
				}

				shop.item[nextSlot].SetDefaults(ItemID.Kimono);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 1) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				Rarity = 6;
				shop.item[nextSlot].SetDefaults(ItemID.AngelHalo);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 40) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;
			}
			else //Docor Shop
			{
				Rarity = 1;
				shop.item[nextSlot].SetDefaults(ItemID.TeamBlockRed);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 1) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.TeamBlockRedPlatform);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 1) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.TeamBlockYellow);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 1) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.TeamBlockYellowPlatform);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 1) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.TeamBlockGreen);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 1) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.TeamBlockGreenPlatform);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 1) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.TeamBlockBlue);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 1) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.TeamBlockBluePlatform);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 1) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.TeamBlockPink);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 1) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.TeamBlockPinkPlatform);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 1) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.TeamBlockWhite);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 1) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.TeamBlockWhitePlatform);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 1) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.SteampunkCup);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 50) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.FancyDishes);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 20) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.DynastyWood);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 0, 50) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.RedDynastyShingles);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 0, 50) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.BlueDynastyShingles);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 0, 50) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.ZebraSkin);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 1) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.LeopardSkin);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 1) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.TigerSkin);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 1) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;

				Rarity = 3;
				if (Main.xMas)
				{
					shop.item[nextSlot].SetDefaults(ItemID.PaintingTheSeason);
					shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 50) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
					nextSlot++;

					shop.item[nextSlot].SetDefaults(ItemID.PaintingSnowfellas);
					shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 50) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
					nextSlot++;

					shop.item[nextSlot].SetDefaults(ItemID.PaintingColdSnap);
					shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 50) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
					nextSlot++;

					shop.item[nextSlot].SetDefaults(ItemID.PaintingCursedSaint);
					shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 50) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
					nextSlot++;

					shop.item[nextSlot].SetDefaults(ItemID.PaintingAcorns);
					shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 50) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
					nextSlot++;
				}

				if (NPC.downedMartians)
				{
					shop.item[nextSlot].SetDefaults(ItemID.PaintingTheTruthIsUpThere);
					shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 2) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
					nextSlot++;

					shop.item[nextSlot].SetDefaults(ItemID.PaintingMartiaLisa);
					shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 2) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
					nextSlot++;

					shop.item[nextSlot].SetDefaults(ItemID.PaintingCastleMarsberg);
					shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 2) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
					nextSlot++;
				}

				if (NPC.downedMoonlord)
				{
					shop.item[nextSlot].SetDefaults(ItemID.MoonLordPainting);
					shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 3) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
					nextSlot++;
				}

				Rarity = 5;
				shop.item[nextSlot].SetDefaults(ItemID.ArcaneRuneWall);
				shop.item[nextSlot].shopCustomPrice = (int)Math.Min(MaxPrice, Terraria.Item.buyPrice(0, 0, 2, 50) * BaseMultiplier * (1 + RarityMultiplier * (Rarity - 1)));
				nextSlot++;
			}
		}
    }
}