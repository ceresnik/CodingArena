using CodingArena.Player.Battlefield;
using FluentAssertions;

namespace CodingArena.Game.Tests.Verification
{
    internal class BattlefieldPlaceVerification
    {
        private IBattlefieldPlace Place { get; }

        public BattlefieldPlaceVerification(IBattlefieldPlace place)
        {
            Place = place;
        }

        public void Is(int x, int y)
        {
            Place.X.Should().Be(x);
            Place.Y.Should().Be(y);
        }
    }
}