using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using static System.Console;

namespace CodingArena.Game
{
    [Export(typeof(IOutput))]
    internal class Output : IOutput
    {
        private IList<Bot> QualifiedBots { get; set; }
        private const int RoundRow = 1;
        private const int BattlefieldRow = 2;
        private const int QualificationRow = 3;
        private const int BotsRow = 10;

        public Output()
        {
            CursorVisible = false;
        }

        public void StartRound()
        {
            Clear();
            DisplayRow(0, "CodingArena");
            DisplayRow(RoundRow, $"Starting round {DateTime.Now} ...");
        }

        public void NextRoundIn(TimeSpan delayForNextRound) =>
            DisplayRow(RoundRow, $"Next round in {delayForNextRound:g}");

        public void Battlefield(Battlefield battlefield)
        {
            var size = battlefield.Size;
            DisplayRow(BattlefieldRow, $"Battlefield [width: {size.Width}, height:{size.Height}]");
        }

        public void NoBotsQualified()
        {
            FullRow(QualificationRow, "-");
            DisplayRow(QualificationRow + 1, "No bots are qualified.");
        }

        public void Qualified(Bot bot)
        {
            FullRow(QualificationRow, "-");
            DisplayRow(QualificationRow + 1, "Only one bot qualified:");
            DisplayRow(QualificationRow + 2, DisplayBot(bot));
        }

        public void Qualified(IList<Bot> bots)
        {
            QualifiedBots = bots;
            FullRow(QualificationRow, "-");
            DisplayRow(QualificationRow + 1, "Bots qualified:");
            for (int i = 0; i < bots.Count; i++)
                DisplayRow(QualificationRow + 2 + i, DisplayBot(bots[i]));
        }

        public void TurnAction(Bot bot, string message)
        {
            Qualified(QualifiedBots);
            var index = QualifiedBots.IndexOf(bot);
            DisplayRow(BotsRow + index, message);
        }

        public void RoundResult(RoundResult roundResult)
        {
            DisplayRow(RoundRow, string.IsNullOrWhiteSpace(roundResult.WinnerName)
                ? "Round has no winner."
                : $"Round winner is {roundResult.WinnerName}.");
        }

        public void MatchResult(Dictionary<string, int> winners)
        {
            // TODO
        }

        private void DisplayRow(int row, string message)
        {
            FullRow(row, " ");
            CursorTop = row;
            CursorLeft = 0;
            WriteLine(message);
        }

        private void FullRow(int row, string s)
        {
            CursorTop = row;
            CursorLeft = 0;
            WriteLine(string.Join("", Enumerable.Repeat(s, BufferWidth - 1)));
        }

        private static string DisplayBot(Bot bot)
        {
            string position = "";
            if (bot.Position != null)
            {
                position = $"[X: {bot.Position.X}, Y: {bot.Position.Y}]";
            }
            return $"{bot.Name} " +
                   $"[HP: {bot.Health:F0} SP: {bot.Shield:F0} EP: {bot.Energy:F0}] " +
                   position;
        }
    }
}