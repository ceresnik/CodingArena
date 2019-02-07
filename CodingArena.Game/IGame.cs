using System;

namespace CodingArena.Game
{
    public interface IGame
    {
        void Start();
        IMatch Match { get; }
        event EventHandler MatchStarting;
        event EventHandler MatchFinished;
    }
}