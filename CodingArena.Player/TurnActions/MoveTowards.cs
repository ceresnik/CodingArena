using CodingArena.Player.Battlefield;
using System;

namespace CodingArena.Player.TurnActions
{
    public class MoveTowards : ITurnAction
    {
        internal MoveTowards(IBattlefieldPlace newPlace) =>
            Place = newPlace ?? throw new ArgumentNullException(nameof(newPlace));

        public int EnergyCost => 2;

        public IBattlefieldPlace Place { get; }
    }
}