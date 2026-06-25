using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.Content.Items
{
    internal class CultMembershipCardInactive : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 48;
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
}
