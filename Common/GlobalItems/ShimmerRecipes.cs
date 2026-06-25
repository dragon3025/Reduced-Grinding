using ReducedGrinding.Configuration;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.GlobalItems
{
    public class ShimmerRecipes : GlobalItem
    {
        private static readonly CraftingConfig craftingConfig = GetInstance<CraftingConfig>();
        private static readonly LimitedItemsConfig limitedItemsConfig = GetInstance<LimitedItemsConfig>();
        private static readonly AnglerConfig anglerConfig = GetInstance<AnglerConfig>();
        public static bool EvilBiomeMimicCounterpartModEnabled;

        public override void SetDefaults(Item item)
        {
            void ShimmerLoopWithTwo(int item01, int item02)
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
            void ShimmerLoopWithThree(int item01, int item02, int item03)
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

            if (limitedItemsConfig.CraftableRareChests)
            {
                ShimmerLoopWithTwo(ItemID.ShadowChest, ItemID.ShadowKey);
            }

            if (anglerConfig.ShimmerHoneyRewards)
            {
                ShimmerLoopWithTwo(ItemID.HoneyAbsorbantSponge, ItemID.BottomlessHoneyBucket);
            }

            //In 1.4.5, these already have a Shimmer loop
            ItemID.Sets.ShimmerTransformToItem[ItemID.FlameTrap] = ItemID.SpearTrap;
            ItemID.Sets.ShimmerTransformToItem[ItemID.SpearTrap] = ItemID.SpikyBallTrap;
            ItemID.Sets.ShimmerTransformToItem[ItemID.SpikyBallTrap] = ItemID.SuperDartTrap;
            ItemID.Sets.ShimmerTransformToItem[ItemID.SuperDartTrap] = ItemID.FlameTrap;

            ShimmerLoopWithThree(ItemID.BlueDungeonBathtub, ItemID.GreenDungeonBathtub, ItemID.PinkDungeonBathtub);
            ShimmerLoopWithThree(ItemID.BlueDungeonBed, ItemID.GreenDungeonBed, ItemID.PinkDungeonBed);
            ShimmerLoopWithThree(ItemID.BlueDungeonBookcase, ItemID.GreenDungeonBookcase, ItemID.PinkDungeonBookcase);
            ShimmerLoopWithThree(ItemID.BlueDungeonCandelabra, ItemID.GreenDungeonCandelabra, ItemID.PinkDungeonCandelabra);
            ShimmerLoopWithThree(ItemID.BlueDungeonCandle, ItemID.GreenDungeonCandle, ItemID.PinkDungeonCandle);
            ShimmerLoopWithThree(ItemID.BlueDungeonChair, ItemID.GreenDungeonChair, ItemID.PinkDungeonChair);
            ShimmerLoopWithThree(ItemID.BlueDungeonChandelier, ItemID.GreenDungeonChandelier, ItemID.PinkDungeonChandelier);
            ShimmerLoopWithThree(ItemID.DungeonClockBlue, ItemID.DungeonClockGreen, ItemID.DungeonClockPink);
            ShimmerLoopWithThree(ItemID.BlueDungeonDoor, ItemID.GreenDungeonDoor, ItemID.PinkDungeonDoor);
            ShimmerLoopWithThree(ItemID.BlueDungeonDresser, ItemID.GreenDungeonDresser, ItemID.PinkDungeonDresser);
            ShimmerLoopWithThree(ItemID.BlueDungeonLamp, ItemID.GreenDungeonLamp, ItemID.PinkDungeonLamp);
            ShimmerLoopWithThree(ItemID.BlueDungeonPiano, ItemID.GreenDungeonPiano, ItemID.PinkDungeonPiano);
            ShimmerLoopWithThree(ItemID.BlueDungeonSofa, ItemID.GreenDungeonSofa, ItemID.PinkDungeonSofa);
            ShimmerLoopWithThree(ItemID.BlueDungeonTable, ItemID.GreenDungeonTable, ItemID.PinkDungeonTable);
            ShimmerLoopWithThree(ItemID.BlueDungeonVase, ItemID.GreenDungeonVase, ItemID.PinkDungeonVase);
            ShimmerLoopWithThree(ItemID.BlueDungeonWorkBench, ItemID.GreenDungeonWorkBench, ItemID.PinkDungeonWorkBench);

            if (craftingConfig.ShimmerRoyalStatues) //Disabled by default
            {
                ShimmerLoopWithTwo(ItemID.KingStatue, ItemID.QueenStatue);
            }
        }
    }

    public class ShimmerRecipesSystem : ModSystem
    {
        public override void Load()
        {
            ShimmerRecipes.EvilBiomeMimicCounterpartModEnabled = ModLoader.TryGetMod("EvilBiomeMimicCounterpart", out _);
        }
    }
}