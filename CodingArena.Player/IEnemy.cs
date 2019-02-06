using CodingArena.Player.Battlefield;

namespace CodingArena.Player
{
    public interface IEnemy : IBot
    {
        /// <summary>
        ///     Gets a value of current health points count for enemy bot.
        /// </summary>
        int HP { get; }

        /// <summary>
        ///     Gets a value of current shield points count for enemy bot.
        /// </summary>
        int SP { get; }

        /// <summary>
        ///     Gets a value of current energy points count for enemy bot.
        /// </summary>
        IBattlefieldPlace Position { get; }
    }
}