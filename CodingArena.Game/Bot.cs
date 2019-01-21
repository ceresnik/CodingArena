using System;
using CodingArena.Player.Implement;

namespace CodingArena.Game
{
    internal class Bot
    {
        private readonly IBotAI ai;
        private readonly Battlefield battlefield;

        public Bot(string name, IBotAI ai, BotState state, Battlefield battlefield)
        {
            this.ai = ai ?? throw new ArgumentNullException(nameof(ai));
            this.battlefield = battlefield ?? throw new ArgumentNullException(nameof(battlefield));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            State = state ?? throw new ArgumentNullException(nameof(state));
        }

        public string Name { get; }

        public IBotAI AI { get; }

        public BotState State { get; }

        public void Execute(Turn turn)
        {
            // TODO
        }
    }
}