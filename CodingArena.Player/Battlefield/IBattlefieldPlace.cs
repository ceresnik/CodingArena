using System;

namespace CodingArena.Player.Battlefield
{
    /// <summary>
    /// A representation of place on the battlefield.
    /// </summary>
    public interface IBattlefieldPlace
    {
        /// <summary>
        ///     Gets a X-axis coordinate of place on the battlefield.
        /// </summary>
        int X { get; }

        /// <summary>
        ///     Gets a Y-axis coordinate of place on the battlefield.
        /// </summary>
        int Y { get; }

        /// <summary>
        ///     Gets a value whether specified <see cref="IBattlefieldPlace"/> is empty or not;
        /// </summary>
        /// <returns>
        ///     <c>true</c> if <see cref="Object"/> is <c>null</c>; otherwise <c>false</c>.
        /// </returns>
        bool IsEmpty { get; }

        /// <summary>
        ///     Gets an object that is standing on this <see cref="IBattlefieldPlace"/> or <c>null</c> if empty.
        /// </summary>
        /// <seealso cref="IsEmpty"/>
        IBattlefieldObject Object { get; }

        /// <summary>
        ///     Gets a distance from this place to other place on the battlefield specified by coordinates.
        /// </summary>
        /// <param name="x">X-axis coordinate of other place on the battlefield.</param>
        /// <param name="y">Y-axis coordinate of other place on the battlefield.</param>
        /// <returns>Returns a distance from this place to other place on the battlefield.</returns>
        double DistanceTo(int x, int y);

        /// <summary>
        ///     Gets a distance from this place to other specified battlefield place.
        /// </summary>
        /// <param name="place">A place on the battlefield.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="place"/> is <c>null</c>.
        /// </exception>
        double DistanceTo(IBattlefieldPlace place);
    }
}