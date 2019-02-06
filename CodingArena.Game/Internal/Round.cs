using System;
using System.Collections.Generic;
using CodingArena.Game.Factories;

namespace CodingArena.Game.Internal
{
    internal class Round : IRound
    {
        private IBotFactory BotFactory { get; }

        public Round(IBotFactory botFactory)
        {
            BotFactory = botFactory ?? throw new ArgumentNullException(nameof(botFactory));
        }

        public RoundResult Start()
        {
            var bots = BotFactory.Create();
            var scores = new List<Score>();
            foreach (var bot in bots)
            {
                var score = new Score(bot.Name);
                scores.Add(score);
            }
            return new RoundResult(scores);
        }
    }
}