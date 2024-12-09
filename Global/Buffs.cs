using ReducedGrinding.Configuration;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace ReducedGrinding.Global.GlobalBuffs
{
    public class ReducedGrindingBuffs : GlobalBuff
    {
        readonly static IOtherConfig otherConfig = GetInstance<IOtherConfig>();

        public override void Update(int type, Player player, ref int buffIndex)
        {
            if (type == BuffID.SugarRush)
            {
                player.buffTime[buffIndex] = 2;
                Main.buffNoSave[type] = true;
            }
        }

        public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare)
        {
            if (!otherConfig.ClairvoyanceShowsLuck)
            {
                return;
            }

            if (type == BuffID.Clairvoyance)
            {
                tip += "\n";
                tip += Language.GetTextValue("Mods.ReducedGrinding.Misc.ClairvoyanceLuckTooltip");
            }
        }
    }
}
