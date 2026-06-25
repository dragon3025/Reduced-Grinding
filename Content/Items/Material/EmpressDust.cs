using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Content.Items.Material
{
    public class EmpressDust : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(10, 6));
            ItemID.Sets.AnimatesAsSoul[Type] = true;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 14;
            Item.maxStack = Item.CommonMaxStack;
            Item.value = Item.sellPrice(0, 0, 50);
            Item.rare = ItemRarityID.Yellow;
        }

        public override void PostUpdate()
        {
            if (Main.rand.NextBool(6))
            {
                float lerp = Main.rand.NextFloat();

                Color color = Main.rand.Next(5) switch //Colors are the color values from 5 pixels in Images/Extra_156, in taken evenly.
                {
                    0 => Color.Lerp(new Color(207, 0, 151), new Color(254, 169, 151), lerp),
                    1 => Color.Lerp(new Color(254, 169, 151), new Color(92, 255, 219), lerp),
                    2 => Color.Lerp(new Color(92, 255, 219), new Color(1, 217, 255), lerp),
                    3 => Color.Lerp(new Color(1, 217, 255), new Color(94, 112, 232), lerp),
                    _ => Color.Lerp(new Color(94, 112, 232), new Color(207, 0, 151), lerp),
                };

                Dust dust = Dust.NewDustDirect(Item.position, Item.width, Item.height, DustID.FireworksRGB, 0f, 0f, 200, color, 0.65f);
                dust.velocity *= 0.3f;// 1.5f;
                dust.noGravity = true;
                dust.scale = 0.5f;
                dust.alpha = 3 * 255 / 4;
            }
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 50); // Makes this item render at full brightness.
        }
    }

    public class EmpressDustNPC : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.HallowBoss && Helpers.MaterialIsNeeded(ItemType<EmpressDust>());
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            CommonDrop ruleForNormalMode = new(ItemType<EmpressDust>(), 1, 10, 20);
            DropNothing ruleForExpertMode = new();
            npcLoot.Add(new DropBasedOnExpertMode(ruleForNormalMode, ruleForExpertMode));
        }
    }

    public class EmpressDustItem : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == ItemID.FairyQueenBossBag && Helpers.MaterialIsNeeded(ItemType<EmpressDust>());
        }

        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            itemLoot.Add(new CommonDrop(ItemType<EmpressDust>(), 1, 15, 25));
        }
    }
}