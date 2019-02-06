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

        [ImportingConstructor]
        public MatchFactory(ISettings settings, IRoundFactory roundFactory)
        {
            Settings = settings;
            RoundFactory = roundFactory;
        }

        public IMatch Create() => new Match(Settings, RoundFactory);
    }
}