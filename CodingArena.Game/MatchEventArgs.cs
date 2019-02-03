using System;

namespace CodingArena.Game
{
    public class MatchEventArgs
    {
        public MatchEventArgs(IMatchNotifier matchNotifier)
        {
            Match = matchNotifier ?? throw new ArgumentNullException(nameof(matchNotifier));
        }

        public IMatchNotifier Match { get; }
    }
}