using ReducedGrinding.Configuration;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class SpawnRates : GlobalNPC
    {
        readonly static HOtherModdedItemsConfig otherModdedItemsConfig = GetInstance<HOtherModdedItemsConfig>();

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

                int buffIndex = player.FindBuffIndex(BuffID.Battle);
                if (buffIndex == -1)
                {
                    return;
                }

                int preSpawnRate = spawnRate;
                int preMaxSpawns = maxSpawns;

                spawnRate = spawnRate *= 2; //Undo Vanilla Rates before setting new rates.

                if (player.buffTime[buffIndex] > 50400) //14 minutes
                {
                    spawnRate = Math.Max(1, (int)(spawnRate / otherModdedItemsConfig.BattlePotion.SuperSpawnRate));
                    maxSpawns = (int)(maxSpawns * otherModdedItemsConfig.BattlePotion.SuperMax);
                }
                else if (player.buffTime[buffIndex] > 25200) //7 minutes
                {
                    spawnRate = Math.Max(1, (int)(spawnRate / otherModdedItemsConfig.BattlePotion.GreaterSpawnRate));
                    maxSpawns = (int)(maxSpawns * otherModdedItemsConfig.BattlePotion.GreaterMax);
                }
                else
                {
                    spawnRate = Math.Max(1, (int)(spawnRate / otherModdedItemsConfig.BattlePotion.VanillaSpawnRate));
                    maxSpawns = (int)(maxSpawns * otherModdedItemsConfig.BattlePotion.VanillaMax);
                }

                maxSpawns = Math.Max(1, (int)(maxSpawns / 2)); //Undo Vanilla Max
            }
        }
    }
}
