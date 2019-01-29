using System.Collections.Generic;

namespace CodingArena.Game
{
    internal interface IBotFactory
    {
        IEnumerable<Bot> CreateBots(IBattlefield battlefield);
    }
}