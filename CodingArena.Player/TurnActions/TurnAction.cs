using System;
using CodingArena.Player.Battlefield;

namespace CodingArena.Player.TurnActions
{
    public static class TurnAction
    {
        public static ITurnAction Attack(IEnemy enemy) => new Attack(enemy);

        public class Move
        {
            public static ITurnAction North() => new TurnActions.Move(Direction.North);
            public static ITurnAction East() => new TurnActions.Move(Direction.East);
            public static ITurnAction West() => new TurnActions.Move(Direction.West);
            public static ITurnAction South() => new TurnActions.Move(Direction.South);

            public static ITurnAction Towards(IBattlefieldPlace from, IBattlefieldPlace to)
            {
                if (from == null) throw new ArgumentNullException(nameof(from));
                if (to == null) throw new ArgumentNullException(nameof(to));

                int difX = to.X - from.X;
                int difY = to.Y - from.Y;

                if (difX == 0 && difY == 0) return new TurnActions.Move(Direction.None);

                if (difX > 0 && difY == 0) return East();
                if (difX < 0 && difY == 0) return West();

                if (difX == 0 && difY > 0) return North();
                if (difX == 0 && difY < 0) return South();

                if (difX > 0 && difY > 0 && difX >= difY) return East();
                if (difX > 0 && difY > 0 && difX <= difY) return North();

                if (difX < 0 && difY > 0 && Math.Abs(difX) >= difY) return West();
                if (difX < 0 && difY > 0 && Math.Abs(difX) <= difY) return North();

                if (difX < 0 && difY < 0 && Math.Abs(difX) >= Math.Abs(difY)) return West();
                if (difX < 0 && difY < 0 && Math.Abs(difX) <= Math.Abs(difY)) return South();

                if (difX > 0 && difY < 0 && difX >= Math.Abs(difY)) return East();
                if (difX > 0 && difY < 0 && difX <= Math.Abs(difY)) return South();

                throw new NotSupportedException();
            }
        }

        public static class Recharge
        {
            public static ITurnAction Battery() => new RechargeBattery();
            public static ITurnAction Shield() => new RechargeShield();
        }

        public static ITurnAction Idle() => new Idle();
    }
}