/*To debug, use:
ErrorLogger.Log(<string>); /NO LONGER WORKS

To turn into a string use:
Value.ToString()

To show text in chat use:
Main.NewText(string);
or
Main.NewText(string, red, green, blue);

Chatting a value:
Main.NewText(Value.ToString(), 255, 255, 255);
*/

using System.IO;
using Terraria.ModLoader;

namespace ReducedGrinding
{

    class ReducedGrinding : Mod
    {

        /*public override void PostSetupContent() TODO
		{
			Mod censusMod = ModLoader.GetMod("Census");
			if (censusMod != null)
			{
				if (GetInstance<IOtherCustomNPCsConfig>().BoneMerchant)
					censusMod.Call("TownNPCCondition", NPCType("BoneMerchant"), "Summon with a \"Skull Call\".");
				else
					censusMod.Call("TownNPCCondition", NPCType("BoneMerchant"), "[c/FF7F7F:DISABLED IN THE CONFIGURATIONS.]");

				if (GetInstance<IOtherCustomNPCsConfig>().LootMerchant)
					censusMod.Call("TownNPCCondition", NPCType("LootMerchant"), "No conditions.");
				else
					censusMod.Call("TownNPCCondition", NPCType("LootMerchant"), " [c/FF7F7F:DISABLED IN THE CONFIGURATIONS.]");

				if (GetInstance<IOtherCustomNPCsConfig>().ChristmasElf)
					censusMod.Call("TownNPCCondition", NPCType("Christmas_Elf"), "Defeat the Frost Legion.");
				else
					censusMod.Call("TownNPCCondition", NPCType("Christmas_Elf"), "[c/FF7F7F:DISABLED IN THE CONFIGURATIONS.]");

				if (GetInstance<ETravelingAndStationaryMerchantConfig>().StationaryMerchant)
					censusMod.Call("TownNPCCondition", NPCType("StationaryMerchant"), "No conditions.");
				else
					censusMod.Call("TownNPCCondition", NPCType("StationaryMerchant"), "[c/FF7F7F:DISABLED IN THE CONFIGURATIONS.]");
			}
		}*/
        internal enum MessageType : byte
        {
            advanceMoonPhase,
            noMoreAnglerResetsToday,
            dayTime,
            timeCharm,
            seasonalDay
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
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
                default:
                    Logger.WarnFormat("ExampleMod: Unknown Message type: {0}", msgType);
                    break;
            }
        }
    }
}