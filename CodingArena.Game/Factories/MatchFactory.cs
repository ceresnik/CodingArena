using System.ComponentModel.Composition;

namespace CodingArena.Game.Factories
{
    public interface IMatchFactory
    {
        IMatch Create();
    }

    [Export(typeof(IMatchFactory))]
    internal class MatchFactory : IMatchFactory
    {
        private IOutput Output { get; }
        private ISettings Settings { get; }
        private IRoundFactory RoundFactory { get; }

        [ImportingConstructor]
        public MatchFactory(
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