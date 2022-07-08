using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducedGrinding.GlobalFasterBossSummons
{
    public class FasterInvasionSummons : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            int type = item.type;
            return type == ItemID.GoblinBattleStandard || type == ItemID.PirateMap || type == ItemID.SnowGlobe;
        }

        public override bool? UseItem(Item item, Player player)
        {
            Global.Update.instantInvasion = true;
            if (Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = Mod.GetPacket();

                packet.Write((byte)ReducedGrinding.MessageType.instantInvasion);
                packet.Write(Global.Update.instantInvasion);

                packet.Send();
            }
            return base.UseItem(item, player);
        }
    }
    public class FasterCelestialSigil : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.CelestialSigil;
        }

        public override bool? UseItem(Item item, Player player)
        {
            Global.Update.celestialSigil = true;
            if (Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = Mod.GetPacket();

                packet.Write((byte)ReducedGrinding.MessageType.celestialSigil);
                packet.Write(Global.Update.celestialSigil);

                packet.Send();
            }
            return base.UseItem(item, player);
        }
    }
}
