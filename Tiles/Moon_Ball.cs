using Terraria;
using Terraria.ObjectData;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ObjectInteractions;
using Terraria.Audio;


namespace ReducedGrinding.Tiles
{
    public class Moon_Ball : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = false;
			Main.tileLavaDeath[Type] = true;
			TileID.Sets.HasOutlines[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(1, 1);
			//TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
			TileObjectData.newTile.AnchorInvalidTiles = new int[] { 127 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Moon Ball");
			AddMapEntry(new Color(191, 191, 255), name);
			DustType = DustID.Cloud;
			TileID.Sets.DisableSmartCursor[Type] = true;
			Main.tileLighted[Type] = true;
		}

		public override void KillMultiTile(int x, int y, int frameX, int frameY)
		{
            Terraria.Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 32, 32, ModContent.ItemType<Items.Moon_Ball>());
		}

		public override bool HasSmartInteract(int x, int y, SmartInteractScanSettings settings)
		{
			return true;
		}

		public override bool RightClick(int x, int y)
		{
            Terraria.Player player = Main.LocalPlayer;

			Global.Update.advanceMoonPhase = true;
			if (Main.netMode == NetmodeID.MultiplayerClient) //Client
			{
				var netMessage = Mod.GetPacket();
				netMessage.Write((byte)ReducedGrindingMessageType.advanceMoonPhase);
				netMessage.Write(Global.Update.advanceMoonPhase);
				netMessage.Send();
			}
			SoundEngine.PlaySound(SoundID.Item4); //Crystal Ball

			return true;
		}

		public override void MouseOver(int x, int y)
		{
            Terraria.Player player = Main.LocalPlayer;
			player.noThrow = 2;
			player.cursorItemIconEnabled = true;
			player.cursorItemIconID = ModContent.ItemType<Items.Moon_Ball>();
		}

		public override void NumDust(int x, int y, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int x, int y, ref float r, ref float g, ref float b)
		{
			float lightStrength = Main.rand.NextFloat(0.125f, 0.25f);
			r = lightStrength;
			g = lightStrength;
			b = lightStrength;
		}
	}
}
