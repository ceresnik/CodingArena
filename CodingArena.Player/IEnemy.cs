namespace CodingArena.Player
{
    public interface IEnemy : IBot
    {
        /// <summary>
        /// Gets a damage of enemy bot in percent (0-100%).
        /// </summary>
        float Damage { get; }

        /// <summary>
        /// Gets a shield status of enemy bot in percent (0-100%).
        /// </summary>
        float Shield { get; }
    }
}