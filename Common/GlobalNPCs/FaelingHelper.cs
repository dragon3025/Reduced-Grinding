using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalNPCs
{
    internal class FaelingHelper : GlobalNPC
    {
        private bool headToShimmer;
        private float speed = 1f;
        private bool helper;
        public bool despawn;
        public static Vector2 shimmerPosition = new();
        public static bool shimmerFound;

        private readonly OtherConfig otherConfig = GetInstance<OtherConfig>();

        public override bool InstancePerEntity => true;

        public override void PostAI(NPC npc)
        {
            if (npc.type != NPCID.Shimmerfly)
            {
                return;
            }

            if (despawn)
            {
                if (Main.netMode != NetmodeID.Server)
                {
                    DisappearEffects(npc);
                }
                npc.active = false;
                npc.netSkip = -1;
                npc.life = 0;
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, npc.whoAmI);
                }
                return;
            }

            if (Main.netMode == NetmodeID.MultiplayerClient || shimmerPosition.X == -1 ||
                !helper)
            {
                return;
            }

            //Some monsters are spawning with different scales. Setting this after transforming monster, didn't work.
            npc.scale = 1f;

            if (!headToShimmer)
            {
                Player nearestPlayer = Main.player[Player.FindClosest(npc.Center, npc.width, npc.height)];
                headToShimmer = npc.Center.Distance(nearestPlayer.Center) <= 20 * 16;
            }

            if (!headToShimmer)
            {
                return;
            }

            float shimmerDistance = npc.Center.Distance(shimmerPosition);
            if (shimmerDistance < speed)
            {
                shimmerDistance = 0;
                npc.Center = shimmerPosition;
            }
            else
            {
                speed += 8f / 60f;
                npc.velocity = npc.Center.DirectionTo(shimmerPosition) * speed;
            }

            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, npc.whoAmI);
            }

            if (shimmerDistance != 0)
            {
                return;
            }

            despawn = true;
            if (Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = Mod.GetPacket();
                packet.Write((byte)ReducedGrinding.MessageType.FaelingHelperDespawn);
                packet.Write(npc.whoAmI);
                packet.Write(despawn);
                packet.Send();
            }
        }

        private static void DisappearEffects(NPC npc)
        {
            SoundEngine.PlaySound(SoundID.Item4, npc.position);

            Color value = new(153, 109, 233);
            Color value2 = new(190, 172, 252);
            int num = 4;
            for (int i = 0; i < 40; i++)
            {
                float[] colors = [1f, Main.rand.NextFloat(0.5f, 1f), 0.5f];
                Random.Shared.Shuffle(colors);
                Color color = new(colors[0], colors[1], colors[2]);

                Dust dust = Dust.NewDustDirect(npc.position - new Vector2(num) * 0.5f, num + 4, num + 4, DustID.FireworksRGB, 0f, 0f, 200, color, 0.65f);
                dust.velocity *= 1.5f;
                if (i >= 30)
                {
                    dust.velocity *= 3.5f;
                }
                else if (i >= 20)
                {
                    dust.velocity *= 2f;
                }
                dust.fadeIn = Main.rand.Next(0, 17) * 0.1f;
                dust.noGravity = true;
            }
        }

        public override void OnSpawn(NPC npc, IEntitySource source)
        {
            if (otherConfig.FaelingHelperLimit == 0 || otherConfig.FaelingHelperRange == 0f)
            {
                return;
            }

            if (shimmerFound || shimmerPosition.X == -1 ||
                npc.type == NPCID.Shimmerfly ||
                !npc.CountsAsACritter ||
                npc.position.Y < (Main.worldSurface * 16))
            {
                return;
            }

            int shimmerFlies = 0;
            foreach (NPC searchNPC in Main.ActiveNPCs)
            {
                if (searchNPC.type == NPCID.Shimmerfly)
                {
                    shimmerFlies++;
                    if (shimmerFlies >= otherConfig.FaelingHelperLimit)
                    {
                        return;
                    }
                }
            }

            float distanceToShimmer = npc.Center.Distance(shimmerPosition);
            float faelingHelperRange = Main.maxTilesX * otherConfig.FaelingHelperRange * 16f;
            if (distanceToShimmer > faelingHelperRange)
            {
                return;
            }

            npc.Transform(NPCID.Shimmerfly);
            npc.catchItem = ItemID.None;
            npc.dontTakeDamage = true;
            FaelingHelper faelingHelper = npc.GetGlobalNPC<FaelingHelper>();
            faelingHelper.helper = true;
        }
    }

    public class FaelingHelperPlayer : ModPlayer
    {
        public override void PostUpdate()
        {
            if (Player.ZoneShimmer)
            {
                FaelingHelper.shimmerFound = true;
            }
        }
    }
}
