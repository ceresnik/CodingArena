using System.ComponentModel.Composition;
using CodingArena.Game.Entities;
using CodingArena.Game.Internal;

namespace CodingArena.Game.Factories
{
    public interface IRoundFactory
    {
        IRound Create(int number);
    }

    [Export(typeof(IRoundFactory))]
    internal class RoundFactory : IRoundFactory
    {
        private IBotFactory BotFactory { get; }
        private ISettings Settings { get; }
        private ITurnFactory TurnFactory { get; }
        private IBattlefieldFactory BattlefieldFactory { get; }

        [ImportingConstructor]
        public RoundFactory(
            IBotFactory botFactory, 
            ISettings settings, 
            ITurnFactory turnFactory, 
            IBattlefieldFactory battlefieldFactory,
            IOutput output)
        {
            BotFactory = botFactory;
            Settings = settings;
            TurnFactory = turnFactory;
            BattlefieldFactory = battlefieldFactory;
        }

        public IRound Create(int number) => new Round(number, BotFactory, Settings, TurnFactory, BattlefieldFactory);
    }
}