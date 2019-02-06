using System;
using System.ComponentModel.Composition;
using System.Linq;
using static System.Console;

namespace CodingArena.Game.Console
{
    [Export(typeof(IOutput))]
    internal class Output : IOutput
    {
        private const int GameTitleRow = 0;
        private int Row { get; set; }

        public void DisplayGameTitle() => DisplayHeader(GameTitleRow, "Coding Arena");

        public void Error(string message)
        {
            var previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            WriteLine(message);
            ForegroundColor = previousColor;
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