using Microsoft.Xna.Framework.Graphics;
using ReducedGrinding.Common.ModPlayers;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Buffs
{
    public class Bobber : ModBuff
    {
        private Asset<Texture2D> greaterBobberTexture;
        private Asset<Texture2D> superBobberTexture;

        public override void SetStaticDefaults()
        {
            greaterBobberTexture = Request<Texture2D>("ReducedGrinding/Content/Buffs/GreaterBobber");
            superBobberTexture = Request<Texture2D>("ReducedGrinding/Content/Buffs/SuperBobber");
        }

        public override bool PreDraw(SpriteBatch spriteBatch, int buffIndex, ref BuffDrawParams drawParams)
        {
            Player player = Main.LocalPlayer;

            switch (player.GetModPlayer<BobberBuffTiers>().bobberBuffTier)
            {
                case 2:
                    drawParams.Texture = greaterBobberTexture.Value;
                    return true;
                case 3:
                    drawParams.Texture = superBobberTexture.Value;
                    return true;
            }
            return true;
        }
    }
}