using System;
using CodingArena.Player.Battlefield;

namespace CodingArena.Player
{
    public interface IEnemy : IBot
    {
        /// <summary>
        ///     Gets a value of maximum health points for enemy bot.
        /// </summary>
        int MaxHP { get; }
        /// <summary>
        ///     Gets a value of current health points count for enemy bot.
        /// </summary>
        int HP { get; }

        /// <summary>
        ///     Gets a value of maximum shield points for enemy bot.
        /// </summary>
        int MaxSP { get; }
        /// <summary>
        ///     Gets a value of current shield points count for enemy bot.
        /// </summary>
        int SP { get; }

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