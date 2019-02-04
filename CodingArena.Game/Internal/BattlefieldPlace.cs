using CodingArena.Player.Battlefield;
using System;

namespace CodingArena.Game.Internal
{
    internal sealed class BattlefieldPlace :
        IBattlefieldPlace,
        IEquatable<BattlefieldPlace>,
        IEquatable<IBattlefieldPlace>
    {
        public BattlefieldPlace(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public double DistanceTo(int x, int y) =>
            Math.Sqrt(Math.Pow(x - X, 2) + Math.Pow(y - Y, 2));

        public double DistanceTo(IBattlefieldPlace place)
        {
            if (place == null)
            {
                throw new ArgumentNullException(nameof(place));
            }

            return DistanceTo(place.X, place.Y);
        }

        public override string ToString() => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";

        public bool Equals(IBattlefieldPlace other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public bool Equals(BattlefieldPlace other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is BattlefieldPlace other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public static bool operator ==(BattlefieldPlace left, BattlefieldPlace right) => Equals(left, right);

        public static bool operator !=(BattlefieldPlace left, BattlefieldPlace right) => !Equals(left, right);
    }
}