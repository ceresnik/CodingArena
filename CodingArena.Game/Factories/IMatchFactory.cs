using System.ComponentModel.Composition;
using CodingArena.Game.Internal;

namespace CodingArena.Game.Factories
{
    public interface IMatchFactory
    {
        IMatch Create();
    }

    [Export(typeof(IMatchFactory))]
    internal class MatchFactory : IMatchFactory
    {
        private ISettings Settings { get; }
        private IRoundFactory RoundFactory { get; }
        public IOutput Output { get; }

        [ImportingConstructor]
        public MatchFactory(ISettings settings, IRoundFactory roundFactory, IOutput output)
        {
            Settings = settings;
            RoundFactory = roundFactory;
            Output = output;
        }

        public IMatch Create() => new Match(Settings, RoundFactory, Output);
    }
}