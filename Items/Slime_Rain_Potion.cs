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
            Item.width = 20;
            Item.height = 30;
            Item.maxStack = 30;
            Item.rare = ItemRarityID.Green;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
			Item.value = Item.buyPrice(0, 0, 2, 30);
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override bool? UseItem(Player player)
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
			if (Main.netMode == NetmodeID.MultiplayerClient)
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
			if (Main.netMode == NetmodeID.SinglePlayer)
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
				NetMessage.SendData(MessageID.WorldData, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
			}
		}
		
		public static void StartSlimeRain(bool announce = true)
		{
			if (Main.slimeRain)
			{
				return;
			}
			if (Main.netMode == NetmodeID.MultiplayerClient)
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
			if (Main.netMode == NetmodeID.SinglePlayer)
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
					NetMessage.SendData(MessageID.WorldData, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
				}
			}
		}
		
        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<Items.Rain_Potion>())
				.AddIngredient(ItemID.Gel)
				.AddTile(TileID.Bottles)
				.Register();
        }
    }
}