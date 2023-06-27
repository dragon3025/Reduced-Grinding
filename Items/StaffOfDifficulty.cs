using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Items
{
    public class StaffOfDifficulty : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(20, 3));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 42;
            Item.maxStack = 1;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Master;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
        }

        public override bool CanUseItem(Player player)
        {
            return Main.GameMode != GameModeID.Creative && (
                GetInstance<HOtherModdedItemsConfig>().StaffOfDifficultyConfig.Normal ||
                GetInstance<HOtherModdedItemsConfig>().StaffOfDifficultyConfig.Expert ||
                GetInstance<HOtherModdedItemsConfig>().StaffOfDifficultyConfig.Master);
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                Global.Update.advanceDifficulty = true;
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    ModPacket packet = Mod.GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.advanceDifficulty);
                    packet.Write(Global.Update.advanceDifficulty);
                    packet.Send();
                }
                SoundEngine.PlaySound(SoundID.Item4); //Crystal Ball
            }

            return true;
        }

        public override void AddRecipes()
        {
            if (GetInstance<HOtherModdedItemsConfig>().StaffOfDifficultyConfig.Normal ||
                GetInstance<HOtherModdedItemsConfig>().StaffOfDifficultyConfig.Expert ||
                GetInstance<HOtherModdedItemsConfig>().StaffOfDifficultyConfig.Master)
            {
                CreateRecipe()
                  .AddIngredient(ItemID.DirtBlock)
                  .Register();
            }
        }
    }
}