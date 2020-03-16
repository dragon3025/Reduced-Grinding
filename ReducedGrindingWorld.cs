using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;
using Terraria;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using System;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding
{
	public class ReducedGrindingWorld : ModWorld
    {
		//Gets recording into world save
		public static bool advanceMoonPhase = false;
		public static bool skipToDay = false;
		public static bool skipToNight = false;
		public static bool infectionChestMined = false;
        public static bool hallowedChestMined = false;
        public static bool frozenChestMined = false;
        public static bool jungleChestMined = false;
		public static bool smItemShopNotEmpty = false;
		public static bool smItemDecorShopNotEmpty = false;
		public static bool smItemSake = false;
		public static bool smItemPho = false;
		public static bool smItemPadThai = false;
		public static bool smItemUltrabrightTorch = false;
		public static bool smItemAmmoBox = false;
		public static bool smItemMagicHat = false;
		public static bool smItemGypsyRobe = false;
		public static bool smItemGi = false;
		public static bool smItemCelestialMagnet = false;
		public static bool smItemDPSMeter = false;
		public static bool smItemLifeformAnalyzer = false;
		public static bool smItemStopwatch = false;
		public static bool smItemPaintSprayer = false;
		public static bool smItemBrickLayer = false;
		public static bool smItemPortableCementMixer = false;
		public static bool smItemExtendoGrip = false;
		public static bool smItemPresserator = false;
		public static bool smItemBlackCounterweight = false;
		public static bool smItemYellowCounterweight = false;
		public static bool smItemSittingDucksFishingPole = false;
		public static bool smItemKatana = false;
		public static bool smItemCode1 = false;
		public static bool smItemRevolver = false;
		public static bool smItemGatligator = false;
		public static bool smItemCode2 = false;
		public static bool smItemPulseBow = false;
		public static bool smItemRedTeamBlock = false;
		public static bool smItemYellowTeamBlock = false;
		public static bool smItemGreenTeamBlock = false;
		public static bool smItemBlueTeamBlock = false;
		public static bool smItemPinkTeamBlock = false;
		public static bool smItemWhiteTeamBlock = false;
		public static bool smItemDiamondRing = false;
		public static bool smItemAngelHalo = false;
		public static bool smItemFez = false;
		public static bool smItemWinterCape = false;
		public static bool smItemRedCape = false;
		public static bool smItemCrimsonCloak = false;
		public static bool smItemMysteriousCape = false;
		public static bool smItemKimono = false;
		public static bool smItemWaterGun = false;
		public static bool smItemCompanionCube = false;
		public static bool smItemChalice = false;
		public static bool smItemArcaneRuneWall = false;
		public static bool smItemFancyDishes = false;
		public static bool smItemDynastyWood = false;
		public static bool smItemZebraSkin = false;
		public static bool smItemLeopardSkin = false;
		public static bool smItemTigerSkin = false;
		public static bool smItemCastleMarsberg = false;
		public static bool smItemMartiaLisa = false;
		public static bool smItemTheTruthIsUpThere = false;
		public static bool smItemNotAKidNorASquid = false;
		public static bool smItemAcorns = false;
		public static bool smItemColdSnap = false;
		public static bool smItemCursedSaint = false;
		public static bool smItemSnowfellas = false;
		public static bool smItemTheSeason = false;
        public static bool skippedToDayOrNight = false;

        public override void Initialize()
        {
			infectionChestMined = false;
			hallowedChestMined = false;
			frozenChestMined = false;
			jungleChestMined = false;
			smItemShopNotEmpty = false;
			smItemDecorShopNotEmpty = false;
			smItemSake = false;
			smItemPho = false;
			smItemPadThai = false;
			smItemUltrabrightTorch = false;
			smItemAmmoBox = false;
			smItemMagicHat = false;
			smItemGypsyRobe = false;
			smItemGi = false;
			smItemCelestialMagnet = false;
			smItemDPSMeter = false;
			smItemLifeformAnalyzer = false;
			smItemStopwatch = false;
			smItemPaintSprayer = false;
			smItemBrickLayer = false;
			smItemPortableCementMixer = false;
			smItemExtendoGrip = false;
			smItemPresserator = false;
			smItemBlackCounterweight = false;
			smItemYellowCounterweight = false;
			smItemSittingDucksFishingPole = false;
			smItemKatana = false;
			smItemCode1 = false;
			smItemRevolver = false;
			smItemGatligator = false;
			smItemCode2 = false;
			smItemPulseBow = false;
			smItemRedTeamBlock = false;
			smItemYellowTeamBlock = false;
			smItemGreenTeamBlock = false;
			smItemBlueTeamBlock = false;
			smItemPinkTeamBlock = false;
			smItemWhiteTeamBlock = false;
			smItemDiamondRing = false;
			smItemAngelHalo = false;
			smItemFez = false;
			smItemWinterCape = false;
			smItemRedCape = false;
			smItemCrimsonCloak = false;
			smItemMysteriousCape = false;
			smItemKimono = false;
			smItemWaterGun = false;
			smItemCompanionCube = false;
			smItemChalice = false;
			smItemArcaneRuneWall = false;
			smItemFancyDishes = false;
			smItemDynastyWood = false;
			smItemZebraSkin = false;
			smItemLeopardSkin = false;
			smItemTigerSkin = false;
			smItemCastleMarsberg = false;
			smItemMartiaLisa = false;
			smItemTheTruthIsUpThere = false;
			smItemNotAKidNorASquid = false;
			smItemAcorns = false;
			smItemColdSnap = false;
			smItemCursedSaint = false;
			smItemSnowfellas = false;
			smItemTheSeason = false;
			skippedToDayOrNight = false;
		}
		
        public override TagCompound Save()
        {
            var biomeChestMined = new List<string>();
            if (infectionChestMined) biomeChestMined.Add("infectionChestMined");
			if (hallowedChestMined) biomeChestMined.Add("hallowedChestMined");
			if (frozenChestMined) biomeChestMined.Add("frozenChestMined");
			if (jungleChestMined) biomeChestMined.Add("jungleChestMined");

			var stationaryMerchant = new List<string>();
			if (smItemShopNotEmpty) stationaryMerchant.Add("smItemShopNotEmpty");
			if (smItemDecorShopNotEmpty) stationaryMerchant.Add("smItemDecorShopNotEmpty");
			if (smItemSake) stationaryMerchant.Add("smItemSake");
			if (smItemPho) stationaryMerchant.Add("smItemPho");
			if (smItemPadThai) stationaryMerchant.Add("smItemPadThai");
			if (smItemUltrabrightTorch) stationaryMerchant.Add("smItemUltrabrightTorch");
			if (smItemAmmoBox) stationaryMerchant.Add("smItemAmmoBox");
			if (smItemMagicHat) stationaryMerchant.Add("smItemMagicHat");
			if (smItemGypsyRobe) stationaryMerchant.Add("smItemGypsyRobe");
			if (smItemGi) stationaryMerchant.Add("smItemGi");
			if (smItemCelestialMagnet) stationaryMerchant.Add("smItemCelestialMagnet");
			if (smItemDPSMeter) stationaryMerchant.Add("smItemDPSMeter");
			if (smItemLifeformAnalyzer) stationaryMerchant.Add("smItemLifeformAnalyzer");
			if (smItemStopwatch) stationaryMerchant.Add("smItemStopwatch");
			if (smItemPaintSprayer) stationaryMerchant.Add("smItemPaintSprayer");
			if (smItemBrickLayer) stationaryMerchant.Add("smItemBrickLayer");
			if (smItemPortableCementMixer) stationaryMerchant.Add("smItemPortableCementMixer");
			if (smItemExtendoGrip) stationaryMerchant.Add("smItemExtendoGrip");
			if (smItemPresserator) stationaryMerchant.Add("smItemPresserator");
			if (smItemBlackCounterweight) stationaryMerchant.Add("smItemBlackCounterweight");
			if (smItemYellowCounterweight) stationaryMerchant.Add("smItemYellowCounterweight");
			if (smItemSittingDucksFishingPole) stationaryMerchant.Add("smItemSittingDucksFishingPole");
			if (smItemKatana) stationaryMerchant.Add("smItemKatana");
			if (smItemCode1) stationaryMerchant.Add("smItemCode1");
			if (smItemRevolver) stationaryMerchant.Add("smItemRevolver");
			if (smItemGatligator) stationaryMerchant.Add("smItemGatligator");
			if (smItemCode2) stationaryMerchant.Add("smItemCode2");
			if (smItemPulseBow) stationaryMerchant.Add("smItemPulseBow");
			if (smItemRedTeamBlock) stationaryMerchant.Add("smItemRedTeamBlock");
			if (smItemYellowTeamBlock) stationaryMerchant.Add("smItemYellowTeamBlock");
			if (smItemGreenTeamBlock) stationaryMerchant.Add("smItemGreenTeamBlock");
			if (smItemBlueTeamBlock) stationaryMerchant.Add("smItemBlueTeamBlock");
			if (smItemPinkTeamBlock) stationaryMerchant.Add("smItemPinkTeamBlock");
			if (smItemWhiteTeamBlock) stationaryMerchant.Add("smItemWhiteTeamBlock");
			if (smItemDiamondRing) stationaryMerchant.Add("smItemDiamondRing");
			if (smItemAngelHalo) stationaryMerchant.Add("smItemAngelHalo");
			if (smItemFez) stationaryMerchant.Add("smItemFez");
			if (smItemWinterCape) stationaryMerchant.Add("smItemWinterCape");
			if (smItemRedCape) stationaryMerchant.Add("smItemRedCape");
			if (smItemCrimsonCloak) stationaryMerchant.Add("smItemCrimsonCloak");
			if (smItemMysteriousCape) stationaryMerchant.Add("smItemMysteriousCape");
			if (smItemKimono) stationaryMerchant.Add("smItemKimono");
			if (smItemWaterGun) stationaryMerchant.Add("smItemWaterGun");
			if (smItemCompanionCube) stationaryMerchant.Add("smItemCompanionCube");
			if (smItemChalice) stationaryMerchant.Add("smItemChalice");
			if (smItemArcaneRuneWall) stationaryMerchant.Add("smItemArcaneRuneWall");
			if (smItemFancyDishes) stationaryMerchant.Add("smItemFancyDishes");
			if (smItemDynastyWood) stationaryMerchant.Add("smItemDynastyWood");
			if (smItemZebraSkin) stationaryMerchant.Add("smItemZebraSkin");
			if (smItemLeopardSkin) stationaryMerchant.Add("smItemLeopardSkin");
			if (smItemTigerSkin) stationaryMerchant.Add("smItemTigerSkin");
			if (smItemCastleMarsberg) stationaryMerchant.Add("smItemCastleMarsberg");
			if (smItemMartiaLisa) stationaryMerchant.Add("smItemMartiaLisa");
			if (smItemTheTruthIsUpThere) stationaryMerchant.Add("smItemTheTruthIsUpThere");
			if (smItemNotAKidNorASquid) stationaryMerchant.Add("smItemNotAKidNorASquid");
			if (smItemAcorns) stationaryMerchant.Add("smItemAcorns");
			if (smItemColdSnap) stationaryMerchant.Add("smItemColdSnap");
			if (smItemCursedSaint) stationaryMerchant.Add("smItemCursedSaint");
			if (smItemSnowfellas) stationaryMerchant.Add("smItemSnowfellas");
			if (smItemTheSeason) stationaryMerchant.Add("smItemTheSeason");

			return new TagCompound
			{
				{"biomeChestMined", biomeChestMined},
				{"stationaryMerchant", stationaryMerchant},
				{"skippedToDayOrNight", skippedToDayOrNight}
			};
        }

        public override void Load(TagCompound tag)
        {
            var biomeChestMined = tag.GetList<string>("biomeChestMined");
            infectionChestMined = biomeChestMined.Contains("infectionChestMined");
			hallowedChestMined = biomeChestMined.Contains("hallowedChestMined");
			frozenChestMined = biomeChestMined.Contains("frozenChestMined");
			jungleChestMined = biomeChestMined.Contains("jungleChestMined");
			
			var stationaryMerchant = tag.GetList<string>("stationaryMerchant");
			smItemShopNotEmpty = stationaryMerchant.Contains("smItemShopNotEmpty");
			smItemDecorShopNotEmpty = stationaryMerchant.Contains("smItemDecorShopNotEmpty");
			smItemSake = stationaryMerchant.Contains("smItemSake");
			smItemPho = stationaryMerchant.Contains("smItemPho");
			smItemPadThai = stationaryMerchant.Contains("smItemPadThai");
			smItemUltrabrightTorch = stationaryMerchant.Contains("smItemUltrabrightTorch");
			smItemAmmoBox = stationaryMerchant.Contains("smItemAmmoBox");
			smItemMagicHat = stationaryMerchant.Contains("smItemMagicHat");
			smItemGypsyRobe = stationaryMerchant.Contains("smItemGypsyRobe");
			smItemGi = stationaryMerchant.Contains("smItemGi");
			smItemCelestialMagnet = stationaryMerchant.Contains("smItemCelestialMagnet");
			smItemDPSMeter = stationaryMerchant.Contains("smItemDPSMeter");
			smItemLifeformAnalyzer = stationaryMerchant.Contains("smItemLifeformAnalyzer");
			smItemStopwatch = stationaryMerchant.Contains("smItemStopwatch");
			smItemPaintSprayer = stationaryMerchant.Contains("smItemPaintSprayer");
			smItemBrickLayer = stationaryMerchant.Contains("smItemBrickLayer");
			smItemPortableCementMixer = stationaryMerchant.Contains("smItemPortableCementMixer");
			smItemExtendoGrip = stationaryMerchant.Contains("smItemExtendoGrip");
			smItemPresserator = stationaryMerchant.Contains("smItemPresserator");
			smItemBlackCounterweight = stationaryMerchant.Contains("smItemBlackCounterweight");
			smItemYellowCounterweight = stationaryMerchant.Contains("smItemYellowCounterweight");
			smItemSittingDucksFishingPole = stationaryMerchant.Contains("smItemSittingDucksFishingPole");
			smItemKatana = stationaryMerchant.Contains("smItemKatana");
			smItemCode1 = stationaryMerchant.Contains("smItemCode1");
			smItemRevolver = stationaryMerchant.Contains("smItemRevolver");
			smItemGatligator = stationaryMerchant.Contains("smItemGatligator");
			smItemCode2 = stationaryMerchant.Contains("smItemCode2");
			smItemPulseBow = stationaryMerchant.Contains("smItemPulseBow");
			smItemRedTeamBlock = stationaryMerchant.Contains("smItemRedTeamBlock");
			smItemYellowTeamBlock = stationaryMerchant.Contains("smItemYellowTeamBlock");
			smItemGreenTeamBlock = stationaryMerchant.Contains("smItemGreenTeamBlock");
			smItemBlueTeamBlock = stationaryMerchant.Contains("smItemBlueTeamBlock");
			smItemPinkTeamBlock = stationaryMerchant.Contains("smItemPinkTeamBlock");
			smItemWhiteTeamBlock = stationaryMerchant.Contains("smItemWhiteTeamBlock");
			smItemDiamondRing = stationaryMerchant.Contains("smItemDiamondRing");
			smItemAngelHalo = stationaryMerchant.Contains("smItemAngelHalo");
			smItemFez = stationaryMerchant.Contains("smItemFez");
			smItemWinterCape = stationaryMerchant.Contains("smItemWinterCape");
			smItemRedCape = stationaryMerchant.Contains("smItemRedCape");
			smItemCrimsonCloak = stationaryMerchant.Contains("smItemCrimsonCloak");
			smItemMysteriousCape = stationaryMerchant.Contains("smItemMysteriousCape");
			smItemKimono = stationaryMerchant.Contains("smItemKimono");
			smItemWaterGun = stationaryMerchant.Contains("smItemWaterGun");
			smItemCompanionCube = stationaryMerchant.Contains("smItemCompanionCube");
			smItemChalice = stationaryMerchant.Contains("smItemChalice");
			smItemArcaneRuneWall = stationaryMerchant.Contains("smItemArcaneRuneWall");
			smItemFancyDishes = stationaryMerchant.Contains("smItemFancyDishes");
			smItemDynastyWood = stationaryMerchant.Contains("smItemDynastyWood");
			smItemZebraSkin = stationaryMerchant.Contains("smItemZebraSkin");
			smItemLeopardSkin = stationaryMerchant.Contains("smItemLeopardSkin");
			smItemTigerSkin = stationaryMerchant.Contains("smItemTigerSkin");
			smItemCastleMarsberg = stationaryMerchant.Contains("smItemCastleMarsberg");
			smItemMartiaLisa = stationaryMerchant.Contains("smItemMartiaLisa");
			smItemTheTruthIsUpThere = stationaryMerchant.Contains("smItemTheTruthIsUpThere");
			smItemNotAKidNorASquid = stationaryMerchant.Contains("smItemNotAKidNorASquid");
			smItemAcorns = stationaryMerchant.Contains("smItemAcorns");
			smItemColdSnap = stationaryMerchant.Contains("smItemColdSnap");
			smItemCursedSaint = stationaryMerchant.Contains("smItemCursedSaint");
			smItemSnowfellas = stationaryMerchant.Contains("smItemSnowfellas");
			smItemTheSeason = stationaryMerchant.Contains("smItemTheSeason");

			skippedToDayOrNight = tag.GetBool("skippedToDayOrNight");
        }
		
		public override void NetSend(BinaryWriter writer)
		{
			BitsByte smstoreflags = new BitsByte();
			BitsByte smitemflags = new BitsByte();
			BitsByte smitemflags2 = new BitsByte();
			BitsByte smitemflags3 = new BitsByte();
			BitsByte smitemflags4 = new BitsByte();
			BitsByte smitemflags5 = new BitsByte();
			BitsByte smitemflags6 = new BitsByte();
			BitsByte smitemflags7 = new BitsByte();
			BitsByte smitemflags8 = new BitsByte();

			BitsByte bcitemflags = new BitsByte();

			smstoreflags[0] = smItemShopNotEmpty;
			smstoreflags[1] = smItemDecorShopNotEmpty;

			smitemflags[0] = smItemSake;
			smitemflags[1] = smItemPho;
			smitemflags[2] = smItemPadThai;
			smitemflags[3] = smItemUltrabrightTorch;
			smitemflags[4] = smItemAmmoBox;
			smitemflags[5] = smItemMagicHat;
			smitemflags[6] = smItemGypsyRobe;
			smitemflags[7] = smItemGi;

			smitemflags2[0] = smItemCelestialMagnet;
			smitemflags2[1] = smItemDPSMeter;
			smitemflags2[2] = smItemLifeformAnalyzer;
			smitemflags2[3] = smItemStopwatch;
			smitemflags2[4] = smItemPaintSprayer;
			smitemflags2[5] = smItemBrickLayer;
			smitemflags2[6] = smItemPortableCementMixer;
			smitemflags2[7] = smItemExtendoGrip;

			smitemflags3[0] = smItemPresserator;
			smitemflags3[1] = smItemBlackCounterweight;
			smitemflags3[2] = smItemYellowCounterweight;
			smitemflags3[3] = smItemSittingDucksFishingPole;
			smitemflags3[4] = smItemKatana;
			smitemflags3[5] = smItemCode1;
			smitemflags3[6] = smItemRevolver;
			smitemflags3[7] = smItemGatligator;

			smitemflags4[0] = smItemCode2;
			smitemflags4[1] = smItemPulseBow;
			smitemflags4[2] = smItemRedTeamBlock;
			smitemflags4[3] = smItemYellowTeamBlock;
			smitemflags4[4] = smItemGreenTeamBlock;
			smitemflags4[5] = smItemBlueTeamBlock;
			smitemflags4[6] = smItemPinkTeamBlock;
			smitemflags4[7] = smItemWhiteTeamBlock;

			smitemflags5[0] = smItemDiamondRing;
			smitemflags5[1] = smItemAngelHalo;
			smitemflags5[2] = smItemFez;
			smitemflags5[3] = smItemWinterCape;
			smitemflags5[4] = smItemRedCape;
			smitemflags5[5] = smItemCrimsonCloak;
			smitemflags5[6] = smItemMysteriousCape;
			smitemflags5[7] = smItemKimono;

			smitemflags6[0] = smItemWaterGun;
			smitemflags6[1] = smItemCompanionCube;
			smitemflags6[2] = smItemChalice;
			smitemflags6[3] = smItemArcaneRuneWall;
			smitemflags6[4] = smItemFancyDishes;
			smitemflags6[5] = smItemDynastyWood;
			smitemflags6[6] = smItemZebraSkin;
			smitemflags6[7] = smItemLeopardSkin;

			smitemflags7[0] = smItemTigerSkin;
			smitemflags7[1] = smItemCastleMarsberg;
			smitemflags7[2] = smItemMartiaLisa;
			smitemflags7[3] = smItemTheTruthIsUpThere;
			smitemflags7[4] = smItemNotAKidNorASquid;
			smitemflags7[5] = smItemAcorns;
			smitemflags7[6] = smItemColdSnap;
			smitemflags7[7] = smItemCursedSaint;

			smitemflags8[0] = smItemSnowfellas;
			smitemflags8[1] = smItemTheSeason;

			bcitemflags[0] = infectionChestMined;
			bcitemflags[1] = hallowedChestMined;
			bcitemflags[2] = frozenChestMined;
			bcitemflags[3] = jungleChestMined;

			writer.Write(smstoreflags);
			writer.Write(smitemflags);
			writer.Write(smitemflags2);
			writer.Write(smitemflags3);
			writer.Write(smitemflags4);
			writer.Write(smitemflags5);
			writer.Write(smitemflags6);
			writer.Write(smitemflags7);
			writer.Write(smitemflags8);

			writer.Write(bcitemflags);
		}
		
		public override void NetReceive(BinaryReader reader)
		{
			BitsByte smstoreflags = reader.ReadByte();
			BitsByte smitemflags = reader.ReadByte();
			BitsByte smitemflags2 = reader.ReadByte();
			BitsByte smitemflags3 = reader.ReadByte();
			BitsByte smitemflags4 = reader.ReadByte();
			BitsByte smitemflags5 = reader.ReadByte();
			BitsByte smitemflags6 = reader.ReadByte();
			BitsByte smitemflags7 = reader.ReadByte();
			BitsByte smitemflags8 = reader.ReadByte();

			BitsByte bcitemflags = reader.ReadByte();

			smItemShopNotEmpty = smstoreflags[0];
			smItemDecorShopNotEmpty = smstoreflags[1];

			smItemSake = smitemflags[0];
			smItemPho = smitemflags[1];
			smItemPadThai = smitemflags[2];
			smItemUltrabrightTorch = smitemflags[3];
			smItemAmmoBox = smitemflags[4];
			smItemMagicHat = smitemflags[5];
			smItemGypsyRobe = smitemflags[6];
			smItemGi = smitemflags[7];

			smItemCelestialMagnet = smitemflags2[0];
			smItemDPSMeter = smitemflags2[1];
			smItemLifeformAnalyzer = smitemflags2[2];
			smItemStopwatch = smitemflags2[3];
			smItemPaintSprayer = smitemflags2[4];
			smItemBrickLayer = smitemflags2[5];
			smItemPortableCementMixer = smitemflags2[6];
			smItemExtendoGrip = smitemflags2[7];

			smItemPresserator = smitemflags3[0];
			smItemBlackCounterweight = smitemflags3[1];
			smItemYellowCounterweight = smitemflags3[2];
			smItemSittingDucksFishingPole = smitemflags3[3];
			smItemKatana = smitemflags3[4];
			smItemCode1 = smitemflags3[5];
			smItemRevolver = smitemflags3[6];
			smItemGatligator = smitemflags3[7];

			smItemCode2 = smitemflags4[0];
			smItemPulseBow = smitemflags4[1];
			smItemRedTeamBlock = smitemflags4[2];
			smItemYellowTeamBlock = smitemflags4[3];
			smItemGreenTeamBlock = smitemflags4[4];
			smItemBlueTeamBlock = smitemflags4[5];
			smItemPinkTeamBlock = smitemflags4[6];
			smItemWhiteTeamBlock = smitemflags4[7];

			smItemDiamondRing = smitemflags5[0];
			smItemAngelHalo = smitemflags5[1];
			smItemFez = smitemflags5[2];
			smItemWinterCape = smitemflags5[3];
			smItemRedCape = smitemflags5[4];
			smItemCrimsonCloak = smitemflags5[5];
			smItemMysteriousCape = smitemflags5[6];
			smItemKimono = smitemflags5[7];

			smItemWaterGun = smitemflags6[0];
			smItemCompanionCube = smitemflags6[1];
			smItemChalice = smitemflags6[2];
			smItemArcaneRuneWall = smitemflags6[3];
			smItemFancyDishes = smitemflags6[4];
			smItemDynastyWood = smitemflags6[5];
			smItemZebraSkin = smitemflags6[6];
			smItemLeopardSkin = smitemflags6[7];

			smItemTigerSkin = smitemflags7[0];
			smItemCastleMarsberg = smitemflags7[1];
			smItemMartiaLisa = smitemflags7[2];
			smItemTheTruthIsUpThere = smitemflags7[3];
			smItemNotAKidNorASquid = smitemflags7[4];
			smItemAcorns = smitemflags7[5];
			smItemColdSnap = smitemflags7[6];
			smItemCursedSaint = smitemflags7[7];

			smItemSnowfellas = smitemflags8[0];
			smItemTheSeason = smitemflags8[1];

			infectionChestMined = bcitemflags[0];
			hallowedChestMined = bcitemflags[1];
			frozenChestMined = bcitemflags[2];
			jungleChestMined = bcitemflags[3];
		}

		public override void PostUpdate()
		{
			Player player = Main.player[Main.myPlayer];

			int playerCoinAmount = 0;
			foreach (Item i in player.inventory)
			{
				switch (i.type)
				{
					case ItemID.CopperCoin:
						playerCoinAmount += 1 * i.stack;
						break;
					case ItemID.SilverCoin:
						playerCoinAmount += 100 * i.stack;
						break;
					case ItemID.GoldCoin:
						playerCoinAmount += 10000 * i.stack;
						break;
					case ItemID.PlatinumCoin:
						playerCoinAmount += 1000000 * i.stack;
						break;
				}
			}

			bool anyPlayerHasCelestialBeacon = false;
			bool biomechestchange = false;
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active)
				{
					if (Main.player[i].HasItem(mod.ItemType("Celestial_Beacon")))
						anyPlayerHasCelestialBeacon = true;
					if (Main.player[i].HasItem(ItemID.JungleChest) && !jungleChestMined)
					{
						jungleChestMined = true;
						biomechestchange = true;
					}
					if (Main.player[i].HasItem(ItemID.CorruptionChest) && !infectionChestMined)
					{
						infectionChestMined = true;
						biomechestchange = true;
					}
					if (Main.player[i].HasItem(ItemID.CrimsonChest) && !infectionChestMined)
					{
						infectionChestMined = true;
						biomechestchange = true;
					}
					if (Main.player[i].HasItem(ItemID.HallowedChest) && !hallowedChestMined)
					{
						hallowedChestMined = true;
						biomechestchange = true;
					}
					if (Main.player[i].HasItem(ItemID.FrozenChest) && !frozenChestMined)
					{
						frozenChestMined = true;
						biomechestchange = true;
					}
				}
			}

			if (biomechestchange && Main.netMode == NetmodeID.Server)
				NetMessage.SendData(MessageID.WorldData);


			if (NPC.MoonLordCountdown > 1 && anyPlayerHasCelestialBeacon)
				NPC.MoonLordCountdown = 1;

			if (Main.time % 600 == 0 && !NPC.downedMoonlord)
			{
				for (int i = 0; i < Main.npc.Length; i++)
				{
					if (Main.npc[i].type == NPCID.MoonLordCore && !anyPlayerHasCelestialBeacon)
					{
						Main.player[(int)Player.FindClosest(Main.npc[i].position, Main.npc[i].width, Main.npc[i].height)].QuickSpawnItem(mod.ItemType("Celestial_Beacon"));
						break;
					}
				}
			}

			if (advanceMoonPhase)
			{

				if (Main.netMode == NetmodeID.SinglePlayer)//0)
					Main.NewText("advanceMoonPhase", 50, 125);
				else if (Main.netMode == NetmodeID.Server)//2)
					NetMessage.BroadcastChatMessage(NetworkText.FromKey("advanceMoonPhase"), new Color(50, 125, 255));


				advanceMoonPhase = false;
				Main.moonPhase++;
				if (Main.moonPhase >= 8)
				{
					Main.moonPhase = 0;
				}
				if (Main.netMode == NetmodeID.Server)
				{
					var netMessage = mod.GetPacket();
					netMessage.Write((byte)ReducedGrindingMessageType.advanceMoonPhase);
					netMessage.Write(ReducedGrindingWorld.advanceMoonPhase);
					netMessage.Send();

					NetMessage.SendData(7);
				}
			}

			if (skipToNight)
			{
				if (Main.sundialCooldown > 0)
					ReducedGrindingWorld.skippedToDayOrNight = true;
				Main.time = 54000;
				skipToDay = false;
				skipToNight = false;
				//Force Traveling Merchant despawn in order to prevent exploiting.
				int travelingMerchantTarget = -1;
				for (int i = 0; i < 200; i++)
				{
					if (Main.npc[i].active && Main.npc[i].type == NPCID.TravellingMerchant)
					{
						travelingMerchantTarget = i;
						break;
					}
				}
				if (travelingMerchantTarget > -1)
				{
					string fullName = Main.npc[travelingMerchantTarget].FullName;
					if (Main.netMode == NetmodeID.SinglePlayer)//0)
						Main.NewText(Lang.misc[35].Format(fullName), 50, 125);
					else if (Main.netMode == NetmodeID.Server)//2)
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(Lang.misc[35].Key, Main.npc[travelingMerchantTarget].GetFullNetName()), new Color(50, 125, 255));
					Main.npc[travelingMerchantTarget].active = false;
					Main.npc[travelingMerchantTarget].netSkip = -1;
					Main.npc[travelingMerchantTarget].life = 0;
					NetMessage.SendData(23, -1, -1, null, travelingMerchantTarget);
				}
				if (Main.netMode == NetmodeID.Server) //Server
				{
					var netMessage = mod.GetPacket();
					netMessage.Write((byte)ReducedGrindingMessageType.skipToNight);
					netMessage.Write(ReducedGrindingWorld.skipToNight);

					netMessage.Write((byte)ReducedGrindingMessageType.skipToDay);
					netMessage.Write(ReducedGrindingWorld.skipToDay);
					netMessage.Send();

					NetMessage.SendData(7);
				}
			}

			if (skipToDay)
			{
				if (Main.sundialCooldown > 0)
					ReducedGrindingWorld.skippedToDayOrNight = true;
				Main.time = 32400;
				skipToDay = false;
				skipToNight = false;
				if (Main.netMode == NetmodeID.Server)
				{
					var netMessage = mod.GetPacket();
					netMessage.Write((byte)ReducedGrindingMessageType.skipToNight);
					netMessage.Write(ReducedGrindingWorld.skipToNight);

					netMessage.Write((byte)ReducedGrindingMessageType.skipToDay);
					netMessage.Write(ReducedGrindingWorld.skipToDay);
					netMessage.Send();

					NetMessage.SendData(7);
				}
			}

			if (Main.dayTime && skippedToDayOrNight)
			{
				Main.sundialCooldown++;
				skippedToDayOrNight = false;
			}

			//There are 21 stationary vanilla NPCs (excluding Guide and Santa) as of 5/26/2017; 15 Pre-Hardmode and 6 Hardmode.
			float TownNPCs = 0f;
			float TownNPCsMax = 15f;
			float TownHardmodeNPCs = 0f;
			float TownHardmodeNPCsMax = 6f;
			bool travelingMerchantExists = false;
			bool stationaryMerchantExists = false;
			bool tryToSpawnTravelingMerchant = true;

			Mod luiafk = ModLoader.GetMod("Luiafk");
			if (GetInstance<IOtherCustomNPCsConfig>().BoneMerchant && !(luiafk != null && GetInstance<IOtherCustomNPCsConfig>().BoneMerchantDisabledWhenLuiafkIsInstalled))
				TownNPCsMax++;
			if (GetInstance<IOtherCustomNPCsConfig>().ChestSalesman)
				TownNPCsMax++;
			if (GetInstance<ETravelingAndStationaryMerchantConfig>().StationaryMerchant)
				TownNPCsMax++;
			if (GetInstance<IOtherCustomNPCsConfig>().LootMerchant)
				TownNPCsMax++;
			if (GetInstance<IOtherCustomNPCsConfig>().ChristmasElf)
				TownHardmodeNPCsMax++;

			for (int i = 0; i < Terraria.Main.npc.Length; i++) //Do once for each NPC in the world
			{
				if (Terraria.Main.npc[i].townNPC == true)
				{
					if (Terraria.Main.npc[i].type == NPCID.TravellingMerchant)
					{
						travelingMerchantExists = true;
						tryToSpawnTravelingMerchant = false;
					}
					if (Terraria.Main.npc[i].type == mod.NPCType("StationaryMerchant"))
						stationaryMerchantExists = true;
					if (
						Terraria.Main.npc[i].type == NPCID.Merchant ||
						Terraria.Main.npc[i].type == NPCID.Nurse ||
						Terraria.Main.npc[i].type == NPCID.Demolitionist ||
						Terraria.Main.npc[i].type == NPCID.DyeTrader ||
						Terraria.Main.npc[i].type == NPCID.Dryad ||
						Terraria.Main.npc[i].type == NPCID.DD2Bartender ||
						Terraria.Main.npc[i].type == NPCID.ArmsDealer ||
						Terraria.Main.npc[i].type == NPCID.Stylist ||
						Terraria.Main.npc[i].type == NPCID.Painter ||
						Terraria.Main.npc[i].type == NPCID.Angler ||
						Terraria.Main.npc[i].type == NPCID.GoblinTinkerer ||
						Terraria.Main.npc[i].type == NPCID.WitchDoctor ||
						Terraria.Main.npc[i].type == NPCID.Clothier ||
						Terraria.Main.npc[i].type == NPCID.Mechanic ||
						Terraria.Main.npc[i].type == NPCID.PartyGirl ||
						(Terraria.Main.npc[i].type == mod.NPCType("BoneMerchant") && GetInstance<IOtherCustomNPCsConfig>().BoneMerchant) ||
						(Terraria.Main.npc[i].type == mod.NPCType("ChestSalesman") && GetInstance<IOtherCustomNPCsConfig>().ChestSalesman) ||
						(Terraria.Main.npc[i].type == mod.NPCType("StationaryMerchant") && GetInstance<ETravelingAndStationaryMerchantConfig>().StationaryMerchant) ||
						(Terraria.Main.npc[i].type == mod.NPCType("LootMerchant") && GetInstance<IOtherCustomNPCsConfig>().LootMerchant)
					)
						TownNPCs++;
					else if (
						Terraria.Main.npc[i].type == NPCID.Wizard ||
						Terraria.Main.npc[i].type == NPCID.TaxCollector ||
						Terraria.Main.npc[i].type == NPCID.Truffle ||
						Terraria.Main.npc[i].type == NPCID.Pirate ||
						Terraria.Main.npc[i].type == NPCID.Steampunker ||
						Terraria.Main.npc[i].type == NPCID.Cyborg ||
						(Terraria.Main.npc[i].type == mod.NPCType("Christmas Elf") && GetInstance<IOtherCustomNPCsConfig>().ChristmasElf)
					)
					{
						TownHardmodeNPCs++;
					}
				}
			}

			float TownNPCPercent = (TownNPCs / TownNPCsMax + TownHardmodeNPCs / TownHardmodeNPCsMax) / 2;

			if (!Main.fastForwardTime && Main.dayTime && Main.time < 27000.0)
			{
				int alltownNPCs = 0;
				for (int j = 0; j < 200; j++)
				{
					if (Main.npc[j].active && Main.npc[j].townNPC && Main.npc[j].type != 37 && Main.npc[j].type != 453)
					{
						alltownNPCs++;
					}
				}
				if (alltownNPCs >= 2)
				{
					if (tryToSpawnTravelingMerchant)
					{
						tryToSpawnTravelingMerchant = false;
						if (!Main.fastForwardTime && Main.dayTime && Main.time < 27000.0)
						{
							int chanceRoll = (int)(27000.0 / (double)Main.dayRate);
							chanceRoll *= 4;
							for (int i = 0; i < 3; i++)
							{
								if (Main.rand.Next(chanceRoll) == 0)
								{
									tryToSpawnTravelingMerchant = true;
									break;
								}
							}
						}
					}
					if (tryToSpawnTravelingMerchant && Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().BaseMorningTMerchantSpawnChance * Math.Pow(TownNPCPercent, 2))
						WorldGen.SpawnTravelNPC();
				}
			}
			if (travelingMerchantExists && stationaryMerchantExists)
			{
				bool TravelingMerchantRestockOrder = false;
				for (int i = 0; i < 255; i++)
				{
					if (Main.player[i].active && Main.player[i].HasItem(mod.ItemType("Traveling_Merchant_Restock_Order")))
					{
						TravelingMerchantRestockOrder = true;
						break;
					}
				}
				//Each Second there is an item that has a chance to appear in Traveling Merchant if a player is holding a Traveling Merchant Restock Order.
				if (Main.time % 60 == 0 && TravelingMerchantRestockOrder)
				{
                    //for (int i = 0; i < Terraria.Main.npc.Length; i++) //Do once for each NPC in the world
                    //{     (I DON'T KNOW IF THERE IS A REASON I CHECK FOR THE T.MERCHANT TWICE, I COMMENTED JUST IN CASE REMOVING WOULD CAUSE A PROBLEM
                    //if (Terraria.Main.npc[i].type == NPCID.TravellingMerchant)
                    //{
                    if (Main.rand.NextFloat() < GetInstance<ETravelingAndStationaryMerchantConfig>().ChanceEachInGameMinuteWillResetTravelingMerchant * Math.Pow(TownNPCPercent, 2))
                    {
                        Chest.SetupTravelShop();
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendTravelShop(-1);
                            NetMessage.BroadcastChatMessage(NetworkText.FromKey("The traveling merchant restocked his shop."), new Color(0, 127, 255));
                        }
                        else if (Main.netMode == NetmodeID.SinglePlayer) // Single Player
                            Main.NewText("The traveling merchant restocked his shop.", 0, 127, 255);
                    }
                    //break;
                    //}
                    //}
                }
			}
		}
	}
}
