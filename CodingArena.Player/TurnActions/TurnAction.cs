namespace CodingArena.Player.TurnActions
{
    public interface ITurnAction
    {
    }

    public static partial class TurnAction
    {
        public sealed partial class Move : ITurnAction
        {
        }

        public sealed partial class Attack : ITurnAction
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