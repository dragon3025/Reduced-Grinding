using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Items
{
    public class NicePresent : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.value = 0;
            Item.rare = ItemRarityID.Yellow;
            Item.useAnimation = 20;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item4;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.xMas;
        }

        public override bool? UseItem(Player player)
        {
            Main.xMas = true;
            if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Misc.StartedVictoryXmas"), new Color(50, 255, 130));
            }
            else
            {
                Main.NewText(NetworkText.FromKey("Misc.StartedVictoryXmas"), new Color(50, 255, 130));
            }
            return true;
        }

        public override void AddRecipes()
        {
            if (GetInstance<HOtherModdedItemsConfig>().HolidaySummons > 0)
            {
                Recipe recipe = Recipe.Create(Type);
                recipe.AddIngredient(ItemID.NaughtyPresent);
                recipe.AddIngredient(ItemID.PurificationPowder);
                recipe.AddTile(TileID.CrystalBall);
                if (GetInstance<HOtherModdedItemsConfig>().HolidaySummons == 2)
                {
                    recipe.AddCondition(Condition.Christmas);
                    recipe.Register();
                }
            }
        }
    }
}