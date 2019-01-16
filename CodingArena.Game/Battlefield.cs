using CodingArena.Player;

namespace CodingArena.Game
{
    internal class Battlefield : IBattlefield
    {
        public Size Size { get; }

        public Battlefield(Size size)
        {
            Size = size;
        }
    }
}