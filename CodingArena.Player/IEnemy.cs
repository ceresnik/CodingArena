using System;
using CodingArena.Player.Battlefield;

namespace CodingArena.Player
{
    public interface IEnemy : IBot
    {
        /// <summary>
        ///     Gets an access to health properties for your bot.
        /// </summary>
        IHealth Health { get; }

        /// <summary>
        ///     Gets an access to shield properties for your bot.
        /// </summary>
        IShield Shield { get; }

        /// <summary>
        ///     Gets a value of current energy points count for enemy bot.
        /// </summary>
        IBattlefieldPlace Position { get; }

        /// <summary>
        ///     Gets a distance from position of this enemy bot to another <paramref name="enemy"/>.
        /// </summary>
        /// <param name="enemy">The enemy.</param>
        /// <returns>A distance from this enemy to another enemy.</returns>
        /// <exception cref="ArgumentNullException">
        ///     Throws when <paramref name="enemy"/> is <c>null</c>.
        /// </exception>
        double DistanceTo(IEnemy enemy);
    }
}