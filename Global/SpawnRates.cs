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
                    spawnRate = Math.Max(1, (int)(spawnRate / GetInstance<HOtherModdedItemsConfig>().BattlePotionConfig.SuperSpawnRate));
                    maxSpawns = (int)(maxSpawns * GetInstance<HOtherModdedItemsConfig>().BattlePotionConfig.SuperMax);
                }
                if (player.FindBuffIndex(BuffType<Buffs.GreaterBattle>()) != -1)
                {
                    spawnRate = Math.Max(1, (int)(spawnRate / GetInstance<HOtherModdedItemsConfig>().BattlePotionConfig.GreaterSpawnRate));
                    maxSpawns = (int)(maxSpawns * GetInstance<HOtherModdedItemsConfig>().BattlePotionConfig.GreaterMax);
                }
                if (player.FindBuffIndex(BuffID.Battle) != -1)
                {
                    if (GetInstance<HOtherModdedItemsConfig>().BattlePotionConfig.VanillaSpawnRate > 2)
                    {
                        spawnRate = Math.Max(1, (int)(spawnRate / GetInstance<HOtherModdedItemsConfig>().BattlePotionConfig.VanillaSpawnRate));
                    }
                    if (GetInstance<HOtherModdedItemsConfig>().BattlePotionConfig.VanillaMax > 2)
                    {
                        maxSpawns = (int)(maxSpawns * GetInstance<HOtherModdedItemsConfig>().BattlePotionConfig.VanillaMax);
                    }
                }
            }
        }
    }
}
