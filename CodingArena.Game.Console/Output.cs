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
        private const int GameTitleRow = 0;
        private const int MatchRow = 1;
        private int Row { get; set; }

        public void DisplayGameTitle() => DisplayHeader(GameTitleRow, "Coding Arena");

        public void Error(string message)
        {
            var previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            WriteLine(message);
            ForegroundColor = previousColor;
        }

        public void DisplayMatch(IEnumerable<Score> scores)
        {
            DisplayHeader(MatchRow, "Match");
            Row = MatchRow + 1;
            foreach (var score in scores)
            {
                DisplayScore(Row, score);
            }
        }

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