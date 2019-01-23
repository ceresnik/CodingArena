using System.Collections.Generic;
using CodingArena.Player.Battlefield;
using CodingArena.Player.TurnActions;

namespace CodingArena.Player.Implement
{
    public interface IBotAI
    {
        /// <summary>
        /// Gets a name identification for the bot.
        /// Could not be <c>null</c>, <c>empty</c> or <c>whitespace</c>.
        /// </summary>
        string BotName { get; }

        /// <summary>
        /// Returns a turn action for the specified input parameters.
        /// </summary>
        /// <param name="ownBot">Your own bot.</param>
        /// <param name="enemies">Enemy bots.</param>
        /// <param name="battlefield">Battlefield.</param>
        /// <returns>Turn action that is used in actual turn to battle against other enemy bots.</returns>
        ITurnAction GetTurnAction(IOwnBot ownBot, IReadOnlyCollection<IEnemy> enemies, IBattlefield battlefield);
    }
}