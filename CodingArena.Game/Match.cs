using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodingArena.Game
{
    public class Match : IMatch
    {
        public Match(IOutput output, GameConfiguration config)
        {
            Output = output ?? throw new ArgumentNullException(nameof(output));
            Config = config ?? throw new ArgumentNullException(nameof(config));
            Winners = new Dictionary<string, int>();
        }

        private Dictionary<string, int> Winners { get; }
        private IOutput Output { get; }
        private GameConfiguration Config { get; }

        public Task<IRound> CreateRoundAsync() => 
            Task.FromResult<IRound>(new Round(Output));

        public Task WaitForNextRoundAsync()
        {
            Output.NextRoundIn(Config.DelayForNextRound);
            return Task.Delay(Config.DelayForNextRound);
        }

        public void Process(RoundResult roundResult)
        {
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