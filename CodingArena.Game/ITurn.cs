using System.Collections.Generic;

namespace CodingArena.Game
{
    public interface ITurn
    {
        TurnResult Start(ICollection<IBattleBot> battleBots);
    }
}