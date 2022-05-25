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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReducedGrinding;
using System.IO;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            ReducedGrindingMessageType msgType = (ReducedGrindingMessageType)reader.ReadByte();
            switch (msgType)
            {
                case ReducedGrindingMessageType.advanceMoonPhase:
                    World.advanceMoonPhase = reader.ReadBoolean();
                    break;
                case ReducedGrindingMessageType.sundialSearchCount:
                    World.sundialSearchCount = reader.ReadInt32();
                    break;
                case ReducedGrindingMessageType.sundialX:
                    World.sundialX = reader.ReadInt32();
                    break;
                case ReducedGrindingMessageType.sundialY:
                    World.sundialY = reader.ReadInt32();
                    break;
            }
        }
    }

    class SpawnRateMultiplierGlobalNPC : GlobalNPC
    {
        public override void EditSpawnRate(Terraria.Player player, ref int spawnRate, ref int maxSpawns)
        {

            if (player.FindBuffIndex(ModContent.BuffType<Buffs.War>()) != -1)
            {
                spawnRate = (int) (spawnRate / GetInstance<HOtherModdedItemsConfig>().WarPotionSpawnrateMultiplier);
                maxSpawns = (int) (maxSpawns * GetInstance<HOtherModdedItemsConfig>().WarPotionMaxSpawnsMultiplier);
            }
            if (player.FindBuffIndex(ModContent.BuffType<Buffs.Chaos>()) != -1)
            {
                spawnRate = (int) (spawnRate / GetInstance<HOtherModdedItemsConfig>().ChaosPotionSpawnrateMultiplier);
                maxSpawns = (int) (maxSpawns * GetInstance<HOtherModdedItemsConfig>().ChaosPotionMaxSpawnsMultiplier);
            }
        }
    }

    enum ReducedGrindingMessageType : byte
    {
        advanceMoonPhase,
        sundialSearchCount,
        sundialX,
        sundialY
    }

}