using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace CodingArena.Game.Tests.Doubles
{
    [Export(typeof(IOutput))]
    internal class Output : IOutput
    {
        public Dictionary<string, int> Winners { get; private set; }

        public void StartRound() => Console.WriteLine("Starting round...");

        public void NextRoundIn(TimeSpan delayForNextRound) => Console.WriteLine($"Next round in {delayForNextRound}...");

        public void Battlefield(Battlefield battlefield) => Console.WriteLine(battlefield);

        public void NoBotsQualified() => Console.WriteLine("No bots qualified.");

        public void Qualified(Bot bot) => Console.WriteLine($"Only one bot qualified {bot.Name}");

        public void Qualified(IList<Bot> bots)
        {
            Console.WriteLine("Bots qualified:");
            foreach (var bot in bots)
                Console.WriteLine(bot.Name);
        }

        public void TurnAction(Bot bot, string message) => Console.WriteLine($"{bot.Name} {message}");

        public void RoundResult(RoundResult roundResult) =>
            Console.WriteLine(roundResult.WinnerName == null
                ? "No round winner."
                : $"Winner is {roundResult.WinnerName}.");

        public void MatchResult(Dictionary<string, int> winners) => Winners = winners;
    }
}