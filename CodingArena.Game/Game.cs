using CodingArena.Game.Factories;
using System;
using System.ComponentModel.Composition;

namespace CodingArena.Game
{
    [Export(typeof(IGame))]
    internal sealed class Game : IGame, IGameNotifier, IGameController
    {
        private IMatchFactory MatchFactory { get; }

        private IMatch Match { get; set; }

        [ImportingConstructor]
        public Game(IMatchFactory matchFactory)
        {
            MatchFactory = matchFactory;
        }

        public IGameController Controller => this;

        public IGameNotifier Notifier => this;

        public void Start()
        {
            Match = MatchFactory.Create();
            OnMatchStarting(new MatchEventArgs(Match.Notifier));
            Match.Controller.Start();
            OnMatchStarted(new MatchEventArgs(Match.Notifier));
        }

        public event EventHandler<MatchEventArgs> MatchStarting;

        public event EventHandler<MatchEventArgs> MatchStarted;

        private void OnMatchStarting(MatchEventArgs e) => MatchStarting?.Invoke(this, e);

        private void OnMatchStarted(MatchEventArgs e) => MatchStarted?.Invoke(this, e);
    }
}