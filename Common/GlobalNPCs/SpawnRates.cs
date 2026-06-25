using ReducedGrinding.Common.ModPlayers;
using ReducedGrinding.Configuration;
using ReducedGrinding.Content.Items.Consumable;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalNPCs
{
    public class SpawnRates : GlobalNPC
    {
        private static readonly BattlePotionConfig battlePotion = GetInstance<BattlePotionConfig>();

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (WarStandardSystem.frozenProgress == 0 && Main.invasionType != InvasionID.None)
            {
                return;
            }

            int buffIndex = player.FindBuffIndex(BuffID.Battle);
            if (buffIndex == -1)
            {
                return;
            }

            if (player.townNPCs >= 1f && !NPC.unlockedPrincessSpawn && battlePotion.TownsRequireAllVillagersUnlocked)
            {
                return;
            }

            float newRate = player.GetModPlayer<BattleBuffTiers>().battleBuffTier switch
            {
                3 => battlePotion.SuperSpawnRate,
                2 => battlePotion.GreaterSpawnRate,
                _ => battlePotion.VanillaSpawnRate,
            };

            //Undo Vanilla Battlebuff spawnRate change before making new changes.
            spawnRate *= 2;

            spawnRate = Math.Max(1, (int)(spawnRate / newRate));
            maxSpawns = (int)(maxSpawns * newRate);

            //Undo Vanilla Battlebuff maxSpawns changes after new changes.
            maxSpawns = Math.Max(1, maxSpawns / 2);
        }
    }
}
