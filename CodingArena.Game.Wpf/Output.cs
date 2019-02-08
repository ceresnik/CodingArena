using CodingArena.Game.Entities;
using System;
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
            Update();
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
            LongBeep();
        }

        private static void ShortBeep() => Beep(500, 200);

        private static void LongBeep() => Beep(500, 1000);

        private void OnRoundFinished(object sender, EventArgs e)
        {
            Game.Match.Round.TurnStarting -= OnTurnStarting;
            Game.Match.Round.TurnFinished -= OnTurnFinished;
        }

        private void OnTurnStarting(object sender, EventArgs e)
        {
        }

        private void OnTurnFinished(object sender, EventArgs e)
        {
            Update();
        }

        private void Update()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Update(Game.Match));
            sb.AppendLine(Update(Game.Match.Round));
            sb.AppendLine(Update(Game.Match.Round.Turn));
            ViewModel.Text = sb.ToString();
        }

        private string Update(IMatch match)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"=== Match {GetNextRoundIn()}");
            foreach (var score in match.Scores.OrderByDescending(s => s.Kills))
            {
                sb.AppendLine(DisplayScore(score));
            }

            return sb.ToString();
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
                if (timeSpan.Seconds > 0) text += $"{timeSpan.Seconds}s ";
                result = string.IsNullOrEmpty(text)
                    ? " [ Next round starting now ]"
                    : $" [ Next round in {text}]";
            }
            return result;
        }

        private string Update(IRound round) => $"=== Round ({round.Number} / {Settings.MaxRounds}) Battlefield [ {round.Battlefield.Width} x {round.Battlefield.Height} ]";

        private string Update(ITurn turn)
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"=== Turn  ({turn.Number} / {Settings.MaxTurns})");
            foreach (var bot in Game.Match.Round.Bots)
            {
                sb.AppendLine(DisplayBot(bot));
            }

            sb.AppendLine();
            sb.AppendLine("=== Actions");
            foreach (var pair in turn.BotActions)
            {
                sb.AppendLine(pair.Value);
            }

            return sb.ToString();
        }

        private string DisplayBot(IBattleBot bot) =>
            $"  * {bot.Name,-30} " +
            $"[HP: {bot.HP,3:F0}, SP: {bot.SP,3:F0}, EP: {bot.EP,3:F0}] " +
            $"[X: {bot.Position.X,2}, Y: {bot.Position.Y,2}]";

        public void Error(string message) => MessageBox.Show(message, "Error", MessageBoxButton.OK);

        private string DisplayScore(Score score) =>
            $"  * {score.BotName,-30} " +
            $"K: {score.Kills,3:N0} D: {score.Deaths,3:N0}";
    }
}