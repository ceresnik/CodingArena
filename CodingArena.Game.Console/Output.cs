using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using static System.Console;

namespace CodingArena.Game.Console
{
    [Export(typeof(IOutput))]
    internal class Output : IOutput
    {
        private int Row { get; set; }
        private IRound Round { get; set; }
        private ITurn Turn { get; set; }
        private IMatch Match { get; set; }

        public void Set(IMatch match) => Match = match;
        public void Set(IRound round) => Round = round;
        public void Set(ITurn turn) => Turn = turn;

        public void Update()
        {
            Row = 0;
            DisplayHeader(Row++,"Coding Arena");
            if (Match != null)
            {
                DisplayHeader(Row++,"Match");
            }

            if (Round != null)
            {
                DisplayHeader(Row++,"Round");
            }

            if (Turn != null)
            {
                DisplayHeader(Row++, "Turn");
            }
        }

        public void Error(string message)
        {
            var previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            WriteLine(message);
            ForegroundColor = previousColor;
        }

        public void Update(IEnumerable<IBattleBot> bots, TurnResult turnResult)
        {
            Row = 1;
            DisplayHeader(Row, "Match");
            if (Scores != null)
            {
                DisplayHeader(Row, "Match ============================= K == D");
                Row++;
                foreach (var score in Scores.OrderByDescending(s => s.Kills))
                {
                    DisplayScore(Row, score);
                    Row++;
                }
            }
            DisplayHeader(Row, "Round");
        }

        public void SetMatchScores(IEnumerable<Score> scores) => Scores = scores;

        private IEnumerable<Score> Scores { get; set; }

        private void DisplayScore(int row, Score score) =>
            DisplayRow(row,
                $"  * {score.BotName,-30} " +
                $"{score.Kills,4:N0} {score.Deaths,4:N0}");

        private void DisplayHeader(int rowIndex, string text)
        {
            FullRow(rowIndex, "=");
            CursorTop = rowIndex;
            CursorLeft = 1;
            WriteLine($" {text} ");
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
    }
}