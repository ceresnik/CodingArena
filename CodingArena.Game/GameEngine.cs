namespace CodingArena.Game
{
    internal class GameEngine
    {
        private readonly GameConfiguration configuration;
        private readonly Output output;

        public GameEngine(GameConfiguration configuration, Output output)
        {
            this.configuration = configuration;
            this.output = output;
        }

        public IMatch CreateMatch() => new Match(output, configuration);
    }
}