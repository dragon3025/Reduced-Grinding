/* To debug, use:
 * Terraria.ModLoader.ModContent.GetInstance<ReducedGrinding>().Logger.Debug($"");
 * 
 * To turn into a string use:
 * $"text {variable}"
 * 
 * To show text in chat use:
 * Main.NewText(string);
 */

using Humanizer;
using Microsoft.Xna.Framework;
using ReducedGrinding.Common.GlobalItems;
using ReducedGrinding.Common.GlobalNPCs;
using ReducedGrinding.Common.ModPlayers;
using ReducedGrinding.Common.ModSystems;
using ReducedGrinding.Configuration;
using ReducedGrinding.Content.Items;
using ReducedGrinding.Content.Items.Consumable;
using ReducedGrinding.Content.Items.Consumable.Summoning;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding
{
    public class ReducedGrinding : Mod
    {
        public override void Load()
        {
            ModLoader.TryGetMod("Wikithis", out Mod wikithis);
            if (wikithis != null && !Main.dedServ)
            {
                wikithis.Call("AddModURL", this, "https://terrariamods.wiki.gg/wiki/Reduced_Grinding/{}");
            }
        }

        public enum MessageType : byte
        {
            FirstQuestOfTheDay,
            TravelingMerchantDiceRolls,
            ChatQuestFish,
            BattleBuffTier,
            BobberBuffTier,
            ChaosSwarmtime,
            FaelingHelperDespawn,
            LunarApocalypseIsUp,
            MoonLordCountdownRunning,
        }

        //NOTE: You can test 2 players on 1 PC using the start-tModLoader.bat files.
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            MessageType msgType = (MessageType)reader.ReadByte();
            byte playerNumber;
            switch (msgType)
            {
                case MessageType.FirstQuestOfTheDay:
                    UnlimitedAnglerQuests.firstQuestOfTheDay = reader.ReadBoolean();
                    break;
                case MessageType.TravelingMerchantDiceRolls:
                    MerchantDice.travelingMerchantDiceRolls = reader.ReadInt32();
                    break;
                case MessageType.ChatQuestFish:
                    AnglerSystem.chatQuestFish = reader.ReadBoolean();
                    break;
                case MessageType.BattleBuffTier:
                    playerNumber = reader.ReadByte();
                    BattleBuffTiers battleBuffTiers = Main.player[playerNumber].GetModPlayer<BattleBuffTiers>();
                    battleBuffTiers.ReceivePlayerSync(reader);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        battleBuffTiers.SyncPlayer(-1, whoAmI, false);
                    }
                    break;
                case MessageType.BobberBuffTier:
                    playerNumber = reader.ReadByte();
                    BobberBuffTiers bobberBuffTiers = Main.player[playerNumber].GetModPlayer<BobberBuffTiers>();
                    bobberBuffTiers.ReceivePlayerSync(reader);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        bobberBuffTiers.SyncPlayer(-1, whoAmI, false);
                    }
                    break;
                case MessageType.ChaosSwarmtime:
                    ChaosElementalSwarm.chaosSwarmtime = reader.ReadInt32();
                    break;
                case MessageType.FaelingHelperDespawn:
                    NPC npc = Main.npc[reader.ReadInt32()];
                    FaelingHelper faelingHelper = npc.GetGlobalNPC<FaelingHelper>();
                    faelingHelper.despawn = reader.ReadBoolean();
                    break;
                case MessageType.LunarApocalypseIsUp:
                    LunarInvasion.lunarApocalypseIsUp = reader.ReadBoolean();
                    break;
                case MessageType.MoonLordCountdownRunning:
                    LunarInvasion.moonLordCountdownRunning = reader.ReadBoolean();
                    break;
                default:
                    Logger.WarnFormat("Reduced Grinding: Unknown Message type: {0}", msgType);
                    break;
            }
        }

        public static Color DebugColor()
        {
            string name = Main.LocalPlayer.name.Titleize();
            return name == "Mario" ? Color.Red : name == "Luigi" ? Color.Lime : Color.White;
        }

        public static string GetText(string key)
        {
            return Language.GetOrRegister("Mods.ReducedGrinding." + key).ToString();
        }
    }

    public class ReducedGrindingSave : ModSystem
    {
        private static readonly EnemyLootConfig lootConfig = GetInstance<EnemyLootConfig>();

        public override void OnWorldLoad()
        {
            FasterInvasionSummons.instantInvasion = false;
            TravelingMerchant.chatMerchantItems = false;
            AnglerSystem.chatQuestFish = false;
            DifficultyStavesSystem.playersVotingForDifficultyChange.Clear();
            DifficultyStavesSystem.difficultyVotingTimer = 0;
            LunarSigilSystem.activated = 0;
            LunarSigilSystem.npcsToRemove = [];
            CelestialWardSystem.activated = 0;
            CelestialWardSystem.npcsToRemove = [];
            LunarInvasion.UpdateStatus();
            NPCArrivalMessages.cultistsMessageCooldown = 600;

            Rectangle shimmerSurface = new(-1, -1, 0, 1);
            for (int j = (int)Main.rockLayer; j < Main.UnderworldLayer; j++)
            {
                for (int i = 0; i < Main.maxTilesX; i++)
                {
                    Tile tileSafely = Framing.GetTileSafely(i, j);

                    if (tileSafely == null)
                    {
                        continue;
                    }

                    if (tileSafely.LiquidType == LiquidID.Shimmer && tileSafely.LiquidAmount > 0)
                    {
                        if (shimmerSurface.X == -1)
                        {
                            shimmerSurface.X = i;
                            shimmerSurface.Y = j;
                        }
                        shimmerSurface.Width = 1 + (i - shimmerSurface.X);
                    }
                    else if (shimmerSurface.X != -1)
                    {
                        goto finishedShimmerSearch;
                    }
                }
            }
            finishedShimmerSearch:;
            FaelingHelper.shimmerPosition = new(-1, -1);
            if (shimmerSurface.Width > 0)
            {
                FaelingHelper.shimmerPosition.X = shimmerSurface.Center.X * 16;
                FaelingHelper.shimmerPosition.Y = shimmerSurface.Y * 16;
            }
        }

        public override void SaveWorldData(TagCompound tag)
        {
            tag["firstQuestOfTheDay"] = UnlimitedAnglerQuests.firstQuestOfTheDay;
            tag["travelingMerchantDiceRolls"] = MerchantDice.travelingMerchantDiceRolls;
            tag["npcArrivalMessagesOldMan"] = NPCArrivalMessages.oldMan;
            tag["npcArrivalMessagesCultists"] = NPCArrivalMessages.cultists;
            tag["startSandstorm"] = ShimmerEffectsModSystem.startSandstorm;
            tag["shimmerFound"] = FaelingHelper.shimmerFound;
            tag["jungleHardmodeKills"] = BiomeKeyDrop.jungleHardmodeKills;
            tag["corruptionHardmodeKills"] = BiomeKeyDrop.corruptionHardmodeKills;
            tag["crimsonHardmodeKills"] = BiomeKeyDrop.crimsonHardmodeKills;
            tag["hallowHardmodeKills"] = BiomeKeyDrop.hallowHardmodeKills;
            tag["snowHardmodeKills"] = BiomeKeyDrop.snowHardmodeKills;
            tag["desertHardmodeKills"] = BiomeKeyDrop.desertHardmodeKills;
            tag["chaosSwarmtime"] = ChaosElementalSwarm.chaosSwarmtime;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            if (!tag.TryGet("firstQuestOfTheDay", out UnlimitedAnglerQuests.firstQuestOfTheDay))
            {
                UnlimitedAnglerQuests.firstQuestOfTheDay = true;
            }
            if (!tag.TryGet("travelingMerchantDiceRolls", out MerchantDice.travelingMerchantDiceRolls))
            {
                MerchantDice.travelingMerchantDiceRolls = 0;
            }
            if (!tag.TryGet("npcArrivalMessagesOldMan", out NPCArrivalMessages.oldMan))
            {
                NPCArrivalMessages.oldMan = false;
            }
            if (!tag.TryGet("npcArrivalMessagesCultists", out NPCArrivalMessages.cultists))
            {
                NPCArrivalMessages.cultists = false;
            }
            if (!tag.TryGet("startSandstorm", out ShimmerEffectsModSystem.startSandstorm))
            {
                ShimmerEffectsModSystem.startSandstorm = false;
            }
            if (!tag.TryGet("shimmerFound", out FaelingHelper.shimmerFound))
            {
                FaelingHelper.shimmerFound = false;
            }
            if (lootConfig.GuaranteedBiomeKey == 0)
            {
                BiomeKeyDrop.jungleHardmodeKills = 0;
                BiomeKeyDrop.corruptionHardmodeKills = 0;
                BiomeKeyDrop.crimsonHardmodeKills = 0;
                BiomeKeyDrop.hallowHardmodeKills = 0;
                BiomeKeyDrop.snowHardmodeKills = 0;
                BiomeKeyDrop.desertHardmodeKills = 0;
            }
            else
            {
                if (!tag.TryGet("jungleHardmodeKills", out BiomeKeyDrop.jungleHardmodeKills))
                {
                    BiomeKeyDrop.jungleHardmodeKills = 0;
                }
                if (!tag.TryGet("corruptionHardmodeKills", out BiomeKeyDrop.corruptionHardmodeKills))
                {
                    BiomeKeyDrop.corruptionHardmodeKills = 0;
                }
                if (!tag.TryGet("crimsonHardmodeKills", out BiomeKeyDrop.crimsonHardmodeKills))
                {
                    BiomeKeyDrop.crimsonHardmodeKills = 0;
                }
                if (!tag.TryGet("hallowHardmodeKills", out BiomeKeyDrop.hallowHardmodeKills))
                {
                    BiomeKeyDrop.hallowHardmodeKills = 0;
                }
                if (!tag.TryGet("snowHardmodeKills", out BiomeKeyDrop.snowHardmodeKills))
                {
                    BiomeKeyDrop.snowHardmodeKills = 0;
                }
                if (!tag.TryGet("desertHardmodeKills", out BiomeKeyDrop.desertHardmodeKills))
                {
                    BiomeKeyDrop.desertHardmodeKills = 0;
                }
            }
            if (!tag.TryGet("chaosSwarmtime", out ChaosElementalSwarm.chaosSwarmtime))
            {
                ChaosElementalSwarm.chaosSwarmtime = 0;
            }
        }
    }

    //class HowToUseBestiaryUnlock
    //{
    //    //add using Terraria.GameContent.Bestiary

    //    public static bool HowToUseBestiaryUnlockTest()
    //    {
    //        BestiaryEntry entry = BestiaryDatabaseNPCsPopulator.FindEntryByNPCID(NPCID.SkeletonMerchant);
    //        BestiaryEntryUnlockState unlockState = entry.UIInfoProvider.GetEntryUICollectionInfo().UnlockState;
    //        return unlockState != BestiaryEntryUnlockState.NotKnownAtAll_0;
    //    }
    //}
}
