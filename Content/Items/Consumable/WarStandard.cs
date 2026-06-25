using ReducedGrinding.Configuration;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Items.Consumable
{
    public class WarStandard : ModItem
    {
        private readonly bool greaterBattlePotion = GetInstance<BattlePotionConfig>().GreaterBattlePotion;
        private readonly int warStandardDuration = GetInstance<EventAndBossConfig>().WarStandardDuration;

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (greaterBattlePotion)
            {
                tooltips.Add(new TooltipLine(Mod, "WarStandardBattlePotionTooltip", ReducedGrinding.GetText("Misc.WarStandardBattlePotionTooltip")));
            }
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SuspiciousLookingEye);
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.sellPrice(0, 0, 20, 2);
            Item.rare = ItemRarityID.White;
            Item.UseSound = SoundID.Item4;
            Item.buffType = BuffType<Buffs.WarStandard>();
            Item.buffTime = 60 * 60 * warStandardDuration;
        }

        public override bool CanUseItem(Player player)
        {
            return Main.invasionType != InvasionID.None;
        }

        public override void AddRecipes()
        {
            if (warStandardDuration > 0)
            {
                Recipe recipe = Recipe.Create(Type);
                recipe.AddIngredient(ItemID.Silk, 10);
                recipe.AddRecipeGroup(RecipeGroupID.Wood, 10);
                recipe.AddTile(TileID.Loom);
                Recipe recipe2 = recipe.Clone();

                recipe.AddIngredient(ItemID.RottenChunk);
                recipe.Register();

                recipe2.AddIngredient(ItemID.Vertebrae);
                recipe2.Register();
            }
        }
    }

    public class WarStandardSystem : ModSystem
    {
        public static int frozenProgress;

        public override void PostUpdateTime()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient/* || WarStandard.activeTime < 1*/)
            {
                return;
            }

            bool playerHasWarStandard = false;
            foreach (Player player in Main.ActivePlayers)
            {
                if (player.HasBuff(BuffType<Buffs.WarStandard>()))
                {
                    playerHasWarStandard = true;
                    break;
                }
            }

            if (!playerHasWarStandard)
            {
                frozenProgress = 0;
                return;
            }

            if (frozenProgress == 0)
            {
                frozenProgress = Main.invasionSize;
            }

            Main.invasionSize = frozenProgress;
            NetMessage.SendData(MessageID.WorldData);
        }
    }
}