using System;

namespace CodingArena.Game
{
    public interface IGame
    {
        IGameController Controller { get; }
        IGameNotifier Notifier { get; }
    }

    public interface IGameController
    {
        void Start();
    }

    public interface IGameNotifier
    {
        event EventHandler<MatchEventArgs> MatchStarting;
        event EventHandler<MatchEventArgs> MatchStarted;
    }
}