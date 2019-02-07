using System;

namespace CodingArena.Game.Entities
{
    public interface IGame
    {
        void Start();
        IMatch Match { get; }
        event EventHandler MatchStarting;
        event EventHandler MatchFinished;
    }
}