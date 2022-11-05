using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ReducedGrinding.Tiles
{
    public class ShimmeringStar : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);

            AnimationFrameHeight = 36;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Shimmering Star");
            AddMapEntry(new Color(154, 131, 202), name);
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                string failText = "";

                if (Main.dungeonX < (Main.maxTilesX / 2) && i < Main.maxTilesX - WorldGen.beachDistance)
                {
                    failText = "Must be placed in the Caverns under the Eastern Beach.";
                }
                else if (Main.dungeonX > (Main.maxTilesX / 2) && i > WorldGen.beachDistance)
                {
                    failText = "Must be placed in the Caverns under the Western Beach.";
                }
                else if (j < Main.rockLayer || j > Main.UnderworldLayer)
                {
                    failText = "Must be placed in the Caverns.";
                }

                if (failText != "")
                {
                    if (Main.myPlayer == Main.LocalPlayer.whoAmI)
                    {
                        Main.NewText(failText, new Color(255, 127, 127));
                    }

                    WorldGen.KillTile(i, j);
                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, i, j);
                }
            }
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
            Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 32, 32, ModContent.ItemType<Items.Placeable.ShimmeringStar>());
        }
    }
}