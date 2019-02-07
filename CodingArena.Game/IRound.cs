using System;
using System.Collections.Generic;

namespace CodingArena.Game
{
    public interface IRound
    {
        int Number { get; }
        IEnumerable<IBattleBot> Bots { get; }
        IBattlefield Battlefield { get; }
        ITurn Turn { get; }
        IEnumerable<Score> Scores { get; }
        void Start();
        event EventHandler TurnStarting;
        event EventHandler TurnFinished;
    }
}