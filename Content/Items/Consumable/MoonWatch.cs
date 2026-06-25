using Humanizer;
using ReducedGrinding.Configuration;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Items.Consumable
{
    public class MoonWatch : ModItem
    {
        private static readonly TimeAndWeatherConfig otherModdedItemsConfig = GetInstance<TimeAndWeatherConfig>();
        private static int type;
        private static int type2;
        private static readonly int materialStack = otherModdedItemsConfig.MoonWatchMaterialAmount;

        public override void SetDefaults()
        {
            type = otherModdedItemsConfig.MoonWatchMaterial.Type;
            type2 = otherModdedItemsConfig.MoonWatchAlternateMaterial.Type;
            Item.CloneDefaults(ItemID.LifeCrystal);
            Item.width = 28;
            Item.height = 30;
            Item.useTurn = true;
            Item.rare = ItemHelper.GetItemRarityFromIngredients(ItemRarityID.Blue, type, type2);
            Item.value = ItemHelper.GetItemValueFromIngredients(Item.sellPrice(0, 0, 5, 40), type, type2, materialStack);
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                SoundEngine.PlaySound(SoundID.Item4); //Crystal Ball
            }

            if (Main.bloodMoon)
            {
                if (player.whoAmI == Main.myPlayer)
                {
                    Main.NewText(ReducedGrinding.GetText("Misc.MoonWatch.BloodMoon"), 255, 240, 20);
                }
                return true;
            }

            Main.moonPhase++;
            if (Main.moonPhase > 7)
            {
                Main.moonPhase = 0;
            }

            string moonPhaseName = Main.moonPhase switch
            {
                0 => Language.GetTextValue("GameUI.FullMoon"),
                1 => Language.GetTextValue("GameUI.WaningGibbous"),
                2 => Language.GetTextValue("GameUI.ThirdQuarter"),
                3 => Language.GetTextValue("GameUI.WaningCrescent"),
                4 => Language.GetTextValue("GameUI.NewMoon"),
                5 => Language.GetTextValue("GameUI.WaxingCrescent"),
                6 => Language.GetTextValue("GameUI.FirstQuarter"),
                _ => Language.GetTextValue("GameUI.WaxingGibbous"),
            };

            string moonPhaseText = ReducedGrinding.GetText("Misc.MoonWatch.MoonPhase").FormatWith(moonPhaseName);

            Main.NewText(moonPhaseText, 255, 240, 20);

            return true;
        }

        public override void AddRecipes()
        {
            if (type != ItemID.None)
            {
                Recipe recipe = Recipe.Create(Type);
                recipe.AddIngredient(type, materialStack);
                recipe.AddTile(TileID.WorkBenches);
                recipe.AddIngredient(ItemID.Chain);
                recipe.AddIngredient(ItemID.FallenStar);
                recipe.Register();
            }

            if (type2 == ItemID.None)
            {
                return;
            }
            Recipe recipe2 = Recipe.Create(Type);
            recipe2.AddTile(TileID.WorkBenches);
            recipe2.AddIngredient(type2, materialStack);
            recipe2.AddIngredient(ItemID.Chain);
            recipe2.AddIngredient(ItemID.FallenStar);
            recipe2.Register();
        }

        public static void AdvanceMoonPhase()
        {
            Main.moonPhase++;
            if (Main.moonPhase > 7)
            {
                Main.moonPhase = 0;
            }

            string moonPhaseName = Main.moonPhase switch
            {
                0 => Language.GetTextValue("GameUI.FullMoon"),
                1 => Language.GetTextValue("GameUI.WaningGibbous"),
                2 => Language.GetTextValue("GameUI.ThirdQuarter"),
                3 => Language.GetTextValue("GameUI.WaningCrescent"),
                4 => Language.GetTextValue("GameUI.NewMoon"),
                5 => Language.GetTextValue("GameUI.WaxingCrescent"),
                6 => Language.GetTextValue("GameUI.FirstQuarter"),
                _ => Language.GetTextValue("GameUI.WaxingGibbous"),
            };

            string moonPhaseText = ReducedGrinding.GetText("Misc.MoonWatch.MoonPhase").FormatWith(moonPhaseName);

            Main.NewText(moonPhaseText, 255, 240, 20);
        }
    }
}
