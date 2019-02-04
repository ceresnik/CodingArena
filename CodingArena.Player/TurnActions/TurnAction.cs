using CodingArena.Player.Battlefield;
using System;

namespace CodingArena.Player.TurnActions
{
    public static class TurnAction
    {
        /// <summary>
        ///     Creates a turn action to attack specified <paramref name="enemy"/>.
        /// </summary>
        /// <param name="enemy">The enemy to be attacked.</param>
        /// <returns>Turn action to attack specified <paramref name="enemy"/>.</returns>
        /// <exception cref="ArgumentNullException">
        ///     Throws when <paramref name="enemy"/> is <c>null</c>.
        /// </exception>
        public static ITurnAction Attack(IEnemy enemy) => new Attack(enemy);

        public class Move
        {
            /// <summary>
            ///     Creates a turn action to move north. 
            /// Make sure that north is valid place on battlefield; otherwise bot will explode.
            /// </summary>
            /// <returns>Turn action to move north.</returns>
            public static ITurnAction North() => new TurnActions.Move(Direction.North);

            /// <summary>
            ///     Creates a turn action to move east. 
            /// Make sure that east is valid place on battlefield; otherwise bot will explode.
            /// </summary>
            /// <returns>Turn action to move east.</returns>
            public static ITurnAction East() => new TurnActions.Move(Direction.East);

            /// <summary>
            ///     Creates a turn action to move west. 
            /// Make sure that west is valid place on battlefield; otherwise bot will explode.
            /// </summary>
            /// <returns>Turn action to move west.</returns>
            public static ITurnAction West() => new TurnActions.Move(Direction.West);

            /// <summary>
            ///     Creates a turn action to move south. 
            /// Make sure that south is valid place on battlefield; otherwise bot will explode.
            /// </summary>
            /// <returns>Turn action to move south.</returns>
            public static ITurnAction South() => new TurnActions.Move(Direction.South);

            /// <summary>
            ///     Creates a turn action to move towards <paramref name="from"/> 
            /// one battlefield place <paramref name="to"/> another place.
            /// </summary>
            /// <returns>Turn action to move towards specified palce.</returns>
            /// <exception cref="ArgumentNullException">
            ///     Throws when <paramref name="from"/> or <paramref name="to"/> is <c>null</c>.
            /// </exception>
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