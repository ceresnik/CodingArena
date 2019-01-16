namespace CodingArena.Game.Console
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