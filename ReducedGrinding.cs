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
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace ReducedGrinding
{

    class ReducedGrinding : Mod
    {

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
            celestialSigil
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
        public static int multiBobberBonus = 0;

        public override void SaveWorldData(TagCompound tag)
        {
            tag.Add("noMoreAnglerResetsToday", Global.Update.noMoreAnglerResetsToday);
            tag.Add("dayTime", Global.Update.dayTime);
            tag.Add("timeCharm", Global.Update.timeCharm);
            tag.Add("seasonalDay", Math.Max(1, Global.Update.seasonalDay));
            tag.Add("invasionWithGreaterBattleBuff", Global.Update.invasionWithGreaterBattleBuff);
            tag.Add("invasionWithSuperBattleBuff", Global.Update.invasionWithSuperBattleBuff);
        }

        public override void LoadWorldData(TagCompound tag)
        {
            tag.TryGet("noMoreAnglerResetsToday", out bool noMoreAnglerResetsToday);
            tag.TryGet("dayTime", out bool dayTime);
            tag.TryGet("timeCharm", out bool timeCharm);
            tag.TryGet("seasonalDay", out int seasonalDay);
            tag.TryGet("invasionWithGreaterBattleBuff", out bool invasionWithGreaterBattleBuff);
            tag.TryGet("invasionWithSuperBattleBuff", out bool invasionWithSuperBattleBuff);

            Global.Update.noMoreAnglerResetsToday = noMoreAnglerResetsToday;
            Global.Update.dayTime = dayTime;
            Global.Update.timeCharm = timeCharm;
            Global.Update.seasonalDay = Math.Max(1, seasonalDay);
            Global.Update.invasionWithGreaterBattleBuff = invasionWithGreaterBattleBuff;
            Global.Update.invasionWithSuperBattleBuff = invasionWithSuperBattleBuff;
        }

        public override void OnModLoad()
        {
            NPC.LunarShieldPowerExpert = GetInstance<IOtherConfig>().LunarPillarShieldHealth;
            NPC.LunarShieldPowerNormal = Math.Max(1, NPC.LunarShieldPowerExpert * 2 / 3);
            multiBobberBonus = GetInstance<CFishingConfig>().MultiBobberPotionBonus;
            if (ModLoader.TryGetMod("CalamityMod", out _))
            {
                usingCalamity = true;
                multiBobberBonus = GetInstance<CFishingConfig>().MultiBobberPotionBonusCalamity;
            }
        }
    }
}