namespace CodingArena.Player
{
    public interface ITurnAction
    {
    }

    public static class TurnAction
    {
        public sealed class Move : ITurnAction
        {
            private Move(Direction direction)
            {
                Direction = direction;
            }

            public static Move North() => new Move(Direction.North);

            public static Move East() => new Move(Direction.East);

            public static Move West() => new Move(Direction.West);

            public static Move South() => new Move(Direction.South);

            public Direction Direction { get; }
        }

        public sealed class Attack : ITurnAction
        {
        }

        public static class Recharge
        {
            public sealed class Battery : ITurnAction
            {
            }

            public sealed class Shield : ITurnAction
            {
            }
        }
    }
}