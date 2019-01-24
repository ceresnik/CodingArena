namespace CodingArena.Game
{
    internal class GameEngine
    {
        private readonly GameConfiguration configuration;
        private readonly IOutput output;

        public GameEngine(GameConfiguration configuration, IOutput output)
        {
            this.configuration = configuration;
            this.output = output;
        }

        public IMatch CreateMatch() => new Match(output, configuration);
    }
}