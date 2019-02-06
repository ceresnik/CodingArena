using CodingArena.Player.Battlefield;

namespace CodingArena.Player
{
    public interface IOwnBot : IBot
    {
        /// <summary>
        ///     Gets a value of current health points count for your bot.
        /// </summary>
        int HP { get; }

        /// <summary>
        ///     Gets a value of current shield points count for your bot.
        /// </summary>
        int SP { get; }

        /// <summary>
        ///     Gets a value of current energy points count for your bot.
        /// </summary>
        int EP { get; }

        /// <summary>
        ///     Gets a position on battlefield for your bot.
        /// </summary>
        IBattlefieldPlace Position { get; }
    }
}