using System.Collections.Generic;

namespace CodingArena.Game
{
    public class TurnResult
    {
        public TurnResult()
        {
            Kills = new Dictionary<IBattleBot, int>();
            Deaths = new Dictionary<IBattleBot, int>();
        }

        public IDictionary<IBattleBot, int> Kills { get; }
        public IDictionary<IBattleBot, int> Deaths { get; }
    }
}