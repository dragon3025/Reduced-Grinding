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
            FishCoin = CustomCurrencyManager.RegisterCurrency(new Currencies.FishCoinCurrency(ModContent.ItemType<Items.FishCoin>(), 9999L, "Fish Coin"));

            ModLoader.TryGetMod("Wikithis", out Mod wikithis);
            if (wikithis != null && !Main.dedServ)
            {
                wikithis.Call("AddModURL", this, "terrariamods.fandom.com$Reduced_Grinding");
            }
        }

        internal enum MessageType : byte
        {
            advanceMoonPhase,
            anglerQuests,
            dayTime,
            seasonalDay,
            instantInvasion,
            celestialSigil,
            travelingMerchantDiceRolls,
            timeHiddenFromInvasion
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
                case MessageType.anglerQuests:
                    Global.Update.anglerQuests = reader.ReadInt32();
                    break;
                case MessageType.dayTime:
                    Global.Update.dayTime = reader.ReadBoolean();
                    break;
                case MessageType.seasonalDay:
                    Global.Update.seasonalDay = reader.ReadInt32();
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
                default:
                    Logger.WarnFormat("Reduced Grinding: Unknown Message type: {0}", msgType);
                    break;
            }
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData);
            }
        }
    }

    class ReducedGrindingSave : ModSystem
    {
        public static bool usingCalamity = false;
        public static bool usingFargowiltas = false;

        public override void OnWorldUnload()
        {
            Global.Update.anglerQuests = 1;
            Global.Update.dayTime = true;
            Global.Update.seasonalDay = 1;
            Global.Update.travelingMerchantDiceRolls = 0;
        }

        public override void OnWorldLoad()
        {
            Global.Update.anglerQuests = 1;
            Global.Update.dayTime = true;
            Global.Update.seasonalDay = 1;
            Global.Update.travelingMerchantDiceRolls = 0;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            tag["anglerQuests"] = Global.Update.anglerQuests;
            tag["dayTime"] = Global.Update.dayTime;
            tag["seasonalDay"] = Math.Max(1, Global.Update.seasonalDay);
            tag["travelingMerchantDiceRolls"] = Global.Update.travelingMerchantDiceRolls;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            if (!tag.TryGet("anglerQuests", out Global.Update.anglerQuests))
            {
                Global.Update.anglerQuests = 1;
            }
            if (!tag.TryGet("dayTime", out Global.Update.dayTime))
            {
                Global.Update.dayTime = true;
            }
            if (!tag.TryGet("seasonalDay", out Global.Update.seasonalDay))
            {
                Global.Update.seasonalDay = 1;
            }
            if (!tag.TryGet("travelingMerchantDiceRolls", out Global.Update.travelingMerchantDiceRolls))
            {
                Global.Update.travelingMerchantDiceRolls = 0;
            }
        }

        public override void OnModLoad()
        {
            //Remove when 1.4.4+ comes out
            NPC.LunarShieldPowerExpert = NPC.LunarShieldPowerNormal = 100;

            if (ModLoader.TryGetMod("CalamityMod", out _))
            {
                usingCalamity = true;
            }

            if (ModLoader.TryGetMod("Fargowiltas", out _))
            {
                usingFargowiltas = true;
            }
        }
    }
}
