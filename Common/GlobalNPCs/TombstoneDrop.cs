using ReducedGrinding.Configuration;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalNPCs
{
    public class TombstoneDrop : GlobalNPC
    {
        public override void OnKill(NPC npc)
        {
            if (!GetInstance<LimitedItemsConfig>().TombstonesDropFromNPCs
                || !npc.townNPC
                || npc.type == NPCID.OldMan
                || npc.type == NPCID.SkeletonMerchant)
            {
                return;
            }

            bool spawnTombstone = true;
            NetworkText fullNetName = npc.GetFullNetName();
            int langIndex = 19;
            if (npc.type == NPCID.Angler || npc.type == NPCID.Princess || NPCID.Sets.IsTownPet[npc.type])
            {
                langIndex = 36;
                spawnTombstone = false;
            }
            NetworkText networkText = NetworkText.FromKey(Lang.misc[langIndex].Key, fullNetName);
            if (spawnTombstone)
            {
                for (int l = 0; l < 255; l++)
                {
                    Player player = Main.player[l];
                    if (player != null && player.active && player.difficulty == PlayerDifficultyID.Hardcore)
                    {
                        spawnTombstone = false;
                        break;
                    }
                }
            }
            if (spawnTombstone)
            {
                npc.DropTombstoneTownNPC(networkText);
            }
        }
    }
}
