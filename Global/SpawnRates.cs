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
                if (Main.invasionType == InvasionID.None)
                {
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
                }
                else if (GetInstance<HOtherModdedItemsConfig>().BattlePotionsAffectInvasions)
                {
                    int playerCount = 0;
                    for (int i = 0; i < 255; i++)
                    {
                        if (!Main.player[i].active)
                            continue;
                        playerCount++;
                    }
                    int buffEffect = 1;
                    if (player.FindBuffIndex(BuffType<Buffs.SuperBattle>()) != -1)
                        buffEffect *= 2;
                    if (player.FindBuffIndex(BuffType<Buffs.GreaterBattle>()) != -1)
                        buffEffect *= 2;
                    spawnRate = 20 / buffEffect;
                    maxSpawns = (40 + (int)(1.5f * playerCount)) * buffEffect;
                }
            }
        }
    }
}
