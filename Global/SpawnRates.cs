using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Global
{
    public class SpawnRates : GlobalNPC
    {
        class SpawnRateMultiplierGlobalNPC : GlobalNPC
        {
            public override void EditSpawnRate(Terraria.Player player, ref int spawnRate, ref int maxSpawns)
            {
                if (player.FindBuffIndex(BuffType<Buffs.GreaterBattle>()) != -1)
                {
                    spawnRate = (int)(spawnRate / GetInstance<HOtherModdedItemsConfig>().GreaterBattlePotionSpawnrateMultiplier);
                    maxSpawns = (int)(maxSpawns * GetInstance<HOtherModdedItemsConfig>().GreaterBattlePotionMaxSpawnsMultiplier);
                }
                if (player.FindBuffIndex(BuffType<Buffs.SuperBattle>()) != -1)
                {
                    spawnRate = (int)(spawnRate / GetInstance<HOtherModdedItemsConfig>().SuperBattlePotionSpawnrateMultiplier);
                    maxSpawns = (int)(maxSpawns * GetInstance<HOtherModdedItemsConfig>().SuperBattlePotionMaxSpawnsMultiplier);
                }
            }
        }
    }
}
