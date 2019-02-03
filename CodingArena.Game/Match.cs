using CodingArena.Game.Factories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodingArena.Game
{
    public interface IMatchController
    {
        void Start();
    }

    public interface IMatchNotifier
    {
        event EventHandler<RoundEventArgs> RoundStarting;
        event EventHandler<RoundEventArgs> RoundStarted;
    }

    public interface IMatch
    {
        IRound CreateRound();
        Task WaitForNextRoundAsync();
        void Process(RoundResult roundResult);
        IMatchController Controller { get; }
        IMatchNotifier Notifier { get; }
    }

    internal sealed class Match : IMatch, IMatchController, IMatchNotifier
    {
        public Match(IOutput output, ISettings settings, IRoundFactory roundFactory)
        {
            Output = output ?? throw new ArgumentNullException(nameof(output));
            Settings = settings;
            RoundFactory = roundFactory;
            Winners = new Dictionary<string, int>();
        }

        public IMatchController Controller => this;

        public IMatchNotifier Notifier => this;

        private Dictionary<string, int> Winners { get; }
        private IOutput Output { get; }
        private ISettings Settings { get; }
        private IRoundFactory RoundFactory { get; }

        public IRound CreateRound() => RoundFactory.Create();


        public Task WaitForNextRoundAsync()
        {
            Output.NextRoundIn(Settings.NextRoundDelay);
            return Task.Delay(Settings.NextRoundDelay);
        }

        public void Process(RoundResult roundResult)
        {
            if (roundResult.WinnerName == null)
            {
                return;
            }
            if (Winners.ContainsKey(roundResult.WinnerName))
            {
                Winners[roundResult.WinnerName]++;
            }
            else
            {
                Winners.Add(roundResult.WinnerName, 1);
            }
            Output.MatchResult(Winners);
        }

        public void Start()
        {
            for (int i = 1; i <= Settings.MaxRounds; i++)
            {
                var round = RoundFactory.Create();
                OnRoundStarting(new RoundEventArgs(round.Notifier));
                round.Controller.Start();
                OnRoundStarted(new RoundEventArgs(round.Notifier));
            }
        }

        public event EventHandler<RoundEventArgs> RoundStarting;

        private void OnRoundStarted(RoundEventArgs e) => RoundStarted?.Invoke(this, e);

        public event EventHandler<RoundEventArgs> RoundStarted;

        private void OnRoundStarting(RoundEventArgs e) => RoundStarting?.Invoke(this, e);
    }
}