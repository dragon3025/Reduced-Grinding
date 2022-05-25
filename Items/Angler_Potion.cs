using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Items
{
    public class Angler_Potion : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Angler Potion");
            Tooltip.SetDefault("One botle of this will make the Angler want to give you a new fishing quest right away.");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.maxStack = 30;
            Item.rare = ItemRarityID.Green;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.value = 200;
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
        }

        public override bool CanUseItem(Terraria.Player player)
        {
            return true;
        }

        public override bool? UseItem(Terraria.Player player)
        {
            Main.NewText("The angler has a new quest for you.", 0, 128, 255);
            Main.AnglerQuestSwap();
            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.WorldData);
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BottledWater, 1)
                .AddIngredient(ItemID.SpecularFish)
                .AddIngredient(ItemID.Moonglow)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}