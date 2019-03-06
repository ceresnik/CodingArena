using CodingArena.Game.Entities;
using CodingArena.Game.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingArena.Game.Internal
{
    internal sealed class Match : IMatch
    {
        private List<Score> scores;
        private ISettings Settings { get; }
        private IRoundFactory RoundFactory { get; }
        private IScoreRepository ScoreRepository { get; }

        public Match(ISettings settings, IRoundFactory roundFactory, IScoreRepository scoreRepository)
        {
            Settings = settings;
            RoundFactory = roundFactory;
            ScoreRepository = scoreRepository;
            scores = new List<Score>(ScoreRepository.Load());
            NextRoundIn = TimeSpan.Zero;
        }

        public IRound Round { get; private set; }

        public IEnumerable<Score> Scores => scores;
        public TimeSpan NextRoundIn { get; private set; }

        public async Task StartAsync()
        {
            for (int i = 1; i <= Settings.MaxRounds; i++)
            {
                Round = RoundFactory.Create(i);
                OnRoundStarting();
                await Round.StartAsync();
                UpdateScores();
                OnRoundFinished();
                await WaitForNextRoundAsync();
            }
        }

        private void UpdateScores()
        {
            foreach (var roundScore in Round.Scores)
            {
                var existingScore = scores.FirstOrDefault(s => s.BotName == roundScore.BotName);
                if (existingScore != null)
                {
                    existingScore.Kills += roundScore.Kills;
                    existingScore.Deaths += roundScore.Deaths;
                }
                else
                {
                    scores.Add(roundScore);
                }
            }

            scores = scores.OrderByDescending(s => s.Kills - s.Deaths).ToList();
            ScoreRepository.Save(scores);
        }

        private async Task WaitForNextRoundAsync()
        {
            NextRoundIn = Settings.NextRoundDelay;
            while (NextRoundIn > TimeSpan.Zero)
            {
                var poll = TimeSpan.FromSeconds(1);
                await Task.Delay(poll);
                NextRoundIn -= poll;
                OnNextRoundInUpdated();
            }
            NextRoundIn = TimeSpan.Zero;
        }

        public event EventHandler RoundStarting;

        public event EventHandler RoundFinished;

        public event EventHandler NextRoundInUpdated;

        private void OnRoundStarting() => RoundStarting?.Invoke(this, EventArgs.Empty);

        private void OnRoundFinished() => RoundFinished?.Invoke(this, EventArgs.Empty);

        private void OnNextRoundInUpdated() => NextRoundInUpdated?.Invoke(this, EventArgs.Empty);
    }
}