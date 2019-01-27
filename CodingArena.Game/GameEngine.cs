using System.ComponentModel.Composition;

namespace CodingArena.Game
{
    public interface IGameEngine
    {
        IMatch CreateMatch();
    }

    [Export(typeof(IGameEngine))]
    internal class GameEngine : IGameEngine
    {
        private IOutput Output { get; }
        private ISettings Settings { get; }

        public GameEngine(IOutput output, ISettings settings)
        {
            Output = output;
            Settings = settings;
        }

        public IMatch CreateMatch() => new Match(Output, Settings);
    }
}