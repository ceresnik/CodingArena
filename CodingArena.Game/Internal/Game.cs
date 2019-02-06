using System.ComponentModel.Composition;
using CodingArena.Game.Factories;

namespace CodingArena.Game.Internal
{
    [Export(typeof(IGame))]
    internal class Game : IGame
    {
        private IMatchFactory MatchFactory { get; }

        [ImportingConstructor]
        public Game(IMatchFactory matchFactory)
        {
            MatchFactory = matchFactory;
        }

        public void Start()
        {
            var match = MatchFactory.Create();
            match.Start();
        }
    }
}