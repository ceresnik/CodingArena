using CodingArena.Game.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingArena.Game.Internal
{
    internal class Turn : ITurn
    {
        public Turn(int number)
        {
            Number = number;
            BotActions = new Dictionary<IBattleBot, string>();
        }

        public int Number { get; }
        public IDictionary<IBattleBot, string> BotActions { get; }

        public void Start(IEnumerable<IBattleBot> battleBots)
        {
            var bots = battleBots.ToList();
            foreach (var battleBot in bots)
            {
                var enemies = bots.Except(new List<IBattleBot> { battleBot }).ToList();
                battleBot.ExecuteTurnAction(enemies.Where(e => e.HP > 0));
                BotActions.Add(battleBot, battleBot.Action);
            }
        }

        public Task StartAsync(IEnumerable<IBattleBot> battleBots) => Task.Run(() => Start(battleBots));
    }
}