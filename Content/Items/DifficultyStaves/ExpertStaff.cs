using Humanizer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReducedGrinding.Common.ModSystems;
using ReducedGrinding.Configuration;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Items.DifficultyStaves
{
    public class ExpertStaff : ModItem
    {
        private static readonly OtherConfig otherConfig = GetInstance<OtherConfig>();

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string text;
            if (Main.getGoodWorld)
            {
                text = ReducedGrinding.GetText("Misc.DifficultyStaves.GetGoodWillModifyDifficulty");
                tooltips.Add(new TooltipLine(Mod, "GetGoodWillModifyDifficulty", text.FormatWith("FF2619", Language.GetTextValue("UI.Master"))));
            }
            if (Main.GameMode == GameModeID.Expert)
            {
                text = ReducedGrinding.GetText("Misc.DifficultyStaves.DifficultyIsTheSame");
                tooltips.Add(new TooltipLine(Mod, "DifficultyIsTheSame", text));
            }
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MagicMirror);
            Item.width = 12;
            Item.height = 12;
            Item.UseSound = SoundID.Item4;
            Item.value = 0;
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (Main.gameMenu || Main.GameMode != GameModeID.Expert)
            {
                return true;
            }
            spriteBatch.Draw(TextureAssets.Item[Type].Value, position, frame, Color.Gray, 0, origin, scale, SpriteEffects.None, 0);
            return false;
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            player.itemLocation.X = player.Center.X + 2 * player.direction;
            player.itemLocation.Y = player.position.Y + 14;
        }

        public override bool? UseItem(Player player)
        {
            return DifficultyStavesSystem.RequestDifficulty(player, GameModeID.Expert);
        }

        public override void AddRecipes()
        {
            if (otherConfig.DifficultyStavesEnabled)
            {
                CreateRecipe()
                  .AddIngredient(ItemID.FallenStar)
                  .AddRecipeGroup(RecipeGroupID.Wood, 5)
                  .Register();
            }
        }
    }
}