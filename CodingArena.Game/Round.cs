using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    internal class Round : IRound
    {
        private IOutput Output { get; }
        private ISettings Settings { get; }

        public Round(IOutput output, ISettings settings)
        {
            Output = output;
            Settings = settings;
        }

        public Task<RoundResult> StartAsync(IList<Bot> bots, Battlefield battlefield)
        {
            if (bots == null) throw new ArgumentNullException(nameof(bots));
            if (battlefield == null) throw new ArgumentNullException(nameof(battlefield));

            Output.StartRound();
            return bots.Any() == false
                ? NoBotsQualified()
                : bots.Count == 1
                    ? OnlyOneBotQualified(bots.First())
                    : MoreThanOneBotsQualified(bots, battlefield);
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

        private Task<RoundResult> MoreThanOneBotsQualified(IList<Bot> bots, Battlefield battlefield)
        {
            PlaceBotsOnBattlefield(bots, battlefield);
            Output.Qualified(bots);
            var turn = new Turn(0, bots, battlefield);
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

        private void PlaceBotsOnBattlefield(ICollection<Bot> bots, Battlefield battlefield)
        {
            var random = new Random((int) DateTime.Now.Ticks);

            foreach (var bot in bots)
            {
                var place = FindEmptyPlace(battlefield, random);
                battlefield[place.X, place.Y] = new BattlefieldPlace(place.X, place.Y, bot);
            }
        }

        private static IBattlefieldPlace FindEmptyPlace(Battlefield battlefield, Random random)
        {
            var emptyPlaces = new List<IBattlefieldPlace>();
            for (int y = 0; y < battlefield.Size.Height; y++)
            {
                for (int x = 0; x < battlefield.Size.Width; x++)
                {
                    if (battlefield[x, y].IsEmpty)
                        emptyPlaces.Add(battlefield[x, y]);
                }
            }

            if (emptyPlaces.Any())
                return emptyPlaces[random.Next(emptyPlaces.Count - 1)];

            throw new InvalidOperationException("Failed to find empty place on battlefield.");
        }
    }
}
