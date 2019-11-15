using Terraria;
using Terraria.ObjectData;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using Terraria.DataStructures;
using System;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace ReducedGrinding.Tiles
{
	public class Marble_Sundial : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = false;
			Main.tileLavaDeath[Type] = true;
			TileID.Sets.HasOutlines[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(1, 2);
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 18 };
			TileObjectData.newTile.HookCheck = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.FindEmptyChest), -1, 0, true);
			TileObjectData.newTile.AnchorInvalidTiles = new int[] { 127 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Marble Sundial");
			AddMapEntry(new Color(57, 57, 58), name);
			dustType = mod.DustType("Sparkle");
			disableSmartCursor = true;
			dresser = "Marble Sundial";
			Main.tileLighted[Type] = true;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 32, mod.ItemType("Marble_Sundial"));
		}

		public override bool HasSmartInteract()
		{
			return true;
		}

        public override bool NewRightClick(int x, int y)
        {
            if (!Main.dayTime)
			{
				ReducedGrindingWorld.skipToDay = true;
				if (Main.netMode == NetmodeID.MultiplayerClient) //Client
				{
					var netMessage = mod.GetPacket();
					netMessage.Write((byte)ReducedGrindingMessageType.skipToDay);
					netMessage.Write(ReducedGrindingWorld.skipToDay);
					netMessage.Send();
				}
				Main.PlaySound(SoundID.Item4); //Crystal Ball
			}
            return true;
		}

		public override void MouseOver(int i, int j)
		{
			Player player = Main.LocalPlayer;
			player.showItemIcon = true;
			player.showItemIcon2 = mod.ItemType("Marble_Sundial");
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}
