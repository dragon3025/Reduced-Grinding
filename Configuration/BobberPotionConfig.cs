using ReducedGrinding.Content.Items.Material;
using System;
using System.ComponentModel;
using Terraria.ID;
using Terraria.ModLoader.Config;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Configuration
{
    public class BobberPotionConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("BobberPotions")]

        [Range(1, 1000)]
        [DefaultValue(2)]
        public int BobberPotionBonus
        {
            get
            {
                field = Math.Min(field, Math.Min(GreaterBobberPotionBonus, SuperBobberPotionBonus));
                return field;
            }
            set
            {
                GreaterBobberPotionBonus = Math.Max(value, GreaterBobberPotionBonus);
                SuperBobberPotionBonus = Math.Max(GreaterBobberPotionBonus, SuperBobberPotionBonus);
                field = value;
            }
        }

        [ReloadRequired]
        public ItemDefinition BobberPotionIngredient { get; set; }

        [ReloadRequired]
        public ItemDefinition BobberPotionAlternateIngredient { get; set; }

        [Header("GreaterBobberPotion")]

        [Range(1, 1000)]
        [DefaultValue(4)]
        public int GreaterBobberPotionBonus
        {
            get
            {
                field = Math.Min(field, SuperBobberPotionBonus);
                return field;
            }
            set
            {
                SuperBobberPotionBonus = Math.Max(value, SuperBobberPotionBonus);
                field = value;
            }
        }

        [ReloadRequired]
        public ItemDefinition GreaterBobberPotionIngredient { get; set; }

        [ReloadRequired]
        public ItemDefinition GreaterBobberPotionAlternateIngredient { get; set; }

        [Header("SuperBobberPotion")]

        [Range(1, 1000)]
        [DefaultValue(9)]
        public int SuperBobberPotionBonus { get; set; }

        [ReloadRequired]
        public ItemDefinition SuperBobberPotionIngredient { get; set; }

        [ReloadRequired]
        public ItemDefinition SuperBobberPotionAlternateIngredient { get; set; }

        public BobberPotionConfig()
        {
            BobberPotionIngredient = new(ItemID.ChlorophyteOre);
            BobberPotionAlternateIngredient = new(ItemID.None);
            GreaterBobberPotionIngredient = new(ItemType<EmpressDust>());
            GreaterBobberPotionAlternateIngredient = new(ItemID.None);
            SuperBobberPotionIngredient = new(ItemID.LunarOre);
            SuperBobberPotionAlternateIngredient = new(ItemID.None);
        }
    }
}
