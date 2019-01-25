using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    internal sealed class BattlefieldSize : IBattlefieldSize
    {
        public BattlefieldSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; }

        public int Height { get; }

        public override string ToString() => $"[{nameof(Width)}: {Width}, {nameof(Height)}: {Height}]";
    }
}
