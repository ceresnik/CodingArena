using CodingArena.Player.Battlefield;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingArena.Game
{
    public interface ITurn
    {
        ITurn StartTurn();
        ITurnController Controller { get; }
        ITurnNotifier Notifier { get; }
    }

    public interface ITurnController
    {
        void Start();
    }

    public interface ITurnNotifier
    {
        int Number { get; }
    }

    public sealed class Turn : ITurn, ITurnController, ITurnNotifier
    {
        public Turn(int number, ICollection<Bot> bots, IBattlefieldView battlefield)
        {
            Number = number;
            Bots = bots ?? throw new ArgumentNullException(nameof(bots));
            Battlefield = battlefield ?? throw new ArgumentNullException(nameof(battlefield));
        }

        public int Number { get; }

        private ICollection<Bot> Bots { get; }

        private IBattlefieldView Battlefield { get; }

        public ITurn StartTurn()
        {
            if (Bots.Count > 1)
            {
                foreach (var bot in Bots)
                {
                    var enemies = Bots.Except(new[] { bot }).ToList();
                    bot.ExecuteTurnAction(enemies); // TODO: consider change to async
                }
                var remainingBots = Bots.Except(Bots.Where(b => b.Damage > 100f)).ToList();
                return new Turn(Number + 1, remainingBots, Battlefield);
            }
            return new Turn(Number + 1, Bots, Battlefield);
        }

        public ITurnController Controller => this;

        public ITurnNotifier Notifier => this;

        public void Start()
        {
        }
    }
}