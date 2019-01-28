using System.ComponentModel.Composition;

namespace CodingArena.Game
{
    [Export(typeof(IGameEngine))]
    internal class GameEngine : IGameEngine
    {
        private IOutput Output { get; }
        private ISettings Settings { get; }

        [ImportingConstructor]
        public GameEngine(IOutput output, ISettings settings)
        {
            Output = output;
            Settings = settings;
        }

        public IMatch CreateMatch() => new Match(Output, Settings);
    }
}