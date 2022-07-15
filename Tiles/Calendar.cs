using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Tiles
{
    public class Calendar : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileID.Sets.FramesOnKillWall[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.addTile(Type);

			AnimationFrameHeight = 54;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Calendar");
			AddMapEntry(new Color(255, 255, 255), name);
		}

		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			int seasonalDay = Global.Update.seasonalDay;
			int dayLength = GetInstance<IOtherConfig>().PeriodicHolidayTimelineDayLength;
			frame = Math.Max(1, (int)Math.Ceiling(1f * seasonalDay / dayLength)) - 1;
		}

		public override bool HasSmartInteract(int x, int y, SmartInteractScanSettings settings)
		{
			return true;
		}

		public override bool RightClick(int x, int y)
		{
			int seasonalDay = Global.Update.seasonalDay;
			int dayLength = GetInstance<IOtherConfig>().PeriodicHolidayTimelineDayLength;
			int month = Math.Max(1, (int)Math.Ceiling(1f * seasonalDay / dayLength));
			string text = "";
			text = "Day: " + seasonalDay.ToString() + " Month: ";
			switch (month)
			{
				case 1:
					text += "January";
					break;
				case 2:
					text += "Febuary";
					break;
				case 3:
					text += "March";
					break;
				case 4:
					text += "April";
					break;
				case 5:
					text += "May";
					break;
				case 6:
					text += "June";
					break;
				case 7:
					text += "July";
					break;
				case 8:
					text += "August";
					break;
				case 9:
					text += "September";
					break;
				case 10:
					text += "October";
					break;
				case 11:
					text += "November";
					break;
				case 12:
					text += "December";
					break;
			}
			Main.NewText(text, new Color(255, 255, 0));

			return true;
		}

		public override void MouseOver(int x, int y)
		{
			Player player = Main.LocalPlayer;
			player.noThrow = 2;
			player.cursorItemIconEnabled = true;
			player.cursorItemIconID = ItemType<Items.Placeable.Calendar>();
		}

		public override void KillMultiTile(int x, int y, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 32, 32, ItemType<Items.Placeable.Calendar>());
		}
	}
}
