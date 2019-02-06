using System.Collections.Generic;
using System.Linq;

namespace CodingArena.Game.Internal
{
    internal class Turn : ITurn
    {
        public TurnResult Start(ICollection<IBattleBot> battleBots)
        {
            var botActionResults = new Dictionary<IBattleBot, string>();
            foreach (var battleBot in battleBots)
            {
                var enemies = battleBots.Except(new List<IBattleBot> {battleBot}).ToList();
                var botActionResult = battleBot.ExecuteTurnAction(enemies);
                botActionResults.Add(battleBot, botActionResult);
            }
            return new TurnResult(botActionResults);
        }
    }
}