namespace CodingArena.Player.TurnActions
{
    public sealed class MoveTurnAction : ITurnAction
    {
        internal MoveTurnAction(Direction direction)
        {
            Direction = direction;
        }

        public int EnergyCost => 1;

        public Direction Direction { get; }
    }
}