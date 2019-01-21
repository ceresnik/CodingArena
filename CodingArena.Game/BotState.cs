using System;
using CodingArena.Player;

namespace CodingArena.Game
{
    internal class BotState : IBotState
    {
        public BotState(IValueState health, IValueState shield, IValueState energy)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
            Shield = shield ?? throw new ArgumentNullException(nameof(shield));
            Energy = energy ?? throw new ArgumentNullException(nameof(energy));
        }

        public IValueState Health { get; }

        public IValueState Shield { get; }

        public IValueState Energy { get; }
    }
}