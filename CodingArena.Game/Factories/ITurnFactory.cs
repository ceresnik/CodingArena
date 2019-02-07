using CodingArena.Game.Internal;
using System.ComponentModel.Composition;
using CodingArena.Game.Entities;

namespace CodingArena.Game.Factories
{
    public interface ITurnFactory
    {
        ITurn Create(int number);
    }

    [Export(typeof(ITurnFactory))]
    internal class TurnFactory : ITurnFactory
    {
        public ITurn Create(int number) => new Turn(number);
    }
}