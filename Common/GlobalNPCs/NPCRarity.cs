using ReducedGrinding.Configuration;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalNPCs
{
    public class NPCRarity : GlobalNPC
    {
        public override void AI(NPC npc)
        {
            if (!GetInstance<OtherConfig>().ConvenientNPCRarity ||
                npc.type != NPCID.LostGirl &&
                npc.type != NPCID.Nymph &&
                npc.type != NPCID.SkeletonMerchant)
            {
                return;
            }

            if (npc.type == NPCID.SkeletonMerchant)
            {
                npc.rarity = 1;
                if (Main.moonPhase >= 3 && Main.moonPhase <= 5)
                {
                    foreach (Player player in Main.ActivePlayers)
                    {
                        if (!player.ateArtisanBread)
                        {
                            npc.rarity = 3;
                            return;
                        }
                    }
                }
                if (Main.moonPhase == 7) //Radar
                {
                    foreach (Player player in Main.ActivePlayers)
                    {
                        if (!player.accThirdEye)
                        {
                            npc.rarity = 3;
                            return;
                        }
                    }
                }
                return;
            }

            npc.rarity = 2;
            foreach (Player player in Main.ActivePlayers)
            {
                if (!player.accOreFinder) //Metal Detector
                {
                    npc.rarity = 6;
                    return;
                }
            }
        }
    }
}
