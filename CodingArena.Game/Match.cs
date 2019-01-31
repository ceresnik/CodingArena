using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace CodingArena.Game
{
    [Export(typeof(IMatch))]
    internal class Match : IMatch
    {
        [ImportingConstructor]
        public Match(IOutput output, ISettings settings, IRoundFactory roundFactory)
        {
            Output = output ?? throw new ArgumentNullException(nameof(output));
            Settings = settings;
            RoundFactory = roundFactory;
            Winners = new Dictionary<string, int>();
        }

        private Dictionary<string, int> Winners { get; }
        private IOutput Output { get; }
        private ISettings Settings { get; }
        private IRoundFactory RoundFactory { get; }

        public IRound CreateRound() => RoundFactory.Create();

        public Task WaitForNextRoundAsync()
        {
            Output.NextRoundIn(Settings.NextRoundDelay);
            return Task.Delay(Settings.NextRoundDelay);
        }

        public void Process(RoundResult roundResult)
        {
            if (roundResult.WinnerName == null)
            {
                return;
            }
            if (Winners.ContainsKey(roundResult.WinnerName))
            {
                Winners[roundResult.WinnerName]++;
            }
            else
            {
                Winners.Add(roundResult.WinnerName, 1);
            }
            Output.MatchResult(Winners);
        }
    }
}