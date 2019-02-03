using CodingArena.Game.Factories;
using System;
using System.ComponentModel.Composition;

namespace CodingArena.Game
{
    public interface IGameEngine
    {
        void Start();
        IMatch Match { get; }
    }

    public interface IGameNotifier
    {
        event EventHandler<GameStartingEventArgs> Started;
    }

    public class GameStartingEventArgs
    {
        public IMatchNotifier MatchNotifier { get; }

        public GameStartingEventArgs(IMatchNotifier matchNotifier)
        {
            MatchNotifier = matchNotifier;
        }
    }

    [Export(typeof(IGameEngine))]
    [Export(typeof(IGameNotifier))]
    internal sealed class GameEngine : IGameEngine, IGameNotifier
    {
        private IMatchFactory MatchFactory { get; }

        public void Start()
        {
            Match = MatchFactory.Create();
            OnStarted(Match.Notifier);
        }

        public IMatch Match { get; private set; }

        [ImportingConstructor]
        public GameEngine(IMatchFactory matchFactory)
        {
            MatchFactory = matchFactory;
            Match = matchFactory.Create();
        }

        public event EventHandler<GameStartingEventArgs> Started;

        private void OnStarted(IMatchNotifier matchNotifier) =>
            Started?.Invoke(this, new GameStartingEventArgs(matchNotifier));
    }
}