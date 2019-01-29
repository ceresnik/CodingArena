using System.ComponentModel.Composition;

namespace CodingArena.Game
{
    [Export(typeof(IMatchFactory))]
    internal class DefaultMatchFactory : IMatchFactory
    {
        private IOutput Output { get; }
        private ISettings Settings { get; }
        private IBotFactory BotFactory { get; }
        private IBattlefieldFactory BattlefieldFactory { get; }

        [ImportingConstructor]
        public DefaultMatchFactory(
            IOutput output, 
            ISettings settings, 
            IBotFactory botFactory, 
            IBattlefieldFactory battlefieldFactory)
        {
            Output = output;
            Settings = settings;
            BotFactory = botFactory;
            BattlefieldFactory = battlefieldFactory;
        }

        public IMatch Create() => new Match(Output, Settings, BotFactory, BattlefieldFactory);
    }
}