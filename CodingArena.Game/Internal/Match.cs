using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CodingArena.Game.Entities;
using CodingArena.Game.Factories;

namespace CodingArena.Game.Internal
{
    internal sealed class Match : IMatch
    {
        private readonly IList<Score> scores;
        private ISettings Settings { get; }
        private IRoundFactory RoundFactory { get; }

        public Match(ISettings settings, IRoundFactory roundFactory)
        {
            Settings = settings;
            RoundFactory = roundFactory;
            scores = new List<Score>();
            NextRoundIn = TimeSpan.Zero;
        }

        public IRound Round { get; private set; }

        public IEnumerable<Score> Scores => scores;
        public TimeSpan NextRoundIn { get; private set; }

        public void Start()
        {
            for (int i = 1; i <= Settings.MaxRounds; i++)
            {
                Round = RoundFactory.Create(i);
                OnRoundStarting();
                Round.Start();
                
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

                OnRoundFinished();

                WaitForNextRound();
            }
        }

        public Task StartAsync() => Task.Run(() => Start());

        private void WaitForNextRound()
        {
            NextRoundIn = Settings.NextRoundDelay;
            while (NextRoundIn > TimeSpan.Zero)
            {
                var poll = TimeSpan.FromSeconds(1);
                Thread.Sleep(poll);
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