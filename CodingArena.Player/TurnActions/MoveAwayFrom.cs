using CodingArena.Player.Battlefield;
using System;

namespace CodingArena.Player.TurnActions
{
    public class MoveAwayFrom : ITurnAction
    {
        internal MoveAwayFrom(IBattlefieldPlace place)
        {
            Place = place ?? throw new ArgumentNullException(nameof(place));
        }

        public int EnergyCost => 2;
        public IBattlefieldPlace Place { get; }
    }
}