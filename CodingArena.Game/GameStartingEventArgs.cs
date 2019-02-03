using System;

namespace CodingArena.Game
{
    public class GameStartingEventArgs
    {
        public IMatchNotifier MatchNotifier { get; }

        public GameStartingEventArgs(IMatchNotifier matchNotifier)
        {
            MatchNotifier = matchNotifier ?? throw new ArgumentNullException(nameof(matchNotifier));
        }
    }
}