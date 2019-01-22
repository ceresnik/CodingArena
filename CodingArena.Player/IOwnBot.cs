namespace CodingArena.Player
{
    public interface IOwnBot : IBot
    {
        /// <summary>
        /// Gets damage of own bot in percent (0-100%).
        /// </summary>
        float Damage { get; }

        /// <summary>
        /// Gets shield status of own bot in percent (0-100%).
        /// </summary>
        float Shield { get; }

        /// <summary>
        /// Gets energy status of own bot in percent (0-100%).
        /// </summary>
        float Energy { get; }
    }
}