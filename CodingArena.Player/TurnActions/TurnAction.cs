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
            /// Move towards a specified target <paramref name="place"/>.
            /// Move direction is calculated to find shortest path <paramref name="place"/>.
            /// </summary>
            /// <param name="place">A target place to move.</param>
            /// <returns>
            ///     Turn action to move towards a specified <paramref name="place"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">If parameter <paramref name="place"/> is <c>null</c>.</exception>
            public static ITurnAction Towards(IBattlefieldPlace place) =>
                new MoveTowards(place);

            /// <summary>
            /// Move away from a specified <paramref name="place"/>.
            /// Move direction is calculated to find place
            /// which is farthest from specified <paramref name="place"/>.
            /// </summary>
            /// <param name="place">A place to move away from.</param>
            /// <returns>
            ///     Turn action to move away from a specified <paramref name="place"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">If parameter <paramref name="place"/> is <c>null</c>.</exception>
            public static ITurnAction AwayFrom(IBattlefieldPlace place) =>
                new MoveAwayFrom(place);
        }

        /// <summary>
        ///     An access to recharge turn actions.
        /// </summary>
        public static class Recharge
        {
            /// <summary>
            ///     Gets a turn action to recharge battery.
            /// </summary>
            /// <returns>A turn action.</returns>
            public static ITurnAction Battery() => new RechargeBattery();

            /// <summary>
            ///     Gets a turn action to recharge shield with specified <paramref name="amount"/>.
            /// </summary>
            /// <param name="amount">
            ///     An amount of shield points to be recharged. Must be positive value.
            /// Shield points are recharged from energy points in ratio 1:1.
            /// The <paramref name="amount"/> value is limited by current energy points. 
            /// Be careful not to deplete all the energy points!
            /// </param>
            /// <returns>A turn action.</returns>
            /// <exception cref="ArgumentOutOfRangeException">
            ///     Throws when specified <paramref name="amount"/> is out of range.
            /// </exception>
            public static ITurnAction Shield(int amount) => new RechargeShield(amount);
        }

        public static ITurnAction Idle() => new Idle();
    }
}