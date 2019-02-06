using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace CodingArena.Game.Factories
{
    public interface IBotFactory
    {
        IReadOnlyCollection<IBattleBot> Create();
    }

    [Export(typeof(IBotFactory))]
    internal class BotFactory : IBotFactory
    {
        public IReadOnlyCollection<IBattleBot> Create()
        {
            throw new System.NotImplementedException();
        }
    }
}