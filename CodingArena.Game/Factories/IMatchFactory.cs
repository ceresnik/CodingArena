using CodingArena.Game.Entities;
using CodingArena.Game.Internal;
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
        private ISettings Settings { get; }
        private IRoundFactory RoundFactory { get; }
        private IOutput Output { get; }
        private IScoreRepository ScoreRepository { get; }

        [ImportingConstructor]
        public MatchFactory(
            ISettings settings,
            IRoundFactory roundFactory,
            IOutput output,
            IScoreRepository scoreRepository)
        {
            Settings = settings;
            RoundFactory = roundFactory;
            Output = output;
            ScoreRepository = scoreRepository;
        }

        public IMatch Create() => new Match(Settings, RoundFactory, ScoreRepository);
    }
}