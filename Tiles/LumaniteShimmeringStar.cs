using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;

//Remove when 1.4.4+ comes out unless there isn't a way to add shimmer features
namespace ReducedGrinding.Tiles
{
    public class LumaniteShimmeringStar : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;

            AdjTiles = new int[] { ModContent.TileType<Tiles.ShimmeringStar>() };

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);



            AnimationFrameHeight = 36;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Shimmering Star");
            AddMapEntry(new Color(154, 131, 202), name);
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if ((frame == 0 && frameCounter >= 60) || (frame > 0 && frameCounter >= 5))
            {
                frameCounter = 0;
                frame++;
                frame %= 7;
            }
        }

        public override void KillMultiTile(int x, int y, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 32, 32, ModContent.ItemType<Items.Placeable.LumaniteShimmeringStar>());
        }
    }
}