using System;

namespace CodingArena.Player.Battlefield
{
    public sealed class Size
    {
        public Size(int width, int height)
        {
            if (width <= 0)
                throw new ArgumentException("Value must be positive number.", nameof(width));
            if (height <= 0)
                throw new ArgumentException("Value must be positive number.", nameof(width));
            Width = width;
            Height = height;
        }

        public int Width { get; }

        public int Height { get; }

        public override string ToString() => $"[{nameof(Width)}: {Width}, {nameof(Height)}: {Height}]";

        private bool Equals(Size other) => Width == other.Width && Height == other.Height;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Size other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Width * 397) ^ Height;
            }
        }
    }
}
