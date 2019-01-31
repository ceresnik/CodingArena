using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    public interface IRound
    {
        Task<RoundResult> StartAsync();
    }

    public class Round : IRound
    {
        private IList<Bot> Bots { get; }
        private IOutput Output { get; }
        private ISettings Settings { get; }
        private IBattlefieldView Battlefield { get; }

        public Round(IOutput output, ISettings settings, IBattlefieldView battlefield, IList<Bot> bots)
        {
            Bots = bots ?? throw new ArgumentNullException(nameof(bots));
            Output = output ?? throw new ArgumentNullException(nameof(output));
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
            Battlefield = battlefield ?? throw new ArgumentNullException(nameof(battlefield));
        }

        public Task<RoundResult> StartAsync()
        {
            Output.StartRound();
            return Bots.Any() == false
                ? NoBotsQualified()
                : Bots.Count == 1
                    ? OnlyOneBotQualified(Bots.First())
                    : MoreThanOneBotsQualified(Bots);
        }

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
            } while (bots.Count(b => b.HP > 0) > 1 && turn.Number < Settings.MaxTurns);

            if (bots.Count(b => b.HP > 0) == 1)
            {
                var bot = bots.First(b => b.HP > 0);
                return Task.FromResult(RoundResult.Winner(bot.Name));
            }
            return Task.FromResult(RoundResult.NoWinner());
        }

        private void PlaceBotsOnBattlefield(ICollection<Bot> bots)
        {
            var random = new Random((int) DateTime.Now.Ticks);

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
    }
}
