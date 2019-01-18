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
            public static ITurnAction Battery() => new RechargeBatteryTurnAction();
            public static ITurnAction Shield() => new RechargeShieldTurnAction();
        }

        public static ITurnAction Idle() => new IdleTurnAction();
    }
}