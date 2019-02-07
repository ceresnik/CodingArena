namespace CodingArena.Player
{
    public interface IShield
    {
        /// <summary>
        ///     Gets a value of maximum shield points.
        /// </summary>
        int Maximum { get; }

        /// <summary>
        ///     Gets a value of actual shield points.
        /// </summary>
        int Actual { get; }

        /// <summary>
        ///     Gets a value of actual shield points in percent (0 - 100%).
        /// </summary>
        int Percent { get; }
    }
}