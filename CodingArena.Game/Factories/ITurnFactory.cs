using CodingArena.Game.Internal;
using System.ComponentModel.Composition;

namespace CodingArena.Game.Factories
{
    public interface ITurnFactory
    {
        ITurn Create();
    }

    [Export(typeof(ITurnFactory))]
    internal class TurnFactory : ITurnFactory
    {
        public ITurn Create() => new Turn();
    }
}