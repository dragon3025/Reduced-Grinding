using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class SpawnRates : GlobalNPC
    {
        class SpawnRateMultiplierGlobalNPC : GlobalNPC
        {
            public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
            {
                if (!player.active)
                {
                    return;
                }

                if (Main.invasionType > 0 || NPC.waveNumber > 0)
                {
                    return;
                }

                if (player.FindBuffIndex(BuffType<Buffs.SuperBattle>()) != -1)
                {
                    spawnRate = Math.Max(1, (int)(spawnRate / GetInstance<HOtherModdedItemsConfig>().SuperBattlePotionSpawnrateMultiplier));
                    maxSpawns = (int)(maxSpawns * GetInstance<HOtherModdedItemsConfig>().SuperBattlePotionMaxSpawnsMultiplier);
                }
                if (player.FindBuffIndex(BuffType<Buffs.GreaterBattle>()) != -1)
                {
                    spawnRate = Math.Max(1, (int)(spawnRate / GetInstance<HOtherModdedItemsConfig>().GreaterBattlePotionSpawnrateMultiplier));
                    maxSpawns = (int)(maxSpawns * GetInstance<HOtherModdedItemsConfig>().GreaterBattlePotionMaxSpawnsMultiplier);
                }
                if (player.FindBuffIndex(BuffID.Battle) != -1)
                {
                    if (GetInstance<HOtherModdedItemsConfig>().BattlePotionSpawnrateMultiplier > 2)
                    {
                        spawnRate = Math.Max(1, (int)(spawnRate / GetInstance<HOtherModdedItemsConfig>().BattlePotionSpawnrateMultiplier));
                    }
                    if (GetInstance<HOtherModdedItemsConfig>().BattlePotionMaxSpawnsMultiplier > 2)
                    {
                        maxSpawns = (int)(maxSpawns * GetInstance<HOtherModdedItemsConfig>().BattlePotionMaxSpawnsMultiplier);
                    }
                }
            }
        }
    }
}
