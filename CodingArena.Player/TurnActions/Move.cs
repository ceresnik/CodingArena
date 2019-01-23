namespace CodingArena.Player.TurnActions
{
    public sealed class Move : ITurnAction
    {
        internal Move(Direction direction)
        {
            Direction = direction;
        }

        public int EnergyCost => 1;

        public Direction Direction { get; }
    }
}