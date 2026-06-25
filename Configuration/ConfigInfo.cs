using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReducedGrinding.Configuration
{
    public class ConfigInfo : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("ConfigInfo")]

        [DefaultValue(true)]
        public bool ModdedBehaviorByDefault
        {
            get;
            set
            {
                value = true;
                field = value;
            }
        }

        [DefaultValue(false)]
        [BackgroundColor(128, 128, 128)]
        public bool VanillaBehaviorByDefault
        {
            get;
            set
            {
                value = false;
                field = value;
            }
        }

        [Header("ExtraBossMaterial")]

        [DefaultValue(false)]
        [BackgroundColor(128, 128, 128)]
        public bool ExtraBossMaterial
        {
            get;
            set
            {
                value = false;
                field = value;
            }
        }
    }
}
