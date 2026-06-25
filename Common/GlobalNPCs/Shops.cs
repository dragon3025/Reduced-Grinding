using ReducedGrinding.Configuration;
using ReducedGrinding.Content.Items.Consumable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalNPCs
{
    public class Shops : GlobalNPC
    {
        private static readonly VillagersAndEnemiesConfig villagersAndEnemiesConfig = GetInstance<VillagersAndEnemiesConfig>();

        public override void ModifyShop(NPCShop shop)
        {
            switch (shop.NpcType)
            {
                case NPCID.WitchDoctor:
                    if (villagersAndEnemiesConfig.WitchDoctorSellsChlorophyteOre)
                    {
                        shop.Add(ItemID.ChlorophyteOre, Condition.InJungle, Condition.DownedPlantera);
                    }
                    break;
                case NPCID.Dryad:
                    if (!GetInstance<LimitedItemsConfig>().DryadSellsOppositeEvilPlanter)
                    {
                        break;
                    }
                    if (WorldGen.crimson)
                    {
                        shop.Add(ItemID.CorruptPlanterBox, Condition.InGraveyard, Condition.Hardmode);
                    }
                    else
                    {
                        shop.Add(ItemID.CrimsonPlanterBox, Condition.InGraveyard, Condition.Hardmode);
                    }
                    break;
                case NPCID.Merchant:
                    if (!villagersAndEnemiesConfig.NameTag)
                    {
                        break;
                    }
                    shop.Add(ItemType<NameTag>());
                    break;
                default:
                    break;
            }
        }

        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            if (npc.type != NPCID.BestiaryGirl)
            {
                return;
            }

            float bestiaryRateRequired = villagersAndEnemiesConfig.UniPylonBestiaryCompletionRate;
            if (bestiaryRateRequired >= 1f)
            {
                return;
            }

            float bestiaryRate = Main.GetBestiaryProgressReport().CompletionPercent;
            if (bestiaryRate < bestiaryRateRequired)
            {
                return;
            }

            foreach (Item item in items)
            {
                if (item == null)
                {
                    continue;
                }
                if (item.type == ItemID.TeleportationPylonVictory)
                {
                    return;
                }
            }

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    items[i] = new Item();
                }
                if (items[i].type == ItemID.None)
                {
                    items[i].SetDefaults(ItemID.TeleportationPylonVictory);
                    break;
                }
            }
        }
    }
}