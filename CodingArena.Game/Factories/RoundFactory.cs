using System.ComponentModel.Composition;
using System.Linq;

namespace CodingArena.Game.Factories
{
    public interface IRoundFactory
    {
        IRound Create();
    }

    [Export(typeof(IRoundFactory))]
    internal class RoundFactory : IRoundFactory
    {
        private IOutput Output { get; }
        private ISettings Settings { get; }
        private IBattlefieldFactory BattlefieldFactory { get; }
        private IBotFactory BotFactory { get; }
        private ITurnFactory TurnFactory { get; }

        [ImportingConstructor]
        public RoundFactory(
            IOutput output,
            ISettings settings,
            IBattlefieldFactory battlefieldFactory,
            IBotFactory botFactory,
            ITurnFactory turnFactory)
        {
            Output = output;
            Settings = settings;
            BattlefieldFactory = battlefieldFactory;
            BotFactory = botFactory;
            TurnFactory = turnFactory;
        }

        public IRound Create()
        {
            var battlefield = BattlefieldFactory.Create();
            Output.SetBattlefield(battlefield);
            var bots = BotFactory.CreateBots(battlefield).ToList();
            return new Round(Output, Settings, battlefield, bots, TurnFactory);
        }
    }
}