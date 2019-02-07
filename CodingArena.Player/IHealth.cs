namespace CodingArena.Player
{
    public interface IHealth
    {
        /// <summary>
        ///     Gets a value of maximum health points.
        /// </summary>
        int Maximum { get; }

        /// <summary>
        ///     Gets a value of actual health points.
        /// </summary>
        int Actual { get; }

        /// <summary>
        ///     Gets a value of actual health points in percent (0 - 100%).
        /// </summary>
        int Percent { get; }
    }
}