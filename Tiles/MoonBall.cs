using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ReducedGrinding.Tiles
{
    public class MoonBall : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = false;
            Main.tileLavaDeath[Type] = true;
            Main.tileShine[Type] = 300;
            Main.tileLighted[Type] = true;


            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.addTile(Type);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Moon Ball");
            AddMapEntry(new Color(191, 191, 255), name);

            DustType = DustID.Marble;

            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
        }

        public override void KillMultiTile(int x, int y, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 32, 32, ModContent.ItemType<Items.Placeable.MoonBall>());
        }

        public override bool HasSmartInteract(int x, int y, SmartInteractScanSettings settings)
        {
            return true;
        }

        public override bool RightClick(int x, int y)
        {
            Global.Update.advanceMoonPhase = true;
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                ModPacket packet = Mod.GetPacket();
                packet.Write((byte)ReducedGrinding.MessageType.advanceMoonPhase);
                packet.Write(Global.Update.advanceMoonPhase);
                packet.Send();
            }
            SoundEngine.PlaySound(SoundID.Item4); //Crystal Ball

            return true;
        }

        public override void MouseOver(int x, int y)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<Items.Placeable.MoonBall>();
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
