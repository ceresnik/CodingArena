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
        private ISettings Settings { get; }
        private ITurnFactory TurnFactory { get; }
        private IBattlefieldFactory BattlefieldFactory { get; }

        [ImportingConstructor]
        public RoundFactory(IBotFactory botFactory, ISettings settings, ITurnFactory turnFactory, IBattlefieldFactory battlefieldFactory)
        {
            BotFactory = botFactory;
            Settings = settings;
            TurnFactory = turnFactory;
            BattlefieldFactory = battlefieldFactory;
        }

        public IRound Create() => new Round(BotFactory, Settings, TurnFactory, BattlefieldFactory);
    }
}