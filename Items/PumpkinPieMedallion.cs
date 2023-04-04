using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Items
{
    public class PumpkinPieMedallion : ModItem
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
            Item.UseSound = SoundID.ForceRoar;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.halloween;
        }

        public override bool? UseItem(Player player)
        {
            Main.halloween = true;
            if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Misc.StartedVictoryHalloween"), new Color(255, 255, 0));
            }
            else
            {
                Main.NewText(NetworkText.FromKey("Misc.StartedVictoryHalloween"), new Color(255, 255, 0));
            }
            return true;
        }

        public override void AddRecipes()
        {
            if (GetInstance<HOtherModdedItemsConfig>().HolidaySummons == true)
            {
                Recipe recipe = Recipe.Create(Type);
                recipe.AddIngredient(ItemID.PumpkinMoonMedallion);
                recipe.AddIngredient(ItemID.PurificationPowder);
                recipe.AddTile(TileID.CrystalBall);
                recipe.AddCondition(Condition.Halloween);
                recipe.Register();
            }
        }
    }
}