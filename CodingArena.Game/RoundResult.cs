using System.IO;

namespace CodingArena.Game
{
    internal class RoundResult
    {
        public static RoundResult NoWinner() => new RoundResult(null);

        public static RoundResult Winner(string name) => new RoundResult(name);

        private RoundResult(string name) => WinnerName = name;

        public string WinnerName { get; }

        public void DisplayTo(TextWriter output) =>
            output.WriteLine(string.IsNullOrWhiteSpace(WinnerName)
                ? "No winner."
                : $"Winner is {WinnerName}.");
    }
}