using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.GlobalFasterBossSummons
{
    public class Shimmer : GlobalItem
    {
        readonly static AEnemyLootConfig lootConfig = GetInstance<AEnemyLootConfig>();

        public override void SetDefaults(Item item)
        {
            void SetTwoItemsToShimmerIntoEachOther(int item01, int item02)
            {
                if (item.type == item01)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = item02;
                }
                else if (item.type == item02)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = item01;
                }
            }
            void SetThreeItemsToShimmerIntoEachOther(int item01, int item02, int item03)
            {
                if (item.type == item01)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = item02;
                }
                else if (item.type == item02)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = item03;
                }
                else if (item.type == item03)
                {
                    ItemID.Sets.ShimmerTransformToItem[item.type] = item01;
                }
            }

            if (item.type == ItemID.LeafWand)
            {
                ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.SunflowerMinecart;
            }

            SetTwoItemsToShimmerIntoEachOther(ItemID.LadybugMinecart, ItemID.SunflowerMinecart);

            if (GetInstance<IOtherConfig>().CraftableRareChests)
            {
                SetTwoItemsToShimmerIntoEachOther(ItemID.ShadowChest, ItemID.ShadowKey);
            }

            SetThreeItemsToShimmerIntoEachOther(ItemID.BlueDungeonBathtub, ItemID.GreenDungeonBathtub, ItemID.PinkDungeonBathtub);
            SetThreeItemsToShimmerIntoEachOther(ItemID.BlueDungeonBed, ItemID.GreenDungeonBed, ItemID.PinkDungeonBed);
            SetThreeItemsToShimmerIntoEachOther(ItemID.BlueDungeonBookcase, ItemID.GreenDungeonBookcase, ItemID.PinkDungeonBookcase);
            SetThreeItemsToShimmerIntoEachOther(ItemID.BlueDungeonCandelabra, ItemID.GreenDungeonCandelabra, ItemID.PinkDungeonCandelabra);
            SetThreeItemsToShimmerIntoEachOther(ItemID.BlueDungeonCandle, ItemID.GreenDungeonCandle, ItemID.PinkDungeonCandle);
            SetThreeItemsToShimmerIntoEachOther(ItemID.BlueDungeonChair, ItemID.GreenDungeonChair, ItemID.PinkDungeonChair);
            SetThreeItemsToShimmerIntoEachOther(ItemID.BlueDungeonChandelier, ItemID.GreenDungeonChandelier, ItemID.PinkDungeonChandelier);
            SetThreeItemsToShimmerIntoEachOther(ItemID.DungeonClockBlue, ItemID.DungeonClockGreen, ItemID.DungeonClockPink);
            SetThreeItemsToShimmerIntoEachOther(ItemID.BlueDungeonDoor, ItemID.GreenDungeonDoor, ItemID.PinkDungeonDoor);
            SetThreeItemsToShimmerIntoEachOther(ItemID.BlueDungeonDresser, ItemID.GreenDungeonDresser, ItemID.PinkDungeonDresser);
            SetThreeItemsToShimmerIntoEachOther(ItemID.BlueDungeonLamp, ItemID.GreenDungeonLamp, ItemID.PinkDungeonLamp);
            SetThreeItemsToShimmerIntoEachOther(ItemID.BlueDungeonPiano, ItemID.GreenDungeonPiano, ItemID.PinkDungeonPiano);
            SetThreeItemsToShimmerIntoEachOther(ItemID.BlueDungeonSofa, ItemID.GreenDungeonSofa, ItemID.PinkDungeonSofa);
            SetThreeItemsToShimmerIntoEachOther(ItemID.BlueDungeonTable, ItemID.GreenDungeonTable, ItemID.PinkDungeonTable);
            SetThreeItemsToShimmerIntoEachOther(ItemID.BlueDungeonVase, ItemID.GreenDungeonVase, ItemID.PinkDungeonVase);
            SetThreeItemsToShimmerIntoEachOther(ItemID.BlueDungeonWorkBench, ItemID.GreenDungeonWorkBench, ItemID.PinkDungeonWorkBench);
        }
    }
}
