using System.Collections.Generic;

namespace CodingArena.Game
{
    public class RoundResult
    {
        internal RoundResult(IReadOnlyCollection<Score> scores)
        {
            Scores = scores;
        }

        public IReadOnlyCollection<Score> Scores { get; }
    }
}