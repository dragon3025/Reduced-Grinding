using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.Map;
using Terraria.ModLoader;
using Terraria.UI;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;

namespace ReducedGrinding
{
	public class ReducedGrindingMapLayer : ModMapLayer
	{

		public override void Draw(ref MapOverlayDrawContext context, ref string text) {

			const float scaleIfNotSelected = 1f;
			const float scaleIfSelected = scaleIfNotSelected * 2f;

			var enchantedSundialTexture = ModContent.Request<Texture2D>("ReducedGrinding/Assets/EnchantedSundialMapMarker").Value;

			if (ReducedGrindingWorld.sundialX == -1)
				return;

			if (context.Draw(enchantedSundialTexture, new Vector2(ReducedGrindingWorld.sundialX, ReducedGrindingWorld.sundialY), Color.White, new SpriteFrame(1, 1, 0, 0), scaleIfNotSelected, scaleIfSelected, Alignment.Center).IsMouseOver) {
				text = "Enchanted Sundial";
			}
		}
	}
}