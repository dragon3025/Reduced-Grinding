using System;
using Terraria;
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

                int invasionType = Main.invasionType;

                bool awayFromInvasion = true;
                if (invasionType > 0 && Main.invasionDelay == 0 && Main.invasionSize > 0 && player.position.Y < Main.worldSurface * 16.0 + NPC.sHeight)
                {
                    int xExtends = 3000;
                    if (player.position.X > Main.invasionX * 16.0 - xExtends && player.position.X < Main.invasionX * 16.0 + xExtends)
                    {
                        awayFromInvasion = false;
                    }
                    else if (Main.invasionX >= Main.maxTilesX / 2 - 5 && Main.invasionX <= Main.maxTilesX / 2 + 5)
                    {
                        for (int k = 0; k < 200; k++)
                        {
                            if (Main.npc[k].townNPC && Math.Abs(player.position.X - Main.npc[k].Center.X) < xExtends)
                            {
                                if (!Main.rand.NextBool(3))
                                {
                                    awayFromInvasion = false;
                                }
                                break;
                            }
                        }
                    }
                }

                if (awayFromInvasion)
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
            }
        }
    }
}
