namespace CodingArena.Player
{
    public interface IEnergy
    {
        /// <summary>
        ///     Gets a value of maximum energy points.
        /// </summary>
        int Maximum { get; }

        /// <summary>
        ///     Gets a value of actual energy points.
        /// </summary>
        int Actual { get; }

        /// <summary>
        ///     Gets a value of actual energy points in percent (0 - 100%).
        /// </summary>
        int Percent { get; }
    }
}