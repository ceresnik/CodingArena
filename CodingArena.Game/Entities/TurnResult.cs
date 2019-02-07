using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CodingArena.Game.Entities
{
    public class TurnResult
    {
        internal TurnResult(IDictionary<IBattleBot, string> botActionResults)
        {
            BotActionResults = new ReadOnlyDictionary<IBattleBot, string>(botActionResults);
        }

        public IReadOnlyDictionary<IBattleBot, string> BotActionResults { get; }
    }
}