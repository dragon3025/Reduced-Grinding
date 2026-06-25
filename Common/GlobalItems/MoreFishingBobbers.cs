using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using ReducedGrinding.Content.Buffs;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalItems
{
    public class MoreFishingBobbers : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.fishingPole > 0;
        }

        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            BobberPotionConfig bobberPotionConfig = GetInstance<BobberPotionConfig>();
            int buffIndex = player.FindBuffIndex(BuffType<Bobber>());

            if (buffIndex == -1)
            {
                return true;
            }

            int bobbersToAdd;
            if (player.buffTime[buffIndex] > 6 * 60 * 60)
            {
                bobbersToAdd = bobberPotionConfig.SuperBobberPotionBonus;
            }
            else if (player.buffTime[buffIndex] > 3 * 60 * 60)
            {
                bobbersToAdd = bobberPotionConfig.GreaterBobberPotionBonus;
            }
            else
            {
                bobbersToAdd = bobberPotionConfig.BobberPotionBonus;
            }

            if (bobbersToAdd <= 0)
            {
                return true;
            }

            float spreadAmount = 75f;
            for (int index = 0; index < bobbersToAdd; ++index)
            {
                Vector2 bobberSpeed = velocity + new Vector2(Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f, Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f);
                Projectile.NewProjectile(source, position, bobberSpeed, type, 0, 0f, player.whoAmI);
            }

            return true;
        }
    }
}
