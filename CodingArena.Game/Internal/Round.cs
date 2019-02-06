using System;
using System.Collections.Generic;
using CodingArena.Game.Factories;

namespace CodingArena.Game.Internal
{
    internal class Round : IRound
    {
        private IBotFactory BotFactory { get; }
        private ISettings Settings { get; }
        private ITurnFactory TurnFactory { get; }
        private IBattlefieldFactory BattlefieldFactory { get; }

        public Round(
            IBotFactory botFactory, 
            ISettings settings, 
            ITurnFactory turnFactory, 
            IBattlefieldFactory battlefieldFactory)
        {
            BotFactory = botFactory ?? throw new ArgumentNullException(nameof(botFactory));
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
            TurnFactory = turnFactory ?? throw new ArgumentNullException(nameof(turnFactory));
            BattlefieldFactory = battlefieldFactory ?? throw new ArgumentNullException(nameof(battlefieldFactory));
        }

        public RoundResult Start()
        {
            var battlefield = BattlefieldFactory.Create();
            var bots = BotFactory.Create(battlefield);
            battlefield.SetRandomly(bots);
            var scores = new List<Score>();
            for (int i = 1; i <= Settings.MaxTurns; i++)
            {
                var turn = TurnFactory.Create();
                var turnResult = turn.Start(bots);
            }

            foreach (var bot in bots)
            {
                var score = new Score(bot.Name) {Kills = bot.Kills, Deaths = bot.Deaths};
                scores.Add(score);
            }
            return new RoundResult(scores);
        }
    }
}