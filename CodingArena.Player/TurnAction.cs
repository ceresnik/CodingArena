using System;
using CodingArena.Player.Battlefield;

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

            public static Move Towards(IBattlefieldPlace from, IBattlefieldPlace to)
            {
                int difX = to.X - from.X;
                int difY = to.Y - from.Y;

                if (difX == 0 && difY == 0) return new Move(Direction.None);

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
            
            public Direction Direction { get; }
        }

        public sealed class Attack : ITurnAction
        {
            private Attack(IEnemy enemy)
            {
                Enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            }

            public static Attack Target(IEnemy enemy) => new Attack(enemy);

            public IEnemy Enemy { get; }
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