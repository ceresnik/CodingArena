using System;
using System.Collections.Generic;
using CodingArena.Player;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    internal class Turn : ITurn
    {
        public Turn(IReadOnlyCollection<IEnemy> enemies, Battlefield battlefield)
        {
            Enemies = enemies;
            Battlefield = battlefield ?? throw new ArgumentNullException(nameof(battlefield));
        }

        public IReadOnlyCollection<IEnemy> Enemies { get; }
        public IBattlefield Battlefield { get; }
    }
}