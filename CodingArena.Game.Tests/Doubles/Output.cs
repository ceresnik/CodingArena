using System.Collections.Generic;
using System.ComponentModel.Composition;
using static System.Console;

namespace CodingArena.Game.Tests.Doubles
{
    [Export(typeof(IOutput))]
    internal class Output : IOutput
    {
        public void DisplayGameTitle() => WriteLine("Coding Arena");

        public void Error(string message) => WriteLine($"Error: {message}");

        public void DisplayMatch(IEnumerable<Score> scores)
        {
            foreach (var score in scores)
            {
                WriteLine($"{score.BotName} K: {score.Kills} D: {score.Deaths}");
            }
        }
    }
}