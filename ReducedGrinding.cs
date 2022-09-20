/* To debug, use:
 * using static Terraria.ModLoader.ModContent;
 * GetInstance<ReducedGrinding>().Logger.Debug("");
 * 
 * To turn into a string use:
 * Value.ToString()
 * 
 * To show text in chat use:
 * Main.NewText(string);
 */


using System;
using System.IO;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding
{

    class ReducedGrinding : Mod
    {
        public static int FishCoin;

        public override void Load()
        {
            FishCoin = CustomCurrencyManager.RegisterCurrency(new Currencies.FishCoinCurrency(ModContent.ItemType<Items.FishCoin>(), 9999L, "Fish Coin")); //Localize

            ModLoader.TryGetMod("Wikithis", out Mod wikithis);
            if (wikithis != null && !Main.dedServ)
            {
                wikithis.Call("AddModURL", this, "terrariamods.fandom.com$Reduced_Grinding");
            }
        }

        internal enum MessageType : byte
        {
            advanceMoonPhase,
            noMoreAnglerResetsToday,
            dayTime,
            timeCharm,
            seasonalDay,
            invasionWithGreaterBattleBuff,
            invasionWithSuperBattleBuff,
            instantInvasion,
            celestialSigil,
            travelingMerchantDiceRolls,
            timeHiddenFromInvasion,
            dutchmanKilled
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            GetInstance<ReducedGrinding>().Logger.Debug("");
            MessageType msgType = (MessageType)reader.ReadByte();
            switch (msgType)
            {
                case MessageType.advanceMoonPhase:
                    Global.Update.advanceMoonPhase = reader.ReadBoolean();
                    break;
                case MessageType.noMoreAnglerResetsToday:
                    Global.Update.noMoreAnglerResetsToday = reader.ReadBoolean();
                    break;
                case MessageType.dayTime:
                    Global.Update.dayTime = reader.ReadBoolean();
                    break;
                case MessageType.timeCharm:
                    Global.Update.timeCharm = reader.ReadBoolean();
                    break;
                case MessageType.seasonalDay:
                    Global.Update.seasonalDay = reader.ReadInt32();
                    break;
                case MessageType.invasionWithGreaterBattleBuff:
                    Global.Update.invasionWithGreaterBattleBuff = reader.ReadBoolean();
                    break;
                case MessageType.invasionWithSuperBattleBuff:
                    Global.Update.invasionWithSuperBattleBuff = reader.ReadBoolean();
                    break;
                case MessageType.instantInvasion:
                    Global.Update.instantInvasion = reader.ReadBoolean();
                    break;
                case MessageType.celestialSigil:
                    Global.Update.celestialSigil = reader.ReadBoolean();
                    break;
                case MessageType.travelingMerchantDiceRolls:
                    Global.Update.travelingMerchantDiceRolls = reader.ReadInt32();
                    break;
                case MessageType.timeHiddenFromInvasion:
                    Global.Update.timeHiddenFromInvasion = reader.ReadInt32();
                    break;
                case MessageType.dutchmanKilled:
                    Global.Update.dutchManKilled = reader.ReadBoolean();
                    break;
                default:
                    Logger.WarnFormat("Reduced Grinding: Unknown Message type: {0}", msgType);
                    break;
            }
            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.WorldData);
        }
    }

    class ReducedGrindingSave : ModSystem
    {
        public static bool usingCalamity = false;
        public static bool usingFargowiltas = false;

        public override void OnWorldUnload()
        {
            Global.Update.noMoreAnglerResetsToday = false;
            Global.Update.dayTime = true;
            Global.Update.timeCharm = false;
            Global.Update.seasonalDay = 1;
            Global.Update.invasionWithGreaterBattleBuff = false;
            Global.Update.invasionWithSuperBattleBuff = false;
            Global.Update.travelingMerchantDiceRolls = 0;
            Global.Update.dutchManKilled = false;
        }

        public override void OnWorldLoad()
        {
            Global.Update.noMoreAnglerResetsToday = false;
            Global.Update.dayTime = true;
            Global.Update.timeCharm = false;
            Global.Update.seasonalDay = 1;
            Global.Update.invasionWithGreaterBattleBuff = false;
            Global.Update.invasionWithSuperBattleBuff = false;
            Global.Update.travelingMerchantDiceRolls = 0;
            Global.Update.dutchManKilled = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            tag["noMoreAnglerResetsToday"] = Global.Update.noMoreAnglerResetsToday;
            tag["dayTime"] = Global.Update.dayTime;
            tag["timeCharm"] = Global.Update.timeCharm;
            tag["seasonalDay"] = Math.Max(1, Global.Update.seasonalDay);
            tag["invasionWithGreaterBattleBuff"] = Global.Update.invasionWithGreaterBattleBuff;
            tag["invasionWithSuperBattleBuff"] = Global.Update.invasionWithSuperBattleBuff;
            tag["travelingMerchantDiceRolls"] = Global.Update.travelingMerchantDiceRolls;
            tag["dutchmanKillsV2"] = Global.Update.dutchManKilled;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            if (!tag.TryGet("noMoreAnglerResetsToday", out Global.Update.noMoreAnglerResetsToday))
                Global.Update.noMoreAnglerResetsToday = false;

            if (!tag.TryGet("dayTime", out Global.Update.dayTime))
                Global.Update.dayTime = true;

            if (!tag.TryGet("timeCharm", out Global.Update.timeCharm))
                Global.Update.timeCharm = false;

            if (!tag.TryGet("seasonalDay", out Global.Update.seasonalDay))
                Global.Update.seasonalDay = 1;

            if (!tag.TryGet("invasionWithGreaterBattleBuff", out Global.Update.invasionWithGreaterBattleBuff))
                Global.Update.invasionWithGreaterBattleBuff = false;

            if (!tag.TryGet("invasionWithSuperBattleBuff", out Global.Update.invasionWithSuperBattleBuff))
                Global.Update.invasionWithSuperBattleBuff = false;

            if (!tag.TryGet("travelingMerchantDiceRolls", out Global.Update.travelingMerchantDiceRolls))
                Global.Update.travelingMerchantDiceRolls = 0;

            if (!tag.TryGet("dutchmanKills", out Global.Update.dutchManKilled))
                Global.Update.dutchManKilled = false;
        }

        public override void OnModLoad()
        {
            NPC.LunarShieldPowerExpert = GetInstance<IOtherConfig>().LunarPillarShieldHealth;
            NPC.LunarShieldPowerNormal = Math.Max(1, NPC.LunarShieldPowerExpert * 2 / 3);

            if (ModLoader.TryGetMod("CalamityMod", out _))
                usingCalamity = true;

            if (ModLoader.TryGetMod("Fargowiltas", out _))
                usingFargowiltas = true;
        }
    }
}