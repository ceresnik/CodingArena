using System;

namespace CodingArena.Game
{
    internal class BotState
    {
        public BotState(ValueState health, ValueState shield, ValueState energy)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
            Shield = shield ?? throw new ArgumentNullException(nameof(shield));
            Energy = energy ?? throw new ArgumentNullException(nameof(energy));
        }

        public ValueState Health { get; }

        public ValueState Shield { get; }

        public ValueState Energy { get; }
    }
}