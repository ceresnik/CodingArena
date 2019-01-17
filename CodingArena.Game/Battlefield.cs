using CodingArena.Player;
using CodingArena.Player.Battlefield;

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