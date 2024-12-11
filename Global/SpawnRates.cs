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

                float vanillaSpawnRate = otherModdedItemsConfig.BattlePotion.SuperSpawnRate;
                float vanillaMax = otherModdedItemsConfig.BattlePotion.SuperMax;

                float greaterSpawnRate = float.Max(vanillaSpawnRate, otherModdedItemsConfig.BattlePotion.GreaterSpawnRate);
                float greaterMax = float.Max(vanillaMax,  otherModdedItemsConfig.BattlePotion.GreaterMax);

                float superSpawnRate = float.Max(greaterSpawnRate, otherModdedItemsConfig.BattlePotion.SuperSpawnRate);
                float superMax = float.Max(greaterMax, otherModdedItemsConfig.BattlePotion.SuperMax);

                spawnRate = spawnRate *= 2; //Undo Vanilla Rates before setting new rates.

                if (player.buffTime[buffIndex] > 50400) //14 minutes
                {
                    spawnRate = Math.Max(1, (int)(spawnRate / superSpawnRate));
                    maxSpawns = (int)(maxSpawns * superMax);
                }
                else if (player.buffTime[buffIndex] > 25200) //7 minutes
                {
                    spawnRate = Math.Max(1, (int)(spawnRate / greaterSpawnRate));
                    maxSpawns = (int)(maxSpawns * greaterMax);
                }
                else
                {
                    spawnRate = Math.Max(1, (int)(spawnRate / vanillaSpawnRate));
                    maxSpawns = (int)(maxSpawns * vanillaMax);
                }

                maxSpawns = Math.Max(1, (int)(maxSpawns / 2)); //Undo Vanilla Max
            }
        }
    }
}
