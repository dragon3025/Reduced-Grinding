using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ReducedGrinding.Content.Tiles
{
    public class JackStatue : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;
            Main.tileSpelunker[Type] = true;
            TileID.Sets.IsAMechanism[Type] = true;

            DustType = DustID.Stone;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);

            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(144, 148, 144), name);
        }

        public override void HitWire(int i, int j)
        {
            (int x, int y) = TileObjectData.TopLeft(i, j);

            const int TileWidth = 2;
            const int TileHeight = 3;

            for (int yy = y; yy < y + TileHeight; yy++)
            {
                for (int xx = x; xx < x + TileWidth; xx++)
                {
                    Wiring.SkipWire(xx, yy);
                }
            }

            foreach (NPC npc in Main.ActiveNPCs)
            {
                if (!npc.townNPC || npc.homeless)
                {
                    return;
                }

                npc.position.X = npc.homeTileX * 16;
                npc.position.Y = npc.homeTileY * 16 - npc.height;

                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.SyncNPC, number: npc.whoAmI);
                }
            }
        }
    }
}