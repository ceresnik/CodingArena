using System;
using System.Collections.Generic;

namespace CodingArena.Game
{
    public interface IMatch
    {
        IRound Round { get; }
        IEnumerable<Score> Scores { get; }
        void Start();
        event EventHandler RoundStarting;
        event EventHandler RoundFinished;
    }
}