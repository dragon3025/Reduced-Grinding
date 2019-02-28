using Terraria;
using Terraria.World.Generation;
using Terraria.ObjectData;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.ID;
using Terraria.GameContent.Generation;
using Terraria.GameContent.Events;
using Terraria.GameContent.Achievements;
using Terraria.Enums;
using Terraria.DataStructures;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ReducedGrinding.Items
{
    public class Pirate_Retreat_Order : ModItem
	{
		
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pirate Retreat Order");
            Tooltip.SetDefault("This will stop the Pirate Invasion.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.maxStack = 99;
            item.rare = 0;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.value = 20000;
            item.UseSound = SoundID.Item4;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
			if (Main.invasionType == 3)
				return true;
			else
				return false;
        }

        public override bool UseItem(Player player)
        {
			Main.invasionProgress = Main.invasionProgressMax;
			Main.invasionSize = 0;
			return true;
        }
    }
}