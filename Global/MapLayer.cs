using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.Map;
using Terraria.ModLoader;
using Terraria.UI;
using Microsoft.Xna.Framework.Graphics;

namespace ReducedGrinding.Global
{
    public class MapLayer : ModMapLayer
    {

        public override void Draw(ref MapOverlayDrawContext context, ref string text)
        {

            const float scaleIfNotSelected = 1f;
            const float scaleIfSelected = scaleIfNotSelected * 2f;

            var enchantedSundialTexture = ModContent.Request<Texture2D>("ReducedGrinding/Global/EnchantedSundialMapMarker").Value;

            if (Update.sundialX == -1)
                return;

            if (Update.nearPylon)
                return;

            if (context.Draw(enchantedSundialTexture, new Vector2(Global.Update.sundialX, Global.Update.sundialY), Color.White, new SpriteFrame(1, 1, 0, 0), scaleIfNotSelected, scaleIfSelected, Alignment.Center).IsMouseOver)
            {
                text = "Enchanted Sundial\n(Boosting Sleep Rate)";
            }
        }
    }
}