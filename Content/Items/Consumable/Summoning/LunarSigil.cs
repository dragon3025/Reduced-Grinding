using ReducedGrinding.Common.ModSystems;
using ReducedGrinding.Configuration;
using ReducedGrinding.Content.Items.Material;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Items.Consumable.Summoning
{
    public class LunarSigil : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.CelestialSigil);
            Item.UseSound = SoundID.Roar;
        }

        public override bool CanUseItem(Player player)
        {
            return !LunarInvasion.lunarApocalypseIsUp && !LunarInvasion.moonLordCountdownRunning;
        }

        public override bool? UseItem(Player player)
        {
            List<NPC> npcsToSpawnDust = [];

            foreach (NPC npc in Main.ActiveNPCs)
            {
                if (npc.type == NPCID.CultistTablet || npc.type == NPCID.CultistDevote || npc.type == NPCID.CultistArcherBlue)
                {
                    npcsToSpawnDust.Add(npc);
                }
            }

            if (Main.netMode != NetmodeID.Server)
            {
                foreach (NPC npc in npcsToSpawnDust)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Dust.NewDust(npc.position, npc.width, npc.height, DustID.MagicMirror, 0, 0, 150, default, 1.5f);
                    }
                }
            }

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return true;
            }

            LunarSigilSystem.npcsToRemove = npcsToSpawnDust;
            LunarSigilSystem.activated = 2; //Give some time for players to spawn dust
            return true;
        }

        public override void AddRecipes()
        {
            if (GetInstance<EventAndBossConfig>().LunarSigil > 0)
            {
                Recipe recipe = Recipe.Create(Type);
                recipe.AddIngredient(ItemType<LunarTablet>());
                recipe.AddIngredient(ItemID.FragmentNebula);
                recipe.AddIngredient(ItemID.FragmentSolar);
                recipe.AddIngredient(ItemID.FragmentStardust);
                recipe.AddIngredient(ItemID.FragmentVortex);
                recipe.AddIngredient(ItemID.LunarOre);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.Register();
            }
        }
    }

    public class LunarSigilSystem : ModSystem
    {
        internal static List<NPC> npcsToRemove = [];
        internal static int activated;

        public override void PostUpdateTime()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient || activated < 1)
            {
                return;
            }
            activated--;
            if (activated > 0)
            {
                return;
            }

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
            WorldGen.TriggerLunarApocalypse();
            LunarInvasion.UpdateStatus();
        }
    }
}