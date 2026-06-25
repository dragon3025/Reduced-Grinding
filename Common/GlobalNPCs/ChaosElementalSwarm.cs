using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalNPCs
{
    public class ChaosElementalSwarm : GlobalNPC
    {
        private static readonly VillagersAndEnemiesConfig villagersAndEnemiesConfig = GetInstance<VillagersAndEnemiesConfig>();
        public static int chaosSwarmtime;

        public override bool InstancePerEntity => true;

        public override void OnKill(NPC npc)
        {
            if (villagersAndEnemiesConfig.CESwarmDuration == 0 || npc.type != NPCID.QueenSlimeBoss || Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }

            chaosSwarmtime = 60 * 60 * villagersAndEnemiesConfig.CESwarmDuration;
            if (Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = Mod.GetPacket();
                packet.Write((byte)ReducedGrinding.MessageType.ChaosSwarmtime);
                packet.Write(chaosSwarmtime);
                packet.Send();
            }

            string text = ReducedGrinding.GetText("Misc.ChaosElementalSwarm.Start");
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(text, 50, 255, 130);
                return;
            }
            ChatHelper.BroadcastChatMessage(NetworkText.FromKey(text), new Color(50, 255, 130));
        }

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if (!spawnInfo.Player.ZoneHallow || spawnInfo.Player.position.ToTileCoordinates().Y <= Main.rockLayer || chaosSwarmtime < 1)
            {
                return;
            }

            if (Main.rand.NextBool(villagersAndEnemiesConfig.CESwarmCElementalSpawnFailRate))
            {
                if (Main.rand.NextBool(villagersAndEnemiesConfig.CESwarmESwordSpawnFailRate))
                {
                    return;
                }

                pool.Clear();
                pool.Add(new KeyValuePair<int, float>(NPCID.EnchantedSword, 1));
                return;
            }

            pool.Clear();
            pool.Add(new KeyValuePair<int, float>(NPCID.ChaosElemental, 1));
        }

        public override void SetDefaults(NPC npc)
        {
            if (npc.type != NPCID.ChaosElemental || chaosSwarmtime < 1)
            {
                return;
            }

            npc.knockBackResist = 1f - villagersAndEnemiesConfig.CESKnockbackResist;
        }
    }

    public class ChaosElementalSwarmSystem : ModSystem
    {
        public override void PostUpdateTime()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }

            if (ChaosElementalSwarm.chaosSwarmtime > 0)
            {
                ChaosElementalSwarm.chaosSwarmtime--;
                if (GetInstance<VillagersAndEnemiesConfig>().CESwarmDuration == 0)
                {
                    ChaosElementalSwarm.chaosSwarmtime = 0;
                }
                if (ChaosElementalSwarm.chaosSwarmtime == 0)
                {
                    string text = ReducedGrinding.GetText("Misc.ChaosElementalSwarm.End");
                    if (Main.netMode == NetmodeID.Server)
                    {
                        ModPacket packet = Mod.GetPacket();
                        packet.Write((byte)ReducedGrinding.MessageType.ChaosSwarmtime);
                        packet.Write(ChaosElementalSwarm.chaosSwarmtime);
                        packet.Send();

                        ChatHelper.BroadcastChatMessage(NetworkText.FromKey(text), new Color(50, 255, 130));

                        return;
                    }
                    Main.NewText(text, 50, 255, 130);
                }
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(ChaosElementalSwarm.chaosSwarmtime);
        }

        public override void NetReceive(BinaryReader reader)
        {
            ChaosElementalSwarm.chaosSwarmtime = reader.ReadInt32();
        }
    }
}
