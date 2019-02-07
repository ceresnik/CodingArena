using System;
using CodingArena.Player.Battlefield;

namespace CodingArena.Player
{
    public interface IOwnBot : IBot
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
        ///     Gets an access to energy properties for your bot.
        /// </summary>
        IEnergy Energy { get; }

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