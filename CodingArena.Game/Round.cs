using CodingArena.Game.Factories;
using CodingArena.Player.Battlefield;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingArena.Game
{
    public interface IRound
    {
        IRoundController Controller { get; }
        IRoundNotifier Notifier { get; }
    }

    public interface IRoundController
    {
        void Start();
    }

    public interface IRoundNotifier
    {
        int Number { get; }
        IEnumerable<IBotState> BotStates { get; }
        IBattlefieldView Battlefield { get; }
        event EventHandler<TurnEventArgs> TurnStarting;
        event EventHandler<TurnEventArgs> TurnStarted;
    }

    public class RoundEventArgs : EventArgs
    {
        public RoundEventArgs(IRoundNotifier roundNotifier)
        {
            Round = roundNotifier ?? throw new ArgumentNullException(nameof(roundNotifier));
        }

        public IRoundNotifier Round { get; }
    }

    internal sealed class Round : IRound, IRoundController, IRoundNotifier
    {
        private IList<Bot> Bots { get; }
        private ITurnFactory TurnFactory { get; }
        private IOutput Output { get; }
        private ISettings Settings { get; }

        public Round(int number, IOutput output, ISettings settings, IBattlefieldView battlefield, IList<Bot> bots, ITurnFactory turnFactory)
        {
            Number = number;
            Bots = bots ?? throw new ArgumentNullException(nameof(bots));
            TurnFactory = turnFactory;
            Output = output ?? throw new ArgumentNullException(nameof(output));
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
            Battlefield = battlefield ?? throw new ArgumentNullException(nameof(battlefield));
        }

        public IBattlefieldView Battlefield { get; }

        public IRoundController Controller => this;

        public IRoundNotifier Notifier => this;

        public int Number { get; }

        public IEnumerable<IBotState> BotStates => Bots;

        private Task<RoundResult> NoBotsQualified()
        {
            Output.NoBotsQualified();
            return Task.FromResult(RoundResult.NoWinner());
        }

        private Task<RoundResult> OnlyOneBotQualified(Bot bot)
        {
            Output.Qualified(bot);
            return Task.FromResult(RoundResult.Winner(bot.Name));
        }

        private Task<RoundResult> MoreThanOneBotsQualified(IList<Bot> bots)
        {
            PlaceBotsOnBattlefield(bots);
            Output.Qualified(bots);
            ITurn turn = new Turn(0, bots, Battlefield);
            do
            {
                turn = turn.StartTurn();
            } while (bots.Count(b => b.HP > 0) > 1 && turn.Notifier.Number < Settings.MaxTurns);

            if (bots.Count(b => b.HP > 0) == 1)
            {
                var bot = bots.First(b => b.HP > 0);
                return Task.FromResult(RoundResult.Winner(bot.Name));
            }
            return Task.FromResult(RoundResult.NoWinner());
        }

        private void PlaceBotsOnBattlefield(ICollection<Bot> bots)
        {
            var random = new Random((int)DateTime.Now.Ticks);

            foreach (var bot in bots)
            {
                var place = FindEmptyPlace(random);
                bot.MoveTo(new BattlefieldPlace(place.X, place.Y));
            }
        }

        private IBattlefieldPlace FindEmptyPlace(Random random)
        {
            var emptyPlaces = new List<IBattlefieldPlace>();
            for (int y = 0; y < Battlefield.Height; y++)
            {
                for (int x = 0; x < Battlefield.Width; x++)
                {
                    var place = Battlefield[x, y];
                    if (Battlefield.IsEmpty(place))
                        emptyPlaces.Add(place);
                }
            }

            if (emptyPlaces.Any())
                return emptyPlaces[random.Next(emptyPlaces.Count - 1)];

            throw new InvalidOperationException("Failed to find empty place on battlefield.");
        }

        public void Start()
        {
            for (int i = 1; i <= Settings.MaxTurns; i++)
            {
                var turn = TurnFactory.Create(i, new List<Bot>(), Battlefield);
                OnTurnStarting(new TurnEventArgs(turn.Notifier));
                turn.Controller.Start();
                OnTurnStarted(new TurnEventArgs(turn.Notifier));
            }
        }

        public event EventHandler<TurnEventArgs> TurnStarting;

        public event EventHandler<TurnEventArgs> TurnStarted;

        private void OnTurnStarting(TurnEventArgs e) => TurnStarting?.Invoke(this, e);

        private void OnTurnStarted(TurnEventArgs e) => TurnStarted?.Invoke(this, e);
    }
}
