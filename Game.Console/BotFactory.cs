using System.Collections.Generic;

namespace Game.Console
{
    internal class BotFactory
    {
        public IEnumerable<IBot> CreateBots()
        {
            return new List<IBot>();
        }
    }
}