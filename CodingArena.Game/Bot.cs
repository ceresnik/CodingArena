using System;
using System.Collections.Generic;
using CodingArena.Player;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;

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

        public void Execute(IEnumerable<IEnemy> enemies)
        {
            var turnAction = ai.CreateTurnAction(State, enemies, battlefield);
            if (turnAction is MoveTurnAction move)
            {
                switch (move.Direction)
                {
                    case Direction.West:
                        
                        break;
                }
            }
        }
    }
}