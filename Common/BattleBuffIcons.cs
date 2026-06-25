using Microsoft.Xna.Framework.Graphics;
using ReducedGrinding.Common.ModPlayers;
using ReducedGrinding.Configuration;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common
{
    public class BattleBuffIcons : GlobalBuff
    {
        private Asset<Texture2D> greaterBattleTexture;
        private Asset<Texture2D> superBattleTexture;

        public override void SetStaticDefaults()
        {
            greaterBattleTexture = Request<Texture2D>("ReducedGrinding/Content/Buffs/GreaterBattle");
            superBattleTexture = Request<Texture2D>("ReducedGrinding/Content/Buffs/SuperBattle");
        }

        public override bool PreDraw(SpriteBatch spriteBatch, int type, int buffIndex, ref BuffDrawParams drawParams)
        {
            if (!GetInstance<BattlePotionConfig>().BuffIconTiers || type != BuffID.Battle)
            {
                return true;
            }

            Player player = Main.LocalPlayer;

            switch (player.GetModPlayer<BattleBuffTiers>().battleBuffTier)
            {
                case 2:
                    drawParams.Texture = greaterBattleTexture.Value;
                    return true;
                case 3:
                    drawParams.Texture = superBattleTexture.Value;
                    return true;
            }
            return true;
        }
    }
}
