using Microsoft.Xna.Framework;
using Terraria;
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
            static void changeDifficulty()
            {
                if (Main.GameMode == 3)
                {
                    Main.GameMode = 0;
                }
                else
                {
                    Main.GameMode++;
                }
                GetInstance<ReducedGrinding>().Logger.Debug("Changed Game Mode to: " + Main.GameMode.ToString());
            }

            int startingDifficulty = Main.GameMode;
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                string text = "";
                Color textColor = new();
                bool finishedDifficultyChange = false;

                while (!finishedDifficultyChange)
                {
                    switch (Main.GameMode)
                    {
                        case 0:
                            if (GetInstance<HOtherModdedItemsConfig>().StaffOfDifficultyExpert)
                            {
                                finishedDifficultyChange = true;
                                text = "Expert mode is now enabled!";
                                textColor = new Color(255, 179, 0);
                                changeDifficulty();
                            }
                            break;
                        case 1:
                            if (GetInstance<HOtherModdedItemsConfig>().StaffOfDifficultyMaster)
                            {
                                finishedDifficultyChange = true;
                                text = "Master mode is now enabled!";
                                textColor = new Color(255, 0, 0);
                                changeDifficulty();
                            }
                            break;
                        case 2:
                            if (GetInstance<HOtherModdedItemsConfig>().StaffOfDifficultyJourney)
                            {
                                finishedDifficultyChange = true;
                                text = "Journey mode is now enabled!";
                                textColor = new Color(255, 127, 255);
                                changeDifficulty();
                            }
                            break;
                        default:
                            if (GetInstance<HOtherModdedItemsConfig>().StaffOfDifficultyNormal)
                            {
                                finishedDifficultyChange = true;
                                text = "Normal mode is now enabled!";
                                textColor = new Color(255, 255, 255);
                                changeDifficulty();
                            }
                            break;
                    }
                    if (Main.GameMode == startingDifficulty)
                    {
                        finishedDifficultyChange = true;
                    }
                }

                if (Main.GameMode != startingDifficulty)
                {
                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        Main.NewText(text, textColor);
                    }
                    else if (Main.netMode == NetmodeID.Server)
                    {
                        ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), textColor);
                        NetMessage.SendData(MessageID.WorldData);
                    }
                }
            }

            if (Main.GameMode == startingDifficulty && player.whoAmI == Main.myPlayer)
            {
                Main.NewText("Staff of Difficulty configurations aren't letting you change to any difficulty.", new Color(255, 128, 128));
            }
            else if (Main.GameMode != startingDifficulty && Main.netMode != NetmodeID.MultiplayerClient)
            {
                for (int i = 0; i < Main.player.Length; i++)
                {
                    if (!Main.player[i].active)
                    {
                        continue;
                    }

                    if (Main.player[i].difficulty == PlayerDifficultyID.Creative && Main.GameMode != GameModeID.Creative)
                    {
                        Main.player[i].difficulty = PlayerDifficultyID.SoftCore;
                    }
                    else if (Main.player[i].difficulty != PlayerDifficultyID.Creative && Main.GameMode == GameModeID.Creative)
                    {
                        Main.player[i].difficulty = PlayerDifficultyID.Creative;
                    }
                }
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.SyncPlayer);
                }
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