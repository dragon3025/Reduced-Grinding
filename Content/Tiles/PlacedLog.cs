using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ReducedGrinding.Content.Tiles
{
    public class PlacedLog : ModTile
    {
        public override void SetStaticDefaults()
        {
            //In 1.4.5, Fairy Log has a new Sprite.
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileAxe[Type] = true;

            DustType = DustID.t_LivingWood;

            TileObjectData.newTile.CopyFrom(TileObjectData.GetTileData(TileID.FallenLog, 0));
            TileObjectData.newTile.AnchorValidTiles = [TileID.Grass];
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.addTile(Type);

            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(127, 92, 69), name);
        }

        public override void RandomUpdate(int i, int j)
        {
            // A random chance to slow down growth
            if (!WorldGen.genRand.NextBool(120)) //This should take 2 days on average to return true
            {
                return;
            }

            Tile tile = Framing.GetTileSafely(i, j);
            int topX = i - tile.TileFrameX % 54 / 18;
            int topY = j - tile.TileFrameY % 36 / 18;

            int adjustment = tile.TileFrameX < 54 ? 1 : -1;

            for (int x = topX; x < topX + 3; x++)
            {
                for (int y = topY; y < topY + 2; y++)
                {
                    Main.tile[x, y].TileFrameX += (short)(54 * adjustment);
                    if (adjustment == -1)
                    {
                        Main.tile[x, y].TileType = TileID.FallenLog;
                    }
                }
            }

            if (Main.netMode != NetmodeID.SinglePlayer)
            {
                NetMessage.SendTileSquare(-1, topX, topY, 3, 2);
            }
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            yield return new Item(ItemID.Wood, Main.rand.Next(10, 21));
        }

        public override bool CanPlace(int i, int j)
        {
            int surfaceBottom = (int)Main.worldSurface - 10;
            int surfaceTop = 100;
            int surfaceRight = Main.maxTilesX - 100;
            if (Main.remixWorld)
            {
                surfaceBottom = Main.maxTilesY - 350;
                surfaceTop = (int)Main.rockLayer;
            }

            if (i >= 100 && i <= surfaceRight)
            {
                if (j >= surfaceTop && j <= surfaceBottom)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
