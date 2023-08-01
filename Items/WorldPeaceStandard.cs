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
    public class WorldPeaceStandard : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
            Item.useAnimation = 20;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item4;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return Main.invasionType != InvasionID.None;
        }

        public override bool? UseItem(Player player)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                Main.invasionType = InvasionID.None;

                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText("The invasion left.", new Color(255, 255, 0));
                }
                else
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey("The invasion left."), new Color(255, 255, 0));
                    NetMessage.SendData(MessageID.WorldData);
                }
            }

            return true;
        }

        public override void AddRecipes()
        {
            if (GetInstance<HOtherModdedItemsConfig>().WorldPeaceStandard)
            {
                Recipe recipe = Recipe.Create(Type);
                recipe.AddIngredient(ItemID.PinkGel);
                recipe.AddIngredient(ItemID.Silk, 10);
                recipe.AddRecipeGroup(RecipeGroupID.Wood, 10);
                recipe.AddTile(TileID.Loom);
                recipe.Register();
            }
        }
    }
}