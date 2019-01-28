using System.Collections.Generic;

namespace CodingArena.Game.Console
{
    internal interface IBotFactory
    {
        IEnumerable<Bot> CreateBots();
    }
}