using ReducedGrinding.Configuration;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Content.Items.Placeable
{
    internal class JackStatue : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.KingStatue);
            Item.width = 24;
            Item.height = 38;
            Item.createTile = ModContent.TileType<Tiles.JackStatue>();
        }

        public override void AddRecipes()
        {
            if (!ModContent.GetInstance<VillagersAndEnemiesConfig>().JackStatue)
            {
                return;
            }
            Recipe recipe = Recipe.Create(Type);
            recipe.AddIngredient(ItemID.KingStatue);
            recipe.AddIngredient(ItemID.QueenStatue);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddConsumeIngredientCallback(DontConsumeStatues);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.Register();
        }

        public static void DontConsumeStatues(Recipe recipe, int type, ref int amount, bool isDecrafting)
        {
            if (type == ItemID.KingStatue || type == ItemID.QueenStatue)
            {
                amount = 0;
            }
        }
    }

    internal class JackStatueGlobalItem : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => ModContent.GetInstance<VillagersAndEnemiesConfig>().JackStatue
            && (entity.type == ItemID.KingStatue || entity.type == ItemID.QueenStatue);

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "NotConsumedWhenCraftingJackStatue", ReducedGrinding.GetText("Misc.NotConsumedWhenCraftingJackStatue")));
        }
    }
}