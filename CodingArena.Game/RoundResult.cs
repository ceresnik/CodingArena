namespace CodingArena.Game
{
    internal class RoundResult
    {
        public static RoundResult NoWinner() => new RoundResult(null);

        public static RoundResult Winner(string name) => new RoundResult(name);

        private RoundResult(string name) => WinnerName = name;

        public string WinnerName { get; }
    }
}