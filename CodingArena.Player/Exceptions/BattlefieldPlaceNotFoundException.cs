using System;

namespace CodingArena.Player.Exceptions
{
    /// <summary>
    /// An exception used when place on the battlefield is not found.
    /// </summary>
    public class BattlefieldPlaceNotFoundException : Exception
    {
        /// <summary>
        /// Creates an instance of <see cref="BattlefieldPlaceNotFoundException"/>.
        /// </summary>
        /// <param name="message">A message for the exception.</param>
        public BattlefieldPlaceNotFoundException(string message) : base(message)
        {
        }
    }
}