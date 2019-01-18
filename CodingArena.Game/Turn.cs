using System;
using System.Collections.Generic;
using CodingArena.Player;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    internal class Turn : ITurn
    {
        public Turn(IMyRobot robot, IReadOnlyCollection<IEnemy> enemies, IBattlefield battlefield)
        {
            MyRobot = robot ?? throw new ArgumentNullException(nameof(robot));
            Enemies = enemies ?? throw new ArgumentNullException(nameof(enemies));
            Battlefield = battlefield ?? throw new ArgumentNullException(nameof(battlefield));
        }

        public IMyRobot MyRobot { get; }
        public IReadOnlyCollection<IEnemy> Enemies { get; }
        public IBattlefield Battlefield { get; }
    }
}