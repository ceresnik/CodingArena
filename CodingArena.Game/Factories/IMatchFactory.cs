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
        public IMatch Create() => new Match();
    }
}