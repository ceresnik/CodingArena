using System;
using CodingArena.Player.Battlefield;

namespace CodingArena.Player.TurnActions
{
    public static partial class TurnAction
    {
        public static ITurnAction Attack(IEnemy enemy) => new AttackTurnAction(enemy);

        public class Move
        {
            public static ITurnAction North() => new MoveTurnAction(Direction.North);
            public static ITurnAction East() => new MoveTurnAction(Direction.East);
            public static ITurnAction West() => new MoveTurnAction(Direction.West);
            public static ITurnAction South() => new MoveTurnAction(Direction.South);

            public static ITurnAction Towards(IBattlefieldPlace from, IBattlefieldPlace to)
            {
                int difX = to.X - from.X;
                int difY = to.Y - from.Y;

                if (difX == 0 && difY == 0) return new MoveTurnAction(Direction.None);

                if (difX > 0 && difY == 0) return East();
                if (difX < 0 && difY == 0) return West();

                if (difX == 0 && difY > 0) return South();
                if (difX == 0 && difY < 0) return North();

                if (difX > 0 && difY > 0 && difX > difY) return East();
                if (difX > 0 && difY > 0 && difX < difY) return South();

                if (difX < 0 && difY > 0 && Math.Abs(difX) > difY) return West();
                if (difX < 0 && difY > 0 && Math.Abs(difX) < difY) return South();

                if (difX < 0 && difY < 0 && Math.Abs(difX) > Math.Abs(difY)) return West();
                if (difX < 0 && difY < 0 && Math.Abs(difX) < Math.Abs(difY)) return North();

                if (difX > 0 && difY < 0 && difX > Math.Abs(difY)) return East();
                if (difX > 0 && difY < 0 && difX < Math.Abs(difY)) return North();

                throw new NotSupportedException();
            }
        }

        public static class Recharge
        {
            public static ITurnAction Battery() => new RechargeBatteryTurnAction();
            public static ITurnAction Shield() => new RechargeShieldTurnAction();
        }

        public static ITurnAction Idle() => new IdleTurnAction();
    }
}