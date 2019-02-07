using System.Collections.Generic;

namespace CodingArena.Game
{
    public interface ITurn
    {
        int Number { get; }
        IDictionary<IBattleBot, string> BotActions { get; }
        void Start(IEnumerable<IBattleBot> battleBots);
    }
}