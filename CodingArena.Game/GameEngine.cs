using CodingArena.Game.Factories;
using System.ComponentModel.Composition;

namespace CodingArena.Game
{
    public interface IGameEngine
    {
        IMatch Match { get; }
    }

    [Export(typeof(IGameEngine))]
    internal class GameEngine : IGameEngine
    {
        private IMatchFactory MatchFactory { get; }

        public IMatch Match { get; }

        [ImportingConstructor]
        public GameEngine(IMatchFactory matchFactory)
        {
            MatchFactory = matchFactory;
            Match = matchFactory.Create();
        }
    }
}