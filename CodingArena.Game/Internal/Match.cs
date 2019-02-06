using System.Collections.Generic;
using System.Linq;
using CodingArena.Game.Factories;

namespace CodingArena.Game.Internal
{
    internal class Match : IMatch
    {
        public ISettings Settings { get; }
        private IRoundFactory RoundFactory { get; }

        public Match(ISettings settings, IRoundFactory roundFactory)
        {
            Settings = settings;
            RoundFactory = roundFactory;
        }

        public MatchResult Start()
        {
            var scores = new List<Score>();
            for (int i = 0; i < Settings.MaxRounds; i++)
            {
                var round = RoundFactory.Create();
                var roundResult = round.Start();
                foreach (var roundResultScore in roundResult.Scores)
                {
                    var existingScore = scores.SingleOrDefault(s => s.BotName == roundResultScore.BotName);
                    if (existingScore != null)
                    {

                        existingScore.Kills += roundResultScore.Kills;
                        existingScore.Deaths += roundResultScore.Deaths;
                    }
                    else
                    {
                        scores.Add(roundResultScore);
                    }
                }
            }
            return new MatchResult(scores);
        }
    }
}