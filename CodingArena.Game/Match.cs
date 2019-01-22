using System.IO;
using System.Threading.Tasks;

namespace CodingArena.Game
{
    internal class Match : IMatch
    {
        private readonly GameConfiguration config;
        private readonly TextWriter textWriter;

        public Match(GameConfiguration config, TextWriter textWriter)
        {
            this.config = config;
            this.textWriter = textWriter;
        }

        public Task<IRound> CreateRoundAsync() => 
            Task.FromResult<IRound>(new Round(textWriter));

        public Task WaitForNextRoundAsync()
        {
            textWriter.WriteLine($"Next round in {config.DelayForNextRound:g}");
            textWriter.WriteLine("Waiting for next round...");
            return Task.Delay(config.DelayForNextRound);
        }

        public void Process(RoundResult roundResult)
        {            
        }
    }
}