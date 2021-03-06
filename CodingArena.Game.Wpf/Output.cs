﻿using CodingArena.Game.Entities;
using CodingArena.Game.Wpf.Battlefield;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using static System.Console;

namespace CodingArena.Game.Wpf
{
    [Export(typeof(IOutput))]
    internal class Output : IOutput
    {
        private ISettings Settings { get; }
        private IMainViewModel ViewModel { get; }
        private IGame Game { get; set; }

        [ImportingConstructor]
        public Output(ISettings settings, IMainViewModel viewModel)
        {
            Settings = settings;
            ViewModel = viewModel;
            ViewModel.MaxTurns = Settings.MaxTurns;
            ViewModel.MaxRounds = Settings.MaxRounds;
        }

        public void Observe(IGame game)
        {
            Game = game ?? throw new ArgumentNullException(nameof(game));
            Game.MatchStarting += OnMatchStarting;
            Game.MatchFinished += OnMatchFinished;
        }

        private void OnMatchStarting(object sender, EventArgs e)
        {
            Game.Match.RoundStarting += OnRoundStarting;
            Game.Match.RoundFinished += OnRoundFinished;
            Game.Match.NextRoundInUpdated += OnNextRoundInUpdated;
        }

        private void OnMatchFinished(object sender, EventArgs e)
        {
            Game.Match.RoundStarting -= OnRoundStarting;
            Game.Match.RoundFinished -= OnRoundFinished;
            Game.Match.NextRoundInUpdated -= OnNextRoundInUpdated;
        }

        private void OnNextRoundInUpdated(object sender, EventArgs e)
        {
            ViewModel.NextRoundIn = GetNextRoundIn();
            if (Game.Match.NextRoundIn != TimeSpan.Zero &&
                Game.Match.NextRoundIn < TimeSpan.FromSeconds(4))
            {
                ShortBeep();
            }
        }

        private void OnRoundStarting(object sender, EventArgs e)
        {
            Game.Match.Round.TurnStarting += OnTurnStarting;
            Game.Match.Round.TurnFinished += OnTurnFinished;
            ViewModel.RoundNumber = Game.Match.Round.Number;
            ViewModel.BattlefieldViewModel = new BattlefieldViewModel(Game.Match.Round);
            LongBeep();
        }

        private static void ShortBeep() => Beep(500, 200);

        private static void LongBeep() => Beep(500, 1000);

        private void OnRoundFinished(object sender, EventArgs e)
        {
            Game.Match.Round.TurnStarting -= OnTurnStarting;
            Game.Match.Round.TurnFinished -= OnTurnFinished;
            Update();
        }

        private void OnTurnStarting(object sender, EventArgs e)
        {
            ViewModel.TurnNumber = Game.Match.Round.Turn.Number;
        }

        private void OnTurnFinished(object sender, EventArgs e)
        {
            Update();
        }

        private void Update()
        {
            Update(Game.Match);
            IRound round = Game.Match.Round;
            ViewModel.BattlefieldWidth = round.Battlefield.Width;
            ViewModel.BattlefieldHeight = round.Battlefield.Height;

            var sb = new StringBuilder();
            ViewModel.BotStates.Clear();
            foreach (var bot in Game.Match.Round.Bots)
            {
                sb.AppendLine(bot.Action);
                sb.AppendLine(DisplayBot(bot));
                ViewModel.BattlefieldViewModel.Update(bot);
                ViewModel.BotStates.Add(new BotStateViewModel(bot));
            }
            ViewModel.TurnText = sb.ToString();
            ViewModel.BattlefieldText = GetBattlefieldText(Game.Match.Round);
        }

        private void Update(IMatch match)
        {
            ViewModel.BotScores.Clear();
            foreach (var score in match.Scores)
            {
                ViewModel.BotScores.Add(score);
            }

            var roundBotScores = new ObservableCollection<Score>();
            foreach (var bot in match.Round.Bots)
            {
                roundBotScores.Add(
                    new Score
                    {
                        BotName = bot.Name,
                        Kills = bot.Kills,
                        Deaths = bot.Deaths
                    });
            }

            ViewModel.RoundBotScores.Clear();
            foreach (var botScore in roundBotScores.OrderByDescending(s => s.Kills - s.Deaths))
            {
                ViewModel.RoundBotScores.Add(botScore);
            }
        }

        private string GetNextRoundIn()
        {
            string result = "";
            var timeSpan = Game.Match.NextRoundIn;
            if (timeSpan != TimeSpan.Zero)
            {
                string text = string.Empty;
                if (timeSpan.Days > 0) text += $"{timeSpan.Days}d ";
                if (timeSpan.Hours > 0) text += $"{timeSpan.Hours}h ";
                if (timeSpan.Minutes > 0) text += $"{timeSpan.Minutes}m ";
                if (timeSpan.Seconds > 0) text += $"{timeSpan.Seconds}s";
                result = $"Next round in {text}.";
            }
            return result;
        }

        private string GetBattlefieldText(IRound round)
        {
            var sb = new StringBuilder();
            foreach (var bot in round.Bots)
            {
                sb.AppendLine(
                    $"{bot.Name,-30} " +
                    $"[X: {bot.Position.X,2}, Y: {bot.Position.Y,2}]");
            }

            return sb.ToString();
        }

        private string DisplayBot(IBattleBot bot) =>
            $"[HP: {bot.HP,3:F0}, SP: {bot.SP,3:F0}, EP: {bot.EP,3:F0}] ";

        public void Error(string message) => MessageBox.Show(message, "Error", MessageBoxButton.OK);
    }
}