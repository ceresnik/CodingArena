using CodingArena.Player;

namespace CodingArena.Game
{
    internal class Enemy : IEnemy
    {
        public Enemy(string name, IValueState health, IValueState shield)
        {
            Name = name;
            Health = health;
            Shield = shield;
        }

        public string Name { get; }

        public IValueState Health { get; }

        public IValueState Shield { get; }
    }
}