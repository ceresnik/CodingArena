using System.ComponentModel.Composition;

namespace CodingArena.Game
{
    [Export(typeof(IMatchFactory))]
    internal class DefaultMatchFactory : IMatchFactory
    {
        private IOutput Output { get; }
        private ISettings Settings { get; }
        private IRoundFactory RoundFactory { get; }

        [ImportingConstructor]
        public DefaultMatchFactory(
            IOutput output, 
            ISettings settings, 
            IRoundFactory roundFactory)
        {
            Output = output;
            Settings = settings;
            RoundFactory = roundFactory;
        }

        public IMatch Create() => new Match(Output, Settings, RoundFactory);
    }
}