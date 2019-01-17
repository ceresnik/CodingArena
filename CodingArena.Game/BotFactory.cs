using System.Collections.Generic;
using System.Collections.ObjectModel;
using CodingArena.Player.Implement;

namespace CodingArena.Game
{
    internal sealed class BotFactory
    {
        public ICollection<IBot> CreateBots() => new Collection<IBot>();
    }
}