using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using static System.Console;

namespace CodingArena.Game.Tests.Doubles
{
    [Export(typeof(IOutput))]
    internal class Output : IOutput
    {
        public Dictionary<string, int> Winners { get; private set; }

        public void StartRound() => WriteLine("Starting round...");

        public void NextRoundIn(TimeSpan delayForNextRound) => WriteLine($"Next round in {delayForNextRound}...");

        public void SetBattlefield(IBattlefield battlefield) => WriteLine(battlefield);

        public void NoBotsQualified() => WriteLine("No bots qualified.");

        public void Qualified(Bot bot) => WriteLine($"Only one bot qualified {bot.Name}");

        public void Qualified(IList<Bot> bots)
        {
            WriteLine("Bots qualified:");
            foreach (var bot in bots)
                WriteLine(bot.Name);
        }

        public void TurnAction(Bot bot, string message) => WriteLine($"{bot.Name} {message}");

        public void RoundResult(RoundResult roundResult) =>
            WriteLine(roundResult.WinnerName == null
                ? "No round winner."
                : $"Winner is {roundResult.WinnerName}.");

        public void MatchResult(Dictionary<string, int> winners) => Winners = winners;
        public void Error(string message) => WriteLine($"Error: {message}");
    }
}