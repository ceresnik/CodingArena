using System;
using System.ComponentModel.Composition;
using CodingArena.Game.Factories;

namespace CodingArena.Game.Internal
{
    [Export(typeof(IGame))]
    internal sealed class Game : IGame
    {
        private IMatchFactory MatchFactory { get; }

        [ImportingConstructor]
        public Game(IMatchFactory matchFactory)
        {
            MatchFactory = matchFactory;
        }

        public void Start()
        {
            Match = MatchFactory.Create();
            OnMatchStarting();
            Match.Start();
            OnMatchFinished();
        }

        public IMatch Match { get; private set; }
        public event EventHandler MatchStarting;
        public event EventHandler MatchFinished;
        private void OnMatchStarting() => MatchStarting?.Invoke(this, EventArgs.Empty);
        private void OnMatchFinished() => MatchFinished?.Invoke(this, EventArgs.Empty);
    }
}