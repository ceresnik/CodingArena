using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CodingArena.Game.Entities;
using CodingArena.Game.Factories;

namespace CodingArena.Game.Internal
{
    internal sealed class Round : IRound
    {
        private IBotFactory BotFactory { get; }
        private ISettings Settings { get; }
        private ITurnFactory TurnFactory { get; }
        private IBattlefieldFactory BattlefieldFactory { get; }

        public Round(
            int number,
            IBotFactory botFactory, 
            ISettings settings, 
            ITurnFactory turnFactory, 
            IBattlefieldFactory battlefieldFactory)
        {
            Number = number;
            BotFactory = botFactory ?? throw new ArgumentNullException(nameof(botFactory));
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
            TurnFactory = turnFactory ?? throw new ArgumentNullException(nameof(turnFactory));
            BattlefieldFactory = battlefieldFactory ?? throw new ArgumentNullException(nameof(battlefieldFactory));
        }

        public int Number { get; }
        public IEnumerable<IBattleBot> Bots { get; private set; }
        public IBattlefield Battlefield { get; private set; }
        public ITurn Turn { get; private set; }
        public IEnumerable<Score> Scores { get; private set; }

        public void Start()
        {
            Battlefield = BattlefieldFactory.Create();
            Bots = BotFactory.Create(Battlefield);
            Battlefield.SetRandomly(Bots);

            for (int i = 1; i <= Settings.MaxTurns; i++)
            {
                OnTurnStarting();
                Turn = TurnFactory.Create(i);
                Turn.Start(Bots);
                OnTurnFinished();
                if (Bots.Count(b => b.HP > 0) <= 1) break;
                WaitForNextTurn();
            }

            var scores = new List<Score>();
            foreach (var bot in Bots)
            {
                scores.Add(new Score(bot.Name) {Kills = bot.Kills, Deaths = bot.Deaths});
            }
            Scores = scores;
        }

        private void WaitForNextTurn() => Thread.Sleep(Settings.NextTurnDelay);

        public event EventHandler TurnStarting;

        public event EventHandler TurnFinished;

        private void OnTurnStarting() => TurnStarting?.Invoke(this, EventArgs.Empty);

        private void OnTurnFinished() => TurnFinished?.Invoke(this, EventArgs.Empty);
    }
}