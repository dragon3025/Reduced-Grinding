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

        public override void Load()
        {
            ModTranslation text = LocalizationLoader.CreateTranslation("Common.PlanteraBulbLable");
            text.SetDefault($"Dryad Sells [i:{ModContent.ItemType<Items.BossAndEventControl.Plantera_Bulb>()}] Plantera Bulb After Plantera Defeated");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.GoblinRetreatOrderLable");
            text.SetDefault($"Goblin Tinkerer Sells [i:{ModContent.ItemType<Items.BossAndEventControl.Goblin_Retreat_Order>()}] Goblin Retreat Order");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.GoldReflectionMirror");
            text.SetDefault($"Merchant Sells [i:{ModContent.ItemType<Items.Gold_Reflection_Mirror>()}] Gold Reflection Mirror For Crafting Gold Critters Item");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.PirateRetreatOrder");
            text.SetDefault($"Pirate Sells [i:{ModContent.ItemType<Items.BossAndEventControl.Pirate_Retreat_Order>()}] Pirate Retreat Order");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.MoonBall");
            text.SetDefault($"Wizard Sells [i:{ModContent.ItemType<Items.Moon_Ball>()}] Moon Ball");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.WarPotion");
            text.SetDefault($"[i:{ModContent.ItemType<Items.BuffPotions.War_Potion>()}] War Potion (Crafted with [i:300] Battle Potion; gives Battle and War Buffs).");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Common.ChaosPotion");
            text.SetDefault($"[i:{ModContent.ItemType<Items.BuffPotions.Chaos_Potion>()}] Chaos Potion (Crafted with [i:{ModContent.ItemType<Items.BuffPotions.War_Potion>()}] War Potion; gives Battle, War, and Chaos Buffs).");
            LocalizationLoader.AddTranslation(text);
        }

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
            sundialSearchTimer,
            sundialX,
            sundialY,
            nearPylon,
            noMoreAnglerResetsToday,
            dayTime
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            MessageType msgType = (MessageType)reader.ReadByte();
            switch (msgType)
            {
                case MessageType.advanceMoonPhase:
                    Global.Update.advanceMoonPhase = reader.ReadBoolean();
                    break;
                case MessageType.sundialSearchTimer:
                    Global.Update.sundialSearchTimer = reader.ReadInt32();
                    break;
                case MessageType.sundialX:
                    Global.Update.sundialX = reader.ReadInt32();
                    break;
                case MessageType.sundialY:
                    Global.Update.sundialY = reader.ReadInt32();
                    break;
                case MessageType.nearPylon:
                    Global.Update.nearPylon = reader.ReadBoolean();
                    break;
                case MessageType.noMoreAnglerResetsToday:
                    Global.Update.noMoreAnglerResetsToday = reader.ReadBoolean();
                    break;
                case MessageType.dayTime:
                    Global.Update.dayTime = reader.ReadBoolean();
                    break;
                default:
                    Logger.WarnFormat("ExampleMod: Unknown Message type: {0}", msgType);
                    break;
            }
        }
    }
}