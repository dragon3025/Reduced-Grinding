using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using System;
using System.IO;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalItems
{
    public class ShimmerEffects : GlobalItem
    {
        private bool justShimmered;
        private static int itemShimmeredForRain;
        private static int itemShimmeredForWind;

        public override bool InstancePerEntity => true;

        public override void SetDefaults(Item entity)
        {
            itemShimmeredForRain = GetInstance<TimeAndWeatherConfig>().ItemShimmeredForRain.Type;
            itemShimmeredForWind = GetInstance<TimeAndWeatherConfig>().ItemShimmeredForWind.Type;
            if (itemShimmeredForRain > 0)
            {
                ItemID.Sets.ShimmerTransformToItem[itemShimmeredForRain] = itemShimmeredForRain;
            }
            if (itemShimmeredForWind > 0)
            {
                ItemID.Sets.ShimmerTransformToItem[itemShimmeredForWind] = itemShimmeredForWind;
            }
        }

        public override bool OnPickup(Item item, Player player)
        {
            if (justShimmered)
            {
                justShimmered = false;
            }
            return true;
        }

        public override void NetSend(Item item, BinaryWriter writer)
        {
            writer.Write(justShimmered);
        }

        public override void NetReceive(Item item, BinaryReader reader)
        {
            justShimmered = reader.ReadBoolean();
        }

        public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
        {
            if (!item.shimmered || justShimmered)
            {
                return;
            }
            justShimmered = true;

            if (item.type == itemShimmeredForRain && itemShimmeredForRain > 0)
            {
                if (Main.raining)
                {
                    ShowCantShimmerMessage(item, ReducedGrinding.GetText("Misc.CantShimmerItem"));
                    return;
                }
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Main.StartRain();
                    Main.maxRaining = 1f;
                    Main.numClouds = 200;
                }
                if (item.type != itemShimmeredForWind)
                {
                    ReducedItemStack(item);
                }
            }
            if (item.type == itemShimmeredForWind && itemShimmeredForWind > 0)
            {
                if (Math.Abs(Main.windSpeedTarget) >= 0.8f)
                {
                    ShowCantShimmerMessage(item, ReducedGrinding.GetText("Misc.CantShimmerItem"));
                    return;
                }
                Main.windSpeedTarget = Math.Sign(Main.windSpeedTarget) * 0.8f;
                if (Main.windSpeedTarget == 0f)
                {
                    Main.windSpeedTarget = Main.rand.NextBool(2) ? 0.8f : -0.8f;
                }
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    ShimmerEffectsModSystem.startSandstorm = true;
                }
                ReducedItemStack(item);
            }
        }

        private static void ReducedItemStack(Item item)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }
            item.stack--;
            if (item.stack > 0)
            {
                return;
            }
            item.TurnToAir();
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.SyncItem, number: item.whoAmI);
            }
        }

        private static void ShowCantShimmerMessage(Item item, string message)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(message, 255, 240, 20);
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                foreach (Player player in Main.ActivePlayers)
                {
                    if (item.Distance(player.position) <= 1000f)
                    {
                        ChatHelper.SendChatMessageToClient(NetworkText.FromKey(message), new Color(255, 240, 20), player.whoAmI);
                    }
                }
            }
        }
    }

    public class ShimmerEffectsModSystem : ModSystem
    {
        public static bool startSandstorm;

        public override void PostUpdateTime()
        {
            if (Math.Abs(Main.windSpeedCurrent) >= 0.6f && startSandstorm && Main.netMode != NetmodeID.MultiplayerClient)
            {
                Sandstorm.StartSandstorm();
                startSandstorm = false;
            }
        }
    }
}