using System;
using System.IO;
using System.Threading.Tasks;

namespace CodingArena.Game
{
    internal class Match : IMatch
    {
        public Match(TextWriter output, GameConfiguration config)
        {
            Output = output ?? throw new ArgumentNullException(nameof(output));
            Config = config ?? throw new ArgumentNullException(nameof(config));
        }

        private TextWriter Output { get; }
        private GameConfiguration Config { get; }

        public Task<IRound> CreateRoundAsync() => 
            Task.FromResult<IRound>(new Round(Output));

        public Task WaitForNextRoundAsync()
        {
            Output.WriteLine($"Next round in {Config.DelayForNextRound:g}");
            Output.WriteLine("Waiting for next round...");
            return Task.Delay(Config.DelayForNextRound);
        }

        public void Process(RoundResult roundResult)
        {            
        }
    }
}