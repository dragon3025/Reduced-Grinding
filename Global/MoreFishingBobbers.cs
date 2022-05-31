using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.GlobalMoreFishingRobBobbers
{
    public class MoreFishingBobbers : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.fishingPole > 0;
        }

        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.FindBuffIndex(ModContent.BuffType<Buffs.Multi_Bobber>()) != -1 && GetInstance<CFishingConfig>().MultiBobberPotionBobberAmount > 1)
            {
                int bobberAmount = 10;
                float spreadAmount = 75f;
                for (int index = 0; index < bobberAmount; ++index)
                {
                    Vector2 bobberSpeed = velocity + new Vector2(Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f, Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f);
                    Projectile.NewProjectile(source, position, bobberSpeed, type, 0, 0f, player.whoAmI);
                }
            }
            else
            {
                Vector2 bobberSpeed = velocity;
                Projectile.NewProjectile(source, position, bobberSpeed, type, 0, 0f, player.whoAmI);
            }

            return false;
        }
    }
}
