using System;
using CodingArena.Player.Battlefield;

namespace CodingArena.Player
{
    public interface IOwnBot : IBot
    {
        /// <summary>
        ///     Gets a value of maximum health points for own bot.
        /// </summary>
        int MaxHP { get; }

        /// <summary>
        ///     Gets a value of current health points count for your bot.
        /// </summary>
        int HP { get; }

        /// <summary>
        ///     Gets a value of maximum shield points for own bot.
        /// </summary>
        int MaxSP { get; }

        /// <summary>
        ///     Gets a value of current shield points count for your bot.
        /// </summary>
        int SP { get; }

        /// <summary>
        ///     Gets a value of maximum energy points for own bot.
        /// </summary>
        int MaxEP { get; }

        /// <summary>
        ///     Gets a value of current energy points count for your bot.
        /// </summary>
        int EP { get; }

        /// <summary>
        ///     Gets a position on battlefield for your bot.
        /// </summary>
        IBattlefieldPlace Position { get; }

        /// <summary>
        ///     Gets a distance from position of your bot to specified <paramref name="enemy"/>.
        /// </summary>
        /// <param name="enemy">The enemy.</param>
        /// <returns>A distance from own bot to specified enemy.</returns>
        /// <exception cref="ArgumentNullException">
        ///     Throws when <paramref name="enemy"/> is <c>null</c>.
        /// </exception>
        double DistanceTo(IEnemy enemy);
    }
}