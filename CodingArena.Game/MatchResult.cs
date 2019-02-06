using System.Collections.Generic;

namespace CodingArena.Game
{
    public class MatchResult
    {
        internal MatchResult(IReadOnlyCollection<Score> scores)
        {
            Scores = scores;
        }

        public IReadOnlyCollection<Score> Scores { get; }
    }
}