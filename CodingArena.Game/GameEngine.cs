using System.ComponentModel.Composition;
using CodingArena.Game.Factories;

namespace CodingArena.Game
{
    public interface IGameEngine
    {
        IMatch CreateMatch();
    }

    [Export(typeof(IGameEngine))]
    internal class GameEngine : IGameEngine
    {
        private IMatchFactory MatchFactory { get; }

        [ImportingConstructor]
        public GameEngine(IMatchFactory matchFactory)
        {
            MatchFactory = matchFactory;
        }

        public IMatch CreateMatch() => MatchFactory.Create();
    }
}