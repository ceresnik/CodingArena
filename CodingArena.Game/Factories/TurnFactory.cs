using CodingArena.Player.Battlefield;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace CodingArena.Game.Factories
{
    public interface ITurnFactory
    {
        ITurn Create(int number, ICollection<Bot> bots, IBattlefieldView battlefield);
    }

    [Export(typeof(ITurnFactory))]
    internal class TurnFactory : ITurnFactory
    {
        public ITurn Create(int number, ICollection<Bot> bots, IBattlefieldView battlefield) =>
            new Turn(number, bots, battlefield);
    }
}