using System.Collections.Generic;

namespace CodingArena.Game.Entities
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