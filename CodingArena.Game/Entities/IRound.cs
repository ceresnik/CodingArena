using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodingArena.Game.Entities
{
    public interface IRound
    {
        int Number { get; }

        IEnumerable<IBattleBot> Bots { get; }

        IBattlefield Battlefield { get; }

        ITurn Turn { get; }

        IEnumerable<Score> Scores { get; }

        Task StartAsync();

        event EventHandler TurnStarting;

        event EventHandler TurnFinished;
    }
}