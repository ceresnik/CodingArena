using System;
using CodingArena.Player;

namespace CodingArena.Game
{
    internal class Enemy : Robot, IEnemy
    {
        public Enemy(string name, int maxHP, int hp, int maxSP, int sp) : base(maxHP, hp, maxSP, sp)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "Value cannot be null or whitespace.", nameof(name));
            Name = name;
        }

        public string Name { get; }
    }
}