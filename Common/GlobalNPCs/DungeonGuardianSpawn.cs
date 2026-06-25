using ReducedGrinding.Content.Items;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalNPCs
{
    public class DungeonGuardianSpawn : GlobalNPC
    {
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if (!spawnInfo.Player.ZoneDungeon || !spawnInfo.Player.HasItemInInventoryOrOpenVoidBag(ItemType<OldManVoodooDoll>()))
            {
                return;
            }

            pool.Clear();
            pool.Add(new KeyValuePair<int, float>(NPCID.DungeonGuardian, 1));
        }
    }
}
