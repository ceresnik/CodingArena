using System;
using System.Collections.Generic;
using CodingArena.Player.Exceptions;

namespace CodingArena.Player.Battlefield
{
    /// <summary>
    /// A view on the battlefield from bot perspective.
    /// </summary>
    public interface IBattlefieldView
    {
        /// <summary>
        ///     Gets a width of the battlefield.
        /// </summary>
        int Width { get; }

        /// <summary>
        ///     Gets a height of the battlefield.
        /// </summary>
        int Height { get; }

        /// <summary>
        ///     Gets a read-only collection of objects placed on the battlefield.
        /// </summary>
        IReadOnlyCollection<IBattlefieldObject> Objects { get; }

        /// <summary>
        ///     Gets a place on the battlefield specified by coordinates.
        /// </summary>
        /// <param name="x">X-axis coordinate.</param>
        /// <param name="y">Y-axis coordinate.</param>
        /// <returns>A place on the battlefield.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when specified <paramref name="x"/> or <paramref name="y"/> is out of battlefield range.
        /// </exception>
        IBattlefieldPlace this[int x, int y] { get; }

        /// <summary>
        ///     Gets a place on the battlefield for the specified battlefield object or throws exception.
        /// </summary>
        /// <param name="battlefieldObject">An object on the battlefield.</param>
        /// <returns>A place for <paramref name="battlefieldObject"/> on the battlefield.</returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="battlefieldObject"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="BattlefieldPlaceNotFoundException">
        ///     Thrown when <paramref name="battlefieldObject"/> does not have a place on battlefield.
        /// </exception>
        IBattlefieldPlace this[IBattlefieldObject battlefieldObject] { get; }

        /// <summary>
        ///     Gets a value whether specified battlefield place is empty or not.
        /// </summary>
        /// <param name="battlefieldPlace">A place on the battlefield.</param>
        /// <returns><c>true</c> if place is empty; otherwise <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="battlefieldPlace"/> is <c>null</c>.</exception>
        bool IsEmpty(IBattlefieldPlace battlefieldPlace);
    }
}