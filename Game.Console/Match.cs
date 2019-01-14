using System.IO;
using System.Threading.Tasks;

namespace Game.Console
{
    internal class Match : IMatch
    {
        private readonly GameConfiguration config;

        public Match(GameConfiguration config)
        {
            this.config = config;
        }

        public Task<IRound> CreateRoundAsync() => 
            Task.FromResult<IRound>(new Round());

        public Task WaitForNextRoundAsync(TextWriter textWriter)
        {
            textWriter.WriteLine($"Next round in {config.DelayForNextRound:g}");
            textWriter.WriteLine("Waiting for next round...");
            return Task.Delay(config.DelayForNextRound);
        }
    }
}