using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Items.Consumable.Summoning
{
    public class PumpkinPieMedallion : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SuspiciousLookingEye);
            Item.UseSound = SoundID.Item4;
            Item.width = 26;
            Item.height = 32;
            Item.rare = ItemRarityID.Yellow;
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.halloween;
        }

        public override bool? UseItem(Player player)
        {
            Main.halloween = true;
            if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Misc.StartedVictoryHalloween"), new Color(50, 255, 130));
            }
            else
            {
                Main.NewText(NetworkText.FromKey("Misc.StartedVictoryHalloween"), new Color(50, 255, 130));
            }
            return true;
        }

        public override void AddRecipes()
        {
            EventAndBossConfig eventAndBossConfig = GetInstance<EventAndBossConfig>();

            if (eventAndBossConfig.HolidaySummons != HolidaySummonsEnums.Disabled)
            {
                Recipe recipe = Recipe.Create(Type);
                recipe.AddIngredient(ItemID.PumpkinMoonMedallion);
                recipe.AddIngredient(ItemID.PurificationPowder);
                recipe.AddTile(TileID.CrystalBall);
                if (eventAndBossConfig.HolidaySummons == HolidaySummonsEnums.RequireSeason)
                {
                    recipe.AddCondition(Condition.Halloween);
                }
                recipe.Register();
            }
        }
    }
}