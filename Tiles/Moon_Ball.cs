using Terraria;
using Terraria.ObjectData;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using Terraria.DataStructures;
using System;
using Microsoft.Xna.Framework;


namespace ReducedGrinding.Tiles
{
	public class Moon_Ball : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = false;
			Main.tileLavaDeath[Type] = true;
			TileID.Sets.HasOutlines[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(1, 1);
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
			TileObjectData.newTile.HookCheck = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.FindEmptyChest), -1, 0, true);
			TileObjectData.newTile.AnchorInvalidTiles = new int[] { 127 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Moon Ball");
			AddMapEntry(new Color(191, 191, 255), name);
			dustType = mod.DustType("Sparkle");
			disableSmartCursor = true;
			dresser = "Moon Ball";
			Main.tileLighted[Type] = true;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 32, mod.ItemType("Moon_Ball"));
		}

		public override bool HasSmartInteract()
		{
			return true;
		}

        public override bool NewRightClick(int x, int y)
        {
			ReducedGrindingWorld.advanceMoonPhase = true;
			if (Main.netMode == NetmodeID.MultiplayerClient) //Client
			{
				var netMessage = mod.GetPacket();
				netMessage.Write((byte)ReducedGrindingMessageType.advanceMoonPhase);
				netMessage.Write(ReducedGrindingWorld.advanceMoonPhase);
				netMessage.Send();
			}
			Main.PlaySound(SoundID.Item4); //Crystal Ball
			return true;
		}

		public override void MouseOver(int i, int j)
		{
			Player player = Main.LocalPlayer;
			player.showItemIcon = true;
			player.showItemIcon2 = mod.ItemType("Moon_Ball");
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			float lightStrength = Main.rand.NextFloat(0.125f, 0.25f);
			r = lightStrength;
			g = lightStrength;
			b = lightStrength;
		}
	}
}
