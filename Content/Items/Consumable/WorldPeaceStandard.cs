using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Items.Consumable
{
    public class WorldPeaceStandard : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SuspiciousLookingEye);
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.sellPrice(0, 0, 20, 3);
            Item.UseSound = SoundID.Item4;
            Item.rare = ItemRarityID.White;
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
                    Main.NewText(ReducedGrinding.GetText("Misc.WorldPeaceStandard"), new Color(175, 75, 255));
                }
                else
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey(ReducedGrinding.GetText("Misc.WorldPeaceStandard")), new Color(175, 75, 255));
                    NetMessage.SendData(MessageID.WorldData);
                }
            }

            return true;
        }

        public override void AddRecipes()
        {
            if (GetInstance<EventAndBossConfig>().WorldPeaceStandard)
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