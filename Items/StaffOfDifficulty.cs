using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Items
{
    public class StaffOfDifficulty : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Staff of Difficulty");
            Tooltip.SetDefault("A creative tool that switches the difficulty modes");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(20, 4));
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

        public override bool? UseItem(Player player)
        {
            string text;
            int difficultyChanges = 0;
            Color textColor = new();

            changeDifficulty: { }

            if (difficultyChanges < 4)
            {
                switch (Main.GameMode)
                {
                    case 0:
                        Main.GameMode = 1;
                        difficultyChanges++;
                        if (!GetInstance<HOtherModdedItemsConfig>().StaffOfDifficultyExpert)
                            goto changeDifficulty;
                        player.difficulty = 0;
                        text = "Expert mode is now enabled!"; //Localize
                        textColor = new Color(255, 179, 0);
                        break;
                    case 1:
                        Main.GameMode = 2;
                        difficultyChanges++;
                        if (!GetInstance<HOtherModdedItemsConfig>().StaffOfDifficultyMaster)
                            goto changeDifficulty;
                        player.difficulty = 0;
                        text = "Master mode is now enabled!"; //Localize
                        textColor = new Color(255, 0, 0);
                        break;

                    case 2:
                        Main.GameMode = 3;
                        difficultyChanges++;
                        if (!GetInstance<HOtherModdedItemsConfig>().StaffOfDifficultyJourney)
                            goto changeDifficulty;
                        player.difficulty = 3;
                        text = "Journey mode is now enabled!"; //Localize
                        textColor = new Color(255, 127, 255);
                        break;

                    default:
                        Main.GameMode = 0;
                        difficultyChanges++;
                        if (!GetInstance<HOtherModdedItemsConfig>().StaffOfDifficultyNormal)
                            goto changeDifficulty;
                        player.difficulty = 0;
                        text = "Normal mode is now enabled!"; //Localize
                        textColor = new Color(255, 255, 255);
                        break;
                }

                SoundEngine.PlaySound(SoundID.Item4, player.Center);
            }
            else
            {
                text = "The configuration isn't allowing you to change to any difficulty mode."; //Localize
                textColor = new Color(255, 0, 0);
            }

            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(text, textColor);
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), textColor);
                if (difficultyChanges < 4)
                    NetMessage.SendData(MessageID.WorldData);
            }

            return true;
        }

        public override void AddRecipes()
        {
            if (GetInstance<HOtherModdedItemsConfig>().StaffOfDifficultyJourney ||
                GetInstance<HOtherModdedItemsConfig>().StaffOfDifficultyNormal ||
                GetInstance<HOtherModdedItemsConfig>().StaffOfDifficultyExpert ||
                GetInstance<HOtherModdedItemsConfig>().StaffOfDifficultyMaster)
            {
                CreateRecipe()
                  .AddIngredient(ItemID.DirtBlock)
                  .Register();
            }
        }
    }
}