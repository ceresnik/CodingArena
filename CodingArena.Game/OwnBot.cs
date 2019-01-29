using CodingArena.Player;
using System;

namespace CodingArena.Game
{
    internal class OwnBot : IOwnBot, IEquatable<OwnBot>
    {
        public OwnBot(Bot bot)
        {
            Bot = bot;
        }

        public string Name => Bot.Name;
        public float Damage => Bot.Damage;
        public float Shield => Bot.Shield;
        public float Energy => Bot.Energy;
        private Bot Bot { get; }

        public override string ToString() => $"Own bot: {Name}";

        public bool Equals(OwnBot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Bot, other.Bot);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OwnBot)obj);
        }

        public override int GetHashCode() => Bot != null ? Bot.GetHashCode() : 0;

        public static bool operator ==(OwnBot left, OwnBot right) => Equals(left, right);

        public static bool operator !=(OwnBot left, OwnBot right) => !Equals(left, right);
    }
}