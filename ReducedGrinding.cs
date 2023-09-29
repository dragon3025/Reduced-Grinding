/* To debug, use:
 * Terraria.ModLoader.ModContent.GetInstance<ReducedGrinding>().Logger.Debug("");
 * 
 * To turn into a string use:
 * $"text {variable}"
 * 
 * To show text in chat use:
 * Main.NewText(string);
 */

using System.IO;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

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
                wikithis.Call("AddModURL", this, "https://terrariamods.wiki.gg/wiki/Reduced_Grinding/{}");
            }
        }

        internal enum MessageType : byte
        {
            advanceMoonPhase,
            advanceDifficulty,
            anglerQuests,
            dayTime,
            instantInvasion,
            travelingMerchantDiceRolls,
            chatMerchantItems,
            chatQuestFish
        }

        //NOTE: You can test 2 players on 1 PC using the start-tModLoader.bat files.
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            MessageType msgType = (MessageType)reader.ReadByte();
            switch (msgType)
            {
                case MessageType.advanceMoonPhase:
                    Global.Update.advanceMoonPhase = reader.ReadBoolean();
                    break;
                case MessageType.advanceDifficulty:
                    Global.Update.advanceDifficulty = reader.ReadBoolean();
                    break;
                case MessageType.anglerQuests:
                    Global.Update.anglerQuests = reader.ReadInt32();
                    break;
                case MessageType.dayTime:
                    Global.Update.dayTime = reader.ReadBoolean();
                    break;
                case MessageType.instantInvasion:
                    Global.Update.instantInvasion = reader.ReadBoolean();
                    break;
                case MessageType.travelingMerchantDiceRolls:
                    Global.Update.travelingMerchantDiceRolls = reader.ReadInt32();
                    break;
                case MessageType.chatMerchantItems:
                    Global.Update.chatMerchantItems = reader.ReadBoolean();
                    break;
                case MessageType.chatQuestFish:
                    Global.Update.chatQuestFish = reader.ReadInt32();
                    break;
                default:
                    Logger.WarnFormat("Reduced Grinding: Unknown Message type: {0}", msgType);
                    break;
            }
        }
    }

    class ReducedGrindingSave : ModSystem
    {
        public override void OnWorldLoad()
        {
            Global.Update.advanceMoonPhase = false;
            Global.Update.advanceDifficulty = false;
            Global.Update.instantInvasion = false;
            Global.Update.chatMerchantItems = false;
            Global.Update.chatQuestFish = 0;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            tag["anglerQuests"] = Global.Update.anglerQuests;
            tag["dayTime"] = Global.Update.dayTime;
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
            if (!tag.TryGet("travelingMerchantDiceRolls", out Global.Update.travelingMerchantDiceRolls))
            {
                Global.Update.travelingMerchantDiceRolls = 0;
            }
        }
    }
}
