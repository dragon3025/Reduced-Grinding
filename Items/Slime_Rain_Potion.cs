using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Microsoft.Xna.Framework;

namespace ReducedGrinding.Items
{
    public class Slime_Rain_Potion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slime Rain Potion");
            Tooltip.SetDefault("Starts/stops slime rain");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.maxStack = 30;
            item.rare = 2;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.value = Config.SlimeRainPotionRainPotionCost * Config.RainPotionWaterleafCost * 200 + Config.SlimeRainPotionWaterleafCost * 200 + Config.SlimeRainPotionGelCost * 10;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override bool UseItem(Player player)
        {
            if (Main.slimeRain)
                StopSlimeRain(true);
            else
                StartSlimeRain(true);
            return true;
        }
		
        private static void StopSlimeRain(bool announce = true)
		{
			if (!Main.slimeRain)
			{
				return;
			}
			if (Main.netMode == 1)
			{
				Main.slimeRainTime = 0.0;
				Main.slimeRain = false;
				SkyManager.Instance.Deactivate("Slime", new object[0]);
				return;
			}
			int num = 86400 * 7;
			if (Main.hardMode)
			{
				num *= 2;
			}
			Main.slimeRainTime = (double)(-(double)Main.rand.Next(3024, 6048) * 100);
			Main.slimeRain = false;
			if (Main.netMode == 0)
			{
				if (announce)
				{
					Main.slimeWarningTime = Main.slimeWarningDelay;
				}
				SkyManager.Instance.Deactivate("Slime", new object[0]);
				return;
			}
			if (announce)
			{
				Main.slimeWarningTime = Main.slimeWarningDelay;
				NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
			}
		}
		
		public static void StartSlimeRain(bool announce = true)
		{
			if (Main.slimeRain)
			{
				return;
			}
			if (Main.netMode == 1)
			{
				Main.slimeRainTime = 54000.0;
				Main.slimeRain = true;
				SkyManager.Instance.Activate("Slime", default(Vector2), new object[0]);
				return;
			}
			if (Main.raining)
			{
				return;
			}
			Main.slimeRainTime = (double)Main.rand.Next(32400, 54000);
			Main.slimeRain = true;
			Main.slimeRainKillCount = 0;
			if (Main.netMode == 0)
			{
				SkyManager.Instance.Activate("Slime", default(Vector2), new object[0]);
				if (announce)
				{
					Main.slimeWarningTime = Main.slimeWarningDelay;
					return;
				}
			}
			else
			{
				if (announce)
				{
					Main.slimeWarningTime = Main.slimeWarningDelay;
					NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
				}
			}
		}
		
        public override void AddRecipes()
        {
			if (Config.RainPotionRecipe)
			{
                ModRecipe recipe = new ModRecipe(mod);
				if (Config.SlimeRainPotionRainPotionCost > 0)
				{
					recipe.AddIngredient(mod.ItemType("Rain_Potion"), Config.SlimeRainPotionRainPotionCost);
				}
				else
				{
					recipe.AddIngredient(ItemID.BottledWater, 1);
				}
                if (Config.SlimeRainPotionWaterleafCost > 0)
					recipe.AddIngredient(ItemID.Waterleaf, Config.SlimeRainPotionWaterleafCost);
                if (Config.SlimeRainPotionRainCloudCost > 0)
					recipe.AddIngredient(ItemID.RainCloud, Config.SlimeRainPotionRainCloudCost);
                if (Config.SlimeRainPotionGelCost > 0)
					recipe.AddIngredient(ItemID.Gel, Config.SlimeRainPotionGelCost);
                recipe.AddTile(TileID.Bottles);
                recipe.SetResult(this);
                recipe.AddRecipe();
			}
        }
    }
}