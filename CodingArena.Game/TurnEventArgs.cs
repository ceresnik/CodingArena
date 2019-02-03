using System;

namespace CodingArena.Game
{
    public class TurnEventArgs : EventArgs
    {
        public TurnEventArgs(ITurnNotifier turnNotifier)
        {
            Turn = turnNotifier ?? throw new ArgumentNullException(nameof(turnNotifier));
        }

        public ITurnNotifier Turn { get; }
    }
}