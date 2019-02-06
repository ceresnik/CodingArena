using System.Collections.Generic;
using System.Linq;

namespace CodingArena.Game.Internal
{
    internal class Turn : ITurn
    {
        public TurnResult Start(IEnumerable<IBattleBot> battleBots)
        {
            var botActionResults = new Dictionary<IBattleBot, string>();
            var bots = battleBots.ToList();
            foreach (var battleBot in bots)
            {
                var enemies = bots.Except(new List<IBattleBot> {battleBot}).ToList();
                var botActionResult = battleBot.ExecuteTurnAction(enemies);
                botActionResults.Add(battleBot, botActionResult);
            }
            return new TurnResult(botActionResults);
        }
    }
}