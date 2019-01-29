using CodingArena.Player;
using System;

namespace CodingArena.Game
{
    internal sealed class Enemy : IEnemy, IEquatable<Enemy>
    {
        public Enemy(Bot bot)
        {
            Bot = bot;
        }

        public string Name => Bot.Name;
        public float Damage => Bot.Damage;
        public float Shield => Bot.Shield;
        private Bot Bot { get; }

        public override string ToString() => $"Enemy: {Name}";

        public bool Equals(Enemy other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Bot, other.Bot);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Enemy)obj);
        }

        public override int GetHashCode() => Bot != null ? Bot.GetHashCode() : 0;

        public static bool operator ==(Enemy left, Enemy right) => Equals(left, right);

        public static bool operator !=(Enemy left, Enemy right) => !Equals(left, right);
    }
}