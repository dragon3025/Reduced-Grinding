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
                    return;

                int invasionType = Main.invasionType;

                bool awayFromInvasion = true;
                if (invasionType > 0 && Main.invasionDelay == 0 && Main.invasionSize > 0 && player.position.Y < Main.worldSurface * 16.0 + NPC.sHeight)
                {
                    int num8 = 3000;
                    if (player.position.X > Main.invasionX * 16.0 - num8 && player.position.X < Main.invasionX * 16.0 + num8)
                    {
                        awayFromInvasion = false;
                    }
                    else if (Main.invasionX >= Main.maxTilesX / 2 - 5 && Main.invasionX <= Main.maxTilesX / 2 + 5)
                    {
                        for (int k = 0; k < 200; k++)
                        {
                            if (Main.npc[k].townNPC && Math.Abs(player.position.X - Main.npc[k].Center.X) < num8)
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
                else
                {
                    int BattlePotionsAffectInvasions = GetInstance<HOtherModdedItemsConfig>().BattlePotionsAffectInvasions;
                    bool useInvasionBuffing = false;

                    if (BattlePotionsAffectInvasions > 1 && invasionType != InvasionID.None)
                    {

                        if (BattlePotionsAffectInvasions == 2)
                            useInvasionBuffing = true;
                        else if (invasionType == InvasionID.PirateInvasion || invasionType == InvasionID.GoblinArmy || invasionType == InvasionID.MartianMadness || invasionType == InvasionID.SnowLegion)
                            useInvasionBuffing = true;
                    }

                    if (useInvasionBuffing)
                    {
                        int buffEffect = 1;
                        if (player.FindBuffIndex(BuffType<Buffs.SuperBattle>()) != -1)
                            buffEffect *= 2;
                        if (player.FindBuffIndex(BuffType<Buffs.GreaterBattle>()) != -1)
                            buffEffect *= 2;
                        maxSpawns *= buffEffect;
                        spawnRate = Math.Max(1, spawnRate / buffEffect);
                    }
                }
            }
        }
    }
}
