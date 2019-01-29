using System.ComponentModel.Composition;

namespace CodingArena.Game
{
    [Export(typeof(IGameEngine))]
    internal class DefaultGameEngine : IGameEngine
    {
        private IMatchFactory MatchFactory { get; }

        [ImportingConstructor]
        public DefaultGameEngine(IMatchFactory matchFactory)
        {
            MatchFactory = matchFactory;
        }

        public IMatch CreateMatch() => MatchFactory.Create();
    }
}