using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace CodingArena.Game.Factories
{
    public interface IBotFactory
    {
        IReadOnlyCollection<IBattleBot> Create(IBattlefield battlefield);
    }

    [Export(typeof(IBotFactory))]
    internal class BotFactory : IBotFactory
    {
        public IReadOnlyCollection<IBattleBot> Create(IBattlefield battlefield)
        {
            throw new System.NotImplementedException();
        }
    }
}