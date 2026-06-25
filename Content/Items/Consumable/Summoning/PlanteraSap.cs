using ReducedGrinding.Configuration;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Items.Consumable.Summoning
{
    public class PlanteraSap : ModItem
    {
        public override void SetStaticDefaults()
        {
            NPCID.Sets.MPAllowedEnemies[NPCID.Plantera] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SuspiciousLookingEye);
            Item.width = 20;
            Item.height = 24;
            Item.rare = ItemRarityID.Lime;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ZoneJungle &&
                Main.hardMode &&
                NPC.downedMechBoss1 &&
                NPC.downedMechBoss2 &&
                NPC.downedMechBoss3 &&
                !NPC.AnyNPCs(NPCID.Plantera);
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                SoundEngine.PlaySound(SoundID.Roar, player.position);

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    NPC.SpawnOnPlayer(player.whoAmI, NPCID.Plantera);
                }
                else
                {
                    NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, number: player.whoAmI, number2: NPCID.Plantera);
                }
            }

            return true;
        }
    }

    public class PlanteraSapNPC : GlobalNPC
    {
        private static readonly int planteraSapFromPlantera = GetInstance<EventAndBossConfig>().PlanteraSapFromPlantera;

        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.Plantera && planteraSapFromPlantera > 0;
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            //Don't drop from boss bag; we only want to drop 1 boss summoning item.
            npcLoot.Add(new CommonDrop(ItemType<PlanteraSap>(), planteraSapFromPlantera));
        }
    }
}