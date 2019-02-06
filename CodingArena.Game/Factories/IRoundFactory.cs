using System.ComponentModel.Composition;
using CodingArena.Game.Internal;

namespace CodingArena.Game.Factories
{
    public interface IRoundFactory
    {
        IRound Create();
    }

    [Export(typeof(IRoundFactory))]
    internal class RoundFactory : IRoundFactory
    {
        private IBotFactory BotFactory { get; }

        [ImportingConstructor]
        public RoundFactory(IBotFactory botFactory)
        {
            BotFactory = botFactory;
        }

        public IRound Create() => new Round(BotFactory);
    }
}