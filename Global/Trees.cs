using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.GlobalTrees
{
    public sealed class ReducedGrindingTrees : GlobalItem
	{
		public override void OnSpawn(Item item, IEntitySource source) {
			if (source is EntitySource_ShakeTree)
			{
				if (GetInstance<IOtherConfig>().FinchStaffFromTreeShaking > 0)
				{
					if (Main.rand.NextBool(GetInstance<IOtherConfig>().FinchStaffFromTreeShaking))
					{
						var newSource = item.GetSource_FromThis();
						Item.NewItem(newSource, item.Center, ItemID.BabyBirdStaff);
					}
				}
			}
		}
	}
}
