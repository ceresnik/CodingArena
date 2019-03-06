using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodingArena.Game.Entities
{
    public interface IMatch
    {
        IRound Round { get; }
        IEnumerable<Score> Scores { get; }
        TimeSpan NextRoundIn { get; }
        Task StartAsync();
        event EventHandler RoundStarting;
        event EventHandler RoundFinished;
        event EventHandler NextRoundInUpdated;
    }
}