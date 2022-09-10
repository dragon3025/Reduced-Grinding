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
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding
{

    class ReducedGrinding : Mod
    {
        public override void Load()
        {
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
            dutchmanKills
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
                case MessageType.dutchmanKills:
                    Global.Update.dutchmanKills = reader.ReadInt32();
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
        public static int multiBobberBonus = 0;
        public static int greaterMultiBobberBonus = 0;
        public static int superMultiBobberBonus = 0;

        public override void SaveWorldData(TagCompound tag)
        {
            tag.Add("noMoreAnglerResetsToday", Global.Update.noMoreAnglerResetsToday);
            tag.Add("dayTime", Global.Update.dayTime);
            tag.Add("timeCharm", Global.Update.timeCharm);
            tag.Add("seasonalDay", Math.Max(1, Global.Update.seasonalDay));
            tag.Add("invasionWithGreaterBattleBuff", Global.Update.invasionWithGreaterBattleBuff);
            tag.Add("invasionWithSuperBattleBuff", Global.Update.invasionWithSuperBattleBuff);
            tag.Add("travelingMerchantDiceRolls", Global.Update.travelingMerchantDiceRolls);
            tag.Add("dutchmanKills", Global.Update.dutchmanKills);
        }

        public override void LoadWorldData(TagCompound tag)
        {
            tag.TryGet("noMoreAnglerResetsToday", out bool noMoreAnglerResetsToday);
            tag.TryGet("dayTime", out bool dayTime);
            tag.TryGet("timeCharm", out bool timeCharm);
            tag.TryGet("seasonalDay", out int seasonalDay);
            tag.TryGet("invasionWithGreaterBattleBuff", out bool invasionWithGreaterBattleBuff);
            tag.TryGet("invasionWithSuperBattleBuff", out bool invasionWithSuperBattleBuff);
            tag.TryGet("travelingMerchantDiceRolls", out int travelingMerchantDiceRolls);
            tag.TryGet("dutchmanKills", out int dutchmanKills);

            Global.Update.noMoreAnglerResetsToday = noMoreAnglerResetsToday;
            Global.Update.dayTime = dayTime;
            Global.Update.timeCharm = timeCharm;
            Global.Update.seasonalDay = Math.Max(1, seasonalDay);
            Global.Update.invasionWithGreaterBattleBuff = invasionWithGreaterBattleBuff;
            Global.Update.invasionWithSuperBattleBuff = invasionWithSuperBattleBuff;
            Global.Update.travelingMerchantDiceRolls = travelingMerchantDiceRolls;
            Global.Update.dutchmanKills = dutchmanKills;
        }

        public override void OnModLoad()
        {
            NPC.LunarShieldPowerExpert = GetInstance<IOtherConfig>().LunarPillarShieldHealth;
            NPC.LunarShieldPowerNormal = Math.Max(1, NPC.LunarShieldPowerExpert * 2 / 3);

            if (ModLoader.TryGetMod("CalamityMod", out _))
            {
                usingCalamity = true;
                multiBobberBonus = GetInstance<CFishingConfig>().MultiBobberPotionBonusCalamity;
                greaterMultiBobberBonus = GetInstance<CFishingConfig>().GreaterMultiBobberPotionBonusCalamity;
                superMultiBobberBonus = GetInstance<CFishingConfig>().SuperMultiBobberPotionBonusCalamity;
            }
            else
            {
                multiBobberBonus = GetInstance<CFishingConfig>().MultiBobberPotionBonus;
                greaterMultiBobberBonus = GetInstance<CFishingConfig>().GreaterMultiBobberPotionBonus;
                superMultiBobberBonus = GetInstance<CFishingConfig>().SuperMultiBobberPotionBonus;
            }

            if (ModLoader.TryGetMod("Fargowiltas", out _))
            {
                usingFargowiltas = true;
            }
        }
    }
}