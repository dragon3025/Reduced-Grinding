using Humanizer;
using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Items
{
    public class MerchantDice : ModItem
    {
        public static int travelingMerchantDiceRolls;

        public override void SetDefaults()
        {
            TravelingMerchantConfig travelingMerchant = GetInstance<TravelingMerchantConfig>();

            Item.CloneDefaults(ItemID.MagicMirror);
            Item.width = 26;
            Item.height = 30;
            Item.value = Item.buyPrice(0, 10);
            Item.UseSound = SoundID.Item4;

            if (travelingMerchant.MerchantDiceUsesPreHardmode > 1)
            {
                return;
            }
            else if (travelingMerchant.MerchantDicePostHardmode > 1)
            {
                Item.rare = ItemRarityID.LightRed;
            }
            else if (travelingMerchant.MerchantDiceUsesPostMechBosses > 1)
            {
                Item.rare = ItemRarityID.LightPurple;
            }
            else if (travelingMerchant.MerchantDiceUsesPostPlantera > 1)
            {
                Item.rare = ItemRarityID.Lime;
            }
            else
            {
                Item.rare = ItemRarityID.Red;
            }
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                if (NPC.FindFirstNPC(NPCID.TravellingMerchant) == -1)
                {
                    Main.NewText(ReducedGrinding.GetText("Misc.MerchantDice.MerchantMissing"), 255, 240, 20);
                }
                else if (travelingMerchantDiceRolls == 0)
                {
                    Main.NewText(ReducedGrinding.GetText("Misc.MerchantDice.NoMoreReRolls"), 255, 240, 20);
                }
            }

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return true;
            }

            if (NPC.FindFirstNPC(NPCID.TravellingMerchant) != -1 && travelingMerchantDiceRolls > 0)
            {
                travelingMerchantDiceRolls--;
                Chest.SetupTravelShop();

                ////Item chance testing
                //travelingMerchantDiceRolls++;
                //int timesItemGotten = 0;
                //int rolls = 0;
                //int rollsMax = 1000000 /*100000000*/;
                //while (rolls < rollsMax)
                //{
                //    rolls++;
                //    Chest.SetupTravelShop();
                //    for (int slot = 0; slot < Main.travelShop.Length; slot++)
                //    {
                //        if (Main.travelShop[slot] == ItemID.PulseBow)
                //        {
                //            timesItemGotten++;
                //            break;
                //        }
                //    }
                //}
                //float itemRate = timesItemGotten / (float)rollsMax;
                //float averageRollsToGetItem = 1f / itemRate;
                //Main.NewText($"averageRollsToGetItem: {averageRollsToGetItem}");

                string reRollsLeft = ReducedGrinding.GetText("Misc.MerchantDice.ReRollsLeft").FormatWith(travelingMerchantDiceRolls);
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText(reRollsLeft, 50, 125, 255);
                }
                else
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey(reRollsLeft), new Color(50, 125, 255));

                    ModPacket packet = Mod.GetPacket();
                    packet.Write((byte)ReducedGrinding.MessageType.TravelingMerchantDiceRolls);
                    packet.Write(travelingMerchantDiceRolls);
                    packet.Send();
                }

                return true;
            }

            return true;
        }
    }

    public class MerchantDiceModSystem : ModSystem
    {
        private static readonly TravelingMerchantConfig travelingMerchant = GetInstance<TravelingMerchantConfig>();

        public override void PreUpdateTime()
        {
            if (!Main.dayTime || Main.time != 0)
            {
                return;
            }

            if (NPC.downedMoonlord)
            {
                MerchantDice.travelingMerchantDiceRolls = travelingMerchant.MerchantDiceUsesPostMoonlord;
            }
            else if (NPC.downedPlantBoss)
            {
                MerchantDice.travelingMerchantDiceRolls = travelingMerchant.MerchantDiceUsesPostPlantera;
            }
            else if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                MerchantDice.travelingMerchantDiceRolls = travelingMerchant.MerchantDiceUsesPostMechBosses;
            }
            else if (Main.hardMode)
            {
                MerchantDice.travelingMerchantDiceRolls = travelingMerchant.MerchantDicePostHardmode;
            }
            else
            {
                MerchantDice.travelingMerchantDiceRolls = travelingMerchant.MerchantDiceUsesPreHardmode;
            }
        }
    }
}