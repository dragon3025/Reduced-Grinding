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
			int monthLength = GetInstance<IOtherConfig>().HolidayTimelineDaysPerMonth;
			frame = Math.Max(1, (int)Math.Ceiling(1f * seasonalDay / monthLength)) - 1;
		}

		public override bool HasSmartInteract(int x, int y, SmartInteractScanSettings settings)
		{
			return true;
		}

		public override bool RightClick(int x, int y)
		{
			int seasonalDay = Global.Update.seasonalDay;
			int monthLength = GetInstance<IOtherConfig>().HolidayTimelineDaysPerMonth;
			int month = Math.Max(1, (int)Math.Ceiling(1f * seasonalDay / monthLength));
			string dateText = "";
			switch (month)
			{
				case 1:
					dateText += "January ";
					break;
				case 2:
					dateText += "Febuary ";
					break;
				case 3:
					dateText += "March ";
					break;
				case 4:
					dateText += "April ";
					break;
				case 5:
					dateText += "May ";
					break;
				case 6:
					dateText += "June ";
					break;
				case 7:
					dateText += "July ";
					break;
				case 8:
					dateText += "August ";
					break;
				case 9:
					dateText += "September ";
					break;
				case 10:
					dateText += "October ";
					break;
				case 11:
					dateText += "November ";
					break;
				case 12:
					dateText += "December ";
					break;
			}
			int dayOfMonth = ((seasonalDay - 1) % monthLength) + 1;
			dateText += dayOfMonth.ToString();
            dateText += dayOfMonth switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                21 => "st",
                22 => "nd",
                23 => "rd",
                _ => "th",
            };
            Main.NewText(dateText, new Color(255, 255, 0));

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
