namespace CodingArena.Player.TurnActions
{
    public sealed class MoveTurnAction : ITurnAction
    {
        internal MoveTurnAction(Direction direction)
        {
            Direction = direction;
        }

        public Direction Direction { get; }
    }
}