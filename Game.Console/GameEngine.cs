using System.Threading.Tasks;

namespace Game.Console
{
    internal class GameEngine
    {
        private readonly GameConfiguration config;

        public GameEngine(GameConfiguration configuration)
        {
            config = configuration;
        }

        public IMatch CreateMatch() => new Match();

        public Task WaitForNextRoundAsync() => Task.Delay(config.DelayForNextRound);
    }
}