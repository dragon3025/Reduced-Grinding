using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
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
            int bobbersToAdd = 0;

            if (player.FindBuffIndex(BuffType<Buffs.SuperMultiBobber>()) != -1)
            {
                bobbersToAdd = GetInstance<CFishingConfig>().BobberPotions.SuperMultiBobberPotionBonus;
            }
            else if (player.FindBuffIndex(BuffType<Buffs.GreaterMultiBobber>()) != -1)
            {
                bobbersToAdd = GetInstance<CFishingConfig>().BobberPotions.GreaterMultiBobberPotionBonus;
            }
            else if (player.FindBuffIndex(BuffType<Buffs.MultiBobber>()) != -1)
            {
                bobbersToAdd = GetInstance<CFishingConfig>().BobberPotions.MultiBobberPotionBonus;
            }

            if (bobbersToAdd > 0)
            {
                float spreadAmount = 75f;

                for (int index = 0; index < bobbersToAdd; ++index)
                {
                    Vector2 bobberSpeed = velocity + new Vector2(Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f, Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f);
                    Projectile.NewProjectile(source, position, bobberSpeed, type, 0, 0f, player.whoAmI);
                }
            }

            return true;
        }
    }
}
