using Microsoft.Xna.Framework;
using ReducedGrinding.Common.ModSystems;
using ReducedGrinding.Configuration;
using System.Collections.Generic;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Items.Consumable
{
    public class CelestialWard : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.CelestialSigil);
            Item.UseSound = SoundID.Item4;
        }

        public override bool CanUseItem(Player player)
        {
            return LunarInvasion.lunarApocalypseIsUp || LunarInvasion.moonLordCountdownRunning;
        }

        public override bool? UseItem(Player player)
        {
            List<NPC> npcsToSpawnDust = [];
            foreach (NPC npc in Main.ActiveNPCs)
            {
                if (npc.type == NPCID.LunarTowerNebula
                    || npc.type == NPCID.LunarTowerSolar
                    || npc.type == NPCID.LunarTowerStardust
                    || npc.type == NPCID.LunarTowerVortex)
                {
                    npcsToSpawnDust.Add(npc);
                }
            }

            if (Main.netMode != NetmodeID.Server)
            {
                foreach (NPC npc in npcsToSpawnDust)
                {
                    for (int i = 0; i < 300; i++)
                    {
                        Dust.NewDust(npc.position, npc.width, npc.height, DustID.MagicMirror, 0, 0, 150, default, 1.5f);
                    }
                }
            }

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return true;
            }

            CelestialWardSystem.activated = 2; //Give some time for players to spawn dust
            CelestialWardSystem.npcsToRemove = npcsToSpawnDust;
            return true;
        }

        public override void AddRecipes()
        {
            if (!GetInstance<EventAndBossConfig>().CelestialWard)
            {
                return;
            }
            Recipe recipe = Recipe.Create(Type);
            recipe.AddIngredient(ItemID.CelestialSigil);
            recipe.AddIngredient(ItemID.ShimmerBlock);
            recipe.AddIngredient(ItemID.LunarOre);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }

    public class CelestialWardSystem : ModSystem
    {
        internal static List<NPC> npcsToRemove = [];
        internal static int activated;

        public override void PostUpdateTime()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }
            if (activated <= 0)
            {
                LunarInvasion.UpdateStatus();
                return;
            }
            activated--;
            if (activated >= 1)
            {
                LunarInvasion.UpdateStatus();
                return;
            }

            if (NPC.LunarApocalypseIsUp)
            {
                foreach (NPC npc in npcsToRemove)
                {
                    npc.active = false;
                    npc.life = 0;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.SyncNPC, number: npc.whoAmI);
                    }
                }
                npcsToRemove.Clear();

                foreach (Projectile projectile in Main.ActiveProjectiles)
                {
                    if (projectile.type != ProjectileID.TowerDamageBolt)
                    {
                        projectile.active = false; //Prevent index out of range error.
                    }
                }

                NPC.ShieldStrengthTowerNebula = NPC.ShieldStrengthTowerSolar = NPC.ShieldStrengthTowerStardust = NPC.ShieldStrengthTowerVortex = 0;
                NPC.LunarApocalypseIsUp = NPC.TowerActiveNebula = NPC.TowerActiveSolar = NPC.TowerActiveStardust = NPC.TowerActiveVortex = false;

                LunarInvasion.UpdateStatus();

                string message = ReducedGrinding.GetText("Misc.CelestialWard.Pillars");
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText(message, 175, 75, 255);
                }
                else
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey(message), new Color(175, 75, 255));
                }
            }
            if (NPC.MoonLordCountdown > 0)
            {
                NPC.MoonLordCountdown = 0;
                LunarInvasion.UpdateStatus();
                string message = ReducedGrinding.GetText("Misc.CelestialWard.MoonLord");
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText(message, 50, 255, 130);
                }
                else
                {
                    NetMessage.SendData(MessageID.MoonlordHorror);
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey(message), new Color(50, 255, 130));
                }
            }
            LunarInvasion.UpdateStatus();
        }
    }
}
