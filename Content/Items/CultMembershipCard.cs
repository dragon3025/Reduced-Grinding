using ReducedGrinding.Configuration;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Items
{
    internal class CultMembershipCard : ModItem
    {
        public override void SetStaticDefaults()
        {
            ContentSamples.AddItemResearchOverride(Type, ItemType<CultMembershipCardInactive>());
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 28;
            Item.maxStack = Item.CommonMaxStack;
            Item.value = 0;
            Item.rare = ItemRarityID.Red;
        }

        public override void RightClick(Player player)
        {
            CultMembershipCardPlayer.Toggle(player, Item);
        }

        public override bool CanRightClick()
        {
            return Item.stack == 1;
        }

        public override bool ConsumeItem(Player player)
        {
            return false;
        }

        public override bool AltFunctionUse(Player player)
        {
            SoundEngine.PlaySound(SoundID.Grab);
            CultMembershipCardPlayer.Toggle(player, Item);
            return true;
        }
    }

    public class CultMembershipCardNPC : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.CultistArcherBlue || entity.type == NPCID.CultistDevote || entity.type == NPCID.CultistBoss;
        }

        public override void AI(NPC npc)
        {
            if (npc.type == NPCID.CultistBoss)
            {
                return;
            }
            foreach (Player player in Main.ActivePlayers)
            {
                if (player.HasItemInInventoryOrOpenVoidBag(ItemType<CultMembershipCard>())
                    && Math.Abs(player.position.X - npc.position.X) < 169f / 2 * 16
                    && Math.Abs(player.position.Y - npc.position.Y) < 124f / 2 * 16)
                {
                    npc.dontTakeDamage = true;
                    return;
                }
            }
            npc.dontTakeDamage = false;
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type != NPCID.CultistBoss || !GetInstance<VillagersAndEnemiesConfig>().CultMembershipCard)
            {
                return;
            }
            //Cultist doesn't drop a boss bag
            npcLoot.Add(new CommonDropNotScalingWithLuck(ItemType<CultMembershipCard>(), 1, 1, 1));
        }
    }

    public class CultMembershipCardPlayer : ModPlayer
    {
        internal static void Toggle(Player player, Item item)
        {
            player.releaseUseTile = false;
            Main.mouseRightRelease = false;
            int stack = item.stack; //In 1.4.5+, the stack is transfered.
            if (item.type == ItemType<CultMembershipCard>())
            {
                item.ChangeItemType(ItemType<CultMembershipCardInactive>());
            }
            else
            {
                item.ChangeItemType(ItemType<CultMembershipCard>());
            }
            item.stack = stack;
            Recipe.FindRecipes(); //Not needed in 1.4.5+
        }
    }
}
