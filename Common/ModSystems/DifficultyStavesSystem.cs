using Humanizer;
using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common.ModSystems
{
    public class DifficultyStavesSystem : ModSystem
    {
        public static List<string> playersVotingForDifficultyChange = [];
        private static int requestedDifficulty;
        public static int difficultyVotingTimer;
        private static readonly OtherConfig otherconfig = GetInstance<OtherConfig>();
        private static readonly int difficultyVotingTimerMax = 60 * otherconfig.DifficultyStavesVoteTimeSeconds;

        public override void PostUpdateTime()
        {
            if (Main.netMode != NetmodeID.Server || difficultyVotingTimer <= 0)
            {
                return;
            }

            if (difficultyVotingTimer == difficultyVotingTimerMax)
            {
                string text;
                int activePlayerCount = 0;

                foreach (Player _ in Main.ActivePlayers)
                {
                    activePlayerCount++;
                }

                int totalVotesNeeded = (int)Math.Round(activePlayerCount * otherconfig.DifficultyStavesVotesRequired);
                int votesForDifficulty = playersVotingForDifficultyChange.Count;

                if (votesForDifficulty >= totalVotesNeeded)
                {
                    Main.GameMode = requestedDifficulty;
                    difficultyVotingTimer = 0;
                    playersVotingForDifficultyChange.Clear();

                    text = DifficultySwitchedText(requestedDifficulty);
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey(text), new Color(255, 240, 20));
                    NetMessage.SendData(MessageID.WorldData);

                    return;
                }

                string languageKey = ReducedGrinding.GetText("Misc.DifficultyStaves.VoteCount");
                text = requestedDifficulty switch
                {
                    GameModeID.Normal => languageKey.FormatWith("FFFFFF", Language.GetTextValue("UI.Normal"), votesForDifficulty, totalVotesNeeded),
                    GameModeID.Expert => languageKey.FormatWith("FF9900", Language.GetTextValue("UI.Expert"), votesForDifficulty, totalVotesNeeded),
                    _ => languageKey.FormatWith("FF2619", Language.GetTextValue("UI.Master"), votesForDifficulty, totalVotesNeeded),
                };
                ChatHelper.BroadcastChatMessage(NetworkText.FromKey(text), new Color(255, 240, 20));
            }

            difficultyVotingTimer--;
            if (difficultyVotingTimer <= 0)
            {
                playersVotingForDifficultyChange.Clear();
                ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Mods.ReducedGrinding.Misc.DifficultyStaves.VotingTimeUp"), new Color(255, 240, 20));
                return;
            }
        }

        private static string DifficultySwitchedText(int difficulty)
        {
            string text;
            string languageKey = "Mods.ReducedGrinding.Misc.DifficultyStaves.DifficultySwitched";
            text = difficulty switch
            {
                GameModeID.Normal => Language.GetTextValue(languageKey).FormatWith("FFFFFF", Language.GetTextValue("UI.Normal")),
                GameModeID.Expert => Language.GetTextValue(languageKey).FormatWith("FF9900", Language.GetTextValue("UI.Expert")),
                _ => Language.GetTextValue(languageKey).FormatWith("FF2619", Language.GetTextValue("UI.Master")),
            };
            if (Main.getGoodWorld)
            {
                languageKey = "Mods.ReducedGrinding.Misc.DifficultyStaves.GetGoodModification";
                text += difficulty switch
                {
                    GameModeID.Normal => Language.GetTextValue(languageKey).FormatWith("FF9900", Language.GetTextValue("UI.Expert")),
                    GameModeID.Expert => Language.GetTextValue(languageKey).FormatWith("FF2619", Language.GetTextValue("UI.Master")),
                    _ => Language.GetTextValue(languageKey).FormatWith("32CD32", Language.GetTextValue("UI.Legendary")),
                };
            }

            return text;
        }

        public static bool RequestDifficulty(Player player, int staffDifficulty)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient && player != Main.LocalPlayer)
            {
                return true;
            }

            SoundEngine.PlaySound(SoundID.Item4); //Crystal Ball

            if (Main.GameMode == GameModeID.Creative)
            {
                Main.NewText(ReducedGrinding.GetText("Misc.DifficultyStaves.CantUseInJourneyMode"), 255, 240, 20);
                return true;
            }

            if (Main.GameMode == staffDifficulty)
            {
                string languageKey = ReducedGrinding.GetText("Misc.DifficultyStaves.DifficultyIsTheSame");
                string text = staffDifficulty switch
                {
                    GameModeID.Normal => languageKey.FormatWith("FFFFFF", Language.GetTextValue("UI.Normal")),
                    GameModeID.Expert => languageKey.FormatWith("FF9900", Language.GetTextValue("UI.Expert")),
                    _ => languageKey.FormatWith("FF2619", Language.GetTextValue("UI.Master")),
                };
                Main.NewText(text, 255, 240, 20);
                return true;
            }

            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.GameMode = staffDifficulty;
                Main.NewText(NetworkText.FromKey(DifficultySwitchedText(staffDifficulty)), new Color(255, 240, 20));
                return true;
            }

            if (Main.netMode != NetmodeID.Server)
            {
                return true;
            }

            if (playersVotingForDifficultyChange.Count > 0) //Only the server has this info.
            {
                if (requestedDifficulty != staffDifficulty)
                {
                    string text = ReducedGrinding.GetText("Misc.DifficultyStaves.WaitForVotingTimeToEnd");
                    ChatHelper.SendChatMessageToClient(NetworkText.FromKey(text), new Color(255, 240, 20), player.whoAmI);
                    return true;
                }
                else if (playersVotingForDifficultyChange.Contains(player.name))
                {
                    string text = ReducedGrinding.GetText("Misc.DifficultyStaves.AlreadyVoted");
                    ChatHelper.SendChatMessageToClient(NetworkText.FromKey(text), new Color(255, 240, 20), player.whoAmI);
                    return true;
                }
            }

            if (playersVotingForDifficultyChange.Count == 0)
            {
                requestedDifficulty = staffDifficulty;
            }

            difficultyVotingTimer = difficultyVotingTimerMax;
            playersVotingForDifficultyChange.Add(player.name);

            return true;
        }
    }
}
