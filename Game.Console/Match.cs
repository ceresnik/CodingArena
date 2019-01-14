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

        public Task WaitForNextRoundAsync() => 
            Task.Delay(config.DelayForNextRound);
    }
}