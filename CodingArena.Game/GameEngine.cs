namespace CodingArena.Game
{
    internal class GameEngine
    {
        private ISettings Settings { get; }
        private readonly GameConfiguration configuration;
        private readonly IOutput output;

        public GameEngine(GameConfiguration configuration, IOutput output, ISettings settings)
        {
            Settings = settings;
            this.configuration = configuration;
            this.output = output;
        }

        public IMatch CreateMatch() => new Match(output, configuration, Settings);
    }
}