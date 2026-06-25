using ReducedGrinding.Configuration;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalItems
{
    public class AmberMosquito : GlobalItem
    {
        private static readonly OtherConfig otherConfig = GetInstance<OtherConfig>();

        public override void ExtractinatorUse(int extractType, int extractinatorBlockType, ref int resultType, ref int resultStack)
        {
            if (resultType == ItemID.AmberMosquito || resultType == ItemID.DesertFossil || otherConfig.AmberMosquitoChance == 0)
            {
                return;
            }

            if (extractType == ItemID.DesertFossil)
            {
                if (Main.rand.NextBool(otherConfig.AmberMosquitoChance))
                {
                    resultType = ItemID.AmberMosquito;
                    resultStack = 1;
                }
            }
        }
    }
}
